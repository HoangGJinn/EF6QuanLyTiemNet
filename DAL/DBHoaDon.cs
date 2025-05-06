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
