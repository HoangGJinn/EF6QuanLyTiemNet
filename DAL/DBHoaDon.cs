using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBHoaDon
    {
        private static DBHoaDon instance;
        public static DBHoaDon Instance
        {
            get
            {
                if (instance == null)
                    instance = new DBHoaDon();
                return instance;
            }
            private set { instance = value; }
        }
        private DBHoaDon() { }
        public List<fn_XemChiTietHoaDonDichVu_Result> LayDsCTHD (string maHD)
        {
            try
            {
                // Corrected the syntax issues in the following line
                List<fn_XemChiTietHoaDonDichVu_Result> list = QuanLyTiemNetEntities.Instance.fn_XemChiTietHoaDonDichVu(maHD).ToList();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<HOADON> TimHD(string maHD = null, DateTime? batdau = null, DateTime? ketthuc = null, string loai = null)
        {
            try
            {
                // Corrected the syntax issues in the following line  
                List<HOADON> list = null;
                List<proc_TimKiemHoaDon_Result> temp = QuanLyTiemNetEntities.Instance.proc_TimKiemHoaDon(batdau, ketthuc, loai, maHD).ToList();
                list = temp.Select(x => new HOADON
                {
                    MaHD = x.MaHD,
                    NgayLap = x.NgayLap,
                    TongThanhToan = x.TongThanhToan,
                    PhuongThucTT = x.PhuongThucTT,
                    TienDuocGiam = x.TienDuocGiam,
                    MaNV = x.MaNV,
                    MaKM = x.MaKM
                }).ToList();
                return list;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ThemHoaDonNapTien(int TongThanhToan, string PhuongThuc, int SoTienNap, string TenDangNhap, int MaNV, string MaKM)
        {
            try
            {
                // Corrected the syntax issues in the following line
                QuanLyTiemNetEntities.Instance.proc_ThemHoaDonNapTien(
                    TongThanhToan,
                    PhuongThuc,
                    SoTienNap,
                    TenDangNhap,
                    MaNV,
                    MaKM
                );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
