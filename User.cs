//Teknik Informatika Malam
//Tugas Besar Algoritma
//Dandy Adhitya 411201007
//Hari Nugraha 411201013
//Mohammad Ramdhani 411201014
//Raditya Danu Erlangga 411201018

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RegisterLogin
{
    public partial class User : Form
    {

        SqlDataAdapter adap;
        DataSet ds;

        public User()
        {
            InitializeComponent();
        }

        public string conString = "Data Source=DESKTOP-JFBBSA9;Initial Catalog=LProjek;Persist Security Info=True;User ID=njet;Password=msql123";

        private void User_Load(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(conString);
            try
            {
                con.Open();
                label1.Text = string.Format("Selamat Datang {0}", Login.nm);
                adap = new SqlDataAdapter("Select id as 'No', Nama as 'Nama', Lahir as 'Kelahiran', Tanggal as 'Tgl Lahir', Username as 'Username', Password as 'Password' FROM tbl_user", con);
                ds = new System.Data.DataSet();
                adap.Fill(ds, "Details");
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void logout_Click(object sender, EventArgs e)
        {
            Login f1 = new Login();
            f1.Show();
            this.Hide();
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            /*lbl = label1.Text;*/
        }
    }
}
