using NUnit.Framework;
using SeleniumBoilerplate.Config;
using SeleniumBoilerplate.Data;
using System.Collections.Generic;

namespace SeleniumBoilerplate.Tests
{
	[TestFixture]
	class SampleTests : TestConfiguration
	{
		[SetUp]
		public void SetUp()
		{
			TestCaseSetUp();
		}

		/// <summary>
		/// Example test
		/// </summary>
		[Test]
		public void SampleTestOne()
		{

		}

		/// <summary>
		/// Example test with test data
		/// </summary>
		[TestCaseSource(nameof(SampleTestData))]
		public void SampleTestTwo(TestDataSet testData)
		{
			// testData.GetData("KEY") allows you to retieve data for each test case using the first row as your keys.
			// testData.SetData("KEY", "Value") allows you to set data at run time
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
			return ExcelDataAccess.GetTestData("Sample/SampleData");
		} 
	}
}
