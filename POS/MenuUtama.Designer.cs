namespace POS
{
    partial class MenuUtama
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuUtama));
            this.pnlSideBar = new System.Windows.Forms.Panel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnDatabase = new System.Windows.Forms.Button();
            this.btnPengaturan = new System.Windows.Forms.Button();
            this.btnLaporan = new System.Windows.Forms.Button();
            this.pnlCursor = new System.Windows.Forms.Panel();
            this.btnTransaksi = new System.Windows.Forms.Button();
            this.btnMasterData = new System.Windows.Forms.Button();
            this.pnlProfile = new System.Windows.Forms.Panel();
            this.btnSignInOut = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnHide = new System.Windows.Forms.Button();
            this.lblNamaPengguna = new System.Windows.Forms.Label();
            this.lblPosisi = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlFoto = new System.Windows.Forms.Panel();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.pnlClose = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnMin = new System.Windows.Forms.Button();
            this.lblNamaForm = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlUtama = new System.Windows.Forms.Panel();
            this.timerSideBar = new System.Windows.Forms.Timer(this.components);
            this.timerDate = new System.Windows.Forms.Timer(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlSideBar.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlProfile.SuspendLayout();
            this.pnlTopBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlClose.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSideBar
            // 
            this.pnlSideBar.Controls.Add(this.pnlMenu);
            this.pnlSideBar.Controls.Add(this.pnlProfile);
            this.pnlSideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSideBar.Location = new System.Drawing.Point(0, 0);
            this.pnlSideBar.Name = "pnlSideBar";
            this.pnlSideBar.Size = new System.Drawing.Size(190, 720);
            this.pnlSideBar.TabIndex = 0;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.Teal;
            this.pnlMenu.Controls.Add(this.btnDatabase);
            this.pnlMenu.Controls.Add(this.btnPengaturan);
            this.pnlMenu.Controls.Add(this.btnLaporan);
            this.pnlMenu.Controls.Add(this.pnlCursor);
            this.pnlMenu.Controls.Add(this.btnTransaksi);
            this.pnlMenu.Controls.Add(this.btnMasterData);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenu.Location = new System.Drawing.Point(0, 198);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(190, 522);
            this.pnlMenu.TabIndex = 1;
            // 
            // btnDatabase
            // 
            this.btnDatabase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDatabase.Enabled = false;
            this.btnDatabase.FlatAppearance.BorderSize = 0;
            this.btnDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatabase.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDatabase.ForeColor = System.Drawing.Color.White;
            this.btnDatabase.Image = ((System.Drawing.Image)(resources.GetObject("btnDatabase.Image")));
            this.btnDatabase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDatabase.Location = new System.Drawing.Point(9, 270);
            this.btnDatabase.Name = "btnDatabase";
            this.btnDatabase.Size = new System.Drawing.Size(178, 60);
            this.btnDatabase.TabIndex = 10;
            this.btnDatabase.Text = "      Database";
            this.btnDatabase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDatabase.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDatabase.UseVisualStyleBackColor = true;
            this.btnDatabase.Visible = false;
            this.btnDatabase.Click += new System.EventHandler(this.btnDatabase_Click);
            // 
            // btnPengaturan
            // 
            this.btnPengaturan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPengaturan.Enabled = false;
            this.btnPengaturan.FlatAppearance.BorderSize = 0;
            this.btnPengaturan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPengaturan.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPengaturan.ForeColor = System.Drawing.Color.White;
            this.btnPengaturan.Image = ((System.Drawing.Image)(resources.GetObject("btnPengaturan.Image")));
            this.btnPengaturan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPengaturan.Location = new System.Drawing.Point(9, 204);
            this.btnPengaturan.Name = "btnPengaturan";
            this.btnPengaturan.Size = new System.Drawing.Size(178, 60);
            this.btnPengaturan.TabIndex = 9;
            this.btnPengaturan.Text = "      Pengaturan";
            this.btnPengaturan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPengaturan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPengaturan.UseVisualStyleBackColor = true;
            this.btnPengaturan.Click += new System.EventHandler(this.btnPengaturan_Click);
            // 
            // btnLaporan
            // 
            this.btnLaporan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLaporan.Enabled = false;
            this.btnLaporan.FlatAppearance.BorderSize = 0;
            this.btnLaporan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLaporan.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaporan.ForeColor = System.Drawing.Color.White;
            this.btnLaporan.Image = ((System.Drawing.Image)(resources.GetObject("btnLaporan.Image")));
            this.btnLaporan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLaporan.Location = new System.Drawing.Point(9, 138);
            this.btnLaporan.Name = "btnLaporan";
            this.btnLaporan.Size = new System.Drawing.Size(178, 60);
            this.btnLaporan.TabIndex = 8;
            this.btnLaporan.Text = "      Laporan";
            this.btnLaporan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLaporan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLaporan.UseVisualStyleBackColor = true;
            this.btnLaporan.Click += new System.EventHandler(this.btnLaporan_Click);
            // 
            // pnlCursor
            // 
            this.pnlCursor.BackColor = System.Drawing.Color.White;
            this.pnlCursor.Location = new System.Drawing.Point(0, 6);
            this.pnlCursor.Name = "pnlCursor";
            this.pnlCursor.Size = new System.Drawing.Size(7, 60);
            this.pnlCursor.TabIndex = 5;
            // 
            // btnTransaksi
            // 
            this.btnTransaksi.BackColor = System.Drawing.Color.Teal;
            this.btnTransaksi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTransaksi.Enabled = false;
            this.btnTransaksi.FlatAppearance.BorderSize = 0;
            this.btnTransaksi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransaksi.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransaksi.ForeColor = System.Drawing.Color.White;
            this.btnTransaksi.Image = ((System.Drawing.Image)(resources.GetObject("btnTransaksi.Image")));
            this.btnTransaksi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransaksi.Location = new System.Drawing.Point(9, 72);
            this.btnTransaksi.Name = "btnTransaksi";
            this.btnTransaksi.Size = new System.Drawing.Size(178, 60);
            this.btnTransaksi.TabIndex = 1;
            this.btnTransaksi.Text = "      Transaksi";
            this.btnTransaksi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransaksi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTransaksi.UseVisualStyleBackColor = true;
            this.btnTransaksi.Click += new System.EventHandler(this.btnTransaksi_Click);
            // 
            // btnMasterData
            // 
            this.btnMasterData.BackColor = System.Drawing.Color.Teal;
            this.btnMasterData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMasterData.Enabled = false;
            this.btnMasterData.FlatAppearance.BorderSize = 0;
            this.btnMasterData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMasterData.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMasterData.ForeColor = System.Drawing.Color.White;
            this.btnMasterData.Image = ((System.Drawing.Image)(resources.GetObject("btnMasterData.Image")));
            this.btnMasterData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMasterData.Location = new System.Drawing.Point(9, 6);
            this.btnMasterData.Name = "btnMasterData";
            this.btnMasterData.Size = new System.Drawing.Size(178, 60);
            this.btnMasterData.TabIndex = 0;
            this.btnMasterData.Text = "      Master Data";
            this.btnMasterData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMasterData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMasterData.UseVisualStyleBackColor = true;
            this.btnMasterData.Click += new System.EventHandler(this.btnMasterData_Click);
            // 
            // pnlProfile
            // 
            this.pnlProfile.BackColor = System.Drawing.Color.Teal;
            this.pnlProfile.Controls.Add(this.btnSignInOut);
            this.pnlProfile.Controls.Add(this.btnHide);
            this.pnlProfile.Controls.Add(this.lblNamaPengguna);
            this.pnlProfile.Controls.Add(this.lblPosisi);
            this.pnlProfile.Controls.Add(this.label2);
            this.pnlProfile.Controls.Add(this.pnlFoto);
            this.pnlProfile.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProfile.Location = new System.Drawing.Point(0, 0);
            this.pnlProfile.Name = "pnlProfile";
            this.pnlProfile.Size = new System.Drawing.Size(190, 198);
            this.pnlProfile.TabIndex = 1;
            // 
            // btnSignInOut
            // 
            this.btnSignInOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSignInOut.FlatAppearance.BorderSize = 0;
            this.btnSignInOut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnSignInOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.btnSignInOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignInOut.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignInOut.ForeColor = System.Drawing.Color.White;
            this.btnSignInOut.ImageIndex = 1;
            this.btnSignInOut.ImageList = this.imageList1;
            this.btnSignInOut.Location = new System.Drawing.Point(31, 172);
            this.btnSignInOut.Name = "btnSignInOut";
            this.btnSignInOut.Size = new System.Drawing.Size(120, 23);
            this.btnSignInOut.TabIndex = 7;
            this.btnSignInOut.Text = "Sign In";
            this.btnSignInOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSignInOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSignInOut.UseVisualStyleBackColor = true;
            this.btnSignInOut.Click += new System.EventHandler(this.btnSignInOut_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8_Lock_10px.png");
            this.imageList1.Images.SetKeyName(1, "icons8_Padlock_10px.png");
            // 
            // btnHide
            // 
            this.btnHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHide.FlatAppearance.BorderSize = 0;
            this.btnHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHide.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHide.ForeColor = System.Drawing.Color.White;
            this.btnHide.Image = ((System.Drawing.Image)(resources.GetObject("btnHide.Image")));
            this.btnHide.Location = new System.Drawing.Point(167, 3);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(20, 20);
            this.btnHide.TabIndex = 6;
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // lblNamaPengguna
            // 
            this.lblNamaPengguna.ForeColor = System.Drawing.Color.White;
            this.lblNamaPengguna.Location = new System.Drawing.Point(3, 151);
            this.lblNamaPengguna.Name = "lblNamaPengguna";
            this.lblNamaPengguna.Size = new System.Drawing.Size(187, 18);
            this.lblNamaPengguna.TabIndex = 1;
            this.lblNamaPengguna.Text = "label1";
            this.lblNamaPengguna.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPosisi
            // 
            this.lblPosisi.ForeColor = System.Drawing.Color.White;
            this.lblPosisi.Location = new System.Drawing.Point(3, 27);
            this.lblPosisi.Name = "lblPosisi";
            this.lblPosisi.Size = new System.Drawing.Size(181, 18);
            this.lblPosisi.TabIndex = 2;
            this.lblPosisi.Text = "label3";
            this.lblPosisi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(31, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Selamat Datang";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlFoto
            // 
            this.pnlFoto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlFoto.BackgroundImage")));
            this.pnlFoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlFoto.Location = new System.Drawing.Point(31, 48);
            this.pnlFoto.Name = "pnlFoto";
            this.pnlFoto.Size = new System.Drawing.Size(120, 100);
            this.pnlFoto.TabIndex = 1;
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.Controls.Add(this.panel1);
            this.pnlTopBar.Controls.Add(this.pnlClose);
            this.pnlTopBar.Controls.Add(this.lblNamaForm);
            this.pnlTopBar.Controls.Add(this.label4);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(190, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(1010, 39);
            this.pnlTopBar.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(660, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(287, 39);
            this.panel1.TabIndex = 8;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.Teal;
            this.lblTime.Location = new System.Drawing.Point(164, 3);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(112, 25);
            this.lblTime.TabIndex = 6;
            this.lblTime.Text = "HH:MM:SS";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.Teal;
            this.lblDate.Location = new System.Drawing.Point(3, 3);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(169, 25);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "DD-MMM-YYYY";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlClose
            // 
            this.pnlClose.Controls.Add(this.btnExit);
            this.pnlClose.Controls.Add(this.btnMin);
            this.pnlClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlClose.Location = new System.Drawing.Point(947, 0);
            this.pnlClose.Name = "pnlClose";
            this.pnlClose.Size = new System.Drawing.Size(63, 39);
            this.pnlClose.TabIndex = 7;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(30, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(29, 29);
            this.btnExit.TabIndex = 1;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMin
            // 
            this.btnMin.BackColor = System.Drawing.Color.Transparent;
            this.btnMin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMin.BackgroundImage")));
            this.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMin.FlatAppearance.BorderSize = 0;
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.Location = new System.Drawing.Point(3, 2);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(29, 29);
            this.btnMin.TabIndex = 0;
            this.btnMin.UseVisualStyleBackColor = false;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // lblNamaForm
            // 
            this.lblNamaForm.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamaForm.ForeColor = System.Drawing.Color.Teal;
            this.lblNamaForm.Location = new System.Drawing.Point(130, 3);
            this.lblNamaForm.Name = "lblNamaForm";
            this.lblNamaForm.Size = new System.Drawing.Size(346, 25);
            this.lblNamaForm.TabIndex = 4;
            this.lblNamaForm.Text = "Nama Form";
            this.lblNamaForm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Teal;
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(313, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Point Of Sales";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlUtama
            // 
            this.pnlUtama.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUtama.Location = new System.Drawing.Point(190, 39);
            this.pnlUtama.Name = "pnlUtama";
            this.pnlUtama.Size = new System.Drawing.Size(1010, 681);
            this.pnlUtama.TabIndex = 2;
            // 
            // timerSideBar
            // 
            this.timerSideBar.Interval = 5;
            this.timerSideBar.Tick += new System.EventHandler(this.timerSideBar_Tick);
            // 
            // timerDate
            // 
            this.timerDate.Enabled = true;
            this.timerDate.Tick += new System.EventHandler(this.timerDate_Tick);
            // 
            // toolTip2
            // 
            this.toolTip2.BackColor = System.Drawing.Color.MediumAquamarine;
            this.toolTip2.ForeColor = System.Drawing.Color.White;
            // 
            // MenuUtama
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.pnlUtama);
            this.Controls.Add(this.pnlTopBar);
            this.Controls.Add(this.pnlSideBar);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MenuUtama";
            this.Text = "MenuUtama";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuUtama_FormClosing);
            this.Load += new System.EventHandler(this.MenuUtama_Load);
            this.pnlSideBar.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.pnlProfile.ResumeLayout(false);
            this.pnlTopBar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlClose.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSideBar;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlProfile;
        private System.Windows.Forms.Panel pnlFoto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Timer timerSideBar;
        private System.Windows.Forms.Timer timerDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Panel pnlClose;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Panel pnlUtama;
        public System.Windows.Forms.Label lblNamaForm;
        public System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.Panel pnlCursor;
        public System.Windows.Forms.Button btnMasterData;
        public System.Windows.Forms.Button btnTransaksi;
        public System.Windows.Forms.Button btnDatabase;
        public System.Windows.Forms.Button btnPengaturan;
        public System.Windows.Forms.Button btnLaporan;
        public System.Windows.Forms.Label lblNamaPengguna;
        public System.Windows.Forms.Label lblPosisi;
        public System.Windows.Forms.Button btnSignInOut;
        public System.Windows.Forms.ImageList imageList1;
    }
}