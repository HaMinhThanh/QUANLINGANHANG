using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataModel;

namespace QLNH
{
    public partial class XetDuyetChoVayForm : Form
    {
        private YeuCauChoVay selectedYC;
        public XetDuyetChoVayForm()
        {
            InitializeComponent();
        }

        private void XetDuyetChoVayForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyNganHangDataSet.YeuCauVay' table. You can move, or remove it, as needed.
            this.yeuCauVayTableAdapter.Fill(this.quanLyNganHangDataSet.YeuCauVay);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LapKetQuaXetDuyet newForm = new LapKetQuaXetDuyet();
            newForm.ShowDialog();
            if (newForm.DialogResult == DialogResult.OK)
            {
                selectedYC.KQXetDuyet = newForm.result;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
