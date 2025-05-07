namespace WF_QuanNet
{
    partial class fMenuNV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMenuNV));
            this.pnlMain = new WF_QuanNet.CustomComponent.CustomPanel();
            this.Heading = new System.Windows.Forms.Label();
            this.miniBtn = new System.Windows.Forms.Button();
            this.quitBtn = new System.Windows.Forms.Button();
            this.pnlMenubar = new System.Windows.Forms.Panel();
            this.caNhanBtn = new System.Windows.Forms.Button();
            this.mayTinhBtn = new System.Windows.Forms.Button();
            this.dichVuBtn = new System.Windows.Forms.Button();
            this.taiKhoanBtn = new System.Windows.Forms.Button();
            this.pnlMovable = new System.Windows.Forms.Panel();
            this.bthLogout = new System.Windows.Forms.Button();
            this.pnlMenubar.SuspendLayout();
            this.pnlMovable.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.BorderRadius = 50;
            this.pnlMain.ForeColor = System.Drawing.Color.Black;
            this.pnlMain.GradientAngle = 90F;
            this.pnlMain.GradientBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.pnlMain.GradientTopColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.pnlMain.Location = new System.Drawing.Point(208, 55);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1300, 743);
            this.pnlMain.TabIndex = 10;
            // 
            // Heading
            // 
            this.Heading.Font = new System.Drawing.Font("HarmonyOS Sans Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Heading.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.Heading.Location = new System.Drawing.Point(311, 9);
            this.Heading.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Heading.Name = "Heading";
            this.Heading.Size = new System.Drawing.Size(1068, 28);
            this.Heading.TabIndex = 6;
            this.Heading.Text = "Danh Mục ";
            this.Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // miniBtn
            // 
            this.miniBtn.BackColor = System.Drawing.Color.Transparent;
            this.miniBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.miniBtn.FlatAppearance.BorderSize = 0;
            this.miniBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.miniBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.miniBtn.Location = new System.Drawing.Point(1435, 0);
            this.miniBtn.Margin = new System.Windows.Forms.Padding(0);
            this.miniBtn.Name = "miniBtn";
            this.miniBtn.Size = new System.Drawing.Size(44, 44);
            this.miniBtn.TabIndex = 4;
            this.miniBtn.UseVisualStyleBackColor = false;
            // 
            // quitBtn
            // 
            this.quitBtn.BackColor = System.Drawing.Color.Transparent;
            this.quitBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.quitBtn.FlatAppearance.BorderSize = 0;
            this.quitBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Brown;
            this.quitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quitBtn.Location = new System.Drawing.Point(1479, 0);
            this.quitBtn.Margin = new System.Windows.Forms.Padding(0);
            this.quitBtn.Name = "quitBtn";
            this.quitBtn.Size = new System.Drawing.Size(44, 44);
            this.quitBtn.TabIndex = 3;
            this.quitBtn.UseVisualStyleBackColor = false;
            this.quitBtn.Click += new System.EventHandler(this.quitBtn_Click);
            // 
            // pnlMenubar
            // 
            this.pnlMenubar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.pnlMenubar.Controls.Add(this.caNhanBtn);
            this.pnlMenubar.Controls.Add(this.mayTinhBtn);
            this.pnlMenubar.Controls.Add(this.bthLogout);
            this.pnlMenubar.Controls.Add(this.dichVuBtn);
            this.pnlMenubar.Controls.Add(this.taiKhoanBtn);
            this.pnlMenubar.Location = new System.Drawing.Point(-1, -2);
            this.pnlMenubar.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMenubar.Name = "pnlMenubar";
            this.pnlMenubar.Size = new System.Drawing.Size(197, 814);
            this.pnlMenubar.TabIndex = 9;
            // 
            // caNhanBtn
            // 
            this.caNhanBtn.FlatAppearance.BorderSize = 0;
            this.caNhanBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.caNhanBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.caNhanBtn.ForeColor = System.Drawing.Color.White;
            this.caNhanBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.caNhanBtn.Location = new System.Drawing.Point(4, 497);
            this.caNhanBtn.Margin = new System.Windows.Forms.Padding(4);
            this.caNhanBtn.Name = "caNhanBtn";
            this.caNhanBtn.Size = new System.Drawing.Size(212, 62);
            this.caNhanBtn.TabIndex = 7;
            this.caNhanBtn.Text = "Cá Nhân";
            this.caNhanBtn.UseVisualStyleBackColor = true;
            this.caNhanBtn.Click += new System.EventHandler(this.caNhanBtn_Click);
            // 
            // mayTinhBtn
            // 
            this.mayTinhBtn.FlatAppearance.BorderSize = 0;
            this.mayTinhBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mayTinhBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mayTinhBtn.ForeColor = System.Drawing.Color.White;
            this.mayTinhBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mayTinhBtn.Location = new System.Drawing.Point(4, 257);
            this.mayTinhBtn.Margin = new System.Windows.Forms.Padding(4);
            this.mayTinhBtn.Name = "mayTinhBtn";
            this.mayTinhBtn.Size = new System.Drawing.Size(212, 62);
            this.mayTinhBtn.TabIndex = 4;
            this.mayTinhBtn.Text = "Máy Tính";
            this.mayTinhBtn.UseVisualStyleBackColor = true;
            this.mayTinhBtn.Click += new System.EventHandler(this.mayTinhBtn_Click);
            // 
            // dichVuBtn
            // 
            this.dichVuBtn.FlatAppearance.BorderSize = 0;
            this.dichVuBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dichVuBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dichVuBtn.ForeColor = System.Drawing.Color.White;
            this.dichVuBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dichVuBtn.Location = new System.Drawing.Point(0, 417);
            this.dichVuBtn.Margin = new System.Windows.Forms.Padding(4);
            this.dichVuBtn.Name = "dichVuBtn";
            this.dichVuBtn.Size = new System.Drawing.Size(216, 62);
            this.dichVuBtn.TabIndex = 1;
            this.dichVuBtn.Text = "Dịch Vụ";
            this.dichVuBtn.UseVisualStyleBackColor = true;
            this.dichVuBtn.Click += new System.EventHandler(this.dichVuBtn_Click);
            // 
            // taiKhoanBtn
            // 
            this.taiKhoanBtn.FlatAppearance.BorderSize = 0;
            this.taiKhoanBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.taiKhoanBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taiKhoanBtn.ForeColor = System.Drawing.Color.White;
            this.taiKhoanBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.taiKhoanBtn.Location = new System.Drawing.Point(4, 337);
            this.taiKhoanBtn.Margin = new System.Windows.Forms.Padding(4);
            this.taiKhoanBtn.Name = "taiKhoanBtn";
            this.taiKhoanBtn.Size = new System.Drawing.Size(212, 62);
            this.taiKhoanBtn.TabIndex = 0;
            this.taiKhoanBtn.Text = "Tài Khoản";
            this.taiKhoanBtn.UseVisualStyleBackColor = true;
            this.taiKhoanBtn.Click += new System.EventHandler(this.taiKhoanBtn_Click);
            // 
            // pnlMovable
            // 
            this.pnlMovable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlMovable.Controls.Add(this.Heading);
            this.pnlMovable.Controls.Add(this.miniBtn);
            this.pnlMovable.Controls.Add(this.quitBtn);
            this.pnlMovable.Location = new System.Drawing.Point(-1, -2);
            this.pnlMovable.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMovable.Name = "pnlMovable";
            this.pnlMovable.Size = new System.Drawing.Size(1523, 46);
            this.pnlMovable.TabIndex = 8;
            // 
            // bthLogout
            // 
            this.bthLogout.FlatAppearance.BorderSize = 0;
            this.bthLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bthLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bthLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.bthLogout.Image = ((System.Drawing.Image)(resources.GetObject("bthLogout.Image")));
            this.bthLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bthLogout.Location = new System.Drawing.Point(0, 748);
            this.bthLogout.Margin = new System.Windows.Forms.Padding(4);
            this.bthLogout.Name = "bthLogout";
            this.bthLogout.Size = new System.Drawing.Size(171, 62);
            this.bthLogout.TabIndex = 3;
            this.bthLogout.Text = "Đăng xuất";
            this.bthLogout.UseVisualStyleBackColor = true;
            // 
            // fMenuNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1521, 811);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlMenubar);
            this.Controls.Add(this.pnlMovable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fMenuNV";
            this.Text = "fMenuNV";
            this.pnlMenubar.ResumeLayout(false);
            this.pnlMovable.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomComponent.CustomPanel pnlMain;
        private System.Windows.Forms.Label Heading;
        private System.Windows.Forms.Button miniBtn;
        private System.Windows.Forms.Button quitBtn;
        private System.Windows.Forms.Panel pnlMenubar;
        private System.Windows.Forms.Button caNhanBtn;
        private System.Windows.Forms.Button mayTinhBtn;
        private System.Windows.Forms.Button bthLogout;
        private System.Windows.Forms.Button dichVuBtn;
        private System.Windows.Forms.Button taiKhoanBtn;
        private System.Windows.Forms.Panel pnlMovable;
    }
}