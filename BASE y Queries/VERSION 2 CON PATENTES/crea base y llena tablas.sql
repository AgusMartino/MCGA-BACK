USE [master]
GO
/****** Object:  Database [TELEPEAJE]    Script Date: 10/13/2022 9:20:01 PM ******/
CREATE DATABASE [TELEPEAJE]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TELEPEAJE', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TELEPEAJE.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TELEPEAJE_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TELEPEAJE_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
/****** Object:  Table [dbo].[Estado]    Script Date: 10/13/2022 9:20:01 PM ******/
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
/****** Object:  Table [dbo].[Patente]    Script Date: 10/13/2022 9:20:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patente](
	[Patente] [nvarchar](50) NOT NULL,
	[ID_Tipo_Vehiculo] [uniqueidentifier] NOT NULL,
	[Telepeaje] [bit] NOT NULL,
 CONSTRAINT [PK_Patente] PRIMARY KEY CLUSTERED 
(
	[Patente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Vehiculo]    Script Date: 10/13/2022 9:20:01 PM ******/
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
/****** Object:  Table [dbo].[Transacciones]    Script Date: 10/13/2022 9:20:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transacciones](
	[ID_Transacciones] [uniqueidentifier] NOT NULL,
	[Patente] [nvarchar](50) NOT NULL,
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
INSERT [dbo].[Patente] ([Patente], [ID_Tipo_Vehiculo], [Telepeaje]) VALUES (N'AAA 111', N'ffe7fec7-5539-40b9-9926-d868b22159d7', 1)
GO
INSERT [dbo].[Patente] ([Patente], [ID_Tipo_Vehiculo], [Telepeaje]) VALUES (N'AAA 222', N'ffe7fec7-5539-40b9-9926-d868b22159d7', 1)
GO
INSERT [dbo].[Patente] ([Patente], [ID_Tipo_Vehiculo], [Telepeaje]) VALUES (N'AAA 333', N'ffe7fec7-5539-40b9-9926-d868b22159d7', 1)
GO
INSERT [dbo].[Patente] ([Patente], [ID_Tipo_Vehiculo], [Telepeaje]) VALUES (N'CCC 111', N'9407c5f8-5984-4777-aa6c-7b413b7879c3', 1)
GO
INSERT [dbo].[Patente] ([Patente], [ID_Tipo_Vehiculo], [Telepeaje]) VALUES (N'CCC 222', N'9407c5f8-5984-4777-aa6c-7b413b7879c3', 1)
GO
INSERT [dbo].[Patente] ([Patente], [ID_Tipo_Vehiculo], [Telepeaje]) VALUES (N'CCC 333', N'9407c5f8-5984-4777-aa6c-7b413b7879c3', 1)
GO
INSERT [dbo].[Patente] ([Patente], [ID_Tipo_Vehiculo], [Telepeaje]) VALUES (N'MMM 111', N'54f13da9-b8fe-4fff-919f-d295ec4d55f5', 1)
GO
INSERT [dbo].[Patente] ([Patente], [ID_Tipo_Vehiculo], [Telepeaje]) VALUES (N'MMM 222', N'54f13da9-b8fe-4fff-919f-d295ec4d55f5', 1)
GO
INSERT [dbo].[Patente] ([Patente], [ID_Tipo_Vehiculo], [Telepeaje]) VALUES (N'MMM 333', N'54f13da9-b8fe-4fff-919f-d295ec4d55f5', 1)
GO
INSERT [dbo].[Patente] ([Patente], [ID_Tipo_Vehiculo], [Telepeaje]) VALUES (N'XXX 111', N'b1bbfb23-803e-403b-87c8-cd95cc9a3656', 0)
GO
INSERT [dbo].[Patente] ([Patente], [ID_Tipo_Vehiculo], [Telepeaje]) VALUES (N'XXX 222', N'b1bbfb23-803e-403b-87c8-cd95cc9a3656', 0)
GO
INSERT [dbo].[Patente] ([Patente], [ID_Tipo_Vehiculo], [Telepeaje]) VALUES (N'XXX 333', N'b1bbfb23-803e-403b-87c8-cd95cc9a3656', 0)
GO
INSERT [dbo].[Patente] ([Patente], [ID_Tipo_Vehiculo], [Telepeaje]) VALUES (N'XXX 444', N'b1bbfb23-803e-403b-87c8-cd95cc9a3656', 0)
GO
INSERT [dbo].[Tipo_Vehiculo] ([ID_Tipo_Vehiculo], [Tipo_Vehiculo], [Precio]) VALUES (N'9407c5f8-5984-4777-aa6c-7b413b7879c3', N'CAMION', 600.0000)
GO
INSERT [dbo].[Tipo_Vehiculo] ([ID_Tipo_Vehiculo], [Tipo_Vehiculo], [Precio]) VALUES (N'b1bbfb23-803e-403b-87c8-cd95cc9a3656', N'N/A', 0.0000)
GO
INSERT [dbo].[Tipo_Vehiculo] ([ID_Tipo_Vehiculo], [Tipo_Vehiculo], [Precio]) VALUES (N'54f13da9-b8fe-4fff-919f-d295ec4d55f5', N'MOTO', 200.0000)
GO
INSERT [dbo].[Tipo_Vehiculo] ([ID_Tipo_Vehiculo], [Tipo_Vehiculo], [Precio]) VALUES (N'ffe7fec7-5539-40b9-9926-d868b22159d7', N'AUTO', 400.0000)
GO
INSERT [dbo].[Transacciones] ([ID_Transacciones], [Patente], [ID_Estado], [Fecha], [Precio]) VALUES (N'c57f25c3-0199-44db-95c1-06fdeb118efc', N'XXX 333', N'8e86d7f7-4228-4992-a95e-6f9342b4e244', CAST(N'2022-10-13T21:08:46.707' AS DateTime), 0.0000)
GO
INSERT [dbo].[Transacciones] ([ID_Transacciones], [Patente], [ID_Estado], [Fecha], [Precio]) VALUES (N'a052a1d2-401e-422b-a68e-0fa76b942af0', N'CCC 333', N'8e86d7f7-4228-4992-a95e-6f9342b4e244', CAST(N'2022-10-13T21:08:05.133' AS DateTime), 600.0000)
GO
INSERT [dbo].[Transacciones] ([ID_Transacciones], [Patente], [ID_Estado], [Fecha], [Precio]) VALUES (N'00652651-dc67-4c82-be92-21959badf7f5', N'XXX 333', N'8e86d7f7-4228-4992-a95e-6f9342b4e244', CAST(N'2022-10-13T21:08:47.550' AS DateTime), 0.0000)
GO
INSERT [dbo].[Transacciones] ([ID_Transacciones], [Patente], [ID_Estado], [Fecha], [Precio]) VALUES (N'227874ed-f025-4cd3-8b78-22650e201505', N'XXX 333', N'8e86d7f7-4228-4992-a95e-6f9342b4e244', CAST(N'2022-10-13T21:08:47.010' AS DateTime), 0.0000)
GO
INSERT [dbo].[Transacciones] ([ID_Transacciones], [Patente], [ID_Estado], [Fecha], [Precio]) VALUES (N'b8dae385-02c9-4fb6-ac8e-42bee9870fd8', N'MMM 222', N'6bf5f715-4e6a-476e-b1cb-839b7296642a', CAST(N'2022-10-13T21:07:38.700' AS DateTime), 200.0000)
GO
INSERT [dbo].[Transacciones] ([ID_Transacciones], [Patente], [ID_Estado], [Fecha], [Precio]) VALUES (N'199ef1b2-fbf3-4d6a-ad40-577f1c710367', N'AAA 111', N'6bf5f715-4e6a-476e-b1cb-839b7296642a', CAST(N'2022-10-13T21:07:32.673' AS DateTime), 400.0000)
GO
INSERT [dbo].[Transacciones] ([ID_Transacciones], [Patente], [ID_Estado], [Fecha], [Precio]) VALUES (N'd02671b3-2920-4d2b-a89a-6cf56bf910a9', N'AAA 222', N'6bf5f715-4e6a-476e-b1cb-839b7296642a', CAST(N'2022-10-13T21:07:35.123' AS DateTime), 400.0000)
GO
INSERT [dbo].[Transacciones] ([ID_Transacciones], [Patente], [ID_Estado], [Fecha], [Precio]) VALUES (N'79abf71c-88ff-413c-ae46-aadc4b824b9c', N'MMM 222', N'6bf5f715-4e6a-476e-b1cb-839b7296642a', CAST(N'2022-10-13T21:07:39.000' AS DateTime), 200.0000)
GO
INSERT [dbo].[Transacciones] ([ID_Transacciones], [Patente], [ID_Estado], [Fecha], [Precio]) VALUES (N'38a880b2-d8c5-4be9-90c5-b096333137de', N'ccc 222', N'6bf5f715-4e6a-476e-b1cb-839b7296642a', CAST(N'2022-10-13T21:09:04.593' AS DateTime), 600.0000)
GO
INSERT [dbo].[Transacciones] ([ID_Transacciones], [Patente], [ID_Estado], [Fecha], [Precio]) VALUES (N'5808b30a-c203-401f-b86a-bc362d6ff100', N'CCC 333', N'8e86d7f7-4228-4992-a95e-6f9342b4e244', CAST(N'2022-10-13T21:08:04.263' AS DateTime), 600.0000)
GO
INSERT [dbo].[Transacciones] ([ID_Transacciones], [Patente], [ID_Estado], [Fecha], [Precio]) VALUES (N'74966ffb-aa82-4887-8464-e5f1f7f79ca4', N'ccc 333', N'6bf5f715-4e6a-476e-b1cb-839b7296642a', CAST(N'2022-10-13T21:08:59.660' AS DateTime), 600.0000)
GO
INSERT [dbo].[Transacciones] ([ID_Transacciones], [Patente], [ID_Estado], [Fecha], [Precio]) VALUES (N'99cf6be8-0474-4cdd-adaf-eb1da4e50862', N'XXX 444', N'8e86d7f7-4228-4992-a95e-6f9342b4e244', CAST(N'2022-10-13T21:14:08.210' AS DateTime), 0.0000)
GO
INSERT [dbo].[Transacciones] ([ID_Transacciones], [Patente], [ID_Estado], [Fecha], [Precio]) VALUES (N'f1ba3fea-0590-4f58-af08-edc557c23763', N'MMM 222', N'6bf5f715-4e6a-476e-b1cb-839b7296642a', CAST(N'2022-10-13T21:07:38.410' AS DateTime), 200.0000)
GO
INSERT [dbo].[Transacciones] ([ID_Transacciones], [Patente], [ID_Estado], [Fecha], [Precio]) VALUES (N'86cfc9e2-6fd5-481b-b156-f4ecbf9114e8', N'XXX 333', N'8e86d7f7-4228-4992-a95e-6f9342b4e244', CAST(N'2022-10-13T21:08:48.403' AS DateTime), 0.0000)
GO
INSERT [dbo].[Transacciones] ([ID_Transacciones], [Patente], [ID_Estado], [Fecha], [Precio]) VALUES (N'59ee9d1b-af58-49f2-a199-f9abf1a501b7', N'ccc 333', N'6bf5f715-4e6a-476e-b1cb-839b7296642a', CAST(N'2022-10-13T21:09:01.947' AS DateTime), 600.0000)
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
ALTER TABLE [dbo].[Transacciones]  WITH CHECK ADD  CONSTRAINT [FK_Transacciones_Patente] FOREIGN KEY([Patente])
REFERENCES [dbo].[Patente] ([Patente])
GO
ALTER TABLE [dbo].[Transacciones] CHECK CONSTRAINT [FK_Transacciones_Patente]
GO
USE [master]
GO
ALTER DATABASE [TELEPEAJE] SET  READ_WRITE 
GO
