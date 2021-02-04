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
    public partial class Admin : Form
    {
        SqlDataAdapter adap;
        DataSet ds;
        SqlCommand cmd;
        SqlDataAdapter adapt;
        int id = 0;

        public Admin()
        {
            InitializeComponent();
            DisplayData();
        }
        public string conString = "Data Source=DESKTOP-JFBBSA9;Initial Catalog=LProjek;Persist Security Info=True;User ID=njet;Password=msql123";


        private void Admin_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            try
            {
                con.Open();
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

        private void kembali_Click(object sender, EventArgs e)
        {
            Login f1 = new Login();
            f1.Show();
            this.Hide();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            if (id != 0)
            {
                con.Open();
                cmd = new SqlCommand("delete tbl_user where id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully!");
                DisplayData();
                ClearData();

            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DisplayData()
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from tbl_user", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        //Clear Data  
        private void ClearData()
        {
            Register.nm = "";
            Register.lh = "";
            Register.tgl = "";
            Register.us = "";
            Register.pw = "";
            id = 0;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            Register.nm = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            Register.lh = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            Register.tgl = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            Register.us = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            Register.pw = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }
    }
}
