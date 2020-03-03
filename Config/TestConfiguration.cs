using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumBoilerplate.Config
{
	class TestConfiguration
	{
		protected IWebDriver Driver;

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
			Driver.Close();
			Driver.Quit();
		}
	}
}
