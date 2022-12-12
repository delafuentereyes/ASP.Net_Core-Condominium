CREATE OR ALTER PROCEDURE spGetViviendas
        @id_Habitacional INT
AS
BEGIN
    SELECT * FROM tblViviendas
    WHERE ID_Habitacional=@id_Habitacional
END