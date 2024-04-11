
CREATE DATABASE Aniversariantes

USE Aniversariantes
GO


CREATE TABLE [dbo].[Aniversariante] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Nome]          NVARCHAR (60)  NOT NULL,
    [DataNacimento] DATETIME       NOT NULL,
    [Descricao]     NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


SELECT * FROM [dbo].[Aniversariante]