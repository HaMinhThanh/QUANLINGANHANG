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
    public partial class TaiSanTheChapForm : Form
    {
        private TaiSanTheChapBUS busObj;
        private TrangThaiTaiSanBUS busObjTrangThai;

        public string MaYeuCau { get; set; } = "";

        public TaiSanTheChapForm()
        {
            busObj = new TaiSanTheChapBUS();
            busObjTrangThai = new TrangThaiTaiSanBUS();
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!textBox2.Text.Equals(""))
            {
                listView1.Items.Add(textBox2.Text);
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && listView1.SelectedIndices.Count > 0)
            {
                contextMenuStrip1.Show();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                List<String> toBeDeleled = new List<string>();
                foreach (ListViewItem val in listView1.SelectedItems)
                {
                    listView1.Items.Remove(val);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TaiSanTheChap entry = new TaiSanTheChap();
            entry.DSMaGiayToChungThuc = new List<string>();
            entry.MoTa = richTextBox2.Text;
            foreach (ListViewItem val in listView1.SelectedItems)
            {
                entry.DSMaGiayToChungThuc.Add(val.Text);
            }
            entry.TrangThai = busObjTrangThai.GetTrangThaiByMaTrangThai(comboBox1.SelectedValue.ToString());
            try
            {
                busObj.AddTaiSanTheChap(entry, MaYeuCau);
                MessageBox.Show("Tài sản thế chấp thêm thành công", "Thông báo");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void TaiSanTheChapForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyNganHangDataSet.TrangThaiTaiSanCB' table. You can move, or remove it, as needed.
            this.trangThaiTaiSanCBTableAdapter.Fill(this.quanLyNganHangDataSet.TrangThaiTaiSanCB);
            comboBox1.SelectedIndex = 0;
        }

        private void TaiSanTheChapForm_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyNganHangDataSet.TrangThaiTaiSanCB' table. You can move, or remove it, as needed.
            this.trangThaiTaiSanCBTableAdapter.Fill(this.quanLyNganHangDataSet.TrangThaiTaiSanCB);

        }
    }
}
