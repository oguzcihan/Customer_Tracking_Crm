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
    public partial class CustomerChoose : Form
    {
        Connect con = new Connect();
        SqlConnection baglanti;
        public event musteriSecildiHandle _MusteriSecildi;
        public CustomerChoose()
        {
            baglanti = new SqlConnection(con.adres);
            InitializeComponent();
        }


        private void CustomerChoose_Load(object sender, EventArgs e)
        {
            Liste();
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
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        public void Liste()
        {
            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();
            dt.Clear();
            try
            {
                baglanti.Open();
                SqlCommand com = new SqlCommand("select*from Musteri", baglanti);
                da = new SqlDataAdapter(com);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
                com.Dispose();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message.ToString(), "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        public string MusteriNo { get; set; }
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MusteriNo = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            _MusteriSecildi?.Invoke();
            this.Hide();
        }

        public void birimler()
        {
            if (cmb_tur.Text == "Firma Adı")
            {
                Liste();
                baglanti.Open();
                SqlDataAdapter ada = new SqlDataAdapter("select*from Musteri where firmaAdi like '" +
                txtara.Text + "%'", baglanti);
                dt.Clear();
                ada.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
            else if (cmb_tur.Text == "Yetkili Adı")
            {
                Liste();
                baglanti.Open();
                SqlDataAdapter ada = new SqlDataAdapter("select*from Musteri where firmaYetkilisi like '" +
                txtara.Text + "%'", baglanti);
                dt.Clear();
                ada.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
            else if (cmb_tur.Text == "Telefon")
            {
                Liste();
                baglanti.Open();
                SqlDataAdapter ada = new SqlDataAdapter("select*from Musteri where telefon like '" +
                txtara.Text + "%'", baglanti);
                dt.Clear();
                ada.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
           
            else
            {
                Liste();
            }
        }
        private void txtara_TextChanged(object sender, EventArgs e)
        {
            birimler();
        }

    }
}
