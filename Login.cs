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
using System.Configuration;

namespace RegisterLogin
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public static string nm = "";
        public string conString = "Data Source=DESKTOP-JFBBSA9;Initial Catalog=LProjek;Persist Security Info=True;User ID=njet;Password=msql123";
        private void button2_Click(object sender, EventArgs e)
        {
            Register f2 = new Register();
            f2.Show();
            this.Hide();
        }

        private void Lgn_Click(object sender, EventArgs e)
        {
            if(username.Text=="" || password.Text=="")
            {
                MessageBox.Show("Silahkan Masukkan Username dan Password");
                return;
            }
            else if((this.username.Text == "admin") && (this.password.Text == "admin"))
            {
                MessageBox.Show("Login Admin Berhasil");
                this.Hide();
                Admin f3 = new Admin();
                f3.Show();
                return;
            }
            try
            {
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand("Select * from tbl_user where Username=@username and Password=@password", con);
                cmd.Parameters.AddWithValue("@username", username.Text);
                cmd.Parameters.AddWithValue("@password", password.Text);
                con.Open();
                nm = username.Text;
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                con.Close();
                int count = ds.Tables[0].Rows.Count;
                if (count == 1)
                {
                    MessageBox.Show("Login Berhasil");
                    this.Hide();
                    User f4 = new User();
                    
                    //User.lbl = string.Format("Selamat Datang {0}", Register.nm);
                    f4.Show();
                }
                else
                {
                    MessageBox.Show("Login Gagal");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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
    }
}
