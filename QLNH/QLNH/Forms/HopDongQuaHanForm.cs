using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using BusinessLogicTier;
using System.Windows.Forms;

namespace QLNH
{
    public partial class HopDongQuaHanForm : Form
    {
        private HopDongVayBUS busObj;
        private string MaHD = "";
        public HopDongQuaHanForm(string MaHD)
        {
            busObj = new HopDongVayBUS();
            this.MaHD = MaHD;
            InitializeComponent();
        }

        private void HopDongQuaHanForm_Load(object sender, EventArgs e)
        {
            busObj.GetHopDongVayByMaHopDong(MaHD);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
