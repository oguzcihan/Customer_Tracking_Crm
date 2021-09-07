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
    public partial class Useradd : Form
    {
        SqlConnection baglanti;
        Connect con = new Connect();
        public Useradd()
        {
            baglanti = new SqlConnection(con.adres);
            InitializeComponent();
        }

        private void Useradd_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            cmbGorev.SelectedIndex = 0;
            listele();
            _read();
            txtSifre.PasswordChar = '*';
            dataGridView1.Columns[0].HeaderText = "Kullanıcı No";
            dataGridView1.Columns[1].HeaderText = "Ad";
            dataGridView1.Columns[2].HeaderText = "Soyad";
            dataGridView1.Columns[3].HeaderText = "Telefon";
            dataGridView1.Columns[4].HeaderText = "Görev";
            dataGridView1.Columns[5].HeaderText = "Kullanıcı Adı";
            dataGridView1.Columns[6].HeaderText = "Şifre";
            dataGridView1.Columns[7].Visible=false;
            dataGridView1.Columns[8].HeaderText = "Kayıt Tarihi";

            btn_sil.Enabled = false;
            btnKaydet.Enabled = true;
            btnDuzenle.Enabled = false;
            txtKullaniciAdi.Enabled = true;

            ToolTip acik = new ToolTip();
            acik.SetToolTip(btnyeni, "Yeni kayıt oluştur.");
            acik.SetToolTip(picture_yetki, "Çıkarmak istediğiniz özellikleri seçiniz.");
            acik.ToolTipTitle = "Bilgi";
            acik.ToolTipIcon = ToolTipIcon.Info;
            acik.IsBalloon = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form frm = new Task(this.cmbGorev);
            frm.ShowDialog();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbltarihSaat.Text = DateTime.Now.ToString();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            _Save();
        }
        Random rnd = new Random();
        public string yetkiler;
        private void _Save()
        {
            int sayi = rnd.Next(12345, 99999);
            String no = sayi.ToString();
            String ad = txtAd.Text;
            String soyad = txtSoyad.Text;
            String gorev = cmbGorev.Text.ToString();         
            String telefon = txtTelefon.Text.ToString();
            String kullaniciAdi = txtKullaniciAdi.Text;
            String sifre = txtSifre.Text;
            String islemTarih = lbltarihSaat.Text.ToString();
            String encryptpass=Encrypt(sifre);
            String decryptpass = Decrypt(encryptpass);

            if (ad == "" || soyad == "" || telefon == "" || kullaniciAdi == "" || sifre == "" )
            {
                MessageBox.Show("Boş alan bırakmayınız", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbGorev.SelectedIndex == 0)
            {
                MessageBox.Show("Lütfen geçerli görev seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                try
                {
                    DialogResult d;
                    d = MessageBox.Show("Kullanıcı kaydedilsin mi?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.Yes)
                    {
                        baglanti.Open();

                        SqlCommand komut = new SqlCommand("INSERT INTO Kullanici (kullaniciNo,ad,soyad,telefon,gorev,kullaniciAdi,sifre,yetkiler,kayitTarihi) values" +
                            " (@no,@ad,@soyad,@tel,@gorev,@kulAd,@sifre,@yetkiler,@tarih)", baglanti);

                        komut.Parameters.AddWithValue("@no", no);
                        komut.Parameters.AddWithValue("@ad", ad);
                        komut.Parameters.AddWithValue("@soyad", soyad);
                        komut.Parameters.AddWithValue("@tel", telefon);
                        komut.Parameters.AddWithValue("@gorev", gorev);
                        komut.Parameters.AddWithValue("@kulAd", kullaniciAdi);
                        komut.Parameters.AddWithValue("@sifre", encryptpass);
                        komut.Parameters.AddWithValue("@tarih", DateTime.Parse(islemTarih));
                        

                        if (chkKullaniciIslemleri.Checked)
                        {
                            yetkiler = yetkiler + "1";
                        }
                        if (chkMusteriSil.Checked)
                        {
                            yetkiler = yetkiler + "2";
                        }
                        if (chkYedekle.Checked)
                        {
                            yetkiler = yetkiler + "3";
                        }
                        if (chk_Geriyukle.Checked)
                        {
                            yetkiler = yetkiler + "4";
                        }
                        if (chk_silinenMusteri.Checked)
                        {
                            yetkiler = yetkiler + "5";
                        }
                        if(chkKullaniciIslemleri.Checked==false&&chkMusteriSil.Checked==false&&chkYedekle.Checked==false&&chk_Geriyukle.Checked==false&&chk_silinenMusteri.Checked==false)
                        {
                            yetkiler = yetkiler + "0";
                        }
                        komut.Parameters.AddWithValue("@yetkiler", yetkiler);

                        komut.ExecuteNonQuery();
                        MessageBox.Show("Kayıt Başarılı", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        listele();
                        komut.Dispose();
                        baglanti.Close();
                        yetkiler = "";
                        _cleaner();

                    }
                }
                catch (Exception hata) { MessageBox.Show(hata.Message.ToString()); }
                baglanti.Close();
            }

        }

        string hash = "";
        string Encrypt(string text)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(text);
            using(MD5CryptoServiceProvider md5=new MD5CryptoServiceProvider())
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
        string Decrypt(string text)
        {
            byte[] data = Convert.FromBase64String(text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripleDES.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return UTF8Encoding.UTF8.GetString(results);
                }
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
            SqlCommand komut = new SqlCommand("Select*From Kullanici", baglanti);
            da = new SqlDataAdapter(komut);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            komut.Dispose();
            baglanti.Close();
        }

        public void _cleaner()
        {
            txtAd.Clear();
            txtKullaniciAdi.Clear();
            txtSifre.Clear();
            txtSoyad.Clear();
            txtTelefon.Clear();
            cmbGorev.SelectedIndex = 0;
            chkKullaniciIslemleri.Checked = false;
            chkMusteriSil.Checked = false;
            chkYedekle.Checked = false;
            chk_Geriyukle.Checked = false;
            chk_silinenMusteri.Checked = false;

            btn_sil.Enabled = false;
            btnKaydet.Enabled = true;
            btnDuzenle.Enabled = false;
            txtKullaniciAdi.Enabled = true;
        }
        public void _read()
        {
            baglanti.Open();
            SqlCommand command = new SqlCommand("Select distinct gorevAdi from Gorev", baglanti);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cmbGorev.Items.Add(reader["gorevAdi"].ToString());

            }
            reader.Close();
            baglanti.Close();
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            _update();
        }

        public void _update()
        {
            string sifre = txtSifre.Text.ToString();
            string encryptpass = Encrypt(sifre);

            if (txtAd.Text == "" || txtKullaniciAdi.Text == "" || txtSifre.Text == "" || txtSoyad.Text == "" || txtTelefon.Text == "")
            {
                MessageBox.Show("Boş alan bırakmayınız", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbGorev.SelectedIndex == 0)
            {
                MessageBox.Show("Lütfen geçerli görev seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                try
                {
                    DialogResult d;
                    d = MessageBox.Show("Güncelleme kaydedilsin mi?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.Yes)
                    {
                        baglanti.Open();
                        SqlCommand komut = new SqlCommand("UPDATE Kullanici SET ad=@adi,soyad=@soyadi,telefon=@tel,gorev=@gorevi,kullaniciAdi=@kulad,sifre=@sifresi,yetkiler=@yetki,kayitTarihi=@tarih where kullaniciNo=@no", baglanti);


                        komut.Parameters.AddWithValue("@no", lblmusno.Text);
                        komut.Parameters.AddWithValue("@adi", txtAd.Text);
                        komut.Parameters.AddWithValue("@soyadi", txtSoyad.Text);
                        komut.Parameters.AddWithValue("@tel", txtTelefon.Text.ToString());
                        komut.Parameters.AddWithValue("@gorevi", cmbGorev.Text.ToString());
                        komut.Parameters.AddWithValue("@kulad", txtKullaniciAdi.Text.ToString());
                        komut.Parameters.AddWithValue("@sifresi", encryptpass);
                        komut.Parameters.AddWithValue("@tarih", DateTime.Parse(lbltarihSaat.Text));


                        if (chkKullaniciIslemleri.Checked)
                        {
                            yetkiler = yetkiler + "1";
                        }
                        if (chkMusteriSil.Checked)
                        {
                            yetkiler = yetkiler + "2";
                        }
                        if (chkYedekle.Checked)
                        {
                            yetkiler = yetkiler + "3";
                        }
                        if (chk_Geriyukle.Checked)
                        {
                            yetkiler = yetkiler + "4";
                        }
                        if (chk_silinenMusteri.Checked)
                        {
                            yetkiler = yetkiler + "5";
                        }
                        if (chkKullaniciIslemleri.Checked == false && chkMusteriSil.Checked == false && chkYedekle.Checked == false && chk_Geriyukle.Checked == false && chk_silinenMusteri.Checked == false)
                        {
                            yetkiler = yetkiler + "0";
                        }
                        komut.Parameters.AddWithValue("@yetki", yetkiler);

                        komut.ExecuteNonQuery();
                        MessageBox.Show("Güncelleme Başarılı", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        listele();
                        komut.Dispose();
                        baglanti.Close();
                        yetkiler = "";
                        _cleaner();

                    }
                }
                catch (Exception hata) { MessageBox.Show(hata.Message.ToString()); }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnKaydet.Enabled = false;
            btnDuzenle.Enabled = true;
            btn_sil.Enabled = true;
            txtKullaniciAdi.Enabled = false;

            lblmusno.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtTelefon.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            cmbGorev.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtKullaniciAdi.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            string sifre= dataGridView1.CurrentRow.Cells[6].Value.ToString();
            string sifrecoz=Decrypt(sifre);
            txtSifre.Text = sifrecoz;
           
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)  //Seçili Satırları Silme
            {
                int kod = Convert.ToInt32(drow.Cells[0].Value);
                delete(kod);
            }
            listele();
        }

        private void delete(int kod)
        {
            try
            {
                DialogResult d;
                d = MessageBox.Show("Silmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("delete from Kullanici where kullaniciNo=@no", baglanti);
                    komut.Parameters.AddWithValue("@no", kod);
                    komut.ExecuteNonQuery();
                    komut.Dispose();
                    baglanti.Close();
                    _cleaner();
                    MessageBox.Show("Silindi", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
 

        private void button1_Click(object sender, EventArgs e)
        {
            _cleaner();
        }
        public Boolean sayac;

        private void button2_Click(object sender, EventArgs e)
        {
            if (sayac == true)
            {
                txtSifre.PasswordChar = '\0';
                sayac = false;
            }
            else
            {
                txtSifre.PasswordChar = '*';
                sayac = true;
            }
        }
    }
}
