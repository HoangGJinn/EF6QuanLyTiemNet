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
using DTO;

namespace WF_QuanNet
{
    public partial class fLK: Form
    {
        private DBLM dblm;
        private int malm;
        private List<UcLk> oldLk = new List<UcLk>();
        private List<UcLk> lstLk = new List<UcLk>();
        public fLK(int malm)
        {
            this.malm = malm;
            dblm = DBLM.Instance;
            InitializeComponent();
            LoadLK(malm);
        }

        private void LoadLK(int malm)
        {
            oldLk.Clear();
            lstLk.Clear();
            List<fn_timLkTheoLoaiMay_Result> list = dblm.TimLinhKienTheoLoaiMay(malm);
            CustomButton customButton = addLkBtn;
            flpLk.Controls.Clear();
            foreach (var item in list)
            {
                UcLk ucLk = new UcLk();
                ucLk.tenLkTxtBox.Texts = item.TenLinhKien; 
                ucLk.tenLkTxtBox.Enabled = false;
                ucLk.ctLkTxtBox.Texts = item.ChiTietLK;
                ucLk.slTxtBox.Texts = item.SoLuong.ToString();
                oldLk.Add(ucLk);
                ucLk.xoaLkBtn.Click += (s, args) =>
                {
                    try
                    {
                        DialogResult result = MessageBox.Show(
                            "Bạn có chắc chắn muốn xóa linh kiện này không?",
                            "Xác nhận",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );
                        if (result == DialogResult.No)
                        {
                            return;
                        }
                        dblm.XoaLinhKien(malm, ucLk.tenLkTxtBox.Texts);
                        MessageBox.Show("Xóa thành công");
                        flpLk.Controls.Remove(ucLk);
                        flpLk.Controls.Add(customButton);
                        oldLk.Remove(ucLk);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                };
                flpLk.Controls.Add(ucLk);
            }
            flpLk.Controls.Add(customButton);
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
                lstLk.Remove(ucLk);
            };
            lstLk.Add(ucLk);
            flpLk.Controls.Add(ucLk);
            flpLk.Controls.Add(customButton);
        }

        private void huyBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void luuBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn các lưu chỉnh sửa?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (result == DialogResult.No)
                {
                    return;
                }
                foreach (UcLk ucLk in oldLk)
                {
                    dblm.SuaLinhKien(malm, ucLk.tenLkTxtBox.Texts, ucLk.ctLkTxtBox.Texts, int.Parse(ucLk.slTxtBox.Texts));
                }
                foreach (UcLk ucLk in lstLk)
                {
                    dblm.ThemLinhKien(malm, ucLk.tenLkTxtBox.Texts, ucLk.ctLkTxtBox.Texts, int.Parse(ucLk.slTxtBox.Texts));
                }
                MessageBox.Show("Lưu thành công");
                LoadLK(malm);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
