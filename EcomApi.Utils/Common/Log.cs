using NLog;

namespace EcomApi.Utils.Common
{
    public enum LoggingType
    {
        Debug,
        Info,
        Error,
        Fatal,
        Trace,
        Warn
    };

    public static class Log
    {
        private static Guid LogGuid { get; }
        private static Logger Logger { get; }

        static Log()
        {
            LogGuid = Guid.NewGuid();
            Logger = LogManager.GetCurrentClassLogger();
        }

        public static void FileLogger(string logString, LoggingType logType)
        {
            switch (logType)
            {
                case LoggingType.Debug: Logger.Debug(logString); break;
                case LoggingType.Info: Logger.Info(logString); break;
                case LoggingType.Error: Logger.Error(logString); break;
                case LoggingType.Fatal: Logger.Fatal(logString); break;
                case LoggingType.Trace: Logger.Trace(logString); break;
                case LoggingType.Warn: Logger.Warn(logString); break;
            }
        }
        public static void Info(string logString)
        {
            FileLogger(logString, LoggingType.Info);
        }
        public static void Error(string logString)
        {
            FileLogger(logString, LoggingType.Error);
        }
        public static void Error(object value)
        {
            try
            {
                var logString = value.ToString();
                Error(logString);
            }
            catch {/*EXCEPTION IGNORED*/}
        }
        internal static void Trace(string logString) { FileLogger(logString, LoggingType.Trace); }
        public static void FileLogger(Exception logObj, LoggingType logType)
        {
            FileLogger(logObj.ToString(), logType);
        }
    }
}
