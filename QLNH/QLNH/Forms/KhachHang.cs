using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogicTier;
using DataModel;

namespace QLNH
{
    public partial class KhachHang : Form
    {
        private KhachHangBUS busObj = new KhachHangBUS();
        public KhachHang()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //add new customer........

            DataModel.KhachHang entry;
            if (radioButton5.Checked)
            {
                entry = new KhachHangDoanhNghiep();
                ((KhachHangDoanhNghiep)entry).MaDKDoanhNghiep = textBox3.Text;
                ((KhachHangDoanhNghiep)entry).TenDoanhNghiep = textBox6.Text;
                ((KhachHangDoanhNghiep)entry).LinhVuc = textBox7.Text;
                ((KhachHangDoanhNghiep)entry).ChucVuKHDaiDien = textBox8.Text;
            }
            else
            {
                entry = new DataModel.KhachHang();
            }
            entry.HoTen = textBox2.Text;
            entry.NgaySinh = dateTimePicker1.Value;
            entry.DiaChi = textBox5.Text;
            entry.SDT = textBox9.Text;
            entry.DinhDanhKH = new DinhDanh();
            entry.DinhDanhKH.LoaiDinhDanh = (DinhDanh.DANH_SACH_LOAI_DINH_DANH) comboBox2.SelectedIndex;
            entry.DinhDanhKH.GiaTriDinhDanh = textBox4.Text;


            if (radioButton1.Checked) entry.GioiTinh = "M";
            if (radioButton2.Checked) entry.GioiTinh = "F";
            if (radioButton3.Checked) entry.GioiTinh = "O";

            try
            {
                busObj.AddKhachHang(entry);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void KhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát khỏi biểu mẫu, các thay đổi có thể chưa được lưu lại?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                textBox3.Enabled = true;
                textBox6.Enabled = true;
                textBox7.Enabled = true;
                textBox8.Enabled = true;
            }
            else
            {
                textBox3.Enabled = false;
                textBox6.Enabled = false;
                textBox7.Enabled = false;
                textBox8.Enabled = false;
            }
        }
    }
}
