using BusinessAcessLayer;
using DAL;
using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_QuanNet.customcomponent;

namespace WF_QuanNet
{
    public partial class fDVNV : Form
    {
        private DBDichVu dbDichVu;
        private DBHoaDon dbHoaDon;
        private DBNhanVien dbNV;
        private Hashtable ucDichVus = new Hashtable();
        public fDVNV()
        {
            InitializeComponent();
            dbDichVu = DBDichVu.Instance;
            dbHoaDon = DBHoaDon.Instance;
            dbNV = DBNhanVien.Instance;
            dgvItem.Rows.Add("madv", "stt", "name", "price", "quantity", "totalPrice");
            dgvItem.Rows.Clear();
            LoadDV();
        }


        private void LoadDV()
        {
            flpDV.SuspendLayout();
            flpDV.Controls.Clear();
            string searchText = searchTxtBox.Texts.Trim();

            // Use List<T> from Entity Framework instead of DataTable
            IEnumerable<object> serviceList = null; // Use a common base or object to hold different view types

            try
            {
                if (da.Checked)
                {
                    if (!string.IsNullOrEmpty(searchText))
                    {
                        serviceList = dbDichVu.TimKiemDVDA(searchText);
                    }
                    else
                    {
                        serviceList = dbDichVu.View_DichVuDoAns(); // Corrected method call based on previous DAL code
                    }
                }
                else if (du.Checked)
                {
                    if (!string.IsNullOrEmpty(searchText))
                    {
                        serviceList = dbDichVu.TimKiemDVDU(searchText);
                    }
                    else
                    {
                        serviceList = dbDichVu.LayDSDVDU(); // Corrected method call based on previous DAL code
                    }
                }
                else // tc.Checked or default
                {
                    if (!string.IsNullOrEmpty(searchText))
                    {
                        serviceList = dbDichVu.TimKiemDVTC(searchText);
                    }
                    else
                    {
                        serviceList = dbDichVu.LayDSDVTC(); // Corrected method call based on previous DAL code
                    }
                }

                if (serviceList != null)
                {
                    foreach (var item in serviceList)
                    {
                        string maDV = "";
                        string tenDV = "";
                        long giaDV = 0;

                        // Determine type and extract data
                        if (item is View_DichVuDoAn doAn)
                        {
                            maDV = doAn.MaDV;
                            tenDV = doAn.TenDoAn;
                            giaDV = Convert.ToInt32(doAn.DonGia);
                        }
                        else if (item is View_DichVuDoUong doUong)
                        {
                            maDV = doUong.MaDV;
                            tenDV = doUong.TenDoUong;
                            giaDV = Convert.ToInt32(doUong.DonGia);
                        }
                        else if (item is View_DichVuTheCao theCao)
                        {
                            maDV = theCao.MaDV;
                            // Cố gắng định dạng MenhGia thành chuỗi "XK" nếu là bội số của 1000, ngược lại dùng chuỗi số đầy đủ
                            string menhGiaString;
                            if (theCao.MenhGia >= 1000 && theCao.MenhGia % 1000 == 0)
                            {
                                menhGiaString = (theCao.MenhGia / 1000) + "K";
                            }
                            else
                            {
                                menhGiaString = theCao.MenhGia.ToString();
                            }
                            // Kết hợp LoaiThe và chuỗi MenhGia đã định dạng để tạo tên dịch vụ
                            tenDV = $"{theCao.LoaiThe} {menhGiaString}";
                            giaDV = Convert.ToInt32(theCao.MenhGia); // Giữ nguyên logic lấy giá
                        }
                        // Add handling for fn_TimKMChoHDNapTien_Result if it's ever returned here, though less likely for this form

                        if (ucDichVus.ContainsKey(maDV))
                        {
                            flpDV.Controls.Add(ucDichVus[maDV] as UcDV);
                            continue;
                        }

                        string picName = tenDV.Trim();
                        string imagePath = Path.Combine(Application.StartupPath, "Images", picName + ".png");
                        string imagePath2 = Path.Combine(Application.StartupPath, "Images", picName + ".jpg");

                        UcDV ucItem = new UcDV();
                        ucItem.Tag = maDV; // Store MaDV in Tag
                        ucItem.name.Text = tenDV;
                        ucItem.price.Text = formatPrice(giaDV);

                        // Load image
                        Image image = null;
                        if (File.Exists(imagePath))
                        {

                            image = Image.FromFile(imagePath);
                        }
                        else if (File.Exists(imagePath2))
                        {
                            image = Image.FromFile(imagePath2);
                        }

                        if (image != null)
                        {
                            // Dispose previous image if any to prevent resource leaks
                            if (ucItem.pic.BackgroundImage != null)
                            {
                                ucItem.pic.BackgroundImage.Dispose();
                            }
                            ucItem.pic.BackgroundImage = image;
                            ucItem.pic.BackgroundImageLayout = ImageLayout.Stretch;
                        }
                        else
                        {
                            // Handle case where image is not found (e.g., display a default image or clear the background)
                            ucItem.pic.BackgroundImage = null; // Or a default image
                        }


                        RegisterClickEvents(ucItem, (s, e) =>
                        {
                            addItem(ucItem);
                        });

                        ucDichVus.Add(ucItem.Tag, ucItem); // Add to cache
                        flpDV.Controls.Add(ucItem); // Add to FlowLayoutPanel
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log or show an error message)
                MessageBox.Show($"Error loading services: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Depending on severity, you might rethrow or take other action
            }


            flpDV.ResumeLayout(true);
        }

        private void addItem(UcDV item)
        {
            string maDV = item.Tag.ToString(); // Get MaDV from Tag
            string tenDV = item.name.Text;
            // Parse price from formatted string
            long giaDV;
            if (!long.TryParse(item.price.Text.ToString().Replace(" đ", "").Replace(",", ""), out giaDV))
            {
                // Handle parsing error if necessary
                MessageBox.Show("Error parsing price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // Find existing row by MaDV
            DataGridViewRow existedRow = dgvItem.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => r.Cells["madv"].Value != null && r.Cells["madv"].Value.ToString() == maDV);

            if (existedRow != null)
            {
                int quantity = Convert.ToInt32(existedRow.Cells["quantity"].Value);
                // Keep the logic for updating the quantity numeric up/down if the row is selected
                if (dgvItem.SelectedRows.Count > 0 && xoaBtn.Tag != null && (int)xoaBtn.Tag == existedRow.Index)
                {
                    slCTDV.Value = quantity + 1;
                }
                existedRow.Cells["quantity"].Value = quantity + 1;
                existedRow.Cells["totalPrice"].Value = (quantity + 1) * giaDV;
            }
            else
            {
                int id = dgvItem.Rows.Count + 1;
                // Add new row with MaDV
                dgvItem.Rows.Add(maDV, id, tenDV, giaDV, 1, giaDV);
            }

            UpdateTotalPrice();

            if (!pnlInfo.Visible)
            {
                pnlInfo.Visible = true;
                dgvItem.ClearSelection();
            }
        }
        private void UpdateTotalPrice()
        {
            long totalPrice = 0; // Use long to avoid overflow for large totals
            foreach (DataGridViewRow row in dgvItem.Rows)
            {
                if (row.Cells["totalPrice"].Value != null && long.TryParse(row.Cells["totalPrice"].Value.ToString(), out long rowTotal))
                {
                    totalPrice += rowTotal;
                }
            }
            tong.Text = formatPrice(totalPrice);
        }
        private void RegisterClickEvents(Control parent, EventHandler handler)
        {
            parent.Click += handler;
            foreach (Control child in parent.Controls)
            {
                RegisterClickEvents(child, handler);
            }
        }

        private string formatPrice(long price)
        {
            return price.ToString("N0") + " đ";
        }

        private void da_CheckedChanged(object sender, EventArgs e)
        {
            if (da.Checked)
            {
                LoadDV();
            }
        }

        private void du_CheckedChanged(object sender, EventArgs e)
        {
            if (du.Checked)
            {
                LoadDV();
            }
        }

        private void tc_CheckedChanged(object sender, EventArgs e)
        {
            if (tc.Checked)
            {
                LoadDV();
            }
        }

        private void xoaBtn_Click(object sender, EventArgs e)
        {
            string tb = "Bạn có chắc chắn muốn xóa dịch vụ này khỏi hóa đơn không?";
            if (dgvItem.Rows.Count == 1)
            {
                tb = "Đây là dịch vụ cuối cùng. Hành động này sẽ hủy bỏ hóa đơn này.";
            }
            DialogResult result = MessageBox.Show(
                tb,
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result == DialogResult.No)
            {
                slCTDV.Value = Convert.ToInt32(dgvItem.Rows[(int)xoaBtn.Tag].Cells["quantity"].Value);
                return;
            }
            dgvItem.Rows.RemoveAt((int)xoaBtn.Tag);
            if (dgvItem.Rows.Count == 0)
            {
                pnlInfo.Visible = false;
            }
            pnlSl.Visible = false;
            dgvItem.ClearSelection();
            int totalPrice = 0;
            foreach (DataGridViewRow row in dgvItem.Rows)
            {
                totalPrice += Convert.ToInt32(row.Cells["totalPrice"].Value);
            }
            tong.Text = formatPrice(totalPrice);
        }

        private void huyBtn_Click(object sender, EventArgs e)
        {
            pnlSl.Visible = false;
            dgvItem.ClearSelection();
        }

        private void huydonBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn hủy hóa đơn này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result == DialogResult.No)
            {
                return;
            }
            dgvItem.Rows.Clear();
            pnlInfo.Visible = false;
            pnlSl.Visible = false;
        }

        private void payBtn_Click(object sender, EventArgs e)
        {


            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thanh toán hóa đơn này không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result == DialogResult.No)
            {
                return;
            }

            string pttt = tm.Checked ? "Tiền mặt" : "Chuyển khoản";
            long totalPrice; // Use long
            if (!long.TryParse(tong.Text.ToString().Replace(" đ", "").Replace(",", ""), out totalPrice))
            {
                MessageBox.Show("Error parsing total price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int maNv = 0;
            try
            {
                // Assuming DBNhanVien.LayNVDangNhap() returns List<proc_LayTTNVDangNhap_Result>
                var nv = dbNV.LayNVDangNhap().FirstOrDefault();
                if (nv != null)
                {
                    maNv = nv.MaNV; // Access property
                }
                else
                {
                    MessageBox.Show("Could not get logged in employee info.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting employee info: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string maHD = "";
            try
            {
                // Assuming dbHoaDon.TaoHoaDonDichVu exists and takes appropriate types
                // Need to confirm actual signature and return type of TaoHoaDonDichVu in your DBHoaDon DAL
                maHD = dbHoaDon.TaoHoaDonDichVu(pttt, maNv, maKm.Texts, (int)totalPrice); // Cast totalPrice if proc expects int
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tạo hóa đơn: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(maHD))
            {
                MessageBox.Show("Failed to create invoice header.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DataGridViewRow row in dgvItem.Rows)
            {
                if (row.Cells["madv"].Value == null) continue;

                string maDV = row.Cells["madv"].Value.ToString();
                int quantity = Convert.ToInt32(row.Cells["quantity"].Value);
                long price; // Use long
                if (!long.TryParse(row.Cells["price"].Value.ToString(), out price))
                {
                    MessageBox.Show($"Error parsing price for service {maDV}. Invoice cancelled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Assuming dbHoaDon.HuyHoaDon exists
                    dbHoaDon.HuyHoaDon(maHD);
                    return;
                }

                try
                {

                    dbHoaDon.ThemDichVuVaoHoaDon(maHD, maDV, (int)price, quantity); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi thêm dịch vụ {maDV} vào hóa đơn. Hóa đơn bị hủy.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Assuming dbHoaDon.HuyHoaDon exists
                    dbHoaDon.HuyHoaDon(maHD);
                    return;
                }
            }

            MessageBox.Show($"Tạo hóa đơn dịch vụ thành công! Mã hóa đơn: {maHD}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgvItem.Rows.Clear();
            pnlInfo.Visible = false;
            pnlSl.Visible = false;
            UpdateTotalPrice();
            maKm.Texts = "";
            fXNHDDV fXNHDDV = new fXNHDDV(maHD, pttt);
            fXNHDDV.ShowDialog();
        }

        private void slCTDV_ValueChanged(object sender, EventArgs e)
        {
            if (slCTDV.Value == 0)
            {
                xoaBtn_Click(sender, e);
                return;
            }
            dgvItem.Rows[(int)xoaBtn.Tag].Cells["quantity"].Value = slCTDV.Value;
            dgvItem.Rows[(int)xoaBtn.Tag].Cells["totalPrice"].Value = slCTDV.Value * Convert.ToInt64(dgvItem.Rows[(int)xoaBtn.Tag].Cells["price"].Value);
            int totalPrice = 0;
            foreach (DataGridViewRow row in dgvItem.Rows)
            {
                totalPrice += Convert.ToInt32(row.Cells["totalPrice"].Value);
            }
            tong.Text = formatPrice(totalPrice);
        }

        private void dgvItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            pnlSl.Visible = true;
            xoaBtn.Tag = e.RowIndex;
            slCTDV.Value = Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells["quantity"].Value);
        }


    }
}
