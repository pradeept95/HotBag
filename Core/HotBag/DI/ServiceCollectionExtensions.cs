using HotBag.DI.Base;
using HotBag.Modules;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Linq;
using System.Reflection;

namespace HotBag.DI
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection Remove<T>(this IServiceCollection services)
        {
            var serviceDescriptor = services.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(T));
            if (serviceDescriptor != null)
                services.Remove(serviceDescriptor);

            return services;
        }

        public static IServiceCollection RemoveThenAdd<T>(this IServiceCollection services, object service) where T : class
        {
            var serviceDescriptor = services.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(T));
            if (serviceDescriptor != null)
                services.Remove(serviceDescriptor);
            services.TryAddSingleton((T)service);
            services.BuildServiceProvider();

            return services;
        }

        public static IServiceCollection Replace<TService, TImplementation>(
            this IServiceCollection services,
            ServiceLifetime lifetime)
            where TService : class
            where TImplementation : class, TService
        {
            var descriptorToRemove = services.FirstOrDefault(d => d.ServiceType == typeof(TService));

            services.Remove(descriptorToRemove);

            var descriptorToAdd = new ServiceDescriptor(typeof(TService), typeof(TImplementation), lifetime);

            services.Add(descriptorToAdd);

            return services;
        }

        public static IServiceCollection Replace<T>(
            this IServiceCollection services, object service)
        {
            var descriptorToRemove = services.FirstOrDefault(d => d.ServiceType == typeof(T));

            services.Remove(descriptorToRemove);

            var descriptorToAdd = new ServiceDescriptor(typeof(T), service);

            services.Add(descriptorToAdd);

            return services;
        }
    }

    public static class RegisterDependency
    {
        public static void RegisterAll(IServiceCollection serviceCollection)
        {
            var platform = Environment.OSVersion.Platform.ToString();
            var runtimeAssemblyNames = DependencyContext.Default.GetRuntimeAssemblyNames(platform);
            var allAssembly = runtimeAssemblyNames
                .Select(Assembly.Load)
                .Where(x => x.FullName.Contains("HotBag"));

            serviceCollection.Scan(scan => scan
             .FromAssemblies(allAssembly)
             .AddClasses(classes => classes.AssignableTo<ITransientDependencies>())
                 .AsImplementedInterfaces()
                 .WithTransientLifetime()

             .AddClasses(classes => classes.AssignableTo<IScopedDependencies>())
                 .AsImplementedInterfaces()
                 .WithScopedLifetime()

              .AddClasses(classes => classes.AssignableTo<ISingletonDependencies>())
                         .AsImplementedInterfaces()
                         .WithSingletonLifetime());
        }
    }
}
