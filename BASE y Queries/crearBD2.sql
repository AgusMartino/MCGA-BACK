USE [master]
GO
/****** Object:  Database [TELEPEAJE]    Script Date: 11/18/2022 2:56:01 PM ******/
CREATE DATABASE [TELEPEAJE]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TELEPEAJE', FILENAME = N'C:\Users\fescobar\TELEPEAJE.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TELEPEAJE_log', FILENAME = N'C:\Users\fescobar\TELEPEAJE_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TELEPEAJE] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TELEPEAJE].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TELEPEAJE] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TELEPEAJE] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TELEPEAJE] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TELEPEAJE] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TELEPEAJE] SET ARITHABORT OFF 
GO
ALTER DATABASE [TELEPEAJE] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TELEPEAJE] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TELEPEAJE] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TELEPEAJE] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TELEPEAJE] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TELEPEAJE] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TELEPEAJE] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TELEPEAJE] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TELEPEAJE] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TELEPEAJE] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TELEPEAJE] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TELEPEAJE] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TELEPEAJE] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TELEPEAJE] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TELEPEAJE] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TELEPEAJE] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TELEPEAJE] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TELEPEAJE] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TELEPEAJE] SET  MULTI_USER 
GO
ALTER DATABASE [TELEPEAJE] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TELEPEAJE] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TELEPEAJE] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TELEPEAJE] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TELEPEAJE] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TELEPEAJE] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TELEPEAJE] SET QUERY_STORE = OFF
GO
USE [TELEPEAJE]
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 11/18/2022 2:56:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado](
	[ID_Estado] [uniqueidentifier] NOT NULL,
	[Estado] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[ID_Estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estado_Servicios]    Script Date: 11/18/2022 2:56:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado_Servicios](
	[Nombre_Microservicio] [nvarchar](50) NOT NULL,
	[Estado] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patente]    Script Date: 11/18/2022 2:56:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patente](
	[ID_Patente] [uniqueidentifier] NOT NULL,
	[ID_Tipo_Vehiculo] [uniqueidentifier] NOT NULL,
	[Patente] [nvarchar](50) NOT NULL,
	[Telepeaje] [bit] NOT NULL,
 CONSTRAINT [PK_Patente] PRIMARY KEY CLUSTERED 
(
	[ID_Patente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Vehiculo]    Script Date: 11/18/2022 2:56:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Vehiculo](
	[ID_Tipo_Vehiculo] [uniqueidentifier] NOT NULL,
	[Tipo_Vehiculo] [nvarchar](50) NOT NULL,
	[Precio] [money] NOT NULL,
 CONSTRAINT [PK_Tipo_Vehiculo] PRIMARY KEY CLUSTERED 
(
	[ID_Tipo_Vehiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transacciones]    Script Date: 11/18/2022 2:56:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transacciones](
	[ID_Transacciones] [uniqueidentifier] NOT NULL,
	[ID_Patente] [uniqueidentifier] NOT NULL,
	[ID_Estado] [uniqueidentifier] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Precio] [money] NOT NULL,
 CONSTRAINT [PK_Transacciones] PRIMARY KEY CLUSTERED 
(
	[ID_Transacciones] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Estado] ([ID_Estado], [Estado]) VALUES (N'8e86d7f7-4228-4992-a95e-6f9342b4e244', N'Multa')
GO
INSERT [dbo].[Estado] ([ID_Estado], [Estado]) VALUES (N'6bf5f715-4e6a-476e-b1cb-839b7296642a', N'Pago')
GO
INSERT [dbo].[Estado_Servicios] ([Nombre_Microservicio], [Estado]) VALUES (N'Multa', 1)
GO
INSERT [dbo].[Estado_Servicios] ([Nombre_Microservicio], [Estado]) VALUES (N'Pago', 1)
GO
INSERT [dbo].[Estado_Servicios] ([Nombre_Microservicio], [Estado]) VALUES (N'Reconocimiento', 1)
GO
INSERT [dbo].[Patente] ([ID_Patente], [ID_Tipo_Vehiculo], [Patente], [Telepeaje]) VALUES (N'3ee1c20b-e1a7-4ce1-80b8-0158274f9d99', N'ffe7fec7-5539-40b9-9926-d868b22159d7', N'KZZ 512', 1)
GO
INSERT [dbo].[Patente] ([ID_Patente], [ID_Tipo_Vehiculo], [Patente], [Telepeaje]) VALUES (N'9618d3e3-0dfb-4472-a1b5-2bdd30c92331', N'54f13da9-b8fe-4fff-919f-d295ec4d55f5', N'MMM 111', 1)
GO
INSERT [dbo].[Patente] ([ID_Patente], [ID_Tipo_Vehiculo], [Patente], [Telepeaje]) VALUES (N'74ca9d1b-4784-4b00-b239-3be12ca8d5b1', N'54f13da9-b8fe-4fff-919f-d295ec4d55f5', N'MMM 333', 1)
GO
INSERT [dbo].[Patente] ([ID_Patente], [ID_Tipo_Vehiculo], [Patente], [Telepeaje]) VALUES (N'c7476eff-6f46-49fe-93dd-47768d1606ac', N'9407c5f8-5984-4777-aa6c-7b413b7879c3', N'CCC 222', 1)
GO
INSERT [dbo].[Patente] ([ID_Patente], [ID_Tipo_Vehiculo], [Patente], [Telepeaje]) VALUES (N'800d36c4-40c2-4aee-a01c-4e79ddc8122a', N'54f13da9-b8fe-4fff-919f-d295ec4d55f5', N'KAS 662', 1)
GO
INSERT [dbo].[Patente] ([ID_Patente], [ID_Tipo_Vehiculo], [Patente], [Telepeaje]) VALUES (N'354cd922-7304-4e61-a82b-547a313c872a', N'9407c5f8-5984-4777-aa6c-7b413b7879c3', N'CCC 333', 1)
GO
INSERT [dbo].[Patente] ([ID_Patente], [ID_Tipo_Vehiculo], [Patente], [Telepeaje]) VALUES (N'ca417322-3740-4b60-8984-7264637cbf49', N'ffe7fec7-5539-40b9-9926-d868b22159d7', N'AAA 222', 1)
GO
INSERT [dbo].[Patente] ([ID_Patente], [ID_Tipo_Vehiculo], [Patente], [Telepeaje]) VALUES (N'8e00bb8a-b6b1-4416-af48-76b53e427ddf', N'54f13da9-b8fe-4fff-919f-d295ec4d55f5', N'MMM 222', 1)
GO
INSERT [dbo].[Patente] ([ID_Patente], [ID_Tipo_Vehiculo], [Patente], [Telepeaje]) VALUES (N'1d8a3992-976d-4727-a2a2-8a53201f4fe2', N'9407c5f8-5984-4777-aa6c-7b413b7879c3', N'ZDK 412', 1)
GO
INSERT [dbo].[Patente] ([ID_Patente], [ID_Tipo_Vehiculo], [Patente], [Telepeaje]) VALUES (N'1615f172-0778-45f9-b7b6-95b0a32e193a', N'54f13da9-b8fe-4fff-919f-d295ec4d55f5', N'KAK 152', 1)
GO
INSERT [dbo].[Patente] ([ID_Patente], [ID_Tipo_Vehiculo], [Patente], [Telepeaje]) VALUES (N'c60dfcbb-c028-4143-a915-a264f66b7052', N'ffe7fec7-5539-40b9-9926-d868b22159d7', N'AAA 333', 1)
GO
INSERT [dbo].[Patente] ([ID_Patente], [ID_Tipo_Vehiculo], [Patente], [Telepeaje]) VALUES (N'256dd9c5-b2a2-449e-a871-bb32ae1cb662', N'9407c5f8-5984-4777-aa6c-7b413b7879c3', N'CCC 111', 1)
GO
INSERT [dbo].[Patente] ([ID_Patente], [ID_Tipo_Vehiculo], [Patente], [Telepeaje]) VALUES (N'4b8dacd9-bf3e-4380-812a-d48aefcb08cb', N'ffe7fec7-5539-40b9-9926-d868b22159d7', N'AAA 111', 1)
GO
INSERT [dbo].[Patente] ([ID_Patente], [ID_Tipo_Vehiculo], [Patente], [Telepeaje]) VALUES (N'62d510b1-63e1-4191-8690-f2dbd7b6f02a', N'9407c5f8-5984-4777-aa6c-7b413b7879c3', N'KAD 722', 1)
GO
INSERT [dbo].[Tipo_Vehiculo] ([ID_Tipo_Vehiculo], [Tipo_Vehiculo], [Precio]) VALUES (N'9407c5f8-5984-4777-aa6c-7b413b7879c3', N'CAMION', 600.0000)
GO
INSERT [dbo].[Tipo_Vehiculo] ([ID_Tipo_Vehiculo], [Tipo_Vehiculo], [Precio]) VALUES (N'54f13da9-b8fe-4fff-919f-d295ec4d55f5', N'MOTO', 200.0000)
GO
INSERT [dbo].[Tipo_Vehiculo] ([ID_Tipo_Vehiculo], [Tipo_Vehiculo], [Precio]) VALUES (N'ffe7fec7-5539-40b9-9926-d868b22159d7', N'AUTO', 400.0000)
GO
INSERT [dbo].[Transacciones] ([ID_Transacciones], [ID_Patente], [ID_Estado], [Fecha], [Precio]) VALUES (N'63638811-6f23-477d-bfe5-10ceb232269a', N'c60dfcbb-c028-4143-a915-a264f66b7052', N'6bf5f715-4e6a-476e-b1cb-839b7296642a', CAST(N'2022-10-12T21:49:50.243' AS DateTime), 400.0000)
GO
INSERT [dbo].[Transacciones] ([ID_Transacciones], [ID_Patente], [ID_Estado], [Fecha], [Precio]) VALUES (N'a8686f4c-a61e-482d-828e-19e0053fcc86', N'8e00bb8a-b6b1-4416-af48-76b53e427ddf', N'6bf5f715-4e6a-476e-b1cb-839b7296642a', CAST(N'2022-10-12T21:50:00.760' AS DateTime), 200.0000)
GO
INSERT [dbo].[Transacciones] ([ID_Transacciones], [ID_Patente], [ID_Estado], [Fecha], [Precio]) VALUES (N'2235a5aa-b07b-40ba-a4c7-78f6a3fca057', N'4b8dacd9-bf3e-4380-812a-d48aefcb08cb', N'6bf5f715-4e6a-476e-b1cb-839b7296642a', CAST(N'2022-10-12T21:49:44.907' AS DateTime), 400.0000)
GO
INSERT [dbo].[Transacciones] ([ID_Transacciones], [ID_Patente], [ID_Estado], [Fecha], [Precio]) VALUES (N'6ef4bab3-6e6d-4626-a709-c9f1f105cd9b', N'800d36c4-40c2-4aee-a01c-4e79ddc8122a', N'8e86d7f7-4228-4992-a95e-6f9342b4e244', CAST(N'2022-11-15T20:15:11.950' AS DateTime), 200.0000)
GO
ALTER TABLE [dbo].[Patente]  WITH CHECK ADD  CONSTRAINT [FK_Patente_Tipo_Vehiculo] FOREIGN KEY([ID_Tipo_Vehiculo])
REFERENCES [dbo].[Tipo_Vehiculo] ([ID_Tipo_Vehiculo])
GO
ALTER TABLE [dbo].[Patente] CHECK CONSTRAINT [FK_Patente_Tipo_Vehiculo]
GO
ALTER TABLE [dbo].[Transacciones]  WITH CHECK ADD  CONSTRAINT [FK_Transacciones_Estado] FOREIGN KEY([ID_Estado])
REFERENCES [dbo].[Estado] ([ID_Estado])
GO
ALTER TABLE [dbo].[Transacciones] CHECK CONSTRAINT [FK_Transacciones_Estado]
GO
ALTER TABLE [dbo].[Transacciones]  WITH CHECK ADD  CONSTRAINT [FK_Transacciones_Patente] FOREIGN KEY([ID_Patente])
REFERENCES [dbo].[Patente] ([ID_Patente])
GO
ALTER TABLE [dbo].[Transacciones] CHECK CONSTRAINT [FK_Transacciones_Patente]
GO
USE [master]
GO
ALTER DATABASE [TELEPEAJE] SET  READ_WRITE 
GO
