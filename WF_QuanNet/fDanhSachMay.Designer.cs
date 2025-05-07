namespace WF_QuanNet
{
    partial class fDanhSachMay
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLK = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flpMay = new System.Windows.Forms.FlowLayoutPanel();
            this.searchBtn = new System.Windows.Forms.PictureBox();
            this.searchMaMay = new WF_QuanNet.CustomComponent.CustomTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.giaLbl = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.usnTxtBox = new WF_QuanNet.CustomComponent.CustomTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbboxloaimay = new WF_QuanNet.CustomComponent.CustomComboBox();
            this.customPanel1 = new WF_QuanNet.CustomComponent.CustomPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.huyBtn = new WF_QuanNet.CustomComponent.CustomButton();
            this.lmLbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.thueBtn = new WF_QuanNet.CustomComponent.CustomButton();
            this.smLbl = new System.Windows.Forms.Label();
            this.panelInfo = new WF_QuanNet.CustomComponent.CustomPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchBtn)).BeginInit();
            this.customPanel1.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("HarmonyOS Sans Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 38);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dịch Vụ Máy";
            // 
            // dgvLK
            // 
            this.dgvLK.AllowUserToAddRows = false;
            this.dgvLK.AllowUserToDeleteRows = false;
            this.dgvLK.AllowUserToResizeColumns = false;
            this.dgvLK.AllowUserToResizeRows = false;
            this.dgvLK.BackgroundColor = System.Drawing.Color.White;
            this.dgvLK.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLK.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvLK.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Turquoise;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("HarmonyOS Sans", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Turquoise;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLK.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvLK.ColumnHeadersHeight = 29;
            this.dgvLK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLK.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn4});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("HarmonyOS Sans", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLK.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvLK.EnableHeadersVisualStyles = false;
            this.dgvLK.GridColor = System.Drawing.Color.LightGray;
            this.dgvLK.Location = new System.Drawing.Point(2, 214);
            this.dgvLK.Margin = new System.Windows.Forms.Padding(0);
            this.dgvLK.MultiSelect = false;
            this.dgvLK.Name = "dgvLK";
            this.dgvLK.ReadOnly = true;
            this.dgvLK.RowHeadersVisible = false;
            this.dgvLK.RowHeadersWidth = 51;
            this.dgvLK.RowTemplate.Height = 24;
            this.dgvLK.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLK.Size = new System.Drawing.Size(512, 259);
            this.dgvLK.TabIndex = 127;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Tên LK";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.FillWeight = 175F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Chi Tiết LK";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.FillWeight = 50F;
            this.dataGridViewTextBoxColumn4.HeaderText = "SL";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // flpMay
            // 
            this.flpMay.AutoScroll = true;
            this.flpMay.BackColor = System.Drawing.SystemColors.Control;
            this.flpMay.Location = new System.Drawing.Point(18, 116);
            this.flpMay.Name = "flpMay";
            this.flpMay.Size = new System.Drawing.Size(751, 613);
            this.flpMay.TabIndex = 112;
            // 
            // searchBtn
            // 
            this.searchBtn.BackColor = System.Drawing.Color.White;
            this.searchBtn.BackgroundImage = global::WF_QuanNet.Properties.Resources.search;
            this.searchBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.searchBtn.Location = new System.Drawing.Point(723, 68);
            this.searchBtn.Margin = new System.Windows.Forms.Padding(4);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(32, 30);
            this.searchBtn.TabIndex = 109;
            this.searchBtn.TabStop = false;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // searchMaMay
            // 
            this.searchMaMay.BackColor = System.Drawing.Color.White;
            this.searchMaMay.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.searchMaMay.BorderFocusColor = System.Drawing.Color.MediumSlateBlue;
            this.searchMaMay.BorderRadius = 15;
            this.searchMaMay.BorderSize = 2;
            this.searchMaMay.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchMaMay.Location = new System.Drawing.Point(553, 63);
            this.searchMaMay.Margin = new System.Windows.Forms.Padding(5);
            this.searchMaMay.Multiline = false;
            this.searchMaMay.Name = "searchMaMay";
            this.searchMaMay.Padding = new System.Windows.Forms.Padding(11, 7, 50, 7);
            this.searchMaMay.PasswordChar = false;
            this.searchMaMay.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.searchMaMay.PlaceholderText = "Tìm kiếm";
            this.searchMaMay.Size = new System.Drawing.Size(216, 39);
            this.searchMaMay.TabIndex = 110;
            this.searchMaMay.Texts = "";
            this.searchMaMay.UnderlinedStyle = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Font = new System.Drawing.Font("HarmonyOS Sans Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(8, 9);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(218, 38);
            this.label7.TabIndex = 126;
            this.label7.Text = "Thông Tin Máy";
            // 
            // giaLbl
            // 
            this.giaLbl.AutoSize = true;
            this.giaLbl.BackColor = System.Drawing.SystemColors.Control;
            this.giaLbl.Font = new System.Drawing.Font("HarmonyOS Sans", 13.2F);
            this.giaLbl.ForeColor = System.Drawing.Color.Black;
            this.giaLbl.Location = new System.Drawing.Point(145, 150);
            this.giaLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.giaLbl.Name = "giaLbl";
            this.giaLbl.Size = new System.Drawing.Size(26, 29);
            this.giaLbl.TabIndex = 125;
            this.giaLbl.Text = "1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.Font = new System.Drawing.Font("HarmonyOS Sans", 13.2F);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(27, 150);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 29);
            this.label10.TabIndex = 124;
            this.label10.Text = "Giá tiền:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("HarmonyOS Sans", 12.2F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(152, 186);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(208, 28);
            this.label8.TabIndex = 123;
            this.label8.Text = "Danh Sách Linh Kiện";
            // 
            // usnTxtBox
            // 
            this.usnTxtBox.BackColor = System.Drawing.Color.White;
            this.usnTxtBox.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.usnTxtBox.BorderFocusColor = System.Drawing.Color.MediumSlateBlue;
            this.usnTxtBox.BorderRadius = 15;
            this.usnTxtBox.BorderSize = 2;
            this.usnTxtBox.Font = new System.Drawing.Font("HarmonyOS Sans", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usnTxtBox.Location = new System.Drawing.Point(139, 519);
            this.usnTxtBox.Margin = new System.Windows.Forms.Padding(5);
            this.usnTxtBox.Multiline = false;
            this.usnTxtBox.Name = "usnTxtBox";
            this.usnTxtBox.Padding = new System.Windows.Forms.Padding(11, 7, 11, 7);
            this.usnTxtBox.PasswordChar = false;
            this.usnTxtBox.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.usnTxtBox.PlaceholderText = "Nhập tên đăng nhập";
            this.usnTxtBox.Size = new System.Drawing.Size(259, 39);
            this.usnTxtBox.TabIndex = 119;
            this.usnTxtBox.Texts = "";
            this.usnTxtBox.UnderlinedStyle = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("HarmonyOS Sans", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(194, 491);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 23);
            this.label6.TabIndex = 118;
            this.label6.Text = "Tên đăng nhập";
            // 
            // cbboxloaimay
            // 
            this.cbboxloaimay.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbboxloaimay.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.cbboxloaimay.BorderSize = 1;
            this.cbboxloaimay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbboxloaimay.Font = new System.Drawing.Font("HarmonyOS Sans", 9.75F);
            this.cbboxloaimay.ForeColor = System.Drawing.Color.DimGray;
            this.cbboxloaimay.IconColor = System.Drawing.Color.MediumSlateBlue;
            this.cbboxloaimay.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.cbboxloaimay.ListTextColor = System.Drawing.Color.DimGray;
            this.cbboxloaimay.Location = new System.Drawing.Point(140, 67);
            this.cbboxloaimay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbboxloaimay.MinimumSize = new System.Drawing.Size(160, 30);
            this.cbboxloaimay.Name = "cbboxloaimay";
            this.cbboxloaimay.Padding = new System.Windows.Forms.Padding(1);
            this.cbboxloaimay.Size = new System.Drawing.Size(212, 41);
            this.cbboxloaimay.TabIndex = 115;
            this.cbboxloaimay.Texts = "";
            // 
            // customPanel1
            // 
            this.customPanel1.BackColor = System.Drawing.Color.White;
            this.customPanel1.BorderRadius = 20;
            this.customPanel1.Controls.Add(this.cbboxloaimay);
            this.customPanel1.Controls.Add(this.flpMay);
            this.customPanel1.Controls.Add(this.searchBtn);
            this.customPanel1.Controls.Add(this.searchMaMay);
            this.customPanel1.Controls.Add(this.label3);
            this.customPanel1.Controls.Add(this.label1);
            this.customPanel1.ForeColor = System.Drawing.Color.Black;
            this.customPanel1.GradientAngle = 90F;
            this.customPanel1.GradientBottomColor = System.Drawing.SystemColors.Control;
            this.customPanel1.GradientTopColor = System.Drawing.SystemColors.Control;
            this.customPanel1.Location = new System.Drawing.Point(2, 2);
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.Size = new System.Drawing.Size(778, 739);
            this.customPanel1.TabIndex = 110;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("HarmonyOS Sans Medium", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(13, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 29);
            this.label3.TabIndex = 108;
            this.label3.Text = "Loại Máy";
            // 
            // huyBtn
            // 
            this.huyBtn.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.huyBtn.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.huyBtn.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.huyBtn.BorderRadius = 20;
            this.huyBtn.BorderSize = 2;
            this.huyBtn.FlatAppearance.BorderSize = 0;
            this.huyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.huyBtn.Font = new System.Drawing.Font("HarmonyOS Sans Medium", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.huyBtn.ForeColor = System.Drawing.Color.White;
            this.huyBtn.Location = new System.Drawing.Point(201, 587);
            this.huyBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.huyBtn.Name = "huyBtn";
            this.huyBtn.Size = new System.Drawing.Size(131, 49);
            this.huyBtn.TabIndex = 55;
            this.huyBtn.Text = "Hủy";
            this.huyBtn.TextColor = System.Drawing.Color.White;
            this.huyBtn.UseVisualStyleBackColor = false;
            this.huyBtn.Click += new System.EventHandler(this.huyBtn_Click);
            // 
            // lmLbl
            // 
            this.lmLbl.AutoSize = true;
            this.lmLbl.BackColor = System.Drawing.SystemColors.Control;
            this.lmLbl.Font = new System.Drawing.Font("HarmonyOS Sans", 13.2F);
            this.lmLbl.ForeColor = System.Drawing.Color.Black;
            this.lmLbl.Location = new System.Drawing.Point(145, 108);
            this.lmLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lmLbl.Name = "lmLbl";
            this.lmLbl.Size = new System.Drawing.Size(49, 29);
            this.lmLbl.TabIndex = 117;
            this.lmLbl.Text = "abc";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("HarmonyOS Sans", 13.2F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(27, 108);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 29);
            this.label5.TabIndex = 115;
            this.label5.Text = "Loại máy:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("HarmonyOS Sans", 13.2F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(27, 68);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 29);
            this.label4.TabIndex = 114;
            this.label4.Text = "Số máy:";
            // 
            // thueBtn
            // 
            this.thueBtn.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.thueBtn.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.thueBtn.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.thueBtn.BorderRadius = 20;
            this.thueBtn.BorderSize = 2;
            this.thueBtn.FlatAppearance.BorderSize = 0;
            this.thueBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.thueBtn.Font = new System.Drawing.Font("HarmonyOS Sans Medium", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thueBtn.ForeColor = System.Drawing.Color.White;
            this.thueBtn.Location = new System.Drawing.Point(344, 587);
            this.thueBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.thueBtn.Name = "thueBtn";
            this.thueBtn.Size = new System.Drawing.Size(146, 49);
            this.thueBtn.TabIndex = 53;
            this.thueBtn.Text = "Bắt Đầu SD";
            this.thueBtn.TextColor = System.Drawing.Color.White;
            this.thueBtn.UseVisualStyleBackColor = false;
            this.thueBtn.Click += new System.EventHandler(this.thueBtn_Click);
            // 
            // smLbl
            // 
            this.smLbl.BackColor = System.Drawing.SystemColors.Control;
            this.smLbl.Font = new System.Drawing.Font("HarmonyOS Sans", 13.2F);
            this.smLbl.ForeColor = System.Drawing.Color.Black;
            this.smLbl.Location = new System.Drawing.Point(145, 68);
            this.smLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.smLbl.Name = "smLbl";
            this.smLbl.Size = new System.Drawing.Size(93, 29);
            this.smLbl.TabIndex = 116;
            this.smLbl.Text = "1";
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.Color.White;
            this.panelInfo.BorderRadius = 20;
            this.panelInfo.Controls.Add(this.dgvLK);
            this.panelInfo.Controls.Add(this.label7);
            this.panelInfo.Controls.Add(this.giaLbl);
            this.panelInfo.Controls.Add(this.label10);
            this.panelInfo.Controls.Add(this.label8);
            this.panelInfo.Controls.Add(this.usnTxtBox);
            this.panelInfo.Controls.Add(this.label6);
            this.panelInfo.Controls.Add(this.huyBtn);
            this.panelInfo.Controls.Add(this.lmLbl);
            this.panelInfo.Controls.Add(this.smLbl);
            this.panelInfo.Controls.Add(this.label5);
            this.panelInfo.Controls.Add(this.label4);
            this.panelInfo.Controls.Add(this.thueBtn);
            this.panelInfo.ForeColor = System.Drawing.Color.Black;
            this.panelInfo.GradientAngle = 90F;
            this.panelInfo.GradientBottomColor = System.Drawing.SystemColors.Control;
            this.panelInfo.GradientTopColor = System.Drawing.SystemColors.Control;
            this.panelInfo.Location = new System.Drawing.Point(784, 42);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(514, 652);
            this.panelInfo.TabIndex = 111;
            this.panelInfo.Visible = false;
            // 
            // fDanhSachMay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1300, 743);
            this.Controls.Add(this.customPanel1);
            this.Controls.Add(this.panelInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fDanhSachMay";
            this.Text = "fDanhSachMay";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchBtn)).EndInit();
            this.customPanel1.ResumeLayout(false);
            this.customPanel1.PerformLayout();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvLK;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.FlowLayoutPanel flpMay;
        private System.Windows.Forms.PictureBox searchBtn;
        private CustomComponent.CustomTextBox searchMaMay;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label giaLbl;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private CustomComponent.CustomTextBox usnTxtBox;
        private System.Windows.Forms.Label label6;
        private CustomComponent.CustomComboBox cbboxloaimay;
        private CustomComponent.CustomPanel customPanel1;
        private System.Windows.Forms.Label label3;
        private CustomComponent.CustomButton huyBtn;
        private System.Windows.Forms.Label lmLbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private CustomComponent.CustomButton thueBtn;
        private System.Windows.Forms.Label smLbl;
        private CustomComponent.CustomPanel panelInfo;
    }
}