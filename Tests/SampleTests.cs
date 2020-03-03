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
		public void SampleTestTwo()
		{

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
