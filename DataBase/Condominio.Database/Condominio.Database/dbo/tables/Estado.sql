USE [condominio]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE dbo.Estado(
[Identificador][uniqueidentifier] NOT NULL DEFAULT (newsequentialid()),
[Nome][varchar](150) NOT NULL,
[Sigla][varchar] (2) NOT NULL,

CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED([Identificador])
)
GO

CREATE NONCLUSTERED INDEX ix_CondominioDados_Sigla ON Estado([Sigla]) 

GO
