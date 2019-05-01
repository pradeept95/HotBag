using HotBag.BaseController;
using HotBag.ResultWrapper.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotBag.Plugins.Email.Controller
{
    public class HotBagCoreEmailController : BaseApiController
    {
        [HttpPost]
        [Route("SendEmail")]
        public async Task<ResultDto<string>> SendEmail()
        {
            return new ResultDto<string>("Successfully Sent");
        }
    }
}
