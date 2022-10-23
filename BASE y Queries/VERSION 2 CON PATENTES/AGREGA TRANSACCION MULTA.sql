--------VARIABLES
DECLARE @PATENTE NVARCHAR(50)='XXX 444'

IF not EXISTS
(
    SELECT 1
	FROM TELEPEAJE.dbo.Patente
	where Patente=@PATENTE
)
BEGIN
	------------------VARIABLES PARA TRAER LOS ID DE CADA TIPO DE VEHÍCULO
	declare @NA uniqueidentifier = (select ID_Tipo_Vehiculo from TELEPEAJE.DBO.Tipo_Vehiculo WHERE Tipo_Vehiculo='N/A');
	------------------INSERT
	INSERT INTO TELEPEAJE.DBO.Patente (Patente,ID_Tipo_Vehiculo,Telepeaje)
	VALUES	(@PATENTE,@NA,0);
END

declare @estado uniqueidentifier = (select ID_Estado from TELEPEAJE.dbo.Estado where Estado='Multa');

declare @precio Money = (select Precio
from TELEPEAJE.dbo.Patente pat
inner join TELEPEAJE.dbo.Tipo_Vehiculo tip	on pat.ID_Tipo_Vehiculo=tip.ID_Tipo_Vehiculo
where Patente=@PATENTE);

------------INSERT
INSERT INTO TELEPEAJE.dbo.Transacciones (ID_Transacciones,Patente,ID_Estado,Fecha,Precio)
VALUES (NEWID(),@PATENTE,@estado,getdate(),@precio);