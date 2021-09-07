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
    public partial class Sector : Form
    {
        Connect con = new Connect();
        SqlConnection baglanti;

        public ComboBox _comboBox { get; set; }
        public Sector(ComboBox comboBox=null)
        {
            baglanti = new SqlConnection(con.adres);
            InitializeComponent();
            if (comboBox != null)
                _comboBox = comboBox;
        }

        private void Sector_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            random();
            listele();
            dataGridView1.Columns[0].HeaderText = "Sektör Id";
            dataGridView1.Columns[1].HeaderText = "Sektör Adı";
            dataGridView1.Columns[1].Width = 200;
        }
        private void kaydet()
        {
            if (txtsektorad.Text == "")
            {
                MessageBox.Show("Tüm alanlar dolu olmalıdır!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                try
                {
                    DialogResult d;
                    d = MessageBox.Show(" Sektör kaydedilsin mi?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.Yes)
                    {
                        baglanti.Open();

                        SqlCommand komut = new SqlCommand("INSERT INTO Sektor (Id,sektorAdi) values (@sektorno,@sektorad)", baglanti);

                        komut.Parameters.AddWithValue("@sektorno", lblid.Text);
                        komut.Parameters.AddWithValue("@sektorad", txtsektorad.Text);
                        komut.ExecuteNonQuery();

                        if (_comboBox != null)
                            _comboBox.Items.Add(txtsektorad.Text);

                        MessageBox.Show("Kayıt Başarılı", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        listele();
                        komut.Dispose();
                        baglanti.Close();
                        txtsektorad.Clear();
                        random();
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
            SqlCommand komut = new SqlCommand("Select*From Sektor", baglanti);
            da = new SqlDataAdapter(komut);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            komut.Dispose();
            baglanti.Close();
        }
        private void random()
        {
            Random rnd = new Random();
            int sayi = rnd.Next(12345, 99999);
            lblid.Text = sayi.ToString();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            kaydet();
        }
        private void delete(int kod)
        {
            DialogResult d;
            d = MessageBox.Show("Silmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Sektor where Id=@no", baglanti);
                komut.Parameters.AddWithValue("@no", kod);
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglanti.Close();
                txtsektorad.Clear();
                MessageBox.Show("Silindi", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)  //Seçili Satırları Silme
            {
                int kod = Convert.ToInt32(drow.Cells[0].Value);
                delete(kod);
            }
            listele();
        }
    }
}
