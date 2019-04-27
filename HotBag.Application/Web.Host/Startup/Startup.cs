﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Core;
using HotBag.EntityFrameworkCore;
using HotBag.EntityFrameworkCore.Context;
using HotBag.ResultWrapper.Extensions;
using HotBag.ResultWrapper.Filters;
using HotBag.SB.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]
namespace Web.Host
{
    public class Startup
    {
        private readonly string _defaultCorsPolicyName = "DefaultPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //You can remove the APIController attribute to disable the automatic model 
            //validation. But, then you will lose the other benefits of this attribute like disabling 
            //conventional routing and allowing model binding without adding[FromBody] parameter attributes.

            string connectionString = Configuration["Configuration:EntityFramework:ConnectionString:Default"];
            services.AddDbContext<ApplicationDbContext>
                        (options => options.UseSqlServer(connectionString));

            //The better approach to disable the default behavior by setting 
            //SuppressModelStateInvalidFilter option to true.You can set this option to 
            //true in the ConfigureServices method.Like
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            }); 

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = $"{Configuration.GetSection("App:Name").Value} Api",
                    Description = $"{Configuration.GetSection("App:Description").Value}",
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
            });

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory(_defaultCorsPolicyName));
            });

            // Configure CORS for angular2 UI
            var cors = Configuration.GetSection("App:CorsOrigins").Value
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => Regex.Replace(o, @"/", ""))
                               .ToArray();

            services.AddCors(
                options => options.AddPolicy(
                    _defaultCorsPolicyName,
                    builder => builder
                        .WithOrigins(cors)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                )
            );

            services.AddMvc(
                options =>
                {
                    options.Filters.Add(typeof(ModelStateFeatureFilter));  //this will allow you to 
                                                                           //options.OutputFormatters.Add(new PascalCaseJsonProfileFormatter());
                })
                .AddApplicationPart(Assembly.Load(new AssemblyName("HotBag.Web.Core")))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
             
            services.AddSingleton(Configuration);
            var serviceProvider = services.BuildServiceProvider();
            services.RegisterHotBagCore(serviceProvider);
        }

        // Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
             
            app.UseAuthentication();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{Configuration.GetSection("App: Name").Value} Enterprise Application Framework");
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            //Use HotBag EfCore 
            //app.UseHotBagEfCore(env);

            //use HotBag Dapper
            //app.UseHotBagDapper(env);

            //use HotBag MongoDb
            app.UseHotBagMondoDb(env);

            //Use HotBag Hangfire
            //app.UseHotBagHangfire(env);

            // Add Log4Net
            var loggingOptions = this.Configuration.GetSection("Log4NetCore")
                                                   .Get<Log4NetProviderOptions>();
            loggerFactory.AddLog4Net(loggingOptions);

            app.UseWhen(context => context.Request.Path.StartsWithSegments("/api"), appBuilder =>
            {
                appBuilder.UseHotBagResultWrapper();
            }); 

            app.UseCors(_defaultCorsPolicyName);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
               // routes.UseHotBagODataRoute();
            });
        }
    }
}
