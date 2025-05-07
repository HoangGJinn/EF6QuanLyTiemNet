using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DBKhuyenMai
    {
        private static DBKhuyenMai instance;
        public static DBKhuyenMai Instance
        {
            get
            {
                if (instance == null)
                    instance = new DBKhuyenMai();
                return instance;
            }
            private set { instance = value; }
        }
        private DBKhuyenMai() { }


        public List<DanhSachKhuyenMai> LayDsKhuyenMai()
        {
            try
            {
                return QuanLyTiemNetEntities.Instance.DanhSachKhuyenMais.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<DanhSachKhuyenMai> TimKhuyenMai(string query, DateTime? batdau = null, DateTime? ketthuc = null)
        {
                var quere = QuanLyTiemNetEntities.Instance.proc_TimKhuyenMai(batdau, ketthuc, query);
                List<DanhSachKhuyenMai> list = (from item in quere
                                                select new DanhSachKhuyenMai
                                                {
                                                    MaKM = item.MaKM,
                                                    TenChTrinh = item.TenChTrinh,
                                                    SoTienToiThieuApDung = item.SoTienToiThieuApDung,
                                                    KMToiDa = item.KMToiDa,
                                                    TyLeKM = item.TyLeKM,
                                                    ThoiGianBatDau = item.ThoiGianBatDau,
                                                    ThoiGianKetThuc = item.ThoiGianKetThuc,
                                                    MaLoaiKM = item.MaLoaiKM
                                                }).ToList();
                return list;

        }



        public List<LOAIKM> MaLoaiKM()
        {
            try
            {
                return QuanLyTiemNetEntities.Instance.LOAIKMs.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SuaKhuyenMai(string MaKM, string tenChTrinh, int tyLeKM, int soTienToiThieuApDung, int kmToiDa, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, int maLoaiKM)
        {
            try
            {
                QuanLyTiemNetEntities db = new QuanLyTiemNetEntities();
                db.sp_UpdateKhuyenMai(MaKM, tenChTrinh, tyLeKM, soTienToiThieuApDung, kmToiDa, thoiGianBatDau, thoiGianKetThuc, maLoaiKM);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool ThemKhuyenMai(string tenChTrinh, int tyLeKM, int soTienToiThieuApDung, int kmToiDa, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, int maLoaiKM)
        {
            try
            {
               QuanLyTiemNetEntities db = new QuanLyTiemNetEntities();
                db.sp_InsertKhuyenMai(tenChTrinh, tyLeKM, soTienToiThieuApDung, kmToiDa, thoiGianBatDau, thoiGianKetThuc, maLoaiKM);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool XoaKhuyenMai(string MaKM)
        {
            try
            {
                QuanLyTiemNetEntities db = new QuanLyTiemNetEntities();
                db.sp_DeleteKhuyenMai(MaKM);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

        public List<fn_TimKMChoHDNapTien_Result> LayDsKhuyenMaiTheoTienNap(int TienNap)
        {
            try
            {
                return QuanLyTiemNetEntities.Instance.fn_TimKMChoHDNapTien(TienNap).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int SoKhuyenMaiSapHetHan(int soNgay)
        {
            try
            {
                DateTime currentDate = DateTime.Now;
                DateTime targetDate = currentDate.AddDays(soNgay);

                // Ensure QuanLyTiemNetEntities has a DbSet or property for KhuyenMais  
                var khuyenMais = QuanLyTiemNetEntities.Instance.KHUYENMAIs
                    .Where(km => km.ThoiGianBatDau <= targetDate && km.ThoiGianKetThuc >= currentDate)
                    .ToList();

                return khuyenMais.Count(); // Fix method invocation for Count  
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int SoKMKhaDung()
        {
            try
            {
                DateTime currentDate = DateTime.Now;
                // Ensure QuanLyTiemNetEntities has a DbSet or property for KhuyenMais  
                var khuyenMais = QuanLyTiemNetEntities.Instance.KHUYENMAIs
                    .Where(km => km.ThoiGianBatDau <= currentDate && km.ThoiGianKetThuc >= currentDate)
                    .ToList();
                return khuyenMais.Count(); // Fix method invocation for Count  
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}
