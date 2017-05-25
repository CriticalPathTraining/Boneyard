
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/08/2014 14:53:59
-- Generated from EDMX file: C:\Demos\WingtipSalesModel\WingtipSalesModel\WingtipSalesModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [WingtipSales];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CustomerInvoice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Invoices] DROP CONSTRAINT [FK_CustomerInvoice];
GO
IF OBJECT_ID(N'[dbo].[FK_InvoiceInvoiceDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvoiceDetails] DROP CONSTRAINT [FK_InvoiceInvoiceDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductInvoiceDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvoiceDetails] DROP CONSTRAINT [FK_ProductInvoiceDetail];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customers];
GO
IF OBJECT_ID(N'[dbo].[Invoices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Invoices];
GO
IF OBJECT_ID(N'[dbo].[InvoiceDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvoiceDetails];
GO
IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Company] nvarchar(max)  NULL,
    [EmailAddress] nvarchar(max)  NULL,
    [WorkPhone] nvarchar(max)  NULL,
    [HomePhone] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NULL,
    [City] nvarchar(max)  NULL,
    [State] nvarchar(max)  NULL,
    [ZipCode] nvarchar(max)  NULL,
    [Gender] nvarchar(1)  NULL,
    [BirthDate] datetime  NOT NULL,
    [FirstPurchaseDate] datetime  NULL,
    [LastPurchaseDate] datetime  NULL
);
GO

-- Creating table 'Invoices'
CREATE TABLE [dbo].[Invoices] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [InvoiceNumber] nvarchar(max)  NULL,
    [InvoiceDate] datetime  NOT NULL,
    [InvoiceAmount] decimal(9,2)  NOT NULL,
    [InvoiceType] nvarchar(max)  NOT NULL,
    [CustomerId] int  NOT NULL
);
GO

-- Creating table 'InvoiceDetails'
CREATE TABLE [dbo].[InvoiceDetails] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Quantity] int  NOT NULL,
    [Price] decimal(9,2)  NOT NULL,
    [InvoiceId] int  NOT NULL,
    [ProductId] int  NOT NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] ([Id] int IDENTITY(1,1) NOT NULL,[ProductCode] nvarchar(max)  NOT NULL,[Title] nvarchar(max)  NOT NULL,[Description] nvarchar(max)  NULL,[ProductCategory] nvarchar(max)  NULL,[UnitCost] decimal(18,0)  NULL,[ListPrice] decimal(9,2)  NOT NULL,[Color] nvarchar(max)  NULL,[MinimumAge] int  NULL,[MaximumAge] int  NULL);

GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Invoices'
ALTER TABLE [dbo].[Invoices]
ADD CONSTRAINT [PK_Invoices]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'InvoiceDetails'
ALTER TABLE [dbo].[InvoiceDetails]
ADD CONSTRAINT [PK_InvoiceDetails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CustomerId] in table 'Invoices'
ALTER TABLE [dbo].[Invoices]
ADD CONSTRAINT [FK_CustomerInvoice]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerInvoice'
CREATE INDEX [IX_FK_CustomerInvoice]
ON [dbo].[Invoices]
    ([CustomerId]);
GO

-- Creating foreign key on [InvoiceId] in table 'InvoiceDetails'
ALTER TABLE [dbo].[InvoiceDetails]
ADD CONSTRAINT [FK_InvoiceInvoiceDetail]
    FOREIGN KEY ([InvoiceId])
    REFERENCES [dbo].[Invoices]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvoiceInvoiceDetail'
CREATE INDEX [IX_FK_InvoiceInvoiceDetail]
ON [dbo].[InvoiceDetails]
    ([InvoiceId]);
GO

-- Creating foreign key on [ProductId] in table 'InvoiceDetails'
ALTER TABLE [dbo].[InvoiceDetails]
ADD CONSTRAINT [FK_ProductInvoiceDetail]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductInvoiceDetail'
CREATE INDEX [IX_FK_ProductInvoiceDetail]
ON [dbo].[InvoiceDetails]
    ([ProductId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------