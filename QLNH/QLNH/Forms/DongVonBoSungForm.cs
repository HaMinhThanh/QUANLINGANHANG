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
        BusinessLogicTier.GiaoDichBUS busObj;
        public DongVonBoSungForm()
        {
            InitializeComponent();
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
                transactionIn.DonViGiaoDich = textBox4.Text;
                transactionIn.GiaTri = Double.Parse(textBox5.Text);
                transactionIn.MoTa = richTextBox2.Text;

                busObj.AddGiaoDich(transactionIn);
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
    }
}
