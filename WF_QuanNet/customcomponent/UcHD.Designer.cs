namespace WF_QuanNet.customcomponent
{
    partial class UcHD
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.id = new System.Windows.Forms.Label();
            this.sid = new System.Windows.Forms.Label();
            this.total = new System.Windows.Forms.Label();
            this.pMethod = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.Label();
            this.type = new System.Windows.Forms.Label();
            this.cthdBtn = new WF_QuanNet.CustomComponent.CustomButton();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.id);
            this.flowLayoutPanel1.Controls.Add(this.sid);
            this.flowLayoutPanel1.Controls.Add(this.total);
            this.flowLayoutPanel1.Controls.Add(this.pMethod);
            this.flowLayoutPanel1.Controls.Add(this.status);
            this.flowLayoutPanel1.Controls.Add(this.date);
            this.flowLayoutPanel1.Controls.Add(this.type);
            this.flowLayoutPanel1.Controls.Add(this.cthdBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1279, 35);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // id
            // 
            this.id.BackColor = System.Drawing.Color.Transparent;
            this.id.Font = new System.Drawing.Font("HarmonyOS Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id.Location = new System.Drawing.Point(11, 0);
            this.id.Margin = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(157, 31);
            this.id.TabIndex = 38;
            this.id.Text = "Mã đơn";
            this.id.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sid
            // 
            this.sid.BackColor = System.Drawing.Color.Transparent;
            this.sid.Font = new System.Drawing.Font("HarmonyOS Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sid.Location = new System.Drawing.Point(179, 0);
            this.sid.Margin = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.sid.Name = "sid";
            this.sid.Size = new System.Drawing.Size(83, 31);
            this.sid.TabIndex = 39;
            this.sid.Text = "Mã NV";
            this.sid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // total
            // 
            this.total.BackColor = System.Drawing.Color.Transparent;
            this.total.Font = new System.Drawing.Font("HarmonyOS Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total.Location = new System.Drawing.Point(273, 0);
            this.total.Margin = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(199, 31);
            this.total.TabIndex = 40;
            this.total.Text = "Tổng tiền";
            this.total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pMethod
            // 
            this.pMethod.BackColor = System.Drawing.Color.Transparent;
            this.pMethod.Font = new System.Drawing.Font("HarmonyOS Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pMethod.Location = new System.Drawing.Point(483, 0);
            this.pMethod.Margin = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.pMethod.Name = "pMethod";
            this.pMethod.Size = new System.Drawing.Size(187, 31);
            this.pMethod.TabIndex = 41;
            this.pMethod.Text = "Phương thức TT";
            this.pMethod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // status
            // 
            this.status.BackColor = System.Drawing.Color.Transparent;
            this.status.Font = new System.Drawing.Font("HarmonyOS Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status.Location = new System.Drawing.Point(681, 0);
            this.status.Margin = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(174, 31);
            this.status.TabIndex = 31;
            this.status.Text = "Trạng thái";
            this.status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // date
            // 
            this.date.BackColor = System.Drawing.Color.Transparent;
            this.date.Font = new System.Drawing.Font("HarmonyOS Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date.Location = new System.Drawing.Point(866, 0);
            this.date.Margin = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(167, 31);
            this.date.TabIndex = 33;
            this.date.Text = "Ngày đặt";
            this.date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // type
            // 
            this.type.BackColor = System.Drawing.Color.Transparent;
            this.type.Font = new System.Drawing.Font("HarmonyOS Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.type.Location = new System.Drawing.Point(1044, 0);
            this.type.Margin = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(104, 31);
            this.type.TabIndex = 36;
            this.type.Text = "Loại";
            this.type.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cthdBtn
            // 
            this.cthdBtn.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cthdBtn.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.cthdBtn.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.cthdBtn.BorderRadius = 13;
            this.cthdBtn.BorderSize = 0;
            this.cthdBtn.FlatAppearance.BorderSize = 0;
            this.cthdBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cthdBtn.Font = new System.Drawing.Font("HarmonyOS Sans", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cthdBtn.ForeColor = System.Drawing.Color.Black;
            this.cthdBtn.Location = new System.Drawing.Point(1166, 0);
            this.cthdBtn.Margin = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.cthdBtn.Name = "cthdBtn";
            this.cthdBtn.Size = new System.Drawing.Size(98, 30);
            this.cthdBtn.TabIndex = 37;
            this.cthdBtn.Text = "Chi tiết";
            this.cthdBtn.TextColor = System.Drawing.Color.Black;
            this.cthdBtn.UseVisualStyleBackColor = false;
            // 
            // UcHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.Name = "UcHD";
            this.Size = new System.Drawing.Size(1279, 35);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public System.Windows.Forms.Label status;
        public System.Windows.Forms.Label date;
        public System.Windows.Forms.Label type;
        public CustomComponent.CustomButton cthdBtn;
        public System.Windows.Forms.Label id;
        public System.Windows.Forms.Label sid;
        public System.Windows.Forms.Label total;
        public System.Windows.Forms.Label pMethod;
    }
}
