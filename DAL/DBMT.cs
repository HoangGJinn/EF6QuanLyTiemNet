using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBMT
    {
        private static DBMT instance;
        public static DBMT Instance
        {
            get
            {
                if (instance == null)
                    instance = new DBMT();
                return instance;
            }
            private set { instance = value; }
        }
        private DBMT() { }

        public List<proc_layMayTheoMaLoai_Result> LayDsMayTheoMaLoai(int maLoaiMay)
        {
            try
            {
                return QuanLyTiemNetEntities.Instance.proc_layMayTheoMaLoai(maLoaiMay).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DanhSachMayTinh> LayDsMayTinh()
        {
            return QuanLyTiemNetEntities.Instance.DanhSachMayTinhs.OrderBy(x => x.SoMay).ToList();
        }

        public bool ThemMayTinh(DateTime ngayLapDat, int maLoaiMay)
        {
            try
            {
                QuanLyTiemNetEntities.Instance.proc_themMayTinh(ngayLapDat, maLoaiMay);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SuaMayTinh(string soMay, string trangThai, int maLoaiMay)
        {
            try
            {
                QuanLyTiemNetEntities.Instance.proc_suaMayTinh(soMay, trangThai, maLoaiMay);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<func_timKiemMayTinh_Result> TimKiemMayTinh(string soMay)
        {
            try
            {
                return QuanLyTiemNetEntities.Instance.func_timKiemMayTinh(soMay).OrderBy(x => x.SoMay).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int TinhTongMayHD()
        {
            try
            {
                return QuanLyTiemNetEntities.Instance.fn_TinhTongMayHD().FirstOrDefault();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int GetGiaTienTheoGio(string soMay)
        {
            try
            {
                return QuanLyTiemNetEntities.Instance.fn_GetGiaTienTheoGio(soMay).FirstOrDefault();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public string LayTKDangSDMay(string soMay)
        {
            try
            {
                //object[] param = new object[] { soMay };
                //return (string)db.excuteScalar("EXEC proc_TaiKhoanSuDungMay @SoMay", param);

                return QuanLyTiemNetEntities.Instance.proc_TaiKhoanSuDungMay(soMay).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
