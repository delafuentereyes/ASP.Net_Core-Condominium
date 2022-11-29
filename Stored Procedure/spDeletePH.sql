CREATE PROCEDURE spDeletePH
    @id_Habitacional INT



AS
BEGIN
        DELETE FROM tblPHabitacionales
        WHERE ID_Habitacional = @id_Habitacional
END
GO