namespace POS.frm
{
    partial class Diskon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Diskon));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtCatatan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.dtTglMulai = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtKodeBarcode = new System.Windows.Forms.TextBox();
            this.brnCariBarang = new System.Windows.Forms.Button();
            this.pnlInputData = new System.Windows.Forms.Panel();
            this.btnTambah = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnTerapkan = new System.Windows.Forms.Button();
            this.txtDiskonList = new System.Windows.Forms.TextBox();
            this.rbSemuaBarang = new System.Windows.Forms.RadioButton();
            this.rbKategori = new System.Windows.Forms.RadioButton();
            this.rbBarcode = new System.Windows.Forms.RadioButton();
            this.cboKategori = new POS.cmp.UpperComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.btnBaru = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnCetak = new System.Windows.Forms.Button();
            this.btnKeluar = new System.Windows.Forms.Button();
            this.pnlTransaksi = new System.Windows.Forms.Panel();
            this.txtNamaDisc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtTglSelesai = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.chkAktif = new System.Windows.Forms.CheckBox();
            this.pnlUtama = new System.Windows.Forms.Panel();
            this.pnlDataTransaksi = new System.Windows.Forms.Panel();
            this.dgTransaksi = new System.Windows.Forms.DataGridView();
            this.clHapus = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clNamaBarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clStok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlInputData.SuspendLayout();
            this.pnlButton.SuspendLayout();
            this.pnlTransaksi.SuspendLayout();
            this.pnlUtama.SuspendLayout();
            this.pnlDataTransaksi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTransaksi)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCatatan
            // 
            this.txtCatatan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCatatan.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCatatan.Location = new System.Drawing.Point(107, 165);
            this.txtCatatan.MaxLength = 255;
            this.txtCatatan.Multiline = true;
            this.txtCatatan.Name = "txtCatatan";
            this.txtCatatan.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCatatan.Size = new System.Drawing.Size(280, 76);
            this.txtCatatan.TabIndex = 7;
            this.txtCatatan.Leave += new System.EventHandler(this.txtCatatan_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 18);
            this.label1.TabIndex = 30;
            this.label1.Text = "ID";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(104, 9);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(67, 18);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "AUTO ID";
            this.lblID.TextChanged += new System.EventHandler(this.lblID_TextChanged);
            // 
            // dtTglMulai
            // 
            this.dtTglMulai.CalendarFont = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTglMulai.CustomFormat = "dd - MMM - yyyy";
            this.dtTglMulai.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTglMulai.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTglMulai.Location = new System.Drawing.Point(107, 99);
            this.dtTglMulai.Name = "dtTglMulai";
            this.dtTglMulai.Size = new System.Drawing.Size(149, 26);
            this.dtTglMulai.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 18);
            this.label2.TabIndex = 34;
            this.label2.Text = "Tgl. Mulai";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(124, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 18);
            this.label8.TabIndex = 42;
            this.label8.Text = "Barcode";
            // 
            // txtKodeBarcode
            // 
            this.txtKodeBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKodeBarcode.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKodeBarcode.Location = new System.Drawing.Point(202, 37);
            this.txtKodeBarcode.MaxLength = 100;
            this.txtKodeBarcode.Name = "txtKodeBarcode";
            this.txtKodeBarcode.Size = new System.Drawing.Size(271, 26);
            this.txtKodeBarcode.TabIndex = 8;
            this.txtKodeBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKodeBarcode_KeyDown);
            this.txtKodeBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKodeBarcode_KeyPress);
            // 
            // brnCariBarang
            // 
            this.brnCariBarang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.brnCariBarang.FlatAppearance.BorderSize = 0;
            this.brnCariBarang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.brnCariBarang.Image = ((System.Drawing.Image)(resources.GetObject("brnCariBarang.Image")));
            this.brnCariBarang.Location = new System.Drawing.Point(479, 38);
            this.brnCariBarang.Name = "brnCariBarang";
            this.brnCariBarang.Size = new System.Drawing.Size(25, 25);
            this.brnCariBarang.TabIndex = 1000;
            this.brnCariBarang.UseVisualStyleBackColor = true;
            this.brnCariBarang.Click += new System.EventHandler(this.brnCariBarang_Click);
            this.brnCariBarang.Leave += new System.EventHandler(this.brnCariBarang_Leave);
            // 
            // pnlInputData
            // 
            this.pnlInputData.Controls.Add(this.btnTambah);
            this.pnlInputData.Controls.Add(this.label9);
            this.pnlInputData.Controls.Add(this.label6);
            this.pnlInputData.Controls.Add(this.btnTerapkan);
            this.pnlInputData.Controls.Add(this.txtDiskonList);
            this.pnlInputData.Controls.Add(this.rbSemuaBarang);
            this.pnlInputData.Controls.Add(this.rbKategori);
            this.pnlInputData.Controls.Add(this.rbBarcode);
            this.pnlInputData.Controls.Add(this.cboKategori);
            this.pnlInputData.Controls.Add(this.label5);
            this.pnlInputData.Controls.Add(this.label8);
            this.pnlInputData.Controls.Add(this.txtKodeBarcode);
            this.pnlInputData.Controls.Add(this.brnCariBarang);
            this.pnlInputData.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInputData.Location = new System.Drawing.Point(396, 0);
            this.pnlInputData.Name = "pnlInputData";
            this.pnlInputData.Size = new System.Drawing.Size(638, 241);
            this.pnlInputData.TabIndex = 8;
            // 
            // btnTambah
            // 
            this.btnTambah.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTambah.Location = new System.Drawing.Point(9, 100);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(495, 23);
            this.btnTambah.TabIndex = 1010;
            this.btnTambah.Text = "TAMBAHKAN KE LIST";
            this.btnTambah.UseVisualStyleBackColor = true;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(78, 182);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 18);
            this.label9.TabIndex = 1009;
            this.label9.Text = "%";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(427, 18);
            this.label6.TabIndex = 1008;
            this.label6.Text = "Tetapkan Besaran Diskon Untuk Semua Barang Dalam List";
            // 
            // btnTerapkan
            // 
            this.btnTerapkan.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTerapkan.Location = new System.Drawing.Point(9, 210);
            this.btnTerapkan.Name = "btnTerapkan";
            this.btnTerapkan.Size = new System.Drawing.Size(202, 23);
            this.btnTerapkan.TabIndex = 1007;
            this.btnTerapkan.Text = "TERAPKAN KE SEMUA BARANG";
            this.btnTerapkan.UseVisualStyleBackColor = true;
            this.btnTerapkan.Click += new System.EventHandler(this.btnTerapkan_Click);
            // 
            // txtDiskonList
            // 
            this.txtDiskonList.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDiskonList.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiskonList.Location = new System.Drawing.Point(9, 178);
            this.txtDiskonList.MaxLength = 100;
            this.txtDiskonList.Name = "txtDiskonList";
            this.txtDiskonList.Size = new System.Drawing.Size(63, 26);
            this.txtDiskonList.TabIndex = 1006;
            this.txtDiskonList.Text = "0.00";
            this.txtDiskonList.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDiskonList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiskonList_KeyPress);
            this.txtDiskonList.Leave += new System.EventHandler(this.txtDiskonList_Leave);
            // 
            // rbSemuaBarang
            // 
            this.rbSemuaBarang.AutoSize = true;
            this.rbSemuaBarang.Location = new System.Drawing.Point(9, 5);
            this.rbSemuaBarang.Name = "rbSemuaBarang";
            this.rbSemuaBarang.Size = new System.Drawing.Size(112, 21);
            this.rbSemuaBarang.TabIndex = 1005;
            this.rbSemuaBarang.TabStop = true;
            this.rbSemuaBarang.Text = "Semua Barang";
            this.rbSemuaBarang.UseVisualStyleBackColor = true;
            // 
            // rbKategori
            // 
            this.rbKategori.AutoSize = true;
            this.rbKategori.Location = new System.Drawing.Point(9, 73);
            this.rbKategori.Name = "rbKategori";
            this.rbKategori.Size = new System.Drawing.Size(99, 21);
            this.rbKategori.TabIndex = 1004;
            this.rbKategori.TabStop = true;
            this.rbKategori.Text = "Per Kategori";
            this.rbKategori.UseVisualStyleBackColor = true;
            // 
            // rbBarcode
            // 
            this.rbBarcode.AutoSize = true;
            this.rbBarcode.Location = new System.Drawing.Point(9, 38);
            this.rbBarcode.Name = "rbBarcode";
            this.rbBarcode.Size = new System.Drawing.Size(90, 21);
            this.rbBarcode.TabIndex = 1003;
            this.rbBarcode.TabStop = true;
            this.rbBarcode.Text = "Per Barang";
            this.rbBarcode.UseVisualStyleBackColor = true;
            // 
            // cboKategori
            // 
            this.cboKategori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKategori.FormattingEnabled = true;
            this.cboKategori.Location = new System.Drawing.Point(202, 69);
            this.cboKategori.Name = "cboKategori";
            this.cboKategori.Size = new System.Drawing.Size(302, 25);
            this.cboKategori.TabIndex = 1002;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(124, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 18);
            this.label5.TabIndex = 1001;
            this.label5.Text = "Kategori";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 18);
            this.label7.TabIndex = 39;
            this.label7.Text = "Catatan";
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnBaru);
            this.pnlButton.Controls.Add(this.btnSimpan);
            this.pnlButton.Controls.Add(this.btnHapus);
            this.pnlButton.Controls.Add(this.btnCetak);
            this.pnlButton.Controls.Add(this.btnKeluar);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButton.Location = new System.Drawing.Point(396, 473);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(638, 80);
            this.pnlButton.TabIndex = 9;
            // 
            // btnBaru
            // 
            this.btnBaru.AccessibleName = "BARU";
            this.btnBaru.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBaru.BackColor = System.Drawing.Color.White;
            this.btnBaru.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBaru.FlatAppearance.BorderSize = 0;
            this.btnBaru.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaru.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaru.ForeColor = System.Drawing.Color.Black;
            this.btnBaru.Image = ((System.Drawing.Image)(resources.GetObject("btnBaru.Image")));
            this.btnBaru.Location = new System.Drawing.Point(111, 3);
            this.btnBaru.Name = "btnBaru";
            this.btnBaru.Size = new System.Drawing.Size(100, 75);
            this.btnBaru.TabIndex = 18;
            this.btnBaru.Text = "BARU-F2";
            this.btnBaru.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBaru.UseVisualStyleBackColor = false;
            this.btnBaru.Click += new System.EventHandler(this.btnBaru_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.AccessibleName = "SIMPAN";
            this.btnSimpan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSimpan.BackColor = System.Drawing.Color.White;
            this.btnSimpan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSimpan.Enabled = false;
            this.btnSimpan.FlatAppearance.BorderSize = 0;
            this.btnSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimpan.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimpan.ForeColor = System.Drawing.Color.Black;
            this.btnSimpan.Image = ((System.Drawing.Image)(resources.GetObject("btnSimpan.Image")));
            this.btnSimpan.Location = new System.Drawing.Point(217, 3);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(100, 75);
            this.btnSimpan.TabIndex = 17;
            this.btnSimpan.Text = "SIMPAN-F3";
            this.btnSimpan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSimpan.UseVisualStyleBackColor = false;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.AccessibleName = "HAPUS";
            this.btnHapus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHapus.BackColor = System.Drawing.Color.White;
            this.btnHapus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHapus.Enabled = false;
            this.btnHapus.FlatAppearance.BorderSize = 0;
            this.btnHapus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHapus.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHapus.ForeColor = System.Drawing.Color.Black;
            this.btnHapus.Image = ((System.Drawing.Image)(resources.GetObject("btnHapus.Image")));
            this.btnHapus.Location = new System.Drawing.Point(323, 3);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(100, 75);
            this.btnHapus.TabIndex = 16;
            this.btnHapus.Text = "HAPUS-F4";
            this.btnHapus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnHapus.UseVisualStyleBackColor = false;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnCetak
            // 
            this.btnCetak.AccessibleName = "CETAK";
            this.btnCetak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCetak.BackColor = System.Drawing.Color.White;
            this.btnCetak.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCetak.Enabled = false;
            this.btnCetak.FlatAppearance.BorderSize = 0;
            this.btnCetak.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCetak.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCetak.ForeColor = System.Drawing.Color.Black;
            this.btnCetak.Image = ((System.Drawing.Image)(resources.GetObject("btnCetak.Image")));
            this.btnCetak.Location = new System.Drawing.Point(429, 3);
            this.btnCetak.Name = "btnCetak";
            this.btnCetak.Size = new System.Drawing.Size(100, 75);
            this.btnCetak.TabIndex = 15;
            this.btnCetak.Text = "CETAK-F12";
            this.btnCetak.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCetak.UseVisualStyleBackColor = false;
            this.btnCetak.Click += new System.EventHandler(this.btnCetak_Click);
            // 
            // btnKeluar
            // 
            this.btnKeluar.AccessibleName = "KELUAR";
            this.btnKeluar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKeluar.BackColor = System.Drawing.Color.White;
            this.btnKeluar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKeluar.FlatAppearance.BorderSize = 0;
            this.btnKeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeluar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeluar.ForeColor = System.Drawing.Color.Black;
            this.btnKeluar.Image = ((System.Drawing.Image)(resources.GetObject("btnKeluar.Image")));
            this.btnKeluar.Location = new System.Drawing.Point(535, 3);
            this.btnKeluar.Name = "btnKeluar";
            this.btnKeluar.Size = new System.Drawing.Size(100, 75);
            this.btnKeluar.TabIndex = 14;
            this.btnKeluar.Text = "KELUAR-F10";
            this.btnKeluar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnKeluar.UseVisualStyleBackColor = false;
            this.btnKeluar.Click += new System.EventHandler(this.btnKeluar_Click);
            // 
            // pnlTransaksi
            // 
            this.pnlTransaksi.Controls.Add(this.txtNamaDisc);
            this.pnlTransaksi.Controls.Add(this.label3);
            this.pnlTransaksi.Controls.Add(this.dtTglSelesai);
            this.pnlTransaksi.Controls.Add(this.label4);
            this.pnlTransaksi.Controls.Add(this.chkAktif);
            this.pnlTransaksi.Controls.Add(this.txtCatatan);
            this.pnlTransaksi.Controls.Add(this.label1);
            this.pnlTransaksi.Controls.Add(this.lblID);
            this.pnlTransaksi.Controls.Add(this.dtTglMulai);
            this.pnlTransaksi.Controls.Add(this.label7);
            this.pnlTransaksi.Controls.Add(this.label2);
            this.pnlTransaksi.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTransaksi.Location = new System.Drawing.Point(0, 0);
            this.pnlTransaksi.Name = "pnlTransaksi";
            this.pnlTransaksi.Size = new System.Drawing.Size(396, 553);
            this.pnlTransaksi.TabIndex = 7;
            // 
            // txtNamaDisc
            // 
            this.txtNamaDisc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNamaDisc.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNamaDisc.Location = new System.Drawing.Point(107, 67);
            this.txtNamaDisc.MaxLength = 100;
            this.txtNamaDisc.Name = "txtNamaDisc";
            this.txtNamaDisc.Size = new System.Drawing.Size(280, 26);
            this.txtNamaDisc.TabIndex = 46;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 18);
            this.label3.TabIndex = 45;
            this.label3.Text = "Nama Disc";
            // 
            // dtTglSelesai
            // 
            this.dtTglSelesai.CalendarFont = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTglSelesai.CustomFormat = "dd - MMM - yyyy";
            this.dtTglSelesai.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTglSelesai.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTglSelesai.Location = new System.Drawing.Point(107, 131);
            this.dtTglSelesai.Name = "dtTglSelesai";
            this.dtTglSelesai.Size = new System.Drawing.Size(149, 26);
            this.dtTglSelesai.TabIndex = 43;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 18);
            this.label4.TabIndex = 44;
            this.label4.Text = "Tgl. Selesai";
            // 
            // chkAktif
            // 
            this.chkAktif.AutoSize = true;
            this.chkAktif.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAktif.Location = new System.Drawing.Point(107, 39);
            this.chkAktif.Name = "chkAktif";
            this.chkAktif.Size = new System.Drawing.Size(140, 22);
            this.chkAktif.TabIndex = 42;
            this.chkAktif.Text = "Aktifkan Diskon";
            this.chkAktif.UseVisualStyleBackColor = true;
            // 
            // pnlUtama
            // 
            this.pnlUtama.Controls.Add(this.pnlDataTransaksi);
            this.pnlUtama.Controls.Add(this.pnlButton);
            this.pnlUtama.Controls.Add(this.pnlInputData);
            this.pnlUtama.Controls.Add(this.pnlTransaksi);
            this.pnlUtama.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUtama.Location = new System.Drawing.Point(0, 0);
            this.pnlUtama.Name = "pnlUtama";
            this.pnlUtama.Size = new System.Drawing.Size(1034, 553);
            this.pnlUtama.TabIndex = 1;
            // 
            // pnlDataTransaksi
            // 
            this.pnlDataTransaksi.Controls.Add(this.dgTransaksi);
            this.pnlDataTransaksi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDataTransaksi.Location = new System.Drawing.Point(396, 241);
            this.pnlDataTransaksi.Name = "pnlDataTransaksi";
            this.pnlDataTransaksi.Size = new System.Drawing.Size(638, 232);
            this.pnlDataTransaksi.TabIndex = 10;
            // 
            // dgTransaksi
            // 
            this.dgTransaksi.AllowUserToAddRows = false;
            this.dgTransaksi.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgTransaksi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgTransaksi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTransaksi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clHapus,
            this.clBarcode,
            this.clNamaBarang,
            this.clStok,
            this.clQty});
            this.dgTransaksi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTransaksi.Location = new System.Drawing.Point(0, 0);
            this.dgTransaksi.Name = "dgTransaksi";
            this.dgTransaksi.ShowCellToolTips = false;
            this.dgTransaksi.Size = new System.Drawing.Size(638, 232);
            this.dgTransaksi.TabIndex = 9;
            this.dgTransaksi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTransaksi_CellClick);
            this.dgTransaksi.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTransaksi_CellEndEdit);
            this.dgTransaksi.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgTransaksi_EditingControlShowing);
            this.dgTransaksi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgTransaksi_KeyPress);
            this.dgTransaksi.Leave += new System.EventHandler(this.dgTransaksi_Leave);
            // 
            // clHapus
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.IndianRed;
            this.clHapus.DefaultCellStyle = dataGridViewCellStyle2;
            this.clHapus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clHapus.Frozen = true;
            this.clHapus.HeaderText = "";
            this.clHapus.Name = "clHapus";
            this.clHapus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clHapus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clHapus.Text = "X";
            this.clHapus.Width = 40;
            // 
            // clBarcode
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clBarcode.DefaultCellStyle = dataGridViewCellStyle3;
            this.clBarcode.HeaderText = "Barcode";
            this.clBarcode.Name = "clBarcode";
            this.clBarcode.ReadOnly = true;
            // 
            // clNamaBarang
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clNamaBarang.DefaultCellStyle = dataGridViewCellStyle4;
            this.clNamaBarang.HeaderText = "Nama";
            this.clNamaBarang.Name = "clNamaBarang";
            this.clNamaBarang.ReadOnly = true;
            // 
            // clStok
            // 
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clStok.DefaultCellStyle = dataGridViewCellStyle5;
            this.clStok.HeaderText = "Diskon (%)";
            this.clStok.Name = "clStok";
            // 
            // clQty
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clQty.DefaultCellStyle = dataGridViewCellStyle6;
            this.clQty.HeaderText = "Diskon (Rp)";
            this.clQty.Name = "clQty";
            this.clQty.Visible = false;
            this.clQty.Width = 50;
            // 
            // Diskon
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1034, 553);
            this.Controls.Add(this.pnlUtama);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Diskon";
            this.Text = "Diskon";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Diskon_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Diskon_KeyPress);
            this.pnlInputData.ResumeLayout(false);
            this.pnlInputData.PerformLayout();
            this.pnlButton.ResumeLayout(false);
            this.pnlTransaksi.ResumeLayout(false);
            this.pnlTransaksi.PerformLayout();
            this.pnlUtama.ResumeLayout(false);
            this.pnlDataTransaksi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTransaksi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtCatatan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.DateTimePicker dtTglMulai;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtKodeBarcode;
        private System.Windows.Forms.Button brnCariBarang;
        private System.Windows.Forms.Panel pnlInputData;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnlButton;
        private System.Windows.Forms.Button btnBaru;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnCetak;
        private System.Windows.Forms.Button btnKeluar;
        private System.Windows.Forms.Panel pnlTransaksi;
        private System.Windows.Forms.Panel pnlUtama;
        private System.Windows.Forms.Panel pnlDataTransaksi;
        private System.Windows.Forms.DataGridView dgTransaksi;
        private System.Windows.Forms.CheckBox chkAktif;
        private System.Windows.Forms.DateTimePicker dtTglSelesai;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNamaDisc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDiskonList;
        private System.Windows.Forms.RadioButton rbSemuaBarang;
        private System.Windows.Forms.RadioButton rbKategori;
        private System.Windows.Forms.RadioButton rbBarcode;
        private cmp.UpperComboBox cboKategori;
        private System.Windows.Forms.Button btnTerapkan;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.DataGridViewButtonColumn clHapus;
        private System.Windows.Forms.DataGridViewTextBoxColumn clBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNamaBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn clStok;
        private System.Windows.Forms.DataGridViewTextBoxColumn clQty;
    }
}