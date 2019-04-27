using Microsoft.AspNetCore.Mvc;

namespace Web.Host.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("/swagger");
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
    }
}
