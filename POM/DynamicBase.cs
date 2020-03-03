using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumBoilerplate.POM
{
	/// <summary>
	/// Can be used for grouping elements from dynamic web content.
	/// </summary>
	abstract class DynamicBase
	{
		protected IWebDriver Driver;

		public ISearchContext Container { get; set; }

		public DynamicBase(ISearchContext searchContext, IWebDriver driver)
		{
			Driver = driver;
			Container = searchContext;
			PageFactory.InitElements(Container, this);
		}
	}
}
