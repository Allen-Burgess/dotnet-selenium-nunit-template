using NUnit.Framework;

namespace SeleniumBoilerplate.PageUtils.NUnit
{
	class NUnitUtils
	{
		private static string AddErrorMessage(string detail)
		{
			string message = $"Invalid {detail} value";
			return message;
		}

		/// <summary>
		/// Asserts that the expected string contains the actual string (not case sensitive)
		/// </summary>
		/// <param name="expected">expected result</param>
		/// <param name="actual">actual result</param>
		/// <param name="detail">What is being tested (for error message)</param>
		public static void AssertStringsMatch(string expected, string actual, string detail)
		{
			string message = AddErrorMessage(detail);
			Assert.True(actual.ToLower().Contains(expected.ToLower())
				, $"{message} - expected: '{expected}', actual: '{actual}'");
		}

		/// <summary>
		/// Asserts that two doubles equal one another
		/// </summary>
		/// <param name="expected">expected result</param>
		/// <param name="actual">actual result</param>
		/// <param name="detail">What is being tested (for error message)</param>
		public static void AssertDoublesEqual(double expected, double actual, string detail)
		{
			string message = AddErrorMessage(detail);
			Assert.True(expected == actual
				, $"{message} - expected: {expected}, actual: {actual}");
		}

		/// <summary>
		/// Asserts that two integers equal one another
		/// </summary>
		/// <param name="expected">expected result</param>
		/// <param name="actual">actual result</param>
		/// <param name="detail">Value name (for error message)</param>
		/// <param name="testID">If applicable</param>
		public static void AssertIntsEqual(int expected, int actual, string detail)
		{
			string message = AddErrorMessage(detail);
			Assert.True(expected == actual
				, $"{message} - expected: {expected}, actual: {actual}");
		}
	}
}
