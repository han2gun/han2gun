namespace POS.frm
{
    partial class List
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(List));
            this.pnlUtama = new System.Windows.Forms.Panel();
            this.pnlData = new System.Windows.Forms.Panel();
            this.dgPencarian = new System.Windows.Forms.DataGridView();
            this.pnlPencarian = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnPencarian = new System.Windows.Forms.Button();
            this.txtPencarian = new System.Windows.Forms.TextBox();
            this.cboPencarian = new POS.cmp.UpperComboBox();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnlUtama.SuspendLayout();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPencarian)).BeginInit();
            this.pnlPencarian.SuspendLayout();
            this.pnlButton.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlUtama
            // 
            this.pnlUtama.Controls.Add(this.pnlData);
            this.pnlUtama.Controls.Add(this.pnlPencarian);
            this.pnlUtama.Controls.Add(this.pnlButton);
            this.pnlUtama.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUtama.Location = new System.Drawing.Point(0, 0);
            this.pnlUtama.Name = "pnlUtama";
            this.pnlUtama.Size = new System.Drawing.Size(913, 569);
            this.pnlUtama.TabIndex = 0;
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.dgPencarian);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(0, 75);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(913, 494);
            this.pnlData.TabIndex = 2;
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
            this.dgPencarian.Size = new System.Drawing.Size(913, 494);
            this.dgPencarian.TabIndex = 10;
            this.dgPencarian.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPencarian_CellDoubleClick);
            this.dgPencarian.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgPencarian_KeyDown);
            // 
            // pnlPencarian
            // 
            this.pnlPencarian.Controls.Add(this.btnRefresh);
            this.pnlPencarian.Controls.Add(this.btnPencarian);
            this.pnlPencarian.Controls.Add(this.txtPencarian);
            this.pnlPencarian.Controls.Add(this.cboPencarian);
            this.pnlPencarian.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPencarian.Location = new System.Drawing.Point(0, 36);
            this.pnlPencarian.Name = "pnlPencarian";
            this.pnlPencarian.Size = new System.Drawing.Size(913, 39);
            this.pnlPencarian.TabIndex = 1;
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
            this.btnRefresh.TabIndex = 45;
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
            this.btnPencarian.TabIndex = 44;
            this.btnPencarian.UseVisualStyleBackColor = false;
            this.btnPencarian.Click += new System.EventHandler(this.btnPencarian_Click);
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
            this.txtPencarian.TabIndex = 43;
            this.txtPencarian.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPencarian_KeyPress);
            // 
            // cboPencarian
            // 
            this.cboPencarian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPencarian.FormattingEnabled = true;
            this.cboPencarian.Location = new System.Drawing.Point(3, 7);
            this.cboPencarian.Name = "cboPencarian";
            this.cboPencarian.Size = new System.Drawing.Size(226, 25);
            this.cboPencarian.TabIndex = 1;
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.panel1);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButton.Location = new System.Drawing.Point(0, 0);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(913, 36);
            this.pnlButton.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(878, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(35, 36);
            this.panel1.TabIndex = 3;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(3, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(29, 29);
            this.btnExit.TabIndex = 2;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // List
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(913, 569);
            this.Controls.Add(this.pnlUtama);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "List";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List";
            this.Load += new System.EventHandler(this.List_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.List_KeyPress);
            this.pnlUtama.ResumeLayout(false);
            this.pnlData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPencarian)).EndInit();
            this.pnlPencarian.ResumeLayout(false);
            this.pnlPencarian.PerformLayout();
            this.pnlButton.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlUtama;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Panel pnlPencarian;
        private System.Windows.Forms.Panel pnlButton;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel1;
        private cmp.UpperComboBox cboPencarian;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnPencarian;
        private System.Windows.Forms.TextBox txtPencarian;
        private System.Windows.Forms.DataGridView dgPencarian;
    }
}