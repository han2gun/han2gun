namespace POS.rpt
{
    partial class Laporan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Laporan));
            this.crViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnKeluar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnTampilkan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtAkhir = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtAwal = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // crViewer
            // 
            this.crViewer.ActiveViewIndex = -1;
            this.crViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crViewer.Location = new System.Drawing.Point(0, 62);
            this.crViewer.Name = "crViewer";
            this.crViewer.ShowCloseButton = false;
            this.crViewer.ShowCopyButton = false;
            this.crViewer.ShowGroupTreeButton = false;
            this.crViewer.ShowLogo = false;
            this.crViewer.ShowParameterPanelButton = false;
            this.crViewer.ShowRefreshButton = false;
            this.crViewer.Size = new System.Drawing.Size(830, 510);
            this.crViewer.TabIndex = 16;
            this.crViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnKeluar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(830, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(106, 510);
            this.panel1.TabIndex = 14;
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
            this.btnKeluar.Location = new System.Drawing.Point(3, 4);
            this.btnKeluar.Name = "btnKeluar";
            this.btnKeluar.Size = new System.Drawing.Size(100, 80);
            this.btnKeluar.TabIndex = 23;
            this.btnKeluar.Text = "KELUAR-F10";
            this.btnKeluar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnKeluar.UseVisualStyleBackColor = false;
            this.btnKeluar.Click += new System.EventHandler(this.btnKeluar_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnTampilkan);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.dtAkhir);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.dtAwal);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(936, 62);
            this.panel3.TabIndex = 15;
            // 
            // btnTampilkan
            // 
            this.btnTampilkan.BackColor = System.Drawing.Color.Teal;
            this.btnTampilkan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTampilkan.FlatAppearance.BorderSize = 0;
            this.btnTampilkan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTampilkan.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTampilkan.ForeColor = System.Drawing.Color.White;
            this.btnTampilkan.Location = new System.Drawing.Point(93, 33);
            this.btnTampilkan.Name = "btnTampilkan";
            this.btnTampilkan.Size = new System.Drawing.Size(327, 23);
            this.btnTampilkan.TabIndex = 2;
            this.btnTampilkan.Text = "Tampilkan Data";
            this.btnTampilkan.UseVisualStyleBackColor = false;
            this.btnTampilkan.Click += new System.EventHandler(this.btnTampilkan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 84;
            this.label1.Text = "Periode";
            // 
            // dtAkhir
            // 
            this.dtAkhir.CustomFormat = "dd - MMM - yyyy";
            this.dtAkhir.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtAkhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtAkhir.Location = new System.Drawing.Point(277, 5);
            this.dtAkhir.Name = "dtAkhir";
            this.dtAkhir.Size = new System.Drawing.Size(143, 22);
            this.dtAkhir.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(242, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 17);
            this.label3.TabIndex = 54;
            this.label3.Text = "s.d";
            // 
            // dtAwal
            // 
            this.dtAwal.CustomFormat = "dd - MMM - yyyy";
            this.dtAwal.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtAwal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtAwal.Location = new System.Drawing.Point(93, 5);
            this.dtAwal.Name = "dtAwal";
            this.dtAwal.Size = new System.Drawing.Size(143, 22);
            this.dtAwal.TabIndex = 0;
            // 
            // Laporan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(936, 572);
            this.Controls.Add(this.crViewer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Laporan";
            this.Text = "Laporan";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Laporan_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Laporan_KeyPress);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crViewer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnKeluar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnTampilkan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtAkhir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtAwal;
    }
}