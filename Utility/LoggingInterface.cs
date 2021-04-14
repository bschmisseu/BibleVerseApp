using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleVerseApp.Utility
{
    interface LoggingInterface
    {
        void Debug(string message);
        void Error(string message);
        void Info(string message);
        void Warning(string message);
    }
}
