using Fuyu.Platform.Common.Networking;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class CheckVersion : FuyuHttpBehaviour
    {
        public CheckVersion() : base("/client/checkVersion")
        {
        }

        public override void Run(FuyuHttpContext context)
        {
            var response = new ResponseBody<CheckVersionResponse>()
            {
                data = new CheckVersionResponse()
                {
                    isvalid = true,
                    latestVersion = "0.15.0.2.32197"
                }
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}