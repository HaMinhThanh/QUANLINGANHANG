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
        private HopDongVayBUS busObjHopDong;
        private HopDongChoVay selectedHD = null;
        private DataModel.KhachHang selectedKH = null;

        public PhieuThuNoLaiForm()
        {
            busObj = new HoatDongThuTienBUS();
            busObjGiaoDich = new GiaoDichBUS();
            busObjKhachHang = new KhachHangBUS();
            busObjHopDong = new HopDongVayBUS();
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
                selectedKH = selectedHD.YeuCauVay.KHYeuCau;
                textBox2.Text = selectedKH.HoTen;
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
                entry.GiaoDichThucHien.DonViGiaoDich = selectedKH;
                entry.GiaoDichThucHien.GiaTri = (Double)numericUpDown1.Value;
                entry.GiaoDichThucHien.MoTa = "Thu tiền cho khoản vay " + selectedHD.MaHopDong;
                entry.GiaoDichThucHien.ThoiDiemThucHien = DateTime.Now;

                busObjGiaoDich.AddGiaoDich(entry.GiaoDichThucHien);
                busObj.AddHoatDongThuTien(entry);

                entry.HopDong.GiaTriConLai -= entry.GiaoDichThucHien.GiaTri;

                busObjHopDong.UpdateHopDongVay(entry.HopDong);
                MessageBox.Show("Thêm biên bản thu nợ lãi thành công", "Thông báo");
                this.Close();
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
            TraCuuKhachHangForm newForm = new TraCuuKhachHangForm();
            newForm.ShowDialog();
            if (newForm.DialogResult == DialogResult.OK)
            {
                selectedKH = newForm.result;
                textBox2.Text = selectedKH.HoTen;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            KhachHang newForm = new KhachHang();
            newForm.Show();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                double input = (double)numericUpDown1.Value;
                if (Double.IsNaN(input)) throw new Exception("Invalid number format");
                label7.Text = HelperFunction.Number2Pronounce(input);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
