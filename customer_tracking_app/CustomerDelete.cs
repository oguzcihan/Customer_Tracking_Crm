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
    public partial class CustomerDelete : Form
    {
        Connect con = new Connect();
        SqlConnection baglanti;
        public CustomerDelete()
        {
            baglanti = new SqlConnection(con.adres);
            InitializeComponent();
        }

        private void CustomerDelete_Load(object sender, EventArgs e)
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
        public void delete(int id)
        {
            if (cmb_tur.SelectedIndex == 0)
            {
                MessageBox.Show("Önce arama türü seçiniz!", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                try
                {
                    DialogResult d;
                    d = MessageBox.Show("Silmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.Yes)
                    {
                        baglanti.Open();
                        SqlCommand komut = new SqlCommand("delete from Musteri where musteriNo=@no", baglanti);
                        komut.Parameters.AddWithValue("@no", id);
                        komut.ExecuteNonQuery();
                        komut.Dispose();
                        baglanti.Close();
                        txt_ara.Clear();
                        cmb_tur.SelectedIndex = 0;
                        MessageBox.Show("Silindi", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)  //Seçili Satırları Silme
            {
                int id = Convert.ToInt32(drow.Cells[0].Value);
                delete(id);
            }
            listele();
        }

        SqlDataAdapter da;
        DataTable dt = new DataTable();
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

        private void txt_ara_TextChanged(object sender, EventArgs e)
        {
            birimler();
        }
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
            else if (cmb_tur.Text == "Telefon")
            {
                listele();
                baglanti.Open();
                SqlDataAdapter ada = new SqlDataAdapter("select*from Musteri where telefon like '" +
                txt_ara.Text + "%'", baglanti);
                dt.Clear();
                ada.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
            else if (cmb_tur.Text == "Kullanıcı")
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

    }
}
