using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DataModel;
using BusinessLogicTier;
using System.Windows.Forms;

namespace QLNH
{
    public partial class HopDongQuaHanForm : Form
    {
        private HopDongVayBUS busObj;
        private string MaHD = "";
        private HopDongChoVay selectedHD;
        public HopDongQuaHanForm(string MaHD)
        {
            busObj = new HopDongVayBUS();
            this.MaHD = MaHD;
            InitializeComponent();
        }

        private void HopDongQuaHanForm_Load(object sender, EventArgs e)
        {
            
            try
            {
                selectedHD = busObj.GetHopDongVayByMaHopDong(MaHD);
                textBox3.Text = selectedHD.MaHopDong;
                textBox10.Text = selectedHD.NgayThietLap.ToString();
                textBox1.Text = "0";
                numericUpDown1.Value = (Decimal) selectedHD.YeuCauVay.SoTienVay;
                numericUpDown2.Value = (Decimal) selectedHD.YeuCauVay.KyHan;
                numericUpDown3.Value = (Decimal) selectedHD.YeuCauVay.LaiSuat;
                numericUpDown4.Value = (Decimal) selectedHD.GiaTriConLai;
                textBox9.Text = "";

                // TODO: This line of code loads data into the 'quanLyNganHangDataSet.DanhGiaTaiChinhExt' table. You can move, or remove it, as needed.
                this.danhGiaTaiChinhExtTableAdapter.Fill(this.quanLyNganHangDataSet.DanhGiaTaiChinhExt);
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
            //TODO: change status and update database
            selectedHD.TrangThai = new TrangThaiKhoanVay();
        }
    }
}
