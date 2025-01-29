CREATE DATABASE HAPPY_QUITO
GO
USE HAPPY_QUITO
GO
CREATE TABLE Metodo_Pago (
                Id_MetodoPago INT IDENTITY NOT NULL,
                Metodo VARCHAR(20) NOT NULL,
                Comision MONEY NOT NULL,
                CONSTRAINT Metodo_Pago_pk PRIMARY KEY (Id_MetodoPago)
)

CREATE TABLE Propietario (
                Id_Propietario INT IDENTITY NOT NULL,
                Nombres VARCHAR(50) NOT NULL,
                Direccion VARCHAR(120) NOT NULL,
                Cedula NUMERIC(10) NOT NULL,
                Apellidos VARCHAR(50) NOT NULL,
                Correo VARCHAR(25) NOT NULL,
                CONSTRAINT Propietario_pk PRIMARY KEY (Id_Propietario)
)

CREATE TABLE Establecimiento (
                Id_Establecimiento INT IDENTITY NOT NULL,
                Nombre_Establecimiento VARCHAR(50) NOT NULL,
                Direccion_Establecimiento VARCHAR(120) NOT NULL,
                Correo VARCHAR(25) NOT NULL,
                Tipo_Establecimiento VARCHAR(20) NOT NULL,
                Id_Propietario INT NOT NULL,
                CONSTRAINT Establecimiento_pk PRIMARY KEY (Id_Establecimiento)
)

CREATE TABLE Id_Servicio (
                Id_Serivcio INT IDENTITY NOT NULL,
                Descripcion VARCHAR NOT NULL,
                Costo MONEY NOT NULL,
                Id_Establecimiento INT NOT NULL,
                CONSTRAINT Id_Servicio_pk PRIMARY KEY (Id_Serivcio)
)

CREATE TABLE Id_Paquete (
                Id_Paquete INT IDENTITY NOT NULL,
                Descripcion VARCHAR NOT NULL,
                Id_Serivcio INT NOT NULL,
                CONSTRAINT Id_Paquete_pk PRIMARY KEY (Id_Paquete)
)

CREATE TABLE Usuario (
                Id_Usuario INT IDENTITY NOT NULL,
                Cedula NUMERIC(10) NOT NULL,
                Nombres VARCHAR(50) NOT NULL,
                Apellidos VARCHAR(50) NOT NULL,
                Correo VARCHAR(25) NOT NULL,
                Direccion VARCHAR(120) NOT NULL,
                Contrasea VARCHAR(25) NOT NULL,
                CONSTRAINT Usuario_pk PRIMARY KEY (Id_Usuario)
)

CREATE TABLE Venta (
                Id_Venta INT IDENTITY NOT NULL,
                Id_Paquete INT NOT NULL,
                Id_Usuario INT NOT NULL,
                Id_MetodoPago INT NOT NULL,
                CONSTRAINT Venta_pk PRIMARY KEY (Id_Venta)
)

CREATE TABLE Factura (
                Id_Factura INT IDENTITY NOT NULL,
				Id_Venta INT NOT NULL,
                Fecha_Venta DATETIME NOT NULL,
                SubTotal MONEY NOT NULL,
                Total MONEY NOT NULL,
                CONSTRAINT Factura_pk PRIMARY KEY (Id_Factura)
)

ALTER TABLE Venta ADD CONSTRAINT Metodo_Pago_Venta_fk
FOREIGN KEY (Id_MetodoPago)
REFERENCES Metodo_Pago (Id_MetodoPago)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE Establecimiento ADD CONSTRAINT Propietario_Establecimiento_fk
FOREIGN KEY (Id_Propietario)
REFERENCES Propietario (Id_Propietario)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE Id_Servicio ADD CONSTRAINT Establecimiento_Id_Servicio_fk
FOREIGN KEY (Id_Establecimiento)
REFERENCES Establecimiento (Id_Establecimiento)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE Id_Paquete ADD CONSTRAINT Id_Servicio_Id_Paquete_fk
FOREIGN KEY (Id_Serivcio)
REFERENCES Id_Servicio (Id_Serivcio)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE Venta ADD CONSTRAINT Id_Paquete_Venta_fk
FOREIGN KEY (Id_Paquete)
REFERENCES Id_Paquete (Id_Paquete)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE Venta ADD CONSTRAINT Usuario_Venta_fk
FOREIGN KEY (Id_Usuario)
REFERENCES Usuario (Id_Usuario)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE Factura ADD CONSTRAINT Venta_Factura_fk
FOREIGN KEY (Id_Venta)
REFERENCES Venta (Id_Venta)
ON DELETE NO ACTION
ON UPDATE NO ACTION