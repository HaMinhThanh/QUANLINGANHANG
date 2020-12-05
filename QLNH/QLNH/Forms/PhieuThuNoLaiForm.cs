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
    public partial class PhieuThuNoLaiForm : Form
    {
        private HoatDongThuTienBUS busObj;
        private GiaoDichBUS busObjGiaoDich;
        private KhachHangBUS busObjKhachHang;
        private HopDongChoVay selectedHD = null;

        public PhieuThuNoLaiForm()
        {
            busObj = new HoatDongThuTienBUS();
            busObjGiaoDich = new GiaoDichBUS();
            busObjKhachHang = new KhachHangBUS();
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TraCuuKhoanVay newForm = new TraCuuKhoanVay();
            newForm.ShowDialog();
            if (newForm.DialogResult == DialogResult.OK)
            {
                selectedHD = newForm.result;
                textBox1.Text = selectedHD.MaHopDong;
                textBox2.Text = selectedHD.YeuCauVay.KHYeuCau.MaKH;
                textBox4.Text = selectedHD.YeuCauVay.KHYeuCau.MaKH;
                textBox11.Text = selectedHD.YeuCauVay.KHYeuCau.HoTen;
                textBox7.Text = selectedHD.NgayThietLap.ToString();
                textBox6.Text = selectedHD.YeuCauVay.SoTienVay.ToString();
                textBox5.Text = selectedHD.YeuCauVay.KyHan.ToString();
                textBox8.Text = selectedHD.YeuCauVay.LaiSuat.ToString();
                textBox9.Text = selectedHD.TrangThai.TenTrangThai;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedHD == null)
            {
                MessageBox.Show("Chưa chọn hợp đồng vay để thu tiền", "Thông báo");
            }
            try
            {
                BienBanThuTien entry = new BienBanThuTien();
                entry.GiaoDichThucHien = new GiaoDichThu();
                entry.HopDong = selectedHD;
                entry.NVThucHien = (NhanVienKeToan)SessionState.NVDangNhap;
                entry.GiaoDichThucHien.DonViGiaoDich = busObjKhachHang.GetKhachHangByMaKH(textBox2.Text);
                entry.GiaoDichThucHien.GiaTri = (Double)numericUpDown1.Value;
                entry.GiaoDichThucHien.MoTa = "Thu tiền cho khoản vay " + selectedHD.MaHopDong;
                entry.GiaoDichThucHien.ThoiDiemThucHien = DateTime.Now;

                busObjGiaoDich.AddGiaoDich(entry.GiaoDichThucHien);
                busObj.AddHoatDongThuTien(entry);
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

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
