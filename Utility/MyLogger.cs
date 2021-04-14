using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleVerseApp.Utility
{
    public class MyLogger : LoggingInterface
    {
        private static MyLogger Instance;
        private static Logger Logger;

        public static MyLogger GetInstance()
        {
            if (Instance == null)
            {
                Instance = new MyLogger();
            }
            return Instance;
        }

        private Logger GetLogger()
        {
            if (MyLogger.Logger == null)
            {
                MyLogger.Logger = LogManager.GetLogger("BibleLoggerRule");
            }
            return MyLogger.Logger;
        }

        public void Debug(string message)
        {
            GetLogger().Debug(message);
        }

        public void Error(string message)
        {
            GetLogger().Error(message);
        }

        public void Info(string message)
        {
            GetLogger().Info(message);
        }

        public void Warning(string message)
        {
            GetLogger().Warn(message);
        }
    }
}