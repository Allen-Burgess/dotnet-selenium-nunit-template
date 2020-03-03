using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.IO;
using System.Reflection;

namespace SeleniumBoilerplate.Data
{
	class ExcelDataAccess
	{
		public static List<TestDataSet> GetTestData(string dataSheet)
		{
			var rows = new List<TestDataSet>();
			var fileName = new Uri(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase), $"Data/{dataSheet}.xlsx")).LocalPath;
			using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
			{
				using (var reader = ExcelReaderFactory.CreateReader(stream))
				{

					var conf = new ExcelDataSetConfiguration
					{
						ConfigureDataTable = _ => new ExcelDataTableConfiguration
						{
							UseHeaderRow = true
						}
					};

					dynamic testdataset = new ExpandoObject();
					var result = reader.AsDataSet(conf).Tables[0];

					foreach (DataRow row in result.Rows)
					{
						var dataSet = new TestDataSet();
						foreach (DataColumn col in result.Columns)
						{
							dataSet.SetData(col.ColumnName, row[col.ColumnName].ToString());
						}
						rows.Add(dataSet);
					}
					reader.Close();
				}
			}
			return rows;
		}
	}
}
