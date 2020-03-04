using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Drawing;
using System.Threading;

namespace SeleniumBoilerplate.PageUtils.Selenium.WebDriver
{
	static class Navigation
	{
		/// <summary>
		/// Switches the current frame to a new window/tab
		/// </summary>
		/// <param name="driver">web driver</param>
		/// <param name="windowIndex">Specifies which window index. By default switches to the second window.</param>
		/// <returns></returns>
		public static IWebDriver SwitchToNewWindow(this IWebDriver driver, int windowIndex = 1)
		{
			return driver.SwitchTo().Window(driver.WindowHandles[windowIndex]);
		}

		/// <summary>
		/// Waits the till element stops scrolling.
		/// </summary>
		/// <param name="driver">The driver.</param>
		/// <param name="by">The by.</param>
		public static void WaitTillElementStopsScrolling(this IWebDriver driver, By by)
		{
			int scrollCount = 0; int countAbs = 0;
			Point refLocBefore = Point.Empty;
			Point refLocAfter = driver.ScrollIntoView(by);

			while (scrollCount < 9)
			{
				refLocAfter = driver.ScrollIntoView(by);
				if (refLocBefore == refLocAfter) scrollCount++;
				else scrollCount = 0;
				countAbs++;
				Console.WriteLine("CountAbs: " + countAbs + ", ScrollCount: " + scrollCount + ", refLocBefore: " + refLocBefore + ", refLocAfter: " + refLocAfter);
				refLocBefore = refLocAfter;
			}
		}

		/// <summary>
		/// Scrolls the an element into view
		/// </summary>
		/// <param name="webDriver">The web driver</param>
		/// <param name="by">The by selector</param>
		/// <returns>The hack</returns>
		public static Point ScrollIntoView(this IWebDriver webDriver, By by)
		{
			RemoteWebElement element = (RemoteWebElement)webDriver.FindElement(by);
			Point hack = element.LocationOnScreenOnceScrolledIntoView;

			return hack;
		}

		/// <summary>
		/// Scrolls to the bottom of a page
		/// </summary>
		/// <param name="driver">web driver</param>
		public static void ScrollToBottom(this IWebDriver driver)
		{
			((IJavaScriptExecutor)driver).ExecuteScript(
				"window.scrollTo(0, document.body.scrollHeight)");
			Thread.Sleep(1000); // allow page to re-adjust to scroll
		}

		/// <summary>
		/// Scrolls to the top of a page
		/// </summary>
		/// <param name="driver">web driver</param>
		public static void ScrollToTop(this IWebDriver driver)
		{
			((IJavaScriptExecutor)driver).ExecuteScript(
				"window.scrollTo(document.body.scrollHeight, 0)");
			Thread.Sleep(1000); // allow page to re-adjust to scroll
		}
	}
}
