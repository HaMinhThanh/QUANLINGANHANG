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
    public partial class QuyetToanForm : Form
    {
        public QuyetToanForm()
        {
            InitializeComponent();
        }

        private void QuyetToanForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyNganHangDataSet.GiaoDich' table. You can move, or remove it, as needed.
            this.giaoDichTableAdapter.Fill(this.quanLyNganHangDataSet.GiaoDich);

        }
    }
}
