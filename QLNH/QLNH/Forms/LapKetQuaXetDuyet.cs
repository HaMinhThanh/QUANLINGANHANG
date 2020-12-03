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
    public partial class LapKetQuaXetDuyet : Form
    {
        public KetQuaXetDuyet result { get; set; }
        public YeuCauChoVay entry { get; set; }
        public LapKetQuaXetDuyet()
        {
            result = new KetQuaXetDuyet();
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
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
