using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HotBag.Plugins.Email
{
    public static class EmailConfigurer
    {
        public static IServiceCollection ConfigureEmailSettings(this IServiceCollection serviceCollection, IConfiguration configuration)
        { 
            serviceCollection.Configure<Email.Settings.EmailSettings>(options =>
            {
                options.EncryptedEmailAddress = configuration["EmailConfig:EncryptedEmailAddress"];
                options.EncryptedPassword = configuration["EmailConfig:EncryptedPassword"];
                options.Host = configuration["EmailConfig:Host"];
                options.Port = configuration["EmailConfig:Port"];
                options.EnableSSL = Convert.ToBoolean(configuration["EmailConfig:EnableSSL"]);
                options.DefaultCCEmails = configuration["EmailConfig:DefaultCCEmails"];
                options.DefaultEmails = configuration["EmailConfig:DefaultEmails"];
                options.DefaultSubject = configuration["EmailConfig:DefaultSubject"]; 
            });

            return serviceCollection;
        }
    }
}
