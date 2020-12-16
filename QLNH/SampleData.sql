﻿DELETE FROM tbHoatDong
DELETE FROM tbHopDongVay
DELETE FROM tbGiayToChungThuc
DELETE FROM tbTaiSanTheChap
DELETE FROM tbDieuKhoanHopDong
DELETE FROM tbYeuCauChoVay
DELETE FROM tbKQXetDuyet
DELETE FROM tbDieuKhoan
DELETE FROM tbLoaiYeuCauChinhSua
DELETE FROM tbThamSo
DELETE FROM tbTrangThaiHopDongVay
DELETE FROM tbTrangThaiTaiSan
DELETE FROM tbKhachHang
DELETE FROM tbNhanVien
DELETE FROM tbDinhDanh 
DELETE FROM tbChiTietDoanhNghiep
DELETE FROM tbThamSoKyHanLaiSuat


INSERT INTO tbThamSo VALUES('1-1-2020', 2000000000, 10000000000, 1, 18, 1, 360, 1000000, 0.0, 100.0, 7);

INSERT INTO tbThamSoKyHanLaiSuat VALUES(1, 5.0);
INSERT INTO tbThamSoKyHanLaiSuat VALUES(2, 5.0);
INSERT INTO tbThamSoKyHanLaiSuat VALUES(3, 5.0);
INSERT INTO tbThamSoKyHanLaiSuat VALUES(4, 4.0);
INSERT INTO tbThamSoKyHanLaiSuat VALUES(5, 4.0);
INSERT INTO tbThamSoKyHanLaiSuat VALUES(6, 3.2);
INSERT INTO tbThamSoKyHanLaiSuat VALUES(8, 3.2);
INSERT INTO tbThamSoKyHanLaiSuat VALUES(10, 3.0);
INSERT INTO tbThamSoKyHanLaiSuat VALUES(12, 2.7);
INSERT INTO tbThamSoKyHanLaiSuat VALUES(16, 2.7);
INSERT INTO tbThamSoKyHanLaiSuat VALUES(20, 2.7);
INSERT INTO tbThamSoKyHanLaiSuat VALUES(24, 2.3);
INSERT INTO tbThamSoKyHanLaiSuat VALUES(30, 2.3);
INSERT INTO tbThamSoKyHanLaiSuat VALUES(36, 2.0);
INSERT INTO tbThamSoKyHanLaiSuat VALUES(48, 1.7);
INSERT INTO tbThamSoKyHanLaiSuat VALUES(60, 1.5);
INSERT INTO tbThamSoKyHanLaiSuat VALUES(72, 1.2);
INSERT INTO tbThamSoKyHanLaiSuat VALUES(96, 1.0);
INSERT INTO tbThamSoKyHanLaiSuat VALUES(120, 0.8);

INSERT INTO tbDinhDanh VALUES ('00000000-0000-0000-0000-000000000001', 1, '123456789')
INSERT INTO tbDinhDanh VALUES ('00000000-0000-0000-0000-000000000002', 2, '20037262873')
INSERT INTO tbDinhDanh VALUES ('00000000-0000-0000-0000-000000000003', 2, '10023456789')
INSERT INTO tbDinhDanh VALUES ('00000000-0000-0000-0000-000000000004', 1, '123456749')
INSERT INTO tbDinhDanh VALUES ('00000000-0000-0000-0000-000000000005', 2, '10023456779')
INSERT INTO tbDinhDanh VALUES ('00000000-0000-0000-0000-000000000006', 1, '123456749')
INSERT INTO tbDinhDanh VALUES ('00000000-0000-0000-0000-000000000007', 1, '123449832')
INSERT INTO tbDinhDanh VALUES ('00000000-0000-0000-0000-000000000008', 1, '192343284')
INSERT INTO tbDinhDanh VALUES ('00000000-0000-0000-0000-000000000009', 1, '193983284')
INSERT INTO tbDinhDanh VALUES ('00000000-0000-0000-0000-000000000010', 1, '192348473')
INSERT INTO tbDinhDanh VALUES ('00000000-0000-0000-0000-000000000011', 2, '10002984743')
INSERT INTO tbDinhDanh VALUES ('00000000-0000-0000-0000-000000000012', 2, '10023284743')
INSERT INTO tbDinhDanh VALUES ('00000000-0000-0000-0000-000000000013', 2, '10102881733')
INSERT INTO tbDinhDanh VALUES ('00000000-0000-0000-0000-000000000014', 2, '12203923271')

