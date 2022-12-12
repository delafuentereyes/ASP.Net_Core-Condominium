USE ProyectoBD2
GO


CREATE OR ALTER PROCEDURE spInsertPH
	@logo_Habitacional VARCHAR (100),
    @codigo_Habitacional VARCHAR (100),
    @nombre_Habitacional VARCHAR (100),
    @direccion_Habitacional VARCHAR (300),
    @telefono_Oficina VARCHAR (20),
	@numero_Habitaciones INT,
	@id_Vivienda INT
AS 
BEGIN
		INSERT INTO tblPHabitacionales (Logo_Habitacional, Codigo_Habitacional, Nombre_Habitacional, 
								Direccion_Habitacional, Telefono_Oficina, Numero_Habitaciones, ID_Vivienda)
		VALUES (@logo_Habitacional, @codigo_Habitacional, @nombre_Habitacional,
			    @direccion_Habitacional, @telefono_Oficina, @numero_Habitaciones, @id_Vivienda)
END
GO

EXEC spInsertPH 'PN','001002530','Condominio Solem',
                'Ciudad Colón, del Fresh Market 600m sur y 50m oeste.','+506 2249-5656', 3, 1
GO

SELECT * FROM tblPHabitacionales;