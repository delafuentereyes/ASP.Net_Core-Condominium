USE ProyectoBD2;
GO

CREATE OR ALTER PROCEDURE spGetUsuarioAccess
    @id_Usuario INT
AS
BEGIN
    SELECT * FROM tblUsuarioAccess
    WHERE ID_Usuario = @id_Usuario
END
GO