USE ProyectoBD2;
GO

CREATE TABLE [tblOficialesSeguridad](
	ID_OficialSeguridad INT IDENTITY(1,1) NOT NULL,
	Nombre_OficialSeguridad VARCHAR (100) NOT NULL,
	Cedula_OficialSeguridad VARCHAR (100) NOT NULL,
	Email_OficialSeguridad VARCHAR (100) NOT NULL,
	Telefono_OficialSeguridad VARCHAR (20) NOT NULL,
	Foto_OficialSeguridad VARCHAR (100) NOT NULL,

	CONSTRAINT PKtblOficialesSeguridad PRIMARY KEY (ID_OficialSeguridad),
	CONSTRAINT UNQtblOficialesSeguridad UNIQUE (Cedula_OficialSeguridad)
)
GO


ALTER TABLE [tblOficialesSeguridad]
ADD ID_Habitacional INT NOT NULL;
GO


ALTER TABLE [tblOficialesSeguridad] 
ADD CONSTRAINT FKtblOficialesSeguridad 
FOREIGN KEY (ID_Habitacional) 
REFERENCES [tblPHabitacionales] (ID_Habitacional);
GO

SELECT * FROM tblOficialesSeguridad
GO