namespace POS.frm
{
    partial class Pencarian
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pencarian));
            this.dgPencarian = new System.Windows.Forms.DataGridView();
            this.pnlView = new System.Windows.Forms.Panel();
            this.pnlPencarian = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnPencarian = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtAkhir = new System.Windows.Forms.DateTimePicker();
            this.dtAwal = new System.Windows.Forms.DateTimePicker();
            this.txtPencarian = new System.Windows.Forms.TextBox();
            this.cboPencarian = new POS.cmp.UpperComboBox();
            this.pnlOption = new System.Windows.Forms.Panel();
            this.rbLain = new System.Windows.Forms.RadioButton();
            this.rbTanggal = new System.Windows.Forms.RadioButton();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.btnCetak = new System.Windows.Forms.Button();
            this.btnKeluar = new System.Windows.Forms.Button();
            this.btnBaru = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgPencarian)).BeginInit();
            this.pnlView.SuspendLayout();
            this.pnlPencarian.SuspendLayout();
            this.pnlOption.SuspendLayout();
            this.pnlButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgPencarian
            // 
            this.dgPencarian.AllowUserToAddRows = false;
            this.dgPencarian.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPencarian.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgPencarian.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPencarian.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPencarian.Location = new System.Drawing.Point(0, 0);
            this.dgPencarian.Name = "dgPencarian";
            this.dgPencarian.ReadOnly = true;
            this.dgPencarian.Size = new System.Drawing.Size(830, 499);
            this.dgPencarian.TabIndex = 9;
            this.dgPencarian.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPencarian_CellDoubleClick);
            this.dgPencarian.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgPencarian_KeyDown);
            // 
            // pnlView
            // 
            this.pnlView.Controls.Add(this.dgPencarian);
            this.pnlView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlView.Location = new System.Drawing.Point(0, 67);
            this.pnlView.Name = "pnlView";
            this.pnlView.Size = new System.Drawing.Size(830, 499);
            this.pnlView.TabIndex = 7;
            // 
            // pnlPencarian
            // 
            this.pnlPencarian.Controls.Add(this.btnRefresh);
            this.pnlPencarian.Controls.Add(this.btnPencarian);
            this.pnlPencarian.Controls.Add(this.label1);
            this.pnlPencarian.Controls.Add(this.dtAkhir);
            this.pnlPencarian.Controls.Add(this.dtAwal);
            this.pnlPencarian.Controls.Add(this.txtPencarian);
            this.pnlPencarian.Controls.Add(this.cboPencarian);
            this.pnlPencarian.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPencarian.Location = new System.Drawing.Point(0, 31);
            this.pnlPencarian.Name = "pnlPencarian";
            this.pnlPencarian.Size = new System.Drawing.Size(830, 36);
            this.pnlPencarian.TabIndex = 6;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(709, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(28, 28);
            this.btnRefresh.TabIndex = 42;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnPencarian
            // 
            this.btnPencarian.BackColor = System.Drawing.Color.White;
            this.btnPencarian.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPencarian.FlatAppearance.BorderSize = 0;
            this.btnPencarian.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPencarian.ForeColor = System.Drawing.Color.White;
            this.btnPencarian.Image = ((System.Drawing.Image)(resources.GetObject("btnPencarian.Image")));
            this.btnPencarian.Location = new System.Drawing.Point(675, 4);
            this.btnPencarian.Name = "btnPencarian";
            this.btnPencarian.Size = new System.Drawing.Size(28, 28);
            this.btnPencarian.TabIndex = 41;
            this.btnPencarian.UseVisualStyleBackColor = false;
            this.btnPencarian.Click += new System.EventHandler(this.btnPencarian_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(152, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 20);
            this.label1.TabIndex = 40;
            this.label1.Text = "s.d";
            this.label1.Visible = false;
            // 
            // dtAkhir
            // 
            this.dtAkhir.CustomFormat = "dd - MMM - yyyy";
            this.dtAkhir.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtAkhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtAkhir.Location = new System.Drawing.Point(187, 5);
            this.dtAkhir.Name = "dtAkhir";
            this.dtAkhir.Size = new System.Drawing.Size(143, 26);
            this.dtAkhir.TabIndex = 39;
            this.dtAkhir.Visible = false;
            // 
            // dtAwal
            // 
            this.dtAwal.CustomFormat = "dd - MMM - yyyy";
            this.dtAwal.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtAwal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtAwal.Location = new System.Drawing.Point(3, 5);
            this.dtAwal.Name = "dtAwal";
            this.dtAwal.Size = new System.Drawing.Size(143, 26);
            this.dtAwal.TabIndex = 38;
            this.dtAwal.Visible = false;
            // 
            // txtPencarian
            // 
            this.txtPencarian.BackColor = System.Drawing.Color.White;
            this.txtPencarian.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPencarian.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPencarian.ForeColor = System.Drawing.Color.Black;
            this.txtPencarian.Location = new System.Drawing.Point(235, 6);
            this.txtPencarian.MaxLength = 100;
            this.txtPencarian.Name = "txtPencarian";
            this.txtPencarian.Size = new System.Drawing.Size(434, 26);
            this.txtPencarian.TabIndex = 37;
            this.txtPencarian.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPencarian_KeyPress);
            // 
            // cboPencarian
            // 
            this.cboPencarian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPencarian.FormattingEnabled = true;
            this.cboPencarian.Location = new System.Drawing.Point(3, 6);
            this.cboPencarian.Name = "cboPencarian";
            this.cboPencarian.Size = new System.Drawing.Size(226, 25);
            this.cboPencarian.TabIndex = 0;
            // 
            // pnlOption
            // 
            this.pnlOption.Controls.Add(this.rbLain);
            this.pnlOption.Controls.Add(this.rbTanggal);
            this.pnlOption.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOption.Location = new System.Drawing.Point(0, 0);
            this.pnlOption.Name = "pnlOption";
            this.pnlOption.Size = new System.Drawing.Size(830, 31);
            this.pnlOption.TabIndex = 5;
            // 
            // rbLain
            // 
            this.rbLain.AutoSize = true;
            this.rbLain.Checked = true;
            this.rbLain.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLain.Location = new System.Drawing.Point(3, 3);
            this.rbLain.Name = "rbLain";
            this.rbLain.Size = new System.Drawing.Size(98, 24);
            this.rbLain.TabIndex = 2;
            this.rbLain.TabStop = true;
            this.rbLain.Text = "Lain - Lain";
            this.rbLain.UseVisualStyleBackColor = true;
            this.rbLain.CheckedChanged += new System.EventHandler(this.rbLain_CheckedChanged);
            // 
            // rbTanggal
            // 
            this.rbTanggal.AutoSize = true;
            this.rbTanggal.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTanggal.Location = new System.Drawing.Point(107, 3);
            this.rbTanggal.Name = "rbTanggal";
            this.rbTanggal.Size = new System.Drawing.Size(84, 24);
            this.rbTanggal.TabIndex = 3;
            this.rbTanggal.Text = "Tanggal";
            this.rbTanggal.UseVisualStyleBackColor = true;
            this.rbTanggal.CheckedChanged += new System.EventHandler(this.rbTanggal_CheckedChanged);
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnCetak);
            this.pnlButton.Controls.Add(this.btnKeluar);
            this.pnlButton.Controls.Add(this.btnBaru);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlButton.Location = new System.Drawing.Point(830, 0);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(114, 566);
            this.pnlButton.TabIndex = 4;
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
            this.btnCetak.Location = new System.Drawing.Point(6, 239);
            this.btnCetak.Name = "btnCetak";
            this.btnCetak.Size = new System.Drawing.Size(100, 80);
            this.btnCetak.TabIndex = 13;
            this.btnCetak.Text = "CETAK-F12";
            this.btnCetak.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCetak.UseVisualStyleBackColor = false;
            this.btnCetak.Visible = false;
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
            this.btnKeluar.Location = new System.Drawing.Point(6, 153);
            this.btnKeluar.Name = "btnKeluar";
            this.btnKeluar.Size = new System.Drawing.Size(100, 80);
            this.btnKeluar.TabIndex = 12;
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
            this.btnBaru.Location = new System.Drawing.Point(6, 67);
            this.btnBaru.Name = "btnBaru";
            this.btnBaru.Size = new System.Drawing.Size(100, 80);
            this.btnBaru.TabIndex = 11;
            this.btnBaru.Text = "BARU-F2";
            this.btnBaru.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBaru.UseVisualStyleBackColor = false;
            this.btnBaru.Click += new System.EventHandler(this.btnBaru_Click);
            // 
            // Pencarian
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(944, 566);
            this.Controls.Add(this.pnlView);
            this.Controls.Add(this.pnlPencarian);
            this.Controls.Add(this.pnlOption);
            this.Controls.Add(this.pnlButton);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Pencarian";
            this.Text = "Pencarian";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Pencarian_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Pencarian_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dgPencarian)).EndInit();
            this.pnlView.ResumeLayout(false);
            this.pnlPencarian.ResumeLayout(false);
            this.pnlPencarian.PerformLayout();
            this.pnlOption.ResumeLayout(false);
            this.pnlOption.PerformLayout();
            this.pnlButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgPencarian;
        private System.Windows.Forms.Panel pnlView;
        private System.Windows.Forms.Panel pnlPencarian;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnPencarian;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtAkhir;
        private System.Windows.Forms.DateTimePicker dtAwal;
        private System.Windows.Forms.TextBox txtPencarian;
        private cmp.UpperComboBox cboPencarian;
        private System.Windows.Forms.Panel pnlOption;
        private System.Windows.Forms.RadioButton rbLain;
        private System.Windows.Forms.RadioButton rbTanggal;
        private System.Windows.Forms.Panel pnlButton;
        private System.Windows.Forms.Button btnKeluar;
        private System.Windows.Forms.Button btnBaru;
        private System.Windows.Forms.Button btnCetak;
    }
}