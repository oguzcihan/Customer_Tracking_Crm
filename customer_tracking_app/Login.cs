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
using System.Security.Cryptography;

namespace customer_tracking_app
{
    public partial class Login : Form
    {
        SqlConnection baglanti;
        Connect con = new Connect();
        public Login()
        {
            baglanti = new SqlConnection(con.adres);
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            ToolTip ac = new ToolTip();
            ac.SetToolTip(button2, "Şifre Göster");

            txtsifre.PasswordChar = '*';
        }
        public static string giris;
        public static string _kullaniciadi;

        public static string gorev;
        SqlDataReader data;
        SqlCommand com;
        public void _login()
        {
            baglanti.Open();
            com = new SqlCommand("Select*From Kullanici Where kullaniciAdi=@ad", baglanti);
            com.Parameters.AddWithValue("@ad", txtkullaniciadi.Text);
            _kullaniciadi = txtkullaniciadi.Text;

            data = com.ExecuteReader();
            if (data.Read())
            {
                giris = data["ad"].ToString();
                _kullaniciadi = txtkullaniciadi.Text;
                gorev = lbl_gorev.Text;

                baglanti.Close();
                baglanti.Open();
                string encryptpass=Encrypt(txtsifre.Text.ToString());
                com = new SqlCommand("Select*From Kullanici Where kullaniciAdi=@ad and sifre=@sifre", baglanti);
                com.Parameters.AddWithValue("@ad", txtkullaniciadi.Text.ToString());
                com.Parameters.AddWithValue("@sifre", encryptpass);
                _kullaniciadi = txtkullaniciadi.Text;
                data = com.ExecuteReader();
                if (data.Read())
                {
                    Home ac = new Home();
                    ac.Show();
                    this.Hide();
                  
                   
                }
                else
                {
                    errorProvider1.SetError(txtsifre, "Şifre Hatalı");
                }
                baglanti.Close();
            }
            else
            {
                errorProvider1.SetError(txtkullaniciadi, "Kullanıcı adı hatalı.");
            }
           
        }
        string hash = "";
        string Encrypt(string text)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripleDES.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }
        private void txtkullaniciadi_TextChanged(object sender, EventArgs e)
        {
            if (txtkullaniciadi.Text == "")
            {
                txtsifre.Clear();
                lbl_gorev.Text = "";
            }
            try
            {
                baglanti.Close();
                baglanti.Open();
                SqlCommand k = new SqlCommand("select*from Kullanici where kullaniciAdi=@ad", baglanti);
                k.Parameters.AddWithValue("@ad", txtkullaniciadi.Text);
                SqlDataReader oku = k.ExecuteReader();
                while (oku.Read())
                {

                    lbl_gorev.Text = oku["gorev"].ToString();

                }
                oku.Close();
                baglanti.Close();
            }
            catch (Exception hata) { MessageBox.Show(hata.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public Boolean sayac;
        private void button2_Click(object sender, EventArgs e)
        {
            if (sayac == true)
            {
                txtsifre.PasswordChar = '\0';
                sayac = false;
            }
            else
            {
                txtsifre.PasswordChar = '*';
                sayac = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _login();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //x tuşu kapatır.
                DialogResult g = MessageBox.Show("Uygulamayı kapatmak istiyor musunuz ? ", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (g == DialogResult.No)
                {
                    e.Cancel = true;
                    return;

                }
                Environment.Exit(0);
            }
            catch (Exception hata) { MessageBox.Show(hata.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
