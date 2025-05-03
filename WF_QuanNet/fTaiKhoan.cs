using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_QuanNet.CustomComponent;

namespace WF_QuanNet
{
    public partial class fTaiKhoan: Form
    {
        private DBTaiKhoan taiKhoanDAL;
        public fTaiKhoan()
        {
            taiKhoanDAL = DBTaiKhoan.Instance;
            InitializeComponent();
            LoadTk();
        }
        private void LoadTk()
        {
            string searchText = searchTxtBox.Texts?.Trim();
            List<DanhSachTaiKhoan> list;

            // Lấy danh sách tài khoản dựa vào từ khóa tìm kiếm
            if (string.IsNullOrEmpty(searchText))
            {
                list = taiKhoanDAL.LayDanhSachTaiKhoan();
            }
            else
            {
                // Tìm kiếm và ánh xạ từ kết quả EF sang DTO DanhSachTaiKhoan
                list = taiKhoanDAL.TimTaiKhoan(searchText)
                    .Select(result => new DanhSachTaiKhoan
                    {
                        TenDangNhap = result.TenDangNhap,
                        MatKhau = result.MatKhau,
                        SoDu = result.SoDu,
                        NgayTao = result.NgayTao,
                        TrangThai = result.TrangThai
                    }).ToList();
            }

            // Hiển thị lên DataGridView
            dgvTK.Rows.Clear();
            foreach (var account in list)
            {
                dgvTK.Rows.Add(
                    account.TenDangNhap,
                    formatPrice(account.SoDu),
                    account.TrangThai,
                    account.NgayTao.ToString("dd/MM/yyyy hh:mm:ss tt")
                );
            }
        }
        private string formatPrice(long price)
        {
            return price.ToString("N0") + " VNĐ";
        }
        private void themMoiTkBtn_Click(object sender, EventArgs e)
        {
            lmTkBtn_Click(sender, e);
            usnTxtBox.Enabled = true;
            checkBox1.Checked = false;
            checkBox1.Enabled = false;
            themTkBtn.Visible = true;
            suaTkBtn.Visible = false;
            lmTkBtn.Visible = true;
            khoaBtn.Visible = false;
            huyTkBtn.Visible = true;
            ntBtn.Visible = false;
            infoPnl.Visible = true;
        }

        private void lmTkBtn_Click(object sender, EventArgs e)
        {
            usnTxtBox.Texts = "";
            sdTxtBox.Texts = "";
            mkTxtBox.Texts = "1";
        }

        private void searchTxtBox_Click(object sender, EventArgs e)
        {

        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            LoadTk();
        }

