using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBLM
    {
        private static DBLM instance;
        public static DBLM Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DBLM();
                }
                return instance;
            }
            set { instance = value; }
        }
        private DBLM() { }

        public List<DanhSachLoaiMay> LayDsLoaiMay()
        {
            return QuanLyTiemNetEntities.Instance.DanhSachLoaiMays.ToList();
        }

        public int ThemLoaiMay(string tenLoaiMay, int soTienMotGio)
        {
            try
            {
                return QuanLyTiemNetEntities.Instance.proc_themLoaiMay(tenLoaiMay, soTienMotGio).FirstOrDefault() ?? 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SuaLoaiMay(int maLoaiMay, string tenLoaiMay, int soTienMotGio)
        {
            try
            {
                string tenLoaiMayDB = string.IsNullOrEmpty(tenLoaiMay) ? null : tenLoaiMay;
                QuanLyTiemNetEntities.Instance.proc_suaLoaiMay(maLoaiMay, tenLoaiMayDB, soTienMotGio);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool XoaLoaiMay(int maLoaiMay)
        {
            try
            {
                QuanLyTiemNetEntities.Instance.proc_xoaLoaiMay(maLoaiMay);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<func_timKiemLoaiMay_Result> TimKiemLoaiMay(string tenLoaiMay)
        {
            try
            {
                return QuanLyTiemNetEntities.Instance.func_timKiemLoaiMay(tenLoaiMay).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ThemLinhKien(int maLoaiMay, string tenLinhKien, string chiTietLK, int soLuong)
        {
            try
            {

                QuanLyTiemNetEntities.Instance.proc_themLinhKien(maLoaiMay,
                    string.IsNullOrEmpty(tenLinhKien) ? null : tenLinhKien,
                    string.IsNullOrEmpty(chiTietLK) ? null : chiTietLK,
                    soLuong);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SuaLinhKien(int maLoaiMay, string tenLinhKien, string chiTietLK, int soLuong)
        {
            try
            {
                QuanLyTiemNetEntities.Instance.proc_suaLinhKien(maLoaiMay,
                    string.IsNullOrEmpty(tenLinhKien) ? null : tenLinhKien,
                    string.IsNullOrEmpty(chiTietLK) ? null : chiTietLK,
                    soLuong);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool XoaLinhKien(int maLoaiMay, string tenLinhKien)
        {
            try
            {
                QuanLyTiemNetEntities.Instance.proc_xoaLinhKien(maLoaiMay, tenLinhKien);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<fn_timLkTheoLoaiMay_Result> TimLinhKienTheoLoaiMay(int maLoaiMay)
        {
            try
            {
                return QuanLyTiemNetEntities.Instance.fn_timLkTheoLoaiMay(maLoaiMay).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
