CREATE DATABASE ProyectoBD2;
GO
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
	Foto_Usuario VARCHAR (200) NOT NULL,
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
	Marca_Vehiculo VARCHAR(100) NOT NULL,
	Modelo_Vehiculo VARCHAR(100) NOT NULL,
	Placa_Vehiculo VARCHAR(20) NOT NULL,
	Color_Vehiculo VARCHAR(20) NOT NULL,

	CONSTRAINT PKtblVehiculos PRIMARY KEY(ID_Vehiculo)
)
GO

CREATE TABLE tblVehiculosxCondominos(
	ID_Usuario INT NOT NULL,
	ID_Vehiculo INT NOT NULL,

	CONSTRAINT PKtblVehiculosxCondominos PRIMARY KEY(ID_Usuario, ID_Vehiculo),

	CONSTRAINT FKtblVehiculosxCondominos1 FOREIGN KEY(ID_Usuario) REFERENCES tblUsuarios(ID_Usuario),
	CONSTRAINT FKtblVehiculosxCondominos2 FOREIGN KEY(ID_Vehiculo) REFERENCES tblVehiculos(ID_Vehiculo)
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
	
	ID_Vehiculo INT NOT NULL,

	CONSTRAINT PKtblVisitas PRIMARY KEY (ID_Visita),

	CONSTRAINT FKtblVisitas1 FOREIGN KEY (ID_Vehiculo)
	REFERENCES tblVehiculos (ID_Vehiculo),
	CONSTRAINT FKtblVisitas2 FOREIGN KEY (ID_TipoVisita)
	REFERENCES tblTiposVisitas (ID_TipoVisita),
)
GO

CREATE TABLE tblUsuarioAccess(
    ID_Usuario [int] NOT NULL,
    [Controller] [varchar](50) NULL,
    [Action] [varchar](50) NULL,
    [DatabaseAction] [varchar](50) NULL
) ON [PRIMARY]
GO



ALTER TABLE tblUsuarioAccess  WITH CHECK ADD  CONSTRAINT FKtblUsuarioAccess FOREIGN KEY(ID_Usuario)
REFERENCES tblUsuarios (ID_Usuario)
GO


CREATE TABLE tblViviendas(
    [ID_Vivienda] [int] IDENTITY(1,1) NOT NULL,
    [Numero_Vivienda] [varchar](100) NOT NULL,
    [Desc_Vivienda] [varchar](100) NULL,
    [Numero_Habitaciones] [int] NULL,
    [Cochera] [int] NULL,
    [ID_Habitacional] [int] NOT NULL,
    [ID_Usuario] [int] NULL,
 CONSTRAINT PK_tblViviendas PRIMARY KEY CLUSTERED 
(
    [ID_Vivienda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE tblViviendas  WITH CHECK ADD FOREIGN KEY(ID_Usuario)
REFERENCES tblUsuarios (ID_Usuario)
GO

ALTER TABLE tblViviendas  WITH CHECK ADD FOREIGN KEY([ID_Habitacional])
REFERENCES tblPHabitacionales ([ID_Habitacional])
GO


