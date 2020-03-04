using OpenQA.Selenium;

namespace SeleniumBoilerplate.PageUtils.Selenium.WebDriver
{
	static class Interactions
	{
		/// <summary>
		/// Finds the element if exists in the DOM.
		/// </summary>
		/// <param name="driver">Web driver</param>
		/// <param name="by">The by selector</param>
		/// <returns>Boolean on whether element is displayed</returns>
		public static bool FindElementIfExists(this IWebDriver driver, By by)
		{
			var elements = driver.FindElements(by);

			if (elements.Count == 0) return false;
			else return true;
		}
	}
}
