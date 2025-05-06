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
    public partial class fCTHDNT : Form
    {
        private DBHoaDon dbHoaDon;
        private DBNhanVien dbNV;
        private string maHD;
        public fCTHDNT(string MaHD)
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
            finalPayLabel.Text = formatPrice(hd.TongThanhToan ?? 0);
            pttt.Text = hd.PhuongThucTT;
            dgvItem.Rows.Clear();
            object[] ct =
            {
                       formatPrice(hd.SoTienNap ?? 0),
                       formatPrice(hd.TienCongThem ?? 0),
                       hd.TenDangNhap
                   };
            dgvItem.Rows.Add(ct);
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
