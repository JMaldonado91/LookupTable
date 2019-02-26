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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SQLiteCommand cmd;
        DataTable dt;
        SqlDataAdapter adpt;

        public Form1()
        {
            InitializeComponent();
            
        }

        void display()
        {
            SQLiteConnection con = new SQLiteConnection("data source=mattress.db;version=3");
            con.Open();
            DataTable dt = new DataTable();

            if (NameTextBox.Text.Length > 0)
            {
                var sda = new SQLiteDataAdapter("SELECT * FROM mattress_lookup WHERE MATTRESS LIKE '" + NameTextBox.Text + "%'", con);
                sda.Fill(dt);
            }
            else if (FeelTextBox.Text.Length > 0)
            {
                var sda = new SQLiteDataAdapter("SELECT * FROM mattress_lookup WHERE FEEL LIKE '" + FeelTextBox.Text + "%'", con);
                sda.Fill(dt);
            }
            else if (ProfileTextBox.Text.Length > 0)
            {
                var sda = new SQLiteDataAdapter("SELECT * FROM mattress_lookup WHERE PROFILE LIKE '" + ProfileTextBox.Text + "%'", con);
                sda.Fill(dt);
            }
            else if (YearTextBox.Text.Length > 0)
            {
                var sda = new SQLiteDataAdapter("SELECT * FROM mattress_lookup WHERE YEAR LIKE '" + YearTextBox.Text + "%'", con);
                sda.Fill(dt);
            }
            MattressLookupdataGridView1.DataSource = dt;
        }



        //Text Boxes for Form, user will select one box to search data//

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            //DataView dvmattress_lookup = dtmattress_lookup.DefaultView;
            //dvmattress_lookup.RowFilter = "mattress LIKE '%" + NameTextBox.Text + "%'";

            FeelTextBox.Text = "";
            ProfileTextBox.Text = "";
            YearTextBox.Text = "";
            display();
        }
       
        private void FeelTextBox_TextChanged(object sender, EventArgs e)
        {
            //DataView dvmattress_lookup = dtmattress_lookup.DefaultView;
            //dvmattress_lookup.RowFilter = "Feel LIKE '%" + FeelTextBox.Text + "%'";

            NameTextBox.Text = "";
            ProfileTextBox.Text = "";
            YearTextBox.Text = "";
            display();
        }

        private void ProfileTextBox_TextChanged(object sender, EventArgs e)
        {
            //DataView dvmattress_lookup = dtmattress_lookup.DefaultView;
            //dvmattress_lookup.RowFilter = "Profile LIKE '%" + FeelTextBox.Text + "%'";

            NameTextBox.Text = "";
            FeelTextBox.Text = "";
            YearTextBox.Text = "";
            display();

        }

        private void YearTextBox_TextChanged(object sender, EventArgs e)
        {
            //DataView dvmattress_lookup = dtmattress_lookup.DefaultView;
            //dvmattress_lookup.RowFilter = "Year LIKE '%" + FeelTextBox.Text + "%'";

            NameTextBox.Text = "";
            FeelTextBox.Text = "";
            ProfileTextBox.Text = "";
            display();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MattressLookupdataGridView1.DataSource = dt;
        }

        private DataTable GetMattressLookup()
        {
            DataTable dtmattress_lookup = new DataTable();

            string connString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;

            using (MySqlConnection con = new MySqlConnection(connString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM mattress_lookup", con))
                {
                    con.Open();

                    MySqlDataReader reader = cmd.ExecuteReader();

                    dtmattress_lookup.Load(reader);
                }
            }

                return dtmattress_lookup;
        }

        //When user wants to close form, they will click on Close//

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //When user wants to reset form, they will click on Reset//

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NameTextBox.Clear();
            FeelTextBox.Clear();
            YearTextBox.Clear();
            ProfileTextBox.Clear();
        }
    }
}
