------------------VARIABLES PARA TRAER LOS ID DE CADA TIPO DE VEHÍCULO
declare @AUTO uniqueidentifier = (select ID_Tipo_Vehiculo from TELEPEAJE.DBO.Tipo_Vehiculo WHERE Tipo_Vehiculo='AUTO');
declare @MOTO uniqueidentifier = (select ID_Tipo_Vehiculo from TELEPEAJE.DBO.Tipo_Vehiculo WHERE Tipo_Vehiculo='MOTO');
declare @CAMION uniqueidentifier = (select ID_Tipo_Vehiculo from TELEPEAJE.DBO.Tipo_Vehiculo WHERE Tipo_Vehiculo='CAMION');
declare @NA uniqueidentifier = (select ID_Tipo_Vehiculo from TELEPEAJE.DBO.Tipo_Vehiculo WHERE Tipo_Vehiculo='N/A');

------------------INSERT
INSERT INTO TELEPEAJE.DBO.Patente (Patente,ID_Tipo_Vehiculo,Telepeaje)
VALUES
('AAA 111',@AUTO,1),
('AAA 222',@AUTO,1),
('AAA 333',@AUTO,1),
('MMM 111',@MOTO,1),
('MMM 222',@MOTO,1),
('MMM 333',@MOTO,1),
('CCC 111',@CAMION,1),
('CCC 222',@CAMION,1),
('CCC 333',@CAMION,1),
('XXX 111',@NA,0),
('XXX 222',@NA,0),
('XXX 333',@NA,0);