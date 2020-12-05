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
            // TODO: This line of code loads data into the 'quanLyNganHangDataSet.HopDongVayExt' table. You can move, or remove it, as needed.
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
