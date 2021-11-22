
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/20/2021 21:26:59
-- Generated from EDMX file: S:\OneDrive\UOC\DAM\ICB0_P6_Técnicas_de_persistencia_de_datos_con_.NET\code\NETime_WF_EF6\netime.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [netime2];
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

-- Creating table 'userSet'
CREATE TABLE [dbo].[userSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [surname] nvarchar(max)  NOT NULL,
    [email] nvarchar(max)  NOT NULL,
    [phone] nvarchar(max)  NOT NULL,
    [address] nvarchar(max)  NOT NULL,
    [password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'categoriesSet'
CREATE TABLE [dbo].[categoriesSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [family] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'selected_activitiesSet'
CREATE TABLE [dbo].[selected_activitiesSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [userId] int  NOT NULL,
    [activitiesId] int  NOT NULL
);
GO

-- Creating table 'balanceSet'
CREATE TABLE [dbo].[balanceSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [userId] int  NOT NULL,
    [activity_name] nvarchar(max)  NOT NULL,
    [user_name] nvarchar(max)  NOT NULL,
    [datetime] datetime  NOT NULL,
    [qtty] int  NOT NULL,
    [sing] bit  NOT NULL
);
GO

-- Creating table 'activitiesSet'
CREATE TABLE [dbo].[activitiesSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [userId] int  NOT NULL,
    [categoriesId] int  NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [description] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'userSet'
ALTER TABLE [dbo].[userSet]
ADD CONSTRAINT [PK_userSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'categoriesSet'
ALTER TABLE [dbo].[categoriesSet]
ADD CONSTRAINT [PK_categoriesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'selected_activitiesSet'
ALTER TABLE [dbo].[selected_activitiesSet]
ADD CONSTRAINT [PK_selected_activitiesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'balanceSet'
ALTER TABLE [dbo].[balanceSet]
ADD CONSTRAINT [PK_balanceSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'activitiesSet'
ALTER TABLE [dbo].[activitiesSet]
ADD CONSTRAINT [PK_activitiesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [userId] in table 'selected_activitiesSet'
ALTER TABLE [dbo].[selected_activitiesSet]
ADD CONSTRAINT [FK_userselected_activities]
    FOREIGN KEY ([userId])
    REFERENCES [dbo].[userSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_userselected_activities'
CREATE INDEX [IX_FK_userselected_activities]
ON [dbo].[selected_activitiesSet]
    ([userId]);
GO

-- Creating foreign key on [userId] in table 'balanceSet'
ALTER TABLE [dbo].[balanceSet]
ADD CONSTRAINT [FK_balanceuser]
    FOREIGN KEY ([userId])
    REFERENCES [dbo].[userSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_balanceuser'
CREATE INDEX [IX_FK_balanceuser]
ON [dbo].[balanceSet]
    ([userId]);
GO

-- Creating foreign key on [userId] in table 'activitiesSet'
ALTER TABLE [dbo].[activitiesSet]
ADD CONSTRAINT [FK_useractivities]
    FOREIGN KEY ([userId])
    REFERENCES [dbo].[userSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_useractivities'
CREATE INDEX [IX_FK_useractivities]
ON [dbo].[activitiesSet]
    ([userId]);
GO

-- Creating foreign key on [categoriesId] in table 'activitiesSet'
ALTER TABLE [dbo].[activitiesSet]
ADD CONSTRAINT [FK_categoriesactivities]
    FOREIGN KEY ([categoriesId])
    REFERENCES [dbo].[categoriesSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_categoriesactivities'
CREATE INDEX [IX_FK_categoriesactivities]
ON [dbo].[activitiesSet]
    ([categoriesId]);
GO

-- Creating foreign key on [activitiesId] in table 'selected_activitiesSet'
ALTER TABLE [dbo].[selected_activitiesSet]
ADD CONSTRAINT [FK_activitiesselected_activities]
    FOREIGN KEY ([activitiesId])
    REFERENCES [dbo].[activitiesSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_activitiesselected_activities'
CREATE INDEX [IX_FK_activitiesselected_activities]
ON [dbo].[selected_activitiesSet]
    ([activitiesId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------