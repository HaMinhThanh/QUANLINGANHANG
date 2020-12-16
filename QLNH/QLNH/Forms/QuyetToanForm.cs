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
    public partial class QuyetToanForm : Form
    {
        public QuyetToanForm()
        {
            InitializeComponent();
        }

        private void QuyetToanForm_Load(object sender, EventArgs e)
        {

            //this.giaoDichTableAdapter.Fill(this.quanLyNganHangDataSet.GiaoDich);
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Xin chọn một mốc thời gian quyết toán hợp lệ");
                return;
            }

            string startDate = dateTimePicker1.Value.ToString("MM/dd/yyyy HH:mm:ss");
            string endDate = dateTimePicker2.Value.ToString("MM/dd/yyyy HH:mm:ss");
            ((BindingSource)dataGridView1.DataSource).Filter = String.Format("LoaiGiaoDich = 1 AND MoTa LIKE '{0}*' AND ThoiDiemThucHien >= #{1}# AND ThoiDiemThucHien <= #{2}#", "Thu tiền cho khoản vay ", startDate, endDate);
            ((BindingSource)dataGridView2.DataSource).Filter = String.Format("LoaiGiaoDich = 2 AND MoTa LIKE '{0}*' AND ThoiDiemThucHien >= #{1}# AND ThoiDiemThucHien <= #{2}#", "Phát tiền cho khoản vay ", startDate, endDate);
            // TODO: This line of code loads data into the 'quanLyNganHangDataSet.GiaoDich' table. You can move, or remove it, as needed.
            this.giaoDichTableAdapter.Fill(this.quanLyNganHangDataSet.GiaoDich);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang xây dựng", "Thông báo");
        }
    }
}
