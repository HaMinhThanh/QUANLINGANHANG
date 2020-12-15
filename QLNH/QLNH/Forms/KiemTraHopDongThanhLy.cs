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
    public partial class KiemTraHopDongThanhLy : Form
    {
        private HopDongChoVay selectedHD;
        private HopDongVayBUS busObj;
        public KiemTraHopDongThanhLy()
        {
            busObj = new HopDongVayBUS();
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filter = "";

            if (!textBox8.Text.Equals(""))
                filter += String.Format("MaHopDong = '{0}' AND ", textBox8.Text);
            if (numericUpDown1.Value > 0)
                filter += String.Format("GiaTriHienTai >= {0} AND ", numericUpDown1.Value);
            if (comboBox1.SelectedItem != null)
                filter += String.Format("MaTrangThai = '{0}' AND ", comboBox1.SelectedValue);
            if (!textBox1.Text.Equals(""))
                filter += String.Format("HoTen LIKE '*{0}*' AND ", textBox1.Text);
            if (dateTimePicker1.Value <= DateTime.Now)
                filter += String.Format("NgayThietLap >= #{0}# AND ", dateTimePicker1.Value.ToString("MM/dd/yyyy"));

            if (!filter.Equals(""))
                filter = filter.Substring(0, filter.LastIndexOf("AND") - 1);
            else
            {
                MessageBox.Show("Xin hãy chọn 1 tiêu chuẩn tra cứu", "Thông báo");
                return;
            }
            ((BindingSource)dataGridView1.DataSource).Filter = filter;
            this.hopDongVayExtTableAdapter.Fill(this.quanLyNganHangDataSet.HopDongVayExt);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThanhLyHopDongForm newForm = new ThanhLyHopDongForm(selectedHD.MaHopDong);
            newForm.Show();
        }

        private void KiemTraHopDongThanhLy_Load(object sender, EventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string MaHD = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            try
            {
                selectedHD = busObj.GetHopDongVayByMaHopDong(MaHD);

                textBox2.Text = selectedHD.YeuCauVay.KHYeuCau.MaKH;
                textBox4.Text = selectedHD.MaHopDong;
                textBox5.Text = selectedHD.NgayThietLap.ToString();
                textBox9.Text = SessionState.NVDangNhap.MaNV;
                textBox3.Text = selectedHD.TrangThai.TenTrangThai;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
