# ApiFiltroGeral

Rest API de exemplificação de uma busca por múltiplos itens selecionados em um filtro geral utilizando LINQ.

### Prerequisites

Para que o projeto funcione é necessário alterar a connection string na classe BuscaContext:

```
Data Source=.;Initial Catalog=NomeDoBanco;Integrated Security=True
```

Criar uma tabela com o nome Uf:

```
CREATE TABLE [dbo].[Uf]
(
	[CodigoIbge] tinyint primary key NOT NULL,
	[Nome] varchar(100) NOT NULL,
	[Sigla] char(2) NULL,
	[IdRegiaoPais] tinyint NOT NULL,
)
```

Inserir dados na tabela para fazer a busca:

```
INSERT INTO [dbo].[Uf]
           ([CodigoIbge]
           ,[Nome]
           ,[Sigla]
           ,[IdRegiaoPais])
     VALUES
           (1,'Nome','AA',1),
	   (2,'Nome','AA',1),
	   (3,'Nome','AC',1)
	
```
