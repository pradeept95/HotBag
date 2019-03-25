using Core;
using HotBag.ResultWrapper.Extensions;
using HotBag.ResultWrapper.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotBag.Web.Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //You can remove the APIController attribute to disable the automatic model 
            //validation. But, then you will lose the other benefits of this attribute like disabling 
            //conventional routing and allowing model binding without adding[FromBody] parameter attributes.

            //The better approach to disable the default behavior by setting 
            //SuppressModelStateInvalidFilter option to true.You can set this option to 
            //true in the ConfigureServices method.Like
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddMvc(
                options =>
                {
                    options.Filters.Add(typeof(ModelStateFeatureFilter));  //this will allow you to 
                                                                           //options.OutputFormatters.Add(new PascalCaseJsonProfileFormatter());
                }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSingleton(Configuration);
            var serviceProvider = services.BuildServiceProvider();
            services.RegisterHotBagCore(serviceProvider);
        }

        // Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseWhen(context => context.Request.Path.StartsWithSegments("/api"), appBuilder =>
            {
                appBuilder.UseHotBagResultWrapper();
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
