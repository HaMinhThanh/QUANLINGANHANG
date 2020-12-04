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
        private BusinessLogicTier.KhachHangBUS busObjKhachHang;
        public DongVonBoSungForm()
        {
            InitializeComponent();
            busObj = new BusinessLogicTier.GiaoDichBUS();
            busObjKhachHang = new BusinessLogicTier.KhachHangBUS();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double input = Double.Parse(textBox5.Text);
                if (Double.IsNaN(input)) throw new Exception("Invalid number format");
                label12.Text = HelperFunction.Number2Pronounce(input);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //Button Them
                GiaoDichThu transactionIn = new GiaoDichThu();
                transactionIn.ThoiDiemThucHien = dateTimePicker2.Value;
                transactionIn.DonViGiaoDich = busObjKhachHang.GetKhachHangByMaKH(textBox4.Text);
                transactionIn.GiaTri = Double.Parse(textBox5.Text);
                transactionIn.MoTa = richTextBox2.Text;

                bool res = busObj.AddGiaoDich(transactionIn);
                if (res) MessageBox.Show("Thêm giao dịch thành công", "Thông báo");
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void DongVonBoSungForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyNganHangDataSet.GiaoDich' table. You can move, or remove it, as needed.
            this.giaoDichTableAdapter.Fill(this.quanLyNganHangDataSet.GiaoDich);

        }
    }
}
