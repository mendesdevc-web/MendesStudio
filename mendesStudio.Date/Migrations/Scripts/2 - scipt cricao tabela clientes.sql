CREATE TABLE [dbo].[Clientes] (
    [codigo_cliente] INT IDENTITY(1,1) NOT NULL,
    [nome_cliente] VARCHAR(150) NOT NULL,
    [sexo_cliente] VARCHAR(14) NOT NULL,
    [nome_social] VARCHAR(150) NULL,
    [cpf_cliente] VARCHAR(14) NOT NULL,
    [rg_cliente] VARCHAR(20) NOT NULL,

    CONSTRAINT [PK_Clientes]
        PRIMARY KEY ([codigo_cliente]),

    CONSTRAINT [UQ_Clientes_CPF]
        UNIQUE ([cpf_cliente])
);

ALTER TABLE [dbo].[Atendimentos]  WITH CHECK ADD  CONSTRAINT [FK_Atendimento_Cliente] FOREIGN KEY([codigo_cliente])
REFERENCES [dbo].[Clientes] ([codigo_cliente])