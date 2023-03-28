using CustomLogger.Abstracts;
using CustomLogger.EnumConstants;
using Serilog;
using Serilog.Context;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.ObjectModel;
using System.Data;
using M = Microsoft.Extensions.Logging;

namespace CustomLogger.Sinks
{
    public class DbLogger : IWPOLogger
    {
        #region variable declaration
        private readonly Serilog.ILogger _logger;

        public string CategoryName { get; set; }

        #endregion

        #region constructor                
        /// <summary>
        /// Initializes a new instance of the <see cref="DbLogger"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public DbLogger(DbOptions options)
        {
            var columnOptions = new ColumnOptions();
            //removing Property column
            columnOptions.Store.Remove(StandardColumn.Properties);

            //adding CategoryName column
            columnOptions.AdditionalColumns = new Collection<SqlColumn>
            {
                new SqlColumn("CategoryName", SqlDbType.NVarChar, true, 150)
            };

            _logger = new Serilog.LoggerConfiguration()
                    .MinimumLevel.Information()
                    .MinimumLevel.Override(LogConstants.DefaultOverrideName, Serilog.Events.LogEventLevel.Information)
                    .Enrich.FromLogContext()
                    .WriteTo.MSSqlServer(
                    connectionString: options.ConnectionString,
                    sinkOptions: new MSSqlServerSinkOptions
                    {
                        TableName = options.TableName,
                        SchemaName = options.SchemaName,
                        AutoCreateSqlTable = true
                    },
                    columnOptions: columnOptions)
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
            _logger.Write((Serilog.Events.LogEventLevel)logLevel, exception, message);
        }
    }
}
