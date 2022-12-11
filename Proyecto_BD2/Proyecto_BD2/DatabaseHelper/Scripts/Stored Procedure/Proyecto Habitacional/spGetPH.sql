USE ProyectoBD2;
GO

CREATE OR ALTER PROCEDURE spGetPH
	@id_Habitacional VARCHAR(100)
AS 
BEGIN
	SELECT 
		Logo_Habitacional,
		Codigo_Habitacional,
		Nombre_Habitacional,
		Direccion_Habitacional,
		Telefono_Oficina
	FROM tblPHabitacionales
	WHERE ID_Habitacional = @id_Habitacional
END
GO