using HotBag.DI.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotBag.Services.Providers
{
    public interface ITestService
    {

    }

    public class TestService : ITestService, ITransientDependencies
    {

    }
}
