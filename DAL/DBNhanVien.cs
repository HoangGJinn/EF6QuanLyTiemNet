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
            QuanLyTiemNetEntities db = new QuanLyTiemNetEntities();
            list = db.DanhSachNhanViens.ToList();
            return list;
        }
        public List<DanhSachNhanVien> TimNhanVien(string searchText)
        {
            List<DanhSachNhanVien> list = new List<DanhSachNhanVien>();
            QuanLyTiemNetEntities db = new QuanLyTiemNetEntities();
            list = db.DanhSachNhanViens.Where(x => x.HoTen.Contains(searchText)).ToList();
            return list;
        }


    }
}
