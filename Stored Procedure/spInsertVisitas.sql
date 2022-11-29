USE ProyectoBD2;
USE master;

CREATE PROCEDURE spInsertVisitas

	@id_TipoVisita INT,
	@cedula_Visita VARCHAR(100),
	@nombre_Visita VARCHAR(100),
	@color_Vehiculo VARCHAR(10)
AS 
BEGIN
		INSERT INTO tblVisitas (ID_TipoVisita,Cedula_Visita,Nombre_Visita,Color_Vehiculo)

		VALUES (@id_TipoVisita,@cedula_Visita,@nombre_Visita,@color_Vehiculo)
END
GO

EXEC spInsertUsuarios 1,'2-0783-0956','Jason Delgado Aguilar','jesusreyes_7@outlook.com',
					  '84648776', 'PNG','Bychuzz','jesus123',1,1;
GO


--hay que analizar ese color de vehiculo porque si jalamos el id no es necesario poberlo en la tabla de visita 
SELECT * FROM tblUsuarios;