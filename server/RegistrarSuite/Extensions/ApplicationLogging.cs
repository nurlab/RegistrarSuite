using System.Reflection;
using System.Runtime.Versioning;
#nullable disable

namespace RegistrarSuite.Extensions
{
    internal static class ApplicationLogging
    {
        private static ILoggerFactory _Factory = null;
        private static DateTime _startTime = DateTime.Now;


        static public IApplicationBuilder UseGenericApplicationLogging(this IApplicationBuilder builder)
        {
            LoggerFactory = builder.ApplicationServices.GetRequiredService<ILoggerFactory>();
            return builder;
        }

        public static DateTime StartTime
        {
            get
            {
                return _startTime;

            }
        }

        public static string DotnetRuntime
        {
            get
            {
                string runtime = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription;
                return runtime;
            }
        }

        public static string DotnetFramework
        {
            get
            {
                var framework = Assembly
                        .GetEntryAssembly()?
                        .GetCustomAttribute<TargetFrameworkAttribute>()?
                        .FrameworkName;

                return framework;
            }
        }

        public static ILoggerFactory LoggerFactory
        {
            get
            {
                if (_Factory == null)
                {
                    //_Factory = new LoggerFactory();
                    _Factory = Microsoft.Extensions.Logging.LoggerFactory.Create(loggingBuilder => loggingBuilder
                        .ClearProviders()
                        .SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace)
                        );
                }
                return _Factory;
            }
            set { _Factory = value; }
        }
        public static ILogger<T> CreateLogger<T>() => LoggerFactory.CreateLogger<T>();

        public static ILogger CreateLogger(string sName) => LoggerFactory.CreateLogger(sName);

    }
}