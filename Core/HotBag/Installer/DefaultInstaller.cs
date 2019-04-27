using HotBag;
using HotBag.Modules;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HotBag.Installer
{
    public static class DefaultInstaller 
    {
        public static void InstallDefaultModule()
        {
            string json = System.IO.File.ReadAllText("modulesettings.json");
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            var modules = (jsonObj["Modules"]["Default"]).ToString().Split(",");
            foreach (var module in modules)
            {
                if (string.IsNullOrEmpty(module)) continue;
                HotBagConfiguration.Configurations.ModuleSetting.InstallModule(module.Trim());
            }
        }

        public static void InstallApplicationModule()
        {
            string json = System.IO.File.ReadAllText("modulesettings.json");
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            var modules = (jsonObj["Modules"]["Installed"]).ToString().Split(",");
            foreach (var module in modules)
            {
                if (string.IsNullOrEmpty(module)) continue;
                HotBagConfiguration.Configurations.ModuleSetting.InstallModule(module.Trim());
            }
        }

        public static void RegisterAllModule(List<IApplicationModule> moduleInstances)
        { 
            foreach (var instance in moduleInstances)
            {
                var moduleName = instance.ModuleName;
                if (string.IsNullOrEmpty(moduleName)) continue;
                HotBagConfiguration.Configurations.ModuleSetting.RegisterModule(moduleName); 
            } 
        }
    }
}
