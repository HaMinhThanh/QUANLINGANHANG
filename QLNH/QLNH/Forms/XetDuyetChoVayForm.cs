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
    public partial class XetDuyetChoVayForm : Form
    {
        private YeuCauChoVay selectedYC;
        private YeuCauVayBUS busObj;
        public XetDuyetChoVayForm()
        {
            InitializeComponent();
        }

        private void XetDuyetChoVayForm_Load(object sender, EventArgs e) 
        {
            busObj = new YeuCauVayBUS();
            // TODO: This line of code loads data into the 'quanLyNganHangDataSet.YeuCauVay' table. You can move, or remove it, as needed.
            
            this.yeuCauVayTableAdapter.Fill(this.quanLyNganHangDataSet.YeuCauVay);
            ((BindingSource)dataGridView1.DataSource).Filter = "MaKQXetDuyet IS NULL";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LapKetQuaXetDuyet newForm = new LapKetQuaXetDuyet();
            newForm.ShowDialog();
            if (newForm.DialogResult == DialogResult.OK)
            {
                selectedYC.KQXetDuyet = newForm.result;
                updateYeuCau();
                this.yeuCauVayTableAdapter.Fill(this.quanLyNganHangDataSet.YeuCauVay);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LapKetQuaXetDuyet newForm = new LapKetQuaXetDuyet();
            newForm.ShowDialog();
            if (newForm.DialogResult == DialogResult.OK)
            {
                selectedYC.KQXetDuyet = newForm.result;
                updateYeuCau();
                this.yeuCauVayTableAdapter.Fill(this.quanLyNganHangDataSet.YeuCauVay);
            }
        }

        private void updateYeuCau()
        {
            try
            {
                busObj.UpdateYeuCauChoVay(selectedYC);
                MessageBox.Show("Cập nhật dữ liệu yêu cầu cho vay thành công", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string MaYeuCau = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            try
            {
                selectedYC = busObj.GetYeuCauChoVayByMaYC(MaYeuCau);
                textBox6.Text = selectedYC.ThoiDiemTiepNhan.ToString();
                numericUpDown1.Value = new Decimal(selectedYC.SoTienVay);
                numericUpDown2.Value = new Decimal(selectedYC.KyHan);
                numericUpDown3.Value = new Decimal(selectedYC.LaiSuat);
                textBox2.Text = selectedYC.KHYeuCau.HoTen;
                textBox3.Text = selectedYC.KHYeuCau.NgaySinh.ToString();
                textBox1.Text = selectedYC.KHYeuCau.DiaChi;
                textBox4.Text = selectedYC.KHYeuCau.DinhDanhKH.MaDinhDanh;
                textBox5.Text = selectedYC.KHYeuCau.SDT;
                label15.Text = selectedYC.KHYeuCau.GioiTinh;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Forms.ChiTietKhoanVay newForm = new Forms.ChiTietKhoanVay();
            newForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
