using Core.Log;

namespace HotBag.Dapper
{
    public class DefaultDbLoggerSetting : ILoggerSetting
    {
        public bool AllowLogging { get; set; } = true;
    }

}
