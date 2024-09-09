using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Fuyu.Common.Compression;
using Fuyu.Common.Serialization;

namespace Fuyu.Common.Networking
{
    public class HttpContext : Context
    {
        public HttpContext(HttpListenerRequest request, HttpListenerResponse response) : base(request, response)
        {
        }

        public bool HasBody()
        {
            return Request.HasEntityBody;
        }

        public async Task<byte[]> GetBinaryAsync()
        {
            using (var ms = new MemoryStream())
            {
                await Request.InputStream.CopyToAsync(ms);
                var body = ms.ToArray();

                if (Zlib.IsCompressed(body))
                {
                    body = Zlib.Decompress(body);
                }

                return body;
            }
        }

        public async Task<string> GetTextAsync()
        {
            var body = await GetBinaryAsync();
            return Encoding.UTF8.GetString(body);
        }

        public async Task<T> GetJsonAsync<T>()
        {
            var json = await GetTextAsync();
            return Json.Parse<T>(json);
        }

        public string GetSessionId()
        {
            return Request.Cookies["PHPSESSID"].Value;
        }

        protected async Task SendAsync(byte[] data, string mime, bool zipped = true)
        {
            // used for plaintext debugging
            if (Request.Headers["fuyu-debug"] != null)
            {
                zipped = false;
            }

            if (zipped)
            {
                data = Zlib.Compress(data, ZlibCompression.Level9);
            }

            Response.ContentType = mime;
            Response.ContentLength64 = data.Length;

            using (var payload = Response.OutputStream)
            {
                await payload.WriteAsync(data, 0, data.Length);
            }
        }

        public async Task SendJsonAsync(string text, bool zipped = true)
        {
            var encoded = Encoding.UTF8.GetBytes(text);
            await SendAsync(encoded, "application/json; charset=utf-8", zipped);
        }

        public void Close()
        {
            Response.Close();
        }
    }
}