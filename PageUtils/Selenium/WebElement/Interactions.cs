using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace SeleniumBoilerplate.PageUtils.Selenium.WebElement
{
	static class Interactions
	{
		/// <summary>
		/// Clears a web element then enters text
		/// </summary>
		/// <param name="element">Element to write send keys to</param>
		/// <param name="text">Text to enter</param>
		public static void EnterText(this IWebElement element, string text)
		{
			element.Clear();
			element.SendKeys(text);
		}

		/// <summary>
		/// Hovers the mouse over an element
		/// </summary>
		/// <param name="element">element to hover over</param>
		/// <param name="driver">the web driver</param>
		/// <param name="sleep">miliseconds to wait</param>
		public static void HoverOver(this IWebElement element, IWebDriver driver, int milliseconds = 0)
		{
			Actions action = new Actions(driver);
			action.MoveToElement(element).Perform();
			Thread.Sleep(milliseconds);
		}

	}
}
