CREATE OR ALTER PROCEDURE spGetVivienda
        @id_Vivienda INT
AS
BEGIN
    SELECT * FROM tblViviendas
    WHERE ID_Vivienda = @id_Vivienda
END 