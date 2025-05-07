using DTO; 
using DAL; 
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
using WF_QuanNet.CustomComponent;

namespace WF_QuanNet
{
    public partial class fDanhSachMay : Form
    {
        private DBLM dblm;
        private DBMT dbmt;
        private DBDichVu dbdv; 

        private Hashtable ucMays = new Hashtable();

        public fDanhSachMay()
        {
            InitializeComponent();
            dblm = DBLM.Instance;
            dbmt = DBMT.Instance;

            dbdv = DBDichVu.Instance;


            Load_cbboxLoaiMay();
            Load_MT();
        }

        private void Load_cbboxLoaiMay()
        {
            List<DanhSachLoaiMay> loaiMayList = null; 
            try
            {
                loaiMayList = dblm.LayDsLoaiMay(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading machine types: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loaiMayList = new List<DanhSachLoaiMay>();
            }

            // Use properties from DanhSachLoaiMay for combobox items
            var cbItems = loaiMayList.Select(lm => new { lm.MaLoaiMay, lm.TenLoaiMay }).ToList<dynamic>();
            cbItems.Insert(0, new { MaLoaiMay = -1, TenLoaiMay = "Tất cả" });

            cbboxloaimay.DisplayMember = "TenLoaiMay";
            cbboxloaimay.ValueMember = "MaLoaiMay";
            cbboxloaimay.DataSource = cbItems;
            cbboxloaimay.SelectedIndex = 0;

            // Assuming cbboxloaimay is a custom control with an OnSelectedIndexChanged event
            cbboxloaimay.OnSelectedIndexChanged += cbboxLoaiMay_OnSelectedIndexChanged;
        }

        private void Load_MT()
        {
            flpMay.Controls.Clear(); // Clear existing controls

            IEnumerable<object> mayTinhList = null; // Use object to hold different list types from DBMT
            int selectedLoaiMayId = (int)cbboxloaimay.SelectedValue;
            string searchText = searchMaMay.Texts.Trim();

            try
            {
                if (!string.IsNullOrEmpty(searchText))
                {
                    // Returns List<func_timKiemMayTinh_Result>
                    mayTinhList = dbmt.TimKiemMayTinh(searchText);
                }
                else if (selectedLoaiMayId == -1)
                {
                    // Returns List<DanhSachMayTinh>
                    mayTinhList = dbmt.LayDsMayTinh();
                }
                else
                {
                    // Returns List<proc_layMayTheoMaLoai_Result>
                    mayTinhList = dbmt.LayDsMayTheoMaLoai(selectedLoaiMayId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading machines: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mayTinhList = new List<object>();
            }

            if (mayTinhList != null)
            {
                foreach (var item in mayTinhList) // Iterate through list of different types
                {
                    string soMay = "";
                    string trangThai = "";
                    string tenLoaiMay = "";
                    int maLoaiMay = 0; // Keep MaLoaiMay

                    // Check the actual type and extract properties based on uploaded DAL files
                    if (item is func_timKiemMayTinh_Result timKiemResult)
                    {
                        soMay = timKiemResult.SoMay;
                        trangThai = timKiemResult.TrangThai;
                        tenLoaiMay = timKiemResult.TenLoaiMay;
                        maLoaiMay = timKiemResult.MaLoaiMay;
                    }
                    else if (item is DanhSachMayTinh danhSachResult)
                    {
                        soMay = danhSachResult.SoMay;
                        trangThai = danhSachResult.TrangThai;
                        tenLoaiMay = danhSachResult.TenLoaiMay;
                        maLoaiMay = danhSachResult.MaLoaiMay;
                    }
                    else if (item is proc_layMayTheoMaLoai_Result layTheoLoaiResult)
                    {
                        soMay = layTheoLoaiResult.SoMay;
                        trangThai = layTheoLoaiResult.TrangThai;
                        tenLoaiMay = layTheoLoaiResult.TenLoaiMay;
                        maLoaiMay = layTheoLoaiResult.MaLoaiMay;
                    }
                    else
                    {
                        // Should not happen if DAL methods return expected types, but good for safety
                        continue;
                    }


                    if (ucMays.ContainsKey(soMay)) // Use SoMay as key
                    {
                        // Update existing UcMayTinh if needed (e.g., status changed)
                        if (ucMays[soMay] is UcMayTinh existingUc)
                        {
                            existingUc.SoMayTxtLB.Text = soMay;
                            existingUc.TrangThaiTxtLB.Text = trangThai;
                            existingUc.lmLbl.Text = tenLoaiMay;
                            existingUc.TrangThaiTxtLB.ForeColor = trangThai == "Đang hoạt động" ? Color.Red : Color.Green;
                        }
                        flpMay.Controls.Add(ucMays[soMay] as UcMayTinh);
                        continue;
                    }

                    UcMayTinh ucMay = new UcMayTinh();
                    ucMay.SoMayTxtLB.Text = soMay;
                    ucMay.TrangThaiTxtLB.Text = trangThai;
                    ucMay.lmLbl.Text = tenLoaiMay;
                    ucMay.TrangThaiTxtLB.ForeColor = trangThai == "Đang hoạt động" ? Color.Red : Color.Green;
                    ucMay.Name = soMay; // Use SoMay as control name

                    RegisterClickEvents(ucMay, (s, e) =>
                    {
                        showInfo(ucMay);
                    });

                    ucMays.Add(ucMay.Name, ucMay); // Add to cache using Name (SoMay)
                    flpMay.Controls.Add(ucMay);
                }
            }
        }

        private void showInfo(UcMayTinh item)
        {
            panelInfo.Visible = true;
            dgvLK.Rows.Clear();
            string soMay = item.SoMayTxtLB.Text;

            func_timKiemMayTinh_Result mayTinh = null; // Assuming TimKiemMayTinh is the source for detail info
            List<fn_timLkTheoLoaiMay_Result> linhKienList = null; // Use specific DTO type
            string tkDangSD = "X";
            int giaTienInt = 0; // Get int price first
            long giaTien = 0; // Convert to long for formatting


            try
            {
                // Get machine details - TimKiemMayTinh returns List<func_timKiemMayTinh_Result>, get the first
                mayTinh = dbmt.TimKiemMayTinh(soMay).FirstOrDefault();

                if (mayTinh != null)
                {
                    if (mayTinh.TrangThai == "Đang hoạt động")
                    {
                        thueBtn.Text = "Ngừng SD";
                        tkDangSD = dbmt.LayTKDangSDMay(soMay); // Returns string
                        usnTxtBox.Texts = tkDangSD;
                        usnTxtBox.Enabled = false;
                    }
                    else
                    {
                        thueBtn.Text = "Bắt Đầu SD";
                        usnTxtBox.Texts = "";
                        usnTxtBox.Enabled = true;
                    }

                    smLbl.Text = soMay;
                    string lm = mayTinh.TenLoaiMay;
                    lmLbl.Text = lm;

                    // Get price per hour - returns int, convert to long
                    giaTienInt = dbmt.GetGiaTienTheoGio(soMay);
                    giaTien = giaTienInt;
                    giaLbl.Text = formatPrice(giaTien);

                    // Get components for the machine's type - returns List<fn_timLkTheoLoaiMay_Result>
                    linhKienList = dblm.TimLinhKienTheoLoaiMay(mayTinh.MaLoaiMay); // Use MaLoaiMay from DTO
                }
                else
                {
                    MessageBox.Show($"Machine details for {soMay} not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    panelInfo.Visible = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading machine info: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                panelInfo.Visible = false;
                return;
            }

            // Populate dgvLK with components using properties from fn_timLkTheoLoaiMay_Result
            if (linhKienList != null)
            {
                foreach (var linhKien in linhKienList)
                {
                    // Use actual property names from fn_timLkTheoLoaiMay_Result
                    dgvLK.Rows.Add(linhKien.TenLinhKien, linhKien.ChiTietLK, linhKien.SoLuong);
                }
            }
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
            return price.ToString("N0") + " VNĐ";
        }

        private void cbboxLoaiMay_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Load_MT();
        }

        private void thueBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string usn = usnTxtBox.Texts.Trim();
                string soMay = smLbl.Text;

                // --- NOTE: KetThucThue and BatDauThue are NOT found in the provided DBDV.cs, DBMT.cs, or DBLM.cs ---
                // Assuming these methods exist in a DAL class instance assigned to dbdv
                if (thueBtn.Text == "Ngừng SD")
                {
                    dbdv.KetThucThue(soMay, usn);
                }
                else // Bắt Đầu SD
                {
                    dbdv.BatDauThue(soMay, usn);
                }
                // -------------------------------------------------------------------------------------------

                panelInfo.Visible = false;
                MessageBox.Show(thueBtn.Text + " thành công");

                // Update status display on the UcMayTinh control in the flow panel
                Control[] foundControls = flpMay.Controls.Find(soMay, true);
                if (foundControls.Length > 0 && foundControls[0] is UcMayTinh ucToUpdate)
                {
                    string newStatus = thueBtn.Text == "Ngừng SD" ? "Không hoạt động" : "Đang hoạt động";
                    ucToUpdate.TrangThaiTxtLB.Text = newStatus;
                    ucToUpdate.TrangThaiTxtLB.ForeColor = newStatus == "Đang hoạt động" ? Color.Red : Color.Green;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in {thueBtn.Text}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Reload the machine list to reflect updated status from database
                Load_MT();
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            Load_MT();
        }

        private void huyBtn_Click(object sender, EventArgs e)
        {
            panelInfo.Visible = false;
        }
    }
}