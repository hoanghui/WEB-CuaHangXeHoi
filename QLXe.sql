﻿CREATE DATABASE QLXeHoi
GO
USE QLXeHoi
GO

--Tạo Bảng 
CREATE TABLE QuanLy
(
	MaQuanLy INT IDENTITY(0,1) PRIMARY KEY,
	TenQuanLy VARCHAR(100) NOT NULL,
	PassQuanLy VARCHAR(100) NOT NULL
)
GO

CREATE TABLE LoaiXe
(
	MaLoaiXe INT IDENTITY(0,1) PRIMARY KEY,
	TenLoaiXe NVARCHAR(100) NOT NULL,
	TrangThai BIT
)
GO

CREATE TABLE KhachHang
(
	MaKhachHang INT IDENTITY(0,1) PRIMARY KEY,
	HoTenKhachHang NVARCHAR(100) NOT NULL,
	NgaySinh DATETIME,
	DiaChi NVARCHAR(200),
	TrangThai BIT
)
GO

CREATE TABLE Xe
(
	MaXe INT IDENTITY(0,1) PRIMARY KEY,
	TenXe NVARCHAR(100) NOT NULL,
	NamSanXuat INT,
	Gia FLOAT,
	MaLoaiXe INT,
	TrangThai BIT,
	FOREIGN KEY (MaLoaiXe) REFERENCES Loaixe(MaLoaiXe)
)
GO

CREATE TABLE HoaDon
(
	MaHoaDon INT IDENTITY(0,1) PRIMARY KEY,
	NgayLapHoaDon DATETIME NOT NULL,
	ThanhToan FLOAT,
	MaKhachHang INT,
	TrangThai BIT
	FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang)
)
GO

CREATE TABLE ChiTietHoaDon
(
	MaHoaDon INT,
	MaXe INT,
	PRIMARY KEY (MaHoaDon, MaXe),
	FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon),
	FOREIGN KEY (MaXe) REFERENCES xe(MaXe)
)
GO

INSERT INTO QuanLy 
VALUES 
('admin','1')
GO

INSERT INTO LoaiXe 
VALUES 
(N'Mini hay Hatchback',1),
(N'Sedan, xe du lịch 4 chỗ',1),
(N'Coupe hay Sport Car',1),
(N'SUV 5 chỗ hay Crossover',1),
(N'MPV hay Minivan',1),
(N'Pickup hay xe bán tải',1),
(N'SUV 7 chỗ',1)
GO

INSERT INTO KhachHang 
VALUES 
(N'Steven King','06/17/1987',N'AD_PRES','1'),
(N'Neena Kochhar','09/21/1989',N'AD_VP','1'),
(N'Lex De Haan','01/13/1993',N'AD_VP','1'),
(N'Alexander Hunold','01/03/1990',N'IT_PROG','1'),
(N'Bruce Ernst','05/21/1991',N'IT_PROG','1')
GO

INSERT INTO Xe 
VALUES 
(N'HYUNDAI I10','2000',330000000,0,1),
(N'KIA MORNING','2000',299000000,1,1),
(N'VINFAST FADIL','2000',414000000,2,1),
(N'SUZUKI CELERIO','2000',329000000,3,1),
(N'TOYOTA VIOS','2000',470000000,4,1),
(N'SUZUKI ERTIGA','2000',499000000,5,1),
(N'KIA SOLUTO','2000',399000000,6,1)
GO

INSERT INTO HoaDon 
VALUES 
('05/10/2016','399000000',4,1),
('04/24/2018','414000000',3,1),
('06/24/2018','499000000',2,1),
('10/17/2017','199000000',1,1),
('10/17/2017','199000000',4,1),
('03/17/2016','299000000',0,1)
GO

INSERT INTO ChiTietHoaDon
VALUES 
(0,6),
(1,5),
(2,4),
(3,3),
(4,2),
(0,1),
(1,0)
GO


INSERT INTO HoaDon VALUES ('10/17/2017','199000000',4,1)