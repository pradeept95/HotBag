using HotBag.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Web.Host
{
    public class HostModule : ApplicationModule
    {
        public override string ModuleName
        {
            get { return "HostModule"; } 
        } 
    }
}
