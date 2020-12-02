using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLNH.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            TableLayoutPanel dynamicTableLayoutPanel = new TableLayoutPanel();

            //dynamicTableLayoutPanel.Location = new System.Drawing.Point(3, 110);
            dynamicTableLayoutPanel.Name = "TableLayoutPanel1";
            //dynamicTableLayoutPanel.Size = new System.Drawing.Size(300, 565);
            
            dynamicTableLayoutPanel.Dock = DockStyle.Fill;
            dynamicTableLayoutPanel.AutoSize = true;
            dynamicTableLayoutPanel.ColumnCount = 1;
            dynamicTableLayoutPanel.RowCount = 10;

            dynamicTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            dynamicTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10 ));
            dynamicTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10 ));
            dynamicTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10 ));
            dynamicTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10 ));
            dynamicTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10 ));
            dynamicTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
            dynamicTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
            dynamicTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
            dynamicTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
            dynamicTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10));

            Label lab = new Label();            
            //lab.Size = new Size(299, 44);
            lab.Text = "Chức Năng";
            lab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            lab.AutoSize = true;
            lab.TabIndex = 0;
            Controls.Add(lab);
            dynamicTableLayoutPanel.Controls.Add(lab, 0, 0);

            if (SessionState.NVDangNhap is DataModel.NhanVienTinDung)
            {
                Button btnHSChoVay = new Button();
                //btnHSChoVay.Location = new Point(3, 59);
                btnHSChoVay.Size = new Size(299, 44);
                btnHSChoVay.Text = "Tạo Hồ Sơ Cho Vay";
                btnHSChoVay.Click += BtnHSChoVay_Click;
                btnHSChoVay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                btnHSChoVay.TabIndex = 1;
                btnHSChoVay.Dock = System.Windows.Forms.DockStyle.Fill;
                Controls.Add(btnHSChoVay);

                Button btnTaiSanTheChap = new Button();
                //btnTaiSanTheChap.Location = new Point(3, 115);
                btnTaiSanTheChap.Size = new Size(299, 44);
                btnTaiSanTheChap.Text = "Tài sản thế chấp";
                btnTaiSanTheChap.Click += BtnTaiSanTheChap_Click;
                btnTaiSanTheChap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                btnTaiSanTheChap.TabIndex = 2;
                btnTaiSanTheChap.Dock = System.Windows.Forms.DockStyle.Fill;
                Controls.Add(btnTaiSanTheChap);

                Button btnThongBao = new Button();
                //btnThongBao.Location = new Point(3, 171);
                btnThongBao.Size = new Size(299, 44);
                btnThongBao.Text = "Tạo Thông Báo";
                btnThongBao.Click += BtnThongBao_Click;
                btnThongBao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                btnThongBao.TabIndex = 3;
                btnThongBao.Dock = System.Windows.Forms.DockStyle.Fill;
                Controls.Add(btnThongBao);

                Button btnXacNhanHD = new Button();
                //btnXacNhanHD.Location = new Point(3, 227);
                btnXacNhanHD.Size = new Size(299, 44);
                btnXacNhanHD.Text = "Xác Nhận Hợp Đồng";
                btnXacNhanHD.Click += BtnXacNhanHD_Click;
                btnXacNhanHD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                btnXacNhanHD.TabIndex = 4;
                btnXacNhanHD.Dock = System.Windows.Forms.DockStyle.Fill;
                Controls.Add(btnXacNhanHD);

                Button btnXuLiYeuCauHD = new Button();                
                //btnXuLiYeuCauHD.Location = new Point(3, 283);
                btnXuLiYeuCauHD.Size = new Size(299, 44);
                btnXuLiYeuCauHD.Text = "Xử lí yêu cầu hợp đồng";
                btnXuLiYeuCauHD.Click += BtnXuLiYeuCauHD_Click;
                btnXuLiYeuCauHD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                btnXuLiYeuCauHD.TabIndex = 5;
                btnXuLiYeuCauHD.Dock = System.Windows.Forms.DockStyle.Fill;
                Controls.Add(btnXuLiYeuCauHD);

                dynamicTableLayoutPanel.Controls.Add(btnHSChoVay, 0, 1);
                dynamicTableLayoutPanel.Controls.Add(btnTaiSanTheChap, 0, 2);
                dynamicTableLayoutPanel.Controls.Add(btnThongBao, 0, 3);
                dynamicTableLayoutPanel.Controls.Add(btnXacNhanHD, 0, 4);
                dynamicTableLayoutPanel.Controls.Add(btnXuLiYeuCauHD, 0, 5);
            
                Controls.Add(dynamicTableLayoutPanel);
            }
            else if(SessionState.NVDangNhap is DataModel.NhanVienXetDuyet)
            {
                Button btnXetDuyetChoVay = new Button();
                //btnXetDuyetChoVay.Location = new Point(3, 59);
                btnXetDuyetChoVay.Size = new Size(299, 44);
                btnXetDuyetChoVay.Text = "Xét Duyệt Cho Vay";
                btnXetDuyetChoVay.Click += BtnXetDuyetChoVay_Click;
                btnXetDuyetChoVay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                btnXetDuyetChoVay.TabIndex = 1;
                btnXetDuyetChoVay.Dock = System.Windows.Forms.DockStyle.Fill;
                Controls.Add(btnXetDuyetChoVay);

                dynamicTableLayoutPanel.Controls.Add(btnXetDuyetChoVay, 0, 1);
                Controls.Add(dynamicTableLayoutPanel);
            } 
            else if (SessionState.NVDangNhap is DataModel.NhanVienKeToan)
            {
                Button btnThuNoLai = new Button();
                //btnThuNoLai.Location = new Point(3, 59);
                btnThuNoLai.Size = new Size(299, 44);
                btnThuNoLai.Text = "Tạo Phiếu Thu Nợ Lãi";
                btnThuNoLai.Click += BtnThuNoLai_Click;
                btnThuNoLai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                btnThuNoLai.TabIndex = 1;
                btnThuNoLai.Dock = System.Windows.Forms.DockStyle.Fill;
                Controls.Add(btnThuNoLai);

                dynamicTableLayoutPanel.Controls.Add(btnThuNoLai, 0, 1);
                Controls.Add(dynamicTableLayoutPanel);
            } 
            else //if (SessionState.NVDangNhap is DataModel.NhanVienQuanLy)
            {
                Button btnHSPhatTien = new Button();
                //btnHSPhatTien.Location = new Point(3, 59);
                btnHSPhatTien.Size = new Size(299, 44);
                btnHSPhatTien.Text = "Tạo Hồ Sơ Phát Tiền Vay";
                btnHSPhatTien.Click += BtnHSPhatTien_Click;
                btnHSPhatTien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                btnHSPhatTien.TabIndex = 1;
                btnHSPhatTien.Dock = System.Windows.Forms.DockStyle.Fill;                
                Controls.Add(btnHSPhatTien);

                Button btnDonGHMG = new Button();
                //btnDonGHMG.Location = new Point(3, 115);
                btnDonGHMG.Size = new Size(299, 44);
                btnDonGHMG.Text = "Lập Đơn GHMG";
                btnDonGHMG.Click += BtnDonGHMG_Click;
                btnDonGHMG.TextAlign = ContentAlignment.MiddleCenter;
                btnDonGHMG.TabIndex = 2;
                btnDonGHMG.Dock = DockStyle.Fill;
                Controls.Add(btnDonGHMG);

                Button btnThanhLy = new Button();
                //btnThanhLy.Location = new Point(3, 171);
                btnThanhLy.Size = new Size(299, 44);
                btnThanhLy.Text = "Thanh Lý Hợp Đồng";
                btnThanhLy.Click += BtnThanhLy_Click;
                btnThanhLy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                btnThanhLy.TabIndex = 3;
                btnThanhLy.Dock = System.Windows.Forms.DockStyle.Fill;
                Controls.Add(btnThanhLy);

                Button btnDongVonBoSung = new Button();
                //btnDongVonBoSung.Location = new Point(3, 227);
                btnDongVonBoSung.Size = new Size(299, 44);
                btnDongVonBoSung.Text = "Dòng Vốn Bổ Sung";
                btnDongVonBoSung.Click += BtnDongVonBoSung_Click;
                btnDongVonBoSung.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                btnDongVonBoSung.TabIndex = 4;
                btnDongVonBoSung.Dock = System.Windows.Forms.DockStyle.Fill;
                Controls.Add(btnDongVonBoSung);

                Button btnChiTieuBoSung = new Button();
                //btnChiTieuBoSung.Location = new Point(3, 283);
                btnChiTieuBoSung.Size = new Size(299, 44);
                btnChiTieuBoSung.Text = "Chi Tiêu Bổ Sung";
                btnChiTieuBoSung.Click += BtnChiTieuBoSung_Click;
                btnChiTieuBoSung.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                btnChiTieuBoSung.TabIndex = 5;
                btnChiTieuBoSung.Dock = System.Windows.Forms.DockStyle.Fill;
                Controls.Add(btnChiTieuBoSung);

                Button btnHDQuaHan = new Button();
                //btnHDQuaHan.Location = new Point(3, 339);
                btnHDQuaHan.Size = new Size(299, 44);
                btnHDQuaHan.Text = "Hợp Đồng Qúa Hạn";
                btnHDQuaHan.Click += BtnHDQuaHan_Click;
                btnHDQuaHan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                btnHDQuaHan.TabIndex = 6;
                btnHDQuaHan.Dock = System.Windows.Forms.DockStyle.Fill;
                Controls.Add(btnHDQuaHan);

                Button btnQuyetToan = new Button();
                //btnQuyetToan.Location = new Point(3, 395);
                btnQuyetToan.Size = new Size(299, 44);
                btnQuyetToan.Text = "Lập Quyết Toán";
                btnQuyetToan.Click += BtnQuyetToan_Click;
                btnQuyetToan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                btnQuyetToan.TabIndex = 7;
                btnQuyetToan.Dock = System.Windows.Forms.DockStyle.Fill;
                Controls.Add(btnQuyetToan);

                Button btnBaoCaoDoiTuong = new Button();
                //btnBaoCaoDoiTuong.Location = new Point(3, 451);
                btnBaoCaoDoiTuong.Size = new Size(299, 44);
                btnBaoCaoDoiTuong.Text = "Báo Cáo Đối Tượng Vay";
                btnBaoCaoDoiTuong.Click += BtnBaoCaoDoiTuong_Click;
                btnBaoCaoDoiTuong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                btnBaoCaoDoiTuong.TabIndex = 8;
                btnBaoCaoDoiTuong.Dock = System.Windows.Forms.DockStyle.Fill;
                Controls.Add(btnBaoCaoDoiTuong);

                Button btnBaoCaoTaiChinh = new Button();
               // btnBaoCaoTaiChinh.Location = new Point(3, 507);
                //btnBaoCaoTaiChinh.Size = new Size(250, 44);
                btnBaoCaoTaiChinh.Text = "Báo Cáo Tài Chính";
                btnBaoCaoTaiChinh.Click += BtnBaoCaoTaiChinh_Click;
                btnBaoCaoTaiChinh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                btnBaoCaoTaiChinh.TabIndex = 9;
                btnBaoCaoTaiChinh.Dock = System.Windows.Forms.DockStyle.Fill;
                Controls.Add(btnBaoCaoTaiChinh);                
                
                dynamicTableLayoutPanel.Controls.Add(btnHSPhatTien, 0, 1);             
                dynamicTableLayoutPanel.Controls.Add(btnDonGHMG, 0, 2);
                dynamicTableLayoutPanel.Controls.Add(btnThanhLy, 0, 3);
                dynamicTableLayoutPanel.Controls.Add(btnDongVonBoSung, 0, 4);
                dynamicTableLayoutPanel.Controls.Add(btnChiTieuBoSung, 0, 5);
                dynamicTableLayoutPanel.Controls.Add(btnHDQuaHan, 0, 6);
                dynamicTableLayoutPanel.Controls.Add(btnQuyetToan, 0, 7);
                dynamicTableLayoutPanel.Controls.Add(btnBaoCaoDoiTuong, 0, 8);
                dynamicTableLayoutPanel.Controls.Add(btnBaoCaoTaiChinh, 0, 9);            

                Controls.Add(dynamicTableLayoutPanel);
            }
            tableLayoutPanel1.Controls.Add(dynamicTableLayoutPanel);
        }

        private void BtnBaoCaoTaiChinh_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnBaoCaoDoiTuong_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnQuyetToan_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnHDQuaHan_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnChiTieuBoSung_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnDongVonBoSung_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnThanhLy_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnDonGHMG_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnHSPhatTien_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnXetDuyetChoVay_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnXuLiYeuCauHD_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnXacNhanHD_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnThongBao_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnTaiSanTheChap_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnThuNoLai_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnDonMGGH_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnHSChoVay_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
