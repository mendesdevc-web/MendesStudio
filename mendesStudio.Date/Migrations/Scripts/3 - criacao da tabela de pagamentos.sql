CREATE TABLE [dbo].[PAGAMENTOS_CARTAO] (
    [cod_pagamento_cartao] INT IDENTITY(1,1) NOT NULL,
    [codigo_atendimento] INT NOT NULL,
    [posto_atendimento] INT NOT NULL,
    [nome_cartao] VARCHAR(150) NOT NULL,
    [numero_cartao] VARCHAR(4) NOT NULL,
    [valor] DECIMAL(10, 2) NOT NULL,
    [bandeira_cartao] VARCHAR(30) NOT NULL,
    [data_criacao] DATETIME NOT NULL,
    [data_ultima_modificacao] DATETIME NULL,
    [numero_vezes] INT NOT NULL,
    [debito_credito] CHAR(1) NOT NULL,

    CONSTRAINT [PK_Pagamentos_Cartao]
        PRIMARY KEY ([cod_pagamento_cartao]),

    CONSTRAINT [FK_Pagamentos_Cartao_Atendimento]
        FOREIGN KEY ([codigo_atendimento], [posto_atendimento])
        REFERENCES [dbo].[Atendimentos] ([codigo_atendimento], [codigo_posto]),

)



CREATE TABLE [dbo].[PAGAMENTOS_DINHEIRO] (
    [cod_pagamento_dinheiro] INT IDENTITY(1,1) NOT NULL,
    [codigo_atendimento] INT NOT NULL,
    [posto_atendimento] INT NOT NULL,
    [nome_pagador] VARCHAR(150) NOT NULL,
    [cpf_pagador] VARCHAR(100) NOT NULL,
    [valor] DECIMAL(10, 2) NOT NULL,
    [data_criacao] DATETIME NOT NULL,
    [data_ultima_modificacao] DATETIME NULL,

    CONSTRAINT [PK_Pagamentos_Dinheiro]
        PRIMARY KEY ([cod_pagamento_dinheiro]),

    CONSTRAINT [FK_Pagamentos_Dinheiro_Atendimento]
        FOREIGN KEY ([codigo_atendimento], [posto_atendimento])
        REFERENCES [dbo].[Atendimentos] ([codigo_atendimento], [codigo_posto]),

);


CREATE TABLE [dbo].[PAGAMENTOS_PIX] (
    [cod_pagamento_pix] INT IDENTITY(1,1) NOT NULL,
    [codigo_atendimento] INT NOT NULL,
    [posto_atendimento] INT NOT NULL,
    [nome_pagador] VARCHAR(150) NOT NULL,
    [banco_pagador] VARCHAR(100) NOT NULL,
    [valor] DECIMAL(10, 2) NOT NULL,
    [data_criacao] DATETIME NOT NULL,
    [data_ultima_modificacao] DATETIME NULL,

    CONSTRAINT [PK_Pagamentos_Pix]
        PRIMARY KEY ([cod_pagamento_pix]),

    CONSTRAINT [FK_Pagamentos_Pix_Atendimento]
        FOREIGN KEY ([codigo_atendimento], [posto_atendimento])
        REFERENCES [dbo].[Atendimentos] ([codigo_atendimento], [codigo_posto]),
)
