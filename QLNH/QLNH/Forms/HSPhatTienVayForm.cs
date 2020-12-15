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
        private DataModel.KhachHang selectedKH = null;

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
                selectedKH = selectedHD.YeuCauVay.KHYeuCau;
                textBox6.Text = selectedKH.HoTen;
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
                entry.GiaoDichThucHien.DonViGiaoDich = selectedKH;
                entry.GiaoDichThucHien.GiaTri = (Double) numericUpDown1.Value;
                entry.GiaoDichThucHien.MoTa = "Phát tiền cho khoản vay " + selectedHD.MaHopDong;
                entry.GiaoDichThucHien.ThoiDiemThucHien = dateTimePicker2.Value;

                busObjGiaoDich.AddGiaoDich(entry.GiaoDichThucHien);
                busObj.AddHoatDongPhatTien(entry);
                MessageBox.Show("Thêm biên bản phát tiền thành công", "Thông báo");
                this.Close();
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
            TraCuuKhachHangForm newForm = new TraCuuKhachHangForm();
            newForm.ShowDialog();
            if (newForm.DialogResult == DialogResult.OK)
            {
                selectedKH = newForm.result;
                textBox6.Text = selectedKH.HoTen;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            KhachHang newForm = new KhachHang();
            newForm.Show();
        }

        private void HSPhatTienVayForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = SessionState.NVDangNhap.HoTen;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                double input = (double) numericUpDown1.Value;
                if (Double.IsNaN(input)) throw new Exception("Invalid number format");
                label2.Text = HelperFunction.Number2Pronounce(input);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
