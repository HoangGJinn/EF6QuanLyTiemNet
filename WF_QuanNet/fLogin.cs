using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace WF_QuanNet
{
    public partial class fLogin: Form
    {
        private DBTaiKhoan dbtk;
        public fLogin()
        {
            dbtk = DBTaiKhoan.Instance;
            InitializeComponent();
            customPanel1.BackColor = Color.FromArgb(80, 255, 255, 255);
            customPanel1.GradientBottomColor = Color.FromArgb(80, 255, 255, 255);
            customPanel1.GradientTopColor = Color.FromArgb(80, 255, 255, 255);
            Bitmap image = Properties.Resources.minimize;
            Bitmap resizedImage = new Bitmap(image, new Size(18, 18));
            miniBtn.Image = resizedImage;

            image = Properties.Resources.exit;
            resizedImage = new Bitmap(image, new Size(18, 18));
            quitBtn.Image = resizedImage;
        }

        private void fLogin_Load(object sender, EventArgs e)
        {

        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void miniBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void customButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string username = usnTxtBox.Texts.Trim();
                string password = passTxtBox.Texts.Trim();
                string role = dbtk.BeginConnection(username, password);
                if (role == "db_owner")
                {
                    fMenu f = new fMenu();
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
                else
                {
                    fMenuNV f = new fMenuNV();
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void showBtn_Click(object sender, EventArgs e)
        {
            if (passTxtBox.PasswordChar)
            {
                passTxtBox.PasswordChar = false;
                showBtn.BackgroundImage = WF_QuanNet.Properties.Resources.show;
            }
            else
            {
                passTxtBox.PasswordChar = true;
                showBtn.BackgroundImage = WF_QuanNet.Properties.Resources.hide;
            }
        }
    }

}
