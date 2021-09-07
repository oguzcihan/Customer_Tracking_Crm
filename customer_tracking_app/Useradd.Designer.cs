namespace customer_tracking_app
{
    partial class Useradd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Useradd));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.picture_yetki = new System.Windows.Forms.PictureBox();
            this.chkYedekle = new System.Windows.Forms.CheckBox();
            this.chk_Geriyukle = new System.Windows.Forms.CheckBox();
            this.chk_silinenMusteri = new System.Windows.Forms.CheckBox();
            this.chkKullaniciIslemleri = new System.Windows.Forms.CheckBox();
            this.chkMusteriSil = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnyeni = new System.Windows.Forms.Button();
            this.lbltarihSaat = new System.Windows.Forms.Label();
            this.lblmusno = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.cmbGorev = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.txtSoyad = new System.Windows.Forms.TextBox();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnDuzenle = new System.Windows.Forms.Button();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn_sil = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_yetki)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.picture_yetki);
            this.groupBox1.Controls.Add(this.chkYedekle);
            this.groupBox1.Controls.Add(this.chk_Geriyukle);
            this.groupBox1.Controls.Add(this.chk_silinenMusteri);
            this.groupBox1.Controls.Add(this.chkKullaniciIslemleri);
            this.groupBox1.Controls.Add(this.chkMusteriSil);
            this.groupBox1.Location = new System.Drawing.Point(12, 271);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 159);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Yetkiler";
            // 
            // picture_yetki
            // 
            this.picture_yetki.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picture_yetki.Image = ((System.Drawing.Image)(resources.GetObject("picture_yetki.Image")));
            this.picture_yetki.Location = new System.Drawing.Point(273, 10);
            this.picture_yetki.Name = "picture_yetki";
            this.picture_yetki.Size = new System.Drawing.Size(21, 20);
            this.picture_yetki.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture_yetki.TabIndex = 102;
            this.picture_yetki.TabStop = false;
            // 
            // chkYedekle
            // 
            this.chkYedekle.AutoSize = true;
            this.chkYedekle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chkYedekle.Location = new System.Drawing.Point(42, 72);
            this.chkYedekle.Name = "chkYedekle";
            this.chkYedekle.Size = new System.Drawing.Size(70, 19);
            this.chkYedekle.TabIndex = 38;
            this.chkYedekle.Text = "Yedekle";
            this.chkYedekle.UseVisualStyleBackColor = true;
            // 
            // chk_Geriyukle
            // 
            this.chk_Geriyukle.AutoSize = true;
            this.chk_Geriyukle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chk_Geriyukle.Location = new System.Drawing.Point(42, 97);
            this.chk_Geriyukle.Name = "chk_Geriyukle";
            this.chk_Geriyukle.Size = new System.Drawing.Size(82, 19);
            this.chk_Geriyukle.TabIndex = 37;
            this.chk_Geriyukle.Text = "Geri Yükle";
            this.chk_Geriyukle.UseVisualStyleBackColor = true;
            // 
            // chk_silinenMusteri
            // 
            this.chk_silinenMusteri.AutoSize = true;
            this.chk_silinenMusteri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chk_silinenMusteri.Location = new System.Drawing.Point(42, 122);
            this.chk_silinenMusteri.Name = "chk_silinenMusteri";
            this.chk_silinenMusteri.Size = new System.Drawing.Size(152, 19);
            this.chk_silinenMusteri.TabIndex = 34;
            this.chk_silinenMusteri.Text = "Silinen Müşteri Raporu";
            this.chk_silinenMusteri.UseVisualStyleBackColor = true;
            // 
            // chkKullaniciIslemleri
            // 
            this.chkKullaniciIslemleri.AutoSize = true;
            this.chkKullaniciIslemleri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chkKullaniciIslemleri.Location = new System.Drawing.Point(42, 22);
            this.chkKullaniciIslemleri.Name = "chkKullaniciIslemleri";
            this.chkKullaniciIslemleri.Size = new System.Drawing.Size(123, 19);
            this.chkKullaniciIslemleri.TabIndex = 35;
            this.chkKullaniciIslemleri.Text = "Kullanıcı İşlemleri";
            this.chkKullaniciIslemleri.UseVisualStyleBackColor = true;
            // 
            // chkMusteriSil
            // 
            this.chkMusteriSil.AutoSize = true;
            this.chkMusteriSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chkMusteriSil.Location = new System.Drawing.Point(42, 47);
            this.chkMusteriSil.Name = "chkMusteriSil";
            this.chkMusteriSil.Size = new System.Drawing.Size(84, 19);
            this.chkMusteriSil.TabIndex = 34;
            this.chkMusteriSil.Text = "Müşteri Sil";
            this.chkMusteriSil.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnyeni);
            this.groupBox2.Controls.Add(this.lbltarihSaat);
            this.groupBox2.Controls.Add(this.lblmusno);
            this.groupBox2.Controls.Add(this.button7);
            this.groupBox2.Controls.Add(this.cmbGorev);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtSifre);
            this.groupBox2.Controls.Add(this.txtKullaniciAdi);
            this.groupBox2.Controls.Add(this.txtTelefon);
            this.groupBox2.Controls.Add(this.txtSoyad);
            this.groupBox2.Controls.Add(this.txtAd);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(300, 247);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kayıt İşlemleri";
            // 
            // btnyeni
            // 
            this.btnyeni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnyeni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnyeni.ForeColor = System.Drawing.SystemColors.Control;
            this.btnyeni.Image = ((System.Drawing.Image)(resources.GetObject("btnyeni.Image")));
            this.btnyeni.Location = new System.Drawing.Point(269, 9);
            this.btnyeni.Name = "btnyeni";
            this.btnyeni.Size = new System.Drawing.Size(25, 25);
            this.btnyeni.TabIndex = 74;
            this.btnyeni.UseVisualStyleBackColor = true;
            this.btnyeni.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbltarihSaat
            // 
            this.lbltarihSaat.AutoSize = true;
            this.lbltarihSaat.Location = new System.Drawing.Point(231, 57);
            this.lbltarihSaat.Name = "lbltarihSaat";
            this.lbltarihSaat.Size = new System.Drawing.Size(27, 13);
            this.lbltarihSaat.TabIndex = 75;
            this.lbltarihSaat.Text = "tarih";
            this.lbltarihSaat.Visible = false;
            // 
            // lblmusno
            // 
            this.lblmusno.AutoSize = true;
            this.lblmusno.Location = new System.Drawing.Point(239, 70);
            this.lblmusno.Name = "lblmusno";
            this.lblmusno.Size = new System.Drawing.Size(19, 13);
            this.lblmusno.TabIndex = 76;
            this.lblmusno.Text = "no";
            this.lblmusno.Visible = false;
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.ForeColor = System.Drawing.SystemColors.Control;
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.Location = new System.Drawing.Point(186, 127);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(25, 25);
            this.button7.TabIndex = 73;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // cmbGorev
            // 
            this.cmbGorev.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGorev.FormattingEnabled = true;
            this.cmbGorev.Items.AddRange(new object[] {
            "Seçiniz"});
            this.cmbGorev.Location = new System.Drawing.Point(80, 130);
            this.cmbGorev.Name = "cmbGorev";
            this.cmbGorev.Size = new System.Drawing.Size(100, 21);
            this.cmbGorev.TabIndex = 15;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(181, 196);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 22);
            this.button2.TabIndex = 14;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(38, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Görev";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(46, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Şifre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(6, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Kullanıcı Adı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(31, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Telefon";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(37, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Soyad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(54, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Ad";
            // 
            // txtSifre
            // 
            this.txtSifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSifre.Location = new System.Drawing.Point(80, 196);
            this.txtSifre.MaxLength = 8;
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(100, 21);
            this.txtSifre.TabIndex = 4;
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtKullaniciAdi.Location = new System.Drawing.Point(80, 161);
            this.txtKullaniciAdi.MaxLength = 20;
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(100, 21);
            this.txtKullaniciAdi.TabIndex = 3;
            // 
            // txtTelefon
            // 
            this.txtTelefon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTelefon.Location = new System.Drawing.Point(80, 99);
            this.txtTelefon.MaxLength = 12;
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(100, 21);
            this.txtTelefon.TabIndex = 2;
            // 
            // txtSoyad
            // 
            this.txtSoyad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSoyad.Location = new System.Drawing.Point(80, 66);
            this.txtSoyad.MaxLength = 20;
            this.txtSoyad.Name = "txtSoyad";
            this.txtSoyad.Size = new System.Drawing.Size(100, 21);
            this.txtSoyad.TabIndex = 1;
            // 
            // txtAd
            // 
            this.txtAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAd.Location = new System.Drawing.Point(80, 31);
            this.txtAd.MaxLength = 20;
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(100, 21);
            this.txtAd.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(336, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(601, 531);
            this.dataGridView1.TabIndex = 38;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.Image = ((System.Drawing.Image)(resources.GetObject("btnDuzenle.Image")));
            this.btnDuzenle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDuzenle.Location = new System.Drawing.Point(117, 457);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new System.Drawing.Size(99, 40);
            this.btnDuzenle.TabIndex = 40;
            this.btnDuzenle.Text = "DÜZENLE";
            this.btnDuzenle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDuzenle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDuzenle.UseVisualStyleBackColor = true;
            this.btnDuzenle.Click += new System.EventHandler(this.btnDuzenle_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Image = ((System.Drawing.Image)(resources.GetObject("btnKaydet.Image")));
            this.btnKaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKaydet.Location = new System.Drawing.Point(12, 457);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(99, 40);
            this.btnKaydet.TabIndex = 39;
            this.btnKaydet.Text = "  KAYDET";
            this.btnKaydet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKaydet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btn_sil
            // 
            this.btn_sil.Image = ((System.Drawing.Image)(resources.GetObject("btn_sil.Image")));
            this.btn_sil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_sil.Location = new System.Drawing.Point(222, 457);
            this.btn_sil.Name = "btn_sil";
            this.btn_sil.Size = new System.Drawing.Size(86, 40);
            this.btn_sil.TabIndex = 77;
            this.btn_sil.Text = "  SİL";
            this.btn_sil.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_sil.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_sil.UseVisualStyleBackColor = true;
            this.btn_sil.Click += new System.EventHandler(this.btn_sil_Click);
            // 
            // Useradd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 532);
            this.Controls.Add(this.btn_sil);
            this.Controls.Add(this.btnDuzenle);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Useradd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kullanıcı Kayıt";
            this.Load += new System.EventHandler(this.Useradd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_yetki)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkYedekle;
        private System.Windows.Forms.CheckBox chk_Geriyukle;
        private System.Windows.Forms.CheckBox chkKullaniciIslemleri;
        private System.Windows.Forms.CheckBox chk_silinenMusteri;
        private System.Windows.Forms.CheckBox chkMusteriSil;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.TextBox txtSoyad;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDuzenle;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cmbGorev;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label lblmusno;
        private System.Windows.Forms.Label lbltarihSaat;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_sil;
        private System.Windows.Forms.Button btnyeni;
        private System.Windows.Forms.PictureBox picture_yetki;
    }
}