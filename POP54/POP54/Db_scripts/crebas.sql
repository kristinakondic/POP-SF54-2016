-- crebas.sql
CREATE DATABASE POP

CREATE TABLE [dbo].[FurnitureType] (
    [ID]      INT IDENTITY(1,1)    NOT NULL,
    [Name]    VARCHAR (80) NULL,
    [Deleted] BIT          NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Furniture] (
    [ID]              INT IDENTITY(1,1)            NOT NULL,
    [FurnitureTypeId] INT            NULL,
    [Name]            VARCHAR (100)  NULL,
    [ProductCode]     VARCHAR (20)   NULL,
    [Quantity]        INT            NULL,
    [Price]           NUMERIC (9, 2) NULL,
    [Deleted]         BIT            NULL,
    [SaleId]          INT            NULL,
    [PriceOnSale]     NUMERIC (9, 2) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([FurnitureTypeId]) REFERENCES [dbo].[FurnitureType] ([ID])
);

CREATE TABLE [dbo].[UserTypes] (
    [Type] VARCHAR(10) NOT NULL,
    PRIMARY KEY CLUSTERED ([Type])
);

CREATE TABLE [dbo].[User] (
    [Id]       INT IDENTITY(1,1)     NOT NULL,
    [Name]     NCHAR (10) NOT NULL,
    [Surname]  NCHAR (10) NOT NULL,
    [Username] NCHAR (10) NOT NULL,
    [Password] NCHAR (10) NOT NULL,
    [UserType] VARCHAR(10) NOT NULL,
    [Deleted] BIT NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [User_Type] FOREIGN KEY ([UserType]) REFERENCES [dbo].[UserTypes] ([Type])
);

CREATE TABLE [dbo].[Sale] (
    [Id]        INT IDENTITY(1,1)      NOT NULL,
    [Discount]  NUMERIC (9) NOT NULL,
    [StartDate] DATETIME    NOT NULL,
    [EndDate]   DATETIME    NOT NULL,
    [Deleted]   BIT         NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[FurnitureStore] (
    [Id]        INT IDENTITY(1,1)	 	NOT NULL,
    [Name]      NCHAR (10) NOT NULL,
    [Address]   NCHAR (10) NOT NULL,
    [Phone]     NCHAR (10) NOT NULL,
    [Email]     NCHAR (10) NOT NULL,
    [Website]   NCHAR (10) NOT NULL,
    [CompanyNo] NCHAR (10) NOT NULL,
    [AccountNo] NCHAR (10) NOT NULL,
    [PIB]       NCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[AdditionalService] (
    [Id]      INT IDENTITY(1,1) NOT NULL,
    [Name]    NCHAR (15)     NULL,
    [Price]   NUMERIC (9, 2) NULL,
    [Deleted] BIT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Bill] (
    [Id]         INT IDENTITY(1,1)			NOT NULL,
    [DateOfSale] DATETIME       NOT NULL,
    [BillNo]     INT            NOT NULL,
    [Buyer]      NCHAR (10)     NOT NULL,
    [PDV]        NUMERIC (3, 2) NOT NULL,
    [FullPrice]  NUMERIC (9, 2) DEFAULT ((0)) NOT NULL,
    [Deleted]    BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[BillAdditionalServices] (
    [BillId]      INT IDENTITY(1,1)			NOT NULL,
    [AdditinalServicesId] INT NOT NULL,
    CONSTRAINT [Bill_idd] FOREIGN KEY ([BillId]) REFERENCES [dbo].[Bill] ([Id]),
    CONSTRAINT [AdditionalS_id] FOREIGN KEY ([AdditinalServicesId]) REFERENCES [dbo].[AdditionalService] ([Id]), 
    CONSTRAINT [PK_BillAdditionalServices] PRIMARY KEY ([BillId])
);

CREATE TABLE [dbo].[BillFurniture] (
    [BillId]      INT IDENTITY(1,1)  NOT NULL,
    [FurnitureId] INT NOT NULL,
    CONSTRAINT [Bill_id] FOREIGN KEY ([BillId]) REFERENCES [dbo].[Bill] ([Id]),
    CONSTRAINT [Furniture_id] FOREIGN KEY ([FurnitureId]) REFERENCES [dbo].[Furniture] ([ID]), 
    CONSTRAINT [PK_BillFurniture] PRIMARY KEY ([BillId])
);
