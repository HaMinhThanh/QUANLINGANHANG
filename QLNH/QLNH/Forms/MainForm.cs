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
        public LoginForm rootForm { get; set; }
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyNganHangDataSet.TrangThaiTaiSanCB' table. You can move, or remove it, as needed.
            this.trangThaiTaiSanCBTableAdapter.Fill(this.quanLyNganHangDataSet.TrangThaiTaiSanCB);
            // TODO: This line of code loads data into the 'quanLyNganHangDataSet.TrangThaiHopDongVayCB' table. You can move, or remove it, as needed.
            this.trangThaiHopDongVayCBTableAdapter.Fill(this.quanLyNganHangDataSet.TrangThaiHopDongVayCB);
            label1.Text = "Xin chào, " + SessionState.NVDangNhap.HoTen;
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

                Button btnThemKhachHang = new Button();
                //btnXacNhanHD.Location = new Point(3, 227);
                btnThemKhachHang.Size = new Size(299, 44);
                btnThemKhachHang.Text = "Thêm khách hàng";
                btnThemKhachHang.Click += BtnThemKhachHang_Click;
                btnThemKhachHang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                btnThemKhachHang.TabIndex = 3;
                btnThemKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
                Controls.Add(btnThemKhachHang);

                Button btnXacNhanHD = new Button();
                //btnXacNhanHD.Location = new Point(3, 227);
                btnXacNhanHD.Size = new Size(299, 44);
                btnXacNhanHD.Text = "Xác Nhận Hợp Đồng";
                btnXacNhanHD.Click += BtnXacNhanHD_Click;
                btnXacNhanHD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                btnXacNhanHD.TabIndex = 4;
                btnXacNhanHD.Dock = System.Windows.Forms.DockStyle.Fill;
                Controls.Add(btnXacNhanHD);

                Button btnDonGHMG = new Button();
                //btnDonGHMG.Location = new Point(3, 115);
                btnDonGHMG.Size = new Size(299, 44);
                btnDonGHMG.Text = "Lập Đơn GHMG";
                btnDonGHMG.Click += BtnDonGHMG_Click;
                btnDonGHMG.TextAlign = ContentAlignment.MiddleCenter;
                btnDonGHMG.TabIndex = 2;
                btnDonGHMG.Dock = DockStyle.Fill;
                Controls.Add(btnDonGHMG);

                Button btnBaoCaoDoiTuong = new Button();
                //btnBaoCaoDoiTuong.Location = new Point(3, 451);
                btnBaoCaoDoiTuong.Size = new Size(299, 44);
                btnBaoCaoDoiTuong.Text = "Báo Cáo Đối Tượng Vay";
                btnBaoCaoDoiTuong.Click += BtnBaoCaoDoiTuong_Click;
                btnBaoCaoDoiTuong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                btnBaoCaoDoiTuong.TabIndex = 8;
                btnBaoCaoDoiTuong.Dock = System.Windows.Forms.DockStyle.Fill;
                Controls.Add(btnBaoCaoDoiTuong);

                dynamicTableLayoutPanel.Controls.Add(btnHSChoVay, 0, 1);
                dynamicTableLayoutPanel.Controls.Add(btnTaiSanTheChap, 0, 2);
                dynamicTableLayoutPanel.Controls.Add(btnThemKhachHang, 0, 3);
                dynamicTableLayoutPanel.Controls.Add(btnXacNhanHD, 0, 4);
                dynamicTableLayoutPanel.Controls.Add(btnBaoCaoDoiTuong, 0, 5);
                dynamicTableLayoutPanel.Controls.Add(btnDonGHMG, 0, 6);


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

                Button btnXuLiYeuCauHD = new Button();
                //btnXuLiYeuCauHD.Location = new Point(3, 283);
                btnXuLiYeuCauHD.Size = new Size(299, 44);
                btnXuLiYeuCauHD.Text = "Xử lí yêu cầu hợp đồng";
                btnXuLiYeuCauHD.Click += BtnXuLiYeuCauHD_Click;
                btnXuLiYeuCauHD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                btnXuLiYeuCauHD.TabIndex = 5;
                btnXuLiYeuCauHD.Dock = System.Windows.Forms.DockStyle.Fill;
                Controls.Add(btnXuLiYeuCauHD);

                Button btnXuLiTaiSanTheChap = new Button();
                //btnXuLiYeuCauHD.Location = new Point(3, 283);
                btnXuLiTaiSanTheChap.Size = new Size(299, 44);
                btnXuLiTaiSanTheChap.Text = "Định giá tài sản thế chấp";
                btnXuLiTaiSanTheChap.Click += btnXuLiTaiSanTheChap_Click;
                btnXuLiTaiSanTheChap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                btnXuLiTaiSanTheChap.TabIndex = 5;
                btnXuLiTaiSanTheChap.Dock = System.Windows.Forms.DockStyle.Fill;
                Controls.Add(btnXuLiTaiSanTheChap);

                dynamicTableLayoutPanel.Controls.Add(btnXetDuyetChoVay, 0, 1);
                dynamicTableLayoutPanel.Controls.Add(btnXuLiYeuCauHD, 0, 2);
                dynamicTableLayoutPanel.Controls.Add(btnXuLiTaiSanTheChap, 0, 3);
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

                Button btnPhieuPhatTien = new Button();
                //btnThuNoLai.Location = new Point(3, 59);
                btnPhieuPhatTien.Size = new Size(299, 44);
                btnPhieuPhatTien.Text = "Tạo Phiếu Phát tiền";
                btnPhieuPhatTien.Click += BtnPhieuPhatTien_Click;
                btnPhieuPhatTien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                btnPhieuPhatTien.TabIndex = 1;
                btnPhieuPhatTien.Dock = System.Windows.Forms.DockStyle.Fill;
                Controls.Add(btnPhieuPhatTien);

                Button btnThongBao = new Button();
                //btnThongBao.Location = new Point(3, 171);
                btnThongBao.Size = new Size(299, 44);
                btnThongBao.Text = "Tạo Thông Báo";
                btnThongBao.Click += BtnThongBao_Click;
                btnThongBao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                btnThongBao.TabIndex = 3;
                btnThongBao.Dock = System.Windows.Forms.DockStyle.Fill;
                Controls.Add(btnThongBao);

                dynamicTableLayoutPanel.Controls.Add(btnThuNoLai, 0, 1);
                dynamicTableLayoutPanel.Controls.Add(btnThongBao, 0, 2);
                dynamicTableLayoutPanel.Controls.Add(btnPhieuPhatTien, 0, 3);
                Controls.Add(dynamicTableLayoutPanel);
            } 
            else //if (SessionState.NVDangNhap is DataModel.NhanVienQuanLy)
            {


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
                btnHDQuaHan.Text = "Hợp Đồng Quá Hạn";
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

                Button btnQuyDinh = new Button();
                //btnQuyDinh.Location = new Point(3, 395);
                btnQuyDinh.Size = new Size(299, 44);
                btnQuyDinh.Text = "Thay đổi quy định";
                btnQuyDinh.Click += btnQuyDinh_Click;
                btnQuyDinh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                btnQuyDinh.TabIndex = 7;
                btnQuyDinh.Dock = System.Windows.Forms.DockStyle.Fill;
                Controls.Add(btnQuyDinh);

                Button btnBaoCaoTaiChinh = new Button();
               // btnBaoCaoTaiChinh.Location = new Point(3, 507);
                //btnBaoCaoTaiChinh.Size = new Size(250, 44);
                btnBaoCaoTaiChinh.Text = "Báo Cáo Tài Chính";
                btnBaoCaoTaiChinh.Click += BtnBaoCaoTaiChinh_Click;
                btnBaoCaoTaiChinh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                btnBaoCaoTaiChinh.TabIndex = 9;
                btnBaoCaoTaiChinh.Dock = System.Windows.Forms.DockStyle.Fill;
                Controls.Add(btnBaoCaoTaiChinh);                
                
                dynamicTableLayoutPanel.Controls.Add(btnThanhLy, 0, 1);
                dynamicTableLayoutPanel.Controls.Add(btnHDQuaHan, 0, 2);
                dynamicTableLayoutPanel.Controls.Add(btnDongVonBoSung, 0, 3);
                dynamicTableLayoutPanel.Controls.Add(btnChiTieuBoSung, 0, 4);
                dynamicTableLayoutPanel.Controls.Add(btnQuyetToan, 0, 5);
                dynamicTableLayoutPanel.Controls.Add(btnBaoCaoTaiChinh, 0, 6);
                dynamicTableLayoutPanel.Controls.Add(btnQuyDinh, 0, 7);

                Controls.Add(dynamicTableLayoutPanel);
            }
            tableLayoutPanel1.Controls.Add(dynamicTableLayoutPanel);
        }

        private void btnQuyDinh_Click(object sender, EventArgs e)
        {
            QuyDinhForm newForm = new QuyDinhForm();
            newForm.Show();
        }

        private void btnXuLiTaiSanTheChap_Click(object sender, EventArgs e)
        {
            DinhGiaTaiSanTheChapForm newForm = new DinhGiaTaiSanTheChapForm();
            newForm.Show();
        }

        private void BtnPhieuPhatTien_Click(object sender, EventArgs e)
        {
            HSPhatTienVayForm newForm = new HSPhatTienVayForm();
            newForm.Show();
        }

        private void BtnThemKhachHang_Click(object sender, EventArgs e)
        {
            KhachHang newForm = new KhachHang();
            newForm.Show();
        }

        private void BtnBaoCaoTaiChinh_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            BaoCaoTaiChinhForm newForm = new BaoCaoTaiChinhForm();
            newForm.Show();
        }

        private void BtnBaoCaoDoiTuong_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            BaoCaoTaiChinhDoiTuongVay newForm = new BaoCaoTaiChinhDoiTuongVay();
            newForm.Show();
        }

        private void BtnQuyetToan_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            QuyetToanForm newForm = new QuyetToanForm();
            newForm.Show();
        }

        private void BtnHDQuaHan_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            
            KiemTraHopDongQuaHan newForm = new KiemTraHopDongQuaHan();
            newForm.Show();
        }

        private void BtnChiTieuBoSung_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            ChiTieuBoSungForm newForm = new ChiTieuBoSungForm();
            newForm.Show();
        }

        private void BtnDongVonBoSung_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            DongVonBoSungForm newForm = new DongVonBoSungForm();
            newForm.Show();
        }

        private void BtnThanhLy_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            KiemTraHopDongThanhLy newForm = new KiemTraHopDongThanhLy();
            newForm.Show();
        }

        private void BtnDonGHMG_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            DonMGGHForm newForm = new DonMGGHForm();
            newForm.Show();
        }

        private void BtnHSPhatTien_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            HSPhatTienVayForm newForm = new HSPhatTienVayForm();
            newForm.Show();
        }

        private void BtnXetDuyetChoVay_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            XetDuyetChoVayForm newForm = new XetDuyetChoVayForm();
            newForm.Show();
        }

        private void BtnXuLiYeuCauHD_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            XetDuyetYeuCauChinhSuaForm newForm = new XetDuyetYeuCauChinhSuaForm();
            newForm.Show();
        }

        private void BtnXacNhanHD_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            XacNhanHopDongForm newForm = new XacNhanHopDongForm();
            newForm.Show();
        }

        private void BtnThongBao_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            ThongBaoForm newForm = new ThongBaoForm();
            newForm.Show();
        }

        private void BtnTaiSanTheChap_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            TaiSanTheChapForm newForm = new TaiSanTheChapForm();
            newForm.Show();
        }

        private void BtnThuNoLai_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            PhieuThuNoLaiForm newForm = new PhieuThuNoLaiForm();
            newForm.Show();
        }

        private void BtnDonMGGH_Click(object sender, EventArgs e)
        {
            DonMGGHForm newForm = new DonMGGHForm();
            newForm.Show();
        }

        private void BtnHSChoVay_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            HSChoVayForm newForm = new HSChoVayForm();
            newForm.Show();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            rootForm.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //MaKhachHang, HoTenKhachHang, DinhDanh, LoaiKhachHang
            string filter = "";

            if (!textBox1.Text.Equals(""))
                filter += String.Format("MaKH = '{0}' AND ", textBox1.Text);
            if (!textBox3.Text.Equals(""))
                filter += String.Format("HoTen LIKE '*{0}*' AND ", textBox3.Text);
            if (comboBox13.SelectedItem != null && comboBox13.SelectedIndex != 0 && !textBox2.Text.Equals(""))
                filter += String.Format("LoaiDinhDanh = {0} AND GiaTri LIKE '*{1}' AND ", comboBox13.SelectedIndex, textBox2.Text);
            if (comboBox10.SelectedItem != null && comboBox10.SelectedIndex != 0)
            {
                if (comboBox10.SelectedIndex == 1)
                    filter += String.Format("MaDoanhNghiepDaiDien IS NULL AND ");
                else if (comboBox10.SelectedIndex == 2)
                    filter += String.Format("MaDoanhNghiepDaiDien IS NOT NULL AND ");
            }
            if (!filter.Equals(""))
                filter = filter.Substring(0, filter.LastIndexOf("AND") - 1);
            else
            {
                MessageBox.Show("Xin hãy chọn 1 tiêu chuẩn tra cứu", "Thông báo");
                return;
            }
            ((BindingSource)dataGridView2.DataSource).Filter = filter;
            this.khachHangTableAdapter.Fill(this.quanLyNganHangDataSet.KhachHang);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string filter = "";

            if (!textBox9.Text.Equals(""))
                filter += String.Format("MaTaiSan = '{0}' AND ", textBox9.Text);
            if (!textBox11.Text.Equals(""))
                filter += String.Format("MoTa LIKE '*{0}*' AND ", textBox11.Text);
            if (numericUpDown2.Value > 0)
                filter += String.Format("DinhGia >= {0} AND ", numericUpDown2.Value);
            if (comboBox12.SelectedItem != null)
                filter += String.Format("MaTrangThai = '{0}' AND ", comboBox12.SelectedValue);

            if (!filter.Equals(""))
                filter = filter.Substring(0, filter.LastIndexOf("AND") - 1);
            else
            {
                MessageBox.Show("Xin hãy chọn 1 tiêu chuẩn tra cứu", "Thông báo");
                return;
            }
            ((BindingSource)dataGridView4.DataSource).Filter = filter;
            this.taiSanTheChapExtTableAdapter.Fill(this.quanLyNganHangDataSet.TaiSanTheChapExt);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string filter = "";

            if (!textBox5.Text.Equals(""))
                filter += String.Format("MaHopDong = '{0}' AND ", textBox5.Text);
            if (numericUpDown1.Value > 0)
                filter += String.Format("GiaTriHienTai >= {0} AND ", numericUpDown1.Value);
            if (comboBox11.SelectedItem != null)
                filter += String.Format("MaTrangThai = '{0}' AND ", comboBox11.SelectedValue);
            if (!textBox6.Text.Equals(""))
                filter += String.Format("HoTen LIKE '*{0}*' AND ", textBox6.Text);
            if (dateTimePicker4.Value <= DateTime.Now)
                filter += String.Format("NgayThietLap >= #{0}# AND ", dateTimePicker4.Value.ToString("MM/dd/yyyy"));

            if (!filter.Equals(""))
                filter = filter.Substring(0, filter.LastIndexOf("AND") - 1);
            else
            {
                MessageBox.Show("Xin hãy chọn 1 tiêu chuẩn tra cứu", "Thông báo");
                return;
            }
            ((BindingSource)dataGridView3.DataSource).Filter = filter;
            this.hopDongVayExtTableAdapter.Fill(this.quanLyNganHangDataSet.HopDongVayExt);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //(InRange) ThoiDiemThucHien
            string startDate = dateTimePicker2.Value.ToString("MM/dd/yyyy");
            string endDate = dateTimePicker3.Value.ToString("MM/dd/yyyy");
            ((BindingSource)dataGridView5.DataSource).Filter = String.Format("ThoiDiemThucHien >= #{0}# AND ThoiDiemThucHien <= #{1}#", startDate, endDate);
            this.hoatDongTableAdapter.Fill(this.quanLyNganHangDataSet.HoatDong);
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
