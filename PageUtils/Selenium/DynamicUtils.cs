using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumBoilerplate.PageUtils.Selenium
{
	public static class DynamicUtils
	{
		/// <summary>
		/// Returns a list of objects within the container of the type passed into the method
		/// </summary>
		/// <param name="type">class type</param>
		/// <param name="container">Element that contains the objects</param>
		/// <param name="driver"></param>
		/// <param name="objContainer">Selector for the objects themselves</param>
		/// <returns></returns>
		public static List<dynamic> ReturnListOfObjects(this Type type, ISearchContext container, IWebDriver driver, By objContainer)
		{
			List<IWebElement> objElement = container.FindElements(objContainer).ToList();
			List<dynamic> objList = new List<dynamic>();

			foreach (var element in objElement)
			{
				dynamic obj = Activator.CreateInstance(type, element, driver);
				objList.Add(obj);
			}

			return objList; // should be followed up with .Cast<classname>().ToArray();
		}
	}
}
