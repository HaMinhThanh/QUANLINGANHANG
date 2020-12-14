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
    public partial class ChiTietKhoanVay : Form
    {
        private HopDongVayBUS busObj;
        private YeuCauVayBUS busObjYC;
        private TaiSanTheChapBUS busObjTSTC;
        private string MaHopDong = "";
        private bool requestMode = false;
        public ChiTietKhoanVay()
        {
            busObj = new HopDongVayBUS();
            busObjTSTC = new TaiSanTheChapBUS();
            InitializeComponent();
        }

        

        public ChiTietKhoanVay(string MaHopDong)
        {
            busObj = new HopDongVayBUS();
            this.MaHopDong = MaHopDong;
            InitializeComponent();
        }

        public ChiTietKhoanVay(string MaHopDong, bool requestMode)
        {
            this.MaHopDong = MaHopDong;
            this.requestMode = requestMode;
            busObj = new HopDongVayBUS();
            busObjYC = new YeuCauVayBUS();
            busObjTSTC = new TaiSanTheChapBUS();
            InitializeComponent();
        }

        private void ChiTietKhoanVay_Load(object sender, EventArgs e)
        {
            try
            {
                if (requestMode == false)
                {
                    HopDongChoVay res = busObj.GetHopDongVayByMaHopDong(MaHopDong);
                    // TODO: This line of code loads data into the 'quanLyNganHangDataSet.TaiSanTheChapExt' table. You can move, or remove it, as needed.
                    ((BindingSource)dataGridView1.DataSource).Filter = "MaYeuCau = '" + res.YeuCauVay.MaYeuCau + "'";
                    this.taiSanTheChapExtTableAdapter.Fill(this.quanLyNganHangDataSet.TaiSanTheChapExt);
                    textBox8.Text = res.MaHopDong;
                    textBox2.Text = res.TrangThai.TenTrangThai;
                    textBox1.Text = res.NgayThietLap.ToString();
                    numericUpDown1.Value = (Decimal)res.YeuCauVay.SoTienVay;
                    numericUpDown2.Value = (Decimal)res.GiaTriConLai;
                    numericUpDown3.Value = (Decimal)res.YeuCauVay.KyHan;
                    numericUpDown4.Value = (Decimal)res.YeuCauVay.LaiSuat;

                    textBox3.Text = res.YeuCauVay.KHYeuCau.MaKH;
                    textBox4.Text = res.YeuCauVay.KHYeuCau.HoTen;
                    dateTimePicker2.Value = res.YeuCauVay.KHYeuCau.NgaySinh;
                    textBox5.Text = res.YeuCauVay.KHYeuCau.SDT;
                    textBox6.Text = res.YeuCauVay.KHYeuCau.DiaChi;
                    label14.Text = res.YeuCauVay.KHYeuCau.GioiTinh;
                }
                else
                {
                    YeuCauChoVay res = busObjYC.GetYeuCauChoVayByMaYC(MaHopDong);
                    ((BindingSource)dataGridView1.DataSource).Filter = "MaYeuCau = '" + res.MaYeuCau + "'";
                    this.taiSanTheChapExtTableAdapter.Fill(this.quanLyNganHangDataSet.TaiSanTheChapExt);
                    numericUpDown1.Value = (Decimal)res.SoTienVay;
                    numericUpDown3.Value = (Decimal)res.KyHan;
                    numericUpDown4.Value = (Decimal)res.LaiSuat;

                    textBox3.Text = res.KHYeuCau.MaKH;
                    textBox4.Text = res.KHYeuCau.HoTen;
                    dateTimePicker2.Value = res.KHYeuCau.NgaySinh;
                    textBox5.Text = res.KHYeuCau.SDT;
                    textBox6.Text = res.KHYeuCau.DiaChi;
                    label14.Text = res.KHYeuCau.GioiTinh;
                }
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string MaTSTC = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            try
            {
                TaiSanTheChap res = busObjTSTC.GetTaiSanTheChapByMaTSTC(MaTSTC);
                textBox7.Text = res.MaTSTC;
                textBox11.Text = res.TrangThai.TenTrangThai;
                richTextBox2.Text = res.MoTa;
                numericUpDown5.Value = (Decimal)res.DinhGia;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
