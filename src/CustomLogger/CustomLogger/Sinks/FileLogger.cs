using CustomLogger.Abstracts;
using CustomLogger.EnumConstants;
using Serilog;
using Serilog.Context;
using System;
using System.Text;
using System.Text.RegularExpressions;
using M = Microsoft.Extensions.Logging;

namespace CustomLogger.Sinks
{
    public class FileLogger : IWPOLogger
    {
        #region variable declaration
        private readonly Serilog.ILogger _logger;

        private readonly FileOptions _options;

        private string path, fileName, fullPath;

        public string CategoryName { get; set; }

        #endregion

        #region constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="FileLogger"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public FileLogger(FileOptions options)
        {
            _options = options;

            if (!string.IsNullOrEmpty(_options.LocationPath))
            {
                if (System.IO.Path.IsPathFullyQualified(_options.LocationPath))
                {
                    path = _options.LocationPath;
                }
                else
                {
                    path = LogConstants.DefaultFilePath;
                }
            }
            else
            {
                path = LogConstants.DefaultFilePath;
            }

            fileName = LogConstants.DefaultFileName;

            //for validating the file name using regular expression
            var regx = new Regex("[^a-zA-Z0-9_.]");

            if (!string.IsNullOrEmpty(_options.FileName))
            {
                if (!(regx.IsMatch(_options.FileName)))
                {
                    fileName = _options.FileName;
                }
            }

            fullPath = System.IO.Path.Combine(path, fileName);

            var ri = RollingInterval.Day;

            //checking rolling interval value
            if (!(string.IsNullOrEmpty(_options.RollingInterval)))
            {
                if (_options.RollingInterval.Equals(RollingInterval.Infinite.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    ri = RollingInterval.Infinite;
                }

                if (_options.RollingInterval.Equals(RollingInterval.Year.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    ri = RollingInterval.Year;
                }

                if (_options.RollingInterval.Equals(RollingInterval.Month.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    ri = RollingInterval.Month;
                }

                if (_options.RollingInterval.Equals(RollingInterval.Day.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    ri = RollingInterval.Day;
                }

                if (_options.RollingInterval.Equals(RollingInterval.Hour.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    ri = RollingInterval.Hour;
                }

                if (_options.RollingInterval.Equals(RollingInterval.Minute.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    ri = RollingInterval.Minute;
                }
            }

            _logger = new Serilog.LoggerConfiguration()
                    .MinimumLevel.Information()
                    .MinimumLevel.Override(LogConstants.DefaultOverrideName, Serilog.Events.LogEventLevel.Information)
                    .Enrich.FromLogContext()
                    .WriteTo.File(fullPath, rollingInterval: ri, rollOnFileSizeLimit: true,
                                outputTemplate: _options.Template, shared: true)
                    .CreateLogger();
        }

        #endregion

        /// <summary>
        /// Begins a logical operation scope.
        /// </summary>
        /// <typeparam name="TState">The type of the state to begin scope for.</typeparam>
        /// <param name="state">The identifier for the scope.</param>
        /// <returns>
        /// A disposable object that ends the logical operation scope on dispose.
        /// </returns>
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        /// <summary>
        /// Checks if the given <paramref name="logLevel" /> is enabled.
        /// </summary>
        /// <param name="logLevel">level to be checked.</param>
        /// <returns>
        ///   <see langword="true" /> if enabled; <see langword="false" /> otherwise.
        /// </returns>
        public bool IsEnabled(M.LogLevel logLevel)
        {
            return logLevel != M.LogLevel.None;
        }

        /// <summary>
        /// Writes a log entry.
        /// </summary>
        /// <typeparam name="TState">The type of the object to be written.</typeparam>
        /// <param name="logLevel">Entry will be written on this level.</param>
        /// <param name="eventId">Id of the event.</param>
        /// <param name="state">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a <see cref="T:System.String" /> message of the <paramref name="state" /> and <paramref name="exception" />.</param>
        public void Log<TState>(M.LogLevel logLevel, M.EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(formatter(state, exception));
            if (exception != null)
            {
                sb.Append(" Exception : ");
            }
            else
            {
                sb.Append(" ");
            }

            sb.Append(exception?.ToString().Replace(Environment.NewLine, " "));
            //WriteLog(logLevel, CategoryName, sb.ToString(), exception);

            WriteLog(logLevel, CategoryName, formatter(state, exception), exception);
        }

        /// <summary>
        /// Sets the category.
        /// </summary>
        /// <param name="categoryName">Name of the category.</param>
        public void SetCategory(string categoryName)
        {
            CategoryName = categoryName;
            LogContext.PushProperty("CategoryName", categoryName);
        }

        /// <summary>
        /// Writes the log.
        /// </summary>
        /// <param name="logLevel">The log level.</param>
        /// <param name="category">The category.</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void WriteLog(M.LogLevel logLevel, string category, string message, Exception exception)
        {
            LogContext.PushProperty("CategoryName", category);
            //_logger.Write((Serilog.Events.LogEventLevel)logLevel, message);

            _logger.Write((Serilog.Events.LogEventLevel)logLevel, exception, message);
        }
    }
}
