USE ProyectoBD2
GO

CREATE OR ALTER PROCEDURE spDeleteUsuarios
    @id_Usuario INT



AS
BEGIN
        DELETE FROM tblUsuarios
        WHERE ID_Usuario = @id_Usuario
END
GO