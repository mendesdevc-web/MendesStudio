CREATE TABLE [dbo].[Atendimento_Procedimentos] (
    [codigo_atendimento] INT NOT NULL,
    [posto_atendimento] INT NOT NULL,
    [codigo_procedimento] INT NOT NULL,

    CONSTRAINT [PK_Atendimento_Procedimento]
        PRIMARY KEY (
            [codigo_atendimento],
            [posto_atendimento],
            [codigo_procedimento]
        )
)



CREATE TABLE [dbo].[Procedimentos] (
    [codigo_procedimento] INT IDENTITY(1,1) NOT NULL,
    [desc_procedimento] VARCHAR(150) NOT NULL,

    CONSTRAINT [PK_Procedimentos]
        PRIMARY KEY ([codigo_procedimento])
)


ALTER TABLE [dbo].[Atendimento_Procedimentos]  WITH CHECK ADD  CONSTRAINT [FK_AP_Atendimento] 
FOREIGN KEY([codigo_atendimento], [posto_atendimento])
REFERENCES [dbo].[Atendimentos] ([codigo_atendimento], [codigo_posto])

ALTER TABLE [dbo].[Atendimento_Procedimentos]  WITH CHECK ADD  CONSTRAINT [FK_AP_Procedimento] 
FOREIGN KEY([codigo_procedimento])
REFERENCES [dbo].[Procedimentos] ([codigo_procedimento])
