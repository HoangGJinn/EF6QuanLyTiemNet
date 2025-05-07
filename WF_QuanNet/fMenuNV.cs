using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_QuanNet
{
    public partial class fMenuNV : Form
    {
        private Form activeForm;
        private Button currentButton;

        public fMenuNV()
        {
            InitializeComponent();

            // Đặt form mở ra ở giữa màn hình
            this.StartPosition = FormStartPosition.CenterScreen;

            // Code xử lý ảnh cho các nút
            Bitmap image = WF_QuanNet.Properties.Resources.mt;
            Bitmap resizedImage = new Bitmap(image, new Size(30, 30));
            mayTinhBtn.Image = resizedImage;

            image = WF_QuanNet.Properties.Resources.user__5_;
            resizedImage = new Bitmap(image, new Size(30, 30));
            taiKhoanBtn.Image = resizedImage;

            image = WF_QuanNet.Properties.Resources.dv;
            resizedImage = new Bitmap(image, new Size(30, 30));
            dichVuBtn.Image = resizedImage;

            image = WF_QuanNet.Properties.Resources.user;
            resizedImage = new Bitmap(image, new Size(30, 30));
            caNhanBtn.Image = resizedImage;

            image = WF_QuanNet.Properties.Resources.minimize;
            resizedImage = new Bitmap(image, new Size(18, 18));
            miniBtn.Image = resizedImage;

            image = WF_QuanNet.Properties.Resources.exit;
            resizedImage = new Bitmap(image, new Size(18, 18));
            quitBtn.Image = resizedImage;

            // mayTinhBtn_Click(mayTinhBtn, new EventArgs()); // Uncomment if you want to open the Máy Tính form by default
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

            if (sender.Text == "Máy Tính")
            {
                Heading.Text = "Danh Sách Máy Tính";
            }
            else if (sender.Text == "Tài Khoản")
            {
                Heading.Text = "Quản Lý Tài Khoản";
            }
            else if (sender.Text == "Dịch Vụ")
            {
                Heading.Text = "Danh Sách Dịch Vụ";
            }
            else if (sender.Text == "Cá Nhân")
            {
                Heading.Text = "Thông Tin Cá Nhân";
            }

            ActivateButton(sender);

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnlMain.Controls.Add(childForm);
            pnlMain.Tag = childForm; // Storing the child form instance in panel's Tag

            childForm.BringToFront();
            childForm.Show();
        }

        private void dichVuBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fDVNV(), sender as Button);
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mayTinhBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fDanhSachMay(), sender as Button);
        }

        private void taiKhoanBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fTaiKhoan(), sender as Button);
        }

        private void caNhanBtn_Click(object sender, EventArgs e)
        {
           OpenChildForm(new fTTNhanVien(), sender as Button);
        }


        private void miniBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

    }
}