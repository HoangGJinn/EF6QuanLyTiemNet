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
    }
}
