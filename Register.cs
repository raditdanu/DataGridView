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
using System.Text.RegularExpressions;

namespace RegisterLogin
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        public static string nm = "";
        public static string lh = "";
        public static string us = "";
        public static string pw = "";
        public static string tgl = "";
        public string conString = "Data Source=DESKTOP-JFBBSA9;Initial Catalog=LProjek;Persist Security Info=True;User ID=njet;Password=msql123";
        private void rgstr_Click(object sender, EventArgs e)
        {
            if (nama.Text == "")
            {
                errorProvider1.SetError(nama, "Masukkan Nama");
            }
            else if (kelahiran.Text == "")
            {
                errorProvider1.SetError(kelahiran, "Masukkan Kelahiran");
            }
            else if (username.Text == "")
            {
                errorProvider1.SetError(username, "Masukkan Username");
            }
            else if (password.Text == "")
            {
                errorProvider1.SetError(password, "Masukkan Password");
            }
            else
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                bool exist = false;

                using (SqlCommand cmd = new SqlCommand("Select count(*) from tbl_user where Username=@username", con))
                {
                    cmd.Parameters.AddWithValue("@username", username.Text);
                    exist = (int)cmd.ExecuteScalar() > 0;
                }
                
                if (exist)
                {
                    MessageBox.Show(string.Format("Username {0} Sudah Dipakai", username.Text));
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("Insert into tbl_user(Username, Password, Nama, Lahir, Tanggal) values(@username, @password, @nama, @kelahiran, @tanggal)", con);
                    cmd.Parameters.AddWithValue("@username", username.Text);
                    cmd.Parameters.AddWithValue("@password", password.Text);
                    cmd.Parameters.AddWithValue("@nama", nama.Text);
                    cmd.Parameters.AddWithValue("@kelahiran", kelahiran.Text);
                    cmd.Parameters.AddWithValue("@tanggal", dateTimePicker1.Text);
                    nm = nama.Text;
                    lh = kelahiran.Text;
                    us = username.Text;
                    pw = password.Text;
                    tgl = dateTimePicker1.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Register Berhasil");
                    this.Hide();
                    Login f1 = new Login();
                    f1.Show();

                }
            }
        }

        private void nama_Validating(object sender, CancelEventArgs e)
        {
            if (nama.Text == string.Empty)
            {
                errorProvider1.SetError(nama, "Masukkan Nama");
                errorProvider2.SetError(nama, "");
            }
            else
            {
                errorProvider1.SetError(nama, "");
                errorProvider2.SetError(nama, "Benar");
                
            }
        }

        private void kelahiran_Validating(object sender, CancelEventArgs e)
        {
            if (kelahiran.Text == string.Empty)
            {
                errorProvider1.SetError(kelahiran, "Masukkan Kelahiran");
                errorProvider2.SetError(kelahiran, "");
            }
            else
            {
                errorProvider1.SetError(kelahiran, "");
                errorProvider2.SetError(kelahiran, "Benar");

            }
        }

        private void username_Validating(object sender, CancelEventArgs e)
        {
            if (username.Text == string.Empty)
            {
                errorProvider1.SetError(username, "Masukkan Username");
                errorProvider2.SetError(username, "");
            }
            else
            {
                errorProvider1.SetError(username, "");
                errorProvider2.SetError(username, "Benar");

            }
        }

        private void password_Validating(object sender, CancelEventArgs e)
        {
            if (password.Text == string.Empty)
            {
                errorProvider1.SetError(password, "Masukkan Password");
                errorProvider2.SetError(password, "");
            }
            else
            {
                errorProvider1.SetError(password, "");
                errorProvider2.SetError(password, "Benar");

            }
        }

        private void Kembali_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login f1 = new Login();
            f1.Show();
        }
    }
}
