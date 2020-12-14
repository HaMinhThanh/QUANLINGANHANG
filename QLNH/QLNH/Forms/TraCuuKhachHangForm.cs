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
    public partial class TraCuuKhachHangForm : Form
    {
        public DataModel.KhachHang result { get; set; } = null;
        private KhachHangBUS busObj;
        public TraCuuKhachHangForm()
        {
            busObj = new KhachHangBUS();
            InitializeComponent();
        }

        private void TraCuuKhachHangForm_Load(object sender, EventArgs e)
        {
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string filter = "";

            if (!textBox1.Text.Equals(""))
                filter += String.Format("MaKH = '{0}' AND ", textBox1.Text);
            if (!textBox3.Text.Equals(""))
                filter += String.Format("HoTen LIKE '*{0}*' AND ", textBox3.Text);
            if (comboBox13.SelectedItem != null && comboBox13.SelectedIndex != 0 && !textBox2.Text.Equals(""))
                filter += String.Format("LoaiDinhDanh = {0} AND GiaTri LIKE '*{1}' AND ", comboBox13.SelectedIndex, textBox2.Text);
            if (comboBox10.SelectedItem != null && comboBox10.SelectedIndex != 0)
            {
                if (comboBox10.SelectedIndex == 0)
                    filter += String.Format("MaDoanhNghiepDaiDien IS NULL AND ");
                else if (comboBox10.SelectedIndex == 1)
                    filter += String.Format("MaDoanhNghiepDaiDien IS NOT NULL AND ");
            }
            if (!filter.Equals(""))
                filter = filter.Substring(0, filter.LastIndexOf("AND") - 1);
            else
            {
                MessageBox.Show("Xin hãy chọn 1 tiêu chuẩn tra cứu", "Thông báo");
                return;
            }
            ((BindingSource)dataGridView2.DataSource).Filter = filter;
            this.khachHangTableAdapter.Fill(this.quanLyNganHangDataSet.KhachHang);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string MaKH = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                result = busObj.GetKhachHangByMaKH(MaKH);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
