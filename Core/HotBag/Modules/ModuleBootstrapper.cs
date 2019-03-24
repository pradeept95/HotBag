using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;

namespace HotBag.Modules
{
    public class ModuleBootstrapper : IModuleBootstrapper
    {
        private readonly IServiceCollection _serviceCollection;
        private readonly IConfiguration _configuration;
        public ModuleBootstrapper(IServiceCollection serviceCollection, IServiceProvider serviceProvider)
        {
            _serviceCollection = serviceCollection;
            _configuration = serviceProvider.GetService<IConfiguration>();
            Init();
        }

        public void Init()
        {
            Build();
        }

        public bool Build()
        {
            FindThenBuild();
            return true;
        }

        private void FindThenBuild()
        {
            var moduleInstances = new List<IApplicationModule>(); 

            var platform = Environment.OSVersion.Platform.ToString();
            var runtimeAssemblyNames = DependencyContext.Default.GetRuntimeAssemblyNames(platform);

            var instances = runtimeAssemblyNames
                .Select(Assembly.Load)
                .SelectMany(a => a.ExportedTypes)
                .Where(t => TypeExtensions.GetInterfaces(t).Contains(typeof(IApplicationModule)) && t.GetConstructor(Type.EmptyTypes) != null)
                .Select(y => (IApplicationModule)Activator.CreateInstance(y));
                moduleInstances.AddRange(instances);

            
            foreach (var instance in moduleInstances)
            {   //TODO::check module is installed or not
                instance.PreInitialize(_serviceCollection, _configuration);
            } 

            foreach (var instance in moduleInstances)
            {
                instance.Initialize(_serviceCollection, _configuration);
            }

            foreach (var instance in moduleInstances)
            {
                instance.PostInitialize(_serviceCollection, _configuration);
            } 
        }

    }

}
