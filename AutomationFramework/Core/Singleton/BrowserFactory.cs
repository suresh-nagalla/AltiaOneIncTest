using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using Serilog;

namespace AutomationFramework.Core.Singleton
{
    /// <summary>
    /// Provides a Singleton implementation for managing WebDriver instances.
    /// </summary>
    public sealed class BrowserFactory
    {
        private static IWebDriver _driver;
        private static readonly object Padlock = new object();

        /// <summary>
        /// Gets the WebDriver instance based on the specified browser type.
        /// </summary>
        public static IWebDriver GetDriver(string browser = "Chrome")
        {
            if (_driver == null)
            {
                lock (Padlock)
                {
                    if (_driver == null)
                    {
                        Logger.Initialize();
                        switch (browser.ToLower())
                        {
                            case "chrome":
                                _driver = new ChromeDriver();
                                break;
                            case "firefox":
                                _driver = new FirefoxDriver();
                                break;
                            default:
                                throw new ArgumentException("Unsupported browser: " + browser);
                        }
                        Log.Information("WebDriver initialized for browser: {Browser}", browser);
                    }
                }
            }
            return _driver;
        }

        /// <summary>
        /// Closes and quits the WebDriver instance.
        /// </summary>
        public static void CloseDriver()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver = null;
                Log.Information("WebDriver instance closed and disposed.");
            }
        }
    }
}