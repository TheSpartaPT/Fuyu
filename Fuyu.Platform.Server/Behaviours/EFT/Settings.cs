using Fuyu.Platform.Common.Networking;
using Fuyu.Platform.Common.IO;

namespace Fuyu.Platform.Server.Behaviours.EFT
{
    public class Settings : FuyuHttpBehaviour
    {
        private readonly string _response;

        public Settings() : base("/client/settings")
        {
            _response = Resx.GetText("eft", "database.eft.client.settings.json");
        }

        public override void Run(FuyuHttpContext context)
        {
            SendJson(context, _response);
        }
    }
}