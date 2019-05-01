using HotBag.DI.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotBag.Configuration.Global.Application
{
    public class ApplicationSetting : IApplicationSetting, ISingletonDependencies
    {

        public string ApplicationName { get; private set; }
        public string ApplicationVersion { get; private set; }
         
        public ApplicationSetting()
        {
            this.ApplicationName = "HotBag Enterprise Boilerplate Framework";
            this.ApplicationVersion = "1.0.0.0";
        }

        public void SetApplicationSetting(string name)
        {
            this.ApplicationName = name;
        }
    }

    public interface IApplicationSetting
    {
        string ApplicationName { get; }
        string ApplicationVersion { get; }
        void SetApplicationSetting(string name);
    }
}
