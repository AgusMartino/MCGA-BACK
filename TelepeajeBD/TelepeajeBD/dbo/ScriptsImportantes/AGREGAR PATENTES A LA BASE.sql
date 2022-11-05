------------------VARIABLES PARA TRAER LOS ID DE CADA TIPO DE VEHÍCULO
declare @MOTO uniqueidentifier = (select ID_Tipo_Vehiculo from TELEPEAJE.DBO.Tipo_Vehiculo WHERE Tipo_Vehiculo='MOTO');
declare @AUTO uniqueidentifier = (select ID_Tipo_Vehiculo from TELEPEAJE.DBO.Tipo_Vehiculo WHERE Tipo_Vehiculo='AUTO');
declare @CAMION uniqueidentifier = (select ID_Tipo_Vehiculo from TELEPEAJE.DBO.Tipo_Vehiculo WHERE Tipo_Vehiculo='CAMION');

------------------INSERT
INSERT INTO TELEPEAJE.DBO.Patente (ID_Patente,ID_Tipo_Vehiculo,Patente,Telepeaje)
VALUES
(NEWID(),@AUTO,'AAA 111',1),
(NEWID(),@AUTO,'AAA 222',1),
(NEWID(),@AUTO,'AAA 333',1),
(NEWID(),@MOTO,'MMM 111',1),
(NEWID(),@MOTO,'MMM 222',1),
(NEWID(),@MOTO,'MMM 333',1),
(NEWID(),@CAMION,'CCC 111',1),
(NEWID(),@CAMION,'CCC 222',1),
(NEWID(),@CAMION,'CCC 333',1);