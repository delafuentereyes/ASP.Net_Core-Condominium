USE ProyectoBD2;
GO

CREATE TABLE tblVehiculos(
	ID_Vehiculo INT IDENTITY(1,1) NOT NULL,
	Marca_Vehiculo VARCHAR(20) NOT NULL,

	CONSTRAINT PKtblVehiculos PRIMARY KEY(ID_Vehiculo)
)
GO

CREATE TABLE tblModelos(
	ID_Modelo Int Identity(1,1) NOT NULL,
	ID_Vehiculo int NOT NULL, 
	Modelo_Vehiculo Varchar(100) NOT NULL,

	CONSTRAINT PKtblModelos PRIMARY KEY(ID_MODELO),
	CONSTRAINT FKtblModelos FOREIGN KEY(ID_Vehiculo) REFERENCES tblVehiculos(ID_Vehiculo)
)
GO


CREATE TABLE tblVehiculosxCondominos(
	ID_Usuario INT NOT NULL,
	ID_Vehiculo INT NOT NULL,
	ID_Modelo INT NOT NULL,

	Placa_Vehiculo VARCHAR(20) NOT NULL,
	Color_Vehiculo VARCHAR(20) NOT NULL,

	CONSTRAINT PKtblVehiculosxCondominos PRIMARY KEY(ID_Usuario, ID_Vehiculo, ID_Modelo),
	CONSTRAINT FKtblVehiculosxCondominos1 FOREIGN KEY(ID_Usuario) REFERENCES tblUsuarios(ID_Usuario),
	CONSTRAINT FKtblVehiculosxCondominos2 FOREIGN KEY(ID_Vehiculo) REFERENCES tblVehiculos(ID_Vehiculo),
	CONSTRAINT FKtblVehiculosxCondominos3 FOREIGN KEY(ID_Modelo) REFERENCES tblModelos(ID_Modelo)

)
GO