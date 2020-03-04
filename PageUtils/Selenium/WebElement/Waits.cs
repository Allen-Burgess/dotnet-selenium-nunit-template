using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace SeleniumBoilerplate.PageUtils.Selenium.WebElement
{
	static class Waits
	{
		/// <summary>
		/// Waits for the element's text to contain a specified value
		/// </summary>
		/// <param name="element">Element to wait for text to be present in</param>
		/// <param name="text">Text to wait for</param>
		/// <param name="driver">web driver</param>
		/// <param name="timeout">Seconds to wait before timing out</param>
		public static void WaitForElementToContainText(this IWebElement element, string text, IWebDriver driver, int timeout = 20)
		{
			var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
			Func<IWebDriver, bool> elementContainsText = (x) => element.Text.ToLower().Contains(text.ToLower());
		}
	}
}
