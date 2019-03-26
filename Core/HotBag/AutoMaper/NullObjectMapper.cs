using HotBag.DI.Base;
using HotBag.ResultWrapper.WrapperModel;

namespace HotBag.AutoMaper
{
    public sealed class NullObjectMapper// : IObjectMapper 
    {
        /// <summary>
        /// Singleton instance.
        /// </summary>
        public static NullObjectMapper Instance { get; } = new NullObjectMapper();

        public TDestination Map<TDestination>(object source)
        {
            throw new ApiException("HotBag.ObjectMapping.IObjectMapper should be implemented in order to map objects.");
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            throw new ApiException("HotBag.ObjectMapping.IObjectMapper should be implemented in order to map objects.");

        }
    }
}
