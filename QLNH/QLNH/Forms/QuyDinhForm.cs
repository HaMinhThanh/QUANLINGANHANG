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
    public partial class QuyDinhForm : Form
    {
        private ThamSoBUS busObj;
        private ThamSo loadedThamSo;
        public QuyDinhForm()
        {
            busObj = new ThamSoBUS();
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadedThamSo.VonVayCaNhanToiDa = (Double) numericUpDown1.Value;
            loadedThamSo.VonVayToChucToiDa = (Double) numericUpDown2.Value;
            loadedThamSo.KyHanToiThieu = (Int32) numericUpDown3.Value;
            loadedThamSo.KyHanToiDa = (Int32)numericUpDown10.Value;
            loadedThamSo.TuoiDuocVayToiThieu = (Int32)numericUpDown4.Value;
            loadedThamSo.DinhGiaToiThieu = (Double) numericUpDown5.Value;
            loadedThamSo.LaiSuatToiThieu = (Double) numericUpDown6.Value;
            loadedThamSo.LaiSuatToiDa = (Double) numericUpDown7.Value;
            loadedThamSo.ThoiGianThongBaoTraNo = (Int32) numericUpDown9.Value;

            try
            {
                busObj.AddThamSo(loadedThamSo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void QuyDinhForm_Load(object sender, EventArgs e)
        {
            try
            {
                loadedThamSo = busObj.GetLatestThamSo();
                numericUpDown1.Value = (Decimal)loadedThamSo.VonVayCaNhanToiDa;
                numericUpDown2.Value = (Decimal)loadedThamSo.VonVayToChucToiDa;
                numericUpDown3.Value = (Decimal)loadedThamSo.KyHanToiThieu;
                numericUpDown10.Value = (Decimal)loadedThamSo.KyHanToiDa;
                numericUpDown4.Value = (Decimal)loadedThamSo.TuoiDuocVayToiThieu;
                numericUpDown5.Value = (Decimal)loadedThamSo.DinhGiaToiThieu;
                numericUpDown6.Value = (Decimal)loadedThamSo.LaiSuatToiThieu;
                numericUpDown7.Value = (Decimal)loadedThamSo.LaiSuatToiDa;
                numericUpDown8.Value = (Decimal)1;
                numericUpDown9.Value = (Decimal)loadedThamSo.ThoiGianThongBaoTraNo;
                numericUpDown11.Value = (Decimal)100;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