INSERT INTO tbChiTietDoanhNghiep VALUES('00000000-0000-0000-0000-000000000001', '0315692516', N'CÔNG TY TNHH THƯƠNG MẠI VÀ VẬN TẢI TÂN NGỌC MINH VIỆT NAM', N'Sản xuất sản phẩm từ gỗ', N'Đại diện doanh nghiệp')

INSERT INTO tbNhanVien VALUES ('00000000-0000-0000-0000-000000000002', N'Nguyễn Ngọc Đăng', 'employee1', '123456', '01-24-2000', '0123456789', N'KTX Khu B', '11-20-2020', '00000000-0000-0000-0000-000000000001', 1)
INSERT INTO tbNhanVien VALUES ('00000000-0000-0000-0000-000000000003', N'Hà Minh Thành', 'employee2', '123457', '02-20-2000', '0123456788', N'KTX Khu B', '10-20-2020', '00000000-0000-0000-0000-000000000003', 2)
INSERT INTO tbNhanVien VALUES ('00000000-0000-0000-0000-000000000004', N'Hà Minh Hiệu', 'employee3', '123456', '01-24-2000', '0123456789', N'KTX Khu B', '11-20-2020', '00000000-0000-0000-0000-000000000004', 3)
INSERT INTO tbNhanVien VALUES ('00000000-0000-0000-0000-000000000005', N'Nguyễn Văn Tiến', 'employee4', 'admin', '02-20-2000', '0123456788', N'KTX Khu B', '10-20-2020', '00000000-0000-0000-0000-000000000005', 4)

INSERT INTO tbKhachHang VALUES ('00000000-0000-0000-0000-000000000002', N'Nguyễn Văn An', '01-20-2000', '03482124433', N'Quảng Bình', '00000000-0000-0000-0000-000000000002', NULL, 'M')
INSERT INTO tbKhachHang VALUES ('00000000-0000-0000-0000-000000000003', N'Trần Phi B', '07-20-1998', '02987294442', N'Hà Nam', '00000000-0000-0000-0000-000000000006', NULL, 'M')
INSERT INTO tbKhachHang VALUES ('00000000-0000-0000-0000-000000000004', N'Nguyễn Thị C', '02-24-2001', '03438746333', N'Quảng Trị', '00000000-0000-0000-0000-000000000007', NULL, 'F')
INSERT INTO tbKhachHang VALUES ('00000000-0000-0000-0000-000000000005', N'Trần Thu Thủy', '09-22-1992', '03438746333', N'Lai Châu', '00000000-0000-0000-0000-000000000010', NULL, 'F')
INSERT INTO tbKhachHang VALUES ('00000000-0000-0000-0000-000000000006', N'Hoàng Phúc', '12-31-1995', '03438746333', N'Quảng Ninh', '00000000-0000-0000-0000-000000000011', NULL, 'M')
INSERT INTO tbKhachHang VALUES ('00000000-0000-0000-0000-000000000007', N'Ngô Thị Châu', '07-25-1991', '03438746333', N'Hà Nội', '00000000-0000-0000-0000-000000000012', NULL, 'F')
INSERT INTO tbKhachHang VALUES ('00000000-0000-0000-0000-000000000008', N'Hoàng Văn D', '12-07-1977', '03482124323', N'Hà Nội', '00000000-0000-0000-0000-000000000008', NULL, 'F')
INSERT INTO tbKhachHang VALUES ('00000000-0000-0000-0000-000000000009', N'Ngô Xuân E', '11-06-1980', '09632342111', N'TP HCM', '00000000-0000-0000-0000-000000000009', '00000000-0000-0000-0000-000000000001', 'M')

INSERT INTO tbTrangThaiTaiSan VALUES('00000000-0000-0000-0000-000000000001', N'Nguyên vẹn', 10);
INSERT INTO tbTrangThaiTaiSan VALUES('00000000-0000-0000-0000-000000000002', N'Có hư hỏng nhẹ', 8);
INSERT INTO tbTrangThaiTaiSan VALUES('00000000-0000-0000-0000-000000000003', N'Có hư hỏng trung bình', 5);
INSERT INTO tbTrangThaiTaiSan VALUES('00000000-0000-0000-0000-000000000004', N'Có hư hỏng nặng', 3);
INSERT INTO tbTrangThaiTaiSan VALUES('00000000-0000-0000-0000-000000000005', N'Không còn giá trị sử dụng', 0);
INSERT INTO tbTrangThaiTaiSan VALUES('00000000-0000-0000-0000-000000000006', N'Đã thu hồi', -1);
INSERT INTO tbTrangThaiTaiSan VALUES('00000000-0000-0000-0000-000000000007', N'Đã giải phóng', -2);

