using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Server.BSG.DTO.Responses;

namespace Fuyu.Server.EFT.Controllers
{
    public class GameVersionValidateController : HttpController
    {
        public GameVersionValidateController() : base("/client/game/version/validate")
        {
        }

        public override void Run(HttpContext context)
        {
            var response = new ResponseBody<object>()
            {
                data = null
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}