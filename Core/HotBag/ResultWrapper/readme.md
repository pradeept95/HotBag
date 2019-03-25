A REST API global exception handler and response wrapper for ASP.NET Core APIs.


# Api.Helper.ContentWrapper.Core

The Api.Helper.ContentWrapper.Core is a global exception handler and response wrapper for ASP.NET Core APIs. It uses a middleware to 
capture exceptions and to capture HTTP response to build a consistent response object for both successful and error requests.

## Prerequisite

Install Newtonsog.Json package

## Installing

Below are the steps to use the Api.Helper.ContentWrapper.Core middleware into your ASP.NET Core app:

1) Declare the following namespace within Startup.cs

using Api.Helper.ContentWrapper.Core.Extensions;

2) Register the middleware below within the Configure() method of Startup.cs

  app.UseAPIResponseWrapperMiddleware();

Note: Make sure to register it "before" the MVC middleware

3) Done. 

# NOTE
## Conditional middleware with UseWhen
The final case I want to look at is when you want most of your middleware to run for all requests but you have some conditional pieces - specific 
middleware that should only run for certain requests.

This is easily achieved with UseWhen which also uses a predicate to determine if the middleware should run:

    app.UseWhen(context => context.Request.Path.StartsWithSegments("/api"), appBuilder =>
	{
		appBuilder.UseAPIResponseWrapperMiddleware();
	});

This code uses different error handling middleware when the request is for the API (determined using the URL). 
The predicate approach provides a lot of flexibility and you can conditionally apply middleware based on cookies, headers,
current user and much more.

# Don't Forget to register your modelstate error filter helper

   services.AddMvc(
                  options =>
                  {
                      options.Filters.Add(typeof(ModelStateFeatureFilter));  //this will allow you to 
                      //options.OutputFormatters.Add(new PascalCaseJsonProfileFormatter());
                  })
             .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver())
             .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);



# Disable Automatic Model State Validation
You can remove the APIController attribute to disable the automatic model validation. But, then you will lose the other benefits of this attribute like disabling conventional routing and allowing model binding without adding [FromBody] parameter attributes.

The better approach to disable the default behavior by setting SuppressModelStateInvalidFilter option to true. You can set this option to true in the ConfigureServices method. Like,

public void ConfigureServices(IServiceCollection services)
{
    services.Configure<ApiBehaviorOptions>(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });
}

This will disable the automatic model state validation and now you can return the custom error from the controller action methods.