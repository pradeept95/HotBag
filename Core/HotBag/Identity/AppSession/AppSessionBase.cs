using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace HotBag.Identity.AppSession
{
    public class NullAppSession : AppSessionBase
    { 
        /// <summary>
        /// Singleton instance.
        /// </summary>AppSession
        public static NullAppSession Instance { get; } = new NullAppSession(); 

        private readonly HttpContextAccessor _httpContextAccessor;
        private string currentUserId = null; 

        public NullAppSession()
        {
            _httpContextAccessor = new HttpContextAccessor();
        }
        public override string UserId
        {
            get
            {
                var claimsIdentity = this._httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
                currentUserId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(currentUserId))
                {
                    //throw new System.UnauthorizedAccessException();
                    return null; //return null if user does not exists
                }
                return currentUserId;
            }
        }

        public override string ImpersonatorUserId => throw new System.NotImplementedException();

        public override HttpContext HttpContext {
            get
            {  
                return this._httpContextAccessor.HttpContext;
            }
        }
    }

    public abstract class AppSessionBase : IAppSession
    {
        
        public abstract string  UserId { get; }

        public abstract string ImpersonatorUserId { get; }

        public abstract HttpContext HttpContext { get; }
    }


}
