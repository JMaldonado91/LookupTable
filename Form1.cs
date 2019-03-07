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
        List<mattress> mattress_lookup = new List<mattress>();


        public Form1()
        {
            InitializeComponent();

        }

        private SQLiteConnection con;
        private SQLiteCommand cmd;
        private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();


        private void LoadMattressList()
        {
            mattress_lookup = DataAccess.LoadMattress();

            WiredUpMattressList();
        }

        private void WiredUpMattressList()
        {
            MattressLookupdataGridView1.DataSource = null;
            MattressLookupdataGridView1.DataSource = mattress_lookup;

        }

        //Text Boxes for Form, user will select one box to search data

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            //DataView dvmattress_lookup = dtmattress_lookup.DefaultView;
            //dvmattress_lookup.RowFilter = "mattress LIKE '%" + NameTextBox.Text + "%'";

        }

        private void FeelTextBox_TextChanged(object sender, EventArgs e)
        {
            //DataView dvmattress_lookup = dtmattress_lookup.DefaultView;
            //dvmattress_lookup.RowFilter = "Feel LIKE '%" + FeelTextBox.Text + "%'";

        }

        private void ProfileTextBox_TextChanged(object sender, EventArgs e)
        {
            //DataView dvmattress_lookup = dtmattress_lookup.DefaultView;
            //dvmattress_lookup.RowFilter = "Profile LIKE '%" + FeelTextBox.Text + "%'";  

        }

        private void YearTextBox_TextChanged(object sender, EventArgs e)
        {
            //DataView dvmattress_lookup = dtmattress_lookup.DefaultView;
            //dvmattress_lookup.RowFilter = "Year LIKE '%" + FeelTextBox.Text + "%'";

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
            //insert button will create new row of data
            mattress m = new mattress();

            m.Mattress = NameTextBox.Text;
            m.feel = FeelTextBox.Text;
            m.year = YearTextBox.Text;
            m.profile = ProfileTextBox.Text;

            DataAccess.InsertMattress(m);

            NameTextBox.Text = "";
            FeelTextBox.Text = "";
            YearTextBox.Text = "";
            ProfileTextBox.Text = "";

            MessageBox.Show("Record inserted successfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //refresh button will load datatable
            LoadMattressList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            SQLiteConnection myConnection = new SQLiteConnection("data source=mattress.db;Version=3;");
            myConnection = new SQLiteConnection("Data Source=mattress.db;Version=3;");
            myConnection.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = myConnection;
            cmd.CommandText = "select * from mattress_lookup";
            using (SQLiteDataReader sdr = cmd.ExecuteReader())
            {
                DataTable dt = new DataTable();
                dt.Load(sdr);
                sdr.Close();
                myConnection.Close();
                MattressLookupdataGridView1.DataSource = dt;
            }

        }
    }
}


    


