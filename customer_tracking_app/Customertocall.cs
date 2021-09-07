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
    public partial class Customertocall : Form
    {
        Connect con = new Connect();
        SqlConnection baglanti;
        public Customertocall()
        {
            baglanti = new SqlConnection(con.adres);
            InitializeComponent();
        }

        private void Customertocall_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            lblkullaniciAdi.Text = Login._kullaniciadi;
            cmb_durum.SelectedIndex = 0;
            listele();
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

            ToolTip acik = new ToolTip();
            acik.SetToolTip(button1, "Tümünü Temizle");
            acik.ToolTipTitle = "Bilgi";
            acik.ToolTipIcon = ToolTipIcon.Info;
            acik.IsBalloon = true;
        }

        CustomerChoose frm = new CustomerChoose();
        private void btn_sec_Click(object sender, EventArgs e)
        {
            if (frm == null)
            {
                frm = new CustomerChoose();
            }
            frm._MusteriSecildi += Frm_musterisecildi;
            frm.ShowDialog();
        }

        private void Frm_musterisecildi()
        {
            lblmusteri_no.Text = frm.MusteriNo;
        }
        public void Read()
        {
            baglanti.Open();
            if (lblmusteri_no.Text == "--")
            {

            }
            else
            {
                SqlCommand komut = new SqlCommand("select*from Musteri where musteriNo=@no", baglanti);
                komut.Parameters.AddWithValue("@no", lblmusteri_no.Text);
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    lblmust_ad.Text = oku["musteriAdi"].ToString();
                    lbl_soyad.Text = oku["musteriSoyadi"].ToString();
                    lbl_mustel.Text = oku["telefon"].ToString();
                    lblAdres.Text = oku["adres"].ToString();
                    lblFirmaAd.Text = oku["firmaAdi"].ToString();
                    lblSektor.Text = oku["sektor"].ToString();
                    lblYetkili.Text = oku["firmaYetkilisi"].ToString();


                }
                oku.Close();

            }
            baglanti.Close();
        }

        private void lblmusteri_no_TextChanged(object sender, EventArgs e)
        {
            Read();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clear();
        }
        public void clear()
        {
            lblAdres.Text = "--";
            lblFirmaAd.Text = "--";
            lblmusteri_no.Text = "--";
            lblmust_ad.Text = "--";
            lblSektor.Text = "--";
            lblYetkili.Text = "--";
            lbl_mustel.Text = "--";
            lbl_soyad.Text = "--";
    
            cmb_durum.SelectedIndex = 0;
        }

        private void cmb_durum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_durum.Text == "Evet")
            {
                txt_yapilanislem.Clear();
                txt_yapilanislem.Enabled = true;
            }
            else if(cmb_durum.Text=="Hayır")
            {
                txt_yapilanislem.Text = "Yok";
                txt_yapilanislem.Enabled = false;
            }
            else
            {
                txt_yapilanislem.Text = "Yapılan Görüşmeyi Giriniz...";
                txt_yapilanislem.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _Update();
        }
        public void _Update()
        {
            String mesaj = txt_yapilanislem.Text;
            String durum = cmb_durum.Text.ToString();
            String tarih = lbltarihSaat.Text.ToString();
            String kullaniciAdi = lblkullaniciAdi.Text.ToString();

            if (txt_yapilanislem.Text=="")
            {
                MessageBox.Show("Boş alan bırakmayınız", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (lblmusteri_no.Text == "--")
            {
                MessageBox.Show("Geçerli müşteri seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (cmb_durum.SelectedIndex == 0)
            {
                MessageBox.Show("Lütfen geçerli durum seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                try
                {
                    DialogResult d;
                    d = MessageBox.Show("Görüşme kayıt edilsin mi?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.Yes)
                    {
                        baglanti.Open();

                        SqlCommand komut = new SqlCommand("UPDATE Musteri set arandimi=@arandimi,aramaMesaji=@mesaj,islemTarihi=@tarih,kullanici=@kullanici where musteriNo=@musno", baglanti);

                        komut.Parameters.AddWithValue("@musno", lblmusteri_no.Text);
                        komut.Parameters.AddWithValue("@arandimi", durum);
                        komut.Parameters.AddWithValue("@mesaj", mesaj);
                     
                        komut.Parameters.AddWithValue("@tarih", DateTime.Parse(tarih));
                        komut.Parameters.AddWithValue("@kullanici", kullaniciAdi);

                        komut.ExecuteNonQuery();
                        MessageBox.Show("Kayıt Başarılı", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        listele();
                        clear();
                        komut.Dispose();
                        baglanti.Close();



                    }
                }
                catch (Exception hata) { MessageBox.Show(hata.Message.ToString()); }
            }
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbltarihSaat.Text = DateTime.Now.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lblmusteri_no.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            lblmust_ad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            lbl_soyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
           
            lblAdres.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            lblFirmaAd.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            lbl_mustel.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            lblSektor.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            lblYetkili.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            cmb_durum.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            txt_yapilanislem.Text= dataGridView1.CurrentRow.Cells[10].Value.ToString();
        }
    }
}
