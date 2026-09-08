
CREATE TABLE [dbo].[Postos](
	[codigo_posto] [int] IDENTITY(1,1) NOT NULL,
	[desc_posto] [varchar](100) NOT NULL,
	[nome_empresa] [varchar](150) NOT NULL,
	[conta_bancaria] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Posto] PRIMARY KEY CLUSTERED 
(
	[codigo_posto] ASC
))

CREATE TABLE [dbo].[Atendimentos](
    [codigo_atendimento] [int] IDENTITY(1,1) NOT NULL,
    [codigo_posto] [int] NOT NULL,
    [codigo_cliente] [int] NOT NULL,
    [data_atendimento] [datetime] NOT NULL,
    [valor_total] [decimal](10, 2) NOT NULL,

    CONSTRAINT [PK_Atendimento] 
        PRIMARY KEY CLUSTERED (
            [codigo_atendimento] ASC,
            [codigo_posto] ASC
        ),

    CONSTRAINT [FK_Atendimento_Posto]
        FOREIGN KEY ([codigo_posto])
        REFERENCES [dbo].[Postos] ([codigo_posto])
);








