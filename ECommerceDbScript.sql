USE [ECommerce]
GO
/****** Object:  Table [dbo].[BasketClosingReasons]    Script Date: 11.03.2020 15:42:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BasketClosingReasons](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Reason] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_BasketClosingReasons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MemberBaskets]    Script Date: 11.03.2020 15:42:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberBaskets](
	[Id] [uniqueidentifier] NOT NULL,
	[MemberId] [uniqueidentifier] NOT NULL,
	[ProductId] [uniqueidentifier] NOT NULL,
	[ClosingReasonId] [tinyint] NOT NULL,
	[Quantity] [smallint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[ReleaseDate] [datetime] NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_MemberBaskets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Members]    Script Date: 11.03.2020 15:42:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Members](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](75) NOT NULL,
	[Surname] [nvarchar](75) NOT NULL,
 CONSTRAINT [PK_Members] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 11.03.2020 15:42:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[Price] [money] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductStocks]    Script Date: 11.03.2020 15:42:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductStocks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [uniqueidentifier] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_ProductStocks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BasketClosingReasons] ON 

INSERT [dbo].[BasketClosingReasons] ([Id], [Reason]) VALUES (1, N'Added')
INSERT [dbo].[BasketClosingReasons] ([Id], [Reason]) VALUES (2, N'Deleted')
INSERT [dbo].[BasketClosingReasons] ([Id], [Reason]) VALUES (3, N'Ordered')
SET IDENTITY_INSERT [dbo].[BasketClosingReasons] OFF
INSERT [dbo].[Members] ([Id], [Name], [Surname]) VALUES (N'682e9a2a-90d3-4061-86f0-7b0c1ef2230e', N'Second', N'User')
INSERT [dbo].[Members] ([Id], [Name], [Surname]) VALUES (N'4e2bd134-1a19-40bf-b480-b85c59bde0f0', N'First', N'User')
INSERT [dbo].[Members] ([Id], [Name], [Surname]) VALUES (N'c288c386-9364-4eee-aa20-c24ac30283d1', N'Third', N'User')
INSERT [dbo].[Products] ([Id], [Name], [Price], [Status]) VALUES (N'846c7698-c472-4337-ba27-00295bca12be', N'First Product', 11.2200, 1)
INSERT [dbo].[Products] ([Id], [Name], [Price], [Status]) VALUES (N'f607ceec-e3a9-4bad-92a5-3fd162d6c727', N'Third Product', 33.4400, 1)
INSERT [dbo].[Products] ([Id], [Name], [Price], [Status]) VALUES (N'f75738ee-8667-444e-9b0c-7d3fd6227b30', N'Second Product', 22.3300, 1)
SET IDENTITY_INSERT [dbo].[ProductStocks] ON 

INSERT [dbo].[ProductStocks] ([Id], [ProductId], [Quantity]) VALUES (1, N'846c7698-c472-4337-ba27-00295bca12be', 50)
INSERT [dbo].[ProductStocks] ([Id], [ProductId], [Quantity]) VALUES (2, N'f75738ee-8667-444e-9b0c-7d3fd6227b30', 50)
INSERT [dbo].[ProductStocks] ([Id], [ProductId], [Quantity]) VALUES (3, N'f607ceec-e3a9-4bad-92a5-3fd162d6c727', 50)
SET IDENTITY_INSERT [dbo].[ProductStocks] OFF
/****** Object:  Index [Unique_ProductIdOnProductStock]    Script Date: 11.03.2020 15:42:33 ******/
ALTER TABLE [dbo].[ProductStocks] ADD  CONSTRAINT [Unique_ProductIdOnProductStock] UNIQUE NONCLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[MemberBaskets] ADD  CONSTRAINT [DF_MemberBaskets_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[MemberBaskets] ADD  CONSTRAINT [DF_MemberBaskets_CreationDate]  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[MemberBaskets] ADD  CONSTRAINT [DF_MemberBaskets_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Members] ADD  CONSTRAINT [DF_Members_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[MemberBaskets]  WITH CHECK ADD  CONSTRAINT [FK_MemberBaskets_BasketClosingReasons] FOREIGN KEY([ClosingReasonId])
REFERENCES [dbo].[BasketClosingReasons] ([Id])
GO
ALTER TABLE [dbo].[MemberBaskets] CHECK CONSTRAINT [FK_MemberBaskets_BasketClosingReasons]
GO
ALTER TABLE [dbo].[MemberBaskets]  WITH CHECK ADD  CONSTRAINT [FK_MemberBaskets_Members] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([Id])
GO
ALTER TABLE [dbo].[MemberBaskets] CHECK CONSTRAINT [FK_MemberBaskets_Members]
GO
ALTER TABLE [dbo].[MemberBaskets]  WITH CHECK ADD  CONSTRAINT [FK_MemberBaskets_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[MemberBaskets] CHECK CONSTRAINT [FK_MemberBaskets_Products]
GO
ALTER TABLE [dbo].[ProductStocks]  WITH CHECK ADD  CONSTRAINT [FK_ProductStocks_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[ProductStocks] CHECK CONSTRAINT [FK_ProductStocks_Products]
GO
