using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Threading.Tasks;

namespace Application.Core.Identity.PermissionChecker
{
    public sealed class NullPermissionChecker : IPermissionChecker
    {
        /// <summary>
        /// Singleton instance.
        /// </summary>
        public static NullPermissionChecker Instance { get; } = new NullPermissionChecker();

        public Task<bool> IsGrantedAsync(string permissionName)
        {
            return Task.FromResult(true);
        }

        public Task<bool> IsGrantedAsync(UserIdentifier user, string permissionName)
        {
            return Task.FromResult(true);
        }
    }
}
