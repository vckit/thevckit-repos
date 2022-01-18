USE [dbinventory]
GO
/****** Object:  Table [dbo].[ArhiveInventoryObject]    Script Date: 1/18/2022 5:16:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArhiveInventoryObject](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](30) NOT NULL,
	[InventoryNumber] [varchar](10) NOT NULL,
	[CommissioningDate] [date] NOT NULL,
	[DocumentationPath] [nvarchar](1000) NOT NULL,
	[IDType] [nvarchar](100) NOT NULL,
	[IDSubType] [nvarchar](100) NOT NULL,
	[LifeTime] [int] NOT NULL,
	[IDInvoce] [nvarchar](100) NOT NULL,
	[IDCurrentStatus] [nvarchar](100) NOT NULL,
	[Amount] [decimal](13, 2) NOT NULL,
	[IDEmployee] [nvarchar](255) NOT NULL,
	[IDInventoryObjectDetail] [nvarchar](200) NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_ArhiveInventoryObject] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cabinet]    Script Date: 1/18/2022 5:16:38 PM ******/
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
/****** Object:  Table [dbo].[CurrentStatus]    Script Date: 1/18/2022 5:16:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CurrentStatus](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDStatus] [int] NOT NULL,
	[NumberAct] [varchar](20) NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_CurrentStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employe]    Script Date: 1/18/2022 5:16:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employe](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NOT NULL,
	[IDPosition] [int] NOT NULL,
 CONSTRAINT [PK_Employe] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeInventoryObject]    Script Date: 1/18/2022 5:16:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeInventoryObject](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDInventoryObject] [int] NOT NULL,
	[IDEmployee] [int] NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_EmployeeInventoryObject] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryObject]    Script Date: 1/18/2022 5:16:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryObject](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](30) NOT NULL,
	[InventoryNumber] [varchar](10) NOT NULL,
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
/****** Object:  Table [dbo].[InventoryObjectDetails]    Script Date: 1/18/2022 5:16:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryObjectDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SeriaNumber] [varchar](30) NOT NULL,
	[Title] [varchar](20) NOT NULL,
 CONSTRAINT [PK_InventoryObjectDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoce]    Script Date: 1/18/2022 5:16:38 PM ******/
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
/****** Object:  Table [dbo].[Position]    Script Date: 1/18/2022 5:16:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Position](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 1/18/2022 5:16:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Code] [char](1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 1/18/2022 5:16:38 PM ******/
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
/****** Object:  Table [dbo].[SubType]    Script Date: 1/18/2022 5:16:38 PM ******/
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
/****** Object:  Table [dbo].[Type]    Script Date: 1/18/2022 5:16:38 PM ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 1/18/2022 5:16:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[IDRole] [char](1) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ArhiveInventoryObject] ON 

INSERT [dbo].[ArhiveInventoryObject] ([ID], [Title], [InventoryNumber], [CommissioningDate], [DocumentationPath], [IDType], [IDSubType], [LifeTime], [IDInvoce], [IDCurrentStatus], [Amount], [IDEmployee], [IDInventoryObjectDetail], [Date]) VALUES (1, N'rwe', N'423', CAST(N'0001-01-01' AS Date), N'test', N'Техническое оборудование (устройство)', N'Ноутбук', 32, N'342', N'Рабочее', CAST(340.00 AS Decimal(13, 2)), N'Иван Иванов Иванович', N'rwe, 43', CAST(N'2022-01-18' AS Date))
SET IDENTITY_INSERT [dbo].[ArhiveInventoryObject] OFF
GO
SET IDENTITY_INSERT [dbo].[Cabinet] ON 

INSERT [dbo].[Cabinet] ([ID], [Number]) VALUES (1, N'201       ')
SET IDENTITY_INSERT [dbo].[Cabinet] OFF
GO
SET IDENTITY_INSERT [dbo].[CurrentStatus] ON 

INSERT [dbo].[CurrentStatus] ([ID], [IDStatus], [NumberAct], [Date]) VALUES (1, 3, N'1', CAST(N'2021-12-01' AS Date))
INSERT [dbo].[CurrentStatus] ([ID], [IDStatus], [NumberAct], [Date]) VALUES (2, 2, N'4', CAST(N'2021-12-04' AS Date))
INSERT [dbo].[CurrentStatus] ([ID], [IDStatus], [NumberAct], [Date]) VALUES (3, 1, N'432', CAST(N'0001-01-01' AS Date))
INSERT [dbo].[CurrentStatus] ([ID], [IDStatus], [NumberAct], [Date]) VALUES (4, 1, N'323', CAST(N'0001-01-01' AS Date))
SET IDENTITY_INSERT [dbo].[CurrentStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[Employe] ON 

INSERT [dbo].[Employe] ([ID], [FirstName], [LastName], [Patronymic], [IDPosition]) VALUES (1, N'Иван', N'Иванов', N'Иванович', 1)
SET IDENTITY_INSERT [dbo].[Employe] OFF
GO
SET IDENTITY_INSERT [dbo].[InventoryObject] ON 

INSERT [dbo].[InventoryObject] ([ID], [Title], [InventoryNumber], [CommissioningDate], [DocumentationPath], [IDType], [IDSubType], [LifeTime], [IDInvoce], [IDCurrentStatus], [Amount], [IDEmployee], [IDInventoryObjectDetail]) VALUES (3, N'ПК', N'12345', CAST(N'2021-02-21' AS Date), N'test', 1, 18, 12, 1, 1, CAST(20.00 AS Decimal(13, 2)), 1, 1)
SET IDENTITY_INSERT [dbo].[InventoryObject] OFF
GO
SET IDENTITY_INSERT [dbo].[InventoryObjectDetails] ON 

INSERT [dbo].[InventoryObjectDetails] ([ID], [SeriaNumber], [Title]) VALUES (1, N'12345', N'Тест')
INSERT [dbo].[InventoryObjectDetails] ([ID], [SeriaNumber], [Title]) VALUES (2, N'43', N'rwe')
INSERT [dbo].[InventoryObjectDetails] ([ID], [SeriaNumber], [Title]) VALUES (3, N'32', N'32')
SET IDENTITY_INSERT [dbo].[InventoryObjectDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Invoce] ON 

INSERT [dbo].[Invoce] ([ID], [Number], [Date]) VALUES (1, N'11', CAST(N'2021-02-21' AS Date))
INSERT [dbo].[Invoce] ([ID], [Number], [Date]) VALUES (2, N'23', CAST(N'2021-11-01' AS Date))
INSERT [dbo].[Invoce] ([ID], [Number], [Date]) VALUES (3, N'342', CAST(N'0001-01-01' AS Date))
INSERT [dbo].[Invoce] ([ID], [Number], [Date]) VALUES (4, N'3232', CAST(N'0001-01-01' AS Date))
SET IDENTITY_INSERT [dbo].[Invoce] OFF
GO
SET IDENTITY_INSERT [dbo].[Position] ON 

INSERT [dbo].[Position] ([ID], [Title]) VALUES (1, N'Директор')
INSERT [dbo].[Position] ([ID], [Title]) VALUES (2, N'Менеджер')
INSERT [dbo].[Position] ([ID], [Title]) VALUES (3, N'Бухгалтер')
SET IDENTITY_INSERT [dbo].[Position] OFF
GO
INSERT [dbo].[Role] ([Code], [Title]) VALUES (N'a', N'Администратор')
INSERT [dbo].[Role] ([Code], [Title]) VALUES (N'u', N'Пользователь')
GO
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([ID], [Title]) VALUES (1, N'Рабочее')
INSERT [dbo].[Status] ([ID], [Title]) VALUES (2, N'На ремонте')
INSERT [dbo].[Status] ([ID], [Title]) VALUES (3, N'Списано')
INSERT [dbo].[Status] ([ID], [Title]) VALUES (4, N'Подразделение')
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
SET IDENTITY_INSERT [dbo].[SubType] ON 

INSERT [dbo].[SubType] ([ID], [IDType], [Title]) VALUES (18, 1, N'Ноутбук')
SET IDENTITY_INSERT [dbo].[SubType] OFF
GO
SET IDENTITY_INSERT [dbo].[Type] ON 

INSERT [dbo].[Type] ([ID], [Title]) VALUES (1, N'Техническое оборудование (устройство)')
INSERT [dbo].[Type] ([ID], [Title]) VALUES (2, N'Мебель ')
SET IDENTITY_INSERT [dbo].[Type] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [Username], [Password], [IDRole]) VALUES (1, N'admin', N'admin', N'a')
INSERT [dbo].[User] ([ID], [Username], [Password], [IDRole]) VALUES (2, N'user', N'user', N'u')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[CurrentStatus]  WITH CHECK ADD  CONSTRAINT [FK_CurrentStatus_Status] FOREIGN KEY([IDStatus])
REFERENCES [dbo].[Status] ([ID])
GO
ALTER TABLE [dbo].[CurrentStatus] CHECK CONSTRAINT [FK_CurrentStatus_Status]
GO
ALTER TABLE [dbo].[Employe]  WITH CHECK ADD  CONSTRAINT [FK_Employe_Position] FOREIGN KEY([IDPosition])
REFERENCES [dbo].[Position] ([ID])
GO
ALTER TABLE [dbo].[Employe] CHECK CONSTRAINT [FK_Employe_Position]
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
ALTER TABLE [dbo].[InventoryObject]  WITH CHECK ADD  CONSTRAINT [FK_InventoryObject_InventoryObjectDetails] FOREIGN KEY([IDInventoryObjectDetail])
REFERENCES [dbo].[InventoryObjectDetails] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InventoryObject] CHECK CONSTRAINT [FK_InventoryObject_InventoryObjectDetails]
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
ALTER TABLE [dbo].[SubType]  WITH CHECK ADD  CONSTRAINT [FK_SubType_Type] FOREIGN KEY([IDType])
REFERENCES [dbo].[Type] ([ID])
GO
ALTER TABLE [dbo].[SubType] CHECK CONSTRAINT [FK_SubType_Type]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([IDRole])
REFERENCES [dbo].[Role] ([Code])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
