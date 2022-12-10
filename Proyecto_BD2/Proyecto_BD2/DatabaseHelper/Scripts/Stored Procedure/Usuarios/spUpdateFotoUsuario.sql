USE ProyectoBD2
GO

CREATE OR ALTER PROCEDURE spUpdateFotoUsuario
	@foto_Usuario VARCHAR(50),
	@id_Usuario INT
AS
	BEGIN
		UPDATE tblUsuarios SET Foto_Usuario = @foto_Usuario 
		WHERE ID_Usuario = @id_Usuario
	END
GO