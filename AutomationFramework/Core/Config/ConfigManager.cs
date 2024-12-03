using Newtonsoft.Json;
using System.IO;

namespace AutomationFramework.Core.Config
{
    /// <summary>
    /// Manages configuration settings for the framework.
    /// </summary>
    public static class ConfigManager
    {
        /// <summary>
        /// Loads the configuration from the specified JSON file.
        /// </summary>
        public static dynamic LoadConfig()
        {
            string configPath = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Config.json");
            var config = JsonConvert.DeserializeObject(File.ReadAllText(configPath));
            Logger.Initialize();
            Log.Information("Configuration loaded from {ConfigPath}", configPath);
            return config;
        }
    }
}