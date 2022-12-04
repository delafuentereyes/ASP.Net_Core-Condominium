USE ProyectoBD2
GO

CREATE OR ALTER PROCEDURE spUpdateVehiculos
	@id_Vehiculo INT,
	@marca_Vehiculo VARCHAR(100),
	@modelo_Vehiculo VARCHAR(100),
	@placa_Vehiculo VARCHAR(20),
	@color_Vehiculo VARCHAR(20)

AS 
BEGIN
		UPDATE tblVehiculos
		SET 
			Marca_Vehiculo = @marca_Vehiculo,
			Modelo_Vehiculo = @modelo_Vehiculo, 
			Placa_Vehiculo = @placa_Vehiculo,
			Color_Vehiculo = @color_Vehiculo
		WHERE ID_Vehiculo = @id_Vehiculo;
END		 
GO

