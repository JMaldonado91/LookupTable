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

                cnn.Execute("insert into mattress_lookup (mattress, feel, year, profile) values (@Mattress, @feel, @year, @profile)", mattress);
            }

        }
        private static string LoadConnectionString(string id = "dbx")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}

