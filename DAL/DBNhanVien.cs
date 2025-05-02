using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class DBNhanVien
    {
        private static DBNhanVien instance;
        public static DBNhanVien Instance
        {
            get
            {
                if (instance == null)
                    instance = new DBNhanVien();
                return instance;
            }
            private set { instance = value; }
        }
        private DBNhanVien() { }
        public List<DanhSachNhanVien> LayDsNhanVien()
        {
            List<DanhSachNhanVien> list = new List<DanhSachNhanVien>();
            list = QuanLyTiemNetEntities.Instance.DanhSachNhanViens.ToList();
            return list;
        }
        public List<DanhSachNhanVien> TimNhanVien(string searchText)
        {
            List<DanhSachNhanVien> list = new List<DanhSachNhanVien>();
            list = QuanLyTiemNetEntities.Instance.DanhSachNhanViens.Where(x => x.MaNV.ToString().Contains(searchText) || x.HoTen.Contains(searchText)).ToList();
            return list;
        }
        public bool ThemNhanVien(NHANVIEN nv)
        {
            try
            {
                QuanLyTiemNetEntities db = new QuanLyTiemNetEntities();
                db.sp_ThemNhanVien(nv.HoTen, nv.SDT, nv.DiaChi, nv.GioiTinh, nv.NgaySinh);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool XoaNhanVien ( int id) {
            try
            {
                QuanLyTiemNetEntities.Instance.sp_XoaNhanVien(id);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }
        public bool SuaNhanVien(NHANVIEN nv)
        {
            try
            {
                QuanLyTiemNetEntities.Instance.sp_SuaNhanVien(nv.MaNV, nv.HoTen, nv.DiaChi, nv.GioiTinh, nv.NgaySinh);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }


    }
}
