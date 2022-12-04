USE ProyectoBD2
GO

CREATE OR ALTER PROCEDURE spInsertTipoVisitas
	@tipoVisita VARCHAR(100)
AS 
BEGIN
		INSERT INTO tblTiposVisitas (TipoVisita)
		VALUES (@tipoVisita)
END
GO

EXEC spInsertTipoVisitas 'Visita'
EXEC spInsertTipoVisitas 'Favorita'
EXEC spInsertTipoVisitas 'Delivery'
GO

SELECT * FROM tblTiposVisitas;