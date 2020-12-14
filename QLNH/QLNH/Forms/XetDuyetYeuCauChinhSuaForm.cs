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

namespace QLNH.Forms
{
    public partial class XetDuyetYeuCauChinhSuaForm : Form
    {
        private YeuCauChinhSuaHopDong selectedYC;
        private YeuCauChinhSuaBUS busObj;
        private YeuCauVayBUS busObjYCVay;
        public XetDuyetYeuCauChinhSuaForm()
        {
            busObj = new YeuCauChinhSuaBUS();
            busObjYCVay = new YeuCauVayBUS();
            InitializeComponent();
        }

        private void XetDuyetYeuCauChinhSuaForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyNganHangDataSet.YeuCauChinhSuaExt' table. You can move, or remove it, as needed.
            ((BindingSource)dataGridView1.DataSource).Filter = "MaKQXetDuyet IS NULL";
            this.yeuCauChinhSuaExtTableAdapter.Fill(this.quanLyNganHangDataSet.YeuCauChinhSuaExt);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //accept
            if (selectedYC == null)
            {
                MessageBox.Show("Chưa chọn yêu cầu trước khi thao tác", "Thông báo");
                return;
            }
            LapKetQuaXetDuyet newForm = new LapKetQuaXetDuyet();
            newForm.isChapNhan = true;
            newForm.entry = selectedYC.HopDong.YeuCauVay;
            newForm.ShowDialog();
            if (newForm.DialogResult == DialogResult.OK)
            {
                selectedYC.KQXetDuyet = newForm.result;
                updateYeuCau();
                this.yeuCauChinhSuaExtTableAdapter.Fill(this.quanLyNganHangDataSet.YeuCauChinhSuaExt);
            }
            if (selectedYC.HopDong.ApplyModification(selectedYC))
            {
                try
                {
                    busObjYCVay.UpdateYeuCauChoVay(selectedYC.HopDong.YeuCauVay);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //deny
            if (selectedYC == null)
            {
                MessageBox.Show("Chưa chọn yêu cầu trước khi thao tác", "Thông báo");
                return;
            }
            LapKetQuaXetDuyet newForm = new LapKetQuaXetDuyet();
            newForm.isChapNhan = false;
            newForm.entry = selectedYC.HopDong.YeuCauVay;
            newForm.ShowDialog();
            if (newForm.DialogResult == DialogResult.OK)
            {
                selectedYC.KQXetDuyet = newForm.result;
                updateYeuCau();
                this.yeuCauChinhSuaExtTableAdapter.Fill(this.quanLyNganHangDataSet.YeuCauChinhSuaExt);
            }
        }

        private void updateYeuCau()
        {
            try
            {
                busObj.UpdateYeuCauChinhSuaHopDong(selectedYC);
                MessageBox.Show("Cập nhật dữ liệu yêu cầu cho vay thành công", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //quit
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //detail
            if (selectedYC == null)
            {
                MessageBox.Show("Chưa chọn yêu cầu trước khi thao tác", "Thông báo");
                return;
            }
            ChiTietKhoanVay newForm = new ChiTietKhoanVay(selectedYC.HopDong.MaHopDong);
            newForm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //select
            string MaYeuCau = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            try
            {
                selectedYC = busObj.GetYeuCauChinhSuaHopDong(MaYeuCau);
                textBox3.Text = selectedYC.HopDong.YeuCauVay.KHYeuCau.MaKH;
                textBox4.Text = selectedYC.HopDong.YeuCauVay.KHYeuCau.HoTen;
                textBox10.Text = selectedYC.HopDong.NgayThietLap.ToString();
                numericUpDown3.Value = (Decimal)selectedYC.HopDong.GiaTriConLai;
                numericUpDown4.Value = (Decimal)selectedYC.HopDong.YeuCauVay.SoTienVay;
                numericUpDown5.Value = (Decimal)selectedYC.HopDong.YeuCauVay.KyHan;
                numericUpDown6.Value = (Decimal)selectedYC.HopDong.YeuCauVay.LaiSuat;
                textBox8.Text = selectedYC.HopDong.TrangThai.TenTrangThai;

                if (selectedYC.ctKiHan != null)
                {
                    numericUpDown2.Value = (Decimal) selectedYC.ctKiHan.GiaTriMoi;
                }
                else if (selectedYC.ctLaiSuat != null)
                {
                    numericUpDown1.Value = (Decimal) selectedYC.ctLaiSuat.GiaTriMoi;
                }
                textBox1.Text = selectedYC.HopDong.MaHopDong;
                textBox2.Text = selectedYC.HopDong.TrangThai.TenTrangThai;
                richTextBox1.Text = selectedYC.LyDo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
