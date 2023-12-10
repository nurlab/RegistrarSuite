using NLog.Web;

namespace RegistrarSuite.Extensions
{
    public class LoggerInitialize
    {
        public static NLog.Logger logger;

        public static void InitializeNLog()
        {
            logger = NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();
            logger.Debug($"AppStart RunTime={ApplicationLogging.DotnetFramework}({ApplicationLogging.DotnetRuntime}) AppVersion={System.Reflection.Assembly.GetEntryAssembly()?.GetName()?.Version} OS={Environment.OSVersion}");

        }
    }
}
