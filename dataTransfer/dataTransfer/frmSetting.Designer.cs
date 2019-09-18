namespace dataTransfer
{
    partial class frmSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetting));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgOrg = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dgTabel = new System.Windows.Forms.DataGridView();
            this.check1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.org_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.org_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.check2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.table_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTutup = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgOrg)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTabel)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(616, 399);
            this.panel1.TabIndex = 0;
            // 
            // dgOrg
            // 
            this.dgOrg.AllowUserToAddRows = false;
            this.dgOrg.AllowUserToDeleteRows = false;
            this.dgOrg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgOrg.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgOrg.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgOrg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOrg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.check1,
            this.org_code,
            this.org_name});
            this.dgOrg.Location = new System.Drawing.Point(14, 34);
            this.dgOrg.Name = "dgOrg";
            this.dgOrg.Size = new System.Drawing.Size(290, 303);
            this.dgOrg.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Setting Cabang";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dgTabel);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dgOrg);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(614, 344);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnTutup);
            this.panel3.Controls.Add(this.btnSimpan);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 344);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(614, 53);
            this.panel3.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(306, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Setting Tabel";
            // 
            // dgTabel
            // 
            this.dgTabel.AllowUserToAddRows = false;
            this.dgTabel.AllowUserToDeleteRows = false;
            this.dgTabel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgTabel.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgTabel.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgTabel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTabel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.check2,
            this.table_desc,
            this.pk});
            this.dgTabel.Location = new System.Drawing.Point(310, 34);
            this.dgTabel.Name = "dgTabel";
            this.dgTabel.Size = new System.Drawing.Size(290, 303);
            this.dgTabel.TabIndex = 3;
            // 
            // check1
            // 
            this.check1.HeaderText = "";
            this.check1.Name = "check1";
            this.check1.Width = 5;
            // 
            // org_code
            // 
            this.org_code.HeaderText = "org_code";
            this.org_code.Name = "org_code";
            this.org_code.Visible = false;
            // 
            // org_name
            // 
            this.org_name.HeaderText = "Cabang";
            this.org_name.Name = "org_name";
            this.org_name.ReadOnly = true;
            this.org_name.Width = 69;
            // 
            // check2
            // 
            this.check2.HeaderText = "";
            this.check2.Name = "check2";
            this.check2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.check2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.check2.Width = 19;
            // 
            // table_desc
            // 
            this.table_desc.HeaderText = "Nama Tabel";
            this.table_desc.Name = "table_desc";
            this.table_desc.ReadOnly = true;
            this.table_desc.Width = 90;
            // 
            // pk
            // 
            this.pk.HeaderText = "Kolom Kunci";
            this.pk.Name = "pk";
            this.pk.ReadOnly = true;
            this.pk.Visible = false;
            this.pk.Width = 91;
            // 
            // btnTutup
            // 
            this.btnTutup.Image = ((System.Drawing.Image)(resources.GetObject("btnTutup.Image")));
            this.btnTutup.Location = new System.Drawing.Point(505, 5);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(95, 40);
            this.btnTutup.TabIndex = 1;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTutup.UseVisualStyleBackColor = true;
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Image = ((System.Drawing.Image)(resources.GetObject("btnSimpan.Image")));
            this.btnSimpan.Location = new System.Drawing.Point(404, 5);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(95, 40);
            this.btnSimpan.TabIndex = 0;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 399);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting Data Transfer";
            this.Load += new System.EventHandler(this.frmSetting_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgOrg)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTabel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgOrg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgTabel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check1;
        private System.Windows.Forms.DataGridViewTextBoxColumn org_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn org_name;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check2;
        private System.Windows.Forms.DataGridViewTextBoxColumn table_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn pk;
        private System.Windows.Forms.Button btnTutup;
        private System.Windows.Forms.Button btnSimpan;
    }
}