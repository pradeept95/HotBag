using HotBag.BaseController;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotBag.Web.Core.Controllers.TokenAuth
{
    public class TokenAuthController : BaseApiController
    {
        [HttpGet]
        [Route("Get")] 
        public List<string> GetString()
        {
            return new List<string> {
                "Asdf", "Pqrs"
            };
        }
    }
}