        private void themTkBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn tạo tài khoản này không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (result == DialogResult.No)
                {
                    return;
                }
                string tenTk = usnTxtBox.Texts;
                int soDu = Convert.ToInt32(sdTxtBox.Texts);
                taiKhoanDAL.ThemTaiKhoan(tenTk, soDu);
                MessageBox.Show("Thêm tài khoản thành công.");
                LoadTk();
                infoPnl.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void suaTkBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTK.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show(
                        "Bạn có chắc chắn muốn sửa tài khoản này không?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );
                    if (result == DialogResult.No)
                    {
                        return;
                    }
                    DataGridViewRow row = dgvTK.SelectedRows[0];
                    string tenTk = usnTxtBox.Texts;
                    string matKhau = mkTxtBox.Texts;
                    int soDu = Convert.ToInt32(sdTxtBox.Texts);
                    taiKhoanDAL.SuaTaiKhoan(tenTk, matKhau, soDu);
                    MessageBox.Show("Sửa tài khoản thành công.");
                    LoadTk();
                    foreach (DataGridViewRow dr in dgvTK.Rows)
                    {
                        if (dr.Cells["tendangnhap"].Value.ToString() == tenTk)
                        {
                            dr.Selected = true;
                            dgvTK.CurrentCell = dr.Cells[0];
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void huyTkBtn_Click(object sender, EventArgs e)
        {
            infoPnl.Visible = false;
            dgvTK.ClearSelection();
        }

        private void khoaBtn_Click(object sender, EventArgs e)
        {
            string text = khoaBtn.Text;
            DataGridViewRow row = dgvTK.SelectedRows[0];
            string tenTk = row.Cells["tendangnhap"].Value.ToString();
            if (text == "Khóa")
            {
                if (dgvTK.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show(
                        "Bạn có chắc chắn muốn " + khoaBtn.Text.ToLower() + " tài khoản này không?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );
                    if (result == DialogResult.Yes)
                    {
                        taiKhoanDAL.KhoaTaiKhoan(tenTk);
                        MessageBox.Show("Khóa tài khoản thành công.");
                        khoaBtn.Text = "Mở khóa";
                    }
                }
            }
            else
            {
                if (dgvTK.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show(
                        "Bạn có chắc chắn muốn " + khoaBtn.Text.ToLower() + " tài khoản này không?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );
                    if (result == DialogResult.Yes)
                    {
                        taiKhoanDAL.MoKhoaTaiKhoan(tenTk);
                        MessageBox.Show("Mở Khóa tài khoản thành công.");
                        khoaBtn.Text = "Khóa";
                    }
                }
            }
            LoadTk();
            foreach (DataGridViewRow dr in dgvTK.Rows)
            {
                if (dr.Cells["tendangnhap"].Value.ToString() == tenTk)
                {
                    dr.Selected = true;
                    dgvTK.CurrentCell = dr.Cells[0];
                    break;
                }
            }
        }

        private void ntBtn_Click(object sender, EventArgs e)
        {
            if (dgvTK.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvTK.SelectedRows[0];
                string tenTk = row.Cells["tendangnhap"].Value.ToString();
                fNT fNT = new fNT(tenTk);
                using (fBlur fBlur = new fBlur(fMenu.ActiveForm))
                {
                    fBlur.Show();
                    fNT.ShowDialog();
                    fBlur.Close();
                    LoadTk();
                }
                foreach (DataGridViewRow dr in dgvTK.Rows)
                {
                    if (dr.Cells["tendangnhap"].Value.ToString() == tenTk)
                    {
                        dr.Selected = true;
                        dgvTK.CurrentCell = dr.Cells[0];
                        break;
                    }
                }
            }
        }

        private void dgvTK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTK.Rows[e.RowIndex];
                List<DanhSachTaiKhoan> list = taiKhoanDAL.TimTaiKhoan(row.Cells["tendangnhap"].Value.ToString())
                    .Select(result => new DanhSachTaiKhoan
                    {
                        TenDangNhap = result.TenDangNhap,
                        MatKhau = result.MatKhau,
                        SoDu = result.SoDu,
                        NgayTao = result.NgayTao,
                        TrangThai = result.TrangThai
                    }).ToList();
                var dr = list[0];
                sdTxtBox.Texts = dr.SoDu.ToString();
                usnTxtBox.Texts = dr.TenDangNhap;
                mkTxtBox.Texts = dr.MatKhau;
                checkBox1.Checked = false;
                usnTxtBox.Enabled = false;
                checkBox1.Enabled = true;
                themTkBtn.Visible = false;
                khoaBtn.Visible = true;
                suaTkBtn.Visible = true;
                lmTkBtn.Visible = false;
                huyTkBtn.Visible = true;
                ntBtn.Visible = DBNhanVien.Instance.LayNVDangNhap().Count == 0 ? false : true;
                infoPnl.Visible = true;
                if (dr.TrangThai == "Bị khóa")
                {
                    khoaBtn.Text = "Mở khóa";
                }
                else khoaBtn.Text = "Khóa";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                mkTxtBox.Enabled = true;
            }
            else
            {
                mkTxtBox.Enabled = false;
            }
        }

        private void mkTxtBox__TextChanged(object sender, EventArgs e)
        {

        }
    }
}
