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
    public partial class Task : Form
    {
        SqlConnection baglanti;
        Connect con = new Connect();
        public ComboBox _comboBox { get; set; }
        public Task(ComboBox comboBox = null)
        {
            baglanti = new SqlConnection(con.adres);
            InitializeComponent();
            if (comboBox != null)
                _comboBox = comboBox;
        }

        private void Task_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            random();
            listele();
            dataGridView1.Columns[0].HeaderText = "Id";
            dataGridView1.Columns[1].HeaderText = "Görev Adı";
            dataGridView1.Columns[1].Width = 200;
            button2.Enabled = false;
            btnKaydet.Enabled = true;

          
        }
        public void kaydet()
        {
            if (txtGorevAdi.Text == "")
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

                        SqlCommand komut = new SqlCommand("INSERT INTO Gorev (Id,gorevAdi) values (@no,@gorevad)", baglanti);

                        komut.Parameters.AddWithValue("@no", lblid.Text);
                        komut.Parameters.AddWithValue("@gorevad", txtGorevAdi.Text);
                        komut.ExecuteNonQuery();

                        if (_comboBox != null)
                            _comboBox.Items.Add(txtGorevAdi.Text);

                        MessageBox.Show("Kayıt Başarılı", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        listele();
                        komut.Dispose();
                        baglanti.Close();
                        txtGorevAdi.Clear();
                        random();
                    }
                }
                catch (Exception hata) { MessageBox.Show(hata.Message.ToString()); }
            }
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
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        private void listele()
        {
            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();
            dt.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select*From Gorev", baglanti);
            da = new SqlDataAdapter(komut);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            komut.Dispose();
            baglanti.Close();
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

        private void delete(int kod)
        {
            DialogResult d;
            d = MessageBox.Show("Silmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Gorev where Id=@no", baglanti);
                komut.Parameters.AddWithValue("@no", kod);
                komut.ExecuteNonQuery();
                if (_comboBox != null)
                    _comboBox.Items.Remove(txtGorevAdi.Text);
                komut.Dispose();
                baglanti.Close();
                txtGorevAdi.Clear();
                MessageBox.Show("Silindi", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            button2.Enabled = true;
            btnKaydet.Enabled = false;
            
            lblid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtGorevAdi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void txtGorevAdi_TextChanged(object sender, EventArgs e)
        {
            if (txtGorevAdi.Text == "")
            {
                random();
                btnKaydet.Enabled = true;
                button2.Enabled = false;
            }
        }
    }
}
