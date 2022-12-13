USE ProyectoBD2
GO

CREATE OR ALTER PROCEDURE spInsertVehiculosxCondominos
	@id_Usuario INT,
	@id_Vehiculo INT
AS 
BEGIN
		INSERT INTO tblVehiculosxCondominos (ID_Usuario, ID_Vehiculo)
		VALUES (@id_Usuario, @id_Vehiculo)
END
GO

EXEC spInsertVehiculosxCondominos 2, 2
GO

SELECT * FROM tblVehiculosxCondominos