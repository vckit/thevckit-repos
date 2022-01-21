USE [dbinventory]
GO
/****** Object:  Table [dbo].[Cabinet]    Script Date: 1/22/2022 12:10:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cabinet](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Number] [char](10) NOT NULL,
 CONSTRAINT [PK_Cabinet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CabinetInventoryObject]    Script Date: 1/22/2022 12:10:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CabinetInventoryObject](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDInventoryObject] [int] NOT NULL,
	[IDCabinet] [int] NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_CabinetInventoryObject] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CurrentStatus]    Script Date: 1/22/2022 12:10:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CurrentStatus](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDStatus] [int] NOT NULL,
	[NumberAct] [varchar](20) NULL,
	[Date] [date] NULL,
 CONSTRAINT [PK_CurrentStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employe]    Script Date: 1/22/2022 12:10:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employe](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FIO] [varchar](100) NOT NULL,
	[Position] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Employe] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[History]    Script Date: 1/22/2022 12:10:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[History](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FIO] [nvarchar](100) NOT NULL,
	[CabinetNumber] [char](10) NOT NULL,
	[IDInventoryObject] [int] NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_History] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryObject]    Script Date: 1/22/2022 12:10:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryObject](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](30) NOT NULL,
	[InventoryNumber] [char](10) NOT NULL,
	[CommissioningDate] [date] NOT NULL,
	[DocumentationPath] [nvarchar](1000) NOT NULL,
	[IDType] [int] NOT NULL,
	[IDSubType] [int] NOT NULL,
	[LifeTime] [int] NOT NULL,
	[IDInvoce] [int] NOT NULL,
	[IDCurrentStatus] [int] NOT NULL,
	[Amount] [decimal](13, 2) NOT NULL,
	[IDEmployee] [int] NOT NULL,
	[IDInventoryObjectDetail] [int] NOT NULL,
 CONSTRAINT [PK_InventoryObject] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryObjectDetails]    Script Date: 1/22/2022 12:10:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryObjectDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SeriaNumber] [varchar](30) NULL,
	[Title] [varchar](20) NOT NULL,
 CONSTRAINT [PK_InventoryObjectDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryObjectInentoryObjectDetails]    Script Date: 1/22/2022 12:10:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryObjectInentoryObjectDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDInventoryObject] [int] NOT NULL,
	[IDInventoryObjectDetails] [int] NOT NULL,
 CONSTRAINT [PK_InventoryObjectInentoryObjectDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoce]    Script Date: 1/22/2022 12:10:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoce](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Number] [varchar](20) NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_Invoce] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 1/22/2022 12:10:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubType]    Script Date: 1/22/2022 12:10:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDType] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SubType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Type]    Script Date: 1/22/2022 12:10:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Type] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 1/22/2022 12:10:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Role] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CabinetInventoryObject]  WITH CHECK ADD  CONSTRAINT [FK_CabinetInventoryObject_Cabinet] FOREIGN KEY([IDCabinet])
REFERENCES [dbo].[Cabinet] ([ID])
GO
ALTER TABLE [dbo].[CabinetInventoryObject] CHECK CONSTRAINT [FK_CabinetInventoryObject_Cabinet]
GO
ALTER TABLE [dbo].[CabinetInventoryObject]  WITH CHECK ADD  CONSTRAINT [FK_CabinetInventoryObject_InventoryObject] FOREIGN KEY([IDInventoryObject])
REFERENCES [dbo].[InventoryObject] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CabinetInventoryObject] CHECK CONSTRAINT [FK_CabinetInventoryObject_InventoryObject]
GO
ALTER TABLE [dbo].[CurrentStatus]  WITH CHECK ADD  CONSTRAINT [FK_CurrentStatus_Status] FOREIGN KEY([IDStatus])
REFERENCES [dbo].[Status] ([ID])
GO
ALTER TABLE [dbo].[CurrentStatus] CHECK CONSTRAINT [FK_CurrentStatus_Status]
GO
ALTER TABLE [dbo].[History]  WITH CHECK ADD  CONSTRAINT [FK_History_InventoryObject] FOREIGN KEY([IDInventoryObject])
REFERENCES [dbo].[InventoryObject] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[History] CHECK CONSTRAINT [FK_History_InventoryObject]
GO
ALTER TABLE [dbo].[InventoryObject]  WITH CHECK ADD  CONSTRAINT [FK_InventoryObject_CurrentStatus] FOREIGN KEY([IDCurrentStatus])
REFERENCES [dbo].[CurrentStatus] ([ID])
GO
ALTER TABLE [dbo].[InventoryObject] CHECK CONSTRAINT [FK_InventoryObject_CurrentStatus]
GO
ALTER TABLE [dbo].[InventoryObject]  WITH CHECK ADD  CONSTRAINT [FK_InventoryObject_Employe] FOREIGN KEY([IDEmployee])
REFERENCES [dbo].[Employe] ([ID])
GO
ALTER TABLE [dbo].[InventoryObject] CHECK CONSTRAINT [FK_InventoryObject_Employe]
GO
ALTER TABLE [dbo].[InventoryObject]  WITH CHECK ADD  CONSTRAINT [FK_InventoryObject_Invoce] FOREIGN KEY([IDInvoce])
REFERENCES [dbo].[Invoce] ([ID])
GO
ALTER TABLE [dbo].[InventoryObject] CHECK CONSTRAINT [FK_InventoryObject_Invoce]
GO
ALTER TABLE [dbo].[InventoryObject]  WITH CHECK ADD  CONSTRAINT [FK_InventoryObject_SubType] FOREIGN KEY([IDSubType])
REFERENCES [dbo].[SubType] ([ID])
GO
ALTER TABLE [dbo].[InventoryObject] CHECK CONSTRAINT [FK_InventoryObject_SubType]
GO
ALTER TABLE [dbo].[InventoryObject]  WITH CHECK ADD  CONSTRAINT [FK_InventoryObject_Type] FOREIGN KEY([IDType])
REFERENCES [dbo].[Type] ([ID])
GO
ALTER TABLE [dbo].[InventoryObject] CHECK CONSTRAINT [FK_InventoryObject_Type]
GO
ALTER TABLE [dbo].[InventoryObjectInentoryObjectDetails]  WITH CHECK ADD  CONSTRAINT [FK_InventoryObjectInentoryObjectDetails_InventoryObject] FOREIGN KEY([IDInventoryObject])
REFERENCES [dbo].[InventoryObject] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InventoryObjectInentoryObjectDetails] CHECK CONSTRAINT [FK_InventoryObjectInentoryObjectDetails_InventoryObject]
GO
ALTER TABLE [dbo].[InventoryObjectInentoryObjectDetails]  WITH CHECK ADD  CONSTRAINT [FK_InventoryObjectInentoryObjectDetails_InventoryObjectDetails] FOREIGN KEY([IDInventoryObjectDetails])
REFERENCES [dbo].[InventoryObjectDetails] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InventoryObjectInentoryObjectDetails] CHECK CONSTRAINT [FK_InventoryObjectInentoryObjectDetails_InventoryObjectDetails]
GO
ALTER TABLE [dbo].[SubType]  WITH CHECK ADD  CONSTRAINT [FK_SubType_Type] FOREIGN KEY([IDType])
REFERENCES [dbo].[Type] ([ID])
GO
ALTER TABLE [dbo].[SubType] CHECK CONSTRAINT [FK_SubType_Type]
GO
