USE [ExemplosEFCore]
GO
/****** Object:  StoredProcedure [dbo].[PRC_SEL_DETALHES_ESTADO]    Script Date: 01/07/2019 10:11:11 ******/
DROP PROCEDURE [dbo].[PRC_SEL_DETALHES_ESTADO]
GO
ALTER TABLE [dbo].[Estados] DROP CONSTRAINT [FK_Estado_Regiao]
GO
/****** Object:  View [dbo].[VW_DETALHESREGIOES]    Script Date: 01/07/2019 10:11:11 ******/
DROP VIEW [dbo].[VW_DETALHESREGIOES]
GO
/****** Object:  Table [dbo].[Estados]    Script Date: 01/07/2019 10:11:11 ******/
DROP TABLE [dbo].[Estados]
GO
/****** Object:  Table [dbo].[Regioes]    Script Date: 01/07/2019 10:11:11 ******/
DROP TABLE [dbo].[Regioes]
GO
/****** Object:  Table [dbo].[Regioes]    Script Date: 01/07/2019 10:11:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Regioes](
	[IdRegiao] [int] NOT NULL,
	[NomeRegiao] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Regioes] PRIMARY KEY CLUSTERED 
(
	[IdRegiao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estados]    Script Date: 01/07/2019 10:11:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estados](
	[SiglaEstado] [char](2) NOT NULL,
	[NomeEstado] [varchar](20) NOT NULL,
	[NomeCapital] [varchar](20) NOT NULL,
	[IdRegiao] [int] NOT NULL,
 CONSTRAINT [PK_Estados] PRIMARY KEY CLUSTERED 
(
	[SiglaEstado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VW_DETALHESREGIOES]    Script Date: 01/07/2019 10:11:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[VW_DETALHESREGIOES]
AS
SELECT R.IdRegiao, R.NomeRegiao, QtdEstados = COUNT(1)
FROM dbo.Regioes R
INNER JOIN dbo.Estados E ON E.IdRegiao = R.IdRegiao
GROUP BY R.IdRegiao, R.NomeRegiao
GO
INSERT [dbo].[Estados] ([SiglaEstado], [NomeEstado], [NomeCapital], [IdRegiao]) VALUES (N'AC', N'Acre', N'Rio Branco', 3)
INSERT [dbo].[Estados] ([SiglaEstado], [NomeEstado], [NomeCapital], [IdRegiao]) VALUES (N'AL', N'Alagoas', N'Maceió', 2)
INSERT [dbo].[Estados] ([SiglaEstado], [NomeEstado], [NomeCapital], [IdRegiao]) VALUES (N'AM', N'Amazonas', N'Manaus', 3)
INSERT [dbo].[Estados] ([SiglaEstado], [NomeEstado], [NomeCapital], [IdRegiao]) VALUES (N'AP', N'Amapá', N'Macapá', 3)
INSERT [dbo].[Estados] ([SiglaEstado], [NomeEstado], [NomeCapital], [IdRegiao]) VALUES (N'BA', N'Bahia', N'Salvador', 2)
INSERT [dbo].[Estados] ([SiglaEstado], [NomeEstado], [NomeCapital], [IdRegiao]) VALUES (N'CE', N'Ceará', N'Fortaleza', 2)
INSERT [dbo].[Estados] ([SiglaEstado], [NomeEstado], [NomeCapital], [IdRegiao]) VALUES (N'DF', N'Distrito Federal', N'Brasília', 1)
INSERT [dbo].[Estados] ([SiglaEstado], [NomeEstado], [NomeCapital], [IdRegiao]) VALUES (N'ES', N'Espírito Santo', N'Vitória', 4)
INSERT [dbo].[Estados] ([SiglaEstado], [NomeEstado], [NomeCapital], [IdRegiao]) VALUES (N'GO', N'Goiás', N'Goiânia', 1)
INSERT [dbo].[Estados] ([SiglaEstado], [NomeEstado], [NomeCapital], [IdRegiao]) VALUES (N'MA', N'Maranháo', N'São Luís', 2)
INSERT [dbo].[Estados] ([SiglaEstado], [NomeEstado], [NomeCapital], [IdRegiao]) VALUES (N'MG', N'Minas Gerais', N'Belo Horizonte', 4)
INSERT [dbo].[Estados] ([SiglaEstado], [NomeEstado], [NomeCapital], [IdRegiao]) VALUES (N'MS', N'Mato Grosso do Sul', N'Campo Grande', 1)
INSERT [dbo].[Estados] ([SiglaEstado], [NomeEstado], [NomeCapital], [IdRegiao]) VALUES (N'MT', N'Mato Grosso', N'Cuiabá', 1)
INSERT [dbo].[Estados] ([SiglaEstado], [NomeEstado], [NomeCapital], [IdRegiao]) VALUES (N'PA', N'Pará', N'Belém', 3)
INSERT [dbo].[Estados] ([SiglaEstado], [NomeEstado], [NomeCapital], [IdRegiao]) VALUES (N'PB', N'Paraíba', N'João Pessoa', 2)
INSERT [dbo].[Estados] ([SiglaEstado], [NomeEstado], [NomeCapital], [IdRegiao]) VALUES (N'PE', N'Pernambuco', N'Recife', 2)
INSERT [dbo].[Estados] ([SiglaEstado], [NomeEstado], [NomeCapital], [IdRegiao]) VALUES (N'PI', N'Piauí', N'Teresina', 2)
INSERT [dbo].[Estados] ([SiglaEstado], [NomeEstado], [NomeCapital], [IdRegiao]) VALUES (N'PR', N'Paraná', N'Curitiba', 5)
INSERT [dbo].[Estados] ([SiglaEstado], [NomeEstado], [NomeCapital], [IdRegiao]) VALUES (N'RJ', N'Rio de Janeiro', N'Rio de Janeiro', 4)
INSERT [dbo].[Estados] ([SiglaEstado], [NomeEstado], [NomeCapital], [IdRegiao]) VALUES (N'RN', N'Rio Grande do Norte', N'Natal', 2)
INSERT [dbo].[Estados] ([SiglaEstado], [NomeEstado], [NomeCapital], [IdRegiao]) VALUES (N'RO', N'Rondônia', N'Porto Velho', 3)
INSERT [dbo].[Estados] ([SiglaEstado], [NomeEstado], [NomeCapital], [IdRegiao]) VALUES (N'RR', N'Roraima', N'Boa Vista', 3)
INSERT [dbo].[Estados] ([SiglaEstado], [NomeEstado], [NomeCapital], [IdRegiao]) VALUES (N'RS', N'Rio Grande do Sul', N'Porto Alegre', 5)
INSERT [dbo].[Estados] ([SiglaEstado], [NomeEstado], [NomeCapital], [IdRegiao]) VALUES (N'SC', N'Santa Catarina', N'Florianápolis', 5)
INSERT [dbo].[Estados] ([SiglaEstado], [NomeEstado], [NomeCapital], [IdRegiao]) VALUES (N'SE', N'Sergipe', N'Aracaju', 2)
INSERT [dbo].[Estados] ([SiglaEstado], [NomeEstado], [NomeCapital], [IdRegiao]) VALUES (N'SP', N'São Paulo', N'São Paulo', 4)
INSERT [dbo].[Estados] ([SiglaEstado], [NomeEstado], [NomeCapital], [IdRegiao]) VALUES (N'TO', N'Tocantins', N'Palmas', 3)
INSERT [dbo].[Regioes] ([IdRegiao], [NomeRegiao]) VALUES (1, N'Centro-Oeste')
INSERT [dbo].[Regioes] ([IdRegiao], [NomeRegiao]) VALUES (2, N'Nordeste')
INSERT [dbo].[Regioes] ([IdRegiao], [NomeRegiao]) VALUES (3, N'Norte')
INSERT [dbo].[Regioes] ([IdRegiao], [NomeRegiao]) VALUES (4, N'Sudeste')
INSERT [dbo].[Regioes] ([IdRegiao], [NomeRegiao]) VALUES (5, N'Sul')
ALTER TABLE [dbo].[Estados]  WITH CHECK ADD  CONSTRAINT [FK_Estado_Regiao] FOREIGN KEY([IdRegiao])
REFERENCES [dbo].[Regioes] ([IdRegiao])
GO
ALTER TABLE [dbo].[Estados] CHECK CONSTRAINT [FK_Estado_Regiao]
GO
/****** Object:  StoredProcedure [dbo].[PRC_SEL_DETALHES_ESTADO]    Script Date: 01/07/2019 10:11:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[PRC_SEL_DETALHES_ESTADO]
(
	@CodEstado char(2)
)
AS
BEGIN

	SELECT E.SiglaEstado, E.NomeEstado, E.NomeCapital, E.IdRegiao,
	       R.NomeRegiao
	FROM dbo.Estados E
	INNER JOIN dbo.Regioes R ON R.IdRegiao = E.IdRegiao
	WHERE E.SiglaEstado = @CodEstado

END
GO
