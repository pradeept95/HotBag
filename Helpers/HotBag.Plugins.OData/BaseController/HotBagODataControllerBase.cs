using HotBag.BaseController;
using HotBag.Identity.AppSession;
using Microsoft.AspNet.OData;

namespace HotBag.Plugins.OData
{
    public class HotBagODataControllerBase : ODataController
    {
        protected readonly IAppSession AppSession;
        public HotBagODataControllerBase()
        {
            AppSession = NullAppSession.Instance;
        }
    } 
}
