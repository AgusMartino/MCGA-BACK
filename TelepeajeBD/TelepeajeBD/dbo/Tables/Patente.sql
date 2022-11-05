CREATE TABLE [dbo].[Patente] (
    [ID_Patente]       UNIQUEIDENTIFIER NOT NULL,
    [ID_Tipo_Vehiculo] UNIQUEIDENTIFIER NOT NULL,
    [Patente]          NVARCHAR (50)    NOT NULL,
    [Telepeaje]        BIT              NOT NULL,
    CONSTRAINT [PK_Patente] PRIMARY KEY CLUSTERED ([ID_Patente] ASC),
    CONSTRAINT [FK_Patente_Tipo_Vehiculo] FOREIGN KEY ([ID_Tipo_Vehiculo]) REFERENCES [dbo].[Tipo_Vehiculo] ([ID_Tipo_Vehiculo])
);

