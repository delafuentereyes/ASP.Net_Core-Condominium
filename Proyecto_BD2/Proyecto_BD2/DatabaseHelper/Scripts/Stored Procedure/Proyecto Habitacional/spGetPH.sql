USE ProyectoBD2;
GO

CREATE OR ALTER PROCEDURE spGetPH
	@id_Habitacional INT
AS 
BEGIN
	SELECT * FROM tblPHabitacionales
    WHERE ID_Habitacional = @id_Habitacional
END
GO