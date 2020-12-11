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

namespace QLNH.Forms
{
    public partial class DanhSachDieuKhoan : Form
    {
        public DieuKhoanChoVay selectedTerm { get; set; } = null; 
        private DieuKhoanBUS busObj;
        private int mode = 0;

        public DanhSachDieuKhoan(int mode)
        {
            busObj = new DieuKhoanBUS();
            this.mode = mode;
            InitializeComponent();
        }

        private void DanhSachDieuKhoan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyNganHangDataSet.DieuKhoan' table. You can move, or remove it, as needed.
            this.dieuKhoanTableAdapter.Fill(this.quanLyNganHangDataSet.DieuKhoan);
            if (mode == 1)
            { //edit mode
                textBox1.Enabled = true;
                richTextBox1.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //search
            try
            {
                ((BindingSource)dataGridView1.DataSource).Filter = "MoTa LIKE %" + textBox2.Text +"%";
                this.dieuKhoanTableAdapter.Fill(this.quanLyNganHangDataSet.DieuKhoan);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //add
            DieuKhoanChoVay entry = new DieuKhoanChoVay();
            entry.MoTa = richTextBox1.Text;
            try
            {
                busObj.AddDieuKhoan(entry);
                MessageBox.Show("Thêm điều khoản thành công", "Thông báo");
                this.dieuKhoanTableAdapter.Fill(this.quanLyNganHangDataSet.DieuKhoan);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //edit
            if (selectedTerm == null)
            {
                MessageBox.Show("Xin hãy chọn một điều khoản trước khi chỉnh sửa", "Thông báo");
                return;
            }
            try
            {
                selectedTerm.MoTa = richTextBox1.Text;
                busObj.UpdateDieuKhoan(selectedTerm);
                MessageBox.Show("Chỉnh sửa điều khoản thành công", "Thông báo");
                this.dieuKhoanTableAdapter.Fill(this.quanLyNganHangDataSet.DieuKhoan);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (selectedTerm == null)
            {
                MessageBox.Show("Xin hãy chọn một điều khoản trước khi xóa", "Thông báo");
                return;
            }
            try
            {
                busObj.RemoveDieuKhoan(selectedTerm.MaDieuKhoan);
                MessageBox.Show("Xóa điều khoản thành công", "Thông báo");
                this.dieuKhoanTableAdapter.Fill(this.quanLyNganHangDataSet.DieuKhoan);
                selectedTerm = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedTerm = busObj.GetDieuKhoanHopDongByMaDieuKhoan(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            if (mode == 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                textBox1.Text = selectedTerm.MaDieuKhoan;
                richTextBox1.Text = selectedTerm.MoTa;
            }
        }
    }
}
