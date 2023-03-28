using CustomLogger.EnumConstants;

namespace CustomLogger
{
    public class LoggerOptions
    {
        /// <summary>
        /// Gets or sets the type of the log.
        /// </summary>
        /// <value>
        /// The type of the log.
        /// </value>
        public string LogType { get; set; }

        /// <summary>
        /// Gets or sets the file logger.
        /// </summary>
        /// <value>
        /// The file logger.
        /// </value>
        public FileOptions FileLogger { get; set; }

        /// <summary>
        /// Gets or sets the database logger.
        /// </summary>
        /// <value>
        /// The database logger.
        /// </value>
        public DbOptions DbLogger { get; set; }

        /// <summary>
        /// Gets or sets the splunk logger.
        /// </summary>
        /// <value>
        /// The splunk logger.
        /// </value>
        public SplunkOptions SplunkLogger { get; set; }
    }
}
