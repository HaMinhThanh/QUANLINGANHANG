using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogicTier;

namespace QLNH.Forms
{
    public partial class ChiTietKhachHangForm : Form
    {
        public string maKH = "";
        public KhachHangBUS busObj;
        public ChiTietKhachHangForm()
        {
            busObj = new KhachHangBUS();
            InitializeComponent();
            
        }

        public ChiTietKhachHangForm(string maKH)
        {
            busObj = new KhachHangBUS();
            this.maKH = maKH;
            busObj.GetKhachHangByMaKH(maKH);
            InitializeComponent();
            
        }

        private void ChiTietKhachHangForm_Load(object sender, EventArgs e)
        {
            try
            {
                DataModel.KhachHang res = busObj.GetKhachHangByMaKH(maKH);

                // TODO: This line of code loads data into the 'quanLyNganHangDataSet.GiaoDich' table. You can move, or remove it, as needed.
                ((BindingSource)dataGridView1.DataSource).Filter = String.Format("DonViGiaoDich = '{0}'", res.DinhDanhKH);
                this.giaoDichTableAdapter.Fill(this.quanLyNganHangDataSet.GiaoDich);

                textBox1.Text = res.MaKH;
                textBox2.Text = res.HoTen;
                dateTimePicker1.Value = res.NgaySinh;
                textBox4.Text = res.DinhDanhKH.GiaTriDinhDanh;
                textBox5.Text = res.DiaChi;
                textBox6.Text = res.GioiTinh;
                textBox9.Text = res.SDT;
                //TODO: comboBox and companyCustomer info
                if (res is DataModel.KhachHangDoanhNghiep) {
                    textBox3.Text = "Doanh nghiệp";
                    textBox7.Text = ((DataModel.KhachHangDoanhNghiep)res).MaDKDoanhNghiep;
                    textBox8.Text = ((DataModel.KhachHangDoanhNghiep)res).ChucVuKHDaiDien;
                    textBox10.Text = ((DataModel.KhachHangDoanhNghiep)res).TenDoanhNghiep;
                    textBox11.Text = ((DataModel.KhachHangDoanhNghiep)res).LinhVuc;
                }
                else
                {
                    textBox3.Text = "Cá nhân";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
