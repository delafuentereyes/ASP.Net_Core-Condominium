USE ProyectoBD2
GO

CREATE PROCEDURE spInsertRoles
	@tipo_rol VARCHAR(100)

AS 
BEGIN
		INSERT INTO tblRoles (Tipo_Rol)
		VALUES (@tipo_rol)
END
GO

EXEC spInsertRoles 'Admin';
EXEC spInsertRoles 'Condomino';
EXEC spInsertRoles 'Oficial de Seguridad';
GO

SELECT * FROM tblRoles;