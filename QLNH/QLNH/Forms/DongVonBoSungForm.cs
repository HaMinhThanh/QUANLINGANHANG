using DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLNH
{
    public partial class DongVonBoSungForm : Form
    {
        private BusinessLogicTier.GiaoDichBUS busObj;
        private DataModel.KhachHang selectedKH = null;
        public DongVonBoSungForm()
        {
            InitializeComponent();
            busObj = new BusinessLogicTier.GiaoDichBUS();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (selectedKH == null)
            {
                MessageBox.Show("Xin chọn đơn vị giao dịch trước khi tạo giao dịch mới", "Thông báo");
                return;
            }
            try
            {
                //Button Them
                GiaoDichThu transactionIn = new GiaoDichThu();
                transactionIn.ThoiDiemThucHien = dateTimePicker2.Value;
                transactionIn.DonViGiaoDich = selectedKH;
                transactionIn.GiaTri = (Double)numericUpDown1.Value;
                transactionIn.MoTa = richTextBox2.Text;

                bool res = busObj.AddGiaoDich(transactionIn);
                if (res) MessageBox.Show("Thêm giao dịch thành công", "Thông báo");

                //logging
                DataModel.HoatDong action = new DataModel.HoatDong();
                action.NhanVienThucHien = SessionState.NVDangNhap;
                action.ThoiDiem = DateTime.Now;
                action.MoTa = "Thêm giao dịch thu giá trị " + numericUpDown1.Value.ToString();
                new BusinessLogicTier.HoatDongBUS().AddHoatDong(action);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DongVonBoSungForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát khỏi biểu mẫu, các thay đổi có thể chưa được lưu lại?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TraCuuKhachHangForm newForm = new TraCuuKhachHangForm();
            newForm.ShowDialog();
            if (newForm.DialogResult == DialogResult.OK)
            {
                selectedKH = newForm.result;
                textBox4.Text = textBox1.Text = selectedKH.HoTen;
                ((BindingSource)dataGridView1.DataSource).Filter = String.Format("DonViGiaoDich = '{0}' AND LoaiGiaoDich = 1", selectedKH.MaKH);
                this.giaoDichTableAdapter.Fill(this.quanLyNganHangDataSet.GiaoDich);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            KhachHang newForm = new KhachHang();
            newForm.Show();
        }

        private void DongVonBoSungForm_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                double input = (Double)numericUpDown1.Value;
                if (Double.IsNaN(input)) throw new Exception("Invalid number format");
                label12.Text = HelperFunction.Number2Pronounce(input);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (selectedKH == null) return;
            string startTime = dateTimePicker1.Value.ToString("MM/dd/yyyy HH:mm:ss");
            string endTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            ((BindingSource)dataGridView1.DataSource).Filter = String.Format("DonViGiaoDich = '{0}' AND LoaiGiaoDich = 1 AND ThoiDiemThucHien >= #{1}# AND ThoiDiemThucHien <= #{2}#", selectedKH.MaKH, startTime, endTime);
            this.giaoDichTableAdapter.Fill(this.quanLyNganHangDataSet.GiaoDich);
        }
    }
}
