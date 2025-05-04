using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_QuanNet.customcomponent;
using WF_QuanNet.CustomComponent;
using DAL;

namespace WF_QuanNet
{
    public partial class fThemLM: Form
    {
        private DBLM dblm;
        public fThemLM()
        {
            InitializeComponent();
            dblm = DBLM.Instance;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addLkBtn_Click(object sender, EventArgs e)
        {
            UcLk ucLk = new UcLk();
            CustomButton customButton = addLkBtn;
            flpLk.Controls.Remove(customButton);
            ucLk.xoaLkBtn.Click += (s, args) =>
            {
                flpLk.Controls.Remove(ucLk);
                flpLk.Controls.Add(customButton);
            };
            flpLk.Controls.Add(ucLk);
            flpLk.Controls.Add(customButton);
        }

        private void huyBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void themLMBtn_Click(object sender, EventArgs e)
        {
            int malm;
            try
            {
                malm = dblm.ThemLoaiMay(tenLoaiTxtBox.Texts, Convert.ToInt32(st1hTxtBox.Texts));
            }
            catch (FormatException)
            {
                MessageBox.Show("Sai định dạng số nhập vào số tiền");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            try
            {
                foreach (UcLk ucLk in flpLk.Controls.OfType<UcLk>())
                {
                    dblm.ThemLinhKien(malm, ucLk.tenLkTxtBox.Texts, ucLk.ctLkTxtBox.Texts, Convert.ToInt32(ucLk.slTxtBox.Texts));
                }
                MessageBox.Show("Thêm thành công");
            }
            catch (FormatException)
            {
                MessageBox.Show("Sai định dạng số nhập vào số lượng");
                dblm.XoaLoaiMay(malm);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                dblm.XoaLoaiMay(malm);
                return;
            }
            this.Close();
        }
    }
}
