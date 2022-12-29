namespace POS.frm
{
    partial class Piutang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Piutang));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSisa = new System.Windows.Forms.Label();
            this.txtPembayaran = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblTotalHutang = new System.Windows.Forms.Label();
            this.lblTotalBayar = new System.Windows.Forms.Label();
            this.pnlTotalPembelian = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDetailPenjualan = new System.Windows.Forms.TextBox();
            this.pnlDetailSupplier = new System.Windows.Forms.Panel();
            this.btnCariPenjualan = new System.Windows.Forms.Button();
            this.txtIDPenjualan = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCatatan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.dtTglTransaksi = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlKiri = new System.Windows.Forms.Panel();
            this.dgTransaksi = new System.Windows.Forms.DataGridView();
            this.clIDPembayaran = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTglBayar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCatatan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clPembayaran = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlUtama = new System.Windows.Forms.Panel();
            this.pnlDataTransaksi = new System.Windows.Forms.Panel();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.btnBaru = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnCetak = new System.Windows.Forms.Button();
            this.btnKeluar = new System.Windows.Forms.Button();
            this.chkLunas = new System.Windows.Forms.CheckBox();
            this.pnlTotalPembelian.SuspendLayout();
            this.pnlDetailSupplier.SuspendLayout();
            this.pnlKiri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTransaksi)).BeginInit();
            this.pnlUtama.SuspendLayout();
            this.pnlDataTransaksi.SuspendLayout();
            this.pnlButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 18);
            this.label3.TabIndex = 57;
            this.label3.Text = "Sisa";
            // 
            // lblSisa
            // 
            this.lblSisa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblSisa.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSisa.Location = new System.Drawing.Point(129, 140);
            this.lblSisa.Name = "lblSisa";
            this.lblSisa.Size = new System.Drawing.Size(258, 34);
            this.lblSisa.TabIndex = 56;
            this.lblSisa.Text = "0.00";
            this.lblSisa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPembayaran
            // 
            this.txtPembayaran.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPembayaran.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPembayaran.Location = new System.Drawing.Point(129, 181);
            this.txtPembayaran.MaxLength = 100;
            this.txtPembayaran.Name = "txtPembayaran";
            this.txtPembayaran.Size = new System.Drawing.Size(258, 26);
            this.txtPembayaran.TabIndex = 12;
            this.txtPembayaran.Text = "0.00";
            this.txtPembayaran.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPembayaran.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPembayaran_KeyPress);
            this.txtPembayaran.Leave += new System.EventHandler(this.txtPembayaran_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(18, 185);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 18);
            this.label11.TabIndex = 55;
            this.label11.Text = "Bayar";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(18, 110);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 18);
            this.label12.TabIndex = 53;
            this.label12.Text = "Total Bayar";
            // 
            // lblTotalHutang
            // 
            this.lblTotalHutang.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalHutang.Location = new System.Drawing.Point(129, 52);
            this.lblTotalHutang.Name = "lblTotalHutang";
            this.lblTotalHutang.Size = new System.Drawing.Size(258, 34);
            this.lblTotalHutang.TabIndex = 48;
            this.lblTotalHutang.Text = "0.00";
            this.lblTotalHutang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalBayar
            // 
            this.lblTotalBayar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblTotalBayar.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBayar.Location = new System.Drawing.Point(129, 98);
            this.lblTotalBayar.Name = "lblTotalBayar";
            this.lblTotalBayar.Size = new System.Drawing.Size(258, 34);
            this.lblTotalBayar.TabIndex = 46;
            this.lblTotalBayar.Text = "0.00";
            this.lblTotalBayar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlTotalPembelian
            // 
            this.pnlTotalPembelian.Controls.Add(this.chkLunas);
            this.pnlTotalPembelian.Controls.Add(this.label3);
            this.pnlTotalPembelian.Controls.Add(this.lblSisa);
            this.pnlTotalPembelian.Controls.Add(this.txtPembayaran);
            this.pnlTotalPembelian.Controls.Add(this.label11);
            this.pnlTotalPembelian.Controls.Add(this.label12);
            this.pnlTotalPembelian.Controls.Add(this.lblTotalHutang);
            this.pnlTotalPembelian.Controls.Add(this.label5);
            this.pnlTotalPembelian.Controls.Add(this.lblTotalBayar);
            this.pnlTotalPembelian.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTotalPembelian.Location = new System.Drawing.Point(0, 354);
            this.pnlTotalPembelian.Name = "pnlTotalPembelian";
            this.pnlTotalPembelian.Size = new System.Drawing.Size(491, 219);
            this.pnlTotalPembelian.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 18);
            this.label5.TabIndex = 49;
            this.label5.Text = "Total Hutang";
            // 
            // txtDetailPenjualan
            // 
            this.txtDetailPenjualan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDetailPenjualan.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetailPenjualan.Location = new System.Drawing.Point(129, 103);
            this.txtDetailPenjualan.MaxLength = 255;
            this.txtDetailPenjualan.Multiline = true;
            this.txtDetailPenjualan.Name = "txtDetailPenjualan";
            this.txtDetailPenjualan.ReadOnly = true;
            this.txtDetailPenjualan.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDetailPenjualan.Size = new System.Drawing.Size(356, 143);
            this.txtDetailPenjualan.TabIndex = 10;
            // 
            // pnlDetailSupplier
            // 
            this.pnlDetailSupplier.Controls.Add(this.txtDetailPenjualan);
            this.pnlDetailSupplier.Controls.Add(this.btnCariPenjualan);
            this.pnlDetailSupplier.Controls.Add(this.txtIDPenjualan);
            this.pnlDetailSupplier.Controls.Add(this.label8);
            this.pnlDetailSupplier.Controls.Add(this.txtCatatan);
            this.pnlDetailSupplier.Controls.Add(this.label1);
            this.pnlDetailSupplier.Controls.Add(this.lblID);
            this.pnlDetailSupplier.Controls.Add(this.dtTglTransaksi);
            this.pnlDetailSupplier.Controls.Add(this.label7);
            this.pnlDetailSupplier.Controls.Add(this.label2);
            this.pnlDetailSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetailSupplier.Location = new System.Drawing.Point(0, 0);
            this.pnlDetailSupplier.Name = "pnlDetailSupplier";
            this.pnlDetailSupplier.Size = new System.Drawing.Size(491, 354);
            this.pnlDetailSupplier.TabIndex = 5;
            // 
            // btnCariPenjualan
            // 
            this.btnCariPenjualan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCariPenjualan.FlatAppearance.BorderSize = 0;
            this.btnCariPenjualan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCariPenjualan.Image = ((System.Drawing.Image)(resources.GetObject("btnCariPenjualan.Image")));
            this.btnCariPenjualan.Location = new System.Drawing.Point(345, 72);
            this.btnCariPenjualan.Name = "btnCariPenjualan";
            this.btnCariPenjualan.Size = new System.Drawing.Size(25, 25);
            this.btnCariPenjualan.TabIndex = 9;
            this.btnCariPenjualan.UseVisualStyleBackColor = true;
            this.btnCariPenjualan.Click += new System.EventHandler(this.btnCariPenjualan_Click);
            // 
            // txtIDPenjualan
            // 
            this.txtIDPenjualan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIDPenjualan.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDPenjualan.Location = new System.Drawing.Point(129, 71);
            this.txtIDPenjualan.MaxLength = 100;
            this.txtIDPenjualan.Name = "txtIDPenjualan";
            this.txtIDPenjualan.Size = new System.Drawing.Size(210, 26);
            this.txtIDPenjualan.TabIndex = 8;
            this.txtIDPenjualan.TextChanged += new System.EventHandler(this.txtIDPenjualan_TextChanged);
            this.txtIDPenjualan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIDPenjualan_KeyDown);
            this.txtIDPenjualan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIDPenjualan_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 18);
            this.label8.TabIndex = 42;
            this.label8.Text = "ID Penjualan";
            // 
            // txtCatatan
            // 
            this.txtCatatan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCatatan.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCatatan.Location = new System.Drawing.Point(129, 252);
            this.txtCatatan.MaxLength = 255;
            this.txtCatatan.Multiline = true;
            this.txtCatatan.Name = "txtCatatan";
            this.txtCatatan.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCatatan.Size = new System.Drawing.Size(272, 76);
            this.txtCatatan.TabIndex = 11;
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
            this.lblID.Location = new System.Drawing.Point(126, 9);
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
            this.dtTglTransaksi.Location = new System.Drawing.Point(129, 39);
            this.dtTglTransaksi.Name = "dtTglTransaksi";
            this.dtTglTransaksi.Size = new System.Drawing.Size(149, 26);
            this.dtTglTransaksi.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 257);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 18);
            this.label7.TabIndex = 39;
            this.label7.Text = "Catatan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 18);
            this.label2.TabIndex = 34;
            this.label2.Text = "Tgl. Tr.";
            // 
            // pnlKiri
            // 
            this.pnlKiri.Controls.Add(this.pnlDetailSupplier);
            this.pnlKiri.Controls.Add(this.pnlTotalPembelian);
            this.pnlKiri.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlKiri.Location = new System.Drawing.Point(0, 0);
            this.pnlKiri.Name = "pnlKiri";
            this.pnlKiri.Size = new System.Drawing.Size(491, 573);
            this.pnlKiri.TabIndex = 1;
            // 
            // dgTransaksi
            // 
            this.dgTransaksi.AllowUserToAddRows = false;
            this.dgTransaksi.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgTransaksi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgTransaksi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTransaksi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clIDPembayaran,
            this.clTglBayar,
            this.clCatatan,
            this.clPembayaran});
            this.dgTransaksi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTransaksi.Location = new System.Drawing.Point(0, 0);
            this.dgTransaksi.Name = "dgTransaksi";
            this.dgTransaksi.ShowCellToolTips = false;
            this.dgTransaksi.Size = new System.Drawing.Size(568, 493);
            this.dgTransaksi.TabIndex = 17;
            // 
            // clIDPembayaran
            // 
            this.clIDPembayaran.HeaderText = "ID Pembayaran";
            this.clIDPembayaran.Name = "clIDPembayaran";
            this.clIDPembayaran.ReadOnly = true;
            // 
            // clTglBayar
            // 
            this.clTglBayar.HeaderText = "Tgl. Pembayaran";
            this.clTglBayar.Name = "clTglBayar";
            this.clTglBayar.ReadOnly = true;
            // 
            // clCatatan
            // 
            this.clCatatan.HeaderText = "Catatan";
            this.clCatatan.Name = "clCatatan";
            this.clCatatan.ReadOnly = true;
            // 
            // clPembayaran
            // 
            this.clPembayaran.HeaderText = "Pembayaran";
            this.clPembayaran.Name = "clPembayaran";
            this.clPembayaran.ReadOnly = true;
            // 
            // pnlUtama
            // 
            this.pnlUtama.Controls.Add(this.pnlDataTransaksi);
            this.pnlUtama.Controls.Add(this.pnlButton);
            this.pnlUtama.Controls.Add(this.pnlKiri);
            this.pnlUtama.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUtama.Location = new System.Drawing.Point(0, 0);
            this.pnlUtama.Name = "pnlUtama";
            this.pnlUtama.Size = new System.Drawing.Size(1059, 573);
            this.pnlUtama.TabIndex = 1;
            // 
            // pnlDataTransaksi
            // 
            this.pnlDataTransaksi.Controls.Add(this.dgTransaksi);
            this.pnlDataTransaksi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDataTransaksi.Location = new System.Drawing.Point(491, 0);
            this.pnlDataTransaksi.Name = "pnlDataTransaksi";
            this.pnlDataTransaksi.Size = new System.Drawing.Size(568, 493);
            this.pnlDataTransaksi.TabIndex = 9;
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnBaru);
            this.pnlButton.Controls.Add(this.btnSimpan);
            this.pnlButton.Controls.Add(this.btnHapus);
            this.pnlButton.Controls.Add(this.btnCetak);
            this.pnlButton.Controls.Add(this.btnKeluar);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButton.Location = new System.Drawing.Point(491, 493);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(568, 80);
            this.pnlButton.TabIndex = 8;
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
            this.btnBaru.Location = new System.Drawing.Point(147, 3);
            this.btnBaru.Name = "btnBaru";
            this.btnBaru.Size = new System.Drawing.Size(100, 75);
            this.btnBaru.TabIndex = 16;
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
            this.btnSimpan.Location = new System.Drawing.Point(253, 3);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(100, 75);
            this.btnSimpan.TabIndex = 13;
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
            this.btnHapus.Location = new System.Drawing.Point(359, 3);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(100, 75);
            this.btnHapus.TabIndex = 14;
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
            this.btnCetak.Location = new System.Drawing.Point(-2, 3);
            this.btnCetak.Name = "btnCetak";
            this.btnCetak.Size = new System.Drawing.Size(100, 75);
            this.btnCetak.TabIndex = 15;
            this.btnCetak.Text = "CETAK-F12";
            this.btnCetak.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCetak.UseVisualStyleBackColor = false;
            this.btnCetak.Visible = false;
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
            this.btnKeluar.Location = new System.Drawing.Point(465, 3);
            this.btnKeluar.Name = "btnKeluar";
            this.btnKeluar.Size = new System.Drawing.Size(100, 75);
            this.btnKeluar.TabIndex = 15;
            this.btnKeluar.Text = "KELUAR-F10";
            this.btnKeluar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnKeluar.UseVisualStyleBackColor = false;
            this.btnKeluar.Click += new System.EventHandler(this.btnKeluar_Click);
            // 
            // chkLunas
            // 
            this.chkLunas.AutoSize = true;
            this.chkLunas.Location = new System.Drawing.Point(108, 189);
            this.chkLunas.Name = "chkLunas";
            this.chkLunas.Size = new System.Drawing.Size(15, 14);
            this.chkLunas.TabIndex = 59;
            this.chkLunas.UseVisualStyleBackColor = true;
            this.chkLunas.CheckedChanged += new System.EventHandler(this.chkLunas_CheckedChanged);
            // 
            // Piutang
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1059, 573);
            this.Controls.Add(this.pnlUtama);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Piutang";
            this.Text = "Piutang";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Piutang_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Piutang_KeyPress);
            this.pnlTotalPembelian.ResumeLayout(false);
            this.pnlTotalPembelian.PerformLayout();
            this.pnlDetailSupplier.ResumeLayout(false);
            this.pnlDetailSupplier.PerformLayout();
            this.pnlKiri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTransaksi)).EndInit();
            this.pnlUtama.ResumeLayout(false);
            this.pnlDataTransaksi.ResumeLayout(false);
            this.pnlButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSisa;
        private System.Windows.Forms.TextBox txtPembayaran;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTotalHutang;
        private System.Windows.Forms.Label lblTotalBayar;
        private System.Windows.Forms.Panel pnlTotalPembelian;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDetailPenjualan;
        private System.Windows.Forms.Panel pnlDetailSupplier;
        private System.Windows.Forms.Button btnCariPenjualan;
        private System.Windows.Forms.TextBox txtIDPenjualan;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCatatan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.DateTimePicker dtTglTransaksi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlKiri;
        private System.Windows.Forms.DataGridView dgTransaksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn clIDPembayaran;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTglBayar;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCatatan;
        private System.Windows.Forms.DataGridViewTextBoxColumn clPembayaran;
        private System.Windows.Forms.Panel pnlUtama;
        private System.Windows.Forms.Panel pnlDataTransaksi;
        private System.Windows.Forms.Panel pnlButton;
        private System.Windows.Forms.Button btnBaru;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnCetak;
        private System.Windows.Forms.Button btnKeluar;
        private System.Windows.Forms.CheckBox chkLunas;
    }
}