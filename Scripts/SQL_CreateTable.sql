﻿--DROP DATABASE PTTK_ABC;

CREATE DATABASE PTTK_ABC;
GO

USE PTTK_ABC;
GO

CREATE TABLE THANHVIEN (
  IDThanhVien INT IDENTITY(1,1) NOT NULL,
  TenDangNhap VARCHAR(30) UNIQUE,
  Ten NVARCHAR(50),
  Email VARCHAR(50),
  MatKhau VARCHAR(30) NOT NULL,
  LoaiThanhVien VARCHAR(20) CHECK (LoaiThanhVien IN ('DOANHNGHIEP', 'UNGVIEN', 'NHANVIEN')),
  PRIMARY KEY (IDThanhVien)
);

CREATE TABLE DOANHNGHIEP (
  IDDoanhNghiep INT PRIMARY KEY,
  MaSoThue CHAR(10),
  NguoiDaiDien NVARCHAR(50),
  DiaChi NVARCHAR(100),
  UuDai FLOAT
);

CREATE TABLE UNGVIEN (
  IDUngVien INT PRIMARY KEY,
  NgaySinh DATE
);

CREATE TABLE NHANVIEN (
  IDNhanVien INT PRIMARY KEY,
  VaiTro NVARCHAR(50) CHECK (VaiTro IN (N'Ban lãnh đạo', N'Nhân viên cơ bản'))
);

CREATE TABLE THANHTOAN (
  IDThanhToan INT IDENTITY(1,1) NOT NULL,
  NgayGiaoDich DATE,
  HinhThucTT NVARCHAR(10) CHECK (HinhThucTT IN(N'Thẻ', N'Trực tiếp')),
  SoTienCanThanhToan FLOAT,
  Dot INT,
  IDHoaDon INT,
  IDNhanVien INT,
  PRIMARY KEY (IDThanhToan)
);

CREATE TABLE HOADON (
  IDHoaDon INT IDENTITY(1,1) NOT NULL,
  TongTien FLOAT,
  DaTra FLOAT,
  LoaiHinhThanhToan NVARCHAR(50) CHECK (LoaiHinhThanhToan IN(N'Toàn bộ', N'Theo đợt')),
  NgayLap DATE,
  TrangThaiHoanThanh NVARCHAR(50) CHECK (TrangThaiHoanThanh IN(N'Chưa hoàn thành', N'Đã hoàn thành')),
  IDPhieuDangTuyen INT,
  PRIMARY KEY (IDHoaDon)
);

CREATE TABLE BANGCAP (
  IDBang INT IDENTITY(1,1) NOT NULL,
  TenBang NVARCHAR(100),
  CapBac VARCHAR(50),
  NgayCap DATE,
  DonViCap NVARCHAR(100),
  IDUngVien INT,
  PRIMARY KEY (IDBang)
);

CREATE TABLE HOSOUNGTUYEN (
  IDDoanhNghiep INT,
  IDUngVien INT,
  NgayUngTuyen DATE,
  TinhTrangUngTuyen NVARCHAR(50) CHECK (TinhTrangUngTuyen IN (N'Chưa đủ điều kiện', N'Đang xử lý', N'Đủ điều kiện') or TinhTrangUngTuyen is NULL),
  ViTriUngTuyen NVARCHAR(50),
  DiemDanhGia INT CHECK (DiemDanhGia IN(1,2,3,4,5,6,7,8,9,10))
);

CREATE TABLE PHIEUDANGTUYEN (
  IDPhieuDangTuyen INT IDENTITY(1,1) NOT NULL, 
  ViTriDangTuyen NVARCHAR(50),
  SoLuongTuyenDung INT,
  IDDoanhNghiep INT,
  IDPhieuQuangCao INT,
  PRIMARY KEY (IDPhieuDangTuyen)
);

CREATE TABLE YEUCAUCV (
  IDYeuCau INT IDENTITY(1,1) NOT NULL, 
  IDPhieuDangTuyen INT,
  MoTa NVARCHAR(1000),
  PRIMARY KEY (IDYeuCau, IDPhieuDangTuyen)
);

CREATE TABLE PHIEUQUANGCAO (
  IDPhieuQuangCao INT IDENTITY(1,1) NOT NULL, 
  NgayBatDau DATE,
  NgayKetThuc DATE,
  HinhThucDangTuyen NVARCHAR(50) check (HinhThucDangTuyen IN(N'Báo giấy', N'Banner quảng cáo', N'Trang mạng')),
  TongTienQuangCao FLOAT,
  PRIMARY KEY (IDPhieuQuangCao)
);

ALTER TABLE UNGVIEN ADD 
  CONSTRAINT FK_UNGVIEN_THANHVIEN FOREIGN KEY (IDUngVien) REFERENCES THANHVIEN(IDThanhVien);

ALTER TABLE NHANVIEN ADD 
  CONSTRAINT FK_NHANVIEN_THANHVIEN FOREIGN KEY (IDNhanVien) REFERENCES THANHVIEN(IDThanhVien);

ALTER TABLE DOANHNGHIEP ADD 
  CONSTRAINT FK_DOANHNGHIEP_THANHVIEN FOREIGN KEY (IDDoanhNghiep) REFERENCES THANHVIEN(IDThanhVien);

ALTER TABLE THANHTOAN ADD 
  CONSTRAINT FK_THANHTOAN_HOADON FOREIGN KEY (IDHoaDon) REFERENCES HOADON(IDHoaDon),
  CONSTRAINT FK_THANHTOAN_NHANVIEN FOREIGN KEY (IDNhanVien) REFERENCES NHANVIEN(IDNhanVien);

ALTER TABLE HOADON ADD 
  CONSTRAINT FK_HOADON_PHIEUDANGTUYEN FOREIGN KEY (IDPhieuDangTuyen) REFERENCES PHIEUDANGTUYEN(IDPhieuDangTuyen);

ALTER TABLE BANGCAP ADD 
  CONSTRAINT FK_BANGCAP_UNGVIEN FOREIGN KEY (IDUngVien) REFERENCES UNGVIEN(IDUngVien);

ALTER TABLE HOSOUNGTUYEN ADD 
  CONSTRAINT FK_HOSOUNGTUYEN_DOANHNGHIEP FOREIGN KEY (IDDoanhNghiep) REFERENCES DOANHNGHIEP(IDDoanhNghiep),
  CONSTRAINT FK_HOSOUNGTUYEN_UNGVIEN FOREIGN KEY (IDUngVien) REFERENCES UNGVIEN(IDUngVien);

ALTER TABLE PHIEUDANGTUYEN ADD 
  CONSTRAINT FK_PHIEUDANGTUYEN_DOANHNGHIEP FOREIGN KEY (IDDoanhNghiep) REFERENCES DOANHNGHIEP(IDDoanhNghiep),
  CONSTRAINT FK_PHIEUDANGTUYEN_PHIEUQUANGCAO FOREIGN KEY (IDPhieuQuangCao) REFERENCES PHIEUQUANGCAO(IDPhieuQuangCao);

ALTER TABLE YEUCAUCV ADD 
  CONSTRAINT FK_YEUCAUCV_PHIEUDANGTUYEN FOREIGN KEY (IDPhieuDangTuyen) REFERENCES PHIEUDANGTUYEN(IDPhieuDangTuyen);