using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumBoilerplate.Data
{
	public class TestDataSet
	{
		private Dictionary<string, string> Data { get; set; }

		public TestDataSet()
		{
			Data = new Dictionary<string, string>();
		}

		/// <summary>
		/// Add or update a key value pair to the current test data set.
		/// <para>When adding test data during a test run, prefix it with an _underscore to differentiate it to test data loaded before execution.</para>
		/// </summary>
		/// <param name="dataKey">Key</param>
		/// <param name="value">Value</param>
		public void SetData(string dataKey, string value)
		{
			if (DataExists(dataKey)) Data[dataKey] = value;
			else Data.Add(dataKey, value);
		}

		/// <summary>
		/// Gets the value of a piece of test data for the given key.
		/// </summary>
		/// <param name="dataKey">Key</param>
		/// <returns>Test data value</returns>
		public string GetData(string dataKey)
		{
			if (!Data.ContainsKey(dataKey)) throw new Exception($"Test data for key {dataKey} not found");
			return Data[dataKey];
		}

		/// <summary>
		/// Returns true if the given piece of test data exists.
		/// </summary>
		/// <param name="dataKey">Key</param>
		/// <returns></returns>
		public bool DataExists(string dataKey)
		{
			return Data.ContainsKey(dataKey);
		}

		/// <summary>
		/// Writes all of the test data to output
		/// </summary>
		public void WriteToConsole()
		{
			Console.WriteLine("*** TEST DATA ***");
			foreach (var dict in Data)
				Console.WriteLine($"{dict.Key}: {dict.Value}");
			Console.WriteLine("*** TEST DATA ***");
		}
	}
}
