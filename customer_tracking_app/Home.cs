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
    public partial class Home : Form
    {
        SqlConnection baglanti;
        Connect con = new Connect();
        public Home()
        {
            baglanti = new SqlConnection(con.adres);
            InitializeComponent();
        }
        public static string yetki;
        SqlCommand com;
        SqlDataReader data;
        private void Home_Load(object sender, EventArgs e)
        {

            lbl_kullaniciadi.Text = Login._kullaniciadi;
            lbl_gorev.Text = Login.gorev;
            _yetkilendirme();

        }
        public void _yetkilendirme()
        {
            baglanti.Open();
            com = new SqlCommand("Select*From Kullanici Where kullaniciAdi=@ad", baglanti);
            com.Parameters.AddWithValue("@ad", Login._kullaniciadi);
            data = com.ExecuteReader();
            if (data.Read())
            {
                yetki = data["yetkiler"].ToString();
                if (yetki.Contains("1") == true)
                {
                    kullanıcıİşlemleriToolStripMenuItem.Visible = false;
                    if (yetki.Contains("2") == true)
                    {
                        müşteriSilToolStripMenuItem.Visible = false;

                        if (yetki.Contains("3") == true)
                        {
                            yedekleToolStripMenuItem.Visible = false;
                            if (yetki.Contains("4") == true)
                            {
                                geriYükleToolStripMenuItem.Visible = false;

                                if (yetki.Contains("5") == true)
                                {
                                    silinenMüşteriKayıtlarıToolStripMenuItem.Visible = false;
                                    if (yetki.Contains("0") == true)
                                    {

                                    }
                                }
                            }
                        }
                    }

                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (baslik.Left < 1360)
            {
                baslik.Left += 1;
            }

            else
            {
                baslik.Left = -340;
            }
        }

        private void müşteriKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new CustomerAdd();
            frm.ShowDialog();
        }

        private void müşteriSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form del = new CustomerDelete();
            del.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new CustomerAdd();
            frm.ShowDialog();
        }

        private void arananMüşterilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerCalled ac = new CustomerCalled();
            ac.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CustomerCalled ac = new CustomerCalled();
            ac.ShowDialog();
        }

        private void müşteriListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerList list = new CustomerList();
            list.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CustomerList list = new CustomerList();
            list.ShowDialog();
        }

        private void aranacakMüşterilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customertocall frm = new Customertocall();
            frm.ShowDialog();
        }

        private void kullanıcıKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Useradd frm = new Useradd();
            frm.ShowDialog();
        }

        private void kullanıcıDeğiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home kapat = new Home();
            kapat.Close();
            Login frm1 = new Login();
            frm1.Show();
            this.Hide();
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
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

        private void yedekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Close();
                baglanti.Open();
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "(*.bak) | *.bak|(*.rar)|*.rar";
                save.Title = "Database backup";
                save.FilterIndex = 0;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    string sql = string.Format(@"BACKUP database customer_tracking to disk='{0}'", save.FileName);
                    SqlCommand cmd = new SqlCommand(sql, baglanti);
                    ;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Yedeklendi", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                baglanti.Close();
            }
            catch (Exception hata) { MessageBox.Show(hata.Message.ToString()); }
        }

        private void hesapMakinesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void çıkışToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void müşteriGenelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report1 ac = new Report1();
            ac.ShowDialog();
        }

        private void silinenMüşteriKayıtlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report2 ac = new Report2();
            ac.ShowDialog();
        }

        private void kullanıcılarListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report3 ac = new Report3();
            ac.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Report2 ac = new Report2();
            ac.ShowDialog();
        }

        private void geriYükleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baglanti.Close();
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "SQL SERVER database backup files|*.bak";
            dlg.Title = "Database restore";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                String name=dlg.FileName;
                string database = baglanti.Database.ToString();
                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open();
                }
                try
                {
                    string sqlStmt2 = string.Format("ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                    SqlCommand bu2 = new SqlCommand(sqlStmt2, baglanti);
                    bu2.ExecuteNonQuery();

                    string sqlStmt3 = "USE MASTER RESTORE DATABASE [" + database + "] FROM DISK='" + name + "'WITH REPLACE;";
                    SqlCommand bu3 = new SqlCommand(sqlStmt3, baglanti);
                    bu3.ExecuteNonQuery();

                    string sqlStmt4 = string.Format("ALTER DATABASE [" + database + "] SET MULTI_USER");
                    SqlCommand bu4 = new SqlCommand(sqlStmt4, baglanti);
                    bu4.ExecuteNonQuery();

                    MessageBox.Show("Geri yükleme başarılı","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    baglanti.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }


        }

        private void yardımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help hlp = new Help();
            hlp.ShowDialog();
        }
    }
}
