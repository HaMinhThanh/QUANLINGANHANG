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
    public partial class XuLiYeuCauHĐForm : Form
    {
        private DSDieuKhoanBUS busObj;
        public string MaYeuCau { get; set; } = "";

        public XuLiYeuCauHĐForm()
        {
            busObj = new DSDieuKhoanBUS();
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //save
            try
            {
                //TODO: clear the term list before adding new one
                foreach (ListViewItem entry in listView1.Items)
                {
                    busObj.AddDieuKhoanToHopDong(entry.Text, MaYeuCau);
                }
                MessageBox.Show("Đã lưu danh sách điều khoản hợp đồng", "Thông báo");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //add
            Forms.DanhSachDieuKhoan newForm = new Forms.DanhSachDieuKhoan(0);
            newForm.ShowDialog();
            if (newForm.DialogResult == DialogResult.OK)
            {
                ListViewItem new_item = new ListViewItem(newForm.selectedTerm.MaDieuKhoan);
                new_item.SubItems.Add(newForm.selectedTerm.MoTa);
                
                listView1.Items.Add(new_item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //remove
            //TODO: confirm box
            if (listView1.SelectedItems.Count > 0)
            {
                foreach (ListViewItem entry in listView1.Items)
                    listView1.Items.Remove(entry);
            }
            
        }
    }
}
