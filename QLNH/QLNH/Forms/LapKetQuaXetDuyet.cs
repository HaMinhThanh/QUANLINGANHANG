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

namespace QLNH
{
    public partial class LapKetQuaXetDuyet : Form
    {
        public KetQuaXetDuyet result { get; set; }
        public YeuCauChoVay entry { get; set; }
        public bool isChapNhan { get; set; } = false;
        public KetQuaXetDuyetBUS busObj;

        public LapKetQuaXetDuyet()
        {
            result = new KetQuaXetDuyet();
            busObj = new KetQuaXetDuyetBUS();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                result.NVXetDuyet = (NhanVienXetDuyet) SessionState.NVDangNhap;
                result.ThoiDiemXetDuyet = DateTime.Now;
                result.isChapNhan = checkBox1.Checked;
                result.LyDo = richTextBox1.Text;

                busObj.AddKQXetDuyet(result);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LapKetQuaXetDuyet_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = isChapNhan;
        }
    }
}
