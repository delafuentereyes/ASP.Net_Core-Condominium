USE ProyectoBD2
GO

CREATE OR ALTER PROCEDURE spCreateViviendas
    @numero_Vivienda varchar(100),
    @desc_Vivienda varchar(100),
    @numero_Habitaciones int,
    @cochera int,
    @id_Habitacional int,
	@id_Usuario int
AS
BEGIN
INSERT INTO tblViviendas
          
		  (Numero_Vivienda,
            Desc_Vivienda,
            Numero_Habitaciones,
            Cochera,
            ID_Habitacional,
			ID_Usuario)
     VALUES
          (@numero_Vivienda,
		   @desc_Vivienda,
		   @numero_Habitaciones,
		   @cochera,
		   @id_Habitacional,
		   @id_Usuario)
END
GO

EXEC spCreateViviendas '1011', 'descripcion', 3, 1, 1, 2