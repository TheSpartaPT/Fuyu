using Fuyu.Server.Arena.DTO.Responses;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;

namespace Fuyu.Server.Arena.Controllers
{
    public class MailDialogListController : HttpController
    {
        public MailDialogListController() : base("/client/mail/dialog/list")
        {
        }

        public override void Run(HttpContext context)
        {
            var response = new ResponseBody<object[]>
            {
                data = []
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}