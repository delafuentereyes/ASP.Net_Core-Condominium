USE ProyectoBD2;
GO

CREATE TABLE tblUsuarios(
	ID_Usuario INT IDENTITY(1,1) NOT NULL,
	Nombre_Usuario VARCHAR (100) NOT NULL,
	Cedula_Usuario VARCHAR (100) NOT NULL,
	Email_Usuario VARCHAR (100) NOT NULL,
	Telefono_Usuario VARCHAR (20) NOT NULL,
	Foto_Usuario VARCHAR (100) NOT NULL,
	Usuario VARCHAR(50) NOT NULL,
	Pass VARCHAR(50) NOT NULL,

	ID_Rol INT NOT NULL,

	CONSTRAINT PKtblUsuarios PRIMARY KEY (ID_Usuario),

	CONSTRAINT FKtblUsuarios FOREIGN KEY (ID_Rol)
	REFERENCES tblRoles (ID_Rol),

	CONSTRAINT UNQtblUsuarios UNIQUE (Cedula_Usuario)
)

