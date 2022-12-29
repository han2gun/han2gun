namespace POS
{
    partial class Database
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Database));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRestore = new System.Windows.Forms.Label();
            this.pbRestore = new System.Windows.Forms.PictureBox();
            this.btnRestore = new System.Windows.Forms.Button();
            this.pnPelanggan = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBackup = new System.Windows.Forms.Label();
            this.pbBackup = new System.Windows.Forms.PictureBox();
            this.btnBackup = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRestore)).BeginInit();
            this.pnPelanggan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackup)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblRestore);
            this.panel1.Controls.Add(this.pbRestore);
            this.panel1.Controls.Add(this.btnRestore);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Location = new System.Drawing.Point(179, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(161, 221);
            this.panel1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "Restore Database";
            // 
            // lblRestore
            // 
            this.lblRestore.BackColor = System.Drawing.Color.Teal;
            this.lblRestore.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRestore.ForeColor = System.Drawing.Color.White;
            this.lblRestore.Location = new System.Drawing.Point(3, 4);
            this.lblRestore.Name = "lblRestore";
            this.lblRestore.Size = new System.Drawing.Size(155, 26);
            this.lblRestore.TabIndex = 1;
            this.lblRestore.Text = "RESTORE";
            this.lblRestore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbRestore
            // 
            this.pbRestore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbRestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbRestore.Enabled = false;
            this.pbRestore.Image = ((System.Drawing.Image)(resources.GetObject("pbRestore.Image")));
            this.pbRestore.Location = new System.Drawing.Point(3, 33);
            this.pbRestore.Name = "pbRestore";
            this.pbRestore.Size = new System.Drawing.Size(155, 116);
            this.pbRestore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRestore.TabIndex = 1;
            this.pbRestore.TabStop = false;
            // 
            // btnRestore
            // 
            this.btnRestore.BackColor = System.Drawing.Color.Teal;
            this.btnRestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestore.Enabled = false;
            this.btnRestore.FlatAppearance.BorderSize = 0;
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestore.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestore.ForeColor = System.Drawing.Color.White;
            this.btnRestore.Location = new System.Drawing.Point(3, 195);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(155, 23);
            this.btnRestore.TabIndex = 1;
            this.btnRestore.Text = "Buat Data";
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // pnPelanggan
            // 
            this.pnPelanggan.BackColor = System.Drawing.Color.Silver;
            this.pnPelanggan.Controls.Add(this.label2);
            this.pnPelanggan.Controls.Add(this.lblBackup);
            this.pnPelanggan.Controls.Add(this.pbBackup);
            this.pnPelanggan.Controls.Add(this.btnBackup);
            this.pnPelanggan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnPelanggan.Location = new System.Drawing.Point(12, 12);
            this.pnPelanggan.Name = "pnPelanggan";
            this.pnPelanggan.Size = new System.Drawing.Size(161, 221);
            this.pnPelanggan.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 40);
            this.label2.TabIndex = 1;
            this.label2.Text = "Backup Database";
            // 
            // lblBackup
            // 
            this.lblBackup.BackColor = System.Drawing.Color.Teal;
            this.lblBackup.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackup.ForeColor = System.Drawing.Color.White;
            this.lblBackup.Location = new System.Drawing.Point(3, 4);
            this.lblBackup.Name = "lblBackup";
            this.lblBackup.Size = new System.Drawing.Size(155, 26);
            this.lblBackup.TabIndex = 1;
            this.lblBackup.Text = "BACKUP";
            this.lblBackup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbBackup
            // 
            this.pbBackup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbBackup.Enabled = false;
            this.pbBackup.Image = ((System.Drawing.Image)(resources.GetObject("pbBackup.Image")));
            this.pbBackup.Location = new System.Drawing.Point(3, 33);
            this.pbBackup.Name = "pbBackup";
            this.pbBackup.Size = new System.Drawing.Size(155, 116);
            this.pbBackup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBackup.TabIndex = 1;
            this.pbBackup.TabStop = false;
            // 
            // btnBackup
            // 
            this.btnBackup.BackColor = System.Drawing.Color.Teal;
            this.btnBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackup.Enabled = false;
            this.btnBackup.FlatAppearance.BorderSize = 0;
            this.btnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackup.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackup.ForeColor = System.Drawing.Color.White;
            this.btnBackup.Location = new System.Drawing.Point(3, 195);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(155, 23);
            this.btnBackup.TabIndex = 1;
            this.btnBackup.Text = "Buat Data";
            this.btnBackup.UseVisualStyleBackColor = false;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // Database
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(838, 529);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnPelanggan);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Database";
            this.Text = "Database";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Database_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbRestore)).EndInit();
            this.pnPelanggan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbBackup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRestore;
        private System.Windows.Forms.PictureBox pbRestore;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Panel pnPelanggan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblBackup;
        private System.Windows.Forms.PictureBox pbBackup;
        private System.Windows.Forms.Button btnBackup;
    }
}