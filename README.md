# ChequeBookRegistry
Application to test MVC coding principles

This is a sample application I created in order to solve my problem of binding multiple dropdown lists to a database and including them in the same page. 

The required SQL tables can be created witht he below:

Database Name: Chequebook
Tables:

Cheques
-------

USE [Chequebook]
GO

/****** Object: Table [dbo].[Cheques] Script Date: 17/08/2022 21:32:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cheques] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Payee]           INT			 NOT NULL,
    [Amount]          FLOAT (53)     NOT NULL,
    [DateDue]         DATE			 NOT NULL,
    [Justification]   NVARCHAR (MAX) NOT NULL,
    [RelatedCustomer] INT			 NOT NULL
);


Customers
---------
USE [Chequebook]
GO

/****** Object: Table [dbo].[Customers] Script Date: 17/08/2022 21:38:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customers] (
    [ID]            INT            IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (50) NOT NULL,
    [ContactPerson] NVARCHAR (50),
    [Telephone]     NVARCHAR (20),
    [Mobile]        NVARCHAR (20),
    [TotalAmount]   FLOAT (53)
);


Payees
------
USE [Chequebook]
GO

/****** Object: Table [dbo].[Customers] Script Date: 17/08/2022 21:38:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Payees] (
    [ID]            INT            IDENTITY (1, 1) NOT NULL,
    [PayeeName]     NVARCHAR (50) NOT NULL,
    [ContactPerson] NVARCHAR (50),
    [Telephone]     NVARCHAR (20),
    [Mobile]        NVARCHAR (20),
    [TotalAmount]   FLOAT (53)
);
