CREATE PROCEDURE spInsertRoles
	@id_rol INT,
	@tipo_rol VARCHAR(100)

AS 
BEGIN
		INSERT INTO tblRoles (ID_Rol, Tipo_Rol)
		VALUES (@id_Rol, @tipo_rol)
END
GO