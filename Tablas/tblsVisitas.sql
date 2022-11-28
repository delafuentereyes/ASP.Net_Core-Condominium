USE ProyectoBD2;
GO

CREATE TABLE tblVisitas(
	ID_Visita INT IDENTITY(1,1) NOT NULL,
	ID_TipoVisita INT NOT NULL,
	Cedula_Visita VARCHAR(100) NOT NULL,
	Nombre_Visita VARCHAR(100) NOT NULL,
	Color_Vehiculo VARCHAR(10) NOT NULL,
	
	ID_Vehiculo INT NOT NULL,
	ID_Modelo INT NOT NULL,

	CONSTRAINT PKtblVisitas PRIMARY KEY (ID_Visita),

	CONSTRAINT FKtblVisitas1 FOREIGN KEY (ID_Vehiculo)
	REFERENCES tblVehiculos (ID_Vehiculo),

	CONSTRAINT FKtblVisitas2 FOREIGN KEY (ID_Modelo)
	REFERENCES tblModelos (ID_Modelo),

	CONSTRAINT FKtblVisitas3 FOREIGN KEY (ID_TipoVisita)
	REFERENCES tblTiposVisitas (ID_TipoVisita),
)
GO

CREATE TABLE tblTiposVisitas(
	ID_TipoVisita INT IDENTITY(1,1) NOT NULL,
	TipoVisita VARCHAR(100) NOT NULL,

	CONSTRAINT PKtblTiposVisitas PRIMARY KEY (ID_TipoVisita)
)
GO