namespace POS.frm
{
    partial class RestoreDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RestoreDB));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnKeluar = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnOpenLokasi = new System.Windows.Forms.Button();
            this.txtLokasi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnKeluar);
            this.panel1.Controls.Add(this.btnRestore);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(795, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(106, 541);
            this.panel1.TabIndex = 19;
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
            this.btnKeluar.Location = new System.Drawing.Point(3, 89);
            this.btnKeluar.Name = "btnKeluar";
            this.btnKeluar.Size = new System.Drawing.Size(100, 80);
            this.btnKeluar.TabIndex = 12;
            this.btnKeluar.Text = "KELUAR-F10";
            this.btnKeluar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnKeluar.UseVisualStyleBackColor = false;
            this.btnKeluar.Click += new System.EventHandler(this.btnKeluar_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.AccessibleName = "RESTORE";
            this.btnRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestore.BackColor = System.Drawing.Color.White;
            this.btnRestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestore.FlatAppearance.BorderSize = 0;
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestore.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestore.ForeColor = System.Drawing.Color.Black;
            this.btnRestore.Image = ((System.Drawing.Image)(resources.GetObject("btnRestore.Image")));
            this.btnRestore.Location = new System.Drawing.Point(3, 3);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(100, 80);
            this.btnRestore.TabIndex = 9;
            this.btnRestore.Text = "RESTORE-F3";
            this.btnRestore.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnOpenLokasi
            // 
            this.btnOpenLokasi.BackColor = System.Drawing.Color.White;
            this.btnOpenLokasi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenLokasi.FlatAppearance.BorderSize = 0;
            this.btnOpenLokasi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenLokasi.ForeColor = System.Drawing.Color.White;
            this.btnOpenLokasi.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenLokasi.Image")));
            this.btnOpenLokasi.Location = new System.Drawing.Point(509, 4);
            this.btnOpenLokasi.Name = "btnOpenLokasi";
            this.btnOpenLokasi.Size = new System.Drawing.Size(28, 28);
            this.btnOpenLokasi.TabIndex = 18;
            this.btnOpenLokasi.UseVisualStyleBackColor = false;
            this.btnOpenLokasi.Click += new System.EventHandler(this.btnOpenLokasi_Click);
            // 
            // txtLokasi
            // 
            this.txtLokasi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLokasi.Enabled = false;
            this.txtLokasi.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLokasi.Location = new System.Drawing.Point(124, 5);
            this.txtLokasi.MaxLength = 100;
            this.txtLokasi.Name = "txtLokasi";
            this.txtLokasi.Size = new System.Drawing.Size(379, 26);
            this.txtLokasi.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "Lokasi Restore";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(370, 176);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(203, 202);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // RestoreDB
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(901, 541);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnOpenLokasi);
            this.Controls.Add(this.txtLokasi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "RestoreDB";
            this.Text = "RestoreDB";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RestoreDB_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RestoreDB_KeyPress);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnKeluar;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnOpenLokasi;
        private System.Windows.Forms.TextBox txtLokasi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}