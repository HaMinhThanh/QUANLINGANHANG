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
        private TrangThaiKhoanVayBUS busObjTrangThai;
        public HopDongQuaHanForm(string MaHD)
        {
            busObj = new HopDongVayBUS();
            busObjTrangThai = new TrangThaiKhoanVayBUS();
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

                //filter
                ((BindingSource)dataGridView1.DataSource).Filter = String.Format("MoTa LIKE '*{0}'", selectedHD.MaHopDong);
                this.giaoDichTableAdapter.Fill(this.quanLyNganHangDataSet.GiaoDich);

                //filter
                ((BindingSource)dataGridView2.DataSource).Filter = String.Format("MaKHBaoCao = '{0}'", selectedHD.YeuCauVay.KHYeuCau.MaKH);
                this.danhGiaTaiChinhExtTableAdapter.Fill(this.quanLyNganHangDataSet.DanhGiaTaiChinhExt);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TODO: change status and update database
            try
            {
                selectedHD.TrangThai = busObjTrangThai.GetTrangThaiByMaTrangThai("00000000-0000-0000-0000-000000000003");
                busObj.UpdateHopDongVay(selectedHD);
                MessageBox.Show("Đã cập nhật thông tin hợp đồng vay", "Thông báo");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
