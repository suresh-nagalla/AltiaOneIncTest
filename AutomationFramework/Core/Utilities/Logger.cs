using Serilog;

namespace AutomationFramework.Core.Utilities
{
    /// <summary>
    /// Provides logging functionality using Serilog.
    /// </summary>
    public static class Logger
    {
        private static bool _isInitialized = false;

        /// <summary>
        /// Initializes the logger configuration.
        /// </summary>
        public static void Initialize()
        {
            if (!_isInitialized)
            {
                Log.Logger = new LoggerConfiguration()
                    .WriteTo.Console()
                    .WriteTo.File("logs\log-.txt", rollingInterval: RollingInterval.Day)
                    .CreateLogger();
                _isInitialized = true;
                Log.Information("Logger initialized.");
            }
        }
    }
}