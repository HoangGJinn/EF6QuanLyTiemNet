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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using DAL;

namespace WF_QuanNet
{
    public partial class fNT: Form
    {
        private string username;
        private DBNhanVien db;
        public fNT(string usn)
        {
            InitializeComponent();
            username = usn;
            label1.Text = label1.Text + " Tài Khoản: " + usn;
            db = DBNhanVien.Instance;
        }

        private void fNT_Load(object sender, EventArgs e)
        {

        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void huyBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void napBtn_Click(object sender, EventArgs e)
        {
            int Tiennap;
            if (int.TryParse(tenLoaiTxtBox.Texts, out Tiennap))
            {
                if (Tiennap > 0)
                {
                    string MaKM;
                    if (customComboBox1.SelectedValue != null)
                    {
                        MaKM = customComboBox1.SelectedValue.ToString();
                    }
                    else
                    {
                        MaKM = null;

                    }
                    DialogResult result = MessageBox.Show(
                        "Bạn có chắc chắn nạp số tiền " + formatPrice(Tiennap) + " cho tài khoản này không?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );
                    if (result == DialogResult.No)
                    {
                        return;
                    }

                    var nvDangNhap = db.LayNVDangNhap();
                    int maNv = int.Parse(nvDangNhap[0].MaNV.ToString());
                    string pttt = tm.Checked ? "Tiền Mặt" : "Chuyển Khoản";
                    DBHoaDon.Instance.ThemHoaDonNapTien(Tiennap, pttt, Tiennap, username, maNv, MaKM);
                    MessageBox.Show("Nạp tiền thành công");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Số tiền nạp không hợp lệ");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số tiền nạp");
            }
        }

        private string formatPrice(long price)
        {
            return price.ToString("N0") + " VNĐ";
        }

        private void tenLoaiTxtBox__TextChanged(object sender, EventArgs e)
        {
            string text = tenLoaiTxtBox.Texts;
            int Tiennap;
            if (int.TryParse(text, out Tiennap))
            {
                var data = DBKhuyenMai.Instance.LayDsKhuyenMaiTheoTienNap(Tiennap);
                if (data.Count > 0)
                {
                    customComboBox1.Texts = "Có thể chọn khuyến mãi";
                    customComboBox1.DataSource = data;

                    customComboBox1.DisplayMember = "TenChTrinh";
                    customComboBox1.ValueMember = "MaKM";
                }
                else
                {
                    customComboBox1.DataSource = null;
                    customComboBox1.Texts = "Không có khuyến mãi khả dụng";
                }
            }
            else
            {
                customComboBox1.DataSource = null;
                customComboBox1.Texts = "Vui Lòng Nhập Số Tiền Nạp";
            }

        }
    }
}
