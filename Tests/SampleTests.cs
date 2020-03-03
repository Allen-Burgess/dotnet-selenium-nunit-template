using NUnit.Framework;
using SeleniumBoilerplate.Config;

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
		public void SampleTest()
		{

		}

		[TearDown]
		public void TearDown()
		{
			TestCaseTearDown();
		}
	}
}
