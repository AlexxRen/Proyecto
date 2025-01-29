/*Procedimentos de Base de datos*/

--Registrar Usuario
CREATE PROCEDURE RegistrarUsuario(
    @Cedula numeric(10),
	@Nombre varchar(50),
    @Apellidos varchar(50),
    @Correo varchar(50),
    @Direccion varchar(120),
	@Contrasea varchar (25),
    @Registrado bit output,
    @Mensaje varchar(100) output
)
AS
BEGIN
    IF (NOT EXISTS(SELECT Correo,Cedula FROM Usuario WHERE Correo=@Correo AND Cedula=@Cedula ))
    BEGIN
		--insertar usuario
        INSERT INTO Usuario(Cedula,Nombres,Apellidos,Correo,Direccion,Contrasea) 
        VALUES (@Cedula,@Nombre,@Apellidos,@Correo,@Direccion,@Contrasea)
		--mensajes de salida
        SET @Registrado = 1
        SET @Mensaje = 'Usuario Registrado'
    END
    ELSE
    BEGIN
        SET @Registrado = 0
        SET @Mensaje ='Usuario ya existente'
    END
END
go



/*
teste 

DECLARE @Registrado BIT, @Mensaje VARCHAR(100)

EXEC RegistrarUsuario 9876543210,'Ana','García','ana@example.com','Calle Nueva',1234,@Registrado OUTPUT, @Mensaje OUTPUT
PRINT @Mensaje

*/
-- Validar Cliente ya existente

Create PROCEDURE ValidarUsuario(
@Cedula numeric (10),
@Correo varchar(50))
as
begin
	if(exists(select * from Usuario where Correo=@Correo and Cedula=@Cedula ))
		select Id_Usuario from Usuario where Correo=@Correo and Cedula=@Cedula 
	else 
		select '0'
end
go
/*
teste

EXEC ValidarUsuario 1234567890,'asdasdsadasda'

EXEC ValidarUsuario 9876543210,'ana@example.com'

*/

--Registrar Transaccion 
CREATE PROCEDURE RegistrarTransaccion
    @Fecha_Transaccion DATETIME,
     @Monto DECIMAL(10,2),
    @Estado VARCHAR(10),
    @Id_OrigenCli NUMERIC(10),
    @Id_Cliente NUMERIC(10)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Verificar Fondos origen
        DECLARE @SaldoOrigen DECIMAL(10,2);
        SELECT @SaldoOrigen = Total_Cuenta 
        FROM Cliente 
        WHERE Id_Cliente = @Id_OrigenCli;

        IF @SaldoOrigen < @Monto
        BEGIN
            RAISERROR ('Saldo insuficiente en la cuenta de origen.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        --actualizacion de cuentas

		--retar origen
        UPDATE Cliente
        SET Total_Cuenta = Total_Cuenta - @Monto
        WHERE Id_Cliente = @Id_OrigenCli;

        -- sumar destino
        UPDATE Cliente
        SET Total_Cuenta = Total_Cuenta + @Monto
        WHERE Id_Cliente = @Id_Cliente;

        -- registrar transaccion
        INSERT INTO Transaccion (Fecha_Transaccion, Monto, Estado, Id_OrigenCli, Id_Cliente)
        VALUES (CAST(@Fecha_Transaccion AS DATETIME), @Monto, @Estado, @Id_OrigenCli, @Id_Cliente);
        COMMIT TRANSACTION;

        PRINT 'Transacción insertada correctamente.';
    END TRY
    BEGIN CATCH
        -- fallo
        ROLLBACK TRANSACTION;
        PRINT 'Error al insertar la transacción: ' + ERROR_MESSAGE();
    END CATCH
END;
GO

/*teste
EXEC RegistrarTransaccion 
    @Fecha_Transaccion = '2025-01-20 12:30:00',
    @Monto = 150.75,
    @Estado = 'Aprobada',
    @Id_OrigenCli = 1,
    @Id_Cliente = 2;
*/

--Validar Transaccion
Create PROCEDURE ValidarTransaccion
@id_transaccion numeric (10)
as
begin
	if(exists(select * from Transaccion where Id_Transaccion =@id_transaccion ))
		select Id_Transaccion,Estado from Transaccion where Id_Transaccion =@id_transaccion
	else 
		select '0'
end
/* teste
Exec ValidarTransaccion 2
*/






