-- crebas.sql
CREATE DATABASE POP

CREATE TABLE [dbo].[FurnitureType] (
    [ID]      INT          IDENTITY (1, 1) NOT NULL,
    [Name]    VARCHAR (80) NULL,
    [Deleted] BIT          NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);


CREATE TABLE [dbo].[Furniture] (
    [ID]              INT            IDENTITY (1, 1) NOT NULL,
    [FurnitureTypeId] INT            NULL,
    [Name]            VARCHAR (100)  NULL,
    [ProductCode]     VARCHAR (20)   NULL,
    [Quantity]        INT            NULL,
    [Price]           NUMERIC (9, 2) NULL,
    [Deleted]         BIT            NULL,
    [SaleId]          INT            NULL,
    [PriceOnSale]     NUMERIC (9, 2) DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([FurnitureTypeId]) REFERENCES [dbo].[FurnitureType] ([ID])
);

CREATE TABLE [dbo].[FurnitureStore] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (50) NOT NULL,
    [Address]   VARCHAR (50) NOT NULL,
    [Phone]     VARCHAR (50) NOT NULL,
    [Email]     VARCHAR (50) NOT NULL,
    [Website]   VARCHAR (50) NOT NULL,
    [CompanyNo] VARCHAR (50) NOT NULL,
    [AccountNo] VARCHAR (50) NOT NULL,
    [PIB]       VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE TABLE [dbo].[Sale] (
    [Id]        INT      IDENTITY (1, 1) NOT NULL,
    [Discount]  INT      NOT NULL,
    [StartDate] DATETIME NOT NULL,
    [EndDate]   DATETIME NOT NULL,
    [Deleted]   BIT      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[UserTypes] (
    [Type] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Type] ASC)
);

CREATE TABLE [dbo].[User] (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (50) NOT NULL,
    [Surname]  VARCHAR (50) NOT NULL,
    [Username] VARCHAR (50) NOT NULL,
    [Password] VARCHAR (50) NOT NULL,
    [UserType] INT          NOT NULL,
    [Deleted]  BIT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [User_Type] FOREIGN KEY ([UserType]) REFERENCES [dbo].[UserTypes] ([Type])
);

CREATE TABLE [dbo].[AdditionalService] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [Name]    VARCHAR (50)   NULL,
    [Price]   NUMERIC (9, 2) NULL,
    [Deleted] BIT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Bill] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [DateOfSale] DATETIME       NOT NULL,
    [BillNo]     INT            NOT NULL,
    [Buyer]      VARCHAR (50)   NOT NULL,
    [FullPrice]  NUMERIC (9, 2) NOT NULL,
    [Deleted]    BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE TABLE [dbo].[BillAdditionalServices] (
    [BillId]              INT NOT NULL,
    [AdditionalServiceId] INT NOT NULL,
    CONSTRAINT [Bill_idd] FOREIGN KEY ([BillId]) REFERENCES [dbo].[Bill] ([Id]),
    CONSTRAINT [AdditionalS_id] FOREIGN KEY ([AdditionalServiceId]) REFERENCES [dbo].[AdditionalService] ([Id])
);


CREATE TABLE [dbo].[BillFurniture] (
    [BillId]      INT NOT NULL,
    [FurnitureId] INT NOT NULL,
    CONSTRAINT [Bill_id] FOREIGN KEY ([BillId]) REFERENCES [dbo].[Bill] ([Id]),
    CONSTRAINT [Furniture_id] FOREIGN KEY ([FurnitureId]) REFERENCES [dbo].[Furniture] ([ID])
);


CREATE TABLE [dbo].[FurnitureSales] (
    [SaleId]      INT NOT NULL,
    [FurnitureId] INT NOT NULL,
    CONSTRAINT [Sale_id] FOREIGN KEY ([SaleId]) REFERENCES [dbo].[Sale] ([Id]),
    FOREIGN KEY ([FurnitureId]) REFERENCES [dbo].[Furniture] ([ID])
);


