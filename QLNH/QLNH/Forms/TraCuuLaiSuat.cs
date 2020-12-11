using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogicTier;

namespace QLNH.Forms
{
    public partial class TraCuuLaiSuat : Form
    {
        public int selectedCycle { get; set; } = -1 ;
        public double result { get; set; } = 0.0;
        
        private int mode = 0;
        private ThamSoKHLSBUS busObj;

        public TraCuuLaiSuat(int mode)
        {
            this.mode = mode; 
            busObj = new ThamSoKHLSBUS();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                busObj.AddLaiSuatByKyHan((int)numericUpDown1.Value, (double)numericUpDown2.Value);
                MessageBox.Show("Đã thêm tham số lãi suất - kì hạn", "Thông báo");
                this.thamSoKyHanLaiSuatTableAdapter.Fill(this.quanLyNganHangDataSet.ThamSoKyHanLaiSuat);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                busObj.UpdateLaiSuatByKyHan((int)numericUpDown1.Value, (double)numericUpDown2.Value);
                MessageBox.Show("Đã cập nhật tham số lãi suất - kì hạn", "Thông báo");
                this.thamSoKyHanLaiSuatTableAdapter.Fill(this.quanLyNganHangDataSet.ThamSoKyHanLaiSuat);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                busObj.RemoveLaiSuatByKyHan((int) numericUpDown1.Value);
                MessageBox.Show("Đã xóa tham số lãi suất - kì hạn", "Thông báo");
                this.thamSoKyHanLaiSuatTableAdapter.Fill(this.quanLyNganHangDataSet.ThamSoKyHanLaiSuat);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void TraCuuLaiSuat_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyNganHangDataSet.ThamSoKyHanLaiSuat' table. You can move, or remove it, as needed.
            this.thamSoKyHanLaiSuatTableAdapter.Fill(this.quanLyNganHangDataSet.ThamSoKyHanLaiSuat);

            if (mode == 1)
            { //edit mode
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            numericUpDown1.Value = Decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            numericUpDown2.Value = Decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());

            if (mode == 0)
            {
                selectedCycle = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                result = Double.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
