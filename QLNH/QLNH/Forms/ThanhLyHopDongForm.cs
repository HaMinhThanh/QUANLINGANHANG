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
    public partial class ThanhLyHopDongForm : Form
    {
        private HopDongVayBUS busObj;
        private string MaHD = "";
        private HopDongChoVay selectedHD;
        public ThanhLyHopDongForm(string MaHD)
        {
            busObj = new HopDongVayBUS();
            this.MaHD = MaHD;
            InitializeComponent();
        }


        private void ThanhLyHopDongForm_Load(object sender, EventArgs e)
        {
            try
            {
                selectedHD = busObj.GetHopDongVayByMaHopDong(MaHD);
                textBox1.Text = selectedHD.MaHopDong;
                textBox12.Text = selectedHD.NgayThietLap.ToString();
                numericUpDown1.Value = (Decimal) selectedHD.YeuCauVay.SoTienVay;
                numericUpDown2.Value = (Decimal) selectedHD.YeuCauVay.KyHan;
                numericUpDown3.Value = (Decimal) selectedHD.YeuCauVay.LaiSuat;
                textBox10.Text = selectedHD.TrangThai.TenTrangThai;

                textBox2.Text = selectedHD.YeuCauVay.KHYeuCau.MaKH;
                textBox3.Text = selectedHD.MaHopDong;
                numericUpDown4.Value = (Decimal) selectedHD.GiaTriConLai;
                textBox6.Text = SessionState.NVDangNhap.MaNV;

                // TODO: This line of code loads data into the 'quanLyNganHangDataSet.GiaoDich' table. You can move, or remove it, as needed.
                this.giaoDichTableAdapter.Fill(this.quanLyNganHangDataSet.GiaoDich);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //create transaction and update loan's status
        }
    }
}
