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

namespace customer_tracking_app
{
    public partial class CustomerList : Form
    {
        Connect con = new Connect();
        SqlConnection baglanti = new SqlConnection();
        public CustomerList()
        {
            baglanti = new SqlConnection(con.adres);
            InitializeComponent();
        }

        private void txt_ara_TextChanged(object sender, EventArgs e)
        {
            birimler();
               
        }
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        public void birimler()
        {
            if (cmb_tur.Text == "Firma Adı")
            {
                listele();
                baglanti.Open();
                SqlDataAdapter ada = new SqlDataAdapter("select*from Musteri where firmaAdi like '" +
                txt_ara.Text + "%'", baglanti);
                dt.Clear();
                ada.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
            else if (cmb_tur.Text == "Arandı Mı?")
            {
                listele();
                baglanti.Open();
                SqlDataAdapter ada = new SqlDataAdapter("select*from Musteri where arandimi like '" +
                txt_ara.Text + "%'", baglanti);
                dt.Clear();
                ada.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
            else if (cmb_tur.Text == "Kullanıcı Adı")
            {
                listele();
                baglanti.Open();
                SqlDataAdapter ada = new SqlDataAdapter("select*from Musteri where kullanici like '" +
                txt_ara.Text + "%'", baglanti);
                dt.Clear();
                ada.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }

            else
            {
                listele();
            }
        }

        private void listele()
        {
            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();
            dt.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select*From Musteri", baglanti);
            da = new SqlDataAdapter(komut);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            komut.Dispose();
            baglanti.Close();
        }

        private void CustormerList_Load(object sender, EventArgs e)
        {
            listele();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            cmb_tur.SelectedIndex = 0;
            dataGridView1.Columns[0].HeaderText = "Müşteri No";
            dataGridView1.Columns[1].HeaderText = "Müşteri Ad";
            dataGridView1.Columns[2].HeaderText = "Müşteri Soyad";
            dataGridView1.Columns[3].HeaderText = "Görev";
            dataGridView1.Columns[4].HeaderText = "Adres";
            dataGridView1.Columns[5].HeaderText = "Firma Adı";
            dataGridView1.Columns[6].HeaderText = "Telefon";
            dataGridView1.Columns[7].HeaderText = "Sektör";
            dataGridView1.Columns[8].HeaderText = "Yetkili";
            dataGridView1.Columns[9].HeaderText = "Arandı Mı?";
            dataGridView1.Columns[10].HeaderText = "Arama Mesajı";
            dataGridView1.Columns[11].HeaderText = "İşlem Tarihi";
            dataGridView1.Columns[12].HeaderText = "Kullanıcı";
        }
    }
}
