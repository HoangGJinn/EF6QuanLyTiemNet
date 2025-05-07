using BusinessAcessLayer;
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
namespace WF_QuanNet
{
    public partial class fDashBoard : Form
    {
        private DBTaiKhoan dbtk;
        private DBMT dbmt;
        private DBKhuyenMai dbkm;
        private DBDichVu dbdv;
        private DBDT dbdt;
        private int currentYear;
        private int currentMonth;

        public fDashBoard()
        {
            InitializeComponent();
            currentYear = DateTime.Now.Year;
            currentMonth = DateTime.Now.Month;
            dbdt = DBDT.Instance;
            dbdv = DBDichVu.Instance;
            dbmt = DBMT.Instance;
            dbkm = DBKhuyenMai.Instance;
            dbtk = DBTaiKhoan.Instance;
            dvCbBox.DataSource = new object[] { "Đồ ăn", "Đồ uống" };
            dvCbBox.SelectedIndex = 0;
            dvCbBoxAsc.DataSource = new object[] { "Đồ ăn", "Đồ uống" };
            dvCbBoxAsc.SelectedIndex = 0;
            namCbBox.DataSource = new object[] { currentYear, currentYear - 1 };
            namCbBox.SelectedIndex = 0;
            int selectedYear = (int)namCbBox.SelectedItem;
            int maxMonth = (selectedYear == currentYear) ? currentMonth : 12;
            List<int> months = Enumerable.Range(1, maxMonth).ToList();
            thangCbBox.DataSource = months;
            int defaultMonthIndex = months.IndexOf(currentMonth);
            thangCbBox.SelectedIndex = defaultMonthIndex >= 0 ? defaultMonthIndex : 0;
            LoadDB();
        }

        private void LoadDB()
        {
            dtLabel.Text = dbdt.TinhDoanhThuThangNay().ToString("N0") + "đ";
            int lastM = currentMonth == 1 ? 12 : currentMonth - 1;
            int lastY = currentMonth == 1 ? currentYear - 1 : currentYear;
            dtTang.Text = calcDtRate(dbdt.TinhTongDoanhThuThang(lastM, lastY), dbdt.TinhDoanhThuThangNay());
            soMayHDLabel.Text = dbmt.TinhTongMayHD().ToString() + "/" + dbmt.LayDsMayTinh().Count.ToString();
            tongTkLabel.Text = dbtk.LayDanhSachTaiKhoan().Count.ToString();
            tkTang.Text = dbtk.TinhTkMoi().ToString() + " tài khoản mới tháng này";
            kmSapHet.Text = dbkm.SoKhuyenMaiSapHetHan(3).ToString() + " khuyến mãi sắp hết hạn";
            soKmDangDienRa.Text = dbkm.SoKMKhaDung().ToString();
            chart1.Series[0].Points.Clear();
            chart1.Series[0].Name = "Doanh thu";
            var dt = dbdt.TinhDoanhThu12ThangGanNhat();
            chart1.ChartAreas[0].AxisX.Interval = 1;
            foreach (var item in dt)
            {
                int x = item.TongDoanhThu ?? 0;
                chart1.Series[0].Points.AddXY(item.Thang.ToString() + "/" + item.Nam.ToString(), x);
            }
            chart1.ChartAreas[0].AxisX.Title = "Tháng";
            chart1.ChartAreas[0].AxisY.Title = "Doanh thu";
            LoadTop5DV();
            LoadTop5DVItNhat();
            LoadTKThang();
        }

        private string calcDtRate(int lastMonth, int currentMonth)
        {
            if (lastMonth == 0 && currentMonth == 0)
            {
                dtPic.Image = Properties.Resources.up;
                return "Tăng 0% so với tháng trước";
            }
            if (lastMonth == 0)
            {
                dtPic.Image = Properties.Resources.up;
                return "Tăng 100% so với tháng trước";
            }
            else
            {
                string isUp = currentMonth - lastMonth < 0 ? "Giảm " : "Tăng ";
                int rate = (int)(((double)(currentMonth - lastMonth) / lastMonth) * 100);
                if (rate < 0)
                {
                    dtPic.Image = Properties.Resources.down;
                }
                else
                {
                    dtPic.Image = Properties.Resources.up;
                }
                return isUp + rate.ToString() + "% so với tháng trước";
            }
        }

