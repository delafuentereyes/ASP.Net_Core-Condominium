CREATE PROCEDURE spInsertUsuarios
	@nombre_Usuario VARCHAR(100),
	@cedula_Usuario VARCHAR(100),
	@email_Usuario VARCHAR (100),
	@telefono_Usuario VARCHAR (20), 
	@foto_Usuario VARCHAR (100), 
	@usuario VARCHAR(50), 
	@pass VARCHAR(50),
	@id_Rol VARCHAR(50)

AS 
BEGIN
		INSERT INTO tblUsuarios (Nombre_Usuario, Cedula_Usuario, Email_Usuario, 
								Telefono_Usuario, Foto_Usuario, Usuario, Pass, ID_Rol)
		VALUES (@nombre_Usuario, @cedula_Usuario, @email_Usuario, 
				@telefono_Usuario, @foto_Usuario, @usuario, @pass, @id_Rol)
END
GO

EXEC spInsertUsuarios 'Jesús De la Fuente', '1-1855-0200', 'jesusreyes_7@outlook.com', '84648776', 