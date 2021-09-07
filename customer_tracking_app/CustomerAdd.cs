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
    public partial class CustomerAdd : Form
    {
        SqlConnection baglanti;
        Connect con = new Connect();

        public CustomerAdd()
        {
            baglanti = new SqlConnection(con.adres);
            InitializeComponent();
        }
        Random rnd = new Random();
        private void CustomerAdd_Load(object sender, EventArgs e)
        {
            lblkullaniciAdi.Text = Login._kullaniciadi;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            listele();
            cmbSektor.SelectedIndex = 0;
            btnDuzenle.Enabled = false;

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

            _read();

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbltarihSaat.Text = DateTime.Now.ToString();
        }
        public void kaydet()
        {
            int sayi = rnd.Next(12345, 99999);
            String no=sayi.ToString();
            String musteriAd = txtAd.Text;
            String musteriSoyad = txtSoyad.Text;
            String gorev = txtGorev.Text;
            String adres = txtAdres.Text.ToString();
            String firmaAdi = txtFirmaAd.Text;
            String telefon = txtTelefon.Text.ToString();
            String sektor = cmbSektor.Text.ToString();
            String yetkili = txtYetkili.Text;
            String islemTarih = lbltarihSaat.Text.ToString();
            String kullanici = lblkullaniciAdi.Text.ToString();

            if (musteriAd == "" || musteriSoyad == "" || gorev == "" || adres == "" || firmaAdi == "" || telefon == "" || yetkili == "")
            {
                MessageBox.Show("Boş alan bırakmayınız", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbSektor.SelectedIndex == 0)
            {
                MessageBox.Show("Lütfen geçerli sektör ekleyiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                try
                {
                    DialogResult d;
                    d = MessageBox.Show(" Müşteri kaydedilsin mi?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.Yes)
                    {
                        baglanti.Open();

                        SqlCommand komut = new SqlCommand("INSERT INTO Musteri (musteriNo,musteriAdi,musteriSoyadi,gorev,adres,firmaAdi,telefon,sektor,firmaYetkilisi,islemtarihi,kullanici) values" +
                            " (@no,@musAd,@musSoyad,@gorev,@adres,@firmaAd,@tel,@sektor,@yetkili,@islemTarihi,@kullanici)", baglanti);

                        komut.Parameters.AddWithValue("@no", no);
                        komut.Parameters.AddWithValue("@musAd", musteriAd);
                        komut.Parameters.AddWithValue("@musSoyad", musteriSoyad);
                        komut.Parameters.AddWithValue("@gorev", gorev);
                        komut.Parameters.AddWithValue("@adres", adres);
                        komut.Parameters.AddWithValue("@firmaAd", firmaAdi);
                        komut.Parameters.AddWithValue("@tel", telefon);
                        komut.Parameters.AddWithValue("@sektor", sektor);
                        komut.Parameters.AddWithValue("@yetkili", yetkili);
                        komut.Parameters.AddWithValue("@islemTarihi", DateTime.Parse(islemTarih));
                        komut.Parameters.AddWithValue("@kullanici", kullanici);

                        komut.ExecuteNonQuery();
                        MessageBox.Show("Kayıt Başarılı", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        listele();
                        cleaner();
                        komut.Dispose();
                        baglanti.Close();


                    }
                }
                catch (Exception hata) { MessageBox.Show(hata.Message.ToString()); }
            }
        }
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        public void listele()
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

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            kaydet();
            
        }
        public void update()
        {   
            
            String musteriAd = txtAd.Text;
            String musteriSoyad = txtSoyad.Text;
            String gorev = txtGorev.Text;
            String adres = txtAdres.Text.ToString();
            String firmaAdi = txtFirmaAd.Text;
            String telefon = txtTelefon.Text.ToString();
            String sektor = cmbSektor.Text.ToString();
            String yetkili = txtYetkili.Text;
            String islemTarih = lbltarihSaat.Text.ToString();
            String kullanici = lblkullaniciAdi.Text.ToString();

            if (musteriAd == "" || musteriSoyad == "" || gorev == "" || adres == "" || firmaAdi == "" || telefon == "" || yetkili == "")
            {
                MessageBox.Show("Boş alan bırakmayınız", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbSektor.SelectedIndex == 0)
            {
                MessageBox.Show("Lütfen geçerli sektör ekleyiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                try
                {
                    DialogResult d;
                    d = MessageBox.Show(" Müşteri güncellensin mi?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.Yes)
                    {
                        baglanti.Open();

                        SqlCommand komut = new SqlCommand("UPDATE Musteri set musteriAdi=@musAd,musteriSoyadi=@musSoyad,gorev=@gorev,adres=@adres,firmaAdi=@firmaAd,telefon=@tel,sektor=@sektor,firmaYetkilisi=@yetkili,islemtarihi=@islemTarihi,kullanici=@kullanici where musteriNo=@musno", baglanti);

                        komut.Parameters.AddWithValue("@musno", lblmusno.Text);
                        komut.Parameters.AddWithValue("@musAd", musteriAd);
                        komut.Parameters.AddWithValue("@musSoyad", musteriSoyad);
                        komut.Parameters.AddWithValue("@gorev", gorev);
                        komut.Parameters.AddWithValue("@adres", adres);
                        komut.Parameters.AddWithValue("@firmaAd", firmaAdi);
                        komut.Parameters.AddWithValue("@tel", telefon);
                        komut.Parameters.AddWithValue("@sektor", sektor);
                        komut.Parameters.AddWithValue("@yetkili", yetkili);
                        komut.Parameters.AddWithValue("@islemTarihi", islemTarih);
                        komut.Parameters.AddWithValue("@kullanici", kullanici);

                        komut.ExecuteNonQuery();
                        MessageBox.Show("Güncelleme Başarılı", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        listele();
                        cleaner();
                        komut.Dispose();
                        baglanti.Close();

              

                    }
                }
                catch (Exception hata) { MessageBox.Show(hata.Message.ToString()); }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnKaydet.Enabled = false;
            btnDuzenle.Enabled = true;
            btnyeni.Enabled = true;

            lblmusno.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtGorev.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtAdres.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtFirmaAd.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtTelefon.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            cmbSektor.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtYetkili.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
           
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            update();
           
            btnDuzenle.Enabled = false;
            btnKaydet.Enabled = true;
        }

        private void btnyeni_Click(object sender, EventArgs e)
        {
            cleaner();
            btnDuzenle.Enabled = false;
            btnKaydet.Enabled = true;
        }
        public void cleaner()
        {
            txtAd.Clear();
            txtAdres.Clear();
            txtFirmaAd.Clear();
            txtGorev.Clear();
            txtSoyad.Clear();
            txtTelefon.Clear();
            txtYetkili.Clear();
            lblmusno.Text = "";
            cmbSektor.SelectedIndex = 0;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form ac = new Sector(this.cmbSektor);
            ac.ShowDialog();
        }
        private void _read()
        {
            baglanti.Open();
            SqlCommand command = new SqlCommand("Select distinct sektorAdi from Sektor",baglanti);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cmbSektor.Items.Add(reader["sektorAdi"].ToString());

            }
            reader.Close();
            baglanti.Close();
        }
    }
}
