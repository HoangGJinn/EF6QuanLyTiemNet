using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class DBDoanhThu
    {
        private static DBDoanhThu instance;
        public static DBDoanhThu Instance
        {
            get
            {
                if (instance == null)
                    instance = new DBDoanhThu();
                return instance;
            }
            private set { instance = value; }
        }
        private DBDoanhThu() { }
        public List<func_TinhDoanhThu12ThangGanNhat_Result> TinhDoanhThu12ThangGanNhat()
        {
            try
            {
                List<func_TinhDoanhThu12ThangGanNhat_Result> list = QuanLyTiemNetEntities.Instance.func_TinhDoanhThu12ThangGanNhat().ToList();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int TinhDoanhThuThang(int thang, int nam)
        {
            try
            {
                int doanhthu = QuanLyTiemNetEntities.Instance.HOADONs
                    .Where(hd => hd.TrangThai == "Thành công" &&
                                 hd.NgayLap.Month == thang &&
                                 hd.NgayLap.Year == nam)
                    .Sum(hd => (hd.TongThanhToan ?? 0) - (hd.TienDuocGiam ?? 0));

                return doanhthu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int TinhDoanhThuThangNay()
        {
            try
            {
                int thang = DateTime.Now.Month;
                int nam = DateTime.Now.Year;
                return TinhDoanhThuThang(thang, nam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<fn_TinhDoanhThuNhanVienTheoThang_Result> DoanhThuNhanVienTheoThang(int thang, int nam)
        {
            try
            {
                List<fn_TinhDoanhThuNhanVienTheoThang_Result> list = QuanLyTiemNetEntities.Instance.fn_TinhDoanhThuNhanVienTheoThang(thang, nam).ToList();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<sp_TinhTongThoiGianSuDungTatCaTaiKhoan_Result> TinhTongTGSDVaDTKH(int thang, int nam)
        {
            try
            {
                List<sp_TinhTongThoiGianSuDungTatCaTaiKhoan_Result> list = QuanLyTiemNetEntities.Instance.sp_TinhTongThoiGianSuDungTatCaTaiKhoan(thang, nam).ToList();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<fn_TimNhanVienCuaThang_Result> NhanVienCuaThang(int thang, int nam)
        {
            try
            {
                List<fn_TimNhanVienCuaThang_Result> list = QuanLyTiemNetEntities.Instance.fn_TimNhanVienCuaThang(thang, nam).ToList();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<fn_TimNhanVienCuaNam_Result> NhanVienCuaNam(int nam)
        {
            try
            {
                List<fn_TimNhanVienCuaNam_Result> list = QuanLyTiemNetEntities.Instance.fn_TimNhanVienCuaNam(nam).ToList();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<fn_TimKhachHangCuaThang_Result> KhachHangCuaThang_Results(int thang, int nam)
        {
            try
            {
                List<fn_TimKhachHangCuaThang_Result> list = QuanLyTiemNetEntities.Instance.fn_TimKhachHangCuaThang(thang, nam).ToList();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<fn_TimKhachHangCuaNam_Result> KhachHangCuaNam_Results(int nam)
        {
            try
            {
                List<fn_TimKhachHangCuaNam_Result> list = QuanLyTiemNetEntities.Instance.fn_TimKhachHangCuaNam(nam).ToList();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
