using HotBag.OptionConfigurer.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace HotBag.OptionConfigurer
{
    public static class OptionConfigurer
    {
        public static IServiceCollection ConfigureApplicationSettings(this IServiceCollection serviceCollection, IConfiguration configuration)
        {

            serviceCollection.Configure<TokenAuthConfiguration>(options =>
            {
                options.SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Authentication:JwtBearer:SecurityKey"]));
                options.Issuer = configuration["Authentication:JwtBearer:Issuer"];
                options.Audience = configuration["Authentication:JwtBearer:Audience"];
                options.SigningCredentials = new SigningCredentials(options.SecurityKey, SecurityAlgorithms.HmacSha256);
                options.Expiration = TimeSpan.FromDays(1);
            });

            serviceCollection.Configure<MongoDbSettings>(options =>
            {
                options.Database = configuration["Configuration:MongoDb:ConnectionString:Default:Database"];
                options.ConnectionString = configuration["Configuration:MongoDb:ConnectionString:Default:Connection"]; 
            });

            return serviceCollection;
        }
    }
}
