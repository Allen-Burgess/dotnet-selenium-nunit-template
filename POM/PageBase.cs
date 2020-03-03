using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumBoilerplate.POM
{
	abstract class PageBase
	{
		protected IWebDriver Driver;

		public PageBase(IWebDriver driver)
		{
			Driver = driver;
			PageFactory.InitElements(Driver, this);
		}
	}
}
