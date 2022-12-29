namespace POS.frm
{
    partial class Penyesuaian
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Penyesuaian));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgTransaksi = new System.Windows.Forms.DataGridView();
            this.pnlUtama = new System.Windows.Forms.Panel();
            this.pnlKanan = new System.Windows.Forms.Panel();
            this.pnlDataTransaksi = new System.Windows.Forms.Panel();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.btnBaru = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnCetak = new System.Windows.Forms.Button();
            this.btnKeluar = new System.Windows.Forms.Button();
            this.pnlInputData = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtKodeBarcode = new System.Windows.Forms.TextBox();
            this.brnCariBarang = new System.Windows.Forms.Button();
            this.pnlKiri = new System.Windows.Forms.Panel();
            this.pnlDetailSupplier = new System.Windows.Forms.Panel();
            this.txtCatatan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.dtTglTransaksi = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.clHapus = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clNamaBarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clStok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clNilaiStok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSelisih = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSatuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clNilaiBarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgTransaksi)).BeginInit();
            this.pnlUtama.SuspendLayout();
            this.pnlKanan.SuspendLayout();
            this.pnlDataTransaksi.SuspendLayout();
            this.pnlButton.SuspendLayout();
            this.pnlInputData.SuspendLayout();
            this.pnlKiri.SuspendLayout();
            this.pnlDetailSupplier.SuspendLayout();
            this.SuspendLayout();
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
            this.clNilaiStok,
            this.clQty,
            this.clSelisih,
            this.clSatuan,
            this.clNilaiBarang,
            this.clSubTotal});
            this.dgTransaksi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTransaksi.Location = new System.Drawing.Point(0, 0);
            this.dgTransaksi.Name = "dgTransaksi";
            this.dgTransaksi.ShowCellToolTips = false;
            this.dgTransaksi.Size = new System.Drawing.Size(634, 455);
            this.dgTransaksi.TabIndex = 9;
            this.dgTransaksi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTransaksi_CellClick);
            this.dgTransaksi.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTransaksi_CellEndEdit);
            this.dgTransaksi.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgTransaksi_EditingControlShowing);
            this.dgTransaksi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgTransaksi_KeyPress);
            // 
            // pnlUtama
            // 
            this.pnlUtama.Controls.Add(this.pnlKanan);
            this.pnlUtama.Controls.Add(this.pnlKiri);
            this.pnlUtama.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUtama.Location = new System.Drawing.Point(0, 0);
            this.pnlUtama.Name = "pnlUtama";
            this.pnlUtama.Size = new System.Drawing.Size(1052, 576);
            this.pnlUtama.TabIndex = 2;
            // 
            // pnlKanan
            // 
            this.pnlKanan.Controls.Add(this.pnlDataTransaksi);
            this.pnlKanan.Controls.Add(this.pnlButton);
            this.pnlKanan.Controls.Add(this.pnlInputData);
            this.pnlKanan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKanan.Location = new System.Drawing.Point(418, 0);
            this.pnlKanan.Name = "pnlKanan";
            this.pnlKanan.Size = new System.Drawing.Size(634, 576);
            this.pnlKanan.TabIndex = 1;
            // 
            // pnlDataTransaksi
            // 
            this.pnlDataTransaksi.Controls.Add(this.dgTransaksi);
            this.pnlDataTransaksi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDataTransaksi.Location = new System.Drawing.Point(0, 41);
            this.pnlDataTransaksi.Name = "pnlDataTransaksi";
            this.pnlDataTransaksi.Size = new System.Drawing.Size(634, 455);
            this.pnlDataTransaksi.TabIndex = 8;
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnBaru);
            this.pnlButton.Controls.Add(this.btnSimpan);
            this.pnlButton.Controls.Add(this.btnHapus);
            this.pnlButton.Controls.Add(this.btnCetak);
            this.pnlButton.Controls.Add(this.btnKeluar);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButton.Location = new System.Drawing.Point(0, 496);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(634, 80);
            this.pnlButton.TabIndex = 7;
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
            this.btnBaru.Location = new System.Drawing.Point(107, 3);
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
            this.btnSimpan.Location = new System.Drawing.Point(213, 3);
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
            this.btnHapus.Location = new System.Drawing.Point(319, 3);
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
            this.btnCetak.Location = new System.Drawing.Point(425, 3);
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
            this.btnKeluar.Location = new System.Drawing.Point(531, 3);
            this.btnKeluar.Name = "btnKeluar";
            this.btnKeluar.Size = new System.Drawing.Size(100, 75);
            this.btnKeluar.TabIndex = 14;
            this.btnKeluar.Text = "KELUAR-F10";
            this.btnKeluar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnKeluar.UseVisualStyleBackColor = false;
            this.btnKeluar.Click += new System.EventHandler(this.btnKeluar_Click);
            // 
            // pnlInputData
            // 
            this.pnlInputData.Controls.Add(this.label8);
            this.pnlInputData.Controls.Add(this.txtKodeBarcode);
            this.pnlInputData.Controls.Add(this.brnCariBarang);
            this.pnlInputData.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInputData.Location = new System.Drawing.Point(0, 0);
            this.pnlInputData.Name = "pnlInputData";
            this.pnlInputData.Size = new System.Drawing.Size(634, 41);
            this.pnlInputData.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 18);
            this.label8.TabIndex = 42;
            this.label8.Text = "Barcode";
            // 
            // txtKodeBarcode
            // 
            this.txtKodeBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKodeBarcode.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKodeBarcode.Location = new System.Drawing.Point(92, 5);
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
            this.brnCariBarang.Location = new System.Drawing.Point(369, 6);
            this.brnCariBarang.Name = "brnCariBarang";
            this.brnCariBarang.Size = new System.Drawing.Size(25, 25);
            this.brnCariBarang.TabIndex = 1000;
            this.brnCariBarang.UseVisualStyleBackColor = true;
            this.brnCariBarang.Click += new System.EventHandler(this.brnCariBarang_Click);
            // 
            // pnlKiri
            // 
            this.pnlKiri.Controls.Add(this.pnlDetailSupplier);
            this.pnlKiri.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlKiri.Location = new System.Drawing.Point(0, 0);
            this.pnlKiri.Name = "pnlKiri";
            this.pnlKiri.Size = new System.Drawing.Size(418, 576);
            this.pnlKiri.TabIndex = 0;
            // 
            // pnlDetailSupplier
            // 
            this.pnlDetailSupplier.Controls.Add(this.txtCatatan);
            this.pnlDetailSupplier.Controls.Add(this.label1);
            this.pnlDetailSupplier.Controls.Add(this.lblID);
            this.pnlDetailSupplier.Controls.Add(this.dtTglTransaksi);
            this.pnlDetailSupplier.Controls.Add(this.label7);
            this.pnlDetailSupplier.Controls.Add(this.label2);
            this.pnlDetailSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetailSupplier.Location = new System.Drawing.Point(0, 0);
            this.pnlDetailSupplier.Name = "pnlDetailSupplier";
            this.pnlDetailSupplier.Size = new System.Drawing.Size(418, 576);
            this.pnlDetailSupplier.TabIndex = 5;
            // 
            // txtCatatan
            // 
            this.txtCatatan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCatatan.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCatatan.Location = new System.Drawing.Point(109, 62);
            this.txtCatatan.MaxLength = 255;
            this.txtCatatan.Multiline = true;
            this.txtCatatan.Name = "txtCatatan";
            this.txtCatatan.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCatatan.Size = new System.Drawing.Size(302, 76);
            this.txtCatatan.TabIndex = 5;
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
            this.lblID.Location = new System.Drawing.Point(106, 9);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(67, 18);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "AUTO ID";
            this.lblID.TextChanged += new System.EventHandler(this.lblID_TextChanged);
            // 
            // dtTglTransaksi
            // 
            this.dtTglTransaksi.CalendarFont = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTglTransaksi.CustomFormat = "dd - MMM - yyyy";
            this.dtTglTransaksi.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTglTransaksi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTglTransaksi.Location = new System.Drawing.Point(109, 30);
            this.dtTglTransaksi.Name = "dtTglTransaksi";
            this.dtTglTransaksi.Size = new System.Drawing.Size(149, 26);
            this.dtTglTransaksi.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 18);
            this.label7.TabIndex = 39;
            this.label7.Text = "Catatan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 18);
            this.label2.TabIndex = 34;
            this.label2.Text = "Tgl. Tr.";
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
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clBarcode.DefaultCellStyle = dataGridViewCellStyle3;
            this.clBarcode.HeaderText = "Barcode";
            this.clBarcode.Name = "clBarcode";
            this.clBarcode.ReadOnly = true;
            // 
            // clNamaBarang
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clNamaBarang.DefaultCellStyle = dataGridViewCellStyle4;
            this.clNamaBarang.HeaderText = "Nama";
            this.clNamaBarang.Name = "clNamaBarang";
            this.clNamaBarang.ReadOnly = true;
            // 
            // clStok
            // 
            this.clStok.HeaderText = "Stok";
            this.clStok.Name = "clStok";
            this.clStok.ReadOnly = true;
            // 
            // clNilaiStok
            // 
            this.clNilaiStok.HeaderText = "Nilai Stok";
            this.clNilaiStok.Name = "clNilaiStok";
            // 
            // clQty
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clQty.DefaultCellStyle = dataGridViewCellStyle5;
            this.clQty.HeaderText = "Penyesuaian";
            this.clQty.Name = "clQty";
            // 
            // clSelisih
            // 
            this.clSelisih.HeaderText = "Selisih";
            this.clSelisih.Name = "clSelisih";
            this.clSelisih.ReadOnly = true;
            // 
            // clSatuan
            // 
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clSatuan.DefaultCellStyle = dataGridViewCellStyle6;
            this.clSatuan.HeaderText = "Satuan";
            this.clSatuan.Name = "clSatuan";
            this.clSatuan.ReadOnly = true;
            this.clSatuan.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clSatuan.Width = 70;
            // 
            // clNilaiBarang
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clNilaiBarang.DefaultCellStyle = dataGridViewCellStyle7;
            this.clNilaiBarang.HeaderText = "Nilai Barang";
            this.clNilaiBarang.Name = "clNilaiBarang";
            this.clNilaiBarang.ReadOnly = true;
            // 
            // clSubTotal
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clSubTotal.DefaultCellStyle = dataGridViewCellStyle8;
            this.clSubTotal.HeaderText = "Sub. Nilai Barang";
            this.clSubTotal.Name = "clSubTotal";
            this.clSubTotal.ReadOnly = true;
            // 
            // Penyesuaian
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1052, 576);
            this.Controls.Add(this.pnlUtama);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Penyesuaian";
            this.Text = "Penyesuaian";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Penyesuaian_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Penyesuaian_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dgTransaksi)).EndInit();
            this.pnlUtama.ResumeLayout(false);
            this.pnlKanan.ResumeLayout(false);
            this.pnlDataTransaksi.ResumeLayout(false);
            this.pnlButton.ResumeLayout(false);
            this.pnlInputData.ResumeLayout(false);
            this.pnlInputData.PerformLayout();
            this.pnlKiri.ResumeLayout(false);
            this.pnlDetailSupplier.ResumeLayout(false);
            this.pnlDetailSupplier.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgTransaksi;
        private System.Windows.Forms.Panel pnlUtama;
        private System.Windows.Forms.Panel pnlKanan;
        private System.Windows.Forms.Panel pnlDataTransaksi;
        private System.Windows.Forms.Panel pnlButton;
        private System.Windows.Forms.Button btnBaru;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnCetak;
        private System.Windows.Forms.Button btnKeluar;
        private System.Windows.Forms.Panel pnlInputData;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtKodeBarcode;
        private System.Windows.Forms.Button brnCariBarang;
        private System.Windows.Forms.Panel pnlKiri;
        private System.Windows.Forms.Panel pnlDetailSupplier;
        private System.Windows.Forms.TextBox txtCatatan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.DateTimePicker dtTglTransaksi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewButtonColumn clHapus;
        private System.Windows.Forms.DataGridViewTextBoxColumn clBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNamaBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn clStok;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNilaiStok;
        private System.Windows.Forms.DataGridViewTextBoxColumn clQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSelisih;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSatuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNilaiBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSubTotal;
    }
}