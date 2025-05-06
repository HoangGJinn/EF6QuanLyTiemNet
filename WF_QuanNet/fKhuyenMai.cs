using DAL;
using DTO;
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

namespace WF_QuanNet
{
    public partial class fKhuyenMai : Form
    {
        private DBKhuyenMai dBKhuyenMai;
        private bool isRefreshing = false;
        public fKhuyenMai()
        {
            InitializeComponent();
            dBKhuyenMai = DBKhuyenMai.Instance;
            lkmCbBox.DisplayMember = "TenLoai";
            lkmCbBox.ValueMember = "MaLoai";
            lkmCbBox.DataSource = DBKhuyenMai.Instance.MaLoaiKM();
            lkmCbBox.SelectedIndex = 0;
            beginPick.Format = DateTimePickerFormat.Custom;
            beginPick.CustomFormat = "dd/MM/yyyy";
            endPick.Format = DateTimePickerFormat.Custom;
            endPick.CustomFormat = "dd/MM/yyyy";
            filterBegin.Format = DateTimePickerFormat.Custom;
            filterBegin.CustomFormat = "dd/MM/yyyy";
            filterBegin.Value = DateTime.Now - TimeSpan.FromDays(30);
            filterEnd.Format = DateTimePickerFormat.Custom;
            filterEnd.CustomFormat = "dd/MM/yyyy";
            loadDsKm();
        }

        private void loadDsKm()
        {
            string searchText = searchBox.Texts;
            string query = searchText;
            List<DanhSachKhuyenMai> dt = dBKhuyenMai.LayDsKhuyenMai();
            dgvKm.Rows.Clear();
            if (string.IsNullOrEmpty(searchText))
            {
                dt = dBKhuyenMai.LayDsKhuyenMai();
            }
            else
            {
                dt = dBKhuyenMai.TimKhuyenMai(searchText, filterBegin.Value, filterEnd.Value );
            }
            foreach (var item in dt)
            {
                int index = dgvKm.Rows.Add();
                dgvKm.Rows[index].Cells["makm"].Value = item.MaKM;
                dgvKm.Rows[index].Cells["ten"].Value = item.TenChTrinh;
                dgvKm.Rows[index].Cells["sotientt"].Value = item.SoTienToiThieuApDung;
                dgvKm.Rows[index].Cells["toida"].Value = item.KMToiDa;
                dgvKm.Rows[index].Cells["tlkm"].Value = item.TyLeKM;
                dgvKm.Rows[index].Cells["begin"].Value = item.ThoiGianBatDau.ToString("dd/MM/yyyy");
                dgvKm.Rows[index].Cells["end"].Value = item.ThoiGianKetThuc.ToString("dd/MM/yyyy");
                dgvKm.Rows[index].Cells["loai"].Value = item.MaLoaiKM;
            }
        }



        private void themKmBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string tenChTrinh = tenTxtBox.Texts;
                int tyLeKM = int.Parse(tyleTxtBox.Texts);
                int soTienToiThieuApDung = int.Parse(ttTxtBox.Texts);
                int kmToiDa = int.Parse(tdTxtBox.Texts);
                DateTime thoiGianBatDau = beginPick.Value;
                DateTime thoiGianKetThuc = endPick.Value;
                int maLoaiKM = int.Parse(lkmCbBox.SelectedValue.ToString());
                DBKhuyenMai.Instance.ThemKhuyenMai(tenChTrinh, tyLeKM, soTienToiThieuApDung, kmToiDa, thoiGianBatDau, thoiGianKetThuc, maLoaiKM);
                MessageBox.Show("Thêm thành công");
                loadDsKm();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void suaKmBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvKm.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show(
                        "Bạn có chắc chắn muốn sửa khuyến mãi này không?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );
                    if (result == DialogResult.No)
                    {
                        return;
                    }
                    DataGridViewRow row = dgvKm.SelectedRows[0];
                    string makm = row.Cells["makm"].Value.ToString();
                    string tenChTrinh = tenTxtBox.Texts;
                    int tyLeKM = int.Parse(tyleTxtBox.Texts);
                    int soTienToiThieuApDung = int.Parse(ttTxtBox.Texts);
                    int kmToiDa = int.Parse(tdTxtBox.Texts);
                    DateTime thoiGianBatDau = beginPick.Value;
                    DateTime thoiGianKetThuc = endPick.Value;
                    int maLoaiKM = int.Parse(lkmCbBox.SelectedValue.ToString());
                    DBKhuyenMai.Instance.SuaKhuyenMai(makm, tenChTrinh, tyLeKM, soTienToiThieuApDung, kmToiDa, thoiGianBatDau, thoiGianKetThuc, maLoaiKM);
                    MessageBox.Show("Sửa thành công");
                    loadDsKm();
                    foreach (DataGridViewRow dr in dgvKm.Rows)
                    {
                        if (dr.Cells["makm"].Value.ToString() == makm)
                        {
                            dr.Selected = true;
                            dgvKm.CurrentCell = dr.Cells[0];
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

        private void xoaKmBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvKm.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show(
                        "Bạn có chắc chắn muốn xóa khuyến mãi này không?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );
                    if (result == DialogResult.No)
                    {
                        return;
                    }
                    DataGridViewRow row = dgvKm.SelectedRows[0];
                    string makm = row.Cells["makm"].Value.ToString();
                    DBKhuyenMai.Instance.XoaKhuyenMai(makm);
                    MessageBox.Show("Xóa thành công");
                    loadDsKm();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn khuyến mãi để xóa");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void huyBtn_Click(object sender, EventArgs e)
        {
            suaKmBtn.Visible = false;
            xoaKmBtn.Visible = false;
            huyBtn.Visible = false;
            tenTxtBox.Texts = "";
            ttTxtBox.Texts = "";
            tdTxtBox.Texts = "";
            tyleTxtBox.Texts = "";
            dgvKm.ClearSelection();
        }

        private void lamMoiBtn_Click(object sender, EventArgs e)
        {
            searchBox.Texts = "";
            isRefreshing = true;
            filterBegin.Value = DateTime.Now - TimeSpan.FromDays(30);
            filterEnd.Value = DateTime.Now;
            isRefreshing = false;
            loadDsKm();
        }

        private void dgvKm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = dgvKm.Rows[e.RowIndex];

                tenTxtBox.Texts = row.Cells["ten"].Value.ToString();
                ttTxtBox.Texts = row.Cells["sotientt"].Value.ToString();
                tdTxtBox.Texts = row.Cells["toida"].Value.ToString();
                tyleTxtBox.Texts = row.Cells["tlkm"].Value.ToString();
                beginPick.Value = DateTime.ParseExact(row.Cells["begin"].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                endPick.Value = DateTime.ParseExact(row.Cells["end"].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                lkmCbBox.SelectedValue = Convert.ToInt32(row.Cells["loai"].Value.ToString());
                suaKmBtn.Visible = true;
                xoaKmBtn.Visible = true;
                huyBtn.Visible = true;
            }
        }

        private void filterBegin_ValueChanged(object sender, EventArgs e)
        {
            loadDsKm();
        }

        private void filterEnd_ValueChanged(object sender, EventArgs e)
        {

            loadDsKm();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            loadDsKm();
        }
    }
}
