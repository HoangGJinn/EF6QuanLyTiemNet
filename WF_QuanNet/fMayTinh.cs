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
    public partial class fMayTinh: Form
    {
        private DBMT dbmt;
        private DBLM dblm;
        public fMayTinh()
        {
            dbmt = DBMT.Instance;
            dblm = DBLM.Instance;
            InitializeComponent();
            ngayld.Format = DateTimePickerFormat.Custom;
            ngayld.CustomFormat = "dd/MM/yyyy";
            lmCbBox.DisplayMember = "TenLoaiMay";
            lmCbBox.ValueMember = "MaLoaiMay";
            lmCbBox.DataSource = dblm.LayDsLoaiMay();
            lmCbBox.SelectedIndex = 0;
            statusCbBox.DataSource = new List<string> { "Không hoạt động", "Hư hỏng" };
            LoadMT();
            LoadLM();
        }
        private void LoadMT()
        {
            string searchText = searchMTTxtBox.Texts;
            List<DanhSachMayTinh> list = null;
            dgvMT.Rows.Clear();
            if (string.IsNullOrEmpty(searchText))
            {
                list = dbmt.LayDsMayTinh();
            }
            else
            {
                list = dbmt.TimKiemMayTinh(searchText)
                    .Select(result => new DanhSachMayTinh
                    {
                        SoMay = result.SoMay,
                        TrangThai = result.TrangThai,
                        NgayLapDat = result.NgayLapDat,
                        TongTGSD = result.TongTGSD,
                        MaLoaiMay = result.MaLoaiMay
                    }).ToList();
            }
            foreach (DanhSachMayTinh item in list)
            {
                object[] r = new object[]
                {
                    item.SoMay,
                    item.TrangThai,
                    item.NgayLapDat.ToString("dd/MM/yyyy"),
                    item.TongTGSD.ToString(),
                    item.MaLoaiMay.ToString()
                };
                dgvMT.Rows.Add(r);
            }
        }

        private void LoadLM()
        {
            string searchText = searchLMTxtBox.Texts;
            List<DanhSachLoaiMay> list = null;
            dgvLM.Rows.Clear();
            if (string.IsNullOrEmpty(searchText))
            {
                list = dblm.LayDsLoaiMay();
            }
            else
            {
                list = dblm.TimKiemLoaiMay(searchText)
                    .Select(result => new DanhSachLoaiMay
                    {
                        MaLoaiMay = result.MaLoaiMay,
                        TenLoaiMay = result.TenLoaiMay,
                        SoTienMotGio = result.SoTienMotGio
                    }).ToList();
            }
            foreach (DanhSachLoaiMay item in list)
            {
                object[] r = new object[]
                {
                    item.MaLoaiMay.ToString(),
                    item.TenLoaiMay.ToString(),
                    formatPrice(Convert.ToInt64(item.SoTienMotGio)),

                };
                dgvLM.Rows.Add(r);
            }
        }

        private string formatPrice(long price)
        {
            return price.ToString("N0") + " VNĐ";
        }
        private void searchMtBtn_Click(object sender, EventArgs e)
        {
            LoadMT();
        }

        private void searchLmBtn_Click(object sender, EventArgs e)
        {
            LoadLM();
        }

        private void themMtBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn thêm mới máy tính không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                DateTime nld = ngayld.Value;
                int maLoaiMay = int.Parse(lmCbBox.SelectedValue.ToString());
                dbmt.ThemMayTinh(nld, maLoaiMay);
                LoadMT();
                MessageBox.Show("Thêm máy tính thành công");
                huyMtBtn_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void suaMtBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMT.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show(
                        "Bạn có chắc chắn muốn sửa thông tin máy tính này không?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );
                    if (result == DialogResult.No)
                    {
                        return;
                    }
                    string soMay = dgvMT.SelectedRows[0].Cells["SoMay"].Value.ToString();
                    string trangThai = statusCbBox.Texts;
                    int maLoaiMay = int.Parse(lmCbBox.SelectedValue.ToString());
                    dbmt.SuaMayTinh(soMay, trangThai, maLoaiMay);
                    LoadMT();
                    MessageBox.Show("Sửa máy tính thành công");
                    foreach (DataGridViewRow row in dgvMT.Rows)
                    {
                        if (row.Cells["SoMay"].Value.ToString() == soMay)
                        {
                            row.Selected = true;
                            dgvMT.CurrentCell = row.Cells[0];
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

        private void huyMtBtn_Click(object sender, EventArgs e)
        {
            ngayld.Value = DateTime.Now;
            statusCbBox.Visible = false;
            lmCbBox.SelectedIndex = 0;
            dgvMT.ClearSelection();
            label4.Visible = false;
            huyMtBtn.Visible = false;
            suaMtBtn.Visible = false;
        }

        private void themLmBtn_Click(object sender, EventArgs e)
        {
            fThemLM fThemLM = new fThemLM();
            using (fBlur fBlur = new fBlur(fMenu.ActiveForm))
            {
                fBlur.Show();
                fThemLM.ShowDialog();
                fBlur.Close();
                huyLmBtn_Click(sender, e);
                LoadLM();
            }
        }

        private void suaLmBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvLM.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show(
                        "Bạn có chắc chắn muốn sửa thông tin loại máy này không?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );
                    if (result == DialogResult.No)
                    {
                        return;
                    }
                    string maLoaiMay = dgvLM.SelectedRows[0].Cells["id"].Value.ToString();
                    string tenLoaiMay = tenLoaiTxtBox.Texts;
                    int soTienMotGio = Convert.ToInt32(st1hTxtBox.Texts);
                    dblm.SuaLoaiMay(int.Parse(maLoaiMay), tenLoaiMay, soTienMotGio);
                    LoadLM();
                    MessageBox.Show("Sửa loại máy thành công");
                    foreach (DataGridViewRow row in dgvLM.Rows)
                    {
                        if (row.Cells["id"].Value.ToString() == maLoaiMay)
                        {
                            row.Selected = true;
                            dgvLM.CurrentCell = row.Cells[0];
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

        private void xoaLmBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvLM.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show(
                        "Bạn có chắc chắn muốn xóa loại máy này không?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );
                    if (result == DialogResult.No)
                    {
                        return;
                    }
                    string maLoaiMay = dgvLM.SelectedRows[0].Cells["id"].Value.ToString();
                    dblm.XoaLoaiMay(int.Parse(maLoaiMay));
                    LoadLM();
                    infoLMPnl.Visible = false;
                    MessageBox.Show("Xóa loại máy thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void huyLmBtn_Click(object sender, EventArgs e)
        {
            infoLMPnl.Visible = false;
            dgvLM.ClearSelection();
        }

        private void lklmBtn_Click(object sender, EventArgs e)
        {
            if (dgvLM.SelectedRows.Count > 0)
            {
                int maLoaiMay = Convert.ToInt32(dgvLM.SelectedRows[0].Cells["id"].Value);
                fLK fLK = new fLK(maLoaiMay);
                using (fBlur fBlur = new fBlur(fMenu.ActiveForm))
                {
                    fBlur.Show();
                    fLK.ShowDialog();
                    fBlur.Close();
                }
            }
        }
        private void dgvMT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMT.Rows[e.RowIndex];
                string soMay = row.Cells["SoMay"].Value.ToString();

                List<func_timKiemMayTinh_Result> list = dbmt.TimKiemMayTinh(soMay);
                if (list.Count > 0)
                {
                    func_timKiemMayTinh_Result result = list[0];
                    ngayld.Value = result.NgayLapDat;
                    statusCbBox.Texts = result.TrangThai;
                    lmCbBox.SelectedValue = result.MaLoaiMay;
                }

                // Ensure visibility of controls
                huyMtBtn.Visible = true;
                suaMtBtn.Visible = true;
                label4.Visible = true;
                statusCbBox.Visible = true;
            }
        }

        private void dgvLM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLM.Rows[e.RowIndex];
                string maLoaiMay = row.Cells["id"].Value.ToString();
                string tenLoaiMay = row.Cells["namelm"].Value.ToString();
                string soTienMotGio = row.Cells["sotien"].Value.ToString().Replace(" VNĐ", "").Replace(",", "");
                tenLoaiTxtBox.Texts = tenLoaiMay;
                st1hTxtBox.Texts = soTienMotGio;
                infoLMPnl.Visible = true;
            }
        }

        private void mtPnl_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
