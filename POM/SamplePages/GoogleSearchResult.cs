using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumBoilerplate.PageUtils.Selenium;
using System.Linq;

namespace SeleniumBoilerplate.POM.SamplePages
{
	class GoogleSearchResult : DynamicBase
	{
		[FindsBy(How = How.TagName, Using = "h3")]
		public IWebElement Title { get; private set; }

		[FindsBy(How = How.CssSelector, Using = "span.st")]
		public IWebElement Description { get; private set; }

		public GoogleSearchResult(IWebElement container, IWebDriver driver) : base(container, driver) { }

		/// <summary>
		/// Returns a list of all google search results on the page or within a container
		/// </summary>
		/// <param name="searchContext">What element/driver to use as the search context</param>
		/// <param name="driver">The web driver</param>
		public static GoogleSearchResult[] GetList(ISearchContext searchContext, IWebDriver driver)
		{
			return typeof(GoogleSearchResult).ReturnListOfObjects(searchContext, driver, By.CssSelector("div.g")).Cast<GoogleSearchResult>().ToArray();
		}
	}
}
