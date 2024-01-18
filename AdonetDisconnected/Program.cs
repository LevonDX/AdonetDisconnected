using Microsoft.Data.SqlClient;
using System.Data;

namespace AdonetDisconnected
{
	internal class Program
	{
		static void Main(string[] args)
		{
			using SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=LibrarySystemDB; Integrated Security=true; TrustServerCertificate=True");

			connection.Open();
			SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Book", connection);

			DataSet books = new DataSet();

			adapter.Fill(books);

			books.Tables[0].Rows[0]["Title"] = "New Title1";

			// Generate update command for adapter

			SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

			adapter.UpdateCommand = builder.GetUpdateCommand();

			adapter.Update(books);

			//foreach (DataRow row in books.Tables[0].Rows)
			//{
			//	foreach (DataColumn column in books.Tables[0].Columns)
			//	{
			//		System.Console.WriteLine($"{column.ColumnName}: {row[column]}");
			//	}
			//	System.Console.WriteLine();
			//}
		}
	}
}