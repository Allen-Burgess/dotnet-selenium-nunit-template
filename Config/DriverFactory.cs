using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using System;

namespace SeleniumBoilerplate.Config
{
	static class DriverFactory
	{
		private static DriverOptions _options;
		private static bool _headless;

		/// <summary>
		/// Sets the _options to chrome options
		/// </summary>
		private static void SetChromeOptions()
		{
			ChromeOptions options = new ChromeOptions();

			if (_headless) options.AddArguments("--headless", "--disable-gpu");

			options.AddArguments(
				"--disable-extensions", 
				"--start-maximized",
				"--disable-notifications",
				"--disable-popup-blocking",
				"--disable-infobars", 
				"--no-sandbox");
			_options = options;
		}

		/// <summary>
		/// Sets the _options to firefox options
		/// </summary>
		private static void SetFirefoxOptions()
		{
			FirefoxOptions options = new FirefoxOptions();
			if (_headless) options.AddArguments("--headless", "--disable-gpu");
			options.AddArguments(
				"--start-maximized");
			_options = options;
		}

		/// <summary>
		/// Sets the _options to IE 11 options
		/// </summary>
		private static void SetInternetExplorerOptions()
		{
			InternetExplorerOptions options = new InternetExplorerOptions();
			options.AddAdditionalCapability("IgnoreZoomSetting", true);
			options.RequireWindowFocus = true;
			_options = options;
		}

		/// <summary>
		/// Sets the _options to microsoft edge options
		/// </summary>
		private static void SetEdgeOptions()
		{
			EdgeOptions options = new EdgeOptions();
			options.UseInPrivateBrowsing = true;
			_options = options;
		}

		/// <summary>
		/// Returns a webdriver object on the specified browser
		/// </summary>
		/// <param name="browser">web driver browser to return</param>
		/// <returns>Web driver</returns>
		public static IWebDriver InitDriver(string browser, bool headless)
		{
			IWebDriver driver = null;
			// IE and Edge do not support headless
			_headless = headless;

			switch (browser.ToLower())
			{
				case "chrome":
					SetChromeOptions();
					driver = new ChromeDriver(_options as ChromeOptions);
					break;
				case "firefox":
					SetFirefoxOptions();
					driver = new FirefoxDriver(_options as FirefoxOptions);
					break;
				case "ie11":
					SetInternetExplorerOptions();
					driver = new InternetExplorerDriver(_options as InternetExplorerOptions);
					break;
				case "edge":
					SetEdgeOptions();
					driver = new EdgeDriver(_options as EdgeOptions);
					break;
				default:
					driver = new ChromeDriver();
					break;
			}

			return driver;
		}

		/// <summary>
		/// Sets the default driver timouts
		/// </summary>
		/// <param name="driver">web driver</param>
		/// <param name="pageload">seconds to wait for pageload</param>
		public static void ManageTimeouts(this IWebDriver driver, int pageload = 60)
		{
			driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(pageload);
			//driver.Manage().Timeouts().ImplicitWait
			//driver.Manage().Timeouts().AsynchronousJavaScript
		}
	}
}
