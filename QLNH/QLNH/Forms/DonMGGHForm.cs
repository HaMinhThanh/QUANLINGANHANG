using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataModel;
using BusinessLogicTier;

namespace QLNH
{
    public partial class DonMGGHForm : Form
    {
        private HopDongVayBUS busObj;
        private YeuCauChinhSuaBUS busObjYCChinhSua;
        private HopDongChoVay selectedHD;
        public DonMGGHForm()
        {
            busObj = new HopDongVayBUS();
            busObjYCChinhSua = new YeuCauChinhSuaBUS();
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            TraCuuKhoanVay newForm = new TraCuuKhoanVay();
            newForm.ShowDialog();
            if (newForm.DialogResult == DialogResult.OK)
            {
                selectedHD = newForm.result;
                textBox3.Text = selectedHD.YeuCauVay.KHYeuCau.MaKH;
                textBox4.Text = selectedHD.YeuCauVay.KHYeuCau.HoTen;
                textBox10.Text = selectedHD.NgayThietLap.ToString();
                numericUpDown3.Value = (Decimal) selectedHD.GiaTriConLai;
                numericUpDown4.Value = (Decimal) selectedHD.YeuCauVay.SoTienVay;
                numericUpDown5.Value = (Decimal) selectedHD.YeuCauVay.KyHan;
                numericUpDown6.Value = (Decimal) selectedHD.YeuCauVay.LaiSuat;
                textBox8.Text = selectedHD.TrangThai.TenTrangThai;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            YeuCauChinhSuaHopDong entry = new YeuCauChinhSuaHopDong();
            if (numericUpDown1.Value != 0)
            {
                entry = new YeuCauChinhSuaLaiSuat();
                entry.HopDong = selectedHD;
                entry.NgayTiepNhan = DateTime.Now;
                entry.NVTiepNhan = (NhanVienTinDung) SessionState.NVDangNhap;
                entry.LyDo = richTextBox1.Text;
                ((YeuCauChinhSuaLaiSuat)entry).GiaTriMoi = (Double)numericUpDown1.Value;
            }
            else if (numericUpDown2.Value != 0)
            {
                entry = new YeuCauChinhSuaKiHan();
                entry.HopDong = selectedHD;
                entry.NgayTiepNhan = DateTime.Now;
                entry.NVTiepNhan = (NhanVienTinDung)SessionState.NVDangNhap;
                entry.LyDo = richTextBox1.Text;
                ((YeuCauChinhSuaLaiSuat)entry).GiaTriMoi = (Int32)numericUpDown2.Value;
            }

            try
            {
                busObjYCChinhSua.AddYeuCauChinhSuaHopDong(entry);
                MessageBox.Show("Gửi yêu cầu chỉnh sửa thành công", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
