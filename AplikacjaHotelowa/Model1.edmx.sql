
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/22/2017 17:15:36
-- Generated from EDMX file: c:\users\hubi\source\repos\AplikacjaHotelowa\AplikacjaHotelowa\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AplikacjaHotelowa];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Osoby'
CREATE TABLE [dbo].[Osoby] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Imie] nvarchar(max)  NOT NULL,
    [Nazwisko] nvarchar(max)  NOT NULL,
    [DataUrodzenia] nvarchar(max)  NOT NULL,
    [Tel] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Rezerwacja'
CREATE TABLE [dbo].[Rezerwacja] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StatusZameldowaniaId] int  NOT NULL,
    [ApartamentyId] int  NOT NULL,
    [OsobyId] int  NOT NULL,
    [StatusRezerwacji] nvarchar(max)  NOT NULL,
    [TerminPrzybycia] datetime  NOT NULL,
    [TerminOdjazdu] datetime  NOT NULL
);
GO

-- Creating table 'Apartamenty'
CREATE TABLE [dbo].[Apartamenty] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BudynkiId] int  NOT NULL,
    [TypId] int  NOT NULL,
    [NumerPokoju] int  NOT NULL,
    [Cena] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'Budynki'
CREATE TABLE [dbo].[Budynki] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nazwa] nvarchar(max)  NOT NULL,
    [TelMenadzer] int  NOT NULL,
    [TelRecepcja] int  NOT NULL,
    [Opis] nvarchar(max)  NULL,
    [Adresy_Id] int  NOT NULL
);
GO

-- Creating table 'Typ'
CREATE TABLE [dbo].[Typ] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nazwa] nvarchar(max)  NOT NULL,
    [Opis] nvarchar(max)  NULL
);
GO

-- Creating table 'Udogodnienia'
CREATE TABLE [dbo].[Udogodnienia] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nazwa] nvarchar(max)  NOT NULL,
    [opis] nvarchar(max)  NULL
);
GO

-- Creating table 'StatusZameldowania'
CREATE TABLE [dbo].[StatusZameldowania] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [opis] nvarchar(max)  NOT NULL,
    [OsobyId] int  NOT NULL
);
GO

-- Creating table 'UdogodnieniaLista'
CREATE TABLE [dbo].[UdogodnieniaLista] (
    [UdogodnieniaId] int  NOT NULL,
    [ApartamentyId] int  NOT NULL
);
GO

-- Creating table 'Adresy'
CREATE TABLE [dbo].[Adresy] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Miasto] nvarchar(max)  NOT NULL,
    [Ulica] nvarchar(max)  NOT NULL,
    [NumerBudynku] nvarchar(max)  NOT NULL,
    [Województwo] nvarchar(max)  NOT NULL,
    [Kraj] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Osoby'
ALTER TABLE [dbo].[Osoby]
ADD CONSTRAINT [PK_Osoby]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Rezerwacja'
ALTER TABLE [dbo].[Rezerwacja]
ADD CONSTRAINT [PK_Rezerwacja]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Apartamenty'
ALTER TABLE [dbo].[Apartamenty]
ADD CONSTRAINT [PK_Apartamenty]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Budynki'
ALTER TABLE [dbo].[Budynki]
ADD CONSTRAINT [PK_Budynki]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Typ'
ALTER TABLE [dbo].[Typ]
ADD CONSTRAINT [PK_Typ]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Udogodnienia'
ALTER TABLE [dbo].[Udogodnienia]
ADD CONSTRAINT [PK_Udogodnienia]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StatusZameldowania'
ALTER TABLE [dbo].[StatusZameldowania]
ADD CONSTRAINT [PK_StatusZameldowania]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UdogodnieniaId], [ApartamentyId] in table 'UdogodnieniaLista'
ALTER TABLE [dbo].[UdogodnieniaLista]
ADD CONSTRAINT [PK_UdogodnieniaLista]
    PRIMARY KEY CLUSTERED ([UdogodnieniaId], [ApartamentyId] ASC);
GO

