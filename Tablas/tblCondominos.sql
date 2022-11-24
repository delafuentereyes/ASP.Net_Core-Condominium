USE ProyectoBD2;
GO

CREATE TABLE [tblCondominos](
	ID_Condomino INT IDENTITY(1,1) NOT NULL,
	Nombre_Condomino VARCHAR (100) NOT NULL,
	Cedula_Condomino VARCHAR (100) NOT NULL,
	Email_Condomino VARCHAR (100) NOT NULL,
	Telefono_Condomino VARCHAR (20) NOT NULL,
	Foto_Condomino VARCHAR (100) NOT NULL,
	
	ID_Habitacional INT NOT NULL,


	CONSTRAINT PKtblCondominos PRIMARY KEY (ID_Condomino),

	CONSTRAINT UNQtblCondominos UNIQUE (Cedula_Condomino),

	CONSTRAINT FKtblCondominos FOREIGN KEY (ID_Habitacional)
	REFERENCES tblPHabitacionales (ID_Habitacional)

)
GO

SELECT * FROM tblCondominos