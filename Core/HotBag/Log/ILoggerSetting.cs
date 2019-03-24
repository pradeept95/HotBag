using System.Threading.Tasks;

namespace Core.Log
{
    public interface ILoggerSetting
    {
        bool AllowLogging { get; set; }
    }
}