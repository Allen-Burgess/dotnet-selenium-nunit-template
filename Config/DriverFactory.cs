using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;

namespace SeleniumBoilerplate.Config
{
	class DriverFactory
	{
		/// <summary>
		/// Returns a webdriver object on the specified browser
		/// </summary>
		/// <param name="browser">web driver browser to return</param>
		/// <returns>Web driver</returns>
		public static IWebDriver InitDriver(string browser)
		{
			IWebDriver driver = null;

			switch (browser.ToLower())
			{
				case "chrome":
					driver = new ChromeDriver();
					break;
				case "firefox":
					driver = new FirefoxDriver();
					break;
				case "ie11":
					driver = new InternetExplorerDriver();
					break;
				case "edge":
					driver = new EdgeDriver();
					break;
				default:
					driver = new ChromeDriver();
					break;
			}

			return driver;
		}
	}
}
