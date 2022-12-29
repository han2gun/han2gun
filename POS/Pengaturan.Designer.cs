namespace POS
{
    partial class Pengaturan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pengaturan));
            this.pnlUtama = new System.Windows.Forms.Panel();
            this.pnKaryawan = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lblUsrMgmt = new System.Windows.Forms.Label();
            this.pbUsrMgmt = new System.Windows.Forms.PictureBox();
            this.btnUsrMgmt = new System.Windows.Forms.Button();
            this.pnPemasok = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUbahPass = new System.Windows.Forms.Label();
            this.pbUbahPass = new System.Windows.Forms.PictureBox();
            this.btnUbahPass = new System.Windows.Forms.Button();
            this.pnlUtama.SuspendLayout();
            this.pnKaryawan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUsrMgmt)).BeginInit();
            this.pnPemasok.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUbahPass)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlUtama
            // 
            this.pnlUtama.Controls.Add(this.pnKaryawan);
            this.pnlUtama.Controls.Add(this.pnPemasok);
            this.pnlUtama.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUtama.Location = new System.Drawing.Point(0, 0);
            this.pnlUtama.Name = "pnlUtama";
            this.pnlUtama.Size = new System.Drawing.Size(888, 542);
            this.pnlUtama.TabIndex = 0;
            // 
            // pnKaryawan
            // 
            this.pnKaryawan.BackColor = System.Drawing.Color.Silver;
            this.pnKaryawan.Controls.Add(this.label5);
            this.pnKaryawan.Controls.Add(this.lblUsrMgmt);
            this.pnKaryawan.Controls.Add(this.pbUsrMgmt);
            this.pnKaryawan.Controls.Add(this.btnUsrMgmt);
            this.pnKaryawan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnKaryawan.Location = new System.Drawing.Point(12, 12);
            this.pnKaryawan.Name = "pnKaryawan";
            this.pnKaryawan.Size = new System.Drawing.Size(161, 221);
            this.pnKaryawan.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 40);
            this.label5.TabIndex = 1;
            this.label5.Text = "Berisi detail data pengaturan pengguna";
            // 
            // lblUsrMgmt
            // 
            this.lblUsrMgmt.BackColor = System.Drawing.Color.Teal;
            this.lblUsrMgmt.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsrMgmt.ForeColor = System.Drawing.Color.White;
            this.lblUsrMgmt.Location = new System.Drawing.Point(3, 4);
            this.lblUsrMgmt.Name = "lblUsrMgmt";
            this.lblUsrMgmt.Size = new System.Drawing.Size(155, 26);
            this.lblUsrMgmt.TabIndex = 1;
            this.lblUsrMgmt.Text = "PENGATURAN PENGGUNA";
            this.lblUsrMgmt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbUsrMgmt
            // 
            this.pbUsrMgmt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbUsrMgmt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbUsrMgmt.Image = ((System.Drawing.Image)(resources.GetObject("pbUsrMgmt.Image")));
            this.pbUsrMgmt.Location = new System.Drawing.Point(3, 33);
            this.pbUsrMgmt.Name = "pbUsrMgmt";
            this.pbUsrMgmt.Size = new System.Drawing.Size(155, 116);
            this.pbUsrMgmt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUsrMgmt.TabIndex = 1;
            this.pbUsrMgmt.TabStop = false;
            // 
            // btnUsrMgmt
            // 
            this.btnUsrMgmt.BackColor = System.Drawing.Color.Teal;
            this.btnUsrMgmt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsrMgmt.Enabled = false;
            this.btnUsrMgmt.FlatAppearance.BorderSize = 0;
            this.btnUsrMgmt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsrMgmt.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsrMgmt.ForeColor = System.Drawing.Color.White;
            this.btnUsrMgmt.Location = new System.Drawing.Point(3, 195);
            this.btnUsrMgmt.Name = "btnUsrMgmt";
            this.btnUsrMgmt.Size = new System.Drawing.Size(155, 23);
            this.btnUsrMgmt.TabIndex = 1;
            this.btnUsrMgmt.Text = "Buat Data";
            this.btnUsrMgmt.UseVisualStyleBackColor = false;
            this.btnUsrMgmt.Click += new System.EventHandler(this.btnUsrMgmt_Click);
            // 
            // pnPemasok
            // 
            this.pnPemasok.BackColor = System.Drawing.Color.Silver;
            this.pnPemasok.Controls.Add(this.label3);
            this.pnPemasok.Controls.Add(this.lblUbahPass);
            this.pnPemasok.Controls.Add(this.pbUbahPass);
            this.pnPemasok.Controls.Add(this.btnUbahPass);
            this.pnPemasok.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnPemasok.Location = new System.Drawing.Point(179, 12);
            this.pnPemasok.Name = "pnPemasok";
            this.pnPemasok.Size = new System.Drawing.Size(161, 221);
            this.pnPemasok.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 40);
            this.label3.TabIndex = 1;
            this.label3.Text = "Menu untuk melakukan perubahan password";
            // 
            // lblUbahPass
            // 
            this.lblUbahPass.BackColor = System.Drawing.Color.Teal;
            this.lblUbahPass.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUbahPass.ForeColor = System.Drawing.Color.White;
            this.lblUbahPass.Location = new System.Drawing.Point(3, 4);
            this.lblUbahPass.Name = "lblUbahPass";
            this.lblUbahPass.Size = new System.Drawing.Size(155, 26);
            this.lblUbahPass.TabIndex = 1;
            this.lblUbahPass.Text = "UBAH PASSWORD";
            this.lblUbahPass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbUbahPass
            // 
            this.pbUbahPass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbUbahPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbUbahPass.Image = ((System.Drawing.Image)(resources.GetObject("pbUbahPass.Image")));
            this.pbUbahPass.Location = new System.Drawing.Point(3, 33);
            this.pbUbahPass.Name = "pbUbahPass";
            this.pbUbahPass.Size = new System.Drawing.Size(155, 116);
            this.pbUbahPass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUbahPass.TabIndex = 1;
            this.pbUbahPass.TabStop = false;
            // 
            // btnUbahPass
            // 
            this.btnUbahPass.BackColor = System.Drawing.Color.Teal;
            this.btnUbahPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUbahPass.FlatAppearance.BorderSize = 0;
            this.btnUbahPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUbahPass.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUbahPass.ForeColor = System.Drawing.Color.White;
            this.btnUbahPass.Location = new System.Drawing.Point(3, 195);
            this.btnUbahPass.Name = "btnUbahPass";
            this.btnUbahPass.Size = new System.Drawing.Size(155, 23);
            this.btnUbahPass.TabIndex = 1;
            this.btnUbahPass.Text = "Buat Data";
            this.btnUbahPass.UseVisualStyleBackColor = false;
            this.btnUbahPass.Click += new System.EventHandler(this.btnUbahPass_Click);
            // 
            // Pengaturan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(888, 542);
            this.Controls.Add(this.pnlUtama);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Pengaturan";
            this.Text = "Pengaturan";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Pengaturan_Load);
            this.pnlUtama.ResumeLayout(false);
            this.pnKaryawan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbUsrMgmt)).EndInit();
            this.pnPemasok.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbUbahPass)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlUtama;
        private System.Windows.Forms.Panel pnKaryawan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblUsrMgmt;
        private System.Windows.Forms.PictureBox pbUsrMgmt;
        private System.Windows.Forms.Button btnUsrMgmt;
        private System.Windows.Forms.Panel pnPemasok;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUbahPass;
        private System.Windows.Forms.PictureBox pbUbahPass;
        private System.Windows.Forms.Button btnUbahPass;
    }
}