CREATE DATABASE ProyectoBD2;
USE ProyectoBD2;
GO

CREATE TABLE [tblPHabitacionales](
	ID_Habitacional INT IDENTITY(1,1) NOT NULL,
	Logo_Habitacional VARCHAR (100) NOT NULL,
	Codigo_Habitacional VARCHAR (100) NOT NULL,
	Nombre_Habitacional VARCHAR (100) NOT NULL,
	Direccion_Habitacional VARCHAR (300) NOT NULL,
	Telefono_Oficina VARCHAR (20) NOT NULL

	CONSTRAINT PKtblPHabitacionales PRIMARY KEY (ID_Habitacional),
	CONSTRAINT UNQtblPHabitacionales UNIQUE (Codigo_Habitacional),
)
GO


SELECT * FROM tblPHabitacionales
GO

DROP TABLE tblPHabitacionales