INSERT INTO tbTrangThaiHopDongVay VALUES('00000000-0000-0000-0000-000000000001', N'Đang hoạt động', 1);
INSERT INTO tbTrangThaiHopDongVay VALUES('00000000-0000-0000-0000-000000000002', N'Rủi ro cao', 2);
INSERT INTO tbTrangThaiHopDongVay VALUES('00000000-0000-0000-0000-000000000003', N'Đã quá hạn', 3);
INSERT INTO tbTrangThaiHopDongVay VALUES('00000000-0000-0000-0000-000000000004', N'Đã thanh lý', 0);

INSERT INTO tbLoaiYeuCauChinhSua VALUES('00000000-0000-0000-0000-000000000001', N'Gia hạn')
INSERT INTO tbLoaiYeuCauChinhSua VALUES('00000000-0000-0000-0000-000000000002', N'Miễn giảm lãi suất')

INSERT INTO tbDieuKhoan VALUES('00000000-0000-0000-0000-000000000001', N'Khế ước nhận nợ này là một bộ phận không tách rời của Hợp đồng cho vay. Những nội dung không đề cập trong Khế ước nhận nợ này sẽ được thực hiện theo Hợp đồng cho vay và các văn bản khác ký kết giữa các Bên.')
INSERT INTO tbDieuKhoan VALUES('00000000-0000-0000-0000-000000000002', N'Khế ước nhận nợ này có hiệu lực kể từ ngày ký. Các Bên xác nhận rằng việc giao kết Khế ước nhận nợ này là hoàn toàn tự nguyện, không giả tạo, không bị ép buộc, lừa dối, đe dọa, nhầm lẫn; ')

INSERT INTO tbKQXetDuyet VALUES('00000000-0000-0000-0000-000000000001', '00000000-0000-0000-0000-000000000004', 1, N'Chấp nhận')
INSERT INTO tbKQXetDuyet VALUES('00000000-0000-0000-0000-000000000002', '00000000-0000-0000-0000-000000000004', 2, N'Rủi ro quá cao')
INSERT INTO tbKQXetDuyet VALUES('00000000-0000-0000-0000-000000000003', '00000000-0000-0000-0000-000000000004', 1, N'Chấp nhận')

INSERT INTO tbYeuCauChoVay VALUES('00000000-0000-0000-0000-000000000001', '00000000-0000-0000-0000-000000000003', '00000000-0000-0000-0000-000000000002', 120000000, 3.0, 10, '00000000-0000-0000-0000-000000000001' , '11-20-2020')
INSERT INTO tbYeuCauChoVay VALUES('00000000-0000-0000-0000-000000000002', '00000000-0000-0000-0000-000000000002', '00000000-0000-0000-0000-000000000002', 1400000000, 2.0, 36, '00000000-0000-0000-0000-000000000002', '11-24-2020')
INSERT INTO tbYeuCauChoVay VALUES('00000000-0000-0000-0000-000000000003', '00000000-0000-0000-0000-000000000005', '00000000-0000-0000-0000-000000000002', 85000000, 3.2, 6, '00000000-0000-0000-0000-000000000003', '11-28-2020')
INSERT INTO tbYeuCauChoVay VALUES('00000000-0000-0000-0000-000000000004', '00000000-0000-0000-0000-000000000007', '00000000-0000-0000-0000-000000000002', 14000000, 3.2, 6, NULL, '11-30-2020')
INSERT INTO tbYeuCauChoVay VALUES('00000000-0000-0000-0000-000000000005', '00000000-0000-0000-0000-000000000008', '00000000-0000-0000-0000-000000000002', 720000000, 2.3, 24, NULL, '12-12-2020')

INSERT INTO tbDieuKhoanHopDong VALUES('00000000-0000-0000-0000-000000000001', '00000000-0000-0000-0000-000000000001')
INSERT INTO tbDieuKhoanHopDong VALUES('00000000-0000-0000-0000-000000000001', '00000000-0000-0000-0000-000000000002')
INSERT INTO tbDieuKhoanHopDong VALUES('00000000-0000-0000-0000-000000000003', '00000000-0000-0000-0000-000000000001')
INSERT INTO tbDieuKhoanHopDong VALUES('00000000-0000-0000-0000-000000000003', '00000000-0000-0000-0000-000000000002')

