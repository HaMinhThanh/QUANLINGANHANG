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
    public partial class DinhGiaTaiSanTheChapForm : Form
    {
        private TaiSanTheChapBUS busObjTSTC;
        private GiayToChungThucBUS busObjChungThuc;

        TaiSanTheChap selectedTS = null;
        public DinhGiaTaiSanTheChapForm()
        {
            busObjTSTC = new TaiSanTheChapBUS();
            busObjChungThuc = new GiayToChungThucBUS();
            InitializeComponent();
        }

        private void DinhGiaTaiSanTheChapForm_Load(object sender, EventArgs e)
        {
            ((BindingSource)dataGridView1.DataSource).Filter = "DinhGia = -1 OR DinhGia IS NULL";
            // TODO: This line of code loads data into the 'quanLyNganHangDataSet.TaiSanTheChapExt' table. You can move, or remove it, as needed.
            this.taiSanTheChapExtTableAdapter.Fill(this.quanLyNganHangDataSet.TaiSanTheChapExt);
            this.trangThaiTaiSanCBTableAdapter.Fill(this.quanLyNganHangDataSet.TrangThaiTaiSanCB);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string MaTSTC = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            try
            {
                selectedTS = busObjTSTC.GetTaiSanTheChapByMaTSTC(MaTSTC);
                textBox1.Text = selectedTS.MaTSTC;
                comboBox1.SelectedValue = selectedTS.TrangThai.UUID;
                richTextBox2.Text = selectedTS.MoTa;
                numericUpDown1.Value = 0;
                listView1.Items.Clear();
                selectedTS.DSMaGiayToChungThuc = busObjChungThuc.GetMaGiayChungThucByMaTaiSan(selectedTS.MaTSTC);
                listView1.BeginUpdate();
                foreach (string val in selectedTS.DSMaGiayToChungThuc)
                {
                    listView1.Items.Add(val);
                }
                listView1.EndUpdate();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedTS == null)
            {
                MessageBox.Show("Xin chọn tài sản thế chấp trước khi lưu thay đổi", "Thông báo");
                return;
            }
            selectedTS.DinhGia = (double)numericUpDown1.Value;
            selectedTS.TrangThai.UUID = comboBox1.SelectedValue.ToString();
            try
            {
                busObjTSTC.UpdateTaiSanTheChap(selectedTS);
                MessageBox.Show("Đã định giá tài sản thành công", "Thông báo");
                this.taiSanTheChapExtTableAdapter.Fill(this.quanLyNganHangDataSet.TaiSanTheChapExt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
