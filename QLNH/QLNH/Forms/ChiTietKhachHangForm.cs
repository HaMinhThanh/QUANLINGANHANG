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
                textBox1.Text = res.MaKH;
                textBox2.Text = res.HoTen;
                dateTimePicker1.Value = res.NgaySinh;
                textBox4.Text = res.DinhDanhKH.GiaTriDinhDanh;
                textBox5.Text = res.DiaChi;
                textBox6.Text = res.GioiTinh;
                textBox9.Text = res.SDT;
                //TODO: comboBox and companyCustomer info

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
