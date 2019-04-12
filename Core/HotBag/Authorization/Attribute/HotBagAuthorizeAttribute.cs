using HotBag.ResultWrapper.WrapperModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Security.Claims;

namespace HotBag.Authorization.Attribute
{
    public class HotBagAuthorizeAttribute : TypeFilterAttribute
    { 
        public HotBagAuthorizeAttribute(string claimType, string claimValue, bool RequiredAllPermission = false) : base(typeof(ClaimRequirementFilter))
        { 
            Arguments = new object[] {
                new Claim(claimType, claimValue),
                RequiredAllPermission
            };
        }
    }

    public class ClaimRequirementFilter : IAuthorizationFilter
    {
        readonly Claim _claim;
        readonly bool _requiredAllPermission = false;

        public ClaimRequirementFilter(Claim claim, bool requiredAllPermission)
        {
            _claim = claim;
            _requiredAllPermission = requiredAllPermission;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var modulePermissions = _claim.Value.Split(",").Select(x => x.Trim()).ToList();
            var hasClaim = false;
             
            var assignedClaims = context.HttpContext.User.Claims.Where(c => c.Type == _claim.Type).Select(c => c.Value).FirstOrDefault()?.Split(",");

            if (_requiredAllPermission)
                hasClaim = modulePermissions.All(x => assignedClaims.Contains(x));
            else
                hasClaim = modulePermissions.Any(x => assignedClaims.Contains(x));


            if (!hasClaim)
            {
                //get not assigned permission\  
                var unAssignedPermission = modulePermissions.FirstOrDefault(x => !assignedClaims.Contains(x));

                var arr = unAssignedPermission.Split(".").ToList(); 

                var msg = "";
                switch (arr.Count)
                {
                    case 1:
                        msg = arr.First();
                       break;
                    case 2:
                        msg = $"for {arr.First()} Module with {arr.Skip(1).First()} Policy";
                        break;
                    default:
                        break;
                }
                 
                 throw new System.UnauthorizedAccessException($"User does not have one of the required permission {msg}");
            }
        }
    }
}
