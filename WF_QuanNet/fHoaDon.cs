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
using DTO;
using WF_QuanNet.customcomponent;
using WF_QuanNet.CustomComponent;


namespace WF_QuanNet
{
    public partial class fHoaDon : Form
    {
        private DBHoaDon dbHoaDon;
        private bool isRefreshing = false;
        public fHoaDon()
        {
            dbHoaDon = DBHoaDon.Instance;
            InitializeComponent();
            LoadHD();
            filterBegin.Format = DateTimePickerFormat.Custom;
            filterBegin.CustomFormat = "dd/MM/yyyy";
            filterEnd.Format = DateTimePickerFormat.Custom;
            filterEnd.CustomFormat = "dd/MM/yyyy";
            filterBegin.Value = DateTime.Now - TimeSpan.FromDays(30);
        }

        public void LoadHD()
        {
            try
            {
                flpHD.Controls.Clear();
                string maHD = searchBox.Texts;
                DateTime? batdau = filterBegin.Value;
                DateTime? ketthuc = filterEnd.Value;
                string loai = null;
                if (filterALL.Checked)
                {
                    loai = null;
                }
                else if (filterNT.Checked)
                {
                    loai = "Nạp tiền";
                }
                else if (filterDV.Checked)
                {
                    loai = "Dịch vụ";
                }
                List<HOADON> dt = dbHoaDon.TimHD(maHD, batdau, ketthuc, loai);
                foreach (var row in dt)
                {
                    UcHD uc = new UcHD();
                    uc.id.Text = row.MaHD;
                    uc.total.Text = formatPrice(row.TongThanhToan ?? 0);
                    uc.sid.Text = row.MaNV?.ToString();
                    uc.status.Text = row.TrangThai;
                    uc.pMethod.Text = row.PhuongThucTT;
                    uc.date.Text = row.NgayLap.ToString("dd/MM/yyyy");
                    uc.type.Text = row.LoaiHoaDon;
                    uc.cthdBtn.Click += (sender, e) => showCTHD(row.MaHD, row.LoaiHoaDon);
                    flpHD.Controls.Add(uc);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                lmBtn_Click(lmBtn, EventArgs.Empty);
            }
        }

        private void showCTHD(string maHD, string type)
        {   
            if (type == "Dịch vụ")
            {
                fCTHDDV fcthd = new fCTHDDV(maHD);
                using (fBlur blur = new fBlur(fMenu.ActiveForm))
                {
                    blur.Show();
                    fcthd.ShowDialog();
                    blur.Close();
                }
            }
            else
            {
                fCTHDNT fcthd = new fCTHDNT(maHD);
                using (fBlur blur = new fBlur(fMenu.ActiveForm))
                {
                    blur.Show();
                    fcthd.ShowDialog();
                    blur.Close();
                }
            }

        }

        private string formatPrice(long price)
        {
            return price.ToString("N0") + " VNĐ";
        }

        private void filterALL_CheckedChanged(object sender, EventArgs e)
        {
            if (isRefreshing)
            {
                return;
            }
            LoadHD();
        }

        private void filterNT_CheckedChanged(object sender, EventArgs e)
        {
            if (isRefreshing)
            {
                return;
            }
            LoadHD();
        }

        private void filterDV_CheckedChanged(object sender, EventArgs e)
        {
            if (isRefreshing)
            {
                return;
            }
            LoadHD();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            LoadHD();
        }

        private void lmBtn_Click(object sender, EventArgs e)
        {
            searchBox.Texts = "";
            isRefreshing = true;
            filterALL.Checked = true;
            filterEnd.Value = DateTime.Now;
            filterBegin.Value = DateTime.Now - TimeSpan.FromDays(30);
            isRefreshing = false;
            LoadHD();
        }

        private void filterBegin_ValueChanged(object sender, EventArgs e)
        {
            if (isRefreshing)
            {
                return;
            }
            LoadHD();
        }

        private void filterEnd_ValueChanged(object sender, EventArgs e)
        {
            if (isRefreshing)
            {
                return;
            }
            LoadHD();
        }
    }
}
