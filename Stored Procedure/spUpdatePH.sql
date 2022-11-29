CREATE PROCEDURE spUpdatePH
    @id_Habitacional INT,
    @logo_Habitacional VARCHAR (100),
    @codigo_Habitacional VARCHAR (100),
    @nombre_Habitacional VARCHAR (100),
    @direccion_Habitacional VARCHAR (300),
    @telefono_Oficina VARCHAR (20)



AS
BEGIN
        UPDATE tblPHabitacionales
        SET
            Logo_Habitacional = @logo_Habitacional,
            Codigo_Habitacional = @codigo_Habitacional,
            Nombre_Habitacional = @nombre_Habitacional,
            Direccion_Habitacional = @direccion_Habitacional,
            Telefono_Oficina = @telefono_Oficina
        WHERE ID_Habitacional = @id_Habitacional;
END
GO