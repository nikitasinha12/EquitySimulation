USE [master]
GO
/****** Object:  Database [Equity]    Script Date: 5/5/2017 3:29:25 PM ******/
CREATE DATABASE [Equity] 
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Equity].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Equity] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Equity] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Equity] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Equity] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Equity] SET ARITHABORT OFF 
GO
ALTER DATABASE [Equity] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Equity] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Equity] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Equity] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Equity] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Equity] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Equity] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Equity] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Equity] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Equity] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Equity] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Equity] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Equity] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Equity] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Equity] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Equity] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Equity] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Equity] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Equity] SET  MULTI_USER 
GO
ALTER DATABASE [Equity] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Equity] SET DB_CHAINING OFF 
GO
USE [Equity]
GO
/****** Object:  Table [dbo].[Block]    Script Date: 5/5/2017 3:29:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Block](
	[BlockID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NOT NULL,
	[BlockStatusID] [bigint] NOT NULL,
	[SymbolID] [bigint] NOT NULL,
	[ExectuedQty] [bigint] NOT NULL,
	[LimitPrice] [decimal](18, 0) NOT NULL,
	[TotalQty] [bigint] NOT NULL,
	[StopPrice] [decimal](18, 0) NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[UpdationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Block] PRIMARY KEY CLUSTERED 
(
	[BlockID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Block_status]    Script Date: 5/5/2017 3:29:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Block_status](
	[BlockStatusId] [bigint] IDENTITY(1,1) NOT NULL,
	[StatusName] [varchar](50) NOT NULL,
	[ISActive] [bit] NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[UpdationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Block_status] PRIMARY KEY CLUSTERED 
(
	[BlockStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Order]    Script Date: 5/5/2017 3:29:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderTypeID] [bigint] NOT NULL,
	[BlockID] [bigint] NULL,
	[PortfolioID] [bigint] NOT NULL,
	[PMID] [bigint] NOT NULL,
	[OrderStatusID] [bigint] NOT NULL,
	[MarketPrice] [decimal](18, 0) NULL,
	[LimitPrice] [decimal](18, 0) NULL,
	[AllocatedQty] [bigint] NOT NULL,
	[TotalQty] [bigint] NOT NULL,
	[ExpiryDate] [datetime2](7) NULL,
	[Side] [varchar](50) NOT NULL,
	[SymbolID] [bigint] NOT NULL,
	[StopPrice] [decimal](18, 0) NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[UpdationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Order_Status]    Script Date: 5/5/2017 3:29:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Order_Status](
	[OrderStatusID] [bigint] IDENTITY(1,1) NOT NULL,
	[StatusName] [varchar](50) NOT NULL,
	[ISActive] [bit] NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[UpdationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Order_Status] PRIMARY KEY CLUSTERED 
(
	[OrderStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Order_Type]    Script Date: 5/5/2017 3:29:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Order_Type](
	[OrderTypeID] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderTypeName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Order_Type\] PRIMARY KEY CLUSTERED 
(
	[OrderTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[orders]    Script Date: 5/5/2017 3:29:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[orders](
	[OrderID] [varchar](50) NULL,
	[OrderTypeID] [varchar](50) NULL,
	[BlockID] [varchar](50) NULL,
	[RiskClassID] [varchar](50) NULL,
	[PMID] [varchar](50) NULL,
	[OrderStatusID] [varchar](50) NULL,
	[MarketPrice] [varchar](50) NULL,
	[LimitPrice] [varchar](50) NULL,
	[AllocatedQty] [varchar](50) NULL,
	[TotalQty] [varchar](50) NULL,
	[ExpiryDate] [varchar](50) NULL,
	[Side] [varchar](50) NULL,
	[SymbolID] [varchar](50) NULL,
	[StopPrice] [varchar](50) NULL,
	[CreationDate] [varchar](50) NULL,
	[UpdationDate] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Portfolio]    Script Date: 5/5/2017 3:29:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Portfolio](
	[PortfolioID] [bigint] IDENTITY(1,1) NOT NULL,
	[PortfolioName] [varchar](50) NULL,
	[ISActive] [bit] NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[UpdationDate] [datetime2](7) NOT NULL,
	[UserID] [bigint] NULL,
 CONSTRAINT [PK_Risk_Class] PRIMARY KEY CLUSTERED 
(
	[PortfolioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Role]    Script Date: 5/5/2017 3:29:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [bigint] IDENTITY(1,1) NOT NULL,
	[RoleType] [varchar](50) NOT NULL,
	[ISActive] [bit] NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[UpdationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Symbol_Properties]    Script Date: 5/5/2017 3:29:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Symbol_Properties](
	[SymbolID] [bigint] IDENTITY(1,1) NOT NULL,
	[Symbol] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Price] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Symbol_Properties] PRIMARY KEY CLUSTERED 
(
	[SymbolID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 5/5/2017 3:29:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [bigint] IDENTITY(1,1) NOT NULL,
	[FName] [varchar](50) NOT NULL,
	[LName] [varchar](50) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[PassWord] [varchar](50) NOT NULL,
	[ISActive] [bit] NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[UpdationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User_Role]    Script Date: 5/5/2017 3:29:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Role](
	[UserRoleID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NOT NULL,
	[RoleID] [bigint] NOT NULL,
	[ISActive] [bit] NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[UpdationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_User_Role] PRIMARY KEY CLUSTERED 
(
	[UserRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Block] ON 

INSERT [dbo].[Block] ([BlockID], [UserID], [BlockStatusID], [SymbolID], [ExectuedQty], [LimitPrice], [TotalQty], [StopPrice], [CreationDate], [UpdationDate]) VALUES (1, 1, 1, 1, 0, CAST(1000 AS Decimal(18, 0)), 1222, CAST(50 AS Decimal(18, 0)), CAST(N'2017-03-16 10:13:24.5193828' AS DateTime2), CAST(N'2017-03-16 10:13:24.5193828' AS DateTime2))
INSERT [dbo].[Block] ([BlockID], [UserID], [BlockStatusID], [SymbolID], [ExectuedQty], [LimitPrice], [TotalQty], [StopPrice], [CreationDate], [UpdationDate]) VALUES (2, 4, 1, 2, 0, CAST(1000 AS Decimal(18, 0)), 1212, CAST(50 AS Decimal(18, 0)), CAST(N'2017-03-16 10:24:21.2691243' AS DateTime2), CAST(N'2017-03-16 10:24:21.2691243' AS DateTime2))
INSERT [dbo].[Block] ([BlockID], [UserID], [BlockStatusID], [SymbolID], [ExectuedQty], [LimitPrice], [TotalQty], [StopPrice], [CreationDate], [UpdationDate]) VALUES (3, 1, 1, 1, 1000, CAST(1000 AS Decimal(18, 0)), 1000, CAST(50 AS Decimal(18, 0)), CAST(N'2017-03-16 10:37:04.6146223' AS DateTime2), CAST(N'2017-03-16 10:37:04.6146223' AS DateTime2))
INSERT [dbo].[Block] ([BlockID], [UserID], [BlockStatusID], [SymbolID], [ExectuedQty], [LimitPrice], [TotalQty], [StopPrice], [CreationDate], [UpdationDate]) VALUES (4, 4, 1, 2, 0, CAST(1000 AS Decimal(18, 0)), 1212, CAST(50 AS Decimal(18, 0)), CAST(N'2017-03-16 11:40:52.9744200' AS DateTime2), CAST(N'2017-03-16 11:40:52.9744200' AS DateTime2))
INSERT [dbo].[Block] ([BlockID], [UserID], [BlockStatusID], [SymbolID], [ExectuedQty], [LimitPrice], [TotalQty], [StopPrice], [CreationDate], [UpdationDate]) VALUES (5, 4, 1, 1, 0, CAST(1000 AS Decimal(18, 0)), 12, CAST(50 AS Decimal(18, 0)), CAST(N'2017-03-16 14:15:27.2796561' AS DateTime2), CAST(N'2017-03-16 14:15:27.2796561' AS DateTime2))
INSERT [dbo].[Block] ([BlockID], [UserID], [BlockStatusID], [SymbolID], [ExectuedQty], [LimitPrice], [TotalQty], [StopPrice], [CreationDate], [UpdationDate]) VALUES (6, 1, 1, 1, 0, CAST(1000 AS Decimal(18, 0)), 222, CAST(50 AS Decimal(18, 0)), CAST(N'2017-03-16 14:51:25.7534819' AS DateTime2), CAST(N'2017-03-16 14:51:25.7534819' AS DateTime2))
INSERT [dbo].[Block] ([BlockID], [UserID], [BlockStatusID], [SymbolID], [ExectuedQty], [LimitPrice], [TotalQty], [StopPrice], [CreationDate], [UpdationDate]) VALUES (7, 4, 1, 2, 0, CAST(1000 AS Decimal(18, 0)), 300, CAST(50 AS Decimal(18, 0)), CAST(N'2017-03-17 10:07:40.1809062' AS DateTime2), CAST(N'2017-03-17 10:07:40.1809062' AS DateTime2))
INSERT [dbo].[Block] ([BlockID], [UserID], [BlockStatusID], [SymbolID], [ExectuedQty], [LimitPrice], [TotalQty], [StopPrice], [CreationDate], [UpdationDate]) VALUES (8, 1, 1, 1, 0, CAST(1000 AS Decimal(18, 0)), 3434, CAST(50 AS Decimal(18, 0)), CAST(N'2017-03-17 10:48:49.9712367' AS DateTime2), CAST(N'2017-03-17 10:48:49.9712367' AS DateTime2))
INSERT [dbo].[Block] ([BlockID], [UserID], [BlockStatusID], [SymbolID], [ExectuedQty], [LimitPrice], [TotalQty], [StopPrice], [CreationDate], [UpdationDate]) VALUES (9, 1, 1, 2, 0, CAST(1000 AS Decimal(18, 0)), 2000, CAST(50 AS Decimal(18, 0)), CAST(N'2017-03-17 10:51:40.1102489' AS DateTime2), CAST(N'2017-03-17 10:51:40.1102489' AS DateTime2))
INSERT [dbo].[Block] ([BlockID], [UserID], [BlockStatusID], [SymbolID], [ExectuedQty], [LimitPrice], [TotalQty], [StopPrice], [CreationDate], [UpdationDate]) VALUES (10, 1, 1, 2, 0, CAST(1000 AS Decimal(18, 0)), 2000, CAST(50 AS Decimal(18, 0)), CAST(N'2017-03-17 11:11:23.4925753' AS DateTime2), CAST(N'2017-05-03 11:40:00.9327298' AS DateTime2))
INSERT [dbo].[Block] ([BlockID], [UserID], [BlockStatusID], [SymbolID], [ExectuedQty], [LimitPrice], [TotalQty], [StopPrice], [CreationDate], [UpdationDate]) VALUES (11, 1, 1, 1, 0, CAST(1000 AS Decimal(18, 0)), 6635, CAST(50 AS Decimal(18, 0)), CAST(N'2017-03-17 11:12:23.7275982' AS DateTime2), CAST(N'2017-05-03 16:05:26.8386485' AS DateTime2))
INSERT [dbo].[Block] ([BlockID], [UserID], [BlockStatusID], [SymbolID], [ExectuedQty], [LimitPrice], [TotalQty], [StopPrice], [CreationDate], [UpdationDate]) VALUES (12, 1, 1, 1, 0, CAST(1000 AS Decimal(18, 0)), 1000, CAST(50 AS Decimal(18, 0)), CAST(N'2017-03-17 11:15:19.1761413' AS DateTime2), CAST(N'2017-03-17 11:15:19.1771414' AS DateTime2))
INSERT [dbo].[Block] ([BlockID], [UserID], [BlockStatusID], [SymbolID], [ExectuedQty], [LimitPrice], [TotalQty], [StopPrice], [CreationDate], [UpdationDate]) VALUES (13, 1, 1, 2, 0, CAST(1000 AS Decimal(18, 0)), 10000, CAST(50 AS Decimal(18, 0)), CAST(N'2017-03-17 11:16:58.0410268' AS DateTime2), CAST(N'2017-03-17 11:16:58.0410268' AS DateTime2))
INSERT [dbo].[Block] ([BlockID], [UserID], [BlockStatusID], [SymbolID], [ExectuedQty], [LimitPrice], [TotalQty], [StopPrice], [CreationDate], [UpdationDate]) VALUES (14, 1, 1, 2, 0, CAST(1000 AS Decimal(18, 0)), 2000, CAST(50 AS Decimal(18, 0)), CAST(N'2017-03-17 11:17:04.7947021' AS DateTime2), CAST(N'2017-03-17 11:17:04.7947021' AS DateTime2))
INSERT [dbo].[Block] ([BlockID], [UserID], [BlockStatusID], [SymbolID], [ExectuedQty], [LimitPrice], [TotalQty], [StopPrice], [CreationDate], [UpdationDate]) VALUES (15, 1, 1, 2, 0, CAST(1000 AS Decimal(18, 0)), 1055, CAST(50 AS Decimal(18, 0)), CAST(N'2017-03-17 11:23:09.0731263' AS DateTime2), CAST(N'2017-03-17 11:23:09.0731263' AS DateTime2))
INSERT [dbo].[Block] ([BlockID], [UserID], [BlockStatusID], [SymbolID], [ExectuedQty], [LimitPrice], [TotalQty], [StopPrice], [CreationDate], [UpdationDate]) VALUES (16, 1, 1, 2, 0, CAST(1000 AS Decimal(18, 0)), 2020, CAST(50 AS Decimal(18, 0)), CAST(N'2017-03-17 11:23:30.2762464' AS DateTime2), CAST(N'2017-03-17 11:23:30.2762464' AS DateTime2))
INSERT [dbo].[Block] ([BlockID], [UserID], [BlockStatusID], [SymbolID], [ExectuedQty], [LimitPrice], [TotalQty], [StopPrice], [CreationDate], [UpdationDate]) VALUES (17, 1, 1, 3, 0, CAST(1000 AS Decimal(18, 0)), 123, CAST(50 AS Decimal(18, 0)), CAST(N'2017-03-17 12:26:34.3506442' AS DateTime2), CAST(N'2017-03-17 12:26:34.3506442' AS DateTime2))
INSERT [dbo].[Block] ([BlockID], [UserID], [BlockStatusID], [SymbolID], [ExectuedQty], [LimitPrice], [TotalQty], [StopPrice], [CreationDate], [UpdationDate]) VALUES (18, 1, 1, 1, 0, CAST(1000 AS Decimal(18, 0)), 10000, CAST(50 AS Decimal(18, 0)), CAST(N'2017-03-17 12:26:46.1078198' AS DateTime2), CAST(N'2017-03-17 12:26:46.1078198' AS DateTime2))
INSERT [dbo].[Block] ([BlockID], [UserID], [BlockStatusID], [SymbolID], [ExectuedQty], [LimitPrice], [TotalQty], [StopPrice], [CreationDate], [UpdationDate]) VALUES (19, 1, 1, 2, 0, CAST(1000 AS Decimal(18, 0)), 5541, CAST(50 AS Decimal(18, 0)), CAST(N'2017-03-17 13:54:48.4390001' AS DateTime2), CAST(N'2017-03-17 13:54:48.4390001' AS DateTime2))
INSERT [dbo].[Block] ([BlockID], [UserID], [BlockStatusID], [SymbolID], [ExectuedQty], [LimitPrice], [TotalQty], [StopPrice], [CreationDate], [UpdationDate]) VALUES (20, 1, 1, 3, 0, CAST(1000 AS Decimal(18, 0)), 2000, CAST(50 AS Decimal(18, 0)), CAST(N'2017-03-17 14:02:03.5135032' AS DateTime2), CAST(N'2017-03-17 14:02:03.5135032' AS DateTime2))
INSERT [dbo].[Block] ([BlockID], [UserID], [BlockStatusID], [SymbolID], [ExectuedQty], [LimitPrice], [TotalQty], [StopPrice], [CreationDate], [UpdationDate]) VALUES (21, 1, 1, 3, 4246, CAST(1000 AS Decimal(18, 0)), 6000, CAST(50 AS Decimal(18, 0)), CAST(N'2017-03-17 14:45:33.7255453' AS DateTime2), CAST(N'2017-03-17 14:45:33.7255453' AS DateTime2))
INSERT [dbo].[Block] ([BlockID], [UserID], [BlockStatusID], [SymbolID], [ExectuedQty], [LimitPrice], [TotalQty], [StopPrice], [CreationDate], [UpdationDate]) VALUES (22, 1, 1, 3, 0, CAST(1000 AS Decimal(18, 0)), 2000, CAST(50 AS Decimal(18, 0)), CAST(N'2017-03-17 14:47:16.4078125' AS DateTime2), CAST(N'2017-03-17 14:47:16.4078125' AS DateTime2))
INSERT [dbo].[Block] ([BlockID], [UserID], [BlockStatusID], [SymbolID], [ExectuedQty], [LimitPrice], [TotalQty], [StopPrice], [CreationDate], [UpdationDate]) VALUES (23, 1, 1, 1, 0, CAST(1000 AS Decimal(18, 0)), 4100, CAST(50 AS Decimal(18, 0)), CAST(N'2017-04-08 13:43:18.9942113' AS DateTime2), CAST(N'2017-04-08 13:43:18.9952113' AS DateTime2))
INSERT [dbo].[Block] ([BlockID], [UserID], [BlockStatusID], [SymbolID], [ExectuedQty], [LimitPrice], [TotalQty], [StopPrice], [CreationDate], [UpdationDate]) VALUES (24, 1, 1, 3, 0, CAST(1000 AS Decimal(18, 0)), 3000, CAST(50 AS Decimal(18, 0)), CAST(N'2017-04-08 15:46:13.8552113' AS DateTime2), CAST(N'2017-04-08 15:46:13.8552113' AS DateTime2))
INSERT [dbo].[Block] ([BlockID], [UserID], [BlockStatusID], [SymbolID], [ExectuedQty], [LimitPrice], [TotalQty], [StopPrice], [CreationDate], [UpdationDate]) VALUES (76, 1, 5, 1, 0, CAST(0 AS Decimal(18, 0)), 3434, CAST(0 AS Decimal(18, 0)), CAST(N'2017-05-05 11:17:33.1104361' AS DateTime2), CAST(N'2017-05-05 11:17:33.1104361' AS DateTime2))
INSERT [dbo].[Block] ([BlockID], [UserID], [BlockStatusID], [SymbolID], [ExectuedQty], [LimitPrice], [TotalQty], [StopPrice], [CreationDate], [UpdationDate]) VALUES (77, 4, 5, 2, 0, CAST(0 AS Decimal(18, 0)), 220, CAST(0 AS Decimal(18, 0)), CAST(N'2017-05-05 11:35:54.4127650' AS DateTime2), CAST(N'2017-05-05 11:35:54.4127650' AS DateTime2))
INSERT [dbo].[Block] ([BlockID], [UserID], [BlockStatusID], [SymbolID], [ExectuedQty], [LimitPrice], [TotalQty], [StopPrice], [CreationDate], [UpdationDate]) VALUES (78, 4, 5, 1, 0, CAST(0 AS Decimal(18, 0)), 110, CAST(0 AS Decimal(18, 0)), CAST(N'2017-05-05 11:40:53.0296237' AS DateTime2), CAST(N'2017-05-05 11:40:53.0296237' AS DateTime2))
INSERT [dbo].[Block] ([BlockID], [UserID], [BlockStatusID], [SymbolID], [ExectuedQty], [LimitPrice], [TotalQty], [StopPrice], [CreationDate], [UpdationDate]) VALUES (79, 1, 5, 2, 26128, CAST(0 AS Decimal(18, 0)), 124412, CAST(0 AS Decimal(18, 0)), CAST(N'2017-05-05 12:38:37.6378402' AS DateTime2), CAST(N'2017-05-05 12:38:37.6378402' AS DateTime2))
INSERT [dbo].[Block] ([BlockID], [UserID], [BlockStatusID], [SymbolID], [ExectuedQty], [LimitPrice], [TotalQty], [StopPrice], [CreationDate], [UpdationDate]) VALUES (80, 1, 5, 2, 0, CAST(0 AS Decimal(18, 0)), 1000, CAST(0 AS Decimal(18, 0)), CAST(N'2017-05-05 12:40:58.3919142' AS DateTime2), CAST(N'2017-05-05 12:40:58.3919142' AS DateTime2))
INSERT [dbo].[Block] ([BlockID], [UserID], [BlockStatusID], [SymbolID], [ExectuedQty], [LimitPrice], [TotalQty], [StopPrice], [CreationDate], [UpdationDate]) VALUES (81, 4, 5, 3, 0, CAST(0 AS Decimal(18, 0)), 123, CAST(0 AS Decimal(18, 0)), CAST(N'2017-05-05 13:00:08.2963336' AS DateTime2), CAST(N'2017-05-05 13:00:08.2963336' AS DateTime2))
INSERT [dbo].[Block] ([BlockID], [UserID], [BlockStatusID], [SymbolID], [ExectuedQty], [LimitPrice], [TotalQty], [StopPrice], [CreationDate], [UpdationDate]) VALUES (84, 1, 5, 1, 0, CAST(0 AS Decimal(18, 0)), 10000, CAST(0 AS Decimal(18, 0)), CAST(N'2017-05-05 13:12:37.6083189' AS DateTime2), CAST(N'2017-05-05 13:12:37.6083189' AS DateTime2))
INSERT [dbo].[Block] ([BlockID], [UserID], [BlockStatusID], [SymbolID], [ExectuedQty], [LimitPrice], [TotalQty], [StopPrice], [CreationDate], [UpdationDate]) VALUES (85, 4, 5, 2, 0, CAST(0 AS Decimal(18, 0)), 1000, CAST(0 AS Decimal(18, 0)), CAST(N'2017-05-05 13:28:15.8666278' AS DateTime2), CAST(N'2017-05-05 13:28:15.8666278' AS DateTime2))
INSERT [dbo].[Block] ([BlockID], [UserID], [BlockStatusID], [SymbolID], [ExectuedQty], [LimitPrice], [TotalQty], [StopPrice], [CreationDate], [UpdationDate]) VALUES (86, 4, 5, 3, 0, CAST(0 AS Decimal(18, 0)), 1000, CAST(0 AS Decimal(18, 0)), CAST(N'2017-05-05 13:28:18.1608572' AS DateTime2), CAST(N'2017-05-05 13:28:18.1608572' AS DateTime2))
INSERT [dbo].[Block] ([BlockID], [UserID], [BlockStatusID], [SymbolID], [ExectuedQty], [LimitPrice], [TotalQty], [StopPrice], [CreationDate], [UpdationDate]) VALUES (87, 4, 5, 1, 0, CAST(0 AS Decimal(18, 0)), 1000, CAST(0 AS Decimal(18, 0)), CAST(N'2017-05-05 13:28:21.4891900' AS DateTime2), CAST(N'2017-05-05 13:28:21.4891900' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Block] OFF
SET IDENTITY_INSERT [dbo].[Block_status] ON 

INSERT [dbo].[Block_status] ([BlockStatusId], [StatusName], [ISActive], [CreationDate], [UpdationDate]) VALUES (1, N'In Progress', 1, CAST(N'2017-03-03 00:00:00.0000000' AS DateTime2), CAST(N'2017-03-03 00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Block_status] ([BlockStatusId], [StatusName], [ISActive], [CreationDate], [UpdationDate]) VALUES (2, N'Partially Filled', 1, CAST(N'2017-03-03 00:00:00.0000000' AS DateTime2), CAST(N'2017-03-03 00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Block_status] ([BlockStatusId], [StatusName], [ISActive], [CreationDate], [UpdationDate]) VALUES (3, N'Completely Filled', 1, CAST(N'2017-03-03 00:00:00.0000000' AS DateTime2), CAST(N'2017-03-03 00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Block_status] ([BlockStatusId], [StatusName], [ISActive], [CreationDate], [UpdationDate]) VALUES (5, N'New', 1, CAST(N'2017-03-03 00:00:00.0000000' AS DateTime2), CAST(N'2017-03-03 00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Block_status] ([BlockStatusId], [StatusName], [ISActive], [CreationDate], [UpdationDate]) VALUES (11, N'Proposed', 1, CAST(N'2017-03-03 00:00:00.0000000' AS DateTime2), CAST(N'2017-03-03 00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Block_status] OFF
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (6, 4, 3, 1, 1, 2, CAST(350 AS Decimal(18, 0)), NULL, 0, 1000, NULL, N'Buy', 1, NULL, CAST(N'2016-12-12 00:00:00.0000000' AS DateTime2), CAST(N'2016-12-12 00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (7, 4, 4, 2, 1, 2, CAST(200 AS Decimal(18, 0)), NULL, 0, 1212, NULL, N'Sell', 2, NULL, CAST(N'2017-01-21 00:00:00.0000000' AS DateTime2), CAST(N'2017-01-21 00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (8, 4, 6, 1, 2, 2, CAST(350 AS Decimal(18, 0)), NULL, 0, 11111, NULL, N'Buy', 1, NULL, CAST(N'2017-02-28 00:00:00.0000000' AS DateTime2), CAST(N'2017-05-01 12:50:23.9505756' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (9, 4, 5, 2, 1, 3, CAST(350 AS Decimal(18, 0)), CAST(100 AS Decimal(18, 0)), 0, 12, NULL, N'Buy', 1, CAST(4 AS Decimal(18, 0)), CAST(N'2017-03-16 00:00:00.0000000' AS DateTime2), CAST(N'2017-03-16 00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (10, 4, 16, 1, 1, 2, CAST(200 AS Decimal(18, 0)), NULL, 0, 1000, NULL, N'Sell', 2, NULL, CAST(N'2017-03-16 14:21:40.0058771' AS DateTime2), CAST(N'2017-03-16 14:21:40.0058771' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (11, 4, 9, 1, 1, 3, CAST(200 AS Decimal(18, 0)), NULL, 0, 1000, NULL, N'Sell', 2, NULL, CAST(N'2017-03-16 14:22:32.3388771' AS DateTime2), CAST(N'2017-03-16 14:22:32.3388771' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (12, 4, 76, 1, 1, 2, CAST(350 AS Decimal(18, 0)), NULL, 0, 1212, NULL, N'Sell', 1, NULL, CAST(N'2017-03-16 14:31:00.8628771' AS DateTime2), CAST(N'2017-05-05 11:16:41.7032959' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (13, 4, 76, 1, 1, 2, CAST(350 AS Decimal(18, 0)), NULL, 0, 2222, NULL, N'Sell', 1, NULL, CAST(N'2017-03-16 14:34:11.4778771' AS DateTime2), CAST(N'2017-05-05 11:16:41.7092965' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (14, 4, 10, 1, 1, 2, CAST(200 AS Decimal(18, 0)), NULL, 0, 1000, NULL, N'Buy', 2, NULL, CAST(N'2017-03-16 14:35:41.5338771' AS DateTime2), CAST(N'2017-03-16 14:35:41.5338771' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (15, 4, 80, 1, 1, 2, CAST(200 AS Decimal(18, 0)), NULL, 0, 1000, NULL, N'Buy', 2, NULL, CAST(N'2017-03-16 14:37:22.8068771' AS DateTime2), CAST(N'2017-03-16 14:37:22.8068771' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (16, 4, 9, 1, 1, 2, CAST(200 AS Decimal(18, 0)), NULL, 0, 1000, NULL, N'Sell', 2, NULL, CAST(N'2017-03-16 14:41:17.6198771' AS DateTime2), CAST(N'2017-03-16 14:41:17.6198771' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (17, 4, 16, 1, 4, 2, CAST(200 AS Decimal(18, 0)), NULL, 0, 1000, NULL, N'Sell', 2, NULL, CAST(N'2017-03-16 15:00:21.6522750' AS DateTime2), CAST(N'2017-05-01 13:03:02.1173847' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (18, 4, 13, 1, 4, 2, CAST(200 AS Decimal(18, 0)), NULL, 0, 10000, NULL, N'Sell', 2, NULL, CAST(N'2017-03-16 15:47:50.1957989' AS DateTime2), CAST(N'2017-03-16 15:47:50.1957989' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (19, 4, 12, 1, 4, 2, CAST(350 AS Decimal(18, 0)), NULL, 0, 1000, NULL, N'Sell', 1, NULL, CAST(N'2017-03-16 15:50:18.5186297' AS DateTime2), CAST(N'2017-03-16 15:50:18.5186297' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (20, 4, 14, 1, 4, 2, CAST(0 AS Decimal(18, 0)), NULL, 0, 1000, NULL, N'Sell', 2, NULL, CAST(N'2017-03-17 08:47:49.1777511' AS DateTime2), CAST(N'2017-05-02 10:17:52.0697907' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (21, 4, 14, 1, 4, 2, CAST(200 AS Decimal(18, 0)), NULL, 0, 1000, NULL, N'Sell', 2, NULL, CAST(N'2017-03-17 08:50:11.0377511' AS DateTime2), CAST(N'2017-03-17 08:50:11.0377511' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (22, 4, NULL, 3, 54, 2, CAST(350 AS Decimal(18, 0)), NULL, 0, 200, NULL, N'Buy', 1, NULL, CAST(N'2017-03-17 09:34:42.6679839' AS DateTime2), CAST(N'2017-05-05 10:58:33.5004810' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (23, 4, 11, 1, 4, 2, CAST(350 AS Decimal(18, 0)), NULL, 0, 1212, NULL, N'Sell', 1, NULL, CAST(N'2017-03-17 10:03:29.2557511' AS DateTime2), CAST(N'2017-03-17 10:03:29.2557511' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (24, 4, 77, 3, 4, 2, CAST(200 AS Decimal(18, 0)), NULL, 0, 200, NULL, N'Sell', 2, NULL, CAST(N'2017-03-17 10:04:30.2019062' AS DateTime2), CAST(N'2017-05-05 10:58:33.5104820' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (25, 4, 7, 2, 4, 2, CAST(200 AS Decimal(18, 0)), NULL, 0, 3000, NULL, N'Sell', 2, NULL, CAST(N'2017-03-17 10:05:32.0249062' AS DateTime2), CAST(N'2017-05-03 09:16:17.8310956' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (26, 4, 15, 1, 4, 2, CAST(200 AS Decimal(18, 0)), NULL, 0, 500, NULL, N'Sell', 2, NULL, CAST(N'2017-03-17 10:06:12.1979062' AS DateTime2), CAST(N'2017-05-03 09:15:46.2239352' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (27, 4, 15, 1, 4, 2, CAST(200 AS Decimal(18, 0)), NULL, 0, 555, NULL, N'Sell', 2, NULL, CAST(N'2017-03-17 10:07:13.1357511' AS DateTime2), CAST(N'2017-05-01 16:32:24.5638321' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (28, 4, 77, 1, 4, 2, CAST(200 AS Decimal(18, 0)), NULL, 0, 20, NULL, N'Sell', 2, NULL, CAST(N'2017-03-17 11:08:47.0259302' AS DateTime2), CAST(N'2017-05-05 10:50:43.7815138' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (29, 4, 81, 1, 4, 2, CAST(300 AS Decimal(18, 0)), NULL, 0, 123, NULL, N'Sell', 3, NULL, CAST(N'2017-03-17 12:19:59.2581389' AS DateTime2), CAST(N'2017-05-03 09:18:23.2886401' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (30, 4, 18, 1, 62, 3, CAST(389 AS Decimal(18, 0)), NULL, 0, 10000, NULL, N'Buy', 1, NULL, CAST(N'2017-03-17 12:24:26.3458450' AS DateTime2), CAST(N'2017-03-17 12:24:26.3458450' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (31, 4, NULL, 8, 4, 2, CAST(300 AS Decimal(18, 0)), NULL, 0, 1234, NULL, N'Buy', 3, NULL, CAST(N'2017-03-17 13:36:57.2268896' AS DateTime2), CAST(N'2017-05-05 13:06:38.8389380' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (32, 4, 19, 1, 4, 2, CAST(201 AS Decimal(18, 0)), NULL, 0, 4321, NULL, N'Sell', 2, NULL, CAST(N'2017-03-17 13:37:31.8413507' AS DateTime2), CAST(N'2017-03-17 13:37:31.8413507' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (33, 4, 19, 1, 4, 2, CAST(201 AS Decimal(18, 0)), NULL, 0, 1220, NULL, N'Sell', 2, NULL, CAST(N'2017-03-17 13:38:11.2682930' AS DateTime2), CAST(N'2017-03-17 13:38:11.2682930' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (34, 4, 21, 1, 4, 3, CAST(300 AS Decimal(18, 0)), NULL, 0, 4000, NULL, N'Buy', 3, NULL, CAST(N'2017-03-17 13:52:27.2848861' AS DateTime2), CAST(N'2017-03-17 13:52:27.2848861' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (35, 4, NULL, 1, 4, 2, CAST(0 AS Decimal(18, 0)), NULL, 0, 300, NULL, N'Sell', 1, NULL, CAST(N'2017-03-17 13:52:38.1619737' AS DateTime2), CAST(N'2017-05-05 13:06:54.1894729' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (36, 4, 23, 1, 4, 2, CAST(387 AS Decimal(18, 0)), NULL, 0, 2000, NULL, N'Buy', 1, NULL, CAST(N'2017-03-17 13:52:53.7715345' AS DateTime2), CAST(N'2017-03-17 13:52:53.7715345' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (37, 4, 21, 1, 4, 2, CAST(300 AS Decimal(18, 0)), NULL, 0, 2000, NULL, N'Buy', 3, NULL, CAST(N'2017-03-17 13:56:22.4914044' AS DateTime2), CAST(N'2017-03-17 13:56:22.4914044' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (38, 4, 20, 1, 4, 2, CAST(300 AS Decimal(18, 0)), NULL, 0, 2000, NULL, N'Buy', 3, NULL, CAST(N'2017-03-17 13:59:23.3284863' AS DateTime2), CAST(N'2017-03-17 13:59:23.3284863' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (39, 4, 23, 1, 4, 2, CAST(387 AS Decimal(18, 0)), NULL, 0, 2000, NULL, N'Buy', 1, NULL, CAST(N'2017-03-17 13:59:37.8479381' AS DateTime2), CAST(N'2017-03-17 13:59:37.8479381' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (40, 4, 23, 1, 4, 2, CAST(387 AS Decimal(18, 0)), NULL, 0, 1000, NULL, N'Buy', 1, NULL, CAST(N'2017-03-17 13:59:46.1247657' AS DateTime2), CAST(N'2017-04-28 16:30:41.4306833' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (41, 4, 11, 1, 4, 2, CAST(300 AS Decimal(18, 0)), NULL, 0, 5000, NULL, N'Sell', 3, NULL, CAST(N'2017-03-17 13:59:55.6177149' AS DateTime2), CAST(N'2017-04-28 16:30:53.1638565' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (42, 4, 24, 1, 4, 2, CAST(300 AS Decimal(18, 0)), NULL, 0, 3000, NULL, N'Buy', 3, NULL, CAST(N'2017-03-17 14:00:05.1496680' AS DateTime2), CAST(N'2017-03-17 14:00:05.1496680' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (43, 4, 10, 1, 4, 2, CAST(201 AS Decimal(18, 0)), NULL, 0, 12, NULL, N'Buy', 2, NULL, CAST(N'2017-03-17 14:40:58.4510206' AS DateTime2), CAST(N'2017-03-17 14:40:58.4510206' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (44, 4, 22, 1, 4, 2, CAST(300 AS Decimal(18, 0)), NULL, 0, 2000, NULL, N'Buy', 3, NULL, CAST(N'2017-03-17 14:41:59.8261575' AS DateTime2), CAST(N'2017-03-17 14:41:59.8261575' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (60, 6, 84, 3, 1, 2, CAST(201 AS Decimal(18, 0)), NULL, 0, 10000, CAST(N'2017-05-04 11:47:05.4865248' AS DateTime2), N'Sell', 1, CAST(211 AS Decimal(18, 0)), CAST(N'2017-05-03 11:47:05.4865248' AS DateTime2), CAST(N'2017-05-05 10:50:43.7935150' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (61, 7, NULL, 3, 1, 5, CAST(201 AS Decimal(18, 0)), CAST(200 AS Decimal(18, 0)), 0, 10000, CAST(N'2017-05-04 12:09:43.4313057' AS DateTime2), N'Buy', 1, CAST(199 AS Decimal(18, 0)), CAST(N'2017-05-03 12:09:43.4313057' AS DateTime2), CAST(N'2017-05-04 10:34:45.5709906' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (66, 4, NULL, 6, 4, 5, CAST(392 AS Decimal(18, 0)), NULL, 0, 2500, CAST(N'2017-05-04 16:19:04.6967533' AS DateTime2), N'Buy', 1, NULL, CAST(N'2017-05-03 16:19:04.6967533' AS DateTime2), CAST(N'2017-05-04 10:34:45.5669902' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (68, 7, NULL, 3, 1, 2, CAST(392 AS Decimal(18, 0)), CAST(100 AS Decimal(18, 0)), 0, 1000, CAST(N'2017-05-05 10:35:42.8510574' AS DateTime2), N'Sell', 1, CAST(100 AS Decimal(18, 0)), CAST(N'2017-05-04 10:35:42.8510574' AS DateTime2), CAST(N'2017-05-05 09:24:56.6798551' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (69, 6, 79, 1, 1, 5, CAST(201 AS Decimal(18, 0)), NULL, 0, 1000, CAST(N'2017-05-05 11:04:47.5734831' AS DateTime2), N'Buy', 2, CAST(100 AS Decimal(18, 0)), CAST(N'2017-05-04 11:04:47.5734831' AS DateTime2), CAST(N'2017-05-04 11:04:47.5734831' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (70, 7, NULL, 19, 1, 2, CAST(392 AS Decimal(18, 0)), CAST(200 AS Decimal(18, 0)), 0, 400, CAST(N'2017-05-05 11:06:06.3371300' AS DateTime2), N'Buy', 1, CAST(450 AS Decimal(18, 0)), CAST(N'2017-05-04 11:06:06.3381301' AS DateTime2), CAST(N'2017-05-05 10:03:30.1901830' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (72, 6, 79, 6, 4, 2, CAST(201 AS Decimal(18, 0)), NULL, 0, 123412, CAST(N'2017-05-06 09:55:50.8463940' AS DateTime2), N'Buy', 2, CAST(1234 AS Decimal(18, 0)), CAST(N'2017-05-05 09:55:50.8463940' AS DateTime2), CAST(N'2017-05-05 09:55:50.8463940' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (73, 4, 78, 6, 4, 2, CAST(392 AS Decimal(18, 0)), NULL, 0, 55, CAST(N'2017-05-06 10:36:03.9106763' AS DateTime2), N'Buy', 1, NULL, CAST(N'2017-05-05 10:36:03.9106763' AS DateTime2), CAST(N'2017-05-05 10:36:21.2894140' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (75, 4, 78, 6, 4, 2, CAST(392 AS Decimal(18, 0)), NULL, 0, 55, CAST(N'2017-05-06 10:53:56.9279673' AS DateTime2), N'Buy', 1, NULL, CAST(N'2017-05-05 10:53:56.9279673' AS DateTime2), CAST(N'2017-05-05 10:53:56.9279673' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (76, 4, NULL, 6, 4, 5, CAST(201 AS Decimal(18, 0)), NULL, 0, 523, CAST(N'2017-05-06 10:57:26.9759700' AS DateTime2), N'Buy', 2, NULL, CAST(N'2017-05-05 10:57:26.9759700' AS DateTime2), CAST(N'2017-05-05 10:57:26.9759700' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (77, 4, NULL, 6, 4, 5, CAST(300 AS Decimal(18, 0)), NULL, 0, 1256, CAST(N'2017-05-06 11:08:20.3813040' AS DateTime2), N'Buy', 3, NULL, CAST(N'2017-05-05 11:08:20.3813040' AS DateTime2), CAST(N'2017-05-05 11:08:20.3813040' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (78, 4, 85, 6, 4, 2, CAST(164 AS Decimal(18, 0)), NULL, 0, 1000, CAST(N'2017-05-06 13:26:24.3104733' AS DateTime2), N'Sell', 2, NULL, CAST(N'2017-05-05 13:26:24.3104733' AS DateTime2), CAST(N'2017-05-05 13:26:24.3104733' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (79, 4, 86, 6, 4, 2, CAST(280 AS Decimal(18, 0)), NULL, 0, 1000, CAST(N'2017-05-06 13:26:45.5115932' AS DateTime2), N'Sell', 3, NULL, CAST(N'2017-05-05 13:26:45.5115932' AS DateTime2), CAST(N'2017-05-05 13:26:45.5115932' AS DateTime2))
INSERT [dbo].[Order] ([OrderID], [OrderTypeID], [BlockID], [PortfolioID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (80, 4, 87, 6, 4, 2, CAST(432 AS Decimal(18, 0)), NULL, 0, 1000, CAST(N'2017-05-06 13:26:56.0306450' AS DateTime2), N'Sell', 1, NULL, CAST(N'2017-05-05 13:26:56.0306450' AS DateTime2), CAST(N'2017-05-05 13:26:56.0306450' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Order] OFF
SET IDENTITY_INSERT [dbo].[Order_Status] ON 

INSERT [dbo].[Order_Status] ([OrderStatusID], [StatusName], [ISActive], [CreationDate], [UpdationDate]) VALUES (1, N'Filled', 1, CAST(N'2017-02-24 11:43:00.0000000' AS DateTime2), CAST(N'2017-02-24 11:43:00.0000000' AS DateTime2))
INSERT [dbo].[Order_Status] ([OrderStatusID], [StatusName], [ISActive], [CreationDate], [UpdationDate]) VALUES (2, N'Pending', 1, CAST(N'2017-02-24 11:43:00.0000000' AS DateTime2), CAST(N'2017-02-24 11:43:00.0000000' AS DateTime2))
INSERT [dbo].[Order_Status] ([OrderStatusID], [StatusName], [ISActive], [CreationDate], [UpdationDate]) VALUES (3, N'Partially Filled', 1, CAST(N'2017-03-03 00:00:00.0000000' AS DateTime2), CAST(N'2017-03-03 00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Order_Status] ([OrderStatusID], [StatusName], [ISActive], [CreationDate], [UpdationDate]) VALUES (5, N'Saved', 1, CAST(N'2017-04-28 11:18:30.0000000' AS DateTime2), CAST(N'2017-04-28 11:18:30.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Order_Status] OFF
SET IDENTITY_INSERT [dbo].[Order_Type] ON 

INSERT [dbo].[Order_Type] ([OrderTypeID], [OrderTypeName]) VALUES (4, N'Market Order')
INSERT [dbo].[Order_Type] ([OrderTypeID], [OrderTypeName]) VALUES (5, N'Limit Order')
INSERT [dbo].[Order_Type] ([OrderTypeID], [OrderTypeName]) VALUES (6, N'Stop Order')
INSERT [dbo].[Order_Type] ([OrderTypeID], [OrderTypeName]) VALUES (7, N'Stop Limit Order')
SET IDENTITY_INSERT [dbo].[Order_Type] OFF
INSERT [dbo].[orders] ([OrderID], [OrderTypeID], [BlockID], [RiskClassID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (N'4', N'4', N'20', N'1', N'1', N'2', N'NULL', N'234', N'0', N'1212', N'NULL', N'Buy', N'1', N'NULL', N'2017-03-15 15:19:28.5382626', N'2017-03-15 15:19:28.5382626')
INSERT [dbo].[orders] ([OrderID], [OrderTypeID], [BlockID], [RiskClassID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (N'5', N'4', N'20', N'1', N'1', N'2', N'NULL', N'NULL', N'0', N'1212', N'NULL', N'Buy', N'1', N'NULL', N'2017-03-15 15:20:15.1762626', N'2017-03-15 15:20:15.6862626')
INSERT [dbo].[orders] ([OrderID], [OrderTypeID], [BlockID], [RiskClassID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (N'6', N'4', N'6', N'1', N'1', N'2', N'NULL', N'NULL', N'0', N'1214251', N'NULL', N'Buy', N'1', N'NULL', N'2017-03-15 15:38:07.2412626', N'2017-03-15 15:38:07.2412626')
INSERT [dbo].[orders] ([OrderID], [OrderTypeID], [BlockID], [RiskClassID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (N'7', N'4', N'1', N'1', N'1', N'2', N'NULL', N'NULL', N'0', N'1214', N'NULL', N'Buy', N'1', N'NULL', N'2017-03-15 15:38:17.4022626', N'2017-03-15 15:38:17.4022626')
INSERT [dbo].[orders] ([OrderID], [OrderTypeID], [BlockID], [RiskClassID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (N'8', N'4', N'1', N'1', N'1', N'2', N'NULL', N'NULL', N'0', N'1214', N'NULL', N'Buy', N'1', N'NULL', N'2017-03-15 15:39:07.7102626', N'2017-03-15 15:39:07.7102626')
INSERT [dbo].[orders] ([OrderID], [OrderTypeID], [BlockID], [RiskClassID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (N'9', N'4', N'15', N'1', N'1', N'2', N'NULL', N'NULL', N'0', N'212', N'NULL', N'Sell', N'1', N'NULL', N'2017-03-15 15:41:56.1242626', N'2017-03-15 15:41:56.1242626')
INSERT [dbo].[orders] ([OrderID], [OrderTypeID], [BlockID], [RiskClassID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (N'10', N'4', N'NULL', N'1', N'1', N'2', N'NULL', N'NULL', N'0', N'212', N'NULL', N'Buy', N'1', N'NULL', N'2017-03-15 15:43:25.5582626', N'2017-03-15 15:43:26.0742626')
INSERT [dbo].[orders] ([OrderID], [OrderTypeID], [BlockID], [RiskClassID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (N'11', N'4', N'15', N'1', N'1', N'2', N'NULL', N'NULL', N'0', N'2332', N'NULL', N'Sell', N'1', N'NULL', N'2017-03-15 15:45:15.0752626', N'2017-03-15 15:45:15.3432626')
INSERT [dbo].[orders] ([OrderID], [OrderTypeID], [BlockID], [RiskClassID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (N'12', N'4', N'1', N'1', N'1', N'2', N'NULL', N'NULL', N'0', N'1212', N'NULL', N'Buy', N'1', N'NULL', N'2017-03-15 15:56:06.8232626', N'2017-03-15 15:56:07.2972626')
INSERT [dbo].[orders] ([OrderID], [OrderTypeID], [BlockID], [RiskClassID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (N'13', N'5', N'2', N'2', N'1', N'2', N'NULL', N'NULL', N'0', N'1000', N'NULL', N'Buy', N'2', N'NULL', N'2017-03-03 00:00:00.0000000', N'2017-03-03 00:00:00.0000000')
INSERT [dbo].[orders] ([OrderID], [OrderTypeID], [BlockID], [RiskClassID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (N'17', N'4', N'19', N'1', N'1', N'2', N'NULL', N'NULL', N'50', N'1000', N'NULL', N'Buy', N'1', N'NULL', N'2017-03-16 00:00:00.0000000', N'2017-03-16 00:00:00.0000000')
INSERT [dbo].[orders] ([OrderID], [OrderTypeID], [BlockID], [RiskClassID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (N'18', N'4', N'18', N'1', N'1', N'2', N'NULL', N'NULL', N'20', N'1200', N'NULL', N'Buy', N'1', N'NULL', N'2017-03-16 00:00:00.0000000', N'2017-03-16 00:00:00.0000000')
INSERT [dbo].[orders] ([OrderID], [OrderTypeID], [BlockID], [RiskClassID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (N'19', N'4', N'18', N'1', N'1', N'2', N'NULL', N'NULL', N'10', N'500', N'NULL', N'Buy', N'1', N'NULL', N'2017-03-16 00:00:00.0000000', N'2017-03-16 00:00:00.0000000')
INSERT [dbo].[orders] ([OrderID], [OrderTypeID], [BlockID], [RiskClassID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (N'20', N'4', N'16', N'1', N'1', N'2', N'NULL', N'NULL', N'0', N'2000', N'NULL', N'Buy', N'6', N'NULL', N'2017-03-16 00:00:00.0000000', N'2017-03-16 00:00:00.0000000')
INSERT [dbo].[orders] ([OrderID], [OrderTypeID], [BlockID], [RiskClassID], [PMID], [OrderStatusID], [MarketPrice], [LimitPrice], [AllocatedQty], [TotalQty], [ExpiryDate], [Side], [SymbolID], [StopPrice], [CreationDate], [UpdationDate]) VALUES (N'21', N'4', N'17', N'1', N'1', N'2', N'NULL', N'NULL', N'0', N'1000', N'NULL', N'Sell', N'6', N'NULL', N'2017-03-16 00:00:00.0000000', N'2017-03-16 00:00:00.0000000')
SET IDENTITY_INSERT [dbo].[Portfolio] ON 

INSERT [dbo].[Portfolio] ([PortfolioID], [PortfolioName], [ISActive], [CreationDate], [UpdationDate], [UserID]) VALUES (1, N'PQR', 1, CAST(N'2017-03-14 18:54:40.0000000' AS DateTime2), CAST(N'2017-03-14 18:54:40.1673071' AS DateTime2), 1)
INSERT [dbo].[Portfolio] ([PortfolioID], [PortfolioName], [ISActive], [CreationDate], [UpdationDate], [UserID]) VALUES (2, N'XYZ', 1, CAST(N'2017-03-14 18:54:40.0000000' AS DateTime2), CAST(N'2017-03-14 18:55:47.3233071' AS DateTime2), 1)
INSERT [dbo].[Portfolio] ([PortfolioID], [PortfolioName], [ISActive], [CreationDate], [UpdationDate], [UserID]) VALUES (3, N'MNO', 1, CAST(N'2017-03-14 18:54:40.0000000' AS DateTime2), CAST(N'2017-03-14 18:15:12.1331771' AS DateTime2), 1)
INSERT [dbo].[Portfolio] ([PortfolioID], [PortfolioName], [ISActive], [CreationDate], [UpdationDate], [UserID]) VALUES (6, N'ABC', 1, CAST(N'2017-03-14 18:54:40.0000000' AS DateTime2), CAST(N'2017-03-02 18:00:10.0000000' AS DateTime2), 1)
INSERT [dbo].[Portfolio] ([PortfolioID], [PortfolioName], [ISActive], [CreationDate], [UpdationDate], [UserID]) VALUES (7, N'IJK', 1, CAST(N'2017-03-14 18:54:40.0000000' AS DateTime2), CAST(N'2017-03-15 23:02:45.3733003' AS DateTime2), 1)
INSERT [dbo].[Portfolio] ([PortfolioID], [PortfolioName], [ISActive], [CreationDate], [UpdationDate], [UserID]) VALUES (8, N'DEF', 1, CAST(N'2017-03-14 18:54:40.0000000' AS DateTime2), CAST(N'2017-03-15 23:02:54.6792308' AS DateTime2), 1)
INSERT [dbo].[Portfolio] ([PortfolioID], [PortfolioName], [ISActive], [CreationDate], [UpdationDate], [UserID]) VALUES (9, N'GHI', 1, CAST(N'2017-03-14 18:54:40.0000000' AS DateTime2), CAST(N'2017-03-15 23:03:04.9022530' AS DateTime2), NULL)
INSERT [dbo].[Portfolio] ([PortfolioID], [PortfolioName], [ISActive], [CreationDate], [UpdationDate], [UserID]) VALUES (10, N'TUV', 0, CAST(N'2017-03-14 18:54:40.0000000' AS DateTime2), CAST(N'2017-03-15 23:03:11.9489576' AS DateTime2), NULL)
INSERT [dbo].[Portfolio] ([PortfolioID], [PortfolioName], [ISActive], [CreationDate], [UpdationDate], [UserID]) VALUES (11, N'DNB', 0, CAST(N'2017-03-14 18:54:40.0000000' AS DateTime2), CAST(N'2017-03-15 23:14:19.5487109' AS DateTime2), NULL)
INSERT [dbo].[Portfolio] ([PortfolioID], [PortfolioName], [ISActive], [CreationDate], [UpdationDate], [UserID]) VALUES (12, N'LMK', 0, CAST(N'2017-03-17 09:44:19.7459580' AS DateTime2), CAST(N'2017-03-17 09:44:19.7459580' AS DateTime2), NULL)
INSERT [dbo].[Portfolio] ([PortfolioID], [PortfolioName], [ISActive], [CreationDate], [UpdationDate], [UserID]) VALUES (13, N'PLO', 1, CAST(N'2017-03-17 09:56:19.8039062' AS DateTime2), CAST(N'2017-03-17 09:56:19.8039062' AS DateTime2), NULL)
INSERT [dbo].[Portfolio] ([PortfolioID], [PortfolioName], [ISActive], [CreationDate], [UpdationDate], [UserID]) VALUES (14, N'UJG', 1, CAST(N'2017-03-17 12:13:32.0000000' AS DateTime2), CAST(N'2017-03-17 12:13:32.9906248' AS DateTime2), NULL)
INSERT [dbo].[Portfolio] ([PortfolioID], [PortfolioName], [ISActive], [CreationDate], [UpdationDate], [UserID]) VALUES (15, N'XYZ', 1, CAST(N'2017-03-17 14:31:13.5962415' AS DateTime2), CAST(N'2017-03-17 14:31:13.5962415' AS DateTime2), NULL)
INSERT [dbo].[Portfolio] ([PortfolioID], [PortfolioName], [ISActive], [CreationDate], [UpdationDate], [UserID]) VALUES (16, N'XYZ', 1, CAST(N'2017-03-17 14:31:24.8032415' AS DateTime2), CAST(N'2017-03-17 14:31:24.8032415' AS DateTime2), NULL)
INSERT [dbo].[Portfolio] ([PortfolioID], [PortfolioName], [ISActive], [CreationDate], [UpdationDate], [UserID]) VALUES (17, N'ABC', 1, CAST(N'2017-05-03 12:28:48.6048116' AS DateTime2), CAST(N'2017-05-03 12:28:48.6058117' AS DateTime2), 4)
INSERT [dbo].[Portfolio] ([PortfolioID], [PortfolioName], [ISActive], [CreationDate], [UpdationDate], [UserID]) VALUES (18, N'MyPorfolio', 1, CAST(N'2017-05-03 15:44:10.8244178' AS DateTime2), CAST(N'2017-05-03 15:44:10.8244178' AS DateTime2), 69)
INSERT [dbo].[Portfolio] ([PortfolioID], [PortfolioName], [ISActive], [CreationDate], [UpdationDate], [UserID]) VALUES (19, N'A23', 1, CAST(N'2017-05-04 10:42:08.2153322' AS DateTime2), CAST(N'2017-05-04 10:42:08.2153322' AS DateTime2), 12)
INSERT [dbo].[Portfolio] ([PortfolioID], [PortfolioName], [ISActive], [CreationDate], [UpdationDate], [UserID]) VALUES (20, N'A23', 1, CAST(N'2017-05-04 10:47:24.1859261' AS DateTime2), CAST(N'2017-05-04 10:47:24.1859261' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Portfolio] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleID], [RoleType], [ISActive], [CreationDate], [UpdationDate]) VALUES (1, N'Trader', 1, CAST(N'2017-03-03 00:00:00.0000000' AS DateTime2), CAST(N'2017-03-03 00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Role] ([RoleID], [RoleType], [ISActive], [CreationDate], [UpdationDate]) VALUES (2, N'PM', 1, CAST(N'2017-03-03 00:00:00.0000000' AS DateTime2), CAST(N'2017-03-03 00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Role] ([RoleID], [RoleType], [ISActive], [CreationDate], [UpdationDate]) VALUES (3, N'Admin', 1, CAST(N'2017-03-03 00:00:00.0000000' AS DateTime2), CAST(N'2017-03-03 00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[Symbol_Properties] ON 

INSERT [dbo].[Symbol_Properties] ([SymbolID], [Symbol], [Name], [Price]) VALUES (1, N'INFY', N'Infosys', CAST(432.00 AS Decimal(18, 2)))
INSERT [dbo].[Symbol_Properties] ([SymbolID], [Symbol], [Name], [Price]) VALUES (2, N'RIL', N'Reliance', CAST(164.00 AS Decimal(18, 2)))
INSERT [dbo].[Symbol_Properties] ([SymbolID], [Symbol], [Name], [Price]) VALUES (3, N'ONG', N'ONGC', CAST(280.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Symbol_Properties] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [FName], [LName], [UserName], [PassWord], [ISActive], [CreationDate], [UpdationDate]) VALUES (1, N'Akshay', N'ABC', N'ABC', N'password', 1, CAST(N'2017-03-03 00:00:00.0000000' AS DateTime2), CAST(N'2017-03-03 00:00:00.0000000' AS DateTime2))
INSERT [dbo].[User] ([UserID], [FName], [LName], [UserName], [PassWord], [ISActive], [CreationDate], [UpdationDate]) VALUES (2, N'Kashish', N'456', N'BC', N'password', 0, CAST(N'2017-03-03 00:00:00.0000000' AS DateTime2), CAST(N'2017-03-03 00:00:00.0000000' AS DateTime2))
INSERT [dbo].[User] ([UserID], [FName], [LName], [UserName], [PassWord], [ISActive], [CreationDate], [UpdationDate]) VALUES (3, N'Meena', N'dsdasd', N'cde', N'password', 0, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2017-03-14 19:08:40.9103071' AS DateTime2))
INSERT [dbo].[User] ([UserID], [FName], [LName], [UserName], [PassWord], [ISActive], [CreationDate], [UpdationDate]) VALUES (4, N'Renu123', N'Bansal', N'renu', N'bansal', 1, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2017-05-03 00:00:00.0000000' AS DateTime2))
INSERT [dbo].[User] ([UserID], [FName], [LName], [UserName], [PassWord], [ISActive], [CreationDate], [UpdationDate]) VALUES (5, N'Tina', N'xyz', N'xyz', N'password', 0, CAST(N'2017-03-15 00:38:18.8004214' AS DateTime2), CAST(N'2017-03-15 00:38:18.8004214' AS DateTime2))
INSERT [dbo].[User] ([UserID], [FName], [LName], [UserName], [PassWord], [ISActive], [CreationDate], [UpdationDate]) VALUES (6, N'Mayank', N'Gupta', N'mayank', N'gupta', 1, CAST(N'2017-03-15 10:42:53.8363748' AS DateTime2), CAST(N'2017-03-15 10:42:53.8363748' AS DateTime2))
INSERT [dbo].[User] ([UserID], [FName], [LName], [UserName], [PassWord], [ISActive], [CreationDate], [UpdationDate]) VALUES (7, N'Neha', N'Sharma', N'neha', N'sharma', 1, CAST(N'2017-03-15 11:04:25.5855368' AS DateTime2), CAST(N'2017-03-15 11:04:25.5855368' AS DateTime2))
INSERT [dbo].[User] ([UserID], [FName], [LName], [UserName], [PassWord], [ISActive], [CreationDate], [UpdationDate]) VALUES (8, N'Manisha', N'ban', N'ren', N'password', 0, CAST(N'2017-03-15 11:20:43.7623447' AS DateTime2), CAST(N'2017-03-15 11:20:43.7623447' AS DateTime2))
INSERT [dbo].[User] ([UserID], [FName], [LName], [UserName], [PassWord], [ISActive], [CreationDate], [UpdationDate]) VALUES (9, N'Miya', N'cba', N'cba', N'password', 1, CAST(N'2017-03-15 11:23:24.7154384' AS DateTime2), CAST(N'2017-05-03 00:00:00.0000000' AS DateTime2))
INSERT [dbo].[User] ([UserID], [FName], [LName], [UserName], [PassWord], [ISActive], [CreationDate], [UpdationDate]) VALUES (10, N'Reema', N'Bansal', N'reema', N'password', 1, CAST(N'2017-03-15 11:25:09.0518710' AS DateTime2), CAST(N'2017-03-15 11:25:09.0518710' AS DateTime2))
INSERT [dbo].[User] ([UserID], [FName], [LName], [UserName], [PassWord], [ISActive], [CreationDate], [UpdationDate]) VALUES (11, N'Neha', N'Gupta', N'username', N'password', 1, CAST(N'2017-03-15 11:29:12.1031737' AS DateTime2), CAST(N'2017-03-15 11:29:12.1031737' AS DateTime2))
INSERT [dbo].[User] ([UserID], [FName], [LName], [UserName], [PassWord], [ISActive], [CreationDate], [UpdationDate]) VALUES (12, N'Akshay', N'Sharma', N'akshay', N'sharma', 1, CAST(N'2017-03-15 12:36:24.4803711' AS DateTime2), CAST(N'2017-03-15 12:36:24.4803711' AS DateTime2))
INSERT [dbo].[User] ([UserID], [FName], [LName], [UserName], [PassWord], [ISActive], [CreationDate], [UpdationDate]) VALUES (13, N'Nisha', N'XYZ', N'pqr', N'password', 1, CAST(N'2017-03-15 12:54:04.8904015' AS DateTime2), CAST(N'2017-03-15 12:54:04.8904015' AS DateTime2))
INSERT [dbo].[User] ([UserID], [FName], [LName], [UserName], [PassWord], [ISActive], [CreationDate], [UpdationDate]) VALUES (14, N'Nishi', N'XYZ', N'pqr2', N'password', 1, CAST(N'2017-03-15 12:54:57.1236243' AS DateTime2), CAST(N'2017-03-15 12:54:57.1236243' AS DateTime2))
INSERT [dbo].[User] ([UserID], [FName], [LName], [UserName], [PassWord], [ISActive], [CreationDate], [UpdationDate]) VALUES (15, N'Kiya', N'abc', N'abc', N'password', 1, CAST(N'2017-03-15 13:01:58.2827360' AS DateTime2), CAST(N'2017-03-15 13:01:58.2827360' AS DateTime2))
INSERT [dbo].[User] ([UserID], [FName], [LName], [UserName], [PassWord], [ISActive], [CreationDate], [UpdationDate]) VALUES (16, N'Tiya', N'riya', N'riya', N'password', 1, CAST(N'2017-03-15 13:04:17.9387002' AS DateTime2), CAST(N'2017-03-15 13:04:17.9387002' AS DateTime2))
INSERT [dbo].[User] ([UserID], [FName], [LName], [UserName], [PassWord], [ISActive], [CreationDate], [UpdationDate]) VALUES (17, N'Riya', N'riya', N'riya2', N'password', 0, CAST(N'2017-03-15 13:05:27.5536610' AS DateTime2), CAST(N'2017-03-15 13:05:27.5536610' AS DateTime2))
INSERT [dbo].[User] ([UserID], [FName], [LName], [UserName], [PassWord], [ISActive], [CreationDate], [UpdationDate]) VALUES (18, N'Meenu', N'min', N'min', N'password', 1, CAST(N'2017-03-15 13:05:47.0756130' AS DateTime2), CAST(N'2017-03-15 13:05:47.0756130' AS DateTime2))
INSERT [dbo].[User] ([UserID], [FName], [LName], [UserName], [PassWord], [ISActive], [CreationDate], [UpdationDate]) VALUES (19, N'yogita', N'gupta', N'yogi', N'password', 1, CAST(N'2017-03-15 13:13:19.9278937' AS DateTime2), CAST(N'2017-03-15 13:13:19.9278937' AS DateTime2))
INSERT [dbo].[User] ([UserID], [FName], [LName], [UserName], [PassWord], [ISActive], [CreationDate], [UpdationDate]) VALUES (20, N'Kiya', N'dhdh', N'dyd', N'password', 0, CAST(N'2017-03-15 13:14:00.1149120' AS DateTime2), CAST(N'2017-03-15 13:14:00.1149120' AS DateTime2))
INSERT [dbo].[User] ([UserID], [FName], [LName], [UserName], [PassWord], [ISActive], [CreationDate], [UpdationDate]) VALUES (21, N'rishabh', N'kashyap', N'rikash', N'yap12', 1, CAST(N'2017-03-15 14:18:03.8126133' AS DateTime2), CAST(N'2017-03-15 14:18:03.8126133' AS DateTime2))
INSERT [dbo].[User] ([UserID], [FName], [LName], [UserName], [PassWord], [ISActive], [CreationDate], [UpdationDate]) VALUES (54, N'Karan', N'Malik', N'KaranM', N'12345', 1, CAST(N'2017-03-17 09:32:27.3229839' AS DateTime2), CAST(N'2017-03-17 09:32:27.3229839' AS DateTime2))
INSERT [dbo].[User] ([UserID], [FName], [LName], [UserName], [PassWord], [ISActive], [CreationDate], [UpdationDate]) VALUES (60, N'Megha', N'Soni', N'megha', N'soni', 1, CAST(N'2017-03-17 12:05:38.2956248' AS DateTime2), CAST(N'2017-03-17 12:05:38.2956248' AS DateTime2))
INSERT [dbo].[User] ([UserID], [FName], [LName], [UserName], [PassWord], [ISActive], [CreationDate], [UpdationDate]) VALUES (61, N'admin', N'admin', N'admin', N'password', 1, CAST(N'2017-03-17 12:20:45.4647591' AS DateTime2), CAST(N'2017-03-17 12:20:45.4647591' AS DateTime2))
INSERT [dbo].[User] ([UserID], [FName], [LName], [UserName], [PassWord], [ISActive], [CreationDate], [UpdationDate]) VALUES (62, N'Nikita', N'Sinha', N'nikita', N'password', 1, CAST(N'2017-03-17 12:23:45.3537462' AS DateTime2), CAST(N'2017-03-17 12:23:45.3537462' AS DateTime2))
INSERT [dbo].[User] ([UserID], [FName], [LName], [UserName], [PassWord], [ISActive], [CreationDate], [UpdationDate]) VALUES (63, N'Ankur', N'Tomar', N'ankur', N'ankur', 1, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2017-03-17 13:55:48.5230079' AS DateTime2))
INSERT [dbo].[User] ([UserID], [FName], [LName], [UserName], [PassWord], [ISActive], [CreationDate], [UpdationDate]) VALUES (64, N'Shivam', N'Sandilya', N'shivam', N'sandliya', 1, CAST(N'2017-03-17 14:00:15.0856615' AS DateTime2), CAST(N'2017-03-17 14:00:15.0856615' AS DateTime2))
INSERT [dbo].[User] ([UserID], [FName], [LName], [UserName], [PassWord], [ISActive], [CreationDate], [UpdationDate]) VALUES (65, N'Samyak', N'Puri', N'sam', N'puri', 1, CAST(N'2017-03-17 14:22:42.5430583' AS DateTime2), CAST(N'2017-05-03 00:00:00.0000000' AS DateTime2))
INSERT [dbo].[User] ([UserID], [FName], [LName], [UserName], [PassWord], [ISActive], [CreationDate], [UpdationDate]) VALUES (66, N'Shivam', N'Sandilya', N'shiv', N'password', 1, CAST(N'2017-03-17 14:23:17.0896033' AS DateTime2), CAST(N'2017-03-17 14:23:17.0896033' AS DateTime2))
INSERT [dbo].[User] ([UserID], [FName], [LName], [UserName], [PassWord], [ISActive], [CreationDate], [UpdationDate]) VALUES (67, N'Aditya', N'Gupta', N'agu168', N'password', 0, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2017-03-17 14:27:58.1502415' AS DateTime2))
INSERT [dbo].[User] ([UserID], [FName], [LName], [UserName], [PassWord], [ISActive], [CreationDate], [UpdationDate]) VALUES (68, N'Anirban', N'Chowdhary', N'achow3', N'123', 0, CAST(N'2017-05-02 13:27:40.0580373' AS DateTime2), CAST(N'2017-05-02 13:27:40.0580373' AS DateTime2))
INSERT [dbo].[User] ([UserID], [FName], [LName], [UserName], [PassWord], [ISActive], [CreationDate], [UpdationDate]) VALUES (69, N'Shubham', N'Singh', N'ssingh', N'12345', 1, CAST(N'2017-05-02 13:32:27.0364823' AS DateTime2), CAST(N'2017-05-02 13:32:27.0364823' AS DateTime2))
INSERT [dbo].[User] ([UserID], [FName], [LName], [UserName], [PassWord], [ISActive], [CreationDate], [UpdationDate]) VALUES (70, N'Kashish', N'Kumar', N'temp', N'asdfg', 1, CAST(N'2017-05-02 16:51:00.8091384' AS DateTime2), CAST(N'2017-05-03 00:00:00.0000000' AS DateTime2))
INSERT [dbo].[User] ([UserID], [FName], [LName], [UserName], [PassWord], [ISActive], [CreationDate], [UpdationDate]) VALUES (71, N'xya', N'asdasd', N'xxx', N'123456', 1, CAST(N'2017-05-03 14:08:25.0516552' AS DateTime2), CAST(N'2017-05-03 14:08:25.0516552' AS DateTime2))
INSERT [dbo].[User] ([UserID], [FName], [LName], [UserName], [PassWord], [ISActive], [CreationDate], [UpdationDate]) VALUES (72, N'123', N'456', N'123456', N'123456', 1, CAST(N'2017-05-03 14:11:36.6646552' AS DateTime2), CAST(N'2017-05-03 00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[User_Role] ON 

INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (1, 1, 1, 1, CAST(N'2017-03-03 00:00:00.0000000' AS DateTime2), CAST(N'2017-03-03 00:00:00.0000000' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (2, 4, 1, 1, CAST(N'2017-03-14 23:51:20.3954214' AS DateTime2), CAST(N'2017-03-14 23:51:20.3954214' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (3, 3, 2, 1, CAST(N'2017-03-15 00:12:07.6594214' AS DateTime2), CAST(N'2017-03-15 00:12:07.6594214' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (4, 4, 2, 0, CAST(N'2017-03-15 00:12:17.4724214' AS DateTime2), CAST(N'2017-03-15 00:12:17.4724214' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (5, 2, 3, 1, CAST(N'2017-03-15 00:13:47.1364214' AS DateTime2), CAST(N'2017-03-15 00:13:47.1364214' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (6, 5, 1, 1, CAST(N'2017-03-15 00:38:18.8004214' AS DateTime2), CAST(N'2017-03-15 00:38:18.8004214' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (7, 6, 3, 1, CAST(N'2017-03-15 10:42:53.8573769' AS DateTime2), CAST(N'2017-03-15 10:42:53.8573769' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (8, 7, 2, 1, CAST(N'2017-03-15 11:04:25.6055388' AS DateTime2), CAST(N'2017-03-15 11:04:25.6055388' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (9, 8, 1, 1, CAST(N'2017-03-15 11:20:43.7753460' AS DateTime2), CAST(N'2017-03-15 11:20:43.7753460' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (10, 8, 2, 1, CAST(N'2017-03-15 11:20:43.7843469' AS DateTime2), CAST(N'2017-03-15 11:20:43.7843469' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (11, 8, 3, 1, CAST(N'2017-03-15 11:20:43.7843469' AS DateTime2), CAST(N'2017-03-15 11:20:43.7843469' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (12, 9, 1, 1, CAST(N'2017-03-15 11:23:24.7264395' AS DateTime2), CAST(N'2017-03-15 11:23:24.7264395' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (13, 9, 2, 1, CAST(N'2017-03-15 11:23:24.8344503' AS DateTime2), CAST(N'2017-03-15 11:23:24.8344503' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (14, 10, 2, 1, CAST(N'2017-03-15 11:25:09.0638722' AS DateTime2), CAST(N'2017-03-15 11:25:09.0638722' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (15, 11, 2, 1, CAST(N'2017-03-15 11:29:12.1311765' AS DateTime2), CAST(N'2017-03-15 11:29:12.1311765' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (16, 12, 1, 1, CAST(N'2017-03-15 12:36:24.4893720' AS DateTime2), CAST(N'2017-03-15 12:36:24.4893720' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (17, 12, 3, 1, CAST(N'2017-03-15 12:36:24.6123843' AS DateTime2), CAST(N'2017-03-15 12:36:24.6123843' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (18, 13, 2, 1, CAST(N'2017-03-15 12:54:04.9014026' AS DateTime2), CAST(N'2017-03-15 12:54:04.9014026' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (19, 14, 2, 1, CAST(N'2017-03-15 12:54:57.1246244' AS DateTime2), CAST(N'2017-03-15 12:54:57.1246244' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (20, 15, 2, 1, CAST(N'2017-03-15 13:01:58.2937371' AS DateTime2), CAST(N'2017-03-15 13:01:58.2937371' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (21, 16, 2, 1, CAST(N'2017-03-15 13:04:17.9487012' AS DateTime2), CAST(N'2017-03-15 13:04:17.9487012' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (22, 17, 2, 1, CAST(N'2017-03-15 13:05:27.8846941' AS DateTime2), CAST(N'2017-03-15 13:05:27.8856942' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (23, 18, 2, 1, CAST(N'2017-03-15 13:05:47.0766131' AS DateTime2), CAST(N'2017-03-15 13:05:47.0766131' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (24, 19, 2, 1, CAST(N'2017-03-15 13:13:19.9378947' AS DateTime2), CAST(N'2017-03-15 13:13:19.9378947' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (25, 20, 3, 1, CAST(N'2017-03-15 13:14:00.1279133' AS DateTime2), CAST(N'2017-03-15 13:14:00.1279133' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (26, 21, 1, 1, CAST(N'2017-03-15 14:18:03.8216133' AS DateTime2), CAST(N'2017-03-15 14:18:03.8216133' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (39, 60, 2, 1, CAST(N'2017-03-17 12:05:38.3136248' AS DateTime2), CAST(N'2017-03-17 12:05:38.3136248' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (40, 60, 1, 1, CAST(N'2017-03-17 12:05:38.4876248' AS DateTime2), CAST(N'2017-03-17 12:05:38.4876248' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (41, 61, 3, 1, CAST(N'2017-03-17 12:20:45.4697596' AS DateTime2), CAST(N'2017-03-17 12:20:45.4697596' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (42, 62, 2, 1, CAST(N'2017-03-17 12:23:45.3717480' AS DateTime2), CAST(N'2017-03-17 12:23:45.3717480' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (43, 63, 2, 1, CAST(N'2017-03-17 13:43:27.2828913' AS DateTime2), CAST(N'2017-03-17 13:43:27.2828913' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (44, 64, 1, 1, CAST(N'2017-03-17 14:00:15.0866616' AS DateTime2), CAST(N'2017-03-17 14:00:15.0866616' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (45, 65, 1, 1, CAST(N'2017-03-17 14:22:42.5450581' AS DateTime2), CAST(N'2017-03-17 14:22:42.5450581' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (46, 66, 2, 1, CAST(N'2017-03-17 14:23:17.0906032' AS DateTime2), CAST(N'2017-03-17 14:23:17.0906032' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (47, 67, 2, 1, CAST(N'2017-03-17 14:26:51.9132415' AS DateTime2), CAST(N'2017-03-17 14:26:51.9132415' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (48, 67, 3, 1, CAST(N'2017-03-17 14:26:51.9242415' AS DateTime2), CAST(N'2017-03-17 14:26:51.9242415' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (49, 67, 1, 1, CAST(N'2017-03-17 14:26:51.9322415' AS DateTime2), CAST(N'2017-03-17 14:26:51.9322415' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (50, 68, 2, 1, CAST(N'2017-05-02 13:27:40.4486854' AS DateTime2), CAST(N'2017-05-02 13:27:40.4486854' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (51, 68, 3, 1, CAST(N'2017-05-02 13:27:40.4646710' AS DateTime2), CAST(N'2017-05-02 13:27:40.4646710' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (52, 69, 2, 1, CAST(N'2017-05-02 13:32:27.0724715' AS DateTime2), CAST(N'2017-05-02 13:32:27.0724715' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (53, 69, 1, 1, CAST(N'2017-05-02 13:32:27.0864673' AS DateTime2), CAST(N'2017-05-02 13:32:27.0864673' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (54, 69, 3, 1, CAST(N'2017-05-02 13:32:27.0864673' AS DateTime2), CAST(N'2017-05-02 13:32:27.0864673' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (55, 70, 2, 1, CAST(N'2017-05-02 16:51:00.8481384' AS DateTime2), CAST(N'2017-05-02 16:51:00.8481384' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (56, 70, 1, 1, CAST(N'2017-05-02 16:51:00.8601384' AS DateTime2), CAST(N'2017-05-02 16:51:00.8601384' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (57, 65, 2, 1, CAST(N'2017-05-03 11:05:58.2920759' AS DateTime2), CAST(N'2017-05-03 11:05:58.2940761' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (58, 65, 3, 1, CAST(N'2017-05-03 11:06:12.6155081' AS DateTime2), CAST(N'2017-05-03 11:06:12.6165082' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (63, 70, 3, 0, CAST(N'2017-05-03 12:55:09.1130925' AS DateTime2), CAST(N'2017-05-03 12:55:09.1130925' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (64, 71, 3, 1, CAST(N'2017-05-03 14:08:25.0816552' AS DateTime2), CAST(N'2017-05-03 14:08:25.0816552' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (65, 72, 2, 0, CAST(N'2017-05-03 14:11:36.6836552' AS DateTime2), CAST(N'2017-05-03 14:11:36.6836552' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (66, 72, 1, 1, CAST(N'2017-05-03 14:11:36.6866552' AS DateTime2), CAST(N'2017-05-03 14:11:36.6866552' AS DateTime2))
INSERT [dbo].[User_Role] ([UserRoleID], [UserID], [RoleID], [ISActive], [CreationDate], [UpdationDate]) VALUES (67, 72, 3, 0, CAST(N'2017-05-03 14:11:36.6866552' AS DateTime2), CAST(N'2017-05-03 14:11:36.6866552' AS DateTime2))
SET IDENTITY_INSERT [dbo].[User_Role] OFF
ALTER TABLE [dbo].[Block]  WITH CHECK ADD  CONSTRAINT [FK_Block_Block_status] FOREIGN KEY([BlockStatusID])
REFERENCES [dbo].[Block_status] ([BlockStatusId])
GO
ALTER TABLE [dbo].[Block] CHECK CONSTRAINT [FK_Block_Block_status]
GO
ALTER TABLE [dbo].[Block]  WITH CHECK ADD  CONSTRAINT [FK_Block_Symbol_Properties] FOREIGN KEY([SymbolID])
REFERENCES [dbo].[Symbol_Properties] ([SymbolID])
GO
ALTER TABLE [dbo].[Block] CHECK CONSTRAINT [FK_Block_Symbol_Properties]
GO
ALTER TABLE [dbo].[Block]  WITH CHECK ADD  CONSTRAINT [FK_Block_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Block] CHECK CONSTRAINT [FK_Block_User]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Block] FOREIGN KEY([BlockID])
REFERENCES [dbo].[Block] ([BlockID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Block]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Order_Status] FOREIGN KEY([OrderStatusID])
REFERENCES [dbo].[Order_Status] ([OrderStatusID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Order_Status]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Order_Type] FOREIGN KEY([OrderTypeID])
REFERENCES [dbo].[Order_Type] ([OrderTypeID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Order_Type]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Portfolio] FOREIGN KEY([PortfolioID])
REFERENCES [dbo].[Portfolio] ([PortfolioID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Portfolio]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Symbol_Properties] FOREIGN KEY([SymbolID])
REFERENCES [dbo].[Symbol_Properties] ([SymbolID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Symbol_Properties]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User] FOREIGN KEY([PMID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User]
GO
ALTER TABLE [dbo].[Portfolio]  WITH CHECK ADD  CONSTRAINT [FK_Portfolio_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Portfolio] CHECK CONSTRAINT [FK_Portfolio_User]
GO
ALTER TABLE [dbo].[User_Role]  WITH CHECK ADD  CONSTRAINT [FK_User_Role_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[User_Role] CHECK CONSTRAINT [FK_User_Role_Role]
GO
ALTER TABLE [dbo].[User_Role]  WITH CHECK ADD  CONSTRAINT [FK_User_Role_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[User_Role] CHECK CONSTRAINT [FK_User_Role_User]
GO
/****** Object:  StoredProcedure [dbo].[UPSERT]    Script Date: 5/5/2017 3:29:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Samyak Puri
-- Create date: 3/15/2017
-- Description:	UPSERT for Symbol_Properties
-- =============================================
CREATE PROCEDURE [dbo].[UPSERT] 
	-- Add the parameters for the stored procedure here
	@Symbol varchar(50) = 0, 
	@Price decimal(18,4) = 0,
	@Name varchar(50) = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF EXISTS ( SELECT * FROM dbo.Symbol_Properties WHERE Symbol = @Symbol)
	BEGIN
		UPDATE dbo.Symbol_Properties
		SET Price = @Price
		WHERE Symbol = @Symbol;
	END

	ELSE
	BEGIN
		WAITFOR DELAY '00:00:03'
		INSERT INTO dbo.Symbol_Properties(Symbol,Name,Price) VALUES(@Symbol,@Name,@Price);
	END
END;

GO
USE [master]
GO
ALTER DATABASE [Equity] SET  READ_WRITE 
GO
