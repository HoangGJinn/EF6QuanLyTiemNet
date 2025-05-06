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
            ttduCbBox.DataSource = new List<string> { "Đang phục vụ", "Tạm ngưng phục vụ" };
            LoadDA();
            LoadDU();
            LoadTC();
        }

        private void LoadDA()
        {
            List<View_DichVuDoAn> dt = dbDichVu.View_DichVuDoAns();

            dgvDA.Rows.Clear();

            if (searchdaBox.Texts == "")
            {
                dt = dbDichVu.View_DichVuDoAns();
            }
            else
            {
                dt = dbDichVu.TimKiemDVDA(searchdaBox.Texts);
            }
            foreach (var item in dt)
            {
                int index = dgvDA.Rows.Add();
                dgvDA.Rows[index].Cells["MaDVDA"].Value = item.MaDV;
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

        private void suaDABtn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn sửa thông tin dịch vụ đồ ăn này không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (result == DialogResult.No)
                {
                    return;
                }
                string maDV = dgvDA.SelectedRows[0].Cells[0].Value.ToString();
                string tenDoAn = tenDoAnTxtBox.Texts;
                int donGia = int.Parse(dgdaTxtBox.Texts);
                bool bestSeller = dabsCheckBox.Checked;
                string trangThai = ttdaCbBox.Texts;
                dbDichVu.SuaDVDoAn(maDV, tenDoAn, donGia, bestSeller, trangThai);
                string imgName = tenDoAnTxtBox.Texts + ".png";
                SaveImageToDebugFolder(picDA.Image, imgName);
                MessageBox.Show("Sửa dịch vụ đồ ăn thành công");
                LoadDA();
                foreach (DataGridViewRow dr in dgvDA.Rows)
                {
                    if (dr.Cells[0].Value.ToString() == maDV)
                    {
                        dr.Selected = true;
                        dgvDA.CurrentCell = dr.Cells[1];
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void searchdaBtn_Click(object sender, EventArgs e)
        {
            LoadDA();
        }

        private void themDABtn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn thêm dịch vụ đồ ăn này không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (result == DialogResult.No)
                {
                    return;
                }
                string tenDoAn = tenDoAnTxtBox.Texts;
                int donGia = int.Parse(dgdaTxtBox.Texts);
                bool bestSeller = dabsCheckBox.Checked;
                dbDichVu.ThemDVDoAn(tenDoAn, donGia, bestSeller);
                string imgName = tenDoAnTxtBox.Texts + ".png";
                SaveImageToDebugFolder(picDA.Image, imgName);
                MessageBox.Show("Thêm dịch vụ đồ ăn thành công");
                huyDABtn_Click(sender, e);
                LoadDA();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void huyDABtn_Click(object sender, EventArgs e)
        {
            themDABtn.Visible = true;
            label11.Visible = false;
            ttdaCbBox.Visible = false;
            huyDABtn.Visible = false;
            suaDABtn.Visible = false;
            xoaDABtn.Visible = false;
            dabsCheckBox.Checked = false;
            tenDoAnTxtBox.Texts = "";
            dgdaTxtBox.Texts = "";
            picDA.Image = null;
            dgvDA.ClearSelection();
        }

        private void xoaDABtn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa dịch vụ đồ ăn này không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (result == DialogResult.No)
                {
                    return;
                }
                string maDV = dgvDA.SelectedRows[0].Cells[0].Value.ToString();
                dbDichVu.XoaDichVu(maDV);
                string imgName = tenDoAnTxtBox.Texts + ".png";
                string imgPath = Path.Combine(Application.StartupPath, "Images", imgName);
                if (File.Exists(imgPath))
                {
                    File.Delete(imgPath);
                }
                MessageBox.Show("Xóa dịch vụ đồ ăn thành công");
                LoadDA();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadDU()
        {
            List<View_DichVuDoUong> dt = dbDichVu.LayDSDVDU();

            dgvDU.Rows.Clear();

            if (searchduBox.Texts == "")
            {
                dt = dbDichVu.LayDSDVDU();
            }
            else
            {
                dt = dbDichVu.TimKiemDVDU(searchduBox.Texts);
            }
            foreach (var item in dt)
            {
                int index = dgvDU.Rows.Add();
                dgvDU.Rows[index].Cells["MaDVDU"].Value = item.MaDV;
                dgvDU.Rows[index].Cells["tendouong"].Value = item.TenDoUong;
                dgvDU.Rows[index].Cells["dongiadouong"].Value = formatPrice(item.DonGia);
                dgvDU.Rows[index].Cells["trangthaidouong"].Value = item.TrangThai;
                dgvDU.Rows[index].Cells["bsdouong"].Value = item.BestSeller;
            }
        }

        private void dgvDU_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDU.Rows[e.RowIndex];
                tenDoUongTxtBox.Texts = row.Cells[1].Value.ToString();
                dgduTxtBox.Texts = row.Cells[2].Value.ToString().Replace(" VNĐ", "").Replace(",", "");
                dubsCheckBox.Checked = Convert.ToBoolean(row.Cells[4].Value);
                ttduCbBox.Texts = row.Cells[3].Value.ToString();
                string baseImageName = tenDoUongTxtBox.Texts;
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
                        picDU.Image = displayedImage;
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
                    picDU.Image = null;
                }
                themDUBtn.Visible = false;
                label10.Visible = true;
                ttduCbBox.Visible = true;
                huyDUBtn.Visible = true;
                suaDUBtn.Visible = true;
                xoaDUBtn.Visible = true;
            }
        }

        private void themDUBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn thêm dịch vụ đồ uống này không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (result == DialogResult.No)
                {
                    return;
                }
                string tenDoUong = tenDoUongTxtBox.Texts;
                int donGia = int.Parse(dgduTxtBox.Texts);
                bool bestSeller = dubsCheckBox.Checked;
                dbDichVu.ThemDVDouong(tenDoUong, donGia, bestSeller);
                string imgName = tenDoUongTxtBox.Texts + ".png";
                SaveImageToDebugFolder(picDU.Image, imgName);
                MessageBox.Show("Thêm dịch vụ đồ uống thành công");
                huyDUBtn_Click(sender, e);
                LoadDU();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void huyDUBtn_Click(object sender, EventArgs e)
        {
            themDUBtn.Visible = true;
            label10.Visible = false;
            ttduCbBox.Visible = false;
            huyDUBtn.Visible = false;
            suaDUBtn.Visible = false;
            xoaDUBtn.Visible = false;
            dubsCheckBox.Checked = false;
            tenDoUongTxtBox.Texts = "";
            dgduTxtBox.Texts = "";
            picDU.Image = null;
            dgvDU.ClearSelection();
        }

        private void suaDUBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn sửa thông tin dịch vụ đồ uống này không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (result == DialogResult.No)
                {
                    return;
                }
                string maDV = dgvDU.SelectedRows[0].Cells[0].Value.ToString();
                string tenDoUong = tenDoUongTxtBox.Texts;
                int donGia = int.Parse(dgduTxtBox.Texts);
                bool bestSeller = dubsCheckBox.Checked;
                string trangThai = ttduCbBox.Texts;
                dbDichVu.SuaDVDouong(maDV, tenDoUong, donGia, bestSeller, trangThai);
                string imgName = tenDoUongTxtBox.Texts + ".png";
                SaveImageToDebugFolder(picDU.Image, imgName);
                MessageBox.Show("Sửa dịch vụ đồ uống thành công");
                LoadDU();
                foreach (DataGridViewRow dr in dgvDU.Rows)
                {
                    if (dr.Cells[0].Value.ToString() == maDV)
                    {
                        dr.Selected = true;
                        dgvDU.CurrentCell = dr.Cells[1];
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void xoaDUBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa dịch vụ đồ uống này không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (result == DialogResult.No)
                {
                    return;
                }
                string maDV = dgvDU.SelectedRows[0].Cells[0].Value.ToString();
                dbDichVu.XoaDichVu(maDV);
                string imgName = tenDoUongTxtBox.Texts + ".png";
                string imgPath = Path.Combine(Application.StartupPath, "Images", imgName);
                if (File.Exists(imgPath))
                {
                    File.Delete(imgPath);
                }
                MessageBox.Show("Xóa dịch vụ đồ uống thành công");
                LoadDU();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void hinhDUBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.Title = "Chọn hình ảnh cho dịch vụ đồ uống";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                Image image = Image.FromFile(filePath);
                picDU.Image = image;
            }
        }

        private void searchduBtn_Click(object sender, EventArgs e)
        {
            LoadDU();
        }

        private void LoadTC()
        {
            List<View_DichVuTheCao> dt = dbDichVu.LayDSDVTC();

            dgvTC.Rows.Clear();

            if (searchtcBox.Texts == "")
            {
                dt = dbDichVu.LayDSDVTC();
            }
            else
            {
                dt = dbDichVu.TimKiemDVTC(searchtcBox.Texts);
            }
            foreach (var item in dt)
            {
                int index = dgvTC.Rows.Add();
                dgvTC.Rows[index].Cells["MaDVTC"].Value = item.MaDV;
                dgvTC.Rows[index].Cells["loaithe"].Value = item.LoaiThe;
                dgvTC.Rows[index].Cells["menhgia"].Value = formatPrice(item.MenhGia);
            }
        }

        private void dgvTC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTC.Rows[e.RowIndex];
                loaiTheTxtBox.Texts = row.Cells[1].Value.ToString();
                menhGiaTxtBox.Texts = row.Cells[2].Value.ToString().Replace(" VNĐ", "").Replace(",", "");
                string baseImageName = loaiTheTxtBox.Texts + " " + (Convert.ToInt32(menhGiaTxtBox.Texts) / 1000).ToString() + "K";
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
                        picTC.Image = displayedImage;
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
                    picTC.Image = null;
                }
                themTCBtn.Visible = false;
                huyTCBtn.Visible = true;
                suaTCBtn.Visible = true;
                xoaTCBtn.Visible = true;
            }
        }

        private void searchtcBtn_Click(object sender, EventArgs e)
        {
            LoadTC();
        }

        private void huyTCBtn_Click(object sender, EventArgs e)
        {
            themTCBtn.Visible = true;
            huyTCBtn.Visible = false;
            suaTCBtn.Visible = false;
            xoaTCBtn.Visible = false;
            loaiTheTxtBox.Texts = "";
            menhGiaTxtBox.Texts = "";
            picTC.Image = null;
            dgvTC.ClearSelection();
        }

        private void hinhTCBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.Title = "Chọn hình ảnh cho dịch vụ thẻ cào";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                Image image = Image.FromFile(filePath);
                picTC.Image = image;
            }
        }

        private void xoaTCBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa dịch vụ thẻ cào này không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (result == DialogResult.No)
                {
                    return;
                }
                string maDV = dgvTC.SelectedRows[0].Cells[0].Value.ToString();
                dbDichVu.XoaDichVu(maDV);
                string imgName = loaiTheTxtBox.Texts + " " + (Convert.ToInt32(menhGiaTxtBox.Texts) / 1000).ToString() + "K.png";
                string imgPath = Path.Combine(Application.StartupPath, "Images", imgName);
                if (File.Exists(imgPath))
                {
                    File.Delete(imgPath);
                }
                MessageBox.Show("Xóa dịch vụ thẻ cào thành công");
                LoadTC();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void suaTCBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn sửa thông tin dịch vụ thẻ cào này không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (result == DialogResult.No)
                {
                    return;
                }
                string maDV = dgvTC.SelectedRows[0].Cells[0].Value.ToString();
                string loaiThe = loaiTheTxtBox.Texts;
                int menhGia = int.Parse(menhGiaTxtBox.Texts);
                dbDichVu.SuaDVTheCao(maDV, loaiThe, menhGia);
                string imgName = loaiTheTxtBox.Texts + " " + (Convert.ToInt32(menhGiaTxtBox.Texts) / 1000).ToString() + "K.png";
                SaveImageToDebugFolder(picTC.Image, imgName);
                MessageBox.Show("Sửa dịch vụ thẻ cào thành công");
                LoadTC();
                foreach (DataGridViewRow dr in dgvTC.Rows)
                {
                    if (dr.Cells[0].Value.ToString() == maDV)
                    {
                        dr.Selected = true;
                        dgvTC.CurrentCell = dr.Cells[1];
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void searchtcBtn_Click_1(object sender, EventArgs e)
        {
            LoadTC();
        }
    }
}
