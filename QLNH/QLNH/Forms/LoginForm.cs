using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLNH.Forms
{
    public partial class LoginForm : Form
    {
        BusinessLogicTier.NhanVienBUS busObj;
        public LoginForm()
        {
            InitializeComponent();
            busObj = new BusinessLogicTier.NhanVienBUS();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SessionState.NVDangNhap = busObj.GetNhanVienByDangNhap(textBox1.Text, textBox2.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return;
            }
            if (SessionState.NVDangNhap == null)
            {
                MessageBox.Show("Không thể xác thực tài khoản, sai thông tin đăng nhập", "Thông báo");
                return;
            }
            MainForm mainForm = new MainForm();
            mainForm.rootForm = this;
            mainForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng chưa được hỗ trợ", "Thông tin");
        }
    }
}
