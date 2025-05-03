using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_QuanNet.CustomComponent;
using DAL;
using DTO;

namespace WF_QuanNet
{
    public partial class fNhanVien : Form
    {
        private DBNhanVien dbNhanVien;
        public fNhanVien()
        {
            dbNhanVien = DBNhanVien.Instance;
            InitializeComponent();
            gtCbBox.DataSource = new List<string> { "Nam", "Nữ" };
            gtCbBox.Texts = "Nam";
            dobPick.Format = DateTimePickerFormat.Custom;
            dobPick.CustomFormat = "dd/MM/yyyy";
            dgvStaff.EnableHeadersVisualStyles= false;
            LoadNV();

        }
        private void LoadNV()
        {
            string searchText = searchTxtBox.Texts;
            List<DanhSachNhanVien> dt = null;

            if (string.IsNullOrEmpty(searchText))
            {
                dt = dbNhanVien.LayDsNhanVien();
            }
            else
            {
                dt = dbNhanVien.TimNhanVien(searchText);
            }

            //dgvStaff.Rows.Clear();
            dgvStaff.DataSource = dt;
        }
        private string formatPrice(long price)
        {
            return price.ToString("N0") + " VNĐ";
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStaff.Rows[e.RowIndex];
                int staffId = Convert.ToInt32(row.Cells["id"].Value);
                lmNvBtn_Click(sender, e);
                tenNvTxtBox.Texts = row.Cells["full_name"].Value.ToString();
                sdtTxtBox.Texts = row.Cells["sdt"].Value.ToString();
                dcTxtBox.Texts = row.Cells["diachi"].Value.ToString();
                gtCbBox.Texts = row.Cells["gender"].Value.ToString();
                DateTime dateTime = Convert.ToDateTime(row.Cells["ngaysinh"].Value);
                dobPick.Value = dateTime;
                suaNvBtn.Visible = true;
                lmNvBtn.Visible = true;
                xoaNvBtn.Visible = true;
                infoPanel.Visible = true;
                mkBtn.Visible = true;
                sdtTxtBox.Enabled = false;
            }
        }

        private void themMoiNvBtn_Click(object sender, EventArgs e)
        {
            
            lmNvBtn_Click(sender, e);
            infoPanel.Visible = true;
            suaNvBtn.Visible = false;
            lmNvBtn.Visible = false;
            xoaNvBtn.Visible = false;
            themNvBtn.Visible = true;
            mkBtn.Visible = false;
            sdtTxtBox.Enabled = true;
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            LoadNV();
        }

        private void themNvBtn_Click(object sender, EventArgs e)
        {
            
            try
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn thêm nhân viên này không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (result == DialogResult.No)
                {
                    return;
                }
                string tenNv = tenNvTxtBox.Texts;
                string sdt = sdtTxtBox.Texts;
                string diaChi = dcTxtBox.Texts;
                string gioiTinh = gtCbBox.Texts;
                dbNhanVien.ThemNhanVien(new NHANVIEN
                {
                    HoTen = tenNv,
                    SDT = sdt,
                    DiaChi = diaChi,
                    GioiTinh = gioiTinh,
                    NgaySinh = dobPick.Value
                });
                infoPanel.Visible = false;
                LoadNV();
                MessageBox.Show("Thêm nhân viên thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            

        }

        private void lmNvBtn_Click(object sender, EventArgs e)
        {
            /*
            tenNvTxtBox.Texts = string.Empty;
            sdtTxtBox.Texts = string.Empty;
            dcTxtBox.Texts = string.Empty;
            gtCbBox.Texts = string.Empty;
            dobPick.Value = DateTime.Now;
            gtCbBox.SelectedIndex = 0;
            */
        }

        private void suaNvBtn_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (dgvStaff.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show(
                        "Bạn có chắc chắn muốn sửa thông tin nhân viên này không?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );
                    if ( result == DialogResult.No ) 
                    {
                        return;
                    }
                    DataGridViewRow row = dgvStaff.SelectedRows[0];
                    string maNv = row.Cells["id"].Value.ToString();
                    string tenNv = tenNvTxtBox.Texts;
                    string diaChi = dcTxtBox.Texts;
                    string gioiTinh = gtCbBox.Texts;
                    DateTime dob = dobPick.Value;
                    dbNhanVien.SuaNhanVien(new NHANVIEN
                    {
                        MaNV = int.Parse(maNv),
                        HoTen = tenNv,
                        DiaChi = diaChi,
                        GioiTinh = gioiTinh,
                        NgaySinh = dob
                    });
                    LoadNV();
                    MessageBox.Show("Sửa nhân viên thành công");
                    foreach (DataGridViewRow dr in dgvStaff.Rows)
                    {
                        if (dr.Cells["id"].Value.ToString() == maNv)
                        {
                            dr.Selected = true;
                            dgvStaff.CurrentCell = dr.Cells[0];
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

        private void xoaNvBtn_Click(object sender, EventArgs e)
        {
            
            string manv;
            try
            {
                if (dgvStaff.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show(
                        "Bạn có chắc chắn muốn xóa nhân viên này không?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );
                    if (result == DialogResult.No)
                    {
                        return;
                    }
                    DataGridViewRow row = dgvStaff.SelectedRows[0];
                    manv = row.Cells["id"].Value.ToString();
                    int id = int.Parse(manv);
                    dbNhanVien.XoaNhanVien(id);
                    MessageBox.Show("Xóa nhân viên thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LoadNV();
            infoPanel.Visible = false;
            
        }

        private void huyNvBtn_Click(object sender, EventArgs e)
        {

            infoPanel.Visible = false;
            dgvStaff.ClearSelection();
        }

        private void mkBtn_Click(object sender, EventArgs e)
        {
            /*
            if (dgvStaff.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvStaff.SelectedRows[0];
                string tenTk = row.Cells["sdt"].Value.ToString();
                fMKNV fNT = new fMKNV(tenTk);
                using (fBlur fBlur = new fBlur(fMenu.ActiveForm))
                {
                    fBlur.Show();
                    fNT.ShowDialog();
                    fBlur.Close();
                }
            }
            */
        }

        private void fNhanVien_Load(object sender, EventArgs e)
        {

        }
    }
}
