using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;


namespace WindowsFormsApp1
{
    public class DataAccess
    {
        public List<Mattress> Getmattress_lookup(string name)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("dbx")))
            {
                connection.Query<Mattress>("select * from mattress_lookup where name = '{name}'").ToList();
                var output = connection.Query<Mattress>("dbo.Mattresses_GetByname @name", new { name = name }).ToList();
                return output;
            }
        }

        internal void InsertMattress(string name, string feel, int year, int profile)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("dbx")))
            {
                //Mattress newMattress = new Mattress { Name = name, Feel = feel, Year = year, Profile = profile };
                List<Mattress> mattresses = new List<Mattress>();

                mattresses.Add(new Mattress { name = name, feel = feel, year = year, profile = profile });

                connection.Execute("dbo.Mattresses_Insert @name, @feel, @year, @profile", mattresses);
            }
        }

        internal void InsertMattress(string text1, string text2, string text3, string text4)
        {
            throw new NotImplementedException();
        }
    }
}
