namespace WF_QuanNet.customcomponent
{
    partial class UcMayTinh
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
            this.lmLbl = new System.Windows.Forms.Label();
            this.TrangThaiTxtLB = new System.Windows.Forms.Label();
            this.SoMayTxtLB = new System.Windows.Forms.Label();
            this.pnlDV.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDV
            // 
            this.pnlDV.BackColor = System.Drawing.Color.White;
            this.pnlDV.BorderRadius = 25;
            this.pnlDV.Controls.Add(this.lmLbl);
            this.pnlDV.Controls.Add(this.TrangThaiTxtLB);
            this.pnlDV.Controls.Add(this.SoMayTxtLB);
            this.pnlDV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDV.ForeColor = System.Drawing.Color.Black;
            this.pnlDV.GradientAngle = 90F;
            this.pnlDV.GradientBottomColor = System.Drawing.Color.Cyan;
            this.pnlDV.GradientTopColor = System.Drawing.Color.LightSkyBlue;
            this.pnlDV.Location = new System.Drawing.Point(0, 0);
            this.pnlDV.Name = "pnlDV";
            this.pnlDV.Size = new System.Drawing.Size(175, 184);
            this.pnlDV.TabIndex = 8;
            // 
            // lmLbl
            // 
            this.lmLbl.BackColor = System.Drawing.Color.Transparent;
            this.lmLbl.Font = new System.Drawing.Font("HarmonyOS Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lmLbl.Location = new System.Drawing.Point(14, 116);
            this.lmLbl.Name = "lmLbl";
            this.lmLbl.Size = new System.Drawing.Size(144, 56);
            this.lmLbl.TabIndex = 7;
            this.lmLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lmLbl.UseMnemonic = false;
            // 
            // TrangThaiTxtLB
            // 
            this.TrangThaiTxtLB.BackColor = System.Drawing.Color.Transparent;
            this.TrangThaiTxtLB.Font = new System.Drawing.Font("HarmonyOS Sans", 12F, System.Drawing.FontStyle.Bold);
            this.TrangThaiTxtLB.Location = new System.Drawing.Point(14, 51);
            this.TrangThaiTxtLB.Name = "TrangThaiTxtLB";
            this.TrangThaiTxtLB.Size = new System.Drawing.Size(144, 60);
            this.TrangThaiTxtLB.TabIndex = 6;
            this.TrangThaiTxtLB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TrangThaiTxtLB.UseMnemonic = false;
            // 
            // SoMayTxtLB
            // 
            this.SoMayTxtLB.BackColor = System.Drawing.Color.Transparent;
            this.SoMayTxtLB.Font = new System.Drawing.Font("HarmonyOS Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SoMayTxtLB.Location = new System.Drawing.Point(14, 15);
            this.SoMayTxtLB.Name = "SoMayTxtLB";
            this.SoMayTxtLB.Size = new System.Drawing.Size(144, 30);
            this.SoMayTxtLB.TabIndex = 5;
            this.SoMayTxtLB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SoMayTxtLB.UseMnemonic = false;
            // 
            // UcMayTinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlDV);
            this.Name = "UcMayTinh";
            this.Size = new System.Drawing.Size(175, 184);
            this.pnlDV.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public CustomComponent.CustomPanel pnlDV;
        public System.Windows.Forms.Label lmLbl;
        public System.Windows.Forms.Label TrangThaiTxtLB;
        public System.Windows.Forms.Label SoMayTxtLB;
    }
}
