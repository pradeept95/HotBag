using HotBag.BaseController;
using HotBag.ResultWrapper.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotBag.Web.Core.Controllers.TokenAuth
{
    public class TokenAuthController : BaseApiController
    {
        [HttpGet]
        [Route("Get")] 
        public async Task<ListResultDto<string>> GetString()
        {
            var result = new List<string> {
                "Asdf", "Pqrs"
            };

            return new ListResultDto<string>(result, "this is summary");
        }
    }
}
