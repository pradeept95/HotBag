using HotBag.Modules;
using HotBag.SB.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;

namespace HotBag.Plugins.Swagger
{
    public class HotBagSwaggerModuel : ApplicationModule
    {
        public override string ModuleName
        {
            get { return "HotBagSwaggerModuel"; }

        }

        public override void Initialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            // Register the Swagger generator, defining 1 or more Swagger documents
            serviceCollection.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = $"{configuration.GetSection("App:Name").Value} Api",
                    Description = $"{configuration.GetSection("App:Description").Value}",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Pradeep Raj Thapaliya",
                        Email = "pradeep.thapaliya@amniltech.com",
                        Url = "https://www.pradeeprajthapaliya.com.np"
                    },
                    License = new License
                    {
                        Name = "Git Source Url",
                        Url = "https://github.com/pradeep9860/HotBag"
                    }
                });

                // Swagger 2.+ support
                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                c.AddSecurityRequirement(security);
                c.DocumentFilter<CustomDocumentFilter>();
                c.OperationFilter<GenericOperationFilter>();
            });

        }

        public override void PostInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {

        }

        public override void PreInitialize(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            
        }
    }
}
