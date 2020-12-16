using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogicTier;

namespace QLNH
{
    public partial class HSChoVayForm : Form
    {
        private string MaYeuCau = "";
        private KhachHangBUS busObjKH;
        private YeuCauVayBUS busObj;

        public HSChoVayForm()
        {
            busObj = new YeuCauVayBUS();
            busObjKH = new KhachHangBUS();
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            KhachHang newForm = new KhachHang();
            newForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filter = "";

            if (!textBox6.Text.Equals(""))
                filter += String.Format("MaKH = '{0}' AND ", textBox6.Text);
            if (!textBox7.Text.Equals(""))
                filter += String.Format("HoTen LIKE '*{0}*' AND ", textBox7.Text);
            if (comboBox2.SelectedItem != null && comboBox2.SelectedIndex != 0 && !textBox3.Text.Equals(""))
                filter += String.Format("LoaiDinhDanh = {0} AND GiaTri LIKE '*{1}' AND ", comboBox2.SelectedIndex, textBox3.Text);
            if (!filter.Equals(""))
                filter = filter.Substring(0, filter.LastIndexOf("AND") - 1);
            else
            {
                MessageBox.Show("Xin hãy chọn 1 tiêu chuẩn tra cứu", "Thông báo");
                return;
            }
            ((BindingSource)dataGridView1.DataSource).Filter = filter;
            this.khachHangTableAdapter.Fill(this.quanLyNganHangDataSet.KhachHang);
        }

        private void HSChoVayForm_Load(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TaiSanTheChapForm newForm = new TaiSanTheChapForm();
            newForm.MaYeuCau = MaYeuCau;
            newForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataModel.YeuCauChoVay entry = new DataModel.YeuCauChoVay();
            entry.KHYeuCau = busObjKH.GetKhachHangByMaKH(textBox1.Text);
            entry.NVTiepNhan = (DataModel.NhanVienTinDung) SessionState.NVDangNhap;
            entry.ThoiDiemTiepNhan = DateTime.Now;
            entry.SoTienVay = (Double) numericUpDown1.Value;
            entry.KyHan = (int)numericUpDown2.Value;
            entry.LaiSuat = Double.Parse(label11.Text);
            try
            {
                MaYeuCau = busObj.AddYeuCauChoVay(entry);
                MessageBox.Show("Thêm yêu cầu vay thành công", "Thông báo");
                button3.Enabled = true;
                dataGridView2.Enabled = true;
                ((BindingSource)dataGridView2.DataSource).Filter = String.Format("MaYeuCau = '{0}'", MaYeuCau);
                this.taiSanTheChapExtTableAdapter.Fill(this.quanLyNganHangDataSet.TaiSanTheChapExt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void HSChoVayForm_Activated(object sender, EventArgs e)
        {
            if (dataGridView2.Enabled)
            {
                this.taiSanTheChapExtTableAdapter.Fill(this.quanLyNganHangDataSet.TaiSanTheChapExt);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Forms.TraCuuLaiSuat newForm = new Forms.TraCuuLaiSuat(0);
            newForm.ShowDialog();
            if (newForm.DialogResult == DialogResult.OK)
            {
                numericUpDown2.Value = (Decimal) newForm.selectedCycle;
                label11.Text = newForm.result.ToString();
            }
        }
    }
}
