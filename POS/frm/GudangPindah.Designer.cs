namespace POS.frm
{
    partial class GudangPindah
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GudangPindah));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlUtama = new System.Windows.Forms.Panel();
            this.pnlDataTransaksi = new System.Windows.Forms.Panel();
            this.pnlComboBox = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnHidePanel = new System.Windows.Forms.Button();
            this.cboSatuan = new POS.cmp.UpperComboBox();
            this.dgTransaksi = new System.Windows.Forms.DataGridView();
            this.clHapus = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clNamaBarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clStok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSatuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clQty1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.btnBaru = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnCetak = new System.Windows.Forms.Button();
            this.btnKeluar = new System.Windows.Forms.Button();
            this.pnlInputData = new System.Windows.Forms.Panel();
            this.chkTerimaSemuaBarang = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtKodeBarcode = new System.Windows.Forms.TextBox();
            this.brnCariBarang = new System.Windows.Forms.Button();
            this.pnlTransaksi = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIDGudang = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboLokasi = new POS.cmp.UpperComboBox();
            this.txtCatatan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.dtTglTransaksi = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rbNotaGudang = new System.Windows.Forms.RadioButton();
            this.rbBarang = new System.Windows.Forms.RadioButton();
            this.btnCariIDGudang = new System.Windows.Forms.Button();
            this.pnlUtama.SuspendLayout();
            this.pnlDataTransaksi.SuspendLayout();
            this.pnlComboBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTransaksi)).BeginInit();
            this.pnlButton.SuspendLayout();
            this.pnlInputData.SuspendLayout();
            this.pnlTransaksi.SuspendLayout();
            this.SuspendLayout();
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
            this.pnlUtama.Size = new System.Drawing.Size(1072, 563);
            this.pnlUtama.TabIndex = 0;
            // 
            // pnlDataTransaksi
            // 
            this.pnlDataTransaksi.Controls.Add(this.pnlComboBox);
            this.pnlDataTransaksi.Controls.Add(this.dgTransaksi);
            this.pnlDataTransaksi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDataTransaksi.Location = new System.Drawing.Point(396, 153);
            this.pnlDataTransaksi.Name = "pnlDataTransaksi";
            this.pnlDataTransaksi.Size = new System.Drawing.Size(676, 330);
            this.pnlDataTransaksi.TabIndex = 10;
            // 
            // pnlComboBox
            // 
            this.pnlComboBox.BackColor = System.Drawing.Color.Transparent;
            this.pnlComboBox.Controls.Add(this.btnOK);
            this.pnlComboBox.Controls.Add(this.btnHidePanel);
            this.pnlComboBox.Controls.Add(this.cboSatuan);
            this.pnlComboBox.Location = new System.Drawing.Point(3, 41);
            this.pnlComboBox.Name = "pnlComboBox";
            this.pnlComboBox.Size = new System.Drawing.Size(143, 88);
            this.pnlComboBox.TabIndex = 10;
            this.pnlComboBox.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(3, 62);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(119, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnHidePanel
            // 
            this.btnHidePanel.BackColor = System.Drawing.Color.Transparent;
            this.btnHidePanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHidePanel.BackgroundImage")));
            this.btnHidePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHidePanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHidePanel.FlatAppearance.BorderSize = 0;
            this.btnHidePanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHidePanel.Location = new System.Drawing.Point(116, 3);
            this.btnHidePanel.Name = "btnHidePanel";
            this.btnHidePanel.Size = new System.Drawing.Size(24, 25);
            this.btnHidePanel.TabIndex = 3;
            this.btnHidePanel.UseVisualStyleBackColor = false;
            this.btnHidePanel.Click += new System.EventHandler(this.btnHidePanel_Click);
            // 
            // cboSatuan
            // 
            this.cboSatuan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSatuan.FormattingEnabled = true;
            this.cboSatuan.Location = new System.Drawing.Point(3, 34);
            this.cboSatuan.Name = "cboSatuan";
            this.cboSatuan.Size = new System.Drawing.Size(119, 25);
            this.cboSatuan.TabIndex = 2;
            // 
            // dgTransaksi
            // 
            this.dgTransaksi.AllowUserToAddRows = false;
            this.dgTransaksi.AllowUserToDeleteRows = false;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgTransaksi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dgTransaksi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTransaksi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clHapus,
            this.clBarcode,
            this.clNamaBarang,
            this.clStok,
            this.clQty,
            this.clSatuan,
            this.clQty1});
            this.dgTransaksi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTransaksi.Location = new System.Drawing.Point(0, 0);
            this.dgTransaksi.Name = "dgTransaksi";
            this.dgTransaksi.ShowCellToolTips = false;
            this.dgTransaksi.Size = new System.Drawing.Size(676, 330);
            this.dgTransaksi.TabIndex = 9;
            this.dgTransaksi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTransaksi_CellClick);
            this.dgTransaksi.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTransaksi_CellEndEdit);
            this.dgTransaksi.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgTransaksi_EditingControlShowing);
            this.dgTransaksi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgTransaksi_KeyPress);
            this.dgTransaksi.Leave += new System.EventHandler(this.dgTransaksi_Leave);
            // 
            // clHapus
            // 
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.IndianRed;
            this.clHapus.DefaultCellStyle = dataGridViewCellStyle23;
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
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clBarcode.DefaultCellStyle = dataGridViewCellStyle24;
            this.clBarcode.HeaderText = "Barcode";
            this.clBarcode.Name = "clBarcode";
            this.clBarcode.ReadOnly = true;
            // 
            // clNamaBarang
            // 
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clNamaBarang.DefaultCellStyle = dataGridViewCellStyle25;
            this.clNamaBarang.HeaderText = "Nama";
            this.clNamaBarang.Name = "clNamaBarang";
            this.clNamaBarang.ReadOnly = true;
            // 
            // clStok
            // 
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clStok.DefaultCellStyle = dataGridViewCellStyle26;
            this.clStok.HeaderText = "Stok Gudang";
            this.clStok.Name = "clStok";
            this.clStok.ReadOnly = true;
            // 
            // clQty
            // 
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clQty.DefaultCellStyle = dataGridViewCellStyle27;
            this.clQty.HeaderText = "Qty";
            this.clQty.Name = "clQty";
            this.clQty.Width = 50;
            // 
            // clSatuan
            // 
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clSatuan.DefaultCellStyle = dataGridViewCellStyle28;
            this.clSatuan.HeaderText = "Satuan";
            this.clSatuan.Name = "clSatuan";
            this.clSatuan.ReadOnly = true;
            this.clSatuan.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clSatuan.Width = 70;
            // 
            // clQty1
            // 
            this.clQty1.HeaderText = "Qty1";
            this.clQty1.Name = "clQty1";
            this.clQty1.ReadOnly = true;
            this.clQty1.Visible = false;
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnBaru);
            this.pnlButton.Controls.Add(this.btnSimpan);
            this.pnlButton.Controls.Add(this.btnHapus);
            this.pnlButton.Controls.Add(this.btnCetak);
            this.pnlButton.Controls.Add(this.btnKeluar);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButton.Location = new System.Drawing.Point(396, 483);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(676, 80);
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
            this.btnBaru.Location = new System.Drawing.Point(149, 3);
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
            this.btnSimpan.Location = new System.Drawing.Point(255, 3);
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
            this.btnHapus.Location = new System.Drawing.Point(361, 3);
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
            this.btnCetak.Location = new System.Drawing.Point(467, 3);
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
            this.btnKeluar.Location = new System.Drawing.Point(573, 3);
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
            this.pnlInputData.Controls.Add(this.btnCariIDGudang);
            this.pnlInputData.Controls.Add(this.rbBarang);
            this.pnlInputData.Controls.Add(this.rbNotaGudang);
            this.pnlInputData.Controls.Add(this.label4);
            this.pnlInputData.Controls.Add(this.chkTerimaSemuaBarang);
            this.pnlInputData.Controls.Add(this.label8);
            this.pnlInputData.Controls.Add(this.txtIDGudang);
            this.pnlInputData.Controls.Add(this.txtKodeBarcode);
            this.pnlInputData.Controls.Add(this.brnCariBarang);
            this.pnlInputData.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInputData.Location = new System.Drawing.Point(396, 0);
            this.pnlInputData.Name = "pnlInputData";
            this.pnlInputData.Size = new System.Drawing.Size(676, 153);
            this.pnlInputData.TabIndex = 8;
            // 
            // chkTerimaSemuaBarang
            // 
            this.chkTerimaSemuaBarang.AutoSize = true;
            this.chkTerimaSemuaBarang.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTerimaSemuaBarang.Location = new System.Drawing.Point(6, 124);
            this.chkTerimaSemuaBarang.Name = "chkTerimaSemuaBarang";
            this.chkTerimaSemuaBarang.Size = new System.Drawing.Size(189, 22);
            this.chkTerimaSemuaBarang.TabIndex = 1001;
            this.chkTerimaSemuaBarang.Text = "Pindah Semua Barang";
            this.chkTerimaSemuaBarang.UseVisualStyleBackColor = true;
            this.chkTerimaSemuaBarang.CheckedChanged += new System.EventHandler(this.chkTerimaSemuaBarang_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(22, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 18);
            this.label8.TabIndex = 42;
            this.label8.Text = "Barcode";
            // 
            // txtKodeBarcode
            // 
            this.txtKodeBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKodeBarcode.Enabled = false;
            this.txtKodeBarcode.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKodeBarcode.Location = new System.Drawing.Point(98, 92);
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
            this.brnCariBarang.Enabled = false;
            this.brnCariBarang.FlatAppearance.BorderSize = 0;
            this.brnCariBarang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.brnCariBarang.Image = ((System.Drawing.Image)(resources.GetObject("brnCariBarang.Image")));
            this.brnCariBarang.Location = new System.Drawing.Point(375, 92);
            this.brnCariBarang.Name = "brnCariBarang";
            this.brnCariBarang.Size = new System.Drawing.Size(25, 25);
            this.brnCariBarang.TabIndex = 1000;
            this.brnCariBarang.UseVisualStyleBackColor = true;
            this.brnCariBarang.Click += new System.EventHandler(this.brnCariBarang_Click);
            this.brnCariBarang.Leave += new System.EventHandler(this.brnCariBarang_Leave);
            // 
            // pnlTransaksi
            // 
            this.pnlTransaksi.Controls.Add(this.label3);
            this.pnlTransaksi.Controls.Add(this.cboLokasi);
            this.pnlTransaksi.Controls.Add(this.txtCatatan);
            this.pnlTransaksi.Controls.Add(this.label1);
            this.pnlTransaksi.Controls.Add(this.lblID);
            this.pnlTransaksi.Controls.Add(this.dtTglTransaksi);
            this.pnlTransaksi.Controls.Add(this.label7);
            this.pnlTransaksi.Controls.Add(this.label2);
            this.pnlTransaksi.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTransaksi.Location = new System.Drawing.Point(0, 0);
            this.pnlTransaksi.Name = "pnlTransaksi";
            this.pnlTransaksi.Size = new System.Drawing.Size(396, 563);
            this.pnlTransaksi.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 18);
            this.label4.TabIndex = 44;
            this.label4.Text = "Nota Gd";
            // 
            // txtIDGudang
            // 
            this.txtIDGudang.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIDGudang.Enabled = false;
            this.txtIDGudang.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDGudang.Location = new System.Drawing.Point(98, 36);
            this.txtIDGudang.MaxLength = 100;
            this.txtIDGudang.Name = "txtIDGudang";
            this.txtIDGudang.Size = new System.Drawing.Size(271, 26);
            this.txtIDGudang.TabIndex = 42;
            this.txtIDGudang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIDGudang_KeyDown);
            this.txtIDGudang.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIDGudang_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 18);
            this.label3.TabIndex = 41;
            this.label3.Text = "Lokasi";
            // 
            // cboLokasi
            // 
            this.cboLokasi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLokasi.FormattingEnabled = true;
            this.cboLokasi.Items.AddRange(new object[] {
            "DISPLAY"});
            this.cboLokasi.Location = new System.Drawing.Point(88, 144);
            this.cboLokasi.Name = "cboLokasi";
            this.cboLokasi.Size = new System.Drawing.Size(212, 25);
            this.cboLokasi.TabIndex = 40;
            this.cboLokasi.Leave += new System.EventHandler(this.cboLokasi_Leave);
            // 
            // txtCatatan
            // 
            this.txtCatatan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCatatan.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCatatan.Location = new System.Drawing.Point(88, 62);
            this.txtCatatan.MaxLength = 255;
            this.txtCatatan.Multiline = true;
            this.txtCatatan.Name = "txtCatatan";
            this.txtCatatan.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCatatan.Size = new System.Drawing.Size(302, 76);
            this.txtCatatan.TabIndex = 7;
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
            this.lblID.Location = new System.Drawing.Point(85, 9);
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
            this.dtTglTransaksi.Location = new System.Drawing.Point(88, 30);
            this.dtTglTransaksi.Name = "dtTglTransaksi";
            this.dtTglTransaksi.Size = new System.Drawing.Size(149, 26);
            this.dtTglTransaksi.TabIndex = 5;
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
            this.label2.Location = new System.Drawing.Point(13, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 18);
            this.label2.TabIndex = 34;
            this.label2.Text = "Tgl. Tr.";
            // 
            // rbNotaGudang
            // 
            this.rbNotaGudang.AutoSize = true;
            this.rbNotaGudang.Location = new System.Drawing.Point(6, 6);
            this.rbNotaGudang.Name = "rbNotaGudang";
            this.rbNotaGudang.Size = new System.Drawing.Size(184, 21);
            this.rbNotaGudang.TabIndex = 1002;
            this.rbNotaGudang.TabStop = true;
            this.rbNotaGudang.Text = "Berdasar ID Masuk Gudang";
            this.rbNotaGudang.UseVisualStyleBackColor = true;
            this.rbNotaGudang.CheckedChanged += new System.EventHandler(this.rbNotaGudang_CheckedChanged);
            // 
            // rbBarang
            // 
            this.rbBarang.AutoSize = true;
            this.rbBarang.Location = new System.Drawing.Point(6, 68);
            this.rbBarang.Name = "rbBarang";
            this.rbBarang.Size = new System.Drawing.Size(168, 21);
            this.rbBarang.TabIndex = 1003;
            this.rbBarang.TabStop = true;
            this.rbBarang.Text = "Berdasar Satuan Barang";
            this.rbBarang.UseVisualStyleBackColor = true;
            this.rbBarang.CheckedChanged += new System.EventHandler(this.rbBarang_CheckedChanged);
            // 
            // btnCariIDGudang
            // 
            this.btnCariIDGudang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCariIDGudang.Enabled = false;
            this.btnCariIDGudang.FlatAppearance.BorderSize = 0;
            this.btnCariIDGudang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCariIDGudang.Image = ((System.Drawing.Image)(resources.GetObject("btnCariIDGudang.Image")));
            this.btnCariIDGudang.Location = new System.Drawing.Point(375, 37);
            this.btnCariIDGudang.Name = "btnCariIDGudang";
            this.btnCariIDGudang.Size = new System.Drawing.Size(25, 25);
            this.btnCariIDGudang.TabIndex = 1004;
            this.btnCariIDGudang.UseVisualStyleBackColor = true;
            this.btnCariIDGudang.Click += new System.EventHandler(this.btnCariIDGudang_Click);
            this.btnCariIDGudang.Leave += new System.EventHandler(this.btnCariIDGudang_Leave);
            // 
            // GudangPindah
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1072, 563);
            this.Controls.Add(this.pnlUtama);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "GudangPindah";
            this.Text = "GudangPindah";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GudangPindah_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GudangPindah_KeyPress);
            this.pnlUtama.ResumeLayout(false);
            this.pnlDataTransaksi.ResumeLayout(false);
            this.pnlComboBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTransaksi)).EndInit();
            this.pnlButton.ResumeLayout(false);
            this.pnlInputData.ResumeLayout(false);
            this.pnlInputData.PerformLayout();
            this.pnlTransaksi.ResumeLayout(false);
            this.pnlTransaksi.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlUtama;
        private System.Windows.Forms.Panel pnlTransaksi;
        private System.Windows.Forms.TextBox txtCatatan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.DateTimePicker dtTglTransaksi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlInputData;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtKodeBarcode;
        private System.Windows.Forms.Button brnCariBarang;
        private System.Windows.Forms.Panel pnlButton;
        private System.Windows.Forms.Button btnBaru;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnCetak;
        private System.Windows.Forms.Button btnKeluar;
        private System.Windows.Forms.Panel pnlDataTransaksi;
        private System.Windows.Forms.Panel pnlComboBox;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnHidePanel;
        private cmp.UpperComboBox cboSatuan;
        private System.Windows.Forms.DataGridView dgTransaksi;
        private System.Windows.Forms.Label label3;
        private cmp.UpperComboBox cboLokasi;
        private System.Windows.Forms.DataGridViewButtonColumn clHapus;
        private System.Windows.Forms.DataGridViewTextBoxColumn clBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNamaBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn clStok;
        private System.Windows.Forms.DataGridViewTextBoxColumn clQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSatuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn clQty1;
        private System.Windows.Forms.CheckBox chkTerimaSemuaBarang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIDGudang;
        private System.Windows.Forms.RadioButton rbBarang;
        private System.Windows.Forms.RadioButton rbNotaGudang;
        private System.Windows.Forms.Button btnCariIDGudang;
    }
}