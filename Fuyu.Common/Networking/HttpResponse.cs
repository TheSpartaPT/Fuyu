namespace Fuyu.Common.Networking
{
    public class HttpResponse
    {
        // TODO:
        // * use enum instead
        // -- seionmoya, 2024/09/19
        public int Status;

        // TODO:
        // * use System.Memory<byte> instead
        // -- seionmoya, 2024/09/19
        public byte[] Body;
    }
}