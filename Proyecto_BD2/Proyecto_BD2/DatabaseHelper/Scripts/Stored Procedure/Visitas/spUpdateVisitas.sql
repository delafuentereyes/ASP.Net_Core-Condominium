USE ProyectoBD2
GO

CREATE OR ALTER PROCEDURE spUpdateVisitas
	@id_Visita INT,
	@id_TipoVisita INT,
	@cedula_Visita VARCHAR(100),
	@nombre_Visita VARCHAR(100),
	@id_Vehiculo INT
AS 
BEGIN
		UPDATE tblVisitas 
		SET ID_TipoVisita = @id_TipoVisita,
			Cedula_Visita = @cedula_Visita,
			Nombre_Visita = @nombre_Visita,
			ID_Vehiculo = @id_Vehiculo
		WHERE ID_Visita = @id_Visita
END
GO

