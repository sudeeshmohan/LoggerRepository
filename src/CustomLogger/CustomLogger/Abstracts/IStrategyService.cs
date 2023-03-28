using Microsoft.Extensions.Logging;

namespace CustomLogger.Abstracts
{
    public interface IStrategyService
    {
        /// <summary>
        /// Creates the logger.
        /// </summary>
        /// <param name="categoryName">Name of the category.</param>
        /// <returns></returns>
        public ILogger CreateLogger(string categoryName);

        /// <summary>
        /// Reads the logger.
        /// </summary>
        /// <returns></returns>
        public void ReadLogger();

        /// <summary>
        /// Writes the log.
        /// </summary>
        /// <param name="lv">The lv.</param>
        /// <param name="message">The message.</param>
        /// <param name="categoryName">Name of the category.</param>
        /// <returns></returns>
        public void WriteLog(LogLevel lv, string message, string categoryName);
    }
}
