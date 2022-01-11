using System;

namespace ARM.Movies.Logging
{
    public interface ILoggerManager
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(string message, Exception exception = null);
    }
}