USE [condominio]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE dbo.CondominioDados(
[Identificador][uniqueidentifier] NOT NULL DEFAULT (newsequentialid()),
[Nome][varchar](300) NOT NULL,
[CpfCnpj] [Varchar](14) NOT NULL,
[Telefone][varchar] (11) NOT NULL,
[Rua][varchar] (255) NOT NULL,
[Cep] INT NOT NULL,
[Numero][varchar] (30) NOT NULL,
[Bairro][varchar] (150) NOT NULL,
[Cidade][varchar] (150) NOT NULL,
[IdentificadorEstado] uniqueidentifier NOT NULL,
[Pais][varchar] (60) NOT NULL,

CONSTRAINT [PK_CondominioDados] PRIMARY KEY NONCLUSTERED([Identificador])
)
GO

CREATE CLUSTERED INDEX ix_CondominioDados_CpfCnpj ON CondominioDados([CpfCnpj]) 

GO

ALTER TABLE[dbo].[CondominioDados] WITH CHECK ADD FOREIGN KEY ([IdentificadorEstado])
REFERENCES [dbo].[Estado]([Identificador])

GO
