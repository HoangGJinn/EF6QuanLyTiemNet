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
    public partial class fCTHDDV : Form
    {
        private DBHoaDon dbHoaDon;
        private DBNhanVien dbNV;
        private string maHD;
        public fCTHDDV(string MaHD)
        {
            maHD = MaHD;
            dbHoaDon = DBHoaDon.Instance;
            dbNV = DBNhanVien.Instance;
            InitializeComponent();
            LoadCTHD();
        }

        private void LoadCTHD()
        {
            HOADON hd = dbHoaDon.TimHD(maHD).FirstOrDefault();
            NHANVIEN nv = hd.MaNV != null ? dbNV.TimNhanVien(hd.MaNV.ToString()).FirstOrDefault() : null;
            idLabel.Text = hd.MaHD;
            dateLabel.Text = hd.NgayLap.ToString("dd/MM/yyyy h:mm:ss tt");
            sid.Text = nv != null ? nv.MaNV.ToString() : "X";
            kmLabel.Text = string.IsNullOrEmpty(hd.MaKM) ? "Không có" : hd.MaKM;
            sname.Text = nv != null ? nv.HoTen : "X";
            discountLabel.Text = formatPrice(hd.TienDuocGiam ?? 0);
            finalPayLabel.Text = formatPrice((hd.TongThanhToan ?? 0) - (hd.TienDuocGiam ?? 0));
            amountLabel.Text = formatPrice(hd.TongThanhToan ?? 0);
            pttt.Text = string.IsNullOrEmpty(hd.PhuongThucTT) ? "Không xác định" : hd.PhuongThucTT;
            List<fn_XemChiTietHoaDonDichVu_Result> rows = dbHoaDon.LayDsCTHD(maHD).ToList();
            dgvItem.Rows.Clear();
            int i = 1;
            foreach (var row in rows)
            {
                object[] ct =
                {
                                     i,
                                     row.TenDV,
                                     formatPrice(row.DonGia),
                                     row.SoLuong.ToString(),
                                     formatPrice(row.ThanhTien ?? 0)
                                 };
                i++;
                dgvItem.Rows.Add(ct);
            }
        }

        private string formatPrice(long price)
        {
            return price.ToString("N0") + " VNĐ";
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
