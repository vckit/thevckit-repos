
-- ЕСЛИ БАЗЫ ДАННЫХ НЕТ, СОЗДАЙТЕ ЕГО, ВЫДЕЛИВ КОМАНДУ НИЖЕ.
CREATE DATABASE [dbMobileCenter]

USE [dbMobileCenter]
GO
/****** Object:  Table [dbo].[Abonent]    Script Date: 1/13/2022 7:35:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Abonent](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Phone] [char](30) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](300) NOT NULL,
	[PresenceBlocker] [bit] NOT NULL,
	[Note] [nvarchar](550) NULL,
 CONSTRAINT [PK_Abonent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ATC]    Script Date: 1/13/2022 7:35:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ATC](
	[Code] [int] NOT NULL,
	[IDDistrict] [int] NOT NULL,
	[CountNumber] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ATC] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[City]    Script Date: 1/13/2022 7:35:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CityDisctict]    Script Date: 1/13/2022 7:35:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CityDisctict](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDDisctrict] [int] NOT NULL,
	[IDCity] [int] NOT NULL,
 CONSTRAINT [PK_CityDisctict] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Disctrict]    Script Date: 1/13/2022 7:35:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Disctrict](
	[Code] [int] NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Disctrict] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sim]    Script Date: 1/13/2022 7:35:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sim](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PairedPhoneNumber] [int] NOT NULL,
	[Debt] [money] NULL,
	[DateInstalled] [date] NOT NULL,
 CONSTRAINT [PK_Sim] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SimATCAbonent]    Script Date: 1/13/2022 7:35:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SimATCAbonent](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDSim] [int] NOT NULL,
	[IDATC] [int] NOT NULL,
	[IDAbonent] [int] NOT NULL,
 CONSTRAINT [PK_SimATCAbonent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Abonent] ON 

INSERT [dbo].[Abonent] ([ID], [Phone], [FirstName], [LastName], [Address], [PresenceBlocker], [Note]) VALUES (1, N'+79880923412                  ', N'Давудова', N'Марина', N'Республика Дагестан, г. Махачкала, ул. Дахадаева 34А', 1, N'-')
INSERT [dbo].[Abonent] ([ID], [Phone], [FirstName], [LastName], [Address], [PresenceBlocker], [Note]) VALUES (3, N'+79668729384                  ', N'Меликов', N'Михаил', N'Республика Дагестан, г. Махачкала, пр-т Гамидова, 38Д', 0, N'Грубиян')
INSERT [dbo].[Abonent] ([ID], [Phone], [FirstName], [LastName], [Address], [PresenceBlocker], [Note]) VALUES (4, N'+79887637766                  ', N'Алиев', N'Магомед', N'Республика Дагестан, г.Махачкала, ул. Имама Шамиля 134Ш', 1, N'-')
INSERT [dbo].[Abonent] ([ID], [Phone], [FirstName], [LastName], [Address], [PresenceBlocker], [Note]) VALUES (5, N'+79228376444                  ', N'Магомедова', N'Алия', N'Республика Дагестане, г.Дербент, ул. Октябрьское', 1, N'-')
SET IDENTITY_INSERT [dbo].[Abonent] OFF
GO
INSERT [dbo].[ATC] ([Code], [IDDistrict], [CountNumber]) VALUES (1, 34, N'2')
INSERT [dbo].[ATC] ([Code], [IDDistrict], [CountNumber]) VALUES (200, 38, N'100')
INSERT [dbo].[ATC] ([Code], [IDDistrict], [CountNumber]) VALUES (234, 34, N'1')
INSERT [dbo].[ATC] ([Code], [IDDistrict], [CountNumber]) VALUES (1000, 37, N'2000')
GO
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([ID], [Title]) VALUES (2, N'Махачкала')
INSERT [dbo].[City] ([ID], [Title]) VALUES (3, N'Дербент')
SET IDENTITY_INSERT [dbo].[City] OFF
GO
SET IDENTITY_INSERT [dbo].[CityDisctict] ON 

INSERT [dbo].[CityDisctict] ([ID], [IDDisctrict], [IDCity]) VALUES (34, 12934, 2)
INSERT [dbo].[CityDisctict] ([ID], [IDDisctrict], [IDCity]) VALUES (37, 341, 2)
INSERT [dbo].[CityDisctict] ([ID], [IDDisctrict], [IDCity]) VALUES (38, 123, 3)
SET IDENTITY_INSERT [dbo].[CityDisctict] OFF
GO
INSERT [dbo].[Disctrict] ([Code], [Title]) VALUES (123, N'Дербентский район')
INSERT [dbo].[Disctrict] ([Code], [Title]) VALUES (341, N'Лейнинский район')
INSERT [dbo].[Disctrict] ([Code], [Title]) VALUES (12934, N'Кировский район')
GO
SET IDENTITY_INSERT [dbo].[Sim] ON 

INSERT [dbo].[Sim] ([ID], [PairedPhoneNumber], [Debt], [DateInstalled]) VALUES (1, 1000, 200.0000, CAST(N'2020-01-01' AS Date))
INSERT [dbo].[Sim] ([ID], [PairedPhoneNumber], [Debt], [DateInstalled]) VALUES (3, 88172, 23.0000, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[Sim] ([ID], [PairedPhoneNumber], [Debt], [DateInstalled]) VALUES (4, 9998, 20.0000, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[Sim] ([ID], [PairedPhoneNumber], [Debt], [DateInstalled]) VALUES (5, 2983, 0.0000, CAST(N'0001-01-01' AS Date))
SET IDENTITY_INSERT [dbo].[Sim] OFF
GO
SET IDENTITY_INSERT [dbo].[SimATCAbonent] ON 

INSERT [dbo].[SimATCAbonent] ([ID], [IDSim], [IDATC], [IDAbonent]) VALUES (1, 1, 1, 1)
INSERT [dbo].[SimATCAbonent] ([ID], [IDSim], [IDATC], [IDAbonent]) VALUES (3, 3, 234, 3)
INSERT [dbo].[SimATCAbonent] ([ID], [IDSim], [IDATC], [IDAbonent]) VALUES (4, 4, 1000, 4)
INSERT [dbo].[SimATCAbonent] ([ID], [IDSim], [IDATC], [IDAbonent]) VALUES (5, 5, 200, 5)
SET IDENTITY_INSERT [dbo].[SimATCAbonent] OFF
GO
ALTER TABLE [dbo].[ATC]  WITH CHECK ADD  CONSTRAINT [FK_ATC_CityDisctict1] FOREIGN KEY([IDDistrict])
REFERENCES [dbo].[CityDisctict] ([ID])
GO
ALTER TABLE [dbo].[ATC] CHECK CONSTRAINT [FK_ATC_CityDisctict1]
GO
ALTER TABLE [dbo].[CityDisctict]  WITH CHECK ADD  CONSTRAINT [FK_CityDisctict_City] FOREIGN KEY([IDCity])
REFERENCES [dbo].[City] ([ID])
GO
ALTER TABLE [dbo].[CityDisctict] CHECK CONSTRAINT [FK_CityDisctict_City]
GO
ALTER TABLE [dbo].[CityDisctict]  WITH CHECK ADD  CONSTRAINT [FK_CityDisctict_Disctrict] FOREIGN KEY([IDDisctrict])
REFERENCES [dbo].[Disctrict] ([Code])
GO
ALTER TABLE [dbo].[CityDisctict] CHECK CONSTRAINT [FK_CityDisctict_Disctrict]
GO
ALTER TABLE [dbo].[SimATCAbonent]  WITH CHECK ADD  CONSTRAINT [FK_SimATCAbonent_Abonent] FOREIGN KEY([IDAbonent])
REFERENCES [dbo].[Abonent] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SimATCAbonent] CHECK CONSTRAINT [FK_SimATCAbonent_Abonent]
GO
ALTER TABLE [dbo].[SimATCAbonent]  WITH CHECK ADD  CONSTRAINT [FK_SimATCAbonent_ATC] FOREIGN KEY([IDATC])
REFERENCES [dbo].[ATC] ([Code])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SimATCAbonent] CHECK CONSTRAINT [FK_SimATCAbonent_ATC]
GO
ALTER TABLE [dbo].[SimATCAbonent]  WITH CHECK ADD  CONSTRAINT [FK_SimATCAbonent_Sim] FOREIGN KEY([IDSim])
REFERENCES [dbo].[Sim] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SimATCAbonent] CHECK CONSTRAINT [FK_SimATCAbonent_Sim]
GO
