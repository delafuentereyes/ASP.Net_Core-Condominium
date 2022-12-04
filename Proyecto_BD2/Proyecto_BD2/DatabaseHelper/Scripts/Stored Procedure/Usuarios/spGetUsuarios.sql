USE ProyectoBD2;
GO

CREATE OR ALTER PROCEDURE spGetUsuarios
	@usuario VARCHAR(100),
	@pass VARCHAR (100)
AS 
BEGIN
	SELECT 
		u.ID_Usuario,
		u.Nombre_Usuario, 
		u.Cedula_Usuario, 
		u.Email_Usuario, 
		u.Telefono_Usuario, 
		u.Foto_Usuario, 
		r.Tipo_Rol, 
		ph.Logo_Habitacional, 
        ph.Codigo_Habitacional, 
		ph.Nombre_Habitacional, 
		ph.Direccion_Habitacional, 
		ph.Telefono_Oficina, 
		v.Marca_Vehiculo, 
        v.Modelo_Vehiculo, 
		v.Placa_Vehiculo, 
		v.Color_Vehiculo
	FROM tblUsuarios u INNER JOIN
			tblRoles r ON u.ID_Rol = r.ID_Rol INNER JOIN
				tblPHabitacionales ph ON u.ID_Habitacional = ph.ID_Habitacional INNER JOIN
					tblVehiculosxCondominos vc ON u.ID_Usuario = vc.ID_Usuario INNER JOIN
						tblVehiculos v ON vc.ID_Vehiculo = v.ID_Vehiculo
	WHERE Usuario = @usuario
	AND Pass = @pass
END
GO