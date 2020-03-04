using OpenQA.Selenium;

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
			var searchResults = GoogleSearchResult.GetList(Driver, Driver);
			searchResults[0].Title.Click();
		}
	}
}
