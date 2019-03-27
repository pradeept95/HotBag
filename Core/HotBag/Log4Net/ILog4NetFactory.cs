using HotBag.DI.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotBag.Log4Net
{
    public interface ILog4NetFactory
    {
    }
    public class Log4NetFactory : ILog4NetFactory, ITransientDependencies
    {
    }
}
