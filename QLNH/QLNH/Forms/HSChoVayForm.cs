using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogicTier;

namespace QLNH
{
    public partial class HSChoVayForm : Form
    {
        private string MaYeuCau = "";
        private KhachHangBUS busObjKH;
        private YeuCauVayBUS busObj;

        public HSChoVayForm()
        {
            busObj = new YeuCauVayBUS();
            busObjKH = new KhachHangBUS();
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            KhachHang newForm = new KhachHang();
            newForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyNganHangDataSet.KhachHang' table. You can move, or remove it, as needed.
            this.khachHangTableAdapter.Fill(this.quanLyNganHangDataSet.KhachHang);
        }

        private void HSChoVayForm_Load(object sender, EventArgs e)
        {
            this.taiSanTheChapExtTableAdapter.Fill(this.quanLyNganHangDataSet.TaiSanTheChapExt);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyNganHangDataSet.TaiSanTheChapExt' table. You can move, or remove it, as needed.
            TaiSanTheChapForm newForm = new TaiSanTheChapForm();
            newForm.MaYeuCau = MaYeuCau;
            newForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataModel.YeuCauChoVay entry = new DataModel.YeuCauChoVay();
            entry.KHYeuCau = busObjKH.GetKhachHangByMaKH(textBox1.Text);
            entry.NVTiepNhan = (DataModel.NhanVienTinDung) SessionState.NVDangNhap;
            entry.ThoiDiemTiepNhan = DateTime.Now;
            entry.SoTienVay = (Double) numericUpDown1.Value;
            entry.KyHan = (int)numericUpDown2.Value;
            entry.LaiSuat = Double.Parse(label11.Text);
            try
            {
                MaYeuCau = busObj.AddYeuCauChoVay(entry);
                MessageBox.Show("Thêm yêu cầu vay thành công", "Thông báo");
                button3.Enabled = true;
                dataGridView2.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void HSChoVayForm_Activated(object sender, EventArgs e)
        {
            if (dataGridView2.Enabled)
            {
                this.taiSanTheChapExtTableAdapter.Fill(this.quanLyNganHangDataSet.TaiSanTheChapExt);
            }
        }
    }
}
