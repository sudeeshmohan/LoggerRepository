using Microsoft.Extensions.Logging;
using System;

namespace CustomLogger.Abstracts
{
    public interface IWPOLogger : ILogger
    {
        /// <summary>
        /// Sets the category.
        /// </summary>
        /// <param name="category">The category.</param>
        void SetCategory(string category);

        /// <summary>
        /// Writes the log.
        /// </summary>
        /// <param name="logLevel">The log level.</param>
        /// <param name="category">The category.</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        void WriteLog(LogLevel logLevel, string category, string message, Exception exception);
    }
}
