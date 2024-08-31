using Fuyu.Platform.Common.Http;
using Fuyu.Platform.Common.Models.EFT.Responses;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class GameMode : FuyuBehaviour
    {
        public GameMode() : base("/client/game/mode")
        {
        }

        public override void Run(FuyuContext context)
        {
            var response = new ResponseBody<GameModeResponse>()
            {
                data = new GameModeResponse()
                {
                    gameMode = "pve",
                    backendUrl = "http://localhost:8000"
                }
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}