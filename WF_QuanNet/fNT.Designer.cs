namespace WF_QuanNet
{
    partial class fNT
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
            this.ck = new System.Windows.Forms.RadioButton();
            this.tm = new System.Windows.Forms.RadioButton();
            this.huyBtn = new WF_QuanNet.CustomComponent.CustomButton();
            this.napBtn = new WF_QuanNet.CustomComponent.CustomButton();
            this.label2 = new System.Windows.Forms.Label();
            this.customComboBox1 = new WF_QuanNet.CustomComponent.CustomComboBox();
            this.tenLoaiTxtBox = new WF_QuanNet.CustomComponent.CustomTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.exitBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ck
            // 
            this.ck.AutoSize = true;
            this.ck.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck.Location = new System.Drawing.Point(406, 248);
            this.ck.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ck.Name = "ck";
            this.ck.Size = new System.Drawing.Size(176, 29);
            this.ck.TabIndex = 75;
            this.ck.Text = "Chuyển khoản";
            this.ck.UseVisualStyleBackColor = true;
            // 
            // tm
            // 
            this.tm.AutoSize = true;
            this.tm.Checked = true;
            this.tm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tm.Location = new System.Drawing.Point(225, 248);
            this.tm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tm.Name = "tm";
            this.tm.Size = new System.Drawing.Size(120, 29);
            this.tm.TabIndex = 74;
            this.tm.TabStop = true;
            this.tm.Text = "Tiền mặt";
            this.tm.UseVisualStyleBackColor = true;
            // 
            // huyBtn
            // 
            this.huyBtn.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.huyBtn.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.huyBtn.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.huyBtn.BorderRadius = 20;
            this.huyBtn.BorderSize = 0;
            this.huyBtn.FlatAppearance.BorderSize = 0;
            this.huyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.huyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.huyBtn.ForeColor = System.Drawing.Color.White;
            this.huyBtn.Location = new System.Drawing.Point(446, 308);
            this.huyBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.huyBtn.Name = "huyBtn";
            this.huyBtn.Size = new System.Drawing.Size(180, 62);
            this.huyBtn.TabIndex = 73;
            this.huyBtn.Text = "Hủy";
            this.huyBtn.TextColor = System.Drawing.Color.White;
            this.huyBtn.UseVisualStyleBackColor = false;
            this.huyBtn.Click += new System.EventHandler(this.huyBtn_Click);
            // 
            // napBtn
            // 
            this.napBtn.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.napBtn.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.napBtn.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.napBtn.BorderRadius = 20;
            this.napBtn.BorderSize = 0;
            this.napBtn.FlatAppearance.BorderSize = 0;
            this.napBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.napBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.napBtn.ForeColor = System.Drawing.Color.White;
            this.napBtn.Location = new System.Drawing.Point(180, 308);
            this.napBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.napBtn.Name = "napBtn";
            this.napBtn.Size = new System.Drawing.Size(180, 62);
            this.napBtn.TabIndex = 72;
            this.napBtn.Text = "Nạp";
            this.napBtn.TextColor = System.Drawing.Color.White;
            this.napBtn.UseVisualStyleBackColor = false;
            this.napBtn.Click += new System.EventHandler(this.napBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(364, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(260, 26);
            this.label2.TabIndex = 71;
            this.label2.Text = "Chương trình khuyến mãi:";
            // 
            // customComboBox1
            // 
            this.customComboBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.customComboBox1.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.customComboBox1.BorderSize = 1;
            this.customComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.customComboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customComboBox1.ForeColor = System.Drawing.Color.DimGray;
            this.customComboBox1.IconColor = System.Drawing.Color.MediumSlateBlue;
            this.customComboBox1.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.customComboBox1.ListTextColor = System.Drawing.Color.DimGray;
            this.customComboBox1.Location = new System.Drawing.Point(370, 173);
            this.customComboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.customComboBox1.MinimumSize = new System.Drawing.Size(300, 46);
            this.customComboBox1.Name = "customComboBox1";
            this.customComboBox1.Padding = new System.Windows.Forms.Padding(1);
            this.customComboBox1.Size = new System.Drawing.Size(405, 51);
            this.customComboBox1.TabIndex = 70;
            this.customComboBox1.Texts = "";
            // 
            // tenLoaiTxtBox
            // 
            this.tenLoaiTxtBox.BackColor = System.Drawing.Color.White;
            this.tenLoaiTxtBox.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.tenLoaiTxtBox.BorderFocusColor = System.Drawing.Color.MediumSlateBlue;
            this.tenLoaiTxtBox.BorderRadius = 15;
            this.tenLoaiTxtBox.BorderSize = 2;
            this.tenLoaiTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenLoaiTxtBox.Location = new System.Drawing.Point(44, 173);
            this.tenLoaiTxtBox.Margin = new System.Windows.Forms.Padding(6);
            this.tenLoaiTxtBox.Multiline = false;
            this.tenLoaiTxtBox.Name = "tenLoaiTxtBox";
            this.tenLoaiTxtBox.Padding = new System.Windows.Forms.Padding(12, 9, 12, 9);
            this.tenLoaiTxtBox.PasswordChar = false;
            this.tenLoaiTxtBox.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.tenLoaiTxtBox.PlaceholderText = "Nhập số tiền nạp";
            this.tenLoaiTxtBox.Size = new System.Drawing.Size(282, 45);
            this.tenLoaiTxtBox.TabIndex = 68;
            this.tenLoaiTxtBox.Texts = "";
            this.tenLoaiTxtBox.UnderlinedStyle = false;
            this.tenLoaiTxtBox._TextChanged += new System.EventHandler(this.tenLoaiTxtBox__TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(39, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 26);
            this.label6.TabIndex = 69;
            this.label6.Text = "Số tiền nạp:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.exitBtn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(804, 82);
            this.panel1.TabIndex = 67;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(36, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nạp Tiền";
            // 
            // exitBtn
            // 
            this.exitBtn.BackgroundImage = global::WF_QuanNet.Properties.Resources.cross;
            this.exitBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exitBtn.FlatAppearance.BorderSize = 0;
            this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitBtn.Location = new System.Drawing.Point(744, 15);
            this.exitBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(45, 49);
            this.exitBtn.TabIndex = 1;
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // fNT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 384);
            this.Controls.Add(this.ck);
            this.Controls.Add(this.tm);
            this.Controls.Add(this.huyBtn);
            this.Controls.Add(this.napBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.customComboBox1);
            this.Controls.Add(this.tenLoaiTxtBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fNT";
            this.Text = "fNT";
            this.Load += new System.EventHandler(this.fNT_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton ck;
        private System.Windows.Forms.RadioButton tm;
        private CustomComponent.CustomButton huyBtn;
        private CustomComponent.CustomButton napBtn;
        private System.Windows.Forms.Label label2;
        private CustomComponent.CustomComboBox customComboBox1;
        private CustomComponent.CustomTextBox tenLoaiTxtBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Label label1;
    }
}