namespace dataTransfer
{
    partial class frmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnHide = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabExport = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgListExport = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPathExport = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLastDateExport = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLastTagExport = new System.Windows.Forms.TextBox();
            this.tabImport = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dgListImport = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPathImport = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLastDateImport = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLastTagImport = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.lb000 = new System.Windows.Forms.ListBox();
            this.lb001 = new System.Windows.Forms.ListBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.picStatus = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.cbAutoHide = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabExport.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgListExport)).BeginInit();
            this.panel4.SuspendLayout();
            this.tabImport.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgListImport)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "Data Transfer";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // btnHide
            // 
            this.btnHide.Image = ((System.Drawing.Image)(resources.GetObject("btnHide.Image")));
            this.btnHide.Location = new System.Drawing.Point(593, 7);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(112, 48);
            this.btnHide.TabIndex = 0;
            this.btnHide.Text = "Sembunyikan";
            this.btnHide.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabExport);
            this.tabControl1.Controls.Add(this.tabImport);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(827, 248);
            this.tabControl1.TabIndex = 1;
            // 
            // tabExport
            // 
            this.tabExport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabExport.Controls.Add(this.panel5);
            this.tabExport.Controls.Add(this.panel4);
            this.tabExport.Location = new System.Drawing.Point(4, 22);
            this.tabExport.Name = "tabExport";
            this.tabExport.Padding = new System.Windows.Forms.Padding(3);
            this.tabExport.Size = new System.Drawing.Size(819, 222);
            this.tabExport.TabIndex = 0;
            this.tabExport.Text = "Export";
            this.tabExport.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dgListExport);
            this.panel5.Location = new System.Drawing.Point(540, 41);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(200, 100);
            this.panel5.TabIndex = 1;
            // 
            // dgListExport
            // 
            this.dgListExport.AllowUserToAddRows = false;
            this.dgListExport.AllowUserToDeleteRows = false;
            this.dgListExport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgListExport.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgListExport.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgListExport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgListExport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgListExport.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgListExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgListExport.Location = new System.Drawing.Point(0, 0);
            this.dgListExport.Name = "dgListExport";
            this.dgListExport.Size = new System.Drawing.Size(200, 100);
            this.dgListExport.TabIndex = 30;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.Width = 5;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.txtPathExport);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.txtLastDateExport);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.txtLastTagExport);
            this.panel4.Location = new System.Drawing.Point(118, 84);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(378, 100);
            this.panel4.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Path export";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtPathExport
            // 
            this.txtPathExport.Location = new System.Drawing.Point(80, 6);
            this.txtPathExport.Name = "txtPathExport";
            this.txtPathExport.Size = new System.Drawing.Size(245, 20);
            this.txtPathExport.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(138, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Tanggal";
            // 
            // txtLastDateExport
            // 
            this.txtLastDateExport.Location = new System.Drawing.Point(185, 32);
            this.txtLastDateExport.Name = "txtLastDateExport";
            this.txtLastDateExport.Size = new System.Drawing.Size(140, 20);
            this.txtLastDateExport.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Tag terakhir";
            // 
            // txtLastTagExport
            // 
            this.txtLastTagExport.Location = new System.Drawing.Point(80, 32);
            this.txtLastTagExport.Name = "txtLastTagExport";
            this.txtLastTagExport.Size = new System.Drawing.Size(50, 20);
            this.txtLastTagExport.TabIndex = 12;
            // 
            // tabImport
            // 
            this.tabImport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabImport.Controls.Add(this.panel7);
            this.tabImport.Controls.Add(this.panel6);
            this.tabImport.Location = new System.Drawing.Point(4, 22);
            this.tabImport.Name = "tabImport";
            this.tabImport.Padding = new System.Windows.Forms.Padding(3);
            this.tabImport.Size = new System.Drawing.Size(819, 222);
            this.tabImport.TabIndex = 1;
            this.tabImport.Text = "Import";
            this.tabImport.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.dgListImport);
            this.panel7.Location = new System.Drawing.Point(530, 48);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(200, 100);
            this.panel7.TabIndex = 2;
            // 
            // dgListImport
            // 
            this.dgListImport.AllowUserToAddRows = false;
            this.dgListImport.AllowUserToDeleteRows = false;
            this.dgListImport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgListImport.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgListImport.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgListImport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgListImport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgListImport.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgListImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgListImport.Location = new System.Drawing.Point(0, 0);
            this.dgListImport.Name = "dgListImport";
            this.dgListImport.Size = new System.Drawing.Size(200, 100);
            this.dgListImport.TabIndex = 30;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 5;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.txtPathImport);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.txtLastDateImport);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.txtLastTagImport);
            this.panel6.Location = new System.Drawing.Point(96, 100);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(378, 100);
            this.panel6.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Path import";
            // 
            // txtPathImport
            // 
            this.txtPathImport.Location = new System.Drawing.Point(80, 6);
            this.txtPathImport.Name = "txtPathImport";
            this.txtPathImport.Size = new System.Drawing.Size(245, 20);
            this.txtPathImport.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(138, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Tanggal";
            // 
            // txtLastDateImport
            // 
            this.txtLastDateImport.Location = new System.Drawing.Point(185, 32);
            this.txtLastDateImport.Name = "txtLastDateImport";
            this.txtLastDateImport.Size = new System.Drawing.Size(140, 20);
            this.txtLastDateImport.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Tag terakhir";
            // 
            // txtLastTagImport
            // 
            this.txtLastTagImport.Location = new System.Drawing.Point(80, 32);
            this.txtLastTagImport.Name = "txtLastTagImport";
            this.txtLastTagImport.Size = new System.Drawing.Size(50, 20);
            this.txtLastTagImport.TabIndex = 12;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            this.panel1.Size = new System.Drawing.Size(831, 313);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.lb000);
            this.panel3.Controls.Add(this.lb001);
            this.panel3.Controls.Add(this.linkLabel2);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.picStatus);
            this.panel3.Controls.Add(this.lblStatus);
            this.panel3.Controls.Add(this.linkLabel1);
            this.panel3.Controls.Add(this.cbAutoHide);
            this.panel3.Controls.Add(this.btnHide);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 250);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(829, 61);
            this.panel3.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(505, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 48);
            this.button2.TabIndex = 10;
            this.button2.Text = "Test";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lb000
            // 
            this.lb000.FormattingEnabled = true;
            this.lb000.Items.AddRange(new object[] {
            "t_transfer_out_hdr",
            "s_stock_movement",
            "t_delivery_goods_hdr",
            "t_inventory_control_hdr",
            "t_inventory_controlu_hdr",
            "t_product_hdr",
            "t_purchase_order_hdr",
            "t_retur_purchase_hdr",
            "t_sales_order_hdr",
            "t_stock_adj_hdr",
            "t_transfer_in_hdr",
            "t_work_in_process_hdr",
            "t_goods_receipt_hdr",
            "s_stock_master",
            "t_req_stock_hdr"});
            this.lb000.Location = new System.Drawing.Point(485, 73);
            this.lb000.Name = "lb000";
            this.lb000.Size = new System.Drawing.Size(120, 95);
            this.lb000.TabIndex = 9;
            this.lb000.Visible = false;
            // 
            // lb001
            // 
            this.lb001.FormattingEnabled = true;
            this.lb001.Items.AddRange(new object[] {
            "m_brand",
            "m_category",
            "m_color",
            "m_customer",
            "m_customer_sub",
            "m_item",
            "m_organization",
            "m_size",
            "m_size_group",
            "m_style",
            "m_supplier",
            "m_uom",
            "m_valas",
            "m_basic_cp_mst",
            "m_basic_sp_mst",
            "m_basic_sp_mst_bak",
            "t_transfer_out_hdr",
            "cp_re_pricing",
            "sp_re_pricing",
            "m_gender"});
            this.lb001.Location = new System.Drawing.Point(359, 73);
            this.lb001.Name = "lb001";
            this.lb001.Size = new System.Drawing.Size(120, 95);
            this.lb001.TabIndex = 8;
            this.lb001.Visible = false;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(372, 39);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(129, 13);
            this.linkLabel2.TabIndex = 7;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Setting table export import";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(711, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 48);
            this.button1.TabIndex = 6;
            this.button1.Text = "Tutup";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // picStatus
            // 
            this.picStatus.Image = ((System.Drawing.Image)(resources.GetObject("picStatus.Image")));
            this.picStatus.Location = new System.Drawing.Point(4, 38);
            this.picStatus.Name = "picStatus";
            this.picStatus.Size = new System.Drawing.Size(18, 17);
            this.picStatus.TabIndex = 5;
            this.picStatus.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatus.Location = new System.Drawing.Point(28, 39);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(35, 13);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "label1";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(269, 39);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(74, 13);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Ubah Koneksi";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // cbAutoHide
            // 
            this.cbAutoHide.AutoSize = true;
            this.cbAutoHide.Location = new System.Drawing.Point(4, 4);
            this.cbAutoHide.Name = "cbAutoHide";
            this.cbAutoHide.Size = new System.Drawing.Size(132, 17);
            this.cbAutoHide.TabIndex = 2;
            this.cbAutoHide.Text = "Sembunyikan otomatis";
            this.cbAutoHide.UseVisualStyleBackColor = true;
            this.cbAutoHide.CheckedChanged += new System.EventHandler(this.cbAutoHide_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(829, 250);
            this.panel2.TabIndex = 3;
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 313);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabExport.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgListExport)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabImport.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgListImport)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabExport;
        private System.Windows.Forms.TabPage tabImport;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbAutoHide;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.PictureBox picStatus;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.ListBox lb001;
        private System.Windows.Forms.ListBox lb000;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPathExport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLastTagExport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLastDateExport;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        internal System.Windows.Forms.DataGridView dgListExport;
        internal System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.Panel panel7;
        internal System.Windows.Forms.DataGridView dgListImport;
        internal System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPathImport;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLastDateImport;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLastTagImport;
        private System.Windows.Forms.Button button2;
    }
}

