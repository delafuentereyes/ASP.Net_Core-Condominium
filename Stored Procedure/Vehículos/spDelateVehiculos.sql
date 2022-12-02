USE ProyectoBD2
GO

CREATE OR ALTER PROCEDURE spDeleteVehiculos
    @id_Vehiculo INT



AS
BEGIN
        DELETE FROM tblVehiculos
        WHERE ID_Vehiculo = @id_Vehiculo
END
GO