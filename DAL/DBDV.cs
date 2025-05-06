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
            
            list = QuanLyTiemNetEntities.Instance.View_DichVuDoAn.ToList();
            return list;
        }

        public void ThemDVDoAn(string tenDoAn, int donGia, bool bestSeller)
        {
            QuanLyTiemNetEntities.Instance.proc_ThemDVDoAn(tenDoAn, donGia, bestSeller);
        }

        public void SuaDVDoAn(string maDV, string tenDoAn, int donGia, bool bestSeller, string trangThai)
        {
            QuanLyTiemNetEntities.Instance.proc_SuaDVDoAn(maDV, tenDoAn, donGia, bestSeller, trangThai);
        }
        public List<View_DichVuDoAn> TimKiemDVDA(string query)
        {
            var x = QuanLyTiemNetEntities.Instance.fn_TimKiemDVDA(query).ToList();
            List<View_DichVuDoAn> list = (from item in x
                                          select new View_DichVuDoAn
                                          {
                                              MaDV = item.MaDV,
                                              TenDoAn = item.TenDoAn,
                                              DonGia = item.DonGia,
                                              BestSeller = item.BestSeller,
                                              TrangThai = item.TrangThai
                                          }).ToList();
            return list;
        }

        public List<View_DichVuDoUong> TimKiemDVDU(string query)
        {
            var x = QuanLyTiemNetEntities.Instance.fn_TimKiemDVDU(query).ToList();
            List<View_DichVuDoUong> list = (from item in x
                                            select new View_DichVuDoUong
                                            {
                                                MaDV = item.MaDV,
                                                TenDoUong = item.TenDoUong,
                                                DonGia = item.DonGia,
                                                BestSeller = item.BestSeller,
                                                TrangThai = item.TrangThai
                                            }).ToList();
            return list;
        }

        public List<View_DichVuTheCao> TimKiemDVTC(string query)
        {
            var x = QuanLyTiemNetEntities.Instance.fn_TimKiemDVTC(query).ToList();
            List<View_DichVuTheCao> list = (from item in x
                                            select new View_DichVuTheCao
                                            {
                                                MaDV = item.MaDV,
                                                LoaiThe = item.LoaiThe,
                                                MenhGia = item.MenhGia,
                                            }).ToList();
            return list;
        }

        public void XoaDichVu(string maDV)
        {
            QuanLyTiemNetEntities.Instance.proc_XoaDV(maDV);
        }

        public List<View_DichVuDoUong> LayDSDVDU()
        {
            return QuanLyTiemNetEntities.Instance.View_DichVuDoUong.ToList();
        }

        public List<View_DichVuTheCao> LayDSDVTC()
        {
            return QuanLyTiemNetEntities.Instance.View_DichVuTheCao.ToList();
        }

        public void ThemDVDouong(string tenDoUong, int donGia, bool bestSeller)
        {
            QuanLyTiemNetEntities.Instance.proc_ThemDVDouong(tenDoUong, donGia, bestSeller);
        }

        public void SuaDVDouong(string maDV, string tenDoUong, int donGia, bool bestSeller, string trangThai)
        {
            QuanLyTiemNetEntities.Instance.proc_SuaDVDouong(maDV, tenDoUong, donGia, bestSeller, trangThai);
        }

        public void ThemDVTheCao(string loaiThe, int menhGia)
        {
            QuanLyTiemNetEntities.Instance.proc_ThemDVTheCao(loaiThe, menhGia);
        }

        public void SuaDVTheCao(string maDV, string loaiThe, int menhGia)
        {
            QuanLyTiemNetEntities.Instance.proc_SuaDVTheCao(maDV, loaiThe, menhGia);
        }



    }
}
