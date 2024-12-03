using OpenQA.Selenium;
using System;
using System.IO;
using Serilog;

namespace AutomationFramework.Core.Utilities
{
    /// <summary>
    /// Provides methods to capture screenshots during tests.
    /// </summary>
    public static class ScreenshotHelper
    {
        /// <summary>
        /// Captures a screenshot and saves it to the Screenshots directory.
        /// </summary>
        public static string CaptureScreenshot(IWebDriver driver, string scenarioName)
        {
            try
            {
                string screenshotsFolder = Path.Combine(Directory.GetCurrentDirectory(), \"Screenshots\");
                if (!Directory.Exists(screenshotsFolder))
                {
                    Directory.CreateDirectory(screenshotsFolder);
                }

                string timestamp = DateTime.Now.ToString(\"yyyyMMdd_HHmmss\");
                string fileName = $"{scenarioName}_{timestamp}.png\";
                string filePath = Path.Combine(screenshotsFolder, fileName);

                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
                Log.Information(\"Screenshot saved at: {FilePath}\