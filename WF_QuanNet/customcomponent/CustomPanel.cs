using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_QuanNet.CustomComponent
{
    public class CustomPanel : Panel
    {
        private int borderRadius = 10;
        private float gradientAngle = 90F;
        private Color gradientTopColor = Color.DodgerBlue;
        private Color gradientBottomColor = Color.CadetBlue;

        public CustomPanel()
        {
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            this.Size = new Size(450, 300);
        }

        public int BorderRadius
        {
            get { return borderRadius; }
            set { borderRadius = value; this.Invalidate(); }
        }

        public float GradientAngle
        {
            get { return gradientAngle; }
            set { gradientAngle = value; this.Invalidate(); }
        }

        public Color GradientTopColor
        {
            get { return gradientTopColor; }
            set { gradientTopColor = value; this.Invalidate(); }
        }

        public Color GradientBottomColor
        {
            get { return gradientBottomColor; }
            set { gradientBottomColor = value; this.Invalidate(); }
        }

        private GraphicsPath GetGraphicsPath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, gradientTopColor, gradientBottomColor, gradientAngle);
            Graphics graphics = e.Graphics;
            graphics.FillRectangle(brush, this.ClientRectangle);
            RectangleF rect = new Rectangle(0, 0, this.Width, this.Height);
            if (borderRadius > 2)
            {
                using (GraphicsPath path = GetGraphicsPath(rect, borderRadius))
                using (Pen pen = new Pen(this.Parent.BackColor, 2))
                {
                    this.Region = new Region(path);
                    e.Graphics.DrawPath(pen, path);
                }
            }
            else this.Region = new Region(rect);
        }
    }
}
