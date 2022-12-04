USE ProyectoBD2
GO

CREATE OR ALTER PROCEDURE spDeletePH
    @id_Habitacional INT

AS
BEGIN
        DELETE FROM tblPHabitacionales
        WHERE ID_Habitacional = @id_Habitacional
END
GO