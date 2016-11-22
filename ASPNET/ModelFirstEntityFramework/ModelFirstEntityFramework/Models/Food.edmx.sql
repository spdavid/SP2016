
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/22/2016 10:28:43
-- Generated from EDMX file: C:\Users\david\Source\Repos\SP2016\ASPNET\ModelFirstEntityFramework\ModelFirstEntityFramework\Models\Food.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [FOOD];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_FootCategoryFood]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Foods] DROP CONSTRAINT [FK_FootCategoryFood];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Foods]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Foods];
GO
IF OBJECT_ID(N'[dbo].[FootCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FootCategories];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Foods'
CREATE TABLE [dbo].[Foods] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [FoodDescription] nvarchar(max)  NOT NULL,
    [FootCategory_Id] int  NOT NULL
);
GO

-- Creating table 'FootCategories'
CREATE TABLE [dbo].[FootCategories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Colors'
CREATE TABLE [dbo].[Colors] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ColorFood'
CREATE TABLE [dbo].[ColorFood] (
    [Color_Id] int  NOT NULL,
    [Foods_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Foods'
ALTER TABLE [dbo].[Foods]
ADD CONSTRAINT [PK_Foods]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FootCategories'
ALTER TABLE [dbo].[FootCategories]
ADD CONSTRAINT [PK_FootCategories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Colors'
ALTER TABLE [dbo].[Colors]
ADD CONSTRAINT [PK_Colors]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Color_Id], [Foods_Id] in table 'ColorFood'
ALTER TABLE [dbo].[ColorFood]
ADD CONSTRAINT [PK_ColorFood]
    PRIMARY KEY CLUSTERED ([Color_Id], [Foods_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [FootCategory_Id] in table 'Foods'
ALTER TABLE [dbo].[Foods]
ADD CONSTRAINT [FK_FootCategoryFood]
    FOREIGN KEY ([FootCategory_Id])
    REFERENCES [dbo].[FootCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FootCategoryFood'
CREATE INDEX [IX_FK_FootCategoryFood]
ON [dbo].[Foods]
    ([FootCategory_Id]);
GO

-- Creating foreign key on [Color_Id] in table 'ColorFood'
ALTER TABLE [dbo].[ColorFood]
ADD CONSTRAINT [FK_ColorFood_Color]
    FOREIGN KEY ([Color_Id])
    REFERENCES [dbo].[Colors]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Foods_Id] in table 'ColorFood'
ALTER TABLE [dbo].[ColorFood]
ADD CONSTRAINT [FK_ColorFood_Food]
    FOREIGN KEY ([Foods_Id])
    REFERENCES [dbo].[Foods]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ColorFood_Food'
CREATE INDEX [IX_FK_ColorFood_Food]
ON [dbo].[ColorFood]
    ([Foods_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------