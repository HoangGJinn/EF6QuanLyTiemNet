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
using DTO;
using DAL;
using System.IO;
using System.Drawing.Imaging;

namespace WF_QuanNet
{
    public partial class fDichVu : Form
    {
        private DBDichVu dbDichVu;
        public fDichVu()
        {
            InitializeComponent();
            dbDichVu = DBDichVu.Instance;
            dgvDA.EnableHeadersVisualStyles = false;
            ttdaCbBox.DataSource = new List<string> { "Đang phục vụ", "Tạm ngưng phục vụ" };

            LoadDA();
        }


        private void LoadDA()
        {
            List<View_DichVuDoAn> dt = dbDichVu.View_DichVuDoAns();
            dgvDA.Rows.Clear();
            foreach (var item in dt)
            {
                int index = dgvDA.Rows.Add();
                dgvDA.Rows[index].Cells["tendoan"].Value = item.TenDoAn;
                dgvDA.Rows[index].Cells["dongia"].Value = formatPrice(item.DonGia);
                dgvDA.Rows[index].Cells["trangthai"].Value = item.TrangThai;
                dgvDA.Rows[index].Cells["BS"].Value = item.BestSeller;
            }
        }

        private string formatPrice(long price)
        {
            return price.ToString("N0") + " VNĐ";
        }


        private void dgvDA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDA.Rows[e.RowIndex];
                tenDoAnTxtBox.Texts = row.Cells[1].Value.ToString();
                dgdaTxtBox.Texts = row.Cells[2].Value.ToString().Replace(" VNĐ", "").Replace(",", "");
                dabsCheckBox.Checked = Convert.ToBoolean(row.Cells[4].Value);
                ttdaCbBox.Texts = row.Cells[3].Value.ToString();
                string baseImageName = tenDoAnTxtBox.Texts;
                string[] imageExtensions = { ".png", ".jpg" };
                string imagePath = null;
                Image originalImage = null;
                foreach (string extension in imageExtensions)
                {
                    string tempPath = Path.Combine(Application.StartupPath, "Images", baseImageName + extension);
                    if (File.Exists(tempPath))
                    {
                        imagePath = tempPath;
                        break;
                    }
                }
                if (!string.IsNullOrEmpty(imagePath))
                {
                    try
                    {
                        originalImage = Image.FromFile(imagePath);
                        Bitmap displayedImage = new Bitmap(originalImage);
                        picDA.Image = displayedImage;
                    }
                    finally
                    {
                        if (originalImage != null)
                        {
                            originalImage.Dispose();
                        }
                    }
                }
                else
                {
                    picDA.Image = null;
                }
                themDABtn.Visible = false;
                label11.Visible = true;
                ttdaCbBox.Visible = true;
                huyDABtn.Visible = true;
                suaDABtn.Visible = true;
                xoaDABtn.Visible = true;
            }
        }


        public void SaveImageToDebugFolder(Image imageToSave, string imageName)
        {
            string imagesFolderPath = Path.Combine(Application.StartupPath, "Images");

            if (!Directory.Exists(imagesFolderPath))
            {
                Directory.CreateDirectory(imagesFolderPath);
            }

            string imagePath = Path.Combine(imagesFolderPath, imageName);

            try
            {
                imageToSave.Save(imagePath, ImageFormat.Png);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void hinhDABtn_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.Title = "Chọn hình ảnh cho dịch vụ đồ ăn";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                Image image = Image.FromFile(filePath);
                picDA.Image = image;
            }

        }
    }
}
