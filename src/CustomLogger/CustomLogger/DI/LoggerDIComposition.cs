using Autofac;
using CustomLogger.Abstracts;
using CustomLogger.EnumConstants;
using CustomLogger.Sinks;
using System;

namespace CustomLogger.DI
{
    /// <summary>
    /// Logger Dependency Injection Class
    /// </summary>
    public static class LoggerDIComposition
    {
        /// <summary>
        /// Adds the logger di container.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        public static IContainer AddLoggerDIContainer(LoggerOptions options)
        {
            var builder = new ContainerBuilder();

            ////For File Logger registration
            if (options.LogType != null && options.LogType.Equals(LogTypes.File.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                builder.RegisterInstance<FileOptions>(options.FileLogger);
                builder.RegisterType<FileLogger>().As<IWPOLogger>();
            }

            ////For Database Logger registration
            if (options.LogType != null && options.LogType.Equals(LogTypes.Database.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                builder.RegisterInstance<DbOptions>(options.DbLogger);
                builder.RegisterType<DbLogger>().As<IWPOLogger>();
            }

            ////For Azure Logger registration
            if (options.LogType != null && options.LogType.Equals(LogTypes.Azure.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {

            }

            ////For Splunk Logger registration
            if (options.LogType != null && options.LogType.Equals(LogTypes.Splunk.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                builder.RegisterInstance<SplunkOptions>(options.SplunkLogger);
                builder.RegisterType<SplunkLogger>().As<IWPOLogger>();
            }

            return builder.Build();
        }
    }
    /// 
    /// services.Configure<LoggerOptions>(Configuration.GetSection(LogConstants.ConfigName));
    //services.AddSingleton<IStrategyService, StrategyService>();
    //        services.AddTransient<ExceptionMiddleware>();
    //        services.AddTransient<LoggerMiddleware>();
    //        services.AddSingleton<ILoggerProvider, LoggerProvider>();

}
