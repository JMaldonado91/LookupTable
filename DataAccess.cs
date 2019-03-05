using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using System.Data;
using MySql.Data;
using System.Data.SQLite;
using MySql.Data.MySqlClient;
using System.IO;

namespace WindowsFormsApp1
{
    public class DataAccess
    {
        public SQLiteConnection myConnection;

        public DataAccess()
        {
            myConnection = new SQLiteConnection("Data Source=mattress.db;Version=3;");
            if (!File.Exists("./mattress.db;Version=3;"))
            {
                SQLiteConnection.CreateFile("mattress.db;Version=3;");
                System.Console.WriteLine("Database file created");
            }
        }

        public void OpenConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Open)
            {
                myConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Closed)
            {
                myConnection.Clone();
            }
        }
        public static List<mattress> LoadMattress()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<mattress>("select * from mattress_lookup", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void InsertMattress(mattress mattress)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into mattress_lookup (mattress, profile, feel, year) values (@mattress, @profile, @feel, @year)", mattress);

                var test = "insert into mattress_lookup (mattress, profile, feel, year) values ('" + mattress.Mattress + "','" + mattress.profile + "', '" + mattress.feel + "', '" + mattress.year + "');";
                cnn.Open();

                cnn.BeginTransaction();
                cnn.Execute(test, new DynamicParameters());
                cnn.Close();

            }

        }
        private static string LoadConnectionString(string id = "dbx")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
