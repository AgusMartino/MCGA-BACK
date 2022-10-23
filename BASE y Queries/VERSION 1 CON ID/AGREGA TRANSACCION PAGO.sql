--------VARIABLES
declare @patente uniqueidentifier = (select * 
from TELEPEAJE.dbo.Patente pat 
where Patente='MMM 333');

declare @estado uniqueidentifier = (select ID_Estado from TELEPEAJE.dbo.Estado where Estado='Pago');

declare @precio Money = (select Precio
from TELEPEAJE.dbo.Patente pat
inner join TELEPEAJE.dbo.Tipo_Vehiculo tip	on pat.ID_Tipo_Vehiculo=tip.ID_Tipo_Vehiculo
where Patente='MMM 222');

------------INSERT
INSERT INTO TELEPEAJE.dbo.Transacciones (ID_Transacciones,ID_Patente,ID_Estado,Fecha,Precio)
VALUES (NEWID(),@patente,@estado,getdate(),@precio);