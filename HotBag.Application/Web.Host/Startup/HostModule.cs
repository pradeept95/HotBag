using HotBag.AuthConfiguration;
using HotBag.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Host
{
    public class HostModule : ApplicationModule
    {

        public override void PreInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.Configure<TokenAuthConfiguration>(options =>
            {
                options.SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Authentication:JwtBearer:SecurityKey"]));
                options.Issuer = configuration["Authentication:JwtBearer:Issuer"];
                options.Audience = configuration["Authentication:JwtBearer:Audience"];
                options.SigningCredentials = new SigningCredentials(options.SecurityKey, SecurityAlgorithms.HmacSha256);
                options.Expiration = TimeSpan.FromDays(1);
            });
        }

        public override void Initialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            
        }

        public override void PostInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            
        }

    }
}
