using HotBag.DI.Base;
using HotBag.Modules;
using HotBag.Services.RepositoryFactory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotBag.Services
{
    public class ApplicationServiceModule : ApplicationModule
    {
        public override string ModuleName
        {
            get { return "ApplicationServiceModule"; } 
        }  
    }
}
