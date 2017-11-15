using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace BDConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLConnection();
            //OLEDB();
            Console.ReadLine();
        }

        static void SQLConnection()
        {
            string connectionString = null;
            connectionString = "Data Source=MICROSOFT-PC; Initial Catalog=BD; Integrated Security=True";
            SqlConnection scn = new SqlConnection(connectionString);
            try
            {
                scn.Open();
                Console.WriteLine("SQL Connection Open!");
                Console.WriteLine("\nWrite the request:");
                SqlCommand cmd = new SqlCommand(Console.ReadLine(), scn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (cmd.CommandText.Substring(0, 6).ToLower() == "select")
                {
                    Console.WriteLine();
                    foreach (DataTable dt in ds.Tables)
                    {
                        for (int col = 0; col < dt.Columns.Count; col++)
                        {
                            Console.Write(dt.Columns[col].ColumnName.Trim() + "\t");
                        }
                        Console.WriteLine('\n');
                        for (int row = 0; row < dt.Rows.Count; row++)
                        {
                            for (int col = 0; col < dt.Columns.Count; col++)
                            {
                                Console.Write(dt.Rows[row][col].ToString().Trim() + "\t");
                            }
                            Console.WriteLine();
                        }
                    }
                }
                scn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void OLEDB()
        {
            string connectionString = null;
            connectionString = "Provider=SQLOLEDB; Data Source=MICROSOFT-PC; Initial Catalog=BD; Integrated Security=SSPI";
            OleDbConnection olcn = new OleDbConnection(connectionString);
            try
            {
                olcn.Open();
                Console.WriteLine("OLEDB Connection Open!");
                Console.WriteLine("\nWrite the request:");
                OleDbCommand cmd = new OleDbCommand(Console.ReadLine(), olcn);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (cmd.CommandText.Substring(0, 6).ToLower() == "select")
                {
                    Console.WriteLine();
                    foreach (DataTable dt in ds.Tables)
                    {
                        for (int col = 0; col < dt.Columns.Count; col++)
                        {
                            Console.Write(dt.Columns[col].ColumnName.Trim() + "\t");
                        }
                        Console.WriteLine('\n');
                        for (int row = 0; row < dt.Rows.Count; row++)
                        {
                            for (int col = 0; col < dt.Columns.Count; col++)
                            {
                                Console.Write(dt.Rows[row][col].ToString().Trim() + "\t");
                            }
                            Console.WriteLine();
                        }
                    }
                }
                olcn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}