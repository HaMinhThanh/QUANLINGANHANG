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
    public partial class HSPhatTienVayForm : Form
    {
        private HoatDongPhatTienBUS busObj;
        private GiaoDichBUS busObjGiaoDich;
        private KhachHangBUS busObjKhachHang;
        private HopDongChoVay selectedHD = null; 

        public HSPhatTienVayForm()
        {
            busObj = new HoatDongPhatTienBUS();
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
                textBox5.Text = selectedHD.MaHopDong;
                textBox6.Text = selectedHD.YeuCauVay.KHYeuCau.MaKH;
                textBox3.Text = selectedHD.YeuCauVay.KHYeuCau.MaKH;
                textBox12.Text = selectedHD.YeuCauVay.KHYeuCau.HoTen;
                textBox8.Text = selectedHD.NgayThietLap.ToString();
                textBox2.Text = selectedHD.YeuCauVay.SoTienVay.ToString();
                textBox4.Text = selectedHD.YeuCauVay.KyHan.ToString();
                textBox9.Text = selectedHD.YeuCauVay.LaiSuat.ToString();
                textBox10.Text = selectedHD.TrangThai.TenTrangThai;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedHD == null)
            {
                MessageBox.Show("Chưa chọn hợp đồng vay để phát tiền", "Thông báo");
            }
            try
            {
                BienBanPhatTien entry = new BienBanPhatTien();
                entry.GiaoDichThucHien = new GiaoDichChi();
                entry.HopDong = selectedHD;
                entry.NVThucHien = (NhanVienKeToan) SessionState.NVDangNhap;
                entry.GiaoDichThucHien.DonViGiaoDich = busObjKhachHang.GetKhachHangByMaKH(textBox6.Text);
                entry.GiaoDichThucHien.GiaTri = (Double) numericUpDown1.Value;
                entry.GiaoDichThucHien.MoTa = "Phát tiền cho khoản vay";
                entry.GiaoDichThucHien.ThoiDiemThucHien = dateTimePicker2.Value;

                busObjGiaoDich.AddGiaoDich(entry.GiaoDichThucHien);
                busObj.AddHoatDongPhatTien(entry);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
