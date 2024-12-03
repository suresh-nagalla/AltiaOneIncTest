using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using Serilog;

namespace AutomationFramework.Core.Base
{
    /// <summary>
    /// Represents a base page class that all UI page classes can inherit.
    /// Provides common methods for interacting with web elements.
    /// </summary>
    public class BasePage
    {
        protected readonly IWebDriver Driver;

        /// <summary>
        /// Initializes a new instance of the BasePage class.
        /// </summary>
        /// <param name="driver">The WebDriver instance to be used for the page.</param>
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Logger.Initialize();
            Log.Information("BasePage initialized with WebDriver.");
        }

        /// <summary>
        /// Navigates to a specified URL.
        /// </summary>
        /// <param name="url">The URL to navigate to.</param>
        public void NavigateToPage(string url)
        {
            Driver.Navigate().GoToUrl(url);
            Log.Information("Navigated to URL: {Url}", url);
        }

        /// <summary>
        /// Refreshes the current page.
        /// </summary>
        public void RefreshPage()
        {
            Driver.Navigate().Refresh();
            Log.Information("Page refreshed.");
        }

        /// <summary>
        /// Locates a visible web element by its locator.
        /// </summary>
        /// <param name="locator">The locator to identify the web element.</param>
        /// <param name="timeoutInSeconds">The time in seconds to wait for the element to become visible.</param>
        /// <returns>The web element found.</returns>
        public IWebElement LocateWidget(By locator, int timeoutInSeconds = 15)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
            Log.Information("Located element by locator: {Locator}", locator);
            return element;
        }

        // Additional Methods with Better Logging and Documentation

        /// <summary>
        /// Clicks on a specified web element.
        /// </summary>
        public void ClickElement(By locator)
        {
            var element = LocateWidget(locator);
            element.Click();
            Log.Information("Clicked on element located by: {Locator}", locator);
        }

        /// <summary>
        /// Enters text into a specified web element.
        /// </summary>
        public void EnterText(By locator, string text)
        {
            var element = LocateWidget(locator);
            element.Clear();
            element.SendKeys(text);
            Log.Information("Entered text into element located by: {Locator}. Text: {Text}", locator, text);
        }

        /// <summary>
        /// Selects a value from a dropdown by visible text.
        /// </summary>
        public void SelectDropdownValue(By locator, string valueToSelect)
        {
            var dropdown = LocateWidget(locator);
            var selectElement = new SelectElement(dropdown);
            selectElement.SelectByText(valueToSelect);
            Log.Information("Selected value '{Value}' from dropdown located by: {Locator}", valueToSelect, locator);
        }

        /// <summary>
        /// Hovers over a specified web element.
        /// </summary>
        public void HoverElement(By locator)
        {
            var element = LocateWidget(locator);
            var actions = new Actions(Driver);
            actions.MoveToElement(element).Perform();
            Log.Information("Hovered over element located by: {Locator}", locator);
        }
    }
}