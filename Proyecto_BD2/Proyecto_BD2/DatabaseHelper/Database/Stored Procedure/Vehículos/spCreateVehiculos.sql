USE ProyectoBD2
GO

CREATE PROCEDURE spCreateVehiculos
	@marca_Vehiculo VARCHAR(100),
	@modelo_Vehiculo VARCHAR(100),
	@placa_Vehiculo VARCHAR(20),
	@color_Vehiculo VARCHAR(20)

AS 
BEGIN
		INSERT INTO tblVehiculos (Marca_Vehiculo, Modelo_Vehiculo, Placa_Vehiculo, Color_Vehiculo)
		VALUES (@marca_Vehiculo, @modelo_Vehiculo, @placa_Vehiculo, @color_Vehiculo)
END
GO

EXEC spCreateVehiculos 'Toyota', 'Hilux', '199202', 'Blanco'
GO

SELECT * FROM tblVehiculos
GO