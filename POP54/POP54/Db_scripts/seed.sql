-- seed.sql
SET IDENTITY_INSERT [dbo].[FurnitureType] ON
INSERT INTO [dbo].[FurnitureType] ([ID], [Name], [Deleted]) VALUES (1, N'Polica', 0)
INSERT INTO [dbo].[FurnitureType] ([ID], [Name], [Deleted]) VALUES (2, N'Garnitura', 0)
INSERT INTO [dbo].[FurnitureType] ([ID], [Name], [Deleted]) VALUES (3, N'Stolica', 0)
INSERT INTO [dbo].[FurnitureType] ([ID], [Name], [Deleted]) VALUES (4, N'Krevet', 0)
SET IDENTITY_INSERT [dbo].[FurnitureType] OFF

SET IDENTITY_INSERT [dbo].[Furniture] ON
INSERT INTO [dbo].[Furniture] ([ID], [FurnitureTypeId], [Name], [ProductCode], [Quantity], [Price], [Deleted], [SaleId], [PriceOnSale]) VALUES (1, 1, N'Mila polica', N'UCJ65', 5, CAST(1253.00 AS Decimal(9, 2)), 0, NULL, CAST(0.00 AS Decimal(9, 2)))
INSERT INTO [dbo].[Furniture] ([ID], [FurnitureTypeId], [Name], [ProductCode], [Quantity], [Price], [Deleted], [SaleId], [PriceOnSale]) VALUES (2, 3, N'Stolica Sanja', N'DSC526', 16, CAST(5240.00 AS Decimal(9, 2)), 0, NULL, CAST(0.00 AS Decimal(9, 2)))
INSERT INTO [dbo].[Furniture] ([ID], [FurnitureTypeId], [Name], [ProductCode], [Quantity], [Price], [Deleted], [SaleId], [PriceOnSale]) VALUES (3, 2, N'Stoja garnitura', N'5151LK', 2, CAST(9033.00 AS Decimal(9, 2)), 0, NULL, CAST(0.00 AS Decimal(9, 2)))
INSERT INTO [dbo].[Furniture] ([ID], [FurnitureTypeId], [Name], [ProductCode], [Quantity], [Price], [Deleted], [SaleId], [PriceOnSale]) VALUES (4, 4, N'Krevet ina', N'652sa', 3, CAST(20001.00 AS Decimal(9, 2)), 0, NULL, CAST(0.00 AS Decimal(9, 2)))
INSERT INTO [dbo].[Furniture] ([ID], [FurnitureTypeId], [Name], [ProductCode], [Quantity], [Price], [Deleted], [SaleId], [PriceOnSale]) VALUES (5, 2, N'a', N'a', 1, CAST(4.00 AS Decimal(9, 2)), 0, NULL, CAST(0.00 AS Decimal(9, 2)))
SET IDENTITY_INSERT [dbo].[Furniture] OFF

INSERT INTO [dbo].[UserTypes] ([Type]) VALUES (0)
INSERT INTO [dbo].[UserTypes] ([Type]) VALUES (1)

SET IDENTITY_INSERT [dbo].[User] ON
INSERT INTO [dbo].[User] ([ID], [Name], [Surname], [Username], [Password], [UserType], [Deleted]) VALUES (1, N'a', N'a', N'a', N'a', 1, 0)
INSERT INTO [dbo].[User] ([ID], [Name], [Surname], [Username], [Password], [UserType], [Deleted]) VALUES (2, N'b', N'b', N'b', N'b', 0, 0)
SET IDENTITY_INSERT [dbo].[User] OFF

SET IDENTITY_INSERT [dbo].[Sale] ON
INSERT INTO [dbo].[Sale] ([ID], [Discount], [StartDate], [EndDate], [Deleted]) VALUES (1, 10, N'2017-11-04 00:00:00', N'2018-11-04 00:00:00', 0)
INSERT INTO [dbo].[Sale] ([ID], [Discount], [StartDate], [EndDate], [Deleted]) VALUES (2, 5, N'2017-11-04 00:00:00', N'2019-11-04 00:00:00', 0)
SET IDENTITY_INSERT [dbo].[Sale] OFF

SET IDENTITY_INSERT [dbo].[AdditionalService] ON
INSERT INTO [dbo].[AdditionalService] ([Id], [Name], [Price], [Deleted]) VALUES (1, N'Sklapanje', CAST(1000.00 AS Decimal(9, 2)), 0)
INSERT INTO [dbo].[AdditionalService] ([Id], [Name], [Price], [Deleted]) VALUES (2, N'Prevoz u gradu', CAST(1500.00 AS Decimal(9, 2)), 0)
INSERT INTO [dbo].[AdditionalService] ([Id], [Name], [Price], [Deleted]) VALUES (3, N'Prevoz van grada', CAST(2000.00 AS Decimal(9, 2)), 0)
SET IDENTITY_INSERT [dbo].[AdditionalService] OFF

SET IDENTITY_INSERT [dbo].[FurnitureStore] ON
INSERT INTO [dbo].[FurnitureStore] ([ID], [Name], [Address], [Phone], [Email], [Website], [CompanyNo], [AccountNo], [PIB]) VALUES (1, N'Forma Idejale', N'Idejalna ulica', N'555333', N'idejale@gmail.com', N'Idejale.com', N'53', N'35', N'3535')
SET IDENTITY_INSERT [dbo].[FurnitureStore] OFF

INSERT INTO [dbo].[FurnitureSales] ([SaleId], [FurnitureId]) VALUES (2, 3)
