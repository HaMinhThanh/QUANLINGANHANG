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
    public partial class ThongBaoForm : Form
    {
        private HopDongVayBUS busObj;
        private HopDongChoVay selectedHD;

        public ThongBaoForm()
        {
            busObj = new HopDongVayBUS();
            InitializeComponent();
        }

        private void ThongBaoForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyNganHangDataSet.HopDongVayExt' table. You can move, or remove it, as needed.
            this.hopDongVayExtTableAdapter.Fill(this.quanLyNganHangDataSet.HopDongVayExt);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string MaHopDong = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            try
            {
                selectedHD = busObj.GetHopDongVayByMaHopDong(MaHopDong);
                textBox3.Text = selectedHD.YeuCauVay.KHYeuCau.MaKH;
                textBox1.Text = selectedHD.YeuCauVay.KHYeuCau.HoTen;
                textBox10.Text = selectedHD.NgayThietLap.ToString();
                numericUpDown2.Value = (Decimal) selectedHD.GiaTriConLai ;
                numericUpDown3.Value = (Decimal) selectedHD.YeuCauVay.SoTienVay;
                numericUpDown4.Value = (Decimal) selectedHD.YeuCauVay.KyHan;
                numericUpDown5.Value = (Decimal) selectedHD.YeuCauVay.LaiSuat;
                textBox8.Text = selectedHD.TrangThai.TenTrangThai;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
