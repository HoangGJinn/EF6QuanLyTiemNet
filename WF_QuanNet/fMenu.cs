using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_QuanNet
{
    public partial class fMenu : Form
    {
        private Form activeForm;
        private Button currentButton;
        public fMenu()
        {
            InitializeComponent();
            Image image = WF_QuanNet.Properties.Resources.dashboard;
            Image resizedImage = new Bitmap(image, new Size(30, 30));
            thongKeBtn.Image = resizedImage;

            image = WF_QuanNet.Properties.Resources.mt;
            resizedImage = new Bitmap(image, new Size(30, 30));
            mayTinhBtn.Image = resizedImage;

            image = WF_QuanNet.Properties.Resources.user__5_;
            resizedImage = new Bitmap(image, new Size(30, 30));
            nhanVienBtn.Image = resizedImage;
            taiKhoanBtn.Image = resizedImage;

            image = WF_QuanNet.Properties.Resources.promo2;
            resizedImage = new Bitmap(image, new Size(30, 30));
            khuyenMaiBtn.Image = resizedImage;

            image = WF_QuanNet.Properties.Resources.dv;
            resizedImage = new Bitmap(image, new Size(30, 30));
            dichVuBtn.Image = resizedImage;

            image = WF_QuanNet.Properties.Resources.bill;
            resizedImage = new Bitmap(image, new Size(30, 30));
            hoaDonBtn.Image = resizedImage;

            image = WF_QuanNet.Properties.Resources.minimize;
            resizedImage = new Bitmap(image, new Size(18, 18));
            miniBtn.Image = resizedImage;

            image = WF_QuanNet.Properties.Resources.exit;
            resizedImage = new Bitmap(image, new Size(18, 18));
            quitBtn.Image = resizedImage;
            thongKeBtn_Click(thongKeBtn, new EventArgs());
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnlMovable_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void fMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void ActivateButton(Button btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != btnSender)
                {
                    DeactivateCrrButton();
                    currentButton = btnSender;
                    currentButton.ForeColor = Color.Turquoise;
                }
            }
        }

        private void DeactivateCrrButton()
        {
            if (currentButton != null)
            {
                currentButton.ForeColor = Color.White;
            }
        }

        private void OpenChildForm(Form childForm, Button sender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            ActivateButton(sender);
            if (sender.Text == "Thống Kê")
            {
                Heading.Text = "Báo Cáo Doanh Thu - " + sender.Text;
            }
            else
            {
                Heading.Text = "Quản Lý " + sender.Text;
            }
            
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnlMain.Controls.Add(childForm);
            pnlMain.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
        }

        private void thongKeBtn_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new fDashBoard(), sender as Button);
        }

        private void mayTinhBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fMayTinh(), sender as Button);
        }

        private void nhanVienBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fNhanVien(), sender as Button);
        }

        private void taiKhoanBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fTaiKhoan(), sender as Button);
        }

        private void dichVuBtn_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new fDichVu(), sender as Button);
        }

        private void khuyenMaiBtn_Click(object sender, EventArgs e)
        {
           // OpenChildForm(new fKhuyenMai(), sender as Button);
        }

        private void hoaDonBtn_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new fHoaDon(), sender as Button);
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void miniBtn_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Minimized;
        }
    }
}
