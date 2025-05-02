using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBDichVu
    {
        private static DBDichVu instance;
        public static DBDichVu Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DBDichVu();
                }
                return instance;
            }
        }
        private DBDichVu() { }
        
        public List<View_DichVuDoAn> View_DichVuDoAns()
        {
            List<View_DichVuDoAn> list = new List<View_DichVuDoAn>();
            QuanLyTiemNetEntities db = new QuanLyTiemNetEntities();
            list = db.View_DichVuDoAn.ToList();
            return list;
        }
    }
}
