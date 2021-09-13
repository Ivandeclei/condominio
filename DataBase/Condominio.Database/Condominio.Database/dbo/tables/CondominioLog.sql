USE [condominio]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CondominioLog](
[Identificador][uniqueidentifier] NOT NULL DEFAULT (newsequentialid()),
[Metodo][varchar](MAX) NOT NULL,
[Excecao][varchar] (MAX) NOT NULL,
[Erros][varchar] (MAX) NOT NULL,
[DataHorario][datetimeoffset] NOT NULL,

CONSTRAINT [PK_CondominioLog] PRIMARY KEY NONCLUSTERED([Identificador])
)
GO

CREATE CLUSTERED INDEX ix_CondominioLog_DataHorario ON [CondominioLog]([DataHorario])