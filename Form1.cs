using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.SQLite;
using System.Data.SqlClient;
using Dapper;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<Mattress> mattress_lookup = new List<Mattress>();


        public Form1()
        {
            InitializeComponent();

            MattressLookupdataGridView1.DataSource = mattress_lookup;

        }


        private void SetupData()
        {
            SQLiteConnection con = new SQLiteConnection("data source=mattress.db;version=3");
            con.Open();
            DataTable dt = new DataTable();

            

        }

        //Text Boxes for Form, user will select one box to search data

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            //DataView dvmattress_lookup = dtmattress_lookup.DefaultView;
            //dvmattress_lookup.RowFilter = "mattress LIKE '%" + NameTextBox.Text + "%'";

            SetupData();
        }
       
        private void FeelTextBox_TextChanged(object sender, EventArgs e)
        {
            //DataView dvmattress_lookup = dtmattress_lookup.DefaultView;
            //dvmattress_lookup.RowFilter = "Feel LIKE '%" + FeelTextBox.Text + "%'";

            SetupData();
        }

        private void ProfileTextBox_TextChanged(object sender, EventArgs e)
        {
            //DataView dvmattress_lookup = dtmattress_lookup.DefaultView;
            //dvmattress_lookup.RowFilter = "Profile LIKE '%" + FeelTextBox.Text + "%'";

            SetupData();

        }

        private void YearTextBox_TextChanged(object sender, EventArgs e)
        {
            //DataView dvmattress_lookup = dtmattress_lookup.DefaultView;
            //dvmattress_lookup.RowFilter = "Year LIKE '%" + FeelTextBox.Text + "%'";

            SetupData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MattressLookupdataGridView1.DataSource = mattress_lookup;
        }

        private DataTable GetMattressLookup()
        {
            DataTable dtmattress_lookup = new DataTable();

            string connString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;

            using (SQLiteConnection con = new SQLiteConnection(connString))
            {
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM mattress_lookup", con))
                {
                    con.Open();

                    SQLiteDataReader reader = cmd.ExecuteReader();

                    dtmattress_lookup.Load(reader);
                }
            }

                return dtmattress_lookup;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //When user wants to close form, they will click on Close
            this.Close();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //When user wants to reset form, they will click on Reset

            NameTextBox.Clear();
            FeelTextBox.Clear();
            YearTextBox.Clear();
            ProfileTextBox.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Add product information to database Sqlite Studio

            DataAccess db = new DataAccess();

            db.InsertMattress(NameTextBox.Text, FeelTextBox.Text, YearTextBox.Text, ProfileTextBox.Text);

            NameTextBox.Text = "";
            FeelTextBox.Text = "";
            YearTextBox.Text = "";
            ProfileTextBox.Text = "";

        } 
    }
}
