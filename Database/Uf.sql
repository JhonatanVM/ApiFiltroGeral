﻿CREATE TABLE [dbo].[Uf]
(
	[CodigoIbge] tinyint primary key NOT NULL,
	[Nome] varchar(100) NOT NULL,
	[Sigla] char(2) NULL,
	[IdRegiaoPais] tinyint NOT NULL,
)