INSERT INTO tbTaiSanTheChap VALUES('00000000-0000-0000-0000-000000000001', '00000000-0000-0000-0000-000000000001', N'Xe hơi hiệu Honda Civic', 120000000, '00000000-0000-0000-0000-000000000001')
INSERT INTO tbTaiSanTheChap VALUES('00000000-0000-0000-0000-000000000002', '00000000-0000-0000-0000-000000000002', N'Nhà mặt tiền', 800000000, '00000000-0000-0000-0000-000000000001')
INSERT INTO tbTaiSanTheChap VALUES('00000000-0000-0000-0000-000000000003', '00000000-0000-0000-0000-000000000002', N'300m2 đất tại trung tâm thành phố', 600000000, '00000000-0000-0000-0000-000000000001')
INSERT INTO tbTaiSanTheChap VALUES('00000000-0000-0000-0000-000000000004', '00000000-0000-0000-0000-000000000003', N'Xe máy SH', 80000000, '00000000-0000-0000-0000-000000000001')
INSERT INTO tbTaiSanTheChap VALUES('00000000-0000-0000-0000-000000000005', '00000000-0000-0000-0000-000000000004', N'Laptop hiệu MSI', 14000000, '00000000-0000-0000-0000-000000000002')
INSERT INTO tbTaiSanTheChap VALUES('00000000-0000-0000-0000-000000000006', '00000000-0000-0000-0000-000000000005', N'Căn hộ tại quận 1', 600000000, '00000000-0000-0000-0000-000000000001')
INSERT INTO tbTaiSanTheChap VALUES('00000000-0000-0000-0000-000000000007', '00000000-0000-0000-0000-000000000005', N'Xe hơi hiệu Nexus', 120000000, '00000000-0000-0000-0000-000000000001')

INSERT INTO tbGiayToChungThuc VALUES('298724-8794982-791237', '00000000-0000-0000-0000-000000000001')
INSERT INTO tbGiayToChungThuc VALUES('289732-8798272-793444', '00000000-0000-0000-0000-000000000001')
INSERT INTO tbGiayToChungThuc VALUES('289732-3984724-974632', '00000000-0000-0000-0000-000000000002')
INSERT INTO tbGiayToChungThuc VALUES('289732-1023844-298313', '00000000-0000-0000-0000-000000000002')
INSERT INTO tbGiayToChungThuc VALUES('289732-4324234-793444', '00000000-0000-0000-0000-000000000003')
INSERT INTO tbGiayToChungThuc VALUES('289732-8798272-699994', '00000000-0000-0000-0000-000000000003')
INSERT INTO tbGiayToChungThuc VALUES('289732-2432722-744312', '00000000-0000-0000-0000-000000000004')
INSERT INTO tbGiayToChungThuc VALUES('289732-8743332-893221', '00000000-0000-0000-0000-000000000005')
INSERT INTO tbGiayToChungThuc VALUES('289732-8798272-793244', '00000000-0000-0000-0000-000000000006')
INSERT INTO tbGiayToChungThuc VALUES('289732-8354362-493474', '00000000-0000-0000-0000-000000000006')
INSERT INTO tbGiayToChungThuc VALUES('289732-4654732-393464', '00000000-0000-0000-0000-000000000007')
INSERT INTO tbGiayToChungThuc VALUES('289732-3435364-593447', '00000000-0000-0000-0000-000000000007')

INSERT INTO tbHopDongVay VALUES ('00000000-0000-0000-0000-000000000001', '00000000-0000-0000-0000-000000000001', '00000000-0000-0000-0000-000000000002', '12-14-2020', 120000000, '00000000-0000-0000-0000-000000000001', '12-15-2020')
INSERT INTO tbHopDongVay VALUES ('00000000-0000-0000-0000-000000000002', '00000000-0000-0000-0000-000000000003', '00000000-0000-0000-0000-000000000002', '12-15-2020', 85000000, '00000000-0000-0000-0000-000000000001', '12-15-2020')

INSERT INTO tbHoatDong VALUES('00000000-0000-0000-0000-000000000001', '00000000-0000-0000-0000-000000000002', '2020-12-14 13:23:44', N'Thiết lập hợp đồng 00000000-0000-0000-0000-000000000001' )
INSERT INTO tbHoatDong VALUES('00000000-0000-0000-0000-000000000002', '00000000-0000-0000-0000-000000000002', '2020-12-15 18:23:44', N'Thiết lập hợp đồng 00000000-0000-0000-0000-000000000002' )