USE ProyectoBD2;


CREATE PROCEDURE spInsertPH
	@logo_Habitacional VARCHAR (100),
    @codigo_Habitacional VARCHAR (100),
    @nombre_Habitacional VARCHAR (100),
    @direccion_Habitacional VARCHAR (300),
    @telefono_Oficina VARCHAR (20)
AS 
BEGIN
		INSERT INTO tblPHabitacionales (Logo_Habitacional, Codigo_Habitacional, Nombre_Habitacional, 
								Direccion_Habitacional, Telefono_Oficina)

		VALUES (@logo_Habitacional ,@codigo_Habitacional,@nombre_Habitacional,
			    @direccion_Habitacional,@telefono_Oficina)
END
GO

EXEC spInsertPH 'PN','001002530','Condominio Solem',
                'Ciudad Colón, del Fresh Market 600m sur y 50m oeste.','+506 2249-5656'

SELECT * FROM tblPHabitacionales;