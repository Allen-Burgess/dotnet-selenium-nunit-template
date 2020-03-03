using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using SeleniumBoilerplate.Data;
using System;
using System.IO;

namespace SeleniumBoilerplate.Config
{
	class TestConfiguration
	{
		protected IWebDriver Driver;

		/// <summary>
		/// Takes a screenshot if a test fails and attaches it to the test output
		/// </summary>
		private void TakeScreenshotOnFailure()
		{
			if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
			{
				// Creates directory if it doesn't exist and creates a screenshot path
				var screenshotDir =
					Directory.CreateDirectory(Path.Combine(TestContext.CurrentContext.WorkDirectory, $"Logs\\{TestContext.CurrentContext.Test.Name}\\Screenshots"));
				string screenshotFile = Path.Combine(screenshotDir.FullName, $"Failure.jpg");

				// Takes a screenshot and adds the jpg as a test attachment
				try
				{
					var screenshot = Driver.TakeScreenshot();
					screenshot.SaveAsFile(screenshotFile, ScreenshotImageFormat.Jpeg);
					TestContext.AddTestAttachment(screenshotFile, "Failure image");
				}
				catch
				{
					Console.WriteLine("Failed to take screenshot");
				}
			}
		}

		/// <summary>
		/// Inits the driver and navigates to the desired test URL
		/// </summary>
		/// <param name="url">Url to navigate to - if left at default will use the url stored in the parameters</param>
		public void TestCaseSetUp(string url = null)
		{
			Driver = DriverFactory.InitDriver(TestContext.Parameters["BROWSER"]);

			if (url == null)
				Driver.Url = TestContext.Parameters["URL"];
			else
				Driver.Url = url;
		}

		/// <summary>
		/// Closes the web driver process and takes a screenshot on failure
		/// </summary>
		public void TestCaseTearDown()
		{
			// Try catch as it may be not all tests use test data
			try
			{
				var testData = TestContext.CurrentContext.Test.Arguments[0] as TestDataSet;
				testData.WriteToConsole();
			}
			catch { }

			TakeScreenshotOnFailure();
			Driver.Close();
			Driver.Quit();
		}

		
	}
}
