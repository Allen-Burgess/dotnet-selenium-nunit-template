using OpenQA.Selenium;
using SeleniumBoilerplate.Selenium.PageUtils.Selenium.WebDriver;
using SeleniumExtras.PageObjects;

namespace SeleniumBoilerplate.POM.SamplePages
{
	class GoogleHomePage : PageBase
	{
		public GoogleHomePage(IWebDriver driver) : base(driver) { }

		[FindsBy(How = How.XPath, Using = "//input[@title='Search']")]
		public IWebElement SearchInput { get; private set; }

		[FindsBy(How = How.XPath, Using = "//div[@class='FPdoLc tfB0Bf']//input[@value='Google Search']")]
		public IWebElement GoogleSearch { get; private set; }

		/// <summary>
		/// Clicks the search button
		/// </summary>
		public void ClickSearch()
		{
			Driver.WaitForElementToBeClickable(By.CssSelector("div.sbtc"));
			SearchInput.SendKeys(Keys.Escape);
			GoogleSearch.Click();
		}

		/// <summary>
		/// Enters text into the search bar
		/// </summary>
		/// <param name="searchTerm"></param>
		public void EnterSearch(string searchTerm)
		{
			Driver.WaitForElementToBeClickable(By.XPath("//input[@title='Search']"));
			SearchInput.SendKeys(searchTerm);
		}
	}
}
