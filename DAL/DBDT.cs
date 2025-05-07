using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace BusinessAcessLayer
{
    public class DBDT
    {
        private static DBDT instance;
        private QuanLyTiemNetEntities db;

        private DBDT()
        {
            db = QuanLyTiemNetEntities.Instance;
        }

        public static DBDT Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DBDT();
                }
                return instance;
            }
        }

        public List<func_TinhDoanhThu12ThangGanNhat_Result> TinhDoanhThu12ThangGanNhat()
        {
            try
            {
                List< func_TinhDoanhThu12ThangGanNhat_Result > res  = db.func_TinhDoanhThu12ThangGanNhat().ToList();
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int TinhTongDoanhThuThang(int thang, int nam)
        {
            try
            {
                int tongDoanhThu = 0;
                try
                {
                    tongDoanhThu = db.HOADONs
                        .Where(hd =>
                                     hd.NgayLap.Month == thang &&
                                     hd.NgayLap.Year == nam &&
                                     hd.TrangThai == "Thành công")
                        .Sum(hd => (hd.TongThanhToan ?? 0) - (hd.TienDuocGiam ?? 0));
                }
                catch (Exception ex)
                {
                }

                return tongDoanhThu;
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
                return db.proc_TinhDoanhThuThangNay().FirstOrDefault() ?? 0;
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
                return db.fn_TinhDoanhThuNhanVienTheoThang(thang, nam).ToList();
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
                var result = db.sp_TinhTongThoiGianSuDungTatCaTaiKhoan(thang, nam).ToList();
                return result;
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
                var result = db.fn_TimNhanVienCuaThang(thang, nam).ToList();
                return result;
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
                var result = db.fn_TimNhanVienCuaNam(nam).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<fn_TimKhachHangCuaThang_Result> KhachHangCuaThang(int thang, int nam)
        {
            try
            {
                var result = db.fn_TimKhachHangCuaThang(thang, nam).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<fn_TimKhachHangCuaNam_Result> KhachHangCuaNam(int nam)
        {
            try
            {
                var result = db.fn_TimKhachHangCuaNam(nam).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable ConvertToDataTable<T>(List<T> data)
        {
            var dataTable = new DataTable();
            var properties = typeof(T).GetProperties();

            foreach (var prop in properties)
            {
                dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (var item in data)
            {
                var row = dataTable.NewRow();
                foreach (var prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}
