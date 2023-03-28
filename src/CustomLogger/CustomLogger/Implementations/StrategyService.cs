using Autofac;
using CustomLogger.Abstracts;
using CustomLogger.DI;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Linq;

namespace CustomLogger.Implementations
{
    public class StrategyService : IStrategyService
    {
        #region variable declaration
        private LoggerOptions _options;

        private static IContainer Container { get; set; }

        #endregion

        #region constructor                
        /// <summary>
        /// Initializes a new instance of the <see cref="StrategyService"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="fileLogger">The file logger.</param>
        /// <param name="dbLogger">The database logger.</param>
        public StrategyService(IOptions<LoggerOptions> options)
        {
            Container = LoggerDIComposition.AddLoggerDIContainer(options?.Value);

        }

        #endregion

        /// <summary>
        /// Creates the logger.
        /// </summary>
        /// <param name="categoryName">Name of the category.</param>
        /// <returns></returns>
        public ILogger CreateLogger(string categoryName)
        {
            using (var scope = Container?.BeginLifetimeScope())
            {
                var activeLogger = scope.Resolve<IWPOLogger>();
                activeLogger.SetCategory(categoryName);
                return activeLogger;
            }
        }

        /// <summary>
        /// Reads the logger.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public void ReadLogger()
        {
            //csv or txt
            //configure
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes the log.
        /// </summary>
        /// <param name="logLevel">The log level.</param>
        /// <param name="message">The message.</param>
        /// <param name="categoryName">Name of the category.</param>
        public void WriteLog(LogLevel logLevel, string message, string categoryName = "")
        {
            using (var scope = Container?.BeginLifetimeScope())
            {
                var activeLogger = scope.Resolve<IWPOLogger>();
                activeLogger.SetCategory(categoryName);
                activeLogger.WriteLog(logLevel, categoryName, message, null);
            }
        }


        public void Read()
        {
            string currentDirectory = @"C:\Users\shilpa.sn\source\repos\New\WpoLoggerPOC\src\Logs\";
            string pattern = "*.txt";
            var directory = new System.IO.DirectoryInfo(currentDirectory);
            DateTime fromdate = DateTime.Now.AddMonths(-3);
            DateTime todate = DateTime.Now.AddDays(-1);
            var files = directory.GetFiles(pattern)//directory.GetFiles()
                        .Where(file => file.LastWriteTime >= fromdate && file.LastWriteTime <= todate);

            var csvPath = @"C:\Users\shilpa.sn\source\repos\New\WpoLoggerPOC\src\Logs\export.csv";

            foreach (System.IO.FileInfo filename in files)
            {
                var tabPath = filename.ToString();

                if (System.IO.File.Exists(tabPath))
                {
                    // Read file using StreamReader. Reads file line by line  
                    using (var sr = new System.IO.StreamReader(new FileStream(tabPath, FileMode.Open, FileAccess.Read, FileShare.Read)))
                    //using (var sr = new System.IO.StreamReader(tabPath))
                    {
                        using (var sw = new System.IO.StreamWriter(csvPath, false))
                        {
                            while (!sr.EndOfStream)
                            {
                                var line = sr.ReadLine().Split(';').ToArray();
                                //var line = sr.ReadLine().Split(';').Select(field => field.EscapeCsvField(',', '"')).ToArray();
                                var csv = String.Join(",", line);
                                //csv = csv + Environment.NewLine;
                                sw.WriteLine(csv);
                            }

                        }
                    }
                }

            }
        }
    }
}
