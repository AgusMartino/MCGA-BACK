CREATE TABLE [dbo].[Transacciones] (
    [ID_Transacciones] UNIQUEIDENTIFIER NOT NULL,
    [ID_Patente]       UNIQUEIDENTIFIER NOT NULL,
    [ID_Estado]        UNIQUEIDENTIFIER NOT NULL,
    [Fecha]            DATETIME         NOT NULL,
    [Precio]           MONEY            NOT NULL,
    CONSTRAINT [PK_Transacciones] PRIMARY KEY CLUSTERED ([ID_Transacciones] ASC),
    CONSTRAINT [FK_Transacciones_Estado] FOREIGN KEY ([ID_Estado]) REFERENCES [dbo].[Estado] ([ID_Estado]),
    CONSTRAINT [FK_Transacciones_Patente] FOREIGN KEY ([ID_Patente]) REFERENCES [dbo].[Patente] ([ID_Patente])
);

