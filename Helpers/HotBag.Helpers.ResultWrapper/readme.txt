A REST API global exception handler and response wrapper for ASP.NET Core APIs.


# Api.Helper.ContentWrapper.Core

The VMD.RESTApiResponseWrapper.Core is a global exception handler and response wrapper for ASP.NET Core APIs. It uses a middleware to 
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