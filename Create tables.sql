CREATE DATABASE ProyectoBD2;
USE ProyectoBD2;
GO

CREATE TABLE tblRoles(
	ID_Rol INT IDENTITY(1,1) NOT NULL,
	Tipo_Rol VARCHAR(100) NOT NULL,

	CONSTRAINT PKtblRoles PRIMARY KEY (ID_Rol),
)
GO

CREATE TABLE tblPHabitacionales(
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

CREATE TABLE tblUsuarios(
	ID_Usuario INT IDENTITY(1,1) NOT NULL,
	Nombre_Usuario VARCHAR (100) NOT NULL,
	Cedula_Usuario VARCHAR (100) NOT NULL,
	Email_Usuario VARCHAR (100) NOT NULL,
	Telefono_Usuario VARCHAR (20) NOT NULL,
	Usuario VARCHAR(50) NOT NULL,
	Pass VARCHAR(50) NOT NULL,

	ID_Rol INT NOT NULL,
	ID_Habitacional INT NOT NULL,

	CONSTRAINT PKtblUsuarios PRIMARY KEY (ID_Usuario),

	CONSTRAINT FKtblUsuarios1 FOREIGN KEY (ID_Rol)
	REFERENCES tblRoles (ID_Rol),

	CONSTRAINT FKtblUsuarios2 FOREIGN KEY (ID_Habitacional)
	REFERENCES tblPHabitacionales (ID_Habitacional),

	CONSTRAINT UNQtblUsuarios UNIQUE (Cedula_Usuario)
)
GO

------------------------------------------------------------------------------------------------

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

---------------------------------------------------------------------------------------------------------------

CREATE TABLE tblTiposVisitas(
	ID_TipoVisita INT IDENTITY(1,1) NOT NULL,
	TipoVisita VARCHAR(100) NOT NULL,

	CONSTRAINT PKtblTiposVisitas PRIMARY KEY (ID_TipoVisita)
)
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



