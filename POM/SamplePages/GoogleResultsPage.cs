using OpenQA.Selenium;
using SeleniumBoilerplate.Selenium.PageUtils.Selenium.WebDriver;

namespace SeleniumBoilerplate.POM.SamplePages
{
	class GoogleResultsPage : PageBase
	{
		public GoogleResultsPage(IWebDriver driver) : base(driver) { }

		/// <summary>
		/// Clicks the first google result
		/// </summary>
		public void ClickFirstResult()
		{
			Driver.WaitForElementToBeClickable(By.CssSelector("div.g"));
			var searchResults = GoogleSearchResult.GetList(Driver, Driver);
			searchResults[0].Title.Click();
		}
	}
}
