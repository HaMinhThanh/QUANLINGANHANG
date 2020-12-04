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
    public partial class TraCuuKhoanVay : Form
    {
        public HopDongChoVay result;
        private HopDongVayBUS busObj;

        public TraCuuKhoanVay()
        {
            busObj = new HopDongVayBUS();
            InitializeComponent();
        }

        private void TraCuuKhoanVay_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ((BindingSource)dataGridView1.DataSource).Filter = "";
            this.hopDongVayExtTableAdapter.Fill(this.quanLyNganHangDataSet.HopDongVayExt);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string MaHopDong = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                result = busObj.GetHopDongVayByMaHopDong(MaHopDong);
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
