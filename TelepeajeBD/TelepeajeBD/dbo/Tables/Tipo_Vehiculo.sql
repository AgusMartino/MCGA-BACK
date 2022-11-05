CREATE TABLE [dbo].[Tipo_Vehiculo] (
    [ID_Tipo_Vehiculo] UNIQUEIDENTIFIER NOT NULL,
    [Tipo_Vehiculo]    NVARCHAR (50)    NOT NULL,
    [Precio]           MONEY            NOT NULL,
    CONSTRAINT [PK_Tipo_Vehiculo] PRIMARY KEY CLUSTERED ([ID_Tipo_Vehiculo] ASC)
);

