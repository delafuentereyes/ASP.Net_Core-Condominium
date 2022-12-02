USE ProyectoBD2
GO

CREATE PROCEDURE spInsertVisitas
	@id_TipoVisita INT,
	@cedula_Visita VARCHAR(100),
	@nombre_Visita VARCHAR(100),
	@id_Vehiculo INT
AS 
BEGIN
		INSERT INTO tblVisitas (ID_TipoVisita, Cedula_Visita, Nombre_Visita, ID_Vehiculo)

		VALUES (@id_TipoVisita, @cedula_Visita, @nombre_Visita, @id_Vehiculo)
END
GO

EXEC spInsertVisitas 1, '200281728', 'Jason Delgado', 1			 
GO
 
SELECT * FROM tblVisitas;
GO