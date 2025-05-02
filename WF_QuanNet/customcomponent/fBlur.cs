using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_QuanNet.CustomComponent
{
    public partial class fBlur : Form
    {
        public fBlur(Form parent)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.BackColor = parent.BackColor;
            this.Opacity = 0.5; 
            this.ShowInTaskbar = false;
            this.Size = parent.Size;
            this.Location = parent.Location;
            //this.TopMost = ;
        }
    }
}