        private void LoadTop5DV()
        {
            if (dvCbBox.Texts == "Đồ ăn")
            {
                dgvTop5DESC.Rows.Clear();
                var dt = dbdv.LayTop5DA();
                foreach (var item in dt)
                {
                    dgvTop5DESC.Rows.Add(item.TenDoAn, item.TongSoLuongBan);
                }
            }
            else
            {
                dgvTop5DESC.Rows.Clear();
                var dt = dbdv.LayTop5DU();
                foreach (var item in dt)
                {
                    dgvTop5DESC.Rows.Add(item.TenDoUong, item.TongSoLuongBan);
                }
            }
        }

        private void LoadTop5DVItNhat()
        {
            if (dvCbBoxAsc.Texts == "Đồ ăn")
            {
                dgvTop5ASC.Rows.Clear();
                var dt = dbdv.LayTop5DAIt();
                foreach (var item in dt)
                {
                    dgvTop5ASC.Rows.Add(item.TenDoAn, item.TongSoLuongBan);
                }
            }
            else
            {
                dgvTop5ASC.Rows.Clear();
                var dt = dbdv.LayTop5DUIt();
                foreach (var item in dt)
                {
                    dgvTop5ASC.Rows.Add(item.TenDoUong, item.TongSoLuongBan);
                }
            }
        }

        private void LoadTKThang()
        {
            int selectedYear = (int)namCbBox.SelectedItem;
            int selectedMonth = (int)thangCbBox.SelectedItem;
            var nvthang = dbdt.NhanVienCuaThang(selectedMonth, selectedYear);
            var nvnam = dbdt.NhanVienCuaNam(selectedYear);
            var khthang = dbdt.KhachHangCuaThang(selectedMonth, selectedYear);
            var khnam = dbdt.KhachHangCuaNam(selectedYear);
            int tdt = dbdt.TinhTongDoanhThuThang(selectedMonth, selectedYear);
            maNvThang.Text = nvthang.Count > 0 ? nvthang[0].MaNV.ToString() : "X";
            tenNvThang.Text = nvthang.Count > 0 ? nvthang[0].HoTen : "Không xác định";
            tongdtNvM.Text = nvthang.Count > 0 ? "Tổng doanh thu: " + formatPrice(nvthang[0].DoanhThu) : "Tổng doanh thu: 0 đ";
            maNvNam.Text = nvnam.Count > 0 ? nvnam[0].MaNV.ToString() : "X";
            tenNvNam.Text = nvnam.Count > 0 ? nvnam[0].HoTen : "Không xác định";
            tongdtNvY.Text = nvnam.Count > 0 ? "Tổng doanh thu: " + formatPrice(nvnam[0].DoanhThu) : "Tổng doanh thu: 0 đ";
            usnThang.Text = khthang.Count > 0 ? khthang[0].TenDangNhap : "Không xác định";
            tongctKhM.Text = khthang.Count > 0 ? "Tổng chi tiêu: " + formatPrice(khthang[0].ChiTieu) : "Tổng chi tiêu: 0 đ";
            usnNam.Text = khnam.Count > 0 ? khnam[0].TenDangNhap : "Không xác định";
            tongctKhY.Text = khnam.Count > 0 ? "Tổng chi tiêu: " + formatPrice(khnam[0].ChiTieu) : "Tổng chi tiêu: 0 đ";
            tongdt.Text = tdt.ToString("N0") + "đ";
            dgvNV.Rows.Clear();
            foreach (var item in dbdt.DoanhThuNhanVienTheoThang(selectedMonth, selectedYear))
            {
                dgvNV.Rows.Add(item.MaNV, item.HoTen, item.DoanhThu);
            }
            dgvCus.Rows.Clear();
            foreach (var item in dbdt.TinhTongTGSDVaDTKH(selectedMonth, selectedYear))
            {
                dgvCus.Rows.Add(item.TenDangNhap, item.TongThoiGian_Gio, item.TongTienNap);
            }
        }

        private string formatPrice(long price)
        {
            return price.ToString("N0") + " đ";
        }

        private void namCbBox_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = (int)namCbBox.SelectedItem;
            int max = (selected == currentYear) ? currentMonth : 12;
            List<int> updatedMonths = Enumerable.Range(1, max).ToList();
            int crrIdx = thangCbBox.SelectedIndex;
            thangCbBox.DataSource = updatedMonths;
            int newIndex = updatedMonths.IndexOf(crrIdx);
            thangCbBox.SelectedIndex = newIndex >= 0 ? newIndex : 0;
            LoadTKThang();
        }

        private void dvCbBox_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTop5DV();
        }

        private void dvCbBoxAsc_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTop5DVItNhat();
        }

        private void thangCbBox_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTKThang();
        }
    }
}
