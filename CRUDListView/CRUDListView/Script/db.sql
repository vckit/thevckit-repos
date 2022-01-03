CREATE DATABASE [dbUser]

USE [dbUser]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 04.01.2022 0:39:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserPersonal]    Script Date: 04.01.2022 0:39:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPersonal](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[Phone] [char](15) NOT NULL,
	[Telegram] [nvarchar](50) NOT NULL,
	[IDStatus] [int] NOT NULL,
	[Photo] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_UserPersonal] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([ID], [Title]) VALUES (1, N'Busy')
INSERT [dbo].[Status] ([ID], [Title]) VALUES (2, N'Freedom')
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
SET IDENTITY_INSERT [dbo].[UserPersonal] ON 

INSERT [dbo].[UserPersonal] ([ID], [FirstName], [LastName], [Email], [DateOfBirth], [Phone], [Telegram], [IDStatus], [Photo]) VALUES (11, N'Marian', N'Pashaeva', N'marian@mail.ru', CAST(N'2001-01-01' AS Date), N'+79998882222   ', N'marian', 1, N'unnamed.jpg')
SET IDENTITY_INSERT [dbo].[UserPersonal] OFF
GO
ALTER TABLE [dbo].[UserPersonal]  WITH CHECK ADD  CONSTRAINT [FK_UserPersonal_Status] FOREIGN KEY([IDStatus])
REFERENCES [dbo].[Status] ([ID])
GO
ALTER TABLE [dbo].[UserPersonal] CHECK CONSTRAINT [FK_UserPersonal_Status]
GO
