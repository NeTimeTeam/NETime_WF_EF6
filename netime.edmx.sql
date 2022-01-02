
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/02/2022 19:19:30
-- Generated from EDMX file: C:\Users\monic\source\repos\NETime_WF_EF6\netime.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [netime];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_userselected_activities]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[selected_activitiesSet] DROP CONSTRAINT [FK_userselected_activities];
GO
IF OBJECT_ID(N'[dbo].[FK_categoriesactivities]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[activitiesSet] DROP CONSTRAINT [FK_categoriesactivities];
GO
IF OBJECT_ID(N'[dbo].[FK_useractivities]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[activitiesSet] DROP CONSTRAINT [FK_useractivities];
GO
IF OBJECT_ID(N'[dbo].[FK_activitiesselected_activities]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[selected_activitiesSet] DROP CONSTRAINT [FK_activitiesselected_activities];
GO
IF OBJECT_ID(N'[dbo].[FK_userbalance]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[balanceSet] DROP CONSTRAINT [FK_userbalance];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[userSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[userSet];
GO
IF OBJECT_ID(N'[dbo].[categoriesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[categoriesSet];
GO
IF OBJECT_ID(N'[dbo].[selected_activitiesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[selected_activitiesSet];
GO
IF OBJECT_ID(N'[dbo].[balanceSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[balanceSet];
GO
IF OBJECT_ID(N'[dbo].[activitiesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[activitiesSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'userSet'
CREATE TABLE [dbo].[userSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [surname] nvarchar(max)  NOT NULL,
    [email] nvarchar(450)  NOT NULL,
    [phone] nvarchar(max)  NOT NULL,
    [address] nvarchar(max)  NOT NULL,
    [password] varbinary(max)  NOT NULL,
    [salt] varbinary(max)  NOT NULL
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
    [datetime] datetime  NOT NULL,
    [qtty] int  NOT NULL,
    [userId] int  NOT NULL,
    [activityName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'activitiesSet'
CREATE TABLE [dbo].[activitiesSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [description] nvarchar(max)  NOT NULL,
    [categoriesId] int  NOT NULL,
    [userId] int  NOT NULL
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

-- Creating foreign key on [userId] in table 'balanceSet'
ALTER TABLE [dbo].[balanceSet]
ADD CONSTRAINT [FK_userbalance]
    FOREIGN KEY ([userId])
    REFERENCES [dbo].[userSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_userbalance'
CREATE INDEX [IX_FK_userbalance]
ON [dbo].[balanceSet]
    ([userId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------