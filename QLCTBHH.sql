USE [master]
GO
/****** Object:  Database [QLCTyBHH]    Script Date: 5/17/2018 8:33:41 PM ******/
CREATE DATABASE [QLCTyBHH]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLCTyBHH', FILENAME = N'E:\QLCTyBHH.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLCTyBHH_log', FILENAME = N'E:\QLCTyBHH_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QLCTyBHH] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLCTyBHH].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLCTyBHH] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLCTyBHH] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLCTyBHH] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLCTyBHH] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLCTyBHH] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLCTyBHH] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QLCTyBHH] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLCTyBHH] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLCTyBHH] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLCTyBHH] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLCTyBHH] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLCTyBHH] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLCTyBHH] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLCTyBHH] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLCTyBHH] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLCTyBHH] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLCTyBHH] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLCTyBHH] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLCTyBHH] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLCTyBHH] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLCTyBHH] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLCTyBHH] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLCTyBHH] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLCTyBHH] SET  MULTI_USER 
GO
ALTER DATABASE [QLCTyBHH] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLCTyBHH] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLCTyBHH] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLCTyBHH] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [QLCTyBHH] SET DELAYED_DURABILITY = DISABLED 
GO
USE [QLCTyBHH]
GO
/****** Object:  Table [dbo].[BaoCao]    Script Date: 5/17/2018 8:33:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaoCao](
	[MSMH] [int] NULL,
	[MSBC] [int] NOT NULL,
	[NgayThangNam] [date] NULL,
	[TongTien] [float] NULL,
 CONSTRAINT [PK_BaoCao] PRIMARY KEY CLUSTERED 
(
	[MSBC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CTPhieuGH]    Script Date: 5/17/2018 8:33:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTPhieuGH](
	[SOPG] [int] NOT NULL,
	[MSMH] [int] NOT NULL,
	[SoLuongGiao] [int] NULL,
	[DonGia] [float] NULL,
	[ThanhTien] [float] NULL,
 CONSTRAINT [PK_CTPhieuGH_1] PRIMARY KEY CLUSTERED 
(
	[SOPG] ASC,
	[MSMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CTPhieuTT]    Script Date: 5/17/2018 8:33:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTPhieuTT](
	[SOPTT] [int] NOT NULL,
	[MSMH] [int] NOT NULL,
	[SoLuongBan] [int] NULL,
	[DonGia] [float] NULL,
	[ThanhTien] [float] NULL,
 CONSTRAINT [PK_CTPhieuTT_1] PRIMARY KEY CLUSTERED 
(
	[SOPTT] ASC,
	[MSMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CuaHang]    Script Date: 5/17/2018 8:33:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CuaHang](
	[MSCH] [int] IDENTITY(1,1) NOT NULL,
	[TenCH] [nvarchar](50) NOT NULL,
	[MSLH] [int] NOT NULL,
	[DiaChi] [nvarchar](50) NULL,
	[NvPhuTrach] [int] NULL,
	[SDT] [char](12) NULL,
 CONSTRAINT [PK_CuaHang] PRIMARY KEY CLUSTERED 
(
	[MSCH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LoaiHang]    Script Date: 5/17/2018 8:33:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiHang](
	[MSLH] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiHang] [nvarchar](50) NULL,
	[HinhAnh] [nvarchar](max) NULL,
 CONSTRAINT [PK_LoaiHang] PRIMARY KEY CLUSTERED 
(
	[MSLH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MatHang]    Script Date: 5/17/2018 8:33:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MatHang](
	[MSMH] [int] IDENTITY(1,1) NOT NULL,
	[MSLH] [int] NULL,
	[TenHang] [nvarchar](50) NULL,
	[SoLuong] [int] NULL,
	[TrangThai] [nvarchar](50) NULL,
	[DonGia] [float] NULL,
	[HinhAnh] [nvarchar](max) NULL,
	[NgayCapNhat] [date] NULL,
 CONSTRAINT [PK_MatHang] PRIMARY KEY CLUSTERED 
(
	[MSMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NVPhuTrach]    Script Date: 5/17/2018 8:33:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NVPhuTrach](
	[MSNV] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[Phai] [nvarchar](50) NULL,
	[NamSinh] [date] NULL,
	[DiaChi] [nvarchar](100) NULL,
	[SDT] [char](12) NULL,
	[TaiKhoan] [char](10) NOT NULL,
	[MatKhau] [char](10) NOT NULL,
 CONSTRAINT [PK_NVPhuTrach] PRIMARY KEY CLUSTERED 
(
	[MSNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NVThanhToan]    Script Date: 5/17/2018 8:33:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NVThanhToan](
	[MSNV] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](50) NOT NULL,
	[Phai] [nvarchar](50) NOT NULL,
	[NamSinh] [date] NOT NULL,
	[DiaChi] [nvarchar](100) NULL,
	[SDT] [char](12) NOT NULL,
	[TaiKhoan] [nchar](10) NOT NULL,
	[MatKhau] [nchar](10) NOT NULL,
 CONSTRAINT [PK_NVThanhToan] PRIMARY KEY CLUSTERED 
(
	[MSNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhieuGiaoHang]    Script Date: 5/17/2018 8:33:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuGiaoHang](
	[SOPG] [int] IDENTITY(1,1) NOT NULL,
	[NgayLapPhieu] [date] NULL,
	[MSCH] [int] NULL,
	[MSNV] [int] NULL,
	[TongCong] [float] NULL,
	[TrangThai] [nvarchar](50) NULL,
 CONSTRAINT [PK_PhieuGiaoHang] PRIMARY KEY CLUSTERED 
(
	[SOPG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhieuThanhToan]    Script Date: 5/17/2018 8:33:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuThanhToan](
	[SOPTT] [int] IDENTITY(1,1) NOT NULL,
	[NgayLapPhieu] [date] NOT NULL,
	[MSCH] [int] NOT NULL,
	[MSVN] [int] NOT NULL,
	[TongCong] [float] NOT NULL,
	[TrangThai] [nvarchar](50) NULL,
 CONSTRAINT [PK_PhieuThanhToan] PRIMARY KEY CLUSTERED 
(
	[SOPTT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TonKho]    Script Date: 5/17/2018 8:33:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TonKho](
	[NgayThang] [date] NOT NULL,
	[MSMH] [int] NOT NULL,
	[SoLuongDau] [int] NULL,
	[SoLuongCuoi] [int] NULL,
	[TongSoLuong] [int] NULL,
 CONSTRAINT [PK_TonKho] PRIMARY KEY CLUSTERED 
(
	[NgayThang] ASC,
	[MSMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[CuaHang] ON 

INSERT [dbo].[CuaHang] ([MSCH], [TenCH], [MSLH], [DiaChi], [NvPhuTrach], [SDT]) VALUES (1, N'Cửa Hàng Đồ Uống', 1, N'1 Trần Hưng Đạo, Q.1, TP.HCM', 1, N'028 1111111 ')
INSERT [dbo].[CuaHang] ([MSCH], [TenCH], [MSLH], [DiaChi], [NvPhuTrach], [SDT]) VALUES (2, N'Cửa Hàng Sữa', 2, N'2 Khánh Hội, Q.4, TP.HCM', 2, N'028 7654321 ')
INSERT [dbo].[CuaHang] ([MSCH], [TenCH], [MSLH], [DiaChi], [NvPhuTrach], [SDT]) VALUES (3, N'Cửa Hàng Gia Vị', 3, N'3 Pasteur, Q.1, TP.HCM', 3, N'028 9090909 ')
INSERT [dbo].[CuaHang] ([MSCH], [TenCH], [MSLH], [DiaChi], [NvPhuTrach], [SDT]) VALUES (4, N'Cửa Hàng Đồ Dùng Cá Nhân', 4, N'4 CMT8, Q.3, TP.HCM', 4, N'028 1233214 ')
INSERT [dbo].[CuaHang] ([MSCH], [TenCH], [MSLH], [DiaChi], [NvPhuTrach], [SDT]) VALUES (5, N'Cửa Hàng Đồ Vệ Sinh Nhà Cửa', 5, N'5 Sư Vạn Hạnh, Q.10, TP.HCM', 5, N'028 4566547 ')
INSERT [dbo].[CuaHang] ([MSCH], [TenCH], [MSLH], [DiaChi], [NvPhuTrach], [SDT]) VALUES (6, N'Cửa Hàng Thực Phẩm Ăn Liền', 6, N'6 Võ Văn Tần, Q.3, TP.HCM', 6, N'028 7896547 ')
INSERT [dbo].[CuaHang] ([MSCH], [TenCH], [MSLH], [DiaChi], [NvPhuTrach], [SDT]) VALUES (7, N'Cửa Hàng Bánh Kẹo, Ăn Vặt', 7, N'7 Cộng Hòa, Q.Tân Bình, TP.HCM', 7, N'028 0007897 ')
SET IDENTITY_INSERT [dbo].[CuaHang] OFF
SET IDENTITY_INSERT [dbo].[LoaiHang] ON 

INSERT [dbo].[LoaiHang] ([MSLH], [TenLoaiHang], [HinhAnh]) VALUES (1, N'Đồ Uống', N'DoUong.jpg')
INSERT [dbo].[LoaiHang] ([MSLH], [TenLoaiHang], [HinhAnh]) VALUES (2, N'Sữa', N'Sua.jpg')
INSERT [dbo].[LoaiHang] ([MSLH], [TenLoaiHang], [HinhAnh]) VALUES (3, N'Gia Vị Nấu Ăn', N'GiaViNauAn.jpg')
INSERT [dbo].[LoaiHang] ([MSLH], [TenLoaiHang], [HinhAnh]) VALUES (4, N'Đồ Dùng Cá Nhân', N'DoDungCaNhan.jpg')
INSERT [dbo].[LoaiHang] ([MSLH], [TenLoaiHang], [HinhAnh]) VALUES (5, N'Vệ Sinh Nhà Cửa', N'VeSinhNhaCua.jpg')
INSERT [dbo].[LoaiHang] ([MSLH], [TenLoaiHang], [HinhAnh]) VALUES (6, N'Thực Phẩm Ăn Liền', N'ThucPhamAnLien.jpg')
INSERT [dbo].[LoaiHang] ([MSLH], [TenLoaiHang], [HinhAnh]) VALUES (7, N'Bánh Kẹo, Ăn Vặt', N'BanhKeoAnVat.jpg')
SET IDENTITY_INSERT [dbo].[LoaiHang] OFF
SET IDENTITY_INSERT [dbo].[MatHang] ON 

INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (1, 1, N'Cocacola', 10, N'Còn Hàng', 10000, N'Coca.jpg', CAST(N'2018-04-01' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (2, 2, N'Dutch Lady', 10, N'Còn Hàng', 10000, N'Dutch Lady.jpg', CAST(N'2018-04-02' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (3, 2, N'Nestle', 10, N'Còn Hàng', 10000, N'Nestle.jpg', CAST(N'2018-04-03' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (4, 2, N'New Zealand Pure Milk', 10, N'Còn Hàng', 10000, N'New Zealand Pure Milk.jpg', CAST(N'2018-04-04' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (5, 3, N'Ajinomoto', 10, N'Còn Hàng', 10000, N'Ajinomoto.jpg', CAST(N'2018-04-05' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (6, 3, N'nước Tương Maggi', 10, N'Còn Hàng', 10000, N'Maggi.jpg', CAST(N'2018-04-06' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (7, 3, N'Dầu Ăn Neptune', 10, N'Còn Hàng', 10000, N'Neptune.jpg', CAST(N'2018-04-07' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (8, 3, N'Muối', 10, N'Còn Hàng', 10000, N'Muối.jpg', CAST(N'2018-04-08' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (9, 3, N'Đường', 10, N'Còn Hàng', 10000, N'Đường.jpg', CAST(N'2018-04-09' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (10, 3, N'Bột Ngọt Vedan', 10, N'Còn Hàng', 10000, N'Vedan.jpg', CAST(N'2018-04-10' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (11, 4, N'Dầu Gội', 10, N'Còn Hàng', 10000, N'Dầu Gội.jpg', CAST(N'2018-04-11' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (12, 1, N'Pepsi', 10, N'Còn Hàng', 10000, N'Pepsi.jpg', CAST(N'2018-04-12' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (13, 4, N'Dầu Xả', 10, N'Còn Hàng', 10000, N'Dầu Xả.jpg', CAST(N'2018-04-13' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (14, 4, N'Nước Rửa Tay', 10, N'Còn Hàng', 10000, N'Nước Rửa Tay.jpg', CAST(N'2018-04-14' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (15, 4, N'Kem Đánh Răng', 10, N'Còn Hàng', 10000, N'Kem Đánh Răng.jpg', CAST(N'2018-04-15' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (16, 4, N'Bàn Chải Đánh Răng', 10, N'Còn Hàng', 10000, N'Bàn Chải Đánh Răng.jpg', CAST(N'2018-04-16' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (17, 4, N'Khăn Giấy', 10, N'Còn Hàng', 10000, N'Khăn Giấy.jpg', CAST(N'2018-04-17' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (18, 5, N'Nước Giặt', 10, N'Còn Hàng', 10000, N'Nước Giặt.jpg', CAST(N'2018-04-18' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (19, 5, N'Bột Giặt', 10, N'Còn Hàng', 10000, N'Bột Giặt.jpg', CAST(N'2018-04-19' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (20, 5, N'Thuốc Tẩy Quần Áo', 10, N'Còn Hàng', 10000, N'Thuốc Tẩy Quần Áo.jpg', CAST(N'2018-04-20' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (21, 5, N'Nước Lau Nhà', 10, N'Còn Hàng', 10000, N'Nước Lau Nhà.jpg', CAST(N'2018-04-21' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (22, 5, N'Long Não', 10, N'Còn Hàng', 10000, N'Long Não.jpg', CAST(N'2018-04-22' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (23, 1, N'Revive Chanh Muối', 10, N'Còn Hàng', 10000, N'Revive.jpg', CAST(N'2018-04-23' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (24, 5, N'Sáp Thơm', 10, N'Còn Hàng', 10000, N'Sáp Thơm.jpg', CAST(N'2018-04-24' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (25, 6, N'Mì', 10, N'Còn Hàng', 10000, N'Mì.jpg', CAST(N'2018-04-25' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (26, 6, N'Phở', 10, N'Còn Hàng', 10000, N'Phở.jpg', CAST(N'2018-04-26' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (27, 6, N'Cháo', 10, N'Còn Hàng', 10000, N'Cháo.jpg', CAST(N'2018-04-27' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (28, 6, N'Miến', 10, N'Còn Hàng', 10000, N'Miến.jpg', CAST(N'2018-04-28' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (29, 6, N'Hủ Tiếu', 10, N'Còn Hàng', 10000, N'Hủ Tiếu.jpg', CAST(N'2018-04-29' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (30, 6, N'Bún', 10, N'Còn Hàng', 10000, N'Bún.jpg', CAST(N'2018-04-30' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (31, 7, N'Bánh Bông Lan', 10, N'Còn Hàng', 10000, N'Bánh Bông Lan.jpg', CAST(N'2018-05-01' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (32, 7, N'Bánh Quy', 10, N'Còn Hàng', 10000, N'Bánh Quy.jpg', CAST(N'2018-05-02' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (33, 7, N'Bánh Xốp', 10, N'Còn Hàng', 10000, N'Bánh Xốp.jpg', CAST(N'2018-05-03' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (34, 1, N'7Up', 10, N'Còn Hàng', 10000, N'7Up.jpg', CAST(N'2018-05-04' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (35, 7, N'Bánh Quế', 10, N'Còn Hàng', 10000, N'Bánh Quế.jpg', CAST(N'2018-05-05' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (36, 7, N'Snack', 10, N'Còn Hàng', 10000, N'Snack.jpg', CAST(N'2018-05-06' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (37, 7, N'Kẹo', 10, N'Còn Hàng', 10000, N'Kẹo.jpg', CAST(N'2018-05-07' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (38, 1, N'Lavie', 10, N'Còn Hàng', 10000, N'Lavie.jpg', CAST(N'2018-05-05' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (39, 1, N'I-On Life', 10, N'Còn Hàng', 10000, N'I-On Life.jpg', CAST(N'2018-05-09' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (40, 2, N'THTrueMilk Socola', 10, N'Còn Hàng', 10000, N'THTrueMilk Socola.jpg', CAST(N'2018-05-10' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (41, 2, N'THTrueMilk Dâu', 10, N'Còn Hàng', 10000, N'THTrueMilk Dâu.jpg', CAST(N'2018-05-10' AS Date))
INSERT [dbo].[MatHang] ([MSMH], [MSLH], [TenHang], [SoLuong], [TrangThai], [DonGia], [HinhAnh], [NgayCapNhat]) VALUES (42, 2, N'Vinamilk', 10, N'Còn Hàng', 10000, N'Vinamilk.jpg', CAST(N'2018-05-10' AS Date))
SET IDENTITY_INSERT [dbo].[MatHang] OFF
SET IDENTITY_INSERT [dbo].[NVPhuTrach] ON 

INSERT [dbo].[NVPhuTrach] ([MSNV], [HoTen], [Phai], [NamSinh], [DiaChi], [SDT], [TaiKhoan], [MatKhau]) VALUES (1, N'Cao Ngọc Hương', N'Nữ', CAST(N'1997-01-01' AS Date), N'1 Lê Đình Cẩn, Q.Bình Tân, TP.HCM', N'0903 111 222', N'cnh       ', N'123       ')
INSERT [dbo].[NVPhuTrach] ([MSNV], [HoTen], [Phai], [NamSinh], [DiaChi], [SDT], [TaiKhoan], [MatKhau]) VALUES (2, N'Lê Ngọc Anh', N'Nữ', CAST(N'1997-01-02' AS Date), N'2 Võ Văn Kiệt, Q.5, TP.HCM', N'0923 909 555', N'lna       ', N'123       ')
INSERT [dbo].[NVPhuTrach] ([MSNV], [HoTen], [Phai], [NamSinh], [DiaChi], [SDT], [TaiKhoan], [MatKhau]) VALUES (3, N'Đặng Đào Thanh Nhàn', N'Nữ', CAST(N'1997-01-03' AS Date), N'3 Nguyễn Văn Cừ, Q.1,TP.HCM', N'0913 678 678', N'ddtn      ', N'123       ')
INSERT [dbo].[NVPhuTrach] ([MSNV], [HoTen], [Phai], [NamSinh], [DiaChi], [SDT], [TaiKhoan], [MatKhau]) VALUES (4, N'Nguyễn Ngọc Trâm', N'Nữ', CAST(N'1997-01-04' AS Date), N'4 Quang Trung, Q.Gò Vấp, TP.HCM', N'0125 678 987', N'nnt       ', N'123       ')
INSERT [dbo].[NVPhuTrach] ([MSNV], [HoTen], [Phai], [NamSinh], [DiaChi], [SDT], [TaiKhoan], [MatKhau]) VALUES (5, N'La Cẩm Khiêm', N'Nam', CAST(N'1997-01-05' AS Date), N'5 Lê Duẩn, Q.Bình Tân, TP.HCM', N'0823 789 798', N'lck       ', N'123       ')
INSERT [dbo].[NVPhuTrach] ([MSNV], [HoTen], [Phai], [NamSinh], [DiaChi], [SDT], [TaiKhoan], [MatKhau]) VALUES (6, N'Trịnh Nhữ Ánh Tuyết', N'Nữ', CAST(N'1997-01-06' AS Date), N'6 Cộng Hòa, Q.Tân Bình, TP.HCM', N'0679 123 456', N'tnat      ', N'123       ')
INSERT [dbo].[NVPhuTrach] ([MSNV], [HoTen], [Phai], [NamSinh], [DiaChi], [SDT], [TaiKhoan], [MatKhau]) VALUES (7, N'Đỗ Huỳnh Như', N'Nữ', CAST(N'1997-01-07' AS Date), N'7 Phan Văn Trị, Q.5, TP.HCM', N'0123 987 654', N'dhn       ', N'123       ')
SET IDENTITY_INSERT [dbo].[NVPhuTrach] OFF
SET IDENTITY_INSERT [dbo].[NVThanhToan] ON 

INSERT [dbo].[NVThanhToan] ([MSNV], [HoTen], [Phai], [NamSinh], [DiaChi], [SDT], [TaiKhoan], [MatKhau]) VALUES (1, N'tram', N'nu', CAST(N'1997-01-01' AS Date), N'aa', N'09191       ', N'nnt       ', N'123       ')
SET IDENTITY_INSERT [dbo].[NVThanhToan] OFF
ALTER TABLE [dbo].[BaoCao]  WITH CHECK ADD  CONSTRAINT [FK_BaoCao_MatHang] FOREIGN KEY([MSMH])
REFERENCES [dbo].[MatHang] ([MSMH])
GO
ALTER TABLE [dbo].[BaoCao] CHECK CONSTRAINT [FK_BaoCao_MatHang]
GO
ALTER TABLE [dbo].[CTPhieuGH]  WITH CHECK ADD  CONSTRAINT [FK_CTPhieuGH_MatHang] FOREIGN KEY([MSMH])
REFERENCES [dbo].[MatHang] ([MSMH])
GO
ALTER TABLE [dbo].[CTPhieuGH] CHECK CONSTRAINT [FK_CTPhieuGH_MatHang]
GO
ALTER TABLE [dbo].[CTPhieuGH]  WITH CHECK ADD  CONSTRAINT [FK_CTPhieuGH_PhieuGiaoHang] FOREIGN KEY([SOPG])
REFERENCES [dbo].[PhieuGiaoHang] ([SOPG])
GO
ALTER TABLE [dbo].[CTPhieuGH] CHECK CONSTRAINT [FK_CTPhieuGH_PhieuGiaoHang]
GO
ALTER TABLE [dbo].[CTPhieuTT]  WITH CHECK ADD  CONSTRAINT [FK_CTPhieuTT_MatHang] FOREIGN KEY([MSMH])
REFERENCES [dbo].[MatHang] ([MSMH])
GO
ALTER TABLE [dbo].[CTPhieuTT] CHECK CONSTRAINT [FK_CTPhieuTT_MatHang]
GO
ALTER TABLE [dbo].[CTPhieuTT]  WITH CHECK ADD  CONSTRAINT [FK_CTPhieuTT_PhieuThanhToan] FOREIGN KEY([SOPTT])
REFERENCES [dbo].[PhieuThanhToan] ([SOPTT])
GO
ALTER TABLE [dbo].[CTPhieuTT] CHECK CONSTRAINT [FK_CTPhieuTT_PhieuThanhToan]
GO
ALTER TABLE [dbo].[CuaHang]  WITH CHECK ADD  CONSTRAINT [FK_CuaHang_LoaiHang] FOREIGN KEY([MSLH])
REFERENCES [dbo].[LoaiHang] ([MSLH])
GO
ALTER TABLE [dbo].[CuaHang] CHECK CONSTRAINT [FK_CuaHang_LoaiHang]
GO
ALTER TABLE [dbo].[CuaHang]  WITH CHECK ADD  CONSTRAINT [FK_CuaHang_NVPhuTrach] FOREIGN KEY([NvPhuTrach])
REFERENCES [dbo].[NVPhuTrach] ([MSNV])
GO
ALTER TABLE [dbo].[CuaHang] CHECK CONSTRAINT [FK_CuaHang_NVPhuTrach]
GO
ALTER TABLE [dbo].[MatHang]  WITH CHECK ADD  CONSTRAINT [FK_MatHang_LoaiHang] FOREIGN KEY([MSLH])
REFERENCES [dbo].[LoaiHang] ([MSLH])
GO
ALTER TABLE [dbo].[MatHang] CHECK CONSTRAINT [FK_MatHang_LoaiHang]
GO
ALTER TABLE [dbo].[PhieuThanhToan]  WITH CHECK ADD  CONSTRAINT [FK_PhieuThanhToan_NVThanhToan] FOREIGN KEY([MSVN])
REFERENCES [dbo].[NVThanhToan] ([MSNV])
GO
ALTER TABLE [dbo].[PhieuThanhToan] CHECK CONSTRAINT [FK_PhieuThanhToan_NVThanhToan]
GO
ALTER TABLE [dbo].[TonKho]  WITH CHECK ADD  CONSTRAINT [FK_TonKho_MatHang] FOREIGN KEY([MSMH])
REFERENCES [dbo].[MatHang] ([MSMH])
GO
ALTER TABLE [dbo].[TonKho] CHECK CONSTRAINT [FK_TonKho_MatHang]
GO
USE [master]
GO
ALTER DATABASE [QLCTyBHH] SET  READ_WRITE 
GO
