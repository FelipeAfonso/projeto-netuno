
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/11/2016 15:06:36
-- Generated from EDMX file: F:\Projetos\Netuno\Projeto\NTN\Site\Models\ERPDBModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [HospedadoERPDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ProdutoCategoria]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProdutoSet] DROP CONSTRAINT [FK_ProdutoCategoria];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteVenda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VendaSet] DROP CONSTRAINT [FK_ClienteVenda];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioEndereco]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EnderecoSet] DROP CONSTRAINT [FK_UsuarioEndereco];
GO
IF OBJECT_ID(N'[dbo].[FK_VendaProdutoVendaItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProdutoVendaItemSet] DROP CONSTRAINT [FK_VendaProdutoVendaItem];
GO
IF OBJECT_ID(N'[dbo].[FK_ProdutoProdutoVendaItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProdutoVendaItemSet] DROP CONSTRAINT [FK_ProdutoProdutoVendaItem];
GO
IF OBJECT_ID(N'[dbo].[FK_Cliente_inherits_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsuarioSet_Cliente] DROP CONSTRAINT [FK_Cliente_inherits_Usuario];
GO
IF OBJECT_ID(N'[dbo].[FK_SubCategoria_inherits_Categoria]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CategoriaSet_SubCategoria] DROP CONSTRAINT [FK_SubCategoria_inherits_Categoria];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ProdutoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProdutoSet];
GO
IF OBJECT_ID(N'[dbo].[CategoriaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategoriaSet];
GO
IF OBJECT_ID(N'[dbo].[VendaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VendaSet];
GO
IF OBJECT_ID(N'[dbo].[UsuarioSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsuarioSet];
GO
IF OBJECT_ID(N'[dbo].[EnderecoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EnderecoSet];
GO
IF OBJECT_ID(N'[dbo].[ProdutoVendaItemSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProdutoVendaItemSet];
GO
IF OBJECT_ID(N'[dbo].[UsuarioSet_Cliente]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsuarioSet_Cliente];
GO
IF OBJECT_ID(N'[dbo].[CategoriaSet_SubCategoria]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategoriaSet_SubCategoria];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ProdutoSet'
CREATE TABLE [dbo].[ProdutoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [PrecoCusto] float  NOT NULL,
    [PrecoVista] float  NOT NULL,
    [PrecoPrazo] float  NULL,
    [Quantidade] float  NULL,
    [DisponivelLojaVirtual] bit  NULL,
    [Descricao] nvarchar(max)  NULL,
    [UnidadeMedida] nvarchar(max)  NULL,
    [Imagem] nvarchar(max)  NULL,
    [Codigo] int  NOT NULL,
    [Categoria_Id] int  NULL
);
GO

-- Creating table 'CategoriaSet'
CREATE TABLE [dbo].[CategoriaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'VendaSet'
CREATE TABLE [dbo].[VendaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Data] datetime  NOT NULL,
    [Total] float  NOT NULL,
    [Cliente_Id] int  NULL
);
GO

-- Creating table 'UsuarioSet'
CREATE TABLE [dbo].[UsuarioSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cpf] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NULL,
    [Nascimento] datetime  NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Rg] nvarchar(max)  NULL,
    [Senha] nvarchar(max)  NULL,
    [Sexo] nvarchar(max)  NULL,
    [Telefone] nvarchar(max)  NULL,
    [Celular] nvarchar(max)  NULL
);
GO

-- Creating table 'EnderecoSet'
CREATE TABLE [dbo].[EnderecoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Numero] int  NULL,
    [Bairro] nvarchar(max)  NULL,
    [Cidade] nvarchar(max)  NULL,
    [Estado] nvarchar(max)  NULL,
    [Logradouro] nvarchar(max)  NULL,
    [CEP] nvarchar(max)  NULL,
    [Usuario_Id] int  NULL
);
GO

-- Creating table 'ProdutoVendaItemSet'
CREATE TABLE [dbo].[ProdutoVendaItemSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Quantidade] int  NOT NULL,
    [Venda_Id] int  NOT NULL,
    [Produto_Id] int  NULL
);
GO

-- Creating table 'UsuarioSet_Cliente'
CREATE TABLE [dbo].[UsuarioSet_Cliente] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'CategoriaSet_SubCategoria'
CREATE TABLE [dbo].[CategoriaSet_SubCategoria] (
    [SubId] int  NOT NULL,
    [SubNome] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ProdutoSet'
ALTER TABLE [dbo].[ProdutoSet]
ADD CONSTRAINT [PK_ProdutoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CategoriaSet'
ALTER TABLE [dbo].[CategoriaSet]
ADD CONSTRAINT [PK_CategoriaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'VendaSet'
ALTER TABLE [dbo].[VendaSet]
ADD CONSTRAINT [PK_VendaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsuarioSet'
ALTER TABLE [dbo].[UsuarioSet]
ADD CONSTRAINT [PK_UsuarioSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EnderecoSet'
ALTER TABLE [dbo].[EnderecoSet]
ADD CONSTRAINT [PK_EnderecoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProdutoVendaItemSet'
ALTER TABLE [dbo].[ProdutoVendaItemSet]
ADD CONSTRAINT [PK_ProdutoVendaItemSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsuarioSet_Cliente'
ALTER TABLE [dbo].[UsuarioSet_Cliente]
ADD CONSTRAINT [PK_UsuarioSet_Cliente]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CategoriaSet_SubCategoria'
ALTER TABLE [dbo].[CategoriaSet_SubCategoria]
ADD CONSTRAINT [PK_CategoriaSet_SubCategoria]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Categoria_Id] in table 'ProdutoSet'
ALTER TABLE [dbo].[ProdutoSet]
ADD CONSTRAINT [FK_ProdutoCategoria]
    FOREIGN KEY ([Categoria_Id])
    REFERENCES [dbo].[CategoriaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProdutoCategoria'
CREATE INDEX [IX_FK_ProdutoCategoria]
ON [dbo].[ProdutoSet]
    ([Categoria_Id]);
GO

-- Creating foreign key on [Cliente_Id] in table 'VendaSet'
ALTER TABLE [dbo].[VendaSet]
ADD CONSTRAINT [FK_ClienteVenda]
    FOREIGN KEY ([Cliente_Id])
    REFERENCES [dbo].[UsuarioSet_Cliente]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteVenda'
CREATE INDEX [IX_FK_ClienteVenda]
ON [dbo].[VendaSet]
    ([Cliente_Id]);
GO

-- Creating foreign key on [Usuario_Id] in table 'EnderecoSet'
ALTER TABLE [dbo].[EnderecoSet]
ADD CONSTRAINT [FK_UsuarioEndereco]
    FOREIGN KEY ([Usuario_Id])
    REFERENCES [dbo].[UsuarioSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioEndereco'
CREATE INDEX [IX_FK_UsuarioEndereco]
ON [dbo].[EnderecoSet]
    ([Usuario_Id]);
GO

-- Creating foreign key on [Venda_Id] in table 'ProdutoVendaItemSet'
ALTER TABLE [dbo].[ProdutoVendaItemSet]
ADD CONSTRAINT [FK_VendaProdutoVendaItem]
    FOREIGN KEY ([Venda_Id])
    REFERENCES [dbo].[VendaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VendaProdutoVendaItem'
CREATE INDEX [IX_FK_VendaProdutoVendaItem]
ON [dbo].[ProdutoVendaItemSet]
    ([Venda_Id]);
GO

-- Creating foreign key on [Produto_Id] in table 'ProdutoVendaItemSet'
ALTER TABLE [dbo].[ProdutoVendaItemSet]
ADD CONSTRAINT [FK_ProdutoProdutoVendaItem]
    FOREIGN KEY ([Produto_Id])
    REFERENCES [dbo].[ProdutoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProdutoProdutoVendaItem'
CREATE INDEX [IX_FK_ProdutoProdutoVendaItem]
ON [dbo].[ProdutoVendaItemSet]
    ([Produto_Id]);
GO

-- Creating foreign key on [Id] in table 'UsuarioSet_Cliente'
ALTER TABLE [dbo].[UsuarioSet_Cliente]
ADD CONSTRAINT [FK_Cliente_inherits_Usuario]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[UsuarioSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'CategoriaSet_SubCategoria'
ALTER TABLE [dbo].[CategoriaSet_SubCategoria]
ADD CONSTRAINT [FK_SubCategoria_inherits_Categoria]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[CategoriaSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------