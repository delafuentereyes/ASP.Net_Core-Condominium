CREATE OR ALTER PROCEDURE spDeleteVivienda
    @idVivienda int
AS
BEGIN
    DELETE FROM tblViviendas
    WHERE ID_Vivienda = @idVivienda
END