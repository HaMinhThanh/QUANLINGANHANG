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
            long elapsedTicks = DateTime.Now.Ticks - (new DateTime(1900, 1, 1)).Ticks;
            int days = (int) new TimeSpan(elapsedTicks).TotalDays;
            days += (int) numericUpDown1.Value;
            ((BindingSource)dataGridView1.DataSource).Filter = String.Format("Expr1 < {0}", days) ;
            this.hopDongVayExtDateTableAdapter.Fill(this.quanLyNganHangDataSet.HopDongVayExtDate);
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
            MessageBox.Show("Chức năng đang được xây dựng", "Thông báo");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            long elapsedTicks = DateTime.Now.Ticks - (new DateTime(1900, 1, 1)).Ticks;
            int days = (int)new TimeSpan(elapsedTicks).TotalDays;
            days += (int)numericUpDown1.Value;
            ((BindingSource)dataGridView1.DataSource).Filter = String.Format("Expr1 < {0}", days);
            this.hopDongVayExtDateTableAdapter.Fill(this.quanLyNganHangDataSet.HopDongVayExtDate);
        }
    }
}
