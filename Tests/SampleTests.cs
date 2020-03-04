using NUnit.Framework;
using SeleniumBoilerplate.Config;
using SeleniumBoilerplate.Data;
using SeleniumBoilerplate.POM.SamplePages;
using System.Collections.Generic;

namespace SeleniumBoilerplate.Tests
{
	[TestFixture]
	class SampleTests : TestConfiguration
	{
		GoogleHomePage GoogleHome;
		GoogleResultsPage Results; 

		[SetUp]
		public void SetUp()
		{
			TestCaseSetUp();
			GoogleHome = new GoogleHomePage(Driver);
			Results = new GoogleResultsPage(Driver);
		}

		/// <summary>
		/// Example test - Enter a google search and click the first result
		/// </summary>
		[Test]
		public void SampleTestOne()
		{
			GoogleHome.EnterSearch("Selenium");
			GoogleHome.ClickSearch();
			Results.ClickFirstResult();
		}

		/// <summary>
		/// Example test with test data - Enter a google search from the test data and click first result
		/// </summary>
		[TestCaseSource(nameof(SampleTestData))] // Thef
		public void SampleTestTwo(TestDataSet testData)
		{
			// testData.GetData("KEY") allows you to retieve data for each test case using the first row as your keys.
			// testData.SetData("KEY", "Value") allows you to set data at run time
			GoogleHome.EnterSearch(testData.GetData("SearchTerm"));
			GoogleHome.ClickSearch();
			Results.ClickFirstResult();
		}


		[TearDown]
		public void TearDown()
		{
			TestCaseTearDown();
		}

		/// <summary>
		/// Returns a testdata which behaves as test case of dictionaries  
		/// </summary>
		/// <returns> List of test cases</returns>
		public static List<TestDataSet> SampleTestData()
		{
			// Enter the path to your excel sheet from the data folder
			// no need to include extensions
			// The first row is recorded as the key and every row after that is run as a seperate test case
			return ExcelDataAccess.GetTestData("Sample/SampleTestData"); 
		} 
	}
}
