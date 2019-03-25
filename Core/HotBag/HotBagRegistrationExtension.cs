﻿using HotBag.DI;
using HotBag.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Core
{
    public static class ApplicationCore
    {
        public static IServiceCollection RegisterHotBagCore(this IServiceCollection services,
            IServiceProvider serviceProvider)
        {
            var configuration = serviceProvider.GetService<IConfiguration>(); 
            services.AddHttpContextAccessor();
            //registering service for later use
            services.AddSingleton(services);
              
            //TODO:: register all dependencies
            new Bootstrapper(services, serviceProvider);

            //register module
            new ModuleBootstrapper(services, serviceProvider); 
            var policy = new Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy();

            policy.Headers.Add("*");
            policy.Methods.Add("*");
            policy.Origins.Add("*");
            policy.SupportsCredentials = true;

            services.AddCors(x => x.AddPolicy("corsGlobalPolicy", policy));
            
            return services; 
        }


        //public static void UseKachuwaInsight(this ILoggerFactory loggerFactory, IOptions<ApplicationInsightsSettings> applicationInsightsSettings, IServiceProvider serviceProvider)
        //{

        //    loggerFactory.AddApplicationInsights(applicationInsightsSettings.Value, serviceProvider);


        //}
        //public static IApplicationBuilder UseKachuwaApps(this IApplicationBuilder app,
        //    IServiceProvider serviceProvider, IHostingEnvironment hostingEnvironment)
        //{

        //    new KachuwaAppBuilder(app, serviceProvider, hostingEnvironment);
        //    return app;

        //}

        //public static IApplicationBuilder UseKachuwaCore(this IApplicationBuilder app, IServiceProvider serviceProvider)
        //{

        //    //app.UseTenant();
        //    //TODO cache middle ware causing problem
        //    //app.UseMiddleware<CacheMiddleware>();
        //    //app.UseSecurityHeadersMiddleware(config =>
        //    //{
        //    //    config.AddContentTypeOptionsNoSniff();
        //    //   // config.AddContentSecurity("YXjwbSX9P94nhr8M8UdVfon4v1KGwTJDk/dRqx72CwM=");
        //    //    config.AddFrameOptionsSameOrigin("/");
        //    //    config.AddXssProtectionBlock();
        //    //    // config.AddStrictTransportSecurityMaxAge();
        //    //    config.AddContentSecurity(builder =>
        //    //    {
        //    //        builder.AddScriptPolicy(script =>
        //    //        {
        //    //            script.AllowSelf().AllowInline().AddNonce().AllowfromCdn(new[] {""});


        //    //        });
        //    //        builder.AddStylePolicy(style =>
        //    //        {
        //    //            style.AllowSelf().AllowInline().AddNonce().AllowfromCdn(new[] { "https://fonts.googleapis.com" });
        //    //        });
        //    //    });
        //    //    config.RemoveServerHeader();

        //    //});
        //    app.UseKSockets(serviceProvider);
        //    app.UseKachuwaLocalization();
        //    // yes, demo code
        //    // app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        //    app.UseCors("corsGlobalPolicy");

        //    return app;

        //}

        //public static IServiceCollection ConfigureKachuwa(this IServiceCollection service, Action<KachuwaSetUp> configuration)
        //{
        //    var setup = new KachuwaSetUp();
        //    configuration(setup);

        //    return service;
        //}
    }
}
