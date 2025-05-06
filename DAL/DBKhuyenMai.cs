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
