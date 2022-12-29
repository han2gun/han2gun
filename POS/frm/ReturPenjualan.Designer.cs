namespace POS.frm
{
    partial class ReturPenjualan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReturPenjualan));
            this.dgTransaksi = new System.Windows.Forms.DataGridView();
            this.clHapus = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clNamaBarang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clketerangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSatuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clHargaJual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDiskon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDiskonRp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSubTotalBersih = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clKondisi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlKiri = new System.Windows.Forms.Panel();
            this.pnlDetailSupplier = new System.Windows.Forms.Panel();
            this.btnCariIDPenjualan = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIDPenjualan = new System.Windows.Forms.TextBox();
            this.txtCatatan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.btnCariCustomer = new System.Windows.Forms.Button();
            this.dtTglTransaksi = new System.Windows.Forms.DateTimePicker();
            this.txtIdCustomer = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNamaCustomer = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlTotalPembelian = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.pnlInputData = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtKodeBarcode = new System.Windows.Forms.TextBox();
            this.brnCariBarang = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnCetak = new System.Windows.Forms.Button();
            this.btnKeluar = new System.Windows.Forms.Button();
            this.btnBaru = new System.Windows.Forms.Button();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.pnlUtama = new System.Windows.Forms.Panel();
            this.pnlKanan = new System.Windows.Forms.Panel();
            this.pnlDataTransaksi = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgTransaksi)).BeginInit();
            this.pnlKiri.SuspendLayout();
            this.pnlDetailSupplier.SuspendLayout();
            this.pnlTotalPembelian.SuspendLayout();
            this.pnlInputData.SuspendLayout();
            this.pnlButton.SuspendLayout();
            this.pnlUtama.SuspendLayout();
            this.pnlKanan.SuspendLayout();
            this.pnlDataTransaksi.SuspendLayout();
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
            this.clketerangan,
            this.clQty,
            this.clSatuan,
            this.clHargaJual,
            this.clDiskon,
            this.clDiskonRp,
            this.clSubTotal,
            this.clSubTotalBersih,
            this.clKondisi});
            this.dgTransaksi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTransaksi.Location = new System.Drawing.Point(0, 0);
            this.dgTransaksi.Name = "dgTransaksi";
            this.dgTransaksi.ShowCellToolTips = false;
            this.dgTransaksi.Size = new System.Drawing.Size(738, 454);
            this.dgTransaksi.TabIndex = 10;
            this.dgTransaksi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTransaksi_CellClick);
            this.dgTransaksi.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTransaksi_CellEndEdit);
            this.dgTransaksi.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgTransaksi_EditingControlShowing);
            this.dgTransaksi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgTransaksi_KeyPress);
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
            // clketerangan
            // 
            this.clketerangan.HeaderText = "Keterangan";
            this.clketerangan.Name = "clketerangan";
            // 
            // clQty
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clQty.DefaultCellStyle = dataGridViewCellStyle5;
            this.clQty.HeaderText = "Qty";
            this.clQty.Name = "clQty";
            this.clQty.Width = 50;
            // 
            // clSatuan
            // 
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clSatuan.DefaultCellStyle = dataGridViewCellStyle6;
            this.clSatuan.HeaderText = "Satuan";
            this.clSatuan.Name = "clSatuan";
            this.clSatuan.ReadOnly = true;
            this.clSatuan.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clSatuan.Width = 70;
            // 
            // clHargaJual
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clHargaJual.DefaultCellStyle = dataGridViewCellStyle7;
            this.clHargaJual.HeaderText = "Harga";
            this.clHargaJual.Name = "clHargaJual";
            this.clHargaJual.ReadOnly = true;
            // 
            // clDiskon
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clDiskon.DefaultCellStyle = dataGridViewCellStyle8;
            this.clDiskon.HeaderText = "Diskon (%)";
            this.clDiskon.Name = "clDiskon";
            this.clDiskon.ReadOnly = true;
            this.clDiskon.Width = 70;
            // 
            // clDiskonRp
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clDiskonRp.DefaultCellStyle = dataGridViewCellStyle9;
            this.clDiskonRp.HeaderText = "Diskon (Rp)";
            this.clDiskonRp.Name = "clDiskonRp";
            this.clDiskonRp.ReadOnly = true;
            this.clDiskonRp.Width = 90;
            // 
            // clSubTotal
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clSubTotal.DefaultCellStyle = dataGridViewCellStyle10;
            this.clSubTotal.HeaderText = "Sub. Total";
            this.clSubTotal.Name = "clSubTotal";
            this.clSubTotal.ReadOnly = true;
            // 
            // clSubTotalBersih
            // 
            this.clSubTotalBersih.HeaderText = "Subt. Total Bersih";
            this.clSubTotalBersih.Name = "clSubTotalBersih";
            this.clSubTotalBersih.ReadOnly = true;
            this.clSubTotalBersih.Visible = false;
            // 
            // clKondisi
            // 
            this.clKondisi.HeaderText = "Kondisi";
            this.clKondisi.Name = "clKondisi";
            this.clKondisi.ReadOnly = true;
            // 
            // pnlKiri
            // 
            this.pnlKiri.Controls.Add(this.pnlDetailSupplier);
            this.pnlKiri.Controls.Add(this.pnlTotalPembelian);
            this.pnlKiri.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlKiri.Location = new System.Drawing.Point(0, 0);
            this.pnlKiri.Name = "pnlKiri";
            this.pnlKiri.Size = new System.Drawing.Size(418, 573);
            this.pnlKiri.TabIndex = 0;
            // 
            // pnlDetailSupplier
            // 
            this.pnlDetailSupplier.Controls.Add(this.btnCariIDPenjualan);
            this.pnlDetailSupplier.Controls.Add(this.label3);
            this.pnlDetailSupplier.Controls.Add(this.txtIDPenjualan);
            this.pnlDetailSupplier.Controls.Add(this.txtCatatan);
            this.pnlDetailSupplier.Controls.Add(this.label1);
            this.pnlDetailSupplier.Controls.Add(this.lblID);
            this.pnlDetailSupplier.Controls.Add(this.btnCariCustomer);
            this.pnlDetailSupplier.Controls.Add(this.dtTglTransaksi);
            this.pnlDetailSupplier.Controls.Add(this.txtIdCustomer);
            this.pnlDetailSupplier.Controls.Add(this.label7);
            this.pnlDetailSupplier.Controls.Add(this.label2);
            this.pnlDetailSupplier.Controls.Add(this.lblNamaCustomer);
            this.pnlDetailSupplier.Controls.Add(this.label4);
            this.pnlDetailSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetailSupplier.Location = new System.Drawing.Point(0, 0);
            this.pnlDetailSupplier.Name = "pnlDetailSupplier";
            this.pnlDetailSupplier.Size = new System.Drawing.Size(418, 518);
            this.pnlDetailSupplier.TabIndex = 5;
            // 
            // btnCariIDPenjualan
            // 
            this.btnCariIDPenjualan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCariIDPenjualan.FlatAppearance.BorderSize = 0;
            this.btnCariIDPenjualan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCariIDPenjualan.Image = ((System.Drawing.Image)(resources.GetObject("btnCariIDPenjualan.Image")));
            this.btnCariIDPenjualan.Location = new System.Drawing.Point(298, 84);
            this.btnCariIDPenjualan.Name = "btnCariIDPenjualan";
            this.btnCariIDPenjualan.Size = new System.Drawing.Size(25, 25);
            this.btnCariIDPenjualan.TabIndex = 10004;
            this.btnCariIDPenjualan.UseVisualStyleBackColor = true;
            this.btnCariIDPenjualan.Click += new System.EventHandler(this.btnCariIDPenjualan_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 18);
            this.label3.TabIndex = 10003;
            this.label3.Text = "ID Penjualan";
            // 
            // txtIDPenjualan
            // 
            this.txtIDPenjualan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIDPenjualan.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDPenjualan.Location = new System.Drawing.Point(112, 83);
            this.txtIDPenjualan.MaxLength = 100;
            this.txtIDPenjualan.Name = "txtIDPenjualan";
            this.txtIDPenjualan.Size = new System.Drawing.Size(180, 26);
            this.txtIDPenjualan.TabIndex = 10002;
            this.txtIDPenjualan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIDPenjualan_KeyDown);
            this.txtIDPenjualan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIDPenjualan_KeyPress);
            // 
            // txtCatatan
            // 
            this.txtCatatan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCatatan.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCatatan.Location = new System.Drawing.Point(112, 147);
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
            this.lblID.Location = new System.Drawing.Point(109, 9);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(67, 18);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "AUTO ID";
            this.lblID.TextChanged += new System.EventHandler(this.lblID_TextChanged);
            // 
            // btnCariCustomer
            // 
            this.btnCariCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCariCustomer.FlatAppearance.BorderSize = 0;
            this.btnCariCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCariCustomer.Image = ((System.Drawing.Image)(resources.GetObject("btnCariCustomer.Image")));
            this.btnCariCustomer.Location = new System.Drawing.Point(267, 30);
            this.btnCariCustomer.Name = "btnCariCustomer";
            this.btnCariCustomer.Size = new System.Drawing.Size(25, 25);
            this.btnCariCustomer.TabIndex = 10001;
            this.btnCariCustomer.UseVisualStyleBackColor = true;
            this.btnCariCustomer.Click += new System.EventHandler(this.btnCariCustomer_Click);
            // 
            // dtTglTransaksi
            // 
            this.dtTglTransaksi.CalendarFont = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTglTransaksi.CustomFormat = "dd - MMM - yyyy";
            this.dtTglTransaksi.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTglTransaksi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTglTransaksi.Location = new System.Drawing.Point(112, 115);
            this.dtTglTransaksi.Name = "dtTglTransaksi";
            this.dtTglTransaksi.Size = new System.Drawing.Size(149, 26);
            this.dtTglTransaksi.TabIndex = 5;
            // 
            // txtIdCustomer
            // 
            this.txtIdCustomer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdCustomer.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdCustomer.Location = new System.Drawing.Point(112, 30);
            this.txtIdCustomer.MaxLength = 100;
            this.txtIdCustomer.Name = "txtIdCustomer";
            this.txtIdCustomer.Size = new System.Drawing.Size(149, 26);
            this.txtIdCustomer.TabIndex = 1;
            this.txtIdCustomer.TextChanged += new System.EventHandler(this.txtIdCustomer_TextChanged);
            this.txtIdCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdCustomer_KeyDown);
            this.txtIdCustomer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdCustomer_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 18);
            this.label7.TabIndex = 39;
            this.label7.Text = "Catatan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 18);
            this.label2.TabIndex = 34;
            this.label2.Text = "Tgl. Tr.";
            // 
            // lblNamaCustomer
            // 
            this.lblNamaCustomer.AutoSize = true;
            this.lblNamaCustomer.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamaCustomer.Location = new System.Drawing.Point(109, 59);
            this.lblNamaCustomer.Name = "lblNamaCustomer";
            this.lblNamaCustomer.Size = new System.Drawing.Size(127, 18);
            this.lblNamaCustomer.TabIndex = 3;
            this.lblNamaCustomer.Text = "Nama Customer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 18);
            this.label4.TabIndex = 36;
            this.label4.Text = "Customer";
            // 
            // pnlTotalPembelian
            // 
            this.pnlTotalPembelian.Controls.Add(this.label12);
            this.pnlTotalPembelian.Controls.Add(this.lblGrandTotal);
            this.pnlTotalPembelian.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTotalPembelian.Location = new System.Drawing.Point(0, 518);
            this.pnlTotalPembelian.Name = "pnlTotalPembelian";
            this.pnlTotalPembelian.Size = new System.Drawing.Size(418, 55);
            this.pnlTotalPembelian.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(43, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 18);
            this.label12.TabIndex = 53;
            this.label12.Text = "Grand Total";
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblGrandTotal.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrandTotal.Location = new System.Drawing.Point(154, 10);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(258, 34);
            this.lblGrandTotal.TabIndex = 46;
            this.lblGrandTotal.Text = "0.00";
            this.lblGrandTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlInputData
            // 
            this.pnlInputData.Controls.Add(this.label8);
            this.pnlInputData.Controls.Add(this.txtKodeBarcode);
            this.pnlInputData.Controls.Add(this.brnCariBarang);
            this.pnlInputData.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInputData.Location = new System.Drawing.Point(0, 0);
            this.pnlInputData.Name = "pnlInputData";
            this.pnlInputData.Size = new System.Drawing.Size(738, 39);
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
            this.txtKodeBarcode.Location = new System.Drawing.Point(84, 5);
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
            this.brnCariBarang.Location = new System.Drawing.Point(361, 6);
            this.brnCariBarang.Name = "brnCariBarang";
            this.brnCariBarang.Size = new System.Drawing.Size(25, 25);
            this.brnCariBarang.TabIndex = 1000;
            this.brnCariBarang.UseVisualStyleBackColor = true;
            this.brnCariBarang.Click += new System.EventHandler(this.brnCariBarang_Click);
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
            this.btnSimpan.Location = new System.Drawing.Point(317, 3);
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
            this.btnHapus.Location = new System.Drawing.Point(423, 3);
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
            this.btnCetak.Location = new System.Drawing.Point(529, 3);
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
            this.btnKeluar.Location = new System.Drawing.Point(635, 3);
            this.btnKeluar.Name = "btnKeluar";
            this.btnKeluar.Size = new System.Drawing.Size(100, 75);
            this.btnKeluar.TabIndex = 14;
            this.btnKeluar.Text = "KELUAR-F10";
            this.btnKeluar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnKeluar.UseVisualStyleBackColor = false;
            this.btnKeluar.Click += new System.EventHandler(this.btnKeluar_Click);
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
            this.btnBaru.Location = new System.Drawing.Point(211, 3);
            this.btnBaru.Name = "btnBaru";
            this.btnBaru.Size = new System.Drawing.Size(100, 75);
            this.btnBaru.TabIndex = 18;
            this.btnBaru.Text = "BARU-F2";
            this.btnBaru.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBaru.UseVisualStyleBackColor = false;
            this.btnBaru.Click += new System.EventHandler(this.btnBaru_Click);
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnBaru);
            this.pnlButton.Controls.Add(this.btnSimpan);
            this.pnlButton.Controls.Add(this.btnHapus);
            this.pnlButton.Controls.Add(this.btnCetak);
            this.pnlButton.Controls.Add(this.btnKeluar);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButton.Location = new System.Drawing.Point(0, 493);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(738, 80);
            this.pnlButton.TabIndex = 7;
            // 
            // pnlUtama
            // 
            this.pnlUtama.Controls.Add(this.pnlKanan);
            this.pnlUtama.Controls.Add(this.pnlKiri);
            this.pnlUtama.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUtama.Location = new System.Drawing.Point(0, 0);
            this.pnlUtama.Name = "pnlUtama";
            this.pnlUtama.Size = new System.Drawing.Size(1156, 573);
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
            this.pnlKanan.Size = new System.Drawing.Size(738, 573);
            this.pnlKanan.TabIndex = 1;
            // 
            // pnlDataTransaksi
            // 
            this.pnlDataTransaksi.Controls.Add(this.dgTransaksi);
            this.pnlDataTransaksi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDataTransaksi.Location = new System.Drawing.Point(0, 39);
            this.pnlDataTransaksi.Name = "pnlDataTransaksi";
            this.pnlDataTransaksi.Size = new System.Drawing.Size(738, 454);
            this.pnlDataTransaksi.TabIndex = 8;
            // 
            // ReturPenjualan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1156, 573);
            this.Controls.Add(this.pnlUtama);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "ReturPenjualan";
            this.Text = "ReturPenjualan";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReturPenjualan_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ReturPenjualan_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dgTransaksi)).EndInit();
            this.pnlKiri.ResumeLayout(false);
            this.pnlDetailSupplier.ResumeLayout(false);
            this.pnlDetailSupplier.PerformLayout();
            this.pnlTotalPembelian.ResumeLayout(false);
            this.pnlTotalPembelian.PerformLayout();
            this.pnlInputData.ResumeLayout(false);
            this.pnlInputData.PerformLayout();
            this.pnlButton.ResumeLayout(false);
            this.pnlUtama.ResumeLayout(false);
            this.pnlKanan.ResumeLayout(false);
            this.pnlDataTransaksi.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgTransaksi;
        private System.Windows.Forms.Panel pnlKiri;
        private System.Windows.Forms.Panel pnlDetailSupplier;
        private System.Windows.Forms.Button btnCariIDPenjualan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIDPenjualan;
        private System.Windows.Forms.TextBox txtCatatan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Button btnCariCustomer;
        private System.Windows.Forms.DateTimePicker dtTglTransaksi;
        private System.Windows.Forms.TextBox txtIdCustomer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNamaCustomer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlTotalPembelian;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblGrandTotal;
        private System.Windows.Forms.Panel pnlInputData;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtKodeBarcode;
        private System.Windows.Forms.Button brnCariBarang;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnCetak;
        private System.Windows.Forms.Button btnKeluar;
        private System.Windows.Forms.Button btnBaru;
        private System.Windows.Forms.Panel pnlButton;
        private System.Windows.Forms.Panel pnlUtama;
        private System.Windows.Forms.Panel pnlKanan;
        private System.Windows.Forms.Panel pnlDataTransaksi;
        private System.Windows.Forms.DataGridViewButtonColumn clHapus;
        private System.Windows.Forms.DataGridViewTextBoxColumn clBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNamaBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn clketerangan;
        private System.Windows.Forms.DataGridViewTextBoxColumn clQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSatuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn clHargaJual;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDiskon;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDiskonRp;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSubTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSubTotalBersih;
        private System.Windows.Forms.DataGridViewTextBoxColumn clKondisi;
    }
}