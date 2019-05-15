using HotBag;
using HotBag.Configuration.Global.ModuleInstallation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Web.Host.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApplicationLifetime _applicationLifetime;
        public HomeController(IApplicationLifetime applicationLifetime)
        {
            _applicationLifetime = applicationLifetime;
        }   

        public IActionResult Index()
        {
            //return Redirect("/swagger");
            return Redirect("/home/install");
            //return View();
        } 
          
        public IActionResult Install()
        {
            //string json = System.IO.File.ReadAllText("modulesettings.json");
            //dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            //jsonObj["Modules"]["Installed"] = "ABC, BCD";
            //string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            //System.IO.File.WriteAllText("modulesettings.json", output);
            return View();
        }

        [HttpGet] 
        public JsonResult GetAllModule()
        {
            var modules = HotBagConfiguration.Configurations.ModuleSetting.GetAllModuleInfo();
            var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "modulesettings.json");
            string json = System.IO.File.ReadAllText(filePath);
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            var coreModuleList = new List<string>();
            var allCoreModuel = (jsonObj["Modules"]["Default"]).ToString().Split(",");
            foreach (var item in allCoreModuel)
            {
                coreModuleList.Add(item);
            }

            var allORMModuel = (jsonObj["Modules"]["ORM"]).ToString().Split(",");
            foreach (var item in allORMModuel)
            {
                coreModuleList.Add(item);
            }

            return Json(new { data = modules.Where(x => !coreModuleList.Contains(x.ModuleName)).ToList() });
        }

        [HttpPost]
        public JsonResult UpdateInstall(ModuleList model)
        {
            try
            {
                var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "modulesettings.json");
                string json = System.IO.File.ReadAllText(filePath);
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                var coreModuleList = new List<string>();
                var allCoreModuel = (jsonObj["Modules"]["Default"]).ToString().Split(",");
                foreach (var item in allCoreModuel)
                {
                    coreModuleList.Add(item);
                }

                var newModules = model.modules.ToList().Where(x => x.IsInstalled && !coreModuleList.Contains(x.ModuleName))
                                        .Select(x => x.ModuleName);
                
                var installedModules = string.Join(',', newModules); 

                jsonObj["Modules"]["Installed"] = installedModules;
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                System.IO.File.WriteAllText(filePath, output);
                return Json(new { success = true, message = "Module(s) Sussessfully updated" });
            }
            catch (System.Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public JsonResult RestartApplication()
        {
            try
            {
                _applicationLifetime.StopApplication(); 
                return Json(new { success = true, message = "Application Successfully starting." });
            }
            catch (System.Exception ex)
            {

                return Json(new { success = false, message = ex.Message });
            }
        }
    }

    public class ModuleList
    {
        public ModuleList()
        {
            this.modules = new List<ModuleInfo>();
        }
        public List<ModuleInfo> modules { get; set; } 
    }
}
