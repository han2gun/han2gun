namespace POS.frm
{
    partial class Barang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Barang));
            this.btnKeluar = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnBaru = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCetak = new System.Windows.Forms.Button();
            this.txtCatatan = new System.Windows.Forms.TextBox();
            this.txtHargaJual1 = new System.Windows.Forms.TextBox();
            this.txtSatuan3 = new System.Windows.Forms.TextBox();
            this.txtSatuan2 = new System.Windows.Forms.TextBox();
            this.txtSatuan1 = new System.Windows.Forms.TextBox();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.txtKodeBarcode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlUtama = new System.Windows.Forms.Panel();
            this.txtHargaBeli = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblStokRupiah = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblStokTersedia = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkNonAktif = new System.Windows.Forms.CheckBox();
            this.cboSatuanStokMin = new POS.cmp.UpperComboBox();
            this.lblJualSatuan3 = new System.Windows.Forms.Label();
            this.lblJualSatuan2 = new System.Windows.Forms.Label();
            this.lblJualSatuan1 = new System.Windows.Forms.Label();
            this.lblJualSatuan5 = new System.Windows.Forms.Label();
            this.txtHargaJual5 = new System.Windows.Forms.TextBox();
            this.txtHargaJual4 = new System.Windows.Forms.TextBox();
            this.txtHargaJual3 = new System.Windows.Forms.TextBox();
            this.txtHargaJual2 = new System.Windows.Forms.TextBox();
            this.lblJualSatuan4 = new System.Windows.Forms.Label();
            this.lblSatuan5 = new System.Windows.Forms.Label();
            this.lblSatuan4 = new System.Windows.Forms.Label();
            this.txtQtySatuan5 = new System.Windows.Forms.TextBox();
            this.txtQtySatuan4 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSatuan5 = new System.Windows.Forms.TextBox();
            this.txtSatuan4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboKategori = new POS.cmp.UpperComboBox();
            this.txtStokMin = new System.Windows.Forms.TextBox();
            this.lblSatuan3 = new System.Windows.Forms.Label();
            this.lblSatuan2 = new System.Windows.Forms.Label();
            this.txtQtySatuan3 = new System.Windows.Forms.TextBox();
            this.txtQtySatuan2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlUtama.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
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
            this.btnKeluar.Location = new System.Drawing.Point(3, 261);
            this.btnKeluar.Name = "btnKeluar";
            this.btnKeluar.Size = new System.Drawing.Size(100, 80);
            this.btnKeluar.TabIndex = 13;
            this.btnKeluar.Text = "KELUAR-F10";
            this.btnKeluar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnKeluar.UseVisualStyleBackColor = false;
            this.btnKeluar.Click += new System.EventHandler(this.btnKeluar_Click);
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
            this.btnHapus.Location = new System.Drawing.Point(3, 175);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(100, 80);
            this.btnHapus.TabIndex = 11;
            this.btnHapus.Text = "HAPUS-F4";
            this.btnHapus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnHapus.UseVisualStyleBackColor = false;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
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
            this.btnSimpan.Location = new System.Drawing.Point(3, 89);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(100, 80);
            this.btnSimpan.TabIndex = 10;
            this.btnSimpan.Text = "SIMPAN-F3";
            this.btnSimpan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSimpan.UseVisualStyleBackColor = false;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnBaru
            // 
            this.btnBaru.AccessibleName = "BARU";
            this.btnBaru.BackColor = System.Drawing.Color.White;
            this.btnBaru.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBaru.FlatAppearance.BorderSize = 0;
            this.btnBaru.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaru.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaru.ForeColor = System.Drawing.Color.Black;
            this.btnBaru.Image = ((System.Drawing.Image)(resources.GetObject("btnBaru.Image")));
            this.btnBaru.Location = new System.Drawing.Point(3, 3);
            this.btnBaru.Name = "btnBaru";
            this.btnBaru.Size = new System.Drawing.Size(100, 80);
            this.btnBaru.TabIndex = 9;
            this.btnBaru.Text = "BARU-F2";
            this.btnBaru.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBaru.UseVisualStyleBackColor = false;
            this.btnBaru.Click += new System.EventHandler(this.btnBaru_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnKeluar);
            this.panel1.Controls.Add(this.btnCetak);
            this.panel1.Controls.Add(this.btnHapus);
            this.panel1.Controls.Add(this.btnSimpan);
            this.panel1.Controls.Add(this.btnBaru);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(864, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(106, 559);
            this.panel1.TabIndex = 18;
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
            this.btnCetak.Location = new System.Drawing.Point(3, 347);
            this.btnCetak.Name = "btnCetak";
            this.btnCetak.Size = new System.Drawing.Size(100, 80);
            this.btnCetak.TabIndex = 12;
            this.btnCetak.Text = "CETAK-F12";
            this.btnCetak.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCetak.UseVisualStyleBackColor = false;
            this.btnCetak.Visible = false;
            this.btnCetak.Click += new System.EventHandler(this.btnCetak_Click);
            // 
            // txtCatatan
            // 
            this.txtCatatan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCatatan.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCatatan.Location = new System.Drawing.Point(159, 107);
            this.txtCatatan.MaxLength = 255;
            this.txtCatatan.Multiline = true;
            this.txtCatatan.Name = "txtCatatan";
            this.txtCatatan.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCatatan.Size = new System.Drawing.Size(379, 76);
            this.txtCatatan.TabIndex = 3;
            // 
            // txtHargaJual1
            // 
            this.txtHargaJual1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHargaJual1.Location = new System.Drawing.Point(159, 285);
            this.txtHargaJual1.MaxLength = 100;
            this.txtHargaJual1.Name = "txtHargaJual1";
            this.txtHargaJual1.Size = new System.Drawing.Size(165, 26);
            this.txtHargaJual1.TabIndex = 15;
            this.txtHargaJual1.Text = "0.00";
            this.txtHargaJual1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHargaJual1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHargaJual1_KeyPress);
            this.txtHargaJual1.Leave += new System.EventHandler(this.txtHargaJual1_Leave);
            // 
            // txtSatuan3
            // 
            this.txtSatuan3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSatuan3.Enabled = false;
            this.txtSatuan3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSatuan3.Location = new System.Drawing.Point(477, 445);
            this.txtSatuan3.MaxLength = 100;
            this.txtSatuan3.Name = "txtSatuan3";
            this.txtSatuan3.Size = new System.Drawing.Size(165, 26);
            this.txtSatuan3.TabIndex = 7;
            this.txtSatuan3.Visible = false;
            this.txtSatuan3.TextChanged += new System.EventHandler(this.txtSatuan3_TextChanged);
            this.txtSatuan3.Leave += new System.EventHandler(this.txtSatuan3_Leave);
            // 
            // txtSatuan2
            // 
            this.txtSatuan2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSatuan2.Enabled = false;
            this.txtSatuan2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSatuan2.Location = new System.Drawing.Point(486, 225);
            this.txtSatuan2.MaxLength = 100;
            this.txtSatuan2.Name = "txtSatuan2";
            this.txtSatuan2.Size = new System.Drawing.Size(165, 26);
            this.txtSatuan2.TabIndex = 5;
            this.txtSatuan2.Visible = false;
            this.txtSatuan2.TextChanged += new System.EventHandler(this.txtSatuan2_TextChanged);
            this.txtSatuan2.Leave += new System.EventHandler(this.txtSatuan2_Leave);
            // 
            // txtSatuan1
            // 
            this.txtSatuan1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSatuan1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSatuan1.Location = new System.Drawing.Point(159, 189);
            this.txtSatuan1.MaxLength = 100;
            this.txtSatuan1.Name = "txtSatuan1";
            this.txtSatuan1.Size = new System.Drawing.Size(165, 26);
            this.txtSatuan1.TabIndex = 4;
            this.txtSatuan1.TextChanged += new System.EventHandler(this.txtSatuan1_TextChanged);
            this.txtSatuan1.Leave += new System.EventHandler(this.txtSatuan1_Leave);
            // 
            // txtNama
            // 
            this.txtNama.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNama.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNama.Location = new System.Drawing.Point(159, 44);
            this.txtNama.MaxLength = 100;
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(379, 26);
            this.txtNama.TabIndex = 1;
            // 
            // txtKodeBarcode
            // 
            this.txtKodeBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKodeBarcode.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKodeBarcode.Location = new System.Drawing.Point(159, 12);
            this.txtKodeBarcode.MaxLength = 100;
            this.txtKodeBarcode.Name = "txtKodeBarcode";
            this.txtKodeBarcode.Size = new System.Drawing.Size(379, 26);
            this.txtKodeBarcode.TabIndex = 0;
            this.txtKodeBarcode.TextChanged += new System.EventHandler(this.txtKodeBarcode_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 18);
            this.label9.TabIndex = 28;
            this.label9.Text = "Catatan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 18);
            this.label2.TabIndex = 21;
            this.label2.Text = "Barcode";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 289);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 18);
            this.label7.TabIndex = 26;
            this.label7.Text = "Harga Jual Satuan";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 225);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 18);
            this.label8.TabIndex = 27;
            this.label8.Text = "Stok Min.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 18);
            this.label5.TabIndex = 24;
            this.label5.Text = "Satuan";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 18);
            this.label4.TabIndex = 23;
            this.label4.Text = "Nama";
            // 
            // pnlUtama
            // 
            this.pnlUtama.Controls.Add(this.txtHargaBeli);
            this.pnlUtama.Controls.Add(this.label16);
            this.pnlUtama.Controls.Add(this.label11);
            this.pnlUtama.Controls.Add(this.lblStokRupiah);
            this.pnlUtama.Controls.Add(this.label12);
            this.pnlUtama.Controls.Add(this.lblStokTersedia);
            this.pnlUtama.Controls.Add(this.panel2);
            this.pnlUtama.Controls.Add(this.cboSatuanStokMin);
            this.pnlUtama.Controls.Add(this.lblJualSatuan3);
            this.pnlUtama.Controls.Add(this.lblJualSatuan2);
            this.pnlUtama.Controls.Add(this.lblJualSatuan1);
            this.pnlUtama.Controls.Add(this.lblJualSatuan5);
            this.pnlUtama.Controls.Add(this.txtHargaJual5);
            this.pnlUtama.Controls.Add(this.txtHargaJual4);
            this.pnlUtama.Controls.Add(this.txtHargaJual3);
            this.pnlUtama.Controls.Add(this.txtHargaJual2);
            this.pnlUtama.Controls.Add(this.lblJualSatuan4);
            this.pnlUtama.Controls.Add(this.lblSatuan5);
            this.pnlUtama.Controls.Add(this.lblSatuan4);
            this.pnlUtama.Controls.Add(this.txtQtySatuan5);
            this.pnlUtama.Controls.Add(this.txtQtySatuan4);
            this.pnlUtama.Controls.Add(this.label14);
            this.pnlUtama.Controls.Add(this.label15);
            this.pnlUtama.Controls.Add(this.txtSatuan5);
            this.pnlUtama.Controls.Add(this.txtSatuan4);
            this.pnlUtama.Controls.Add(this.label3);
            this.pnlUtama.Controls.Add(this.cboKategori);
            this.pnlUtama.Controls.Add(this.txtStokMin);
            this.pnlUtama.Controls.Add(this.lblSatuan3);
            this.pnlUtama.Controls.Add(this.lblSatuan2);
            this.pnlUtama.Controls.Add(this.txtQtySatuan3);
            this.pnlUtama.Controls.Add(this.txtQtySatuan2);
            this.pnlUtama.Controls.Add(this.label10);
            this.pnlUtama.Controls.Add(this.label1);
            this.pnlUtama.Controls.Add(this.txtCatatan);
            this.pnlUtama.Controls.Add(this.txtHargaJual1);
            this.pnlUtama.Controls.Add(this.txtSatuan3);
            this.pnlUtama.Controls.Add(this.txtSatuan2);
            this.pnlUtama.Controls.Add(this.txtSatuan1);
            this.pnlUtama.Controls.Add(this.txtNama);
            this.pnlUtama.Controls.Add(this.txtKodeBarcode);
            this.pnlUtama.Controls.Add(this.label9);
            this.pnlUtama.Controls.Add(this.label2);
            this.pnlUtama.Controls.Add(this.label7);
            this.pnlUtama.Controls.Add(this.label8);
            this.pnlUtama.Controls.Add(this.label5);
            this.pnlUtama.Controls.Add(this.label4);
            this.pnlUtama.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUtama.Location = new System.Drawing.Point(0, 0);
            this.pnlUtama.Name = "pnlUtama";
            this.pnlUtama.Size = new System.Drawing.Size(970, 559);
            this.pnlUtama.TabIndex = 19;
            // 
            // txtHargaBeli
            // 
            this.txtHargaBeli.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHargaBeli.Location = new System.Drawing.Point(159, 253);
            this.txtHargaBeli.MaxLength = 100;
            this.txtHargaBeli.Name = "txtHargaBeli";
            this.txtHargaBeli.Size = new System.Drawing.Size(165, 26);
            this.txtHargaBeli.TabIndex = 14;
            this.txtHargaBeli.Text = "0.00";
            this.txtHargaBeli.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHargaBeli.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHargaBeli_KeyPress);
            this.txtHargaBeli.Leave += new System.EventHandler(this.txtHargaBeli_Leave);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(12, 257);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(138, 18);
            this.label16.TabIndex = 75;
            this.label16.Text = "Harga Beli Satuan";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 354);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 18);
            this.label11.TabIndex = 73;
            this.label11.Text = "Stok Rupiah";
            this.label11.Visible = false;
            // 
            // lblStokRupiah
            // 
            this.lblStokRupiah.AutoSize = true;
            this.lblStokRupiah.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStokRupiah.Location = new System.Drawing.Point(156, 354);
            this.lblStokRupiah.Name = "lblStokRupiah";
            this.lblStokRupiah.Size = new System.Drawing.Size(36, 18);
            this.lblStokRupiah.TabIndex = 72;
            this.lblStokRupiah.Text = "0.00";
            this.lblStokRupiah.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 323);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 18);
            this.label12.TabIndex = 71;
            this.label12.Text = "Stok Gudang";
            // 
            // lblStokTersedia
            // 
            this.lblStokTersedia.AutoSize = true;
            this.lblStokTersedia.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStokTersedia.Location = new System.Drawing.Point(156, 323);
            this.lblStokTersedia.Name = "lblStokTersedia";
            this.lblStokTersedia.Size = new System.Drawing.Size(36, 18);
            this.lblStokTersedia.TabIndex = 70;
            this.lblStokTersedia.Text = "0.00";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkNonAktif);
            this.panel2.Location = new System.Drawing.Point(544, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(182, 38);
            this.panel2.TabIndex = 68;
            this.panel2.Visible = false;
            // 
            // chkNonAktif
            // 
            this.chkNonAktif.AutoSize = true;
            this.chkNonAktif.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNonAktif.Location = new System.Drawing.Point(3, 15);
            this.chkNonAktif.Name = "chkNonAktif";
            this.chkNonAktif.Size = new System.Drawing.Size(178, 22);
            this.chkNonAktif.TabIndex = 20;
            this.chkNonAktif.Text = "Non Aktifkan Barang";
            this.chkNonAktif.UseVisualStyleBackColor = true;
            this.chkNonAktif.Visible = false;
            // 
            // cboSatuanStokMin
            // 
            this.cboSatuanStokMin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSatuanStokMin.FormattingEnabled = true;
            this.cboSatuanStokMin.Location = new System.Drawing.Point(486, 353);
            this.cboSatuanStokMin.Name = "cboSatuanStokMin";
            this.cboSatuanStokMin.Size = new System.Drawing.Size(208, 25);
            this.cboSatuanStokMin.TabIndex = 14;
            this.cboSatuanStokMin.Visible = false;
            this.cboSatuanStokMin.Click += new System.EventHandler(this.cboSatuanStokMin_Click);
            this.cboSatuanStokMin.Enter += new System.EventHandler(this.cboSatuanStokMin_Enter);
            // 
            // lblJualSatuan3
            // 
            this.lblJualSatuan3.AutoSize = true;
            this.lblJualSatuan3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJualSatuan3.Location = new System.Drawing.Point(657, 261);
            this.lblJualSatuan3.Name = "lblJualSatuan3";
            this.lblJualSatuan3.Size = new System.Drawing.Size(70, 18);
            this.lblJualSatuan3.TabIndex = 65;
            this.lblJualSatuan3.Text = "Satuan 3";
            this.lblJualSatuan3.Visible = false;
            // 
            // lblJualSatuan2
            // 
            this.lblJualSatuan2.AutoSize = true;
            this.lblJualSatuan2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJualSatuan2.Location = new System.Drawing.Point(657, 197);
            this.lblJualSatuan2.Name = "lblJualSatuan2";
            this.lblJualSatuan2.Size = new System.Drawing.Size(70, 18);
            this.lblJualSatuan2.TabIndex = 64;
            this.lblJualSatuan2.Text = "Satuan 2";
            this.lblJualSatuan2.Visible = false;
            // 
            // lblJualSatuan1
            // 
            this.lblJualSatuan1.AutoSize = true;
            this.lblJualSatuan1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJualSatuan1.Location = new System.Drawing.Point(483, 382);
            this.lblJualSatuan1.Name = "lblJualSatuan1";
            this.lblJualSatuan1.Size = new System.Drawing.Size(70, 18);
            this.lblJualSatuan1.TabIndex = 63;
            this.lblJualSatuan1.Text = "Satuan 1";
            this.lblJualSatuan1.Visible = false;
            // 
            // lblJualSatuan5
            // 
            this.lblJualSatuan5.AutoSize = true;
            this.lblJualSatuan5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJualSatuan5.Location = new System.Drawing.Point(657, 325);
            this.lblJualSatuan5.Name = "lblJualSatuan5";
            this.lblJualSatuan5.Size = new System.Drawing.Size(70, 18);
            this.lblJualSatuan5.TabIndex = 62;
            this.lblJualSatuan5.Text = "Satuan 5";
            this.lblJualSatuan5.Visible = false;
            // 
            // txtHargaJual5
            // 
            this.txtHargaJual5.Enabled = false;
            this.txtHargaJual5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHargaJual5.Location = new System.Drawing.Point(486, 321);
            this.txtHargaJual5.MaxLength = 100;
            this.txtHargaJual5.Name = "txtHargaJual5";
            this.txtHargaJual5.Size = new System.Drawing.Size(165, 26);
            this.txtHargaJual5.TabIndex = 19;
            this.txtHargaJual5.Text = "0.00";
            this.txtHargaJual5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHargaJual5.Visible = false;
            this.txtHargaJual5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHargaJual5_KeyPress);
            this.txtHargaJual5.Leave += new System.EventHandler(this.txtHargaJual5_Leave);
            // 
            // txtHargaJual4
            // 
            this.txtHargaJual4.Enabled = false;
            this.txtHargaJual4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHargaJual4.Location = new System.Drawing.Point(486, 289);
            this.txtHargaJual4.MaxLength = 100;
            this.txtHargaJual4.Name = "txtHargaJual4";
            this.txtHargaJual4.Size = new System.Drawing.Size(165, 26);
            this.txtHargaJual4.TabIndex = 18;
            this.txtHargaJual4.Text = "0.00";
            this.txtHargaJual4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHargaJual4.Visible = false;
            this.txtHargaJual4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHargaJual4_KeyPress);
            this.txtHargaJual4.Leave += new System.EventHandler(this.txtHargaJual4_Leave);
            // 
            // txtHargaJual3
            // 
            this.txtHargaJual3.Enabled = false;
            this.txtHargaJual3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHargaJual3.Location = new System.Drawing.Point(486, 257);
            this.txtHargaJual3.MaxLength = 100;
            this.txtHargaJual3.Name = "txtHargaJual3";
            this.txtHargaJual3.Size = new System.Drawing.Size(165, 26);
            this.txtHargaJual3.TabIndex = 17;
            this.txtHargaJual3.Text = "0.00";
            this.txtHargaJual3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHargaJual3.Visible = false;
            this.txtHargaJual3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHargaJual3_KeyPress);
            this.txtHargaJual3.Leave += new System.EventHandler(this.txtHargaJual3_Leave);
            // 
            // txtHargaJual2
            // 
            this.txtHargaJual2.Enabled = false;
            this.txtHargaJual2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHargaJual2.Location = new System.Drawing.Point(486, 193);
            this.txtHargaJual2.MaxLength = 100;
            this.txtHargaJual2.Name = "txtHargaJual2";
            this.txtHargaJual2.Size = new System.Drawing.Size(165, 26);
            this.txtHargaJual2.TabIndex = 16;
            this.txtHargaJual2.Text = "0.00";
            this.txtHargaJual2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHargaJual2.Visible = false;
            this.txtHargaJual2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHargaJual2_KeyPress);
            this.txtHargaJual2.Leave += new System.EventHandler(this.txtHargaJual2_Leave);
            // 
            // lblJualSatuan4
            // 
            this.lblJualSatuan4.AutoSize = true;
            this.lblJualSatuan4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJualSatuan4.Location = new System.Drawing.Point(657, 293);
            this.lblJualSatuan4.Name = "lblJualSatuan4";
            this.lblJualSatuan4.Size = new System.Drawing.Size(70, 18);
            this.lblJualSatuan4.TabIndex = 57;
            this.lblJualSatuan4.Text = "Satuan 4";
            this.lblJualSatuan4.Visible = false;
            // 
            // lblSatuan5
            // 
            this.lblSatuan5.AutoSize = true;
            this.lblSatuan5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSatuan5.Location = new System.Drawing.Point(763, 513);
            this.lblSatuan5.Name = "lblSatuan5";
            this.lblSatuan5.Size = new System.Drawing.Size(70, 18);
            this.lblSatuan5.TabIndex = 56;
            this.lblSatuan5.Text = "Satuan 5";
            this.lblSatuan5.Visible = false;
            // 
            // lblSatuan4
            // 
            this.lblSatuan4.AutoSize = true;
            this.lblSatuan4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSatuan4.Location = new System.Drawing.Point(763, 481);
            this.lblSatuan4.Name = "lblSatuan4";
            this.lblSatuan4.Size = new System.Drawing.Size(70, 18);
            this.lblSatuan4.TabIndex = 55;
            this.lblSatuan4.Text = "Satuan 4";
            this.lblSatuan4.Visible = false;
            // 
            // txtQtySatuan5
            // 
            this.txtQtySatuan5.Enabled = false;
            this.txtQtySatuan5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQtySatuan5.Location = new System.Drawing.Point(671, 509);
            this.txtQtySatuan5.MaxLength = 100;
            this.txtQtySatuan5.Name = "txtQtySatuan5";
            this.txtQtySatuan5.Size = new System.Drawing.Size(86, 26);
            this.txtQtySatuan5.TabIndex = 12;
            this.txtQtySatuan5.Text = "0.00";
            this.txtQtySatuan5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtySatuan5.Visible = false;
            this.txtQtySatuan5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQtySatuan5_KeyPress);
            this.txtQtySatuan5.Leave += new System.EventHandler(this.txtQtySatuan5_Leave);
            // 
            // txtQtySatuan4
            // 
            this.txtQtySatuan4.Enabled = false;
            this.txtQtySatuan4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQtySatuan4.Location = new System.Drawing.Point(671, 477);
            this.txtQtySatuan4.MaxLength = 100;
            this.txtQtySatuan4.Name = "txtQtySatuan4";
            this.txtQtySatuan4.Size = new System.Drawing.Size(86, 26);
            this.txtQtySatuan4.TabIndex = 10;
            this.txtQtySatuan4.Text = "0.00";
            this.txtQtySatuan4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtySatuan4.Visible = false;
            this.txtQtySatuan4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQtySatuan4_KeyPress);
            this.txtQtySatuan4.Leave += new System.EventHandler(this.txtQtySatuan4_Leave);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(648, 513);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 18);
            this.label14.TabIndex = 52;
            this.label14.Text = "=";
            this.label14.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(648, 481);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(17, 18);
            this.label15.TabIndex = 51;
            this.label15.Text = "=";
            this.label15.Visible = false;
            // 
            // txtSatuan5
            // 
            this.txtSatuan5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSatuan5.Enabled = false;
            this.txtSatuan5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSatuan5.Location = new System.Drawing.Point(477, 509);
            this.txtSatuan5.MaxLength = 100;
            this.txtSatuan5.Name = "txtSatuan5";
            this.txtSatuan5.Size = new System.Drawing.Size(165, 26);
            this.txtSatuan5.TabIndex = 11;
            this.txtSatuan5.Visible = false;
            this.txtSatuan5.TextChanged += new System.EventHandler(this.txtSatuan5_TextChanged);
            this.txtSatuan5.Leave += new System.EventHandler(this.txtSatuan5_Leave);
            // 
            // txtSatuan4
            // 
            this.txtSatuan4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSatuan4.Enabled = false;
            this.txtSatuan4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSatuan4.Location = new System.Drawing.Point(477, 477);
            this.txtSatuan4.MaxLength = 100;
            this.txtSatuan4.Name = "txtSatuan4";
            this.txtSatuan4.Size = new System.Drawing.Size(165, 26);
            this.txtSatuan4.TabIndex = 9;
            this.txtSatuan4.Visible = false;
            this.txtSatuan4.TextChanged += new System.EventHandler(this.txtSatuan4_TextChanged);
            this.txtSatuan4.Leave += new System.EventHandler(this.txtSatuan4_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 18);
            this.label3.TabIndex = 48;
            this.label3.Text = "Kategori";
            // 
            // cboKategori
            // 
            this.cboKategori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKategori.FormattingEnabled = true;
            this.cboKategori.Location = new System.Drawing.Point(159, 76);
            this.cboKategori.Name = "cboKategori";
            this.cboKategori.Size = new System.Drawing.Size(379, 25);
            this.cboKategori.TabIndex = 2;
            // 
            // txtStokMin
            // 
            this.txtStokMin.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStokMin.Location = new System.Drawing.Point(159, 221);
            this.txtStokMin.MaxLength = 100;
            this.txtStokMin.Name = "txtStokMin";
            this.txtStokMin.Size = new System.Drawing.Size(165, 26);
            this.txtStokMin.TabIndex = 13;
            this.txtStokMin.Text = "0.00";
            this.txtStokMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtStokMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStokMin_KeyPress);
            this.txtStokMin.Leave += new System.EventHandler(this.txtStokMin_Leave);
            // 
            // lblSatuan3
            // 
            this.lblSatuan3.AutoSize = true;
            this.lblSatuan3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSatuan3.Location = new System.Drawing.Point(763, 449);
            this.lblSatuan3.Name = "lblSatuan3";
            this.lblSatuan3.Size = new System.Drawing.Size(70, 18);
            this.lblSatuan3.TabIndex = 45;
            this.lblSatuan3.Text = "Satuan 3";
            this.lblSatuan3.Visible = false;
            // 
            // lblSatuan2
            // 
            this.lblSatuan2.AutoSize = true;
            this.lblSatuan2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSatuan2.Location = new System.Drawing.Point(772, 229);
            this.lblSatuan2.Name = "lblSatuan2";
            this.lblSatuan2.Size = new System.Drawing.Size(70, 18);
            this.lblSatuan2.TabIndex = 44;
            this.lblSatuan2.Text = "Satuan 2";
            this.lblSatuan2.Visible = false;
            // 
            // txtQtySatuan3
            // 
            this.txtQtySatuan3.Enabled = false;
            this.txtQtySatuan3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQtySatuan3.Location = new System.Drawing.Point(671, 445);
            this.txtQtySatuan3.MaxLength = 100;
            this.txtQtySatuan3.Name = "txtQtySatuan3";
            this.txtQtySatuan3.Size = new System.Drawing.Size(86, 26);
            this.txtQtySatuan3.TabIndex = 8;
            this.txtQtySatuan3.Text = "0.00";
            this.txtQtySatuan3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtySatuan3.Visible = false;
            this.txtQtySatuan3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQtySatuan3_KeyPress);
            this.txtQtySatuan3.Leave += new System.EventHandler(this.txtQtySatuan3_Leave);
            // 
            // txtQtySatuan2
            // 
            this.txtQtySatuan2.Enabled = false;
            this.txtQtySatuan2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQtySatuan2.Location = new System.Drawing.Point(680, 225);
            this.txtQtySatuan2.MaxLength = 100;
            this.txtQtySatuan2.Name = "txtQtySatuan2";
            this.txtQtySatuan2.Size = new System.Drawing.Size(86, 26);
            this.txtQtySatuan2.TabIndex = 6;
            this.txtQtySatuan2.Text = "0.00";
            this.txtQtySatuan2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtySatuan2.Visible = false;
            this.txtQtySatuan2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQtySatuan2_KeyPress);
            this.txtQtySatuan2.Leave += new System.EventHandler(this.txtQtySatuan2_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(648, 449);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 18);
            this.label10.TabIndex = 41;
            this.label10.Text = "=";
            this.label10.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(657, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 18);
            this.label1.TabIndex = 40;
            this.label1.Text = "=";
            this.label1.Visible = false;
            // 
            // Barang
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(970, 559);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlUtama);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Barang";
            this.Text = "Barang";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Barang_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Barang_KeyPress);
            this.panel1.ResumeLayout(false);
            this.pnlUtama.ResumeLayout(false);
            this.pnlUtama.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKeluar;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnBaru;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCetak;
        private System.Windows.Forms.TextBox txtCatatan;
        private System.Windows.Forms.TextBox txtHargaJual1;
        private System.Windows.Forms.TextBox txtSatuan3;
        private System.Windows.Forms.TextBox txtSatuan2;
        private System.Windows.Forms.TextBox txtSatuan1;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.TextBox txtKodeBarcode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlUtama;
        private System.Windows.Forms.TextBox txtStokMin;
        private System.Windows.Forms.Label lblSatuan3;
        private System.Windows.Forms.Label lblSatuan2;
        private System.Windows.Forms.TextBox txtQtySatuan3;
        private System.Windows.Forms.TextBox txtQtySatuan2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private cmp.UpperComboBox cboKategori;
        private System.Windows.Forms.Label lblJualSatuan3;
        private System.Windows.Forms.Label lblJualSatuan2;
        private System.Windows.Forms.Label lblJualSatuan1;
        private System.Windows.Forms.Label lblJualSatuan5;
        private System.Windows.Forms.TextBox txtHargaJual5;
        private System.Windows.Forms.TextBox txtHargaJual4;
        private System.Windows.Forms.TextBox txtHargaJual3;
        private System.Windows.Forms.TextBox txtHargaJual2;
        private System.Windows.Forms.Label lblJualSatuan4;
        private System.Windows.Forms.Label lblSatuan5;
        private System.Windows.Forms.Label lblSatuan4;
        private System.Windows.Forms.TextBox txtQtySatuan5;
        private System.Windows.Forms.TextBox txtQtySatuan4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtSatuan5;
        private System.Windows.Forms.TextBox txtSatuan4;
        private System.Windows.Forms.Label label3;
        private cmp.UpperComboBox cboSatuanStokMin;
        private System.Windows.Forms.CheckBox chkNonAktif;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblStokTersedia;
        private System.Windows.Forms.TextBox txtHargaBeli;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblStokRupiah;
    }
}