-- Creating primary key on [Id] in table 'Adresy'
ALTER TABLE [dbo].[Adresy]
ADD CONSTRAINT [PK_Adresy]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ApartamentyId] in table 'Rezerwacja'
ALTER TABLE [dbo].[Rezerwacja]
ADD CONSTRAINT [FK_ApartamentyRezerwacja]
    FOREIGN KEY ([ApartamentyId])
    REFERENCES [dbo].[Apartamenty]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ApartamentyRezerwacja'
CREATE INDEX [IX_FK_ApartamentyRezerwacja]
ON [dbo].[Rezerwacja]
    ([ApartamentyId]);
GO

-- Creating foreign key on [BudynkiId] in table 'Apartamenty'
ALTER TABLE [dbo].[Apartamenty]
ADD CONSTRAINT [FK_BudynkiApartamenty]
    FOREIGN KEY ([BudynkiId])
    REFERENCES [dbo].[Budynki]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BudynkiApartamenty'
CREATE INDEX [IX_FK_BudynkiApartamenty]
ON [dbo].[Apartamenty]
    ([BudynkiId]);
GO

-- Creating foreign key on [TypId] in table 'Apartamenty'
ALTER TABLE [dbo].[Apartamenty]
ADD CONSTRAINT [FK_TypApartamenty]
    FOREIGN KEY ([TypId])
    REFERENCES [dbo].[Typ]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TypApartamenty'
CREATE INDEX [IX_FK_TypApartamenty]
ON [dbo].[Apartamenty]
    ([TypId]);
GO

-- Creating foreign key on [UdogodnieniaId] in table 'UdogodnieniaLista'
ALTER TABLE [dbo].[UdogodnieniaLista]
ADD CONSTRAINT [FK_UdogodnieniaUdogodnieniaLista]
    FOREIGN KEY ([UdogodnieniaId])
    REFERENCES [dbo].[Udogodnienia]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [OsobyId] in table 'Rezerwacja'
ALTER TABLE [dbo].[Rezerwacja]
ADD CONSTRAINT [FK_RezerwacjaOsoby]
    FOREIGN KEY ([OsobyId])
    REFERENCES [dbo].[Osoby]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RezerwacjaOsoby'
CREATE INDEX [IX_FK_RezerwacjaOsoby]
ON [dbo].[Rezerwacja]
    ([OsobyId]);
GO

-- Creating foreign key on [OsobyId] in table 'StatusZameldowania'
ALTER TABLE [dbo].[StatusZameldowania]
ADD CONSTRAINT [FK_StatusZameldowaniaOsoby]
    FOREIGN KEY ([OsobyId])
    REFERENCES [dbo].[Osoby]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StatusZameldowaniaOsoby'
CREATE INDEX [IX_FK_StatusZameldowaniaOsoby]
ON [dbo].[StatusZameldowania]
    ([OsobyId]);
GO

-- Creating foreign key on [ApartamentyId] in table 'UdogodnieniaLista'
ALTER TABLE [dbo].[UdogodnieniaLista]
ADD CONSTRAINT [FK_ApartamentyUdogodnieniaLista]
    FOREIGN KEY ([ApartamentyId])
    REFERENCES [dbo].[Apartamenty]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ApartamentyUdogodnieniaLista'
CREATE INDEX [IX_FK_ApartamentyUdogodnieniaLista]
ON [dbo].[UdogodnieniaLista]
    ([ApartamentyId]);
GO

-- Creating foreign key on [StatusZameldowaniaId] in table 'Rezerwacja'
ALTER TABLE [dbo].[Rezerwacja]
ADD CONSTRAINT [FK_StatusZameldowaniaRezerwacja]
    FOREIGN KEY ([StatusZameldowaniaId])
    REFERENCES [dbo].[StatusZameldowania]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StatusZameldowaniaRezerwacja'
CREATE INDEX [IX_FK_StatusZameldowaniaRezerwacja]
ON [dbo].[Rezerwacja]
    ([StatusZameldowaniaId]);
GO

-- Creating foreign key on [Adresy_Id] in table 'Budynki'
ALTER TABLE [dbo].[Budynki]
ADD CONSTRAINT [FK_BudynkiAdresy]
    FOREIGN KEY ([Adresy_Id])
    REFERENCES [dbo].[Adresy]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BudynkiAdresy'
CREATE INDEX [IX_FK_BudynkiAdresy]
ON [dbo].[Budynki]
    ([Adresy_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------