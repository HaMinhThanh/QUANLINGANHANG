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
    public partial class BaoCaoTaiChinhForm : Form
    {
        public BaoCaoTaiChinhForm()
        {
            InitializeComponent();
        }

        private void BaoCaoTaiChinhForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyNganHangDataSet.GiaoDich' table. You can move, or remove it, as needed.
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Xin chọn một mốc thời gian quyết toán hợp lệ");
                return;
            }

            string startDate = dateTimePicker1.Value.ToString("MM/dd/yyyy HH:mm:ss");
            string endDate = dateTimePicker2.Value.ToString("MM/dd/yyyy HH:mm:ss");
            ((BindingSource)dataGridView1.DataSource).Filter = String.Format("LoaiGiaoDich = 1 AND ThoiDiemThucHien >= #{0}# AND ThoiDiemThucHien <= #{1}#", startDate, endDate);
            ((BindingSource)dataGridView2.DataSource).Filter = String.Format("LoaiGiaoDich = 2 AND ThoiDiemThucHien >= #{0}# AND ThoiDiemThucHien <= #{1}#", startDate, endDate);

            this.giaoDichTableAdapter.Fill(this.quanLyNganHangDataSet.GiaoDich);

            calculateProfitProc();
        }

        private void calculateProfitProc()
        {
            Decimal income = new Decimal(0);
            Decimal expense = new Decimal(0);
            foreach (DataGridViewRow val in dataGridView1.Rows)
            {
                income += (Decimal) val.Cells[3].Value;
            }
            foreach (DataGridViewRow val in dataGridView2.Rows)
            {
                expense += (Decimal)val.Cells[3].Value;
            }
            Decimal profit = income - expense;
            label7.Text = income.ToString() + " VND";
            label8.Text = expense.ToString() + " VND";
            label9.Text = profit.ToString() + " VND";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    dateTimePicker1.Value = dateTimePicker2.Value.AddDays(-7);
                    break;
                case 1:
                    dateTimePicker1.Value = dateTimePicker2.Value.AddDays(-30);
                    break;
                case 2:
                    dateTimePicker1.Value = dateTimePicker2.Value.AddDays(-90);
                    break;
                case 3:
                    dateTimePicker1.Value = dateTimePicker2.Value.AddDays(-365);
                    break;
                case 4:
                    dateTimePicker1.Enabled = true;
                    dateTimePicker2.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang xây dựng", "Thông báo");
        }
    }
}
