namespace WF_QuanNet.customcomponent
{
    partial class UcDV
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
            this.pnlDV = new WF_QuanNet.CustomComponent.CustomPanel();
            this.pic = new System.Windows.Forms.PictureBox();
            this.price = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.pnlDV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDV
            // 
            this.pnlDV.BackColor = System.Drawing.Color.White;
            this.pnlDV.BorderRadius = 25;
            this.pnlDV.Controls.Add(this.pic);
            this.pnlDV.Controls.Add(this.price);
            this.pnlDV.Controls.Add(this.name);
            this.pnlDV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDV.ForeColor = System.Drawing.Color.Black;
            this.pnlDV.GradientAngle = 90F;
            this.pnlDV.GradientBottomColor = System.Drawing.Color.Cyan;
            this.pnlDV.GradientTopColor = System.Drawing.Color.LightSkyBlue;
            this.pnlDV.Location = new System.Drawing.Point(0, 0);
            this.pnlDV.Name = "pnlDV";
            this.pnlDV.Size = new System.Drawing.Size(175, 214);
            this.pnlDV.TabIndex = 0;
            // 
            // pic
            // 
            this.pic.BackColor = System.Drawing.Color.Transparent;
            this.pic.Location = new System.Drawing.Point(19, 6);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(136, 125);
            this.pic.TabIndex = 3;
            this.pic.TabStop = false;
            // 
            // price
            // 
            this.price.BackColor = System.Drawing.Color.Transparent;
            this.price.Font = new System.Drawing.Font("HarmonyOS Sans", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price.Location = new System.Drawing.Point(3, 185);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(169, 23);
            this.price.TabIndex = 5;
            this.price.Text = "25,000đ";
            this.price.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // name
            // 
            this.name.BackColor = System.Drawing.Color.Transparent;
            this.name.Font = new System.Drawing.Font("HarmonyOS Sans", 10.8F);
            this.name.Location = new System.Drawing.Point(3, 128);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(169, 54);
            this.name.TabIndex = 4;
            this.name.Text = "Đen đá không đường";
            this.name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.name.UseMnemonic = false;
            // 
            // UcDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlDV);
            this.Margin = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.Name = "UcDV";
            this.Size = new System.Drawing.Size(175, 214);
            this.pnlDV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.PictureBox pic;
        public System.Windows.Forms.Label price;
        public System.Windows.Forms.Label name;
        public CustomComponent.CustomPanel pnlDV;
    }
}
