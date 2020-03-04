using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace SeleniumBoilerplate.Selenium.PageUtils.Selenium.WebDriver
{
	public static class Driver
	{
		/// <summary>
		/// Adds additional info onto wait messages around the name of the element, the by selector and the timeout
		/// </summary>
		/// <param name="elementName">Title of the element</param>
		/// <param name="by">by selector</param>
		/// <param name="timeout">wait timeout</param>
		/// <returns></returns>
		private static string GetErrorMessageDetail(string elementName, By by, int timeout)
		{
			string errorDetail = "";

			if (elementName != "")
				errorDetail += $"Element title: '{elementName}', ";

			errorDetail += $"By Selector: '{by.ToString()}', ";
			errorDetail += $"Timeout: '{timeout}' seconds";

			return errorDetail;
		}

		private static WebDriverWait GetWebDriverWait(IWebDriver driver, int timeout)
		{
			return new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
		}

		/// <summary>
		/// Waits for an element to be invisible
		/// </summary>
		/// <param name="driver">web driver</param>
		/// <param name="elementLocator">The element By locator</param>
		/// <param name="timeout">Seconds to wait before timing out</param>
		/// <param name="elementName">element title to display in error message</param>
		public static void WaitForElementToBeInvisible(this IWebDriver driver, By elementLocator, int timeout = 30, string elementName = "")
		{
			var wait = GetWebDriverWait(driver, timeout);

			try
			{	
				wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(elementLocator));
			}
			catch(WebDriverTimeoutException)
			{
				Assert.Fail($"Waiting for element to be invisible timed out. - {GetErrorMessageDetail(elementName, elementLocator, timeout)}");
			}
		}

		/// <summary>
		/// Waits for an element to be visible
		/// </summary>
		/// <param name="driver">Web driver</param>
		/// <param name="elementLocator">The element By locator</param>
		/// <param name="timeout">Seconds to wait before timing out</param>
		/// <param name="elementName">Element title to display in error message</param>
		public static void WaitForElementToBeVisible(this IWebDriver driver, By elementLocator, int timeout = 30, string elementName = "")
		{
			var wait = GetWebDriverWait(driver, timeout);

			try
			{
				wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementLocator));
			}
			catch (WebDriverTimeoutException)
			{
				Assert.Fail($"Waiting for element to be visible timed out. - {GetErrorMessageDetail(elementName, elementLocator, timeout)}");
			}
		}

		/// <summary>
		/// Waits for element to be clickable.
		/// </summary>
		/// <param name="driver">Web driver</param>
		/// <param name="elementLocator">The element By locator</param>
		/// <param name="timeout">Seconds to wait before timing out</param>
		/// <param name="elementName">Element title to display in error message</param>
		public static void WaitForElementToBeClickable(this IWebDriver driver, By elementLocator, int timeout = 30, string elementName = "")
		{
			var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
			try
			{
				wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementLocator));
			}
			catch (WebDriverTimeoutException)
			{
				Assert.Fail($"Waiting for element to be clickable timed out. - {GetErrorMessageDetail(elementName, elementLocator, timeout)}");
			}
		}

		/// <summary>
		/// Waits for XML and JavaScript calls to complete.
		/// </summary>
		/// <param name="driver">The driver.</param>
		/// <param name="timeoutSecs">The timeout secs.</param>
		/// <param name="throwException">if set to <c>true</c> [throw exception].</param>
		/// <exception cref="Exception">WebDriver timed out waiting for AJAX call to complete</exception>
		public static void WaitForAjax(this IWebDriver driver, int timeoutSecs = 30, bool throwException = false)
		{
			try
			{
				for (var i = 0; i < timeoutSecs; i++)
				{
					var ajaxIsComplete = (bool)(driver as IJavaScriptExecutor).ExecuteScript("return jQuery.active == 0");
					if (ajaxIsComplete) return;
					Thread.Sleep(1000);
				}
				if (throwException)
				{
					throw new Exception("WebDriver timed out waiting for AJAX call to complete");
				}
			}
			catch (WebDriverException)
			{

			}
		}
	}
}
