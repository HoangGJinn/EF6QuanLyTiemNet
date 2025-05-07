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

namespace WF_QuanNet
{
    public partial class fXNHDDV : Form
    {
        private string maHD;
        private string pttt;
        private DBHoaDon dbHD;
        private DBNhanVien dbNV;
        public fXNHDDV()
        {
            InitializeComponent();
            this.maHD = maHD;
            this.pttt = pttt;
            dbHD = DBHoaDon.Instance;
            dbNV = DBNhanVien.Instance;
        }

        public fXNHDDV(string maHD, string pttt)
        {
            InitializeComponent();
            this.maHD = maHD;
            this.pttt = pttt;

            dbHD = DBHoaDon.Instance;
            dbNV = DBNhanVien.Instance;

            // Ensure DataGridView columns match if not defined in designer
            if (dgvItem.Columns.Count == 0)
            {
                dgvItem.Columns.Add("STT", "STT");
                dgvItem.Columns.Add("TenDV", "Tên Dịch Vụ");
                dgvItem.Columns.Add("DonGia", "Đơn Giá");
                dgvItem.Columns.Add("SoLuong", "Số Lượng");
                dgvItem.Columns.Add("ThanhTien", "Thành Tiền");
            }

            LoadCTHD();
        }

        private void LoadCTHD()
        {
            List<fn_XemChiTietHoaDonDichVu_Result> cthdList = null;
            HOADON hd = null;
            proc_LayTTNVDangNhap_Result nv = null;

            try
            {
                cthdList = dbHD.LayDsCTHD(maHD);
                hd = dbHD.TimHD(maHD: maHD).FirstOrDefault();
                nv = dbNV.LayNVDangNhap().FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading invoice details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if (pttt == "Tiền mặt")
            {
                Height -= 205;
                label6.Visible = false;
                pictureBox1.Visible = false;
                var hoanTatBtnLocation = hoanTatBtn.Location;
                hoanTatBtnLocation.Y -= 210;
                hoanTatBtn.Location = hoanTatBtnLocation;

                var huyBtnLocation = huyBtn.Location;
                huyBtnLocation.Y -= 210;
                huyBtn.Location = huyBtnLocation;
            }

            if (hd != null)
            {
                idLabel.Text = hd.MaHD;
                // Sửa lỗi: hd.NgayLap có vẻ là DateTime không nullable
                dateLabel.Text = hd.NgayLap.ToString("dd/MM/yyyy h:mm:ss tt"); // Access directly

                kmLabel.Text = string.IsNullOrEmpty(hd.MaKM) ? "Không có" : hd.MaKM;
                amountLabel.Text = formatPrice(hd.TongThanhToan ?? 0); // Assuming TongThanhToan is nullable numeric
                discountLabel.Text = formatPrice(hd.TienDuocGiam ?? 0); // Assuming TienDuocGiam is nullable numeric

                long total = hd.TongThanhToan ?? 0;
                long discount = hd.TienDuocGiam ?? 0;
                finalPayLabel.Text = formatPrice(total - discount);
                ptttLabel.Text = hd.PhuongThucTT;
            }
            else
            {
                MessageBox.Show($"Invoice with ID {maHD} not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if (nv != null)
            {
                sid.Text = nv.MaNV.ToString();
                sname.Text = nv.HoTen;
            }
            else
            {
                sid.Text = "N/A";
                sname.Text = "N/A";
            }

            dgvItem.Rows.Clear();
            if (cthdList != null)
            {
                int i = 0;
                foreach (var row in cthdList)
                {
                    i++;
                    string tenDV = row.TenDV;
                    int soLuong = row.SoLuong;
                    int donGia = row.DonGia;
                    // Sửa lỗi: Chuyển đổi ThanhTien sang int
                    int thanhTien = Convert.ToInt32(row.ThanhTien);

                    dgvItem.Rows.Add(i, tenDV, donGia, soLuong, thanhTien);
                }
            }
        }

        private string formatPrice(long price)
        {
            return price.ToString("N0") + " VNĐ";
        }

        private void hoanTatBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Xác nhận hoàn tất hóa đơn?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result == DialogResult.No)
            {
                return;
            }
            try
            {
                // Phương thức này cần được thêm vào lớp DAL.DBHoaDon.cs
                dbHD.HoanTatHoaDon(maHD);
                MessageBox.Show("Thanh toán hóa đơn hoàn tất");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi hoàn tất hóa đơn: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dbHD.HuyHoaDon(maHD); // Uncomment if needed
            }
        }

        private void huyBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn quay lại?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result == DialogResult.No)
            {
                return;
            }
            try
            {
                // Phương thức này cần được thêm vào lớp DAL.DBHoaDon.cs
                dbHD.HuyHoaDon(maHD);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi hủy hóa đơn: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
