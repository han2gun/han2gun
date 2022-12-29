namespace POS.frm
{
    partial class BackupDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackupDB));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.picLoading = new System.Windows.Forms.PictureBox();
            this.btnBackup = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8_Data_Backup_25px.png");
            // 
            // picLoading
            // 
            this.picLoading.Image = ((System.Drawing.Image)(resources.GetObject("picLoading.Image")));
            this.picLoading.Location = new System.Drawing.Point(109, 26);
            this.picLoading.Name = "picLoading";
            this.picLoading.Size = new System.Drawing.Size(37, 32);
            this.picLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLoading.TabIndex = 99;
            this.picLoading.TabStop = false;
            this.picLoading.Visible = false;
            // 
            // btnBackup
            // 
            this.btnBackup.BackColor = System.Drawing.Color.Teal;
            this.btnBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackup.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnBackup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnBackup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.btnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackup.ForeColor = System.Drawing.Color.White;
            this.btnBackup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBackup.ImageIndex = 0;
            this.btnBackup.ImageList = this.imageList1;
            this.btnBackup.Location = new System.Drawing.Point(15, 26);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(88, 32);
            this.btnBackup.TabIndex = 98;
            this.btnBackup.Text = "Backup";
            this.btnBackup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBackup.UseVisualStyleBackColor = false;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 17);
            this.label4.TabIndex = 97;
            this.label4.Text = "File akan tersimpan di";
            // 
            // BackupDB
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(933, 588);
            this.Controls.Add(this.picLoading);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BackupDB";
            this.Text = "BackupDB";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BackupDB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox picLoading;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Label label4;
    }
}