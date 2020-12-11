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
    public partial class TraCuuKhachHangForm : Form
    {
        public DataModel.KhachHang result { get; set; } = null;
        private KhachHangBUS busObj;
        public TraCuuKhachHangForm()
        {
            busObj = new KhachHangBUS();
            InitializeComponent();
        }

        private void TraCuuKhachHangForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyNganHangDataSet.KhachHang' table. You can move, or remove it, as needed.
            this.khachHangTableAdapter.Fill(this.quanLyNganHangDataSet.KhachHang);

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string MaKH = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                result = busObj.GetKhachHangByMaKH(MaKH);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
