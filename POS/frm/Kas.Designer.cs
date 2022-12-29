namespace POS.frm
{
    partial class Kas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Kas));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlDataTransaksi = new System.Windows.Forms.Panel();
            this.dgTransaksi = new System.Windows.Forms.DataGridView();
            this.clHapus = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clKeterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clNominal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.btnBaru = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnCetak = new System.Windows.Forms.Button();
            this.btnKeluar = new System.Windows.Forms.Button();
            this.pnlInputData = new System.Windows.Forms.Panel();
            this.btnTambahList = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNominal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtKeterangan = new System.Windows.Forms.TextBox();
            this.pnlKiri = new System.Windows.Forms.Panel();
            this.pnlDetailSupplier = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.rbKasMasuk = new System.Windows.Forms.RadioButton();
            this.rbKasKeluar = new System.Windows.Forms.RadioButton();
            this.txtCatatan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.dtTglTransaksi = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlTotalPembelian = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlDataTransaksi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTransaksi)).BeginInit();
            this.pnlButton.SuspendLayout();
            this.pnlInputData.SuspendLayout();
            this.pnlKiri.SuspendLayout();
            this.pnlDetailSupplier.SuspendLayout();
            this.pnlTotalPembelian.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlDataTransaksi);
            this.panel1.Controls.Add(this.pnlButton);
            this.panel1.Controls.Add(this.pnlInputData);
            this.panel1.Controls.Add(this.pnlKiri);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(981, 577);
            this.panel1.TabIndex = 0;
            // 
            // pnlDataTransaksi
            // 
            this.pnlDataTransaksi.Controls.Add(this.dgTransaksi);
            this.pnlDataTransaksi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDataTransaksi.Location = new System.Drawing.Point(418, 102);
            this.pnlDataTransaksi.Name = "pnlDataTransaksi";
            this.pnlDataTransaksi.Size = new System.Drawing.Size(563, 395);
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
            this.clKeterangan,
            this.clNominal});
            this.dgTransaksi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTransaksi.Location = new System.Drawing.Point(0, 0);
            this.dgTransaksi.Name = "dgTransaksi";
            this.dgTransaksi.ShowCellToolTips = false;
            this.dgTransaksi.Size = new System.Drawing.Size(563, 395);
            this.dgTransaksi.TabIndex = 11;
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
            // clKeterangan
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clKeterangan.DefaultCellStyle = dataGridViewCellStyle3;
            this.clKeterangan.HeaderText = "Keterangan";
            this.clKeterangan.Name = "clKeterangan";
            // 
            // clNominal
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clNominal.DefaultCellStyle = dataGridViewCellStyle4;
            this.clNominal.HeaderText = "Nominal";
            this.clNominal.Name = "clNominal";
            this.clNominal.Width = 50;
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnBaru);
            this.pnlButton.Controls.Add(this.btnSimpan);
            this.pnlButton.Controls.Add(this.btnHapus);
            this.pnlButton.Controls.Add(this.btnCetak);
            this.pnlButton.Controls.Add(this.btnKeluar);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButton.Location = new System.Drawing.Point(418, 497);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(563, 80);
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
            this.btnBaru.Location = new System.Drawing.Point(36, 3);
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
            this.btnSimpan.Location = new System.Drawing.Point(142, 3);
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
            this.btnHapus.Location = new System.Drawing.Point(248, 3);
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
            this.btnCetak.Location = new System.Drawing.Point(354, 3);
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
            this.btnKeluar.Location = new System.Drawing.Point(460, 3);
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
            this.pnlInputData.Controls.Add(this.btnTambahList);
            this.pnlInputData.Controls.Add(this.label3);
            this.pnlInputData.Controls.Add(this.txtNominal);
            this.pnlInputData.Controls.Add(this.label8);
            this.pnlInputData.Controls.Add(this.txtKeterangan);
            this.pnlInputData.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInputData.Location = new System.Drawing.Point(418, 0);
            this.pnlInputData.Name = "pnlInputData";
            this.pnlInputData.Size = new System.Drawing.Size(563, 102);
            this.pnlInputData.TabIndex = 7;
            // 
            // btnTambahList
            // 
            this.btnTambahList.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnTambahList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTambahList.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTambahList.ForeColor = System.Drawing.Color.White;
            this.btnTambahList.Location = new System.Drawing.Point(106, 69);
            this.btnTambahList.Name = "btnTambahList";
            this.btnTambahList.Size = new System.Drawing.Size(271, 26);
            this.btnTambahList.TabIndex = 10;
            this.btnTambahList.Text = "Tambah ke List";
            this.btnTambahList.UseVisualStyleBackColor = false;
            this.btnTambahList.Click += new System.EventHandler(this.btnTambahList_Click);
            this.btnTambahList.Leave += new System.EventHandler(this.btnTambahList_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 18);
            this.label3.TabIndex = 44;
            this.label3.Text = "Nominal";
            // 
            // txtNominal
            // 
            this.txtNominal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNominal.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNominal.Location = new System.Drawing.Point(106, 37);
            this.txtNominal.MaxLength = 100;
            this.txtNominal.Name = "txtNominal";
            this.txtNominal.Size = new System.Drawing.Size(271, 26);
            this.txtNominal.TabIndex = 9;
            this.txtNominal.Text = "0.00";
            this.txtNominal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNominal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNominal_KeyPress);
            this.txtNominal.Leave += new System.EventHandler(this.txtNominal_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 18);
            this.label8.TabIndex = 42;
            this.label8.Text = "Keterangan";
            // 
            // txtKeterangan
            // 
            this.txtKeterangan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKeterangan.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKeterangan.Location = new System.Drawing.Point(106, 5);
            this.txtKeterangan.MaxLength = 100;
            this.txtKeterangan.Name = "txtKeterangan";
            this.txtKeterangan.Size = new System.Drawing.Size(271, 26);
            this.txtKeterangan.TabIndex = 8;
            // 
            // pnlKiri
            // 
            this.pnlKiri.Controls.Add(this.pnlDetailSupplier);
            this.pnlKiri.Controls.Add(this.pnlTotalPembelian);
            this.pnlKiri.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlKiri.Location = new System.Drawing.Point(0, 0);
            this.pnlKiri.Name = "pnlKiri";
            this.pnlKiri.Size = new System.Drawing.Size(418, 577);
            this.pnlKiri.TabIndex = 1;
            // 
            // pnlDetailSupplier
            // 
            this.pnlDetailSupplier.Controls.Add(this.label4);
            this.pnlDetailSupplier.Controls.Add(this.rbKasMasuk);
            this.pnlDetailSupplier.Controls.Add(this.rbKasKeluar);
            this.pnlDetailSupplier.Controls.Add(this.txtCatatan);
            this.pnlDetailSupplier.Controls.Add(this.label1);
            this.pnlDetailSupplier.Controls.Add(this.lblID);
            this.pnlDetailSupplier.Controls.Add(this.dtTglTransaksi);
            this.pnlDetailSupplier.Controls.Add(this.label7);
            this.pnlDetailSupplier.Controls.Add(this.label2);
            this.pnlDetailSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetailSupplier.Location = new System.Drawing.Point(0, 0);
            this.pnlDetailSupplier.Name = "pnlDetailSupplier";
            this.pnlDetailSupplier.Size = new System.Drawing.Size(418, 536);
            this.pnlDetailSupplier.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 18);
            this.label4.TabIndex = 42;
            this.label4.Text = "Jenis Kas";
            // 
            // rbKasMasuk
            // 
            this.rbKasMasuk.AutoSize = true;
            this.rbKasMasuk.Checked = true;
            this.rbKasMasuk.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbKasMasuk.Location = new System.Drawing.Point(109, 30);
            this.rbKasMasuk.Name = "rbKasMasuk";
            this.rbKasMasuk.Size = new System.Drawing.Size(104, 24);
            this.rbKasMasuk.TabIndex = 40;
            this.rbKasMasuk.TabStop = true;
            this.rbKasMasuk.Text = "Kas Masuk";
            this.rbKasMasuk.UseVisualStyleBackColor = true;
            // 
            // rbKasKeluar
            // 
            this.rbKasKeluar.AutoSize = true;
            this.rbKasKeluar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbKasKeluar.Location = new System.Drawing.Point(219, 30);
            this.rbKasKeluar.Name = "rbKasKeluar";
            this.rbKasKeluar.Size = new System.Drawing.Size(102, 24);
            this.rbKasKeluar.TabIndex = 41;
            this.rbKasKeluar.Text = "Kas Keluar";
            this.rbKasKeluar.UseVisualStyleBackColor = true;
            // 
            // txtCatatan
            // 
            this.txtCatatan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCatatan.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCatatan.Location = new System.Drawing.Point(109, 92);
            this.txtCatatan.MaxLength = 255;
            this.txtCatatan.Multiline = true;
            this.txtCatatan.Name = "txtCatatan";
            this.txtCatatan.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCatatan.Size = new System.Drawing.Size(302, 76);
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
            this.dtTglTransaksi.Location = new System.Drawing.Point(109, 60);
            this.dtTglTransaksi.Name = "dtTglTransaksi";
            this.dtTglTransaksi.Size = new System.Drawing.Size(149, 26);
            this.dtTglTransaksi.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 18);
            this.label7.TabIndex = 39;
            this.label7.Text = "Catatan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 18);
            this.label2.TabIndex = 34;
            this.label2.Text = "Tgl. Tr.";
            // 
            // pnlTotalPembelian
            // 
            this.pnlTotalPembelian.Controls.Add(this.label12);
            this.pnlTotalPembelian.Controls.Add(this.lblGrandTotal);
            this.pnlTotalPembelian.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTotalPembelian.Location = new System.Drawing.Point(0, 536);
            this.pnlTotalPembelian.Name = "pnlTotalPembelian";
            this.pnlTotalPembelian.Size = new System.Drawing.Size(418, 41);
            this.pnlTotalPembelian.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 18);
            this.label12.TabIndex = 53;
            this.label12.Text = "Grand Total";
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblGrandTotal.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrandTotal.Location = new System.Drawing.Point(154, 3);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(258, 34);
            this.lblGrandTotal.TabIndex = 46;
            this.lblGrandTotal.Text = "0.00";
            this.lblGrandTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Kas
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(981, 577);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Kas";
            this.Text = "Kas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Kas_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Kas_KeyPress);
            this.panel1.ResumeLayout(false);
            this.pnlDataTransaksi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTransaksi)).EndInit();
            this.pnlButton.ResumeLayout(false);
            this.pnlInputData.ResumeLayout(false);
            this.pnlInputData.PerformLayout();
            this.pnlKiri.ResumeLayout(false);
            this.pnlDetailSupplier.ResumeLayout(false);
            this.pnlDetailSupplier.PerformLayout();
            this.pnlTotalPembelian.ResumeLayout(false);
            this.pnlTotalPembelian.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlKiri;
        private System.Windows.Forms.Panel pnlDetailSupplier;
        private System.Windows.Forms.TextBox txtCatatan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.DateTimePicker dtTglTransaksi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlTotalPembelian;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblGrandTotal;
        private System.Windows.Forms.Panel pnlInputData;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtKeterangan;
        private System.Windows.Forms.Panel pnlButton;
        private System.Windows.Forms.Button btnBaru;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnCetak;
        private System.Windows.Forms.Button btnKeluar;
        private System.Windows.Forms.Panel pnlDataTransaksi;
        private System.Windows.Forms.DataGridView dgTransaksi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNominal;
        private System.Windows.Forms.Button btnTambahList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbKasMasuk;
        private System.Windows.Forms.RadioButton rbKasKeluar;
        private System.Windows.Forms.DataGridViewButtonColumn clHapus;
        private System.Windows.Forms.DataGridViewTextBoxColumn clKeterangan;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNominal;
    }
}