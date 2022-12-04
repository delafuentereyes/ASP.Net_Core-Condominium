USE ProyectoBD2
GO

CREATE OR ALTER PROCEDURE spDeleteVisitas
    @id_Visita INT

AS
BEGIN
        DELETE FROM tblVisitas
        WHERE ID_Visita = @id_Visita
END
GO