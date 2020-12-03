using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLNH
{
    public partial class TraCuuKhoanVay : Form
    {
        public TraCuuKhoanVay()
        {
            InitializeComponent();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void TraCuuKhoanVay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyNganHangDataSet.HopDongVayExt' table. You can move, or remove it, as needed.
            this.hopDongVayExtTableAdapter.Fill(this.quanLyNganHangDataSet.HopDongVayExt);

        }
    }
}
