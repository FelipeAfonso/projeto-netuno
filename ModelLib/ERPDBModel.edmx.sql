
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/28/2016 02:04:06
-- Generated from EDMX file: C:\Users\Felipe\Desktop\Projetos\Netuno\Projeto\NTN\ModelLib\ERPDBModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [LocalERPDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ProdutoCategoria]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProdutoSet] DROP CONSTRAINT [FK_ProdutoCategoria];
GO
IF OBJECT_ID(N'[dbo].[FK_EstoqueProduto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProdutoSet] DROP CONSTRAINT [FK_EstoqueProduto];
GO
IF OBJECT_ID(N'[dbo].[FK_FornecedorProduto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProdutoSet] DROP CONSTRAINT [FK_FornecedorProduto];
GO
IF OBJECT_ID(N'[dbo].[FK_LojaFornecedor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FornecedorSet] DROP CONSTRAINT [FK_LojaFornecedor];
GO
IF OBJECT_ID(N'[dbo].[FK_LojaCaixa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CaixaSet] DROP CONSTRAINT [FK_LojaCaixa];
GO
IF OBJECT_ID(N'[dbo].[FK_LojaEstoque]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LojaSet] DROP CONSTRAINT [FK_LojaEstoque];
GO
IF OBJECT_ID(N'[dbo].[FK_LojaVenda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VendaSet] DROP CONSTRAINT [FK_LojaVenda];
GO
IF OBJECT_ID(N'[dbo].[FK_VendaProduto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProdutoSet] DROP CONSTRAINT [FK_VendaProduto];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteVenda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VendaSet] DROP CONSTRAINT [FK_ClienteVenda];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioEndereco]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EnderecoSet] DROP CONSTRAINT [FK_UsuarioEndereco];
GO
IF OBJECT_ID(N'[dbo].[FK_EnderecoLoja]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LojaSet] DROP CONSTRAINT [FK_EnderecoLoja];
GO
IF OBJECT_ID(N'[dbo].[FK_FuncionarioPermissao_Funcionario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FuncionarioPermissao] DROP CONSTRAINT [FK_FuncionarioPermissao_Funcionario];
GO
IF OBJECT_ID(N'[dbo].[FK_FuncionarioPermissao_Permissao]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FuncionarioPermissao] DROP CONSTRAINT [FK_FuncionarioPermissao_Permissao];
GO
IF OBJECT_ID(N'[dbo].[FK_FuncionarioVenda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VendaSet] DROP CONSTRAINT [FK_FuncionarioVenda];
GO
IF OBJECT_ID(N'[dbo].[FK_FuncionarioLoja]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsuarioSet_Funcionario] DROP CONSTRAINT [FK_FuncionarioLoja];
GO
IF OBJECT_ID(N'[dbo].[FK_Cliente_inherits_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsuarioSet_Cliente] DROP CONSTRAINT [FK_Cliente_inherits_Usuario];
GO
IF OBJECT_ID(N'[dbo].[FK_Funcionario_inherits_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsuarioSet_Funcionario] DROP CONSTRAINT [FK_Funcionario_inherits_Usuario];
GO
IF OBJECT_ID(N'[dbo].[FK_SubCategoria_inherits_Categoria]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CategoriaSet_SubCategoria] DROP CONSTRAINT [FK_SubCategoria_inherits_Categoria];
GO
IF OBJECT_ID(N'[dbo].[FK_Orcamento_inherits_Venda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VendaSet_Orcamento] DROP CONSTRAINT [FK_Orcamento_inherits_Venda];
GO
IF OBJECT_ID(N'[dbo].[FK_Administrador_inherits_Funcionario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsuarioSet_Administrador] DROP CONSTRAINT [FK_Administrador_inherits_Funcionario];
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
IF OBJECT_ID(N'[dbo].[EstoqueSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EstoqueSet];
GO
IF OBJECT_ID(N'[dbo].[FornecedorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FornecedorSet];
GO
IF OBJECT_ID(N'[dbo].[LojaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LojaSet];
GO
IF OBJECT_ID(N'[dbo].[VendaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VendaSet];
GO
IF OBJECT_ID(N'[dbo].[CaixaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CaixaSet];
GO
IF OBJECT_ID(N'[dbo].[PermissaoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PermissaoSet];
GO
IF OBJECT_ID(N'[dbo].[UsuarioSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsuarioSet];
GO
IF OBJECT_ID(N'[dbo].[EnderecoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EnderecoSet];
GO
IF OBJECT_ID(N'[dbo].[UsuarioSet_Cliente]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsuarioSet_Cliente];
GO
IF OBJECT_ID(N'[dbo].[UsuarioSet_Funcionario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsuarioSet_Funcionario];
GO
IF OBJECT_ID(N'[dbo].[CategoriaSet_SubCategoria]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategoriaSet_SubCategoria];
GO
IF OBJECT_ID(N'[dbo].[VendaSet_Orcamento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VendaSet_Orcamento];
GO
IF OBJECT_ID(N'[dbo].[UsuarioSet_Administrador]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsuarioSet_Administrador];
GO
IF OBJECT_ID(N'[dbo].[FuncionarioPermissao]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FuncionarioPermissao];
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
    [Imagem] tinyint  NULL,
    [Codigo] int  NOT NULL,
    [Categoria_Id] int  NULL,
    [Estoque_Id] int  NULL,
    [Fornecedor_Id] int  NULL,
    [Venda_Id] int  NULL
);
GO

-- Creating table 'CategoriaSet'
CREATE TABLE [dbo].[CategoriaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EstoqueSet'
CREATE TABLE [dbo].[EstoqueSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Custo] float  NOT NULL,
    [Valor] float  NOT NULL
);
GO

-- Creating table 'FornecedorSet'
CREATE TABLE [dbo].[FornecedorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Loja_Id] int  NULL
);
GO

-- Creating table 'LojaSet'
CREATE TABLE [dbo].[LojaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Estoque_Id] int  NOT NULL,
    [Endereco_Id] int  NULL
);
GO

-- Creating table 'VendaSet'
CREATE TABLE [dbo].[VendaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Data] datetime  NOT NULL,
    [Total] float  NOT NULL,
    [Loja_Id] int  NOT NULL,
    [Cliente_Id] int  NOT NULL,
    [Funcionario_Id] int  NOT NULL
);
GO

-- Creating table 'CaixaSet'
CREATE TABLE [dbo].[CaixaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Valor] float  NOT NULL,
    [Loja_Id] int  NOT NULL
);
GO

-- Creating table 'PermissaoSet'
CREATE TABLE [dbo].[PermissaoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Descricao] nvarchar(max)  NULL
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
    [Sexo] nvarchar(max)  NULL
);
GO

-- Creating table 'EnderecoSet'
CREATE TABLE [dbo].[EnderecoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Numero] int  NOT NULL,
    [Bairro] nvarchar(max)  NOT NULL,
    [Cidade] nvarchar(max)  NOT NULL,
    [Estado] nvarchar(max)  NOT NULL,
    [Logradouro] nvarchar(max)  NOT NULL,
    [Usuario_Id] int  NULL
);
GO

-- Creating table 'UsuarioSet_Cliente'
CREATE TABLE [dbo].[UsuarioSet_Cliente] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'UsuarioSet_Funcionario'
CREATE TABLE [dbo].[UsuarioSet_Funcionario] (
    [Foto] nvarchar(max)  NULL,
    [Id] int  NOT NULL,
    [Loja_Id] int  NULL
);
GO

-- Creating table 'CategoriaSet_SubCategoria'
CREATE TABLE [dbo].[CategoriaSet_SubCategoria] (
    [SubId] int  NOT NULL,
    [SubNome] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'VendaSet_Orcamento'
CREATE TABLE [dbo].[VendaSet_Orcamento] (
    [Expiracao] datetime  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'UsuarioSet_Administrador'
CREATE TABLE [dbo].[UsuarioSet_Administrador] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'FuncionarioPermissao'
CREATE TABLE [dbo].[FuncionarioPermissao] (
    [Funcionario_Id] int  NOT NULL,
    [Permissao_Id] int  NOT NULL
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

-- Creating primary key on [Id] in table 'EstoqueSet'
ALTER TABLE [dbo].[EstoqueSet]
ADD CONSTRAINT [PK_EstoqueSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FornecedorSet'
ALTER TABLE [dbo].[FornecedorSet]
ADD CONSTRAINT [PK_FornecedorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LojaSet'
ALTER TABLE [dbo].[LojaSet]
ADD CONSTRAINT [PK_LojaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'VendaSet'
ALTER TABLE [dbo].[VendaSet]
ADD CONSTRAINT [PK_VendaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CaixaSet'
ALTER TABLE [dbo].[CaixaSet]
ADD CONSTRAINT [PK_CaixaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PermissaoSet'
ALTER TABLE [dbo].[PermissaoSet]
ADD CONSTRAINT [PK_PermissaoSet]
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

-- Creating primary key on [Id] in table 'UsuarioSet_Cliente'
ALTER TABLE [dbo].[UsuarioSet_Cliente]
ADD CONSTRAINT [PK_UsuarioSet_Cliente]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsuarioSet_Funcionario'
ALTER TABLE [dbo].[UsuarioSet_Funcionario]
ADD CONSTRAINT [PK_UsuarioSet_Funcionario]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CategoriaSet_SubCategoria'
ALTER TABLE [dbo].[CategoriaSet_SubCategoria]
ADD CONSTRAINT [PK_CategoriaSet_SubCategoria]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'VendaSet_Orcamento'
ALTER TABLE [dbo].[VendaSet_Orcamento]
ADD CONSTRAINT [PK_VendaSet_Orcamento]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsuarioSet_Administrador'
ALTER TABLE [dbo].[UsuarioSet_Administrador]
ADD CONSTRAINT [PK_UsuarioSet_Administrador]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Funcionario_Id], [Permissao_Id] in table 'FuncionarioPermissao'
ALTER TABLE [dbo].[FuncionarioPermissao]
ADD CONSTRAINT [PK_FuncionarioPermissao]
    PRIMARY KEY CLUSTERED ([Funcionario_Id], [Permissao_Id] ASC);
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

-- Creating foreign key on [Estoque_Id] in table 'ProdutoSet'
ALTER TABLE [dbo].[ProdutoSet]
ADD CONSTRAINT [FK_EstoqueProduto]
    FOREIGN KEY ([Estoque_Id])
    REFERENCES [dbo].[EstoqueSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EstoqueProduto'
CREATE INDEX [IX_FK_EstoqueProduto]
ON [dbo].[ProdutoSet]
    ([Estoque_Id]);
GO

-- Creating foreign key on [Fornecedor_Id] in table 'ProdutoSet'
ALTER TABLE [dbo].[ProdutoSet]
ADD CONSTRAINT [FK_FornecedorProduto]
    FOREIGN KEY ([Fornecedor_Id])
    REFERENCES [dbo].[FornecedorSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FornecedorProduto'
CREATE INDEX [IX_FK_FornecedorProduto]
ON [dbo].[ProdutoSet]
    ([Fornecedor_Id]);
GO

-- Creating foreign key on [Loja_Id] in table 'FornecedorSet'
ALTER TABLE [dbo].[FornecedorSet]
ADD CONSTRAINT [FK_LojaFornecedor]
    FOREIGN KEY ([Loja_Id])
    REFERENCES [dbo].[LojaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LojaFornecedor'
CREATE INDEX [IX_FK_LojaFornecedor]
ON [dbo].[FornecedorSet]
    ([Loja_Id]);
GO

-- Creating foreign key on [Loja_Id] in table 'CaixaSet'
ALTER TABLE [dbo].[CaixaSet]
ADD CONSTRAINT [FK_LojaCaixa]
    FOREIGN KEY ([Loja_Id])
    REFERENCES [dbo].[LojaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LojaCaixa'
CREATE INDEX [IX_FK_LojaCaixa]
ON [dbo].[CaixaSet]
    ([Loja_Id]);
GO

-- Creating foreign key on [Estoque_Id] in table 'LojaSet'
ALTER TABLE [dbo].[LojaSet]
ADD CONSTRAINT [FK_LojaEstoque]
    FOREIGN KEY ([Estoque_Id])
    REFERENCES [dbo].[EstoqueSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LojaEstoque'
CREATE INDEX [IX_FK_LojaEstoque]
ON [dbo].[LojaSet]
    ([Estoque_Id]);
GO

-- Creating foreign key on [Loja_Id] in table 'VendaSet'
ALTER TABLE [dbo].[VendaSet]
ADD CONSTRAINT [FK_LojaVenda]
    FOREIGN KEY ([Loja_Id])
    REFERENCES [dbo].[LojaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LojaVenda'
CREATE INDEX [IX_FK_LojaVenda]
ON [dbo].[VendaSet]
    ([Loja_Id]);
GO

-- Creating foreign key on [Venda_Id] in table 'ProdutoSet'
ALTER TABLE [dbo].[ProdutoSet]
ADD CONSTRAINT [FK_VendaProduto]
    FOREIGN KEY ([Venda_Id])
    REFERENCES [dbo].[VendaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VendaProduto'
CREATE INDEX [IX_FK_VendaProduto]
ON [dbo].[ProdutoSet]
    ([Venda_Id]);
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

-- Creating foreign key on [Endereco_Id] in table 'LojaSet'
ALTER TABLE [dbo].[LojaSet]
ADD CONSTRAINT [FK_EnderecoLoja]
    FOREIGN KEY ([Endereco_Id])
    REFERENCES [dbo].[EnderecoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EnderecoLoja'
CREATE INDEX [IX_FK_EnderecoLoja]
ON [dbo].[LojaSet]
    ([Endereco_Id]);
GO

-- Creating foreign key on [Funcionario_Id] in table 'FuncionarioPermissao'
ALTER TABLE [dbo].[FuncionarioPermissao]
ADD CONSTRAINT [FK_FuncionarioPermissao_Funcionario]
    FOREIGN KEY ([Funcionario_Id])
    REFERENCES [dbo].[UsuarioSet_Funcionario]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Permissao_Id] in table 'FuncionarioPermissao'
ALTER TABLE [dbo].[FuncionarioPermissao]
ADD CONSTRAINT [FK_FuncionarioPermissao_Permissao]
    FOREIGN KEY ([Permissao_Id])
    REFERENCES [dbo].[PermissaoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FuncionarioPermissao_Permissao'
CREATE INDEX [IX_FK_FuncionarioPermissao_Permissao]
ON [dbo].[FuncionarioPermissao]
    ([Permissao_Id]);
GO

-- Creating foreign key on [Funcionario_Id] in table 'VendaSet'
ALTER TABLE [dbo].[VendaSet]
ADD CONSTRAINT [FK_FuncionarioVenda]
    FOREIGN KEY ([Funcionario_Id])
    REFERENCES [dbo].[UsuarioSet_Funcionario]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FuncionarioVenda'
CREATE INDEX [IX_FK_FuncionarioVenda]
ON [dbo].[VendaSet]
    ([Funcionario_Id]);
GO

-- Creating foreign key on [Loja_Id] in table 'UsuarioSet_Funcionario'
ALTER TABLE [dbo].[UsuarioSet_Funcionario]
ADD CONSTRAINT [FK_FuncionarioLoja]
    FOREIGN KEY ([Loja_Id])
    REFERENCES [dbo].[LojaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FuncionarioLoja'
CREATE INDEX [IX_FK_FuncionarioLoja]
ON [dbo].[UsuarioSet_Funcionario]
    ([Loja_Id]);
GO

-- Creating foreign key on [Id] in table 'UsuarioSet_Cliente'
ALTER TABLE [dbo].[UsuarioSet_Cliente]
ADD CONSTRAINT [FK_Cliente_inherits_Usuario]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[UsuarioSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'UsuarioSet_Funcionario'
ALTER TABLE [dbo].[UsuarioSet_Funcionario]
ADD CONSTRAINT [FK_Funcionario_inherits_Usuario]
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

-- Creating foreign key on [Id] in table 'VendaSet_Orcamento'
ALTER TABLE [dbo].[VendaSet_Orcamento]
ADD CONSTRAINT [FK_Orcamento_inherits_Venda]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[VendaSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'UsuarioSet_Administrador'
ALTER TABLE [dbo].[UsuarioSet_Administrador]
ADD CONSTRAINT [FK_Administrador_inherits_Funcionario]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[UsuarioSet_Funcionario]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------