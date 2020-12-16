using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogicTier;
using DataModel;

namespace QLNH
{
    public partial class XacNhanHopDongForm : Form
    {
        private YeuCauChoVay selectedYC = null;
        private YeuCauVayBUS busObjYC;
        private TrangThaiKhoanVayBUS busObjTT;
        private HopDongVayBUS busObj;
        public XacNhanHopDongForm()
        {
            busObjTT = new TrangThaiKhoanVayBUS();
            busObj = new HopDongVayBUS();
            busObjYC = new YeuCauVayBUS();
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (selectedYC == null)
            {
                MessageBox.Show("Chưa chọn yêu cầu trước khi thao tác", "Thông báo");
                return;
            }
            Forms.ChiTietKhoanVay newForm = new Forms.ChiTietKhoanVay(selectedYC.MaYeuCau, true);
            newForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HopDongChoVay entry = new HopDongChoVay();

            try
            {
                entry.YeuCauVay = selectedYC;
                entry.GiaTriConLai = selectedYC.SoTienVay;
                entry.NgayThietLap = DateTime.Now;
                //hard coded for active state
                entry.TrangThai = busObjTT.GetTrangThaiByMaTrangThai("00000000-0000-0000-0000-000000000001");
                entry.NVThietLap = (NhanVienTinDung)SessionState.NVDangNhap;

                string MaHopDong = busObj.AddHopDongVay(entry);
                MessageBox.Show("Thêm hợp đồng thành công", "Thông báo");
                this.yeuCauVayExtRightTableAdapter.Fill(this.quanLyNganHangDataSet.YeuCauVayExtRight);

                //logging
                DataModel.HoatDong action = new DataModel.HoatDong();
                action.NhanVienThucHien = SessionState.NVDangNhap;
                action.ThoiDiem = DateTime.Now;
                action.MoTa = "Thiết lập hợp đồng " + MaHopDong;
                new BusinessLogicTier.HoatDongBUS().AddHoatDong(action);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string MaYeuCau = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            try
            {
                selectedYC = busObjYC.GetYeuCauChoVayByMaYC(MaYeuCau);
                textBox6.Text = selectedYC.ThoiDiemTiepNhan.ToString();
                numericUpDown1.Value = new Decimal(selectedYC.SoTienVay);
                numericUpDown2.Value = new Decimal(selectedYC.KyHan);
                numericUpDown3.Value = new Decimal(selectedYC.LaiSuat);
                textBox2.Text = selectedYC.KHYeuCau.HoTen;
                textBox3.Text = selectedYC.KHYeuCau.NgaySinh.ToString();
                textBox1.Text = selectedYC.KHYeuCau.DiaChi;
                textBox4.Text = selectedYC.KHYeuCau.DinhDanhKH.MaDinhDanh;
                textBox5.Text = selectedYC.KHYeuCau.SDT;
                label15.Text = selectedYC.KHYeuCau.GioiTinh;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void XacNhanHopDongForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyNganHangDataSet.YeuCauVayExtRight' table. You can move, or remove it, as needed.
            
            ((BindingSource)dataGridView1.DataSource).Filter = "(MaHopDong IS NULL) AND (coChapNhan = 'true')";
            this.yeuCauVayExtRightTableAdapter.Fill(this.quanLyNganHangDataSet.YeuCauVayExtRight);
        }
    }
}
