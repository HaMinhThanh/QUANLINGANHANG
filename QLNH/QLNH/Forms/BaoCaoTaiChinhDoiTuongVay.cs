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
    public partial class BaoCaoTaiChinhDoiTuongVay : Form
    {
        private DataModel.KhachHang selectedKH = null;
        private BaoCaoDoiTuongVayBUS busObj; 
        public BaoCaoTaiChinhDoiTuongVay()
        {
            busObj = new BaoCaoDoiTuongVayBUS();
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            TraCuuKhachHangForm newForm = new TraCuuKhachHangForm();
            newForm.ShowDialog();
            if (newForm.DialogResult == DialogResult.OK)
            {
                
                selectedKH = newForm.result;
                textBox2.Text = selectedKH.MaKH;
                this.baoCaoDoiTuongVayTableAdapter.Fill(this.quanLyNganHangDataSet.BaoCaoDoiTuongVay);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (selectedKH == null)
            {
                MessageBox.Show("Chưa chọn khách hàng để báo cáo", "Thông báo");
                return;
            }
            BaoCaoTaiChinh entry = new BaoCaoTaiChinh();
            entry.DoiTuongBaoCao = selectedKH;
            entry.suDungVonDungMucDich = checkBox1.Checked;
            entry.trangThaiTaiSanDamBao = checkBox2.Checked;
            entry.DanhGia = richTextBox1.Text;

            try
            {
                busObj.AddBaoCaoDoiTuongVay(entry);
                MessageBox.Show("Thêm báo cáo tài chính khách hàng thành công", "Thông báo");
                this.baoCaoDoiTuongVayTableAdapter.Fill(this.quanLyNganHangDataSet.BaoCaoDoiTuongVay);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BaoCaoTaiChinhDoiTuongVay_Load(object sender, EventArgs e)
        {
        }
    }
}
