
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/27/2022 14:58:02
-- Generated from EDMX file: D:\projects\ANA\QAS\code\TestProject\DataModel\WebApiDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TestProjectWebAPI];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products];
GO
IF OBJECT_ID(N'[dbo].[Tokens]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tokens];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [ProductId] int IDENTITY(1,1) NOT NULL,
    [ProductName] varchar(250)  NOT NULL
);
GO

-- Creating table 'Tokens'
CREATE TABLE [dbo].[Tokens] (
    [TokenId] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [AuthToken] nvarchar(250)  NOT NULL,
    [IssuedOn] datetime  NOT NULL,
    [ExpiresOn] datetime  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(50)  NOT NULL,
    [Password] nvarchar(50)  NOT NULL,
    [Name] nvarchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ProductId] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([ProductId] ASC);
GO

-- Creating primary key on [TokenId], [AuthToken] in table 'Tokens'
ALTER TABLE [dbo].[Tokens]
ADD CONSTRAINT [PK_Tokens]
    PRIMARY KEY CLUSTERED ([TokenId], [AuthToken] ASC);
GO

-- Creating primary key on [UserId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------


INSERT INTO [dbo].[Products] (ProductName)
VALUES
('Arroz pilado'),
('Azúcar'),
('Productos cárnicos'),
('Harina y aceite de pescado'),
('Conservas y productos congelados de pescado'),
('Refinación de mateles no ferrosos'),
('Refinación de petróleo'),
('Conservas de alimentos'),
('Productos lácteos'),
('Molinería'),
('Panadería'),
('Fideos'),
('Aceites y grasas'),
('Cacao, chocolate y productos de confitería'),
('Alimentos para animales'),
('Productos alimenticios diversos'),
('Bebidas alcohólicas'),
('Cerveza y malta'),
('Bebidas gaseosas y agua de mesa'),
('Textil, cuero y calzado'),
('Hilados, tejidos y acabados'),
('Tejidos y artículos de punto'),
('Cuerdas, cordeles, bramantes y redes'),
('Cuero'),
('Prendas de vestir'),
('Otros productos textiles'),
('Calzado'),
('Madera'),
('Muebles'),
('Papel y cartón'),
('Envases de papel y cartón'),
('Otros artículos de papel y cartón'),
('Actividades de impresión'),
('Sustancias químicas básicas'),
('Fibras artificiales'),
('Productos farmacéuticos y medicamentos'),
('Pinturas, barnices y lacas'),
('Productos de tocador y limpieza'),
('Explosivos, esencias naturales y químicas'),
('Caucho'),
('Plásticos'),
('Plaguicidas, abonos compuestos y plásticos primarios'),
('Vidrio y productos de vidrio'),
('Cemento'),
('Materiales para la construcción'),
('Productos minerales no metálicos diversos'),
('Productos metálicos'),
('Maquinaria y equipo'),
('Maquinaria eléctrica'),
('Material de transporte');
GO