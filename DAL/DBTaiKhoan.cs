﻿using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{ 
    /// <summary>
    
    public class DBTaiKhoan
    {
        public static string ConnectionString { get; set; }
        private static DBTaiKhoan instance;
        public static DBTaiKhoan Instance
        {
            get
            {
                if (instance == null)
                    instance = new DBTaiKhoan();
                return instance;
            }
            private set { instance = value; }
        }
        private DBTaiKhoan() { }
        public string BeginConnection(string usn, string pss)
        {
            try
            {
                string efConnectionString = DbHelper.BuildEntityConnectionString(usn, pss);
                ConnectionString = efConnectionString;
                using (var context = new QuanLyTiemNetEntities(efConnectionString))
                {
                    var role = context.GetRoleFromUsername(usn);

                    return role;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("5. Lỗi: " + ex.Message + "\n\nChi tiết:\n" + ex.StackTrace, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception("Lỗi khi kết nối đến cơ sở dữ liệu.", ex);
            }
        }
        public List<DanhSachTaiKhoan> LayDanhSachTaiKhoan()
        {
            List<DanhSachTaiKhoan> list = QuanLyTiemNetEntities.Instance.DanhSachTaiKhoans.ToList();
            return list;
        }

        public void ThemTaiKhoan(string TenTaiKhoan, int SoDu)
        {
            try
            {
                QuanLyTiemNetEntities.Instance.sp_ThemTaiKhoan(
                    string.IsNullOrEmpty(TenTaiKhoan) ? null : TenTaiKhoan,
                    SoDu);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SuaTaiKhoan(string TenTaiKhoan, string MatKhau, int SoDu)
        {
            try
            {
                QuanLyTiemNetEntities.Instance.sp_SuaTaiKhoan(
                    string.IsNullOrEmpty(TenTaiKhoan) ? null : TenTaiKhoan,
                    string.IsNullOrEmpty(MatKhau) ? null : MatKhau,
                    SoDu);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int TinhTkMoi()
        {
            try
            {
                int tkmoi = 0;
                try
                {
                    tkmoi = QuanLyTiemNetEntities.Instance.TAIKHOANs.Where
                        (tk => tk.NgayTao.Month == DateTime.Now.Month &&


                        tk.NgayTao.Year == DateTime.Now.Year).Count();
                }
                catch (Exception ex)
                {
                    tkmoi = 0;
                }
                return tkmoi;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<fn_LayTaiKhoanTheoTenDangNhap_Result> TimTaiKhoan(string timKiem)
        {
            try
            {
                return QuanLyTiemNetEntities.Instance.fn_LayTaiKhoanTheoTenDangNhap(timKiem).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool MoKhoaTaiKhoan(string TenTaiKhoan)
        {
            try
            {
                QuanLyTiemNetEntities.Instance.proc_MoKhoaTaiKhoan(TenTaiKhoan);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool KhoaTaiKhoan(string TenTaiKhoan)
        {
            try
            {
                QuanLyTiemNetEntities.Instance.proc_KhoaTaiKhoan(TenTaiKhoan);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
