USE ProyectoBD2
GO


CREATE OR ALTER PROCEDURE spUpdateUsuarios
    @id_Usuario INT,
    @nombre_Usuario VARCHAR(100),
    @cedula_Usuario VARCHAR(100),
    @email_Usuario VARCHAR (100),
    @telefono_Usuario VARCHAR (20),
    @foto_Usuario VARCHAR (100),
    @usuario VARCHAR(50),
    @pass VARCHAR(50),
    
	@id_Rol INT,
    @id_Habitacional INT


AS
BEGIN
        UPDATE tblUsuarios
        SET
            Nombre_Usuario = @nombre_Usuario,
            Cedula_Usuario = @cedula_Usuario,
            Email_Usuario = @email_Usuario,
            Telefono_Usuario = @telefono_Usuario,
            Foto_Usuario = @foto_Usuario,
            Usuario = @usuario,
            Pass = @pass,
            ID_Rol = @id_Rol,
			ID_Habitacional = @id_Habitacional

        WHERE ID_Usuario = @id_Usuario;
END
GO