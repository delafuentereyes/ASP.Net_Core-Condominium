CREATE OR ALTER PROCEDURE spUpdateVivienda
    @idVivienda int,
    @numeroVivienda varchar(100),
    @desc_Vivienda varchar(100),
    @numeroHabitaciones int,
    @cochera int,
    @id_Usuario int
AS
BEGIN
    UPDATE tblViviendas 
    SET Numero_Vivienda =@numeroVivienda,
        Desc_Vivienda= @desc_Vivienda, 
        Numero_Habitaciones = @numeroHabitaciones, 
        Cochera = @cochera,
        ID_Usuario = @id_Usuario 
    WHERE ID_Vivienda = @idVivienda
END