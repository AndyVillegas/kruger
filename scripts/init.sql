USE [master]
GO
IF DB_ID('Kruger') IS NOT NULL
  set noexec on 
/****** Object:  Database [Kruger]    Script Date: 30/4/2022 21:59:12 ******/
CREATE DATABASE [Kruger]
GO
USE [Kruger]
GO
ALTER DATABASE [Kruger] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Kruger] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Kruger] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Kruger] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Kruger] SET ARITHABORT OFF 
GO
ALTER DATABASE [Kruger] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Kruger] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Kruger] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Kruger] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Kruger] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Kruger] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Kruger] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Kruger] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Kruger] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Kruger] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Kruger] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Kruger] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Kruger] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Kruger] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Kruger] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Kruger] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Kruger] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Kruger] SET RECOVERY FULL 
GO
ALTER DATABASE [Kruger] SET  MULTI_USER 
GO
ALTER DATABASE [Kruger] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Kruger] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Kruger] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Kruger] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Kruger] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Kruger] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Kruger] SET QUERY_STORE = OFF
GO
USE [Kruger]
GO
/****** Object:  Table [dbo].[Car]    Script Date: 30/4/2022 21:59:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Car](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Plate] [varchar](255) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
	[DeletedAt] [datetime] NULL,
 CONSTRAINT [PK_Car] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarOwner]    Script Date: 30/4/2022 21:59:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarOwner](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[LastName] [varchar](255) NOT NULL,
	[IdType] [int] NOT NULL,
	[IdValue] [varchar](15) NOT NULL,
	[LastParking] [datetime] NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
	[DeletedAt] [datetime] NULL,
 CONSTRAINT [PK_CarOwner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ParkingPlace]    Script Date: 30/4/2022 21:59:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParkingPlace](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](255) NOT NULL,
	[Capacity] [int] NOT NULL,
	[RateId] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
	[DeletedAt] [datetime] NULL,
 CONSTRAINT [PK_ParkingPlace] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ParkingRecord]    Script Date: 30/4/2022 21:59:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParkingRecord](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarOwnerId] [int] NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NULL,
	[ParkingPlaceId] [int] NOT NULL,
	[RateValue] [decimal](18, 2) NOT NULL,
	[RateDescription] [varchar](255) NOT NULL,
	[CarId] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
	[DeletedAt] [datetime] NULL,
	[TotalCost] [decimal](18, 2) NOT NULL,
	[Note] [text] NULL,
 CONSTRAINT [PK_ParkingRecord] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rate]    Script Date: 30/4/2022 21:59:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](255) NOT NULL,
	[HourlyCost] [decimal](18, 2) NOT NULL,
	[MinimumCost] [decimal](18, 2) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
	[DeletedAt] [datetime] NULL,
 CONSTRAINT [PK_Rate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 30/4/2022 21:59:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](255) NOT NULL,
	[Password] [varchar](255) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Car] ON 
GO
INSERT [dbo].[Car] ([Id], [Plate], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (1, N'ABC223', CAST(N'2022-04-29T00:57:45.937' AS DateTime), CAST(N'2022-04-30T19:42:51.347' AS DateTime), NULL)
GO
INSERT [dbo].[Car] ([Id], [Plate], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (2, N'SEX001', CAST(N'2022-04-29T00:59:11.813' AS DateTime), NULL, CAST(N'2022-04-30T19:33:40.953' AS DateTime))
GO
INSERT [dbo].[Car] ([Id], [Plate], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (3, N'ABC223', CAST(N'2022-04-30T19:39:24.633' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Car] ([Id], [Plate], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (4, N'ZZZ121', CAST(N'2022-04-30T19:39:27.260' AS DateTime), CAST(N'2022-04-30T20:02:50.070' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Car] OFF
GO
SET IDENTITY_INSERT [dbo].[CarOwner] ON 
GO
INSERT [dbo].[CarOwner] ([Id], [Name], [LastName], [IdType], [IdValue], [LastParking], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (1, N'Andy', N'Villegas', 0, N'0940864747', CAST(N'2022-05-01T02:09:12.010' AS DateTime), CAST(N'2022-04-29T02:44:19.020' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[CarOwner] ([Id], [Name], [LastName], [IdType], [IdValue], [LastParking], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (2, N'Emma', N'Matamoros', 0, N'0940864722', NULL, CAST(N'2022-05-01T02:33:30.567' AS DateTime), CAST(N'2022-05-01T02:43:28.957' AS DateTime), CAST(N'2022-05-01T02:44:15.053' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[CarOwner] OFF
GO
SET IDENTITY_INSERT [dbo].[ParkingPlace] ON 
GO
INSERT [dbo].[ParkingPlace] ([Id], [Description], [Capacity], [RateId], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (1, N'Place #1', 5, 1, CAST(N'2022-04-29T03:24:38.250' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[ParkingPlace] ([Id], [Description], [Capacity], [RateId], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (2, N'Place #2', 3, 1, CAST(N'2022-05-01T02:47:27.093' AS DateTime), CAST(N'2022-05-01T02:47:56.617' AS DateTime), CAST(N'2022-05-01T02:48:03.030' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[ParkingPlace] OFF
GO
SET IDENTITY_INSERT [dbo].[Rate] ON 
GO
INSERT [dbo].[Rate] ([Id], [Description], [HourlyCost], [MinimumCost], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (1, N'A', CAST(10.50 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), CAST(N'2022-04-29T03:17:31.060' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Rate] ([Id], [Description], [HourlyCost], [MinimumCost], [CreatedAt], [UpdatedAt], [DeletedAt]) VALUES (2, N'B', CAST(6.50 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), CAST(N'2022-05-01T02:51:39.360' AS DateTime), CAST(N'2022-05-01T02:52:43.560' AS DateTime), CAST(N'2022-05-01T02:52:50.243' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Rate] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([Id], [Username], [Password]) VALUES (1, N'admin', N'8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918')
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Username]    Script Date: 30/4/2022 21:59:12 ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [UQ_Username] UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Car] ADD  CONSTRAINT [DF_Car_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[CarOwner] ADD  CONSTRAINT [DF_CarOwner_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[ParkingPlace] ADD  CONSTRAINT [DF_ParkingPlace_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[ParkingRecord] ADD  CONSTRAINT [DF_ParkingRecord_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[ParkingRecord] ADD  DEFAULT ((0)) FOR [TotalCost]
GO
ALTER TABLE [dbo].[Rate] ADD  CONSTRAINT [DF_Rate_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[ParkingRecord]  WITH CHECK ADD  CONSTRAINT [FK_ParkingRecord_Car] FOREIGN KEY([CarId])
REFERENCES [dbo].[Car] ([Id])
GO
ALTER TABLE [dbo].[ParkingRecord] CHECK CONSTRAINT [FK_ParkingRecord_Car]
GO
ALTER TABLE [dbo].[ParkingRecord]  WITH CHECK ADD  CONSTRAINT [FK_ParkingRecord_CarOwner] FOREIGN KEY([CarOwnerId])
REFERENCES [dbo].[CarOwner] ([Id])
GO
ALTER TABLE [dbo].[ParkingRecord] CHECK CONSTRAINT [FK_ParkingRecord_CarOwner]
GO
ALTER TABLE [dbo].[ParkingRecord]  WITH CHECK ADD  CONSTRAINT [FK_ParkingRecord_ParkingPlace] FOREIGN KEY([ParkingPlaceId])
REFERENCES [dbo].[ParkingPlace] ([Id])
GO
ALTER TABLE [dbo].[ParkingRecord] CHECK CONSTRAINT [FK_ParkingRecord_ParkingPlace]
GO
USE [master]
GO
ALTER DATABASE [Kruger] SET  READ_WRITE 
GO
