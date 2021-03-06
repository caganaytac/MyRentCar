﻿USE [ReCapDemo]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 4/26/2021 2:44:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[BrandId] [int] IDENTITY(1,1) NOT NULL,
	[BrandName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BrandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarImages]    Script Date: 4/26/2021 2:44:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarId] [int] NOT NULL,
	[ImagePath] [nvarchar](max) NOT NULL,
	[Date] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 4/26/2021 2:44:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[CarId] [int] IDENTITY(1,1) NOT NULL,
	[BrandId] [int] NOT NULL,
	[ColorId] [int] NOT NULL,
	[CarName] [varchar](50) NOT NULL,
	[ModelYear] [varchar](4) NOT NULL,
	[DailyPrice] [decimal](10, 2) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[CreditScore] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CarId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Colors]    Script Date: 4/26/2021 2:44:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colors](
	[ColorId] [int] IDENTITY(1,1) NOT NULL,
	[ColorName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ColorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CreditCards]    Script Date: 4/26/2021 2:44:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditCards](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CardHolderName] [varchar](50) NOT NULL,
	[CardNumber] [varchar](50) NOT NULL,
	[ExpMonth] [int] NOT NULL,
	[ExpYear] [int] NOT NULL,
	[Cvv] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 4/26/2021 2:44:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CompanyName] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OperationClaims]    Script Date: 4/26/2021 2:44:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](250) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rentals]    Script Date: 4/26/2021 2:44:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rentals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[RentDate] [datetime] NOT NULL,
	[ReturnDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserCreditScores]    Script Date: 4/26/2021 2:44:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserCreditScores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CreditScore] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserOperationClaims]    Script Date: 4/26/2021 2:44:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserOperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[OperationClaimId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserProfilePhotos]    Script Date: 4/26/2021 2:44:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfilePhotos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ImagePath] [nvarchar](max) NOT NULL,
	[Date] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 4/26/2021 2:44:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Status] [bit] NOT NULL,
	[PasswordHash] [varbinary](128) NOT NULL,
	[PasswordSalt] [varbinary](128) NOT NULL,
	[Email] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Brands] ON 

INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (1, N'Mercedes')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2, N'VolksWagen')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (3, N'Tesla')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (4, N'Toyota')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (1002, N'Pegout')
SET IDENTITY_INSERT [dbo].[Brands] OFF
GO
SET IDENTITY_INSERT [dbo].[CarImages] ON 

INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (1006, 17, N'da921939-799c-4ffc-a2f1-de5ca83bc3ef.png', CAST(N'2021-03-17' AS Date))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (1007, 17, N'ea14c55e-f117-4a16-8040-207b2f36570c.jpg', CAST(N'2021-03-17' AS Date))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (2002, 10, N'd2ce3136-78e7-499a-b976-5e11b8530a86_4_11_2021.jpg', CAST(N'2021-04-11' AS Date))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (2004, 15, N'776f683e-cb60-4acc-a97a-bc7b33e9ba4d_3_18_2021.jpg', CAST(N'2021-03-18' AS Date))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (2005, 16, N'd106f53b-18b1-40bf-9f7d-15ba8d8aa8e4_3_18_2021.jpg', CAST(N'2021-03-18' AS Date))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (2006, 1002, N'a300cc72-89b6-46d9-a0f4-70594f074475_3_18_2021.jpg', CAST(N'2021-03-18' AS Date))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (2007, 2003, N'5fc93710-d0b7-4e55-8ec7-31d39d7226c4_3_18_2021.jpg', CAST(N'2021-03-18' AS Date))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (2008, 2006, N'4d209ba4-d4b8-4dbe-b908-7ab80b71763e_3_18_2021.jpg', CAST(N'2021-03-18' AS Date))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (2009, 2007, N'117ef362-6f0b-453f-91e6-c824a8c15f97_3_18_2021.jpg', CAST(N'2021-03-18' AS Date))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (2010, 2008, N'7ef5c41d-1872-4a59-80a4-ce05cfc572d0_3_18_2021.jpg', CAST(N'2021-03-18' AS Date))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (2011, 2010, N'63c1b3e6-863f-4fdb-bb2f-c3e41fd548ef_3_18_2021.jpg', CAST(N'2021-03-18' AS Date))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (2012, 2011, N'2aba7139-1137-4dea-8629-76f14c8b9278_3_18_2021.jpg', CAST(N'2021-03-18' AS Date))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (2013, 2013, N'0cee6ead-e663-42b6-ae2d-3ce9038ba9b0_3_18_2021.jpg', CAST(N'2021-03-18' AS Date))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (2014, 2014, N'95c7ed31-12bb-47f8-8486-e0eb9c7cebf2_3_18_2021.jpg', CAST(N'2021-03-18' AS Date))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (2015, 2015, N'df62c10b-ed5c-4902-ac0b-e5abc2add0e1_3_18_2021.jpg', CAST(N'2021-03-18' AS Date))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (2016, 18, N'b443cf39-82d0-43d9-8758-bcea2c243a68_3_18_2021.jpg', CAST(N'2021-03-18' AS Date))
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (3003, 11004, N'ea1f9569-68fa-41e0-afce-8680a4890fb1_4_11_2021.jpg', CAST(N'2021-04-11' AS Date))
SET IDENTITY_INSERT [dbo].[CarImages] OFF
GO
SET IDENTITY_INSERT [dbo].[Cars] ON 

INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [CarName], [ModelYear], [DailyPrice], [Description], [CreditScore]) VALUES (10, 1, 1, N'MAYBACH', N'2020', CAST(190.00 AS Decimal(10, 2)), N'It''s only rival is plane.', 1850)
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [CarName], [ModelYear], [DailyPrice], [Description], [CreditScore]) VALUES (15, 1, 2, N'MAYBACH', N'2019', CAST(150.00 AS Decimal(10, 2)), N'It''s only rival is plane.', 1850)
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [CarName], [ModelYear], [DailyPrice], [Description], [CreditScore]) VALUES (16, 2, 1, N'PASSAT', N'2020', CAST(100.00 AS Decimal(10, 2)), N'Perfect Performance', 1300)
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [CarName], [ModelYear], [DailyPrice], [Description], [CreditScore]) VALUES (17, 3, 3, N'MODEL3', N'2021', CAST(50.00 AS Decimal(10, 2)), N'Zero expense!', 1500)
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [CarName], [ModelYear], [DailyPrice], [Description], [CreditScore]) VALUES (18, 4, 4, N'COROLLA', N'2021', CAST(100.00 AS Decimal(10, 2)), N'Japanese quality.', 800)
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [CarName], [ModelYear], [DailyPrice], [Description], [CreditScore]) VALUES (1002, 3, 1, N'MODEL S', N'2020', CAST(190.00 AS Decimal(10, 2)), N'It''s only rival is plane.', 1000)
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [CarName], [ModelYear], [DailyPrice], [Description], [CreditScore]) VALUES (2003, 3, 2, N'MODEL X', N'2021', CAST(200.00 AS Decimal(10, 2)), N'Hawks fly in the sky and Model X', 1500)
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [CarName], [ModelYear], [DailyPrice], [Description], [CreditScore]) VALUES (2006, 3, 3, N'MODEL X', N'2021', CAST(200.00 AS Decimal(10, 2)), N'Hawks fly in the sky and Model X', 1500)
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [CarName], [ModelYear], [DailyPrice], [Description], [CreditScore]) VALUES (2007, 4, 3, N'COROLLA', N'2019', CAST(85.00 AS Decimal(10, 2)), N'Japanese quality.', 900)
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [CarName], [ModelYear], [DailyPrice], [Description], [CreditScore]) VALUES (2008, 1, 1002, N'MAYBACH', N'2019', CAST(137.00 AS Decimal(10, 2)), N'It''s only rival is plane.', 1700)
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [CarName], [ModelYear], [DailyPrice], [Description], [CreditScore]) VALUES (2010, 2, 1, N'ARTEON', N'2020', CAST(98.00 AS Decimal(10, 2)), N'It''s only rival is plane.', 1100)
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [CarName], [ModelYear], [DailyPrice], [Description], [CreditScore]) VALUES (2011, 2, 1, N'PASSAT', N'2021', CAST(120.00 AS Decimal(10, 2)), N'It''s only rival is plane.', 900)
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [CarName], [ModelYear], [DailyPrice], [Description], [CreditScore]) VALUES (2013, 1002, 1002, N'5008', N'2020', CAST(100.00 AS Decimal(10, 2)), N'It''s only rival is plane.', 1200)
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [CarName], [ModelYear], [DailyPrice], [Description], [CreditScore]) VALUES (2014, 1002, 1, N'3008', N'2018', CAST(75.00 AS Decimal(10, 2)), N'It''s only rival is plane.', 1100)
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [CarName], [ModelYear], [DailyPrice], [Description], [CreditScore]) VALUES (2015, 1002, 3, N'508', N'2021', CAST(130.00 AS Decimal(10, 2)), N'It''s only rival is plane.', 900)
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [CarName], [ModelYear], [DailyPrice], [Description], [CreditScore]) VALUES (9002, 2, 1, N'POLO', N'2015', CAST(40.00 AS Decimal(10, 2)), N'The most economic.', 350)
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [CarName], [ModelYear], [DailyPrice], [Description], [CreditScore]) VALUES (11004, 2, 2, N'POLO', N'2021', CAST(60.00 AS Decimal(10, 2)), N'The newest and the most economic.', 600)
SET IDENTITY_INSERT [dbo].[Cars] OFF
GO
SET IDENTITY_INSERT [dbo].[Colors] ON 

INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (1, N'White')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (2, N'Black')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (3, N'Red')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (4, N'Blue')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (1002, N'Yellow')
SET IDENTITY_INSERT [dbo].[Colors] OFF
GO
SET IDENTITY_INSERT [dbo].[CreditCards] ON 

INSERT [dbo].[CreditCards] ([Id], [UserId], [CardHolderName], [CardNumber], [ExpMonth], [ExpYear], [Cvv]) VALUES (2, 1, N'CAGAN AYTAC', N'5555555555555555', 3, 2025, N'789')
INSERT [dbo].[CreditCards] ([Id], [UserId], [CardHolderName], [CardNumber], [ExpMonth], [ExpYear], [Cvv]) VALUES (1004, 1, N'CAGAN AYTAC', N'4444444444444444', 4, 2035, N'756')
INSERT [dbo].[CreditCards] ([Id], [UserId], [CardHolderName], [CardNumber], [ExpMonth], [ExpYear], [Cvv]) VALUES (1005, 1, N'OPYUY TYUI', N'4565159871526687', 11, 36, N'426')
INSERT [dbo].[CreditCards] ([Id], [UserId], [CardHolderName], [CardNumber], [ExpMonth], [ExpYear], [Cvv]) VALUES (2005, 1005, N'ENGIN DEMIOG', N'7894654925846549', 2, 23, N'789')
INSERT [dbo].[CreditCards] ([Id], [UserId], [CardHolderName], [CardNumber], [ExpMonth], [ExpYear], [Cvv]) VALUES (3005, 4, N'KELMET CANMET', N'5698753215984569', 2, 38, N'478')
SET IDENTITY_INSERT [dbo].[CreditCards] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([CustomerId], [UserId], [CompanyName]) VALUES (12, 4, N'Aytac Inc.')
INSERT [dbo].[Customers] ([CustomerId], [UserId], [CompanyName]) VALUES (1014, 1005, N'Asd Company')
INSERT [dbo].[Customers] ([CustomerId], [UserId], [CompanyName]) VALUES (2014, 1, N'Aytac Inc.')
INSERT [dbo].[Customers] ([CustomerId], [UserId], [CompanyName]) VALUES (2015, 2006, N'Asd Company')
INSERT [dbo].[Customers] ([CustomerId], [UserId], [CompanyName]) VALUES (3013, 8006, N'Jennifer Kuhlo')
INSERT [dbo].[Customers] ([CustomerId], [UserId], [CompanyName]) VALUES (4013, 9006, N'Salmani Osmani')
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[OperationClaims] ON 

INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (1, N'admin')
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (2, N'moderator')
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (3, N'user')
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (4, N'car.add')
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (5, N'car.update')
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (1002, N'car.delete')
SET IDENTITY_INSERT [dbo].[OperationClaims] OFF
GO
SET IDENTITY_INSERT [dbo].[Rentals] ON 

INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (14009, 9002, 3013, CAST(N'2021-04-07T00:00:00.000' AS DateTime), CAST(N'2021-04-08T00:00:00.000' AS DateTime))
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (15009, 17, 2014, CAST(N'2021-04-08T00:00:00.000' AS DateTime), CAST(N'2021-10-08T00:00:00.000' AS DateTime))
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (16009, 10, 2014, CAST(N'2021-04-09T00:00:00.000' AS DateTime), CAST(N'2021-04-16T00:00:00.000' AS DateTime))
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (16010, 9002, 2014, CAST(N'2021-04-09T00:00:00.000' AS DateTime), CAST(N'2021-04-21T00:00:00.000' AS DateTime))
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (17009, 1002, 2014, CAST(N'2021-04-11T00:00:00.000' AS DateTime), CAST(N'2021-04-14T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Rentals] OFF
GO
SET IDENTITY_INSERT [dbo].[UserCreditScores] ON 

INSERT [dbo].[UserCreditScores] ([Id], [UserId], [CreditScore]) VALUES (1, 1, 1999)
INSERT [dbo].[UserCreditScores] ([Id], [UserId], [CreditScore]) VALUES (2, 4, 1000)
INSERT [dbo].[UserCreditScores] ([Id], [UserId], [CreditScore]) VALUES (4, 1005, 1999)
INSERT [dbo].[UserCreditScores] ([Id], [UserId], [CreditScore]) VALUES (5, 2006, 400)
INSERT [dbo].[UserCreditScores] ([Id], [UserId], [CreditScore]) VALUES (2002, 8006, 450)
INSERT [dbo].[UserCreditScores] ([Id], [UserId], [CreditScore]) VALUES (3002, 9006, 400)
SET IDENTITY_INSERT [dbo].[UserCreditScores] OFF
GO
SET IDENTITY_INSERT [dbo].[UserOperationClaims] ON 

INSERT [dbo].[UserOperationClaims] ([Id], [UserId], [OperationClaimId]) VALUES (1, 1, 1)
INSERT [dbo].[UserOperationClaims] ([Id], [UserId], [OperationClaimId]) VALUES (2, 4, 4)
INSERT [dbo].[UserOperationClaims] ([Id], [UserId], [OperationClaimId]) VALUES (1002, 1005, 1)
INSERT [dbo].[UserOperationClaims] ([Id], [UserId], [OperationClaimId]) VALUES (3002, 2006, 3)
INSERT [dbo].[UserOperationClaims] ([Id], [UserId], [OperationClaimId]) VALUES (3005, 4, 5)
INSERT [dbo].[UserOperationClaims] ([Id], [UserId], [OperationClaimId]) VALUES (3006, 4, 1002)
INSERT [dbo].[UserOperationClaims] ([Id], [UserId], [OperationClaimId]) VALUES (4002, 8006, 3)
INSERT [dbo].[UserOperationClaims] ([Id], [UserId], [OperationClaimId]) VALUES (5002, 9006, 3)
SET IDENTITY_INSERT [dbo].[UserOperationClaims] OFF
GO
SET IDENTITY_INSERT [dbo].[UserProfilePhotos] ON 

INSERT [dbo].[UserProfilePhotos] ([Id], [UserId], [ImagePath], [Date]) VALUES (2, 1, N'e670cee6-8f76-4ab3-9e43-1c02e28b59e5_4_5_2021.jpg', CAST(N'2021-04-04' AS Date))
SET IDENTITY_INSERT [dbo].[UserProfilePhotos] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Status], [PasswordHash], [PasswordSalt], [Email]) VALUES (1, N'Cagan', N'Aytac', 1, 0x9090D88D8B09CA6C5423FB0A808D48342C9A746C2D8CE071194AA3C0F34362287ABDA1CAFA2233EB45ABA45EB91D26FEBE8774AC0748E53088E39571FDB334FC, 0x1C39CF8A7072C4921BB15559A21522EBF223205FA2FA2554DF1AF1B06025CAA31E0DB3FB4AF32EA48F595B11A0839EF03F9684011A60A042847FD5A41AFACE34C692AA01294EC0BC14DDF9012596E69CB6AFFC14B34721F57513B5BEF80407A7E922C1E431C1E27495F144F59996A05571B120F09C73D3CAFEB98B18901A9B8E, N'cagan.aytac09@gmail.com')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Status], [PasswordHash], [PasswordSalt], [Email]) VALUES (4, N'Kelmet', N'Canmet', 1, 0x81B212167E68F291CF0795D4AA4532A05CA818D8387B0E9B7D9FC54A6AAF263EE9690C1E5185DB600EE67474679C5CE20D672DE09B3AA664CC8703F6E3C6907300000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000, 0x77AEBD34B3914CFC7D8CD61CD9FF34FFB61F4BB8356F838C57C1A8A87A04F70076372D44C6C46AC7034757AD04705750F9A0D4F43D5793D2A43192C7B1336B8CC06C8A9D5B211C9E1C635A234BBD98B3530AC90A1FD6294ECA9B1442B2C25B023345DB34281EBEC34663C6BD058BE551B6CC35A34027C39F89CFA1CE8C027983, N'kelmetcanmet@gmail.com')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Status], [PasswordHash], [PasswordSalt], [Email]) VALUES (1005, N'Engin', N'Demirog', 1, 0xC2BB5512A7E1F5732699D5E241E1DEF616C81BFA0F29FA2DF7618BE90B9DE0B13AFE7C88B9DA317470520FF256DF7FDF5FF24FB3A343834DA0A32F7D887FB248, 0xF06A417A0512CEEA437D3B273A12A72EDFC0302FB4ACA130AD2F73A350DABE2230E818C9D0F688899A30FB58FBD5E21408A65389068AF1DAB1A0B1BC35DBD0ED187BEE0969026C84E18BE6D8902AEA5269E6717714C059C4C2BED4F782955C450D3422E537DE7AB54FE3672D07F6C043CB03EC9A8F0EEF2DF70135A9B4BBC10B, N'engindemirog@gmail.com')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Status], [PasswordHash], [PasswordSalt], [Email]) VALUES (2006, N'Jenny', N'Mack', 1, 0x81B212167E68F291CF0795D4AA4532A05CA818D8387B0E9B7D9FC54A6AAF263EE9690C1E5185DB600EE67474679C5CE20D672DE09B3AA664CC8703F6E3C6907300000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000, 0x77AEBD34B3914CFC7D8CD61CD9FF34FFB61F4BB8356F838C57C1A8A87A04F70076372D44C6C46AC7034757AD04705750F9A0D4F43D5793D2A43192C7B1336B8CC06C8A9D5B211C9E1C635A234BBD98B3530AC90A1FD6294ECA9B1442B2C25B023345DB34281EBEC34663C6BD058BE551B6CC35A34027C39F89CFA1CE8C027983, N'jennymack@gmail.com')
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Status], [PasswordHash], [PasswordSalt], [Email]) VALUES (8006, N'Jennifer', N'Kuhlo', 1, 0x89D97AAF078132358455C10C6CCDBF04576E4FA18EAE2646F60D79F51C70A8961268E300F2FBA85FD2F7B503200DD6A7540AACE8AB4A83B1C7103257124085D2, 0x1A26C9FA6F3E3C930B5EFD81C82FA7238C4E02CA5014FC36C8547E72319D93872DE59A6402630C9365C772D887390BA6F904B5DFC8EAFBF51A23EB8FEEBD5B0B04288CA2AB61F3C3325B6233ECB5B9D4E71D8A3C41BCB984262975469457AEB93F758FF282903DF6402F2B6E85F58A3E542ED8145ECB2FABB4F2AE343784A1CA, N'jennifferkuhlo@gmail.com')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[CarImages]  WITH CHECK ADD FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([CarId])
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Car_Brand] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brands] ([BrandId])
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Car_Brand]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Car_Color] FOREIGN KEY([ColorId])
REFERENCES [dbo].[Colors] ([ColorId])
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Car_Color]
GO
ALTER TABLE [dbo].[CreditCards]  WITH CHECK ADD  CONSTRAINT [FK_CreditCard_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[CreditCards] CHECK CONSTRAINT [FK_CreditCard_UserId]
GO
