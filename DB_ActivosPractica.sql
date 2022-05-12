--Base de datos
--USE master
--GO
--CREATE DATABASE DB_ActivosPractica
--GO
USE DB_ActivosPractica
GO
--------------------------------------------------------------------------------------------------------------------
--Tablas
CREATE TABLE CategoriaUsuario(
IdCategoriaUsuario INT IDENTITY NOT NULL,
Descripcion NVARCHAR(500)
);
GO
CREATE TABLE Usuario(
IdUsuario INT IDENTITY NOT NULL,
IdCategoriaUsuario INT NOT NULL,
Cedula NVARCHAR(200),
Nombre NVARCHAR(500),
PrimerApellido NVARCHAR(500),
SegundoApellido NVARCHAR(500),
Telefono NVARCHAR(200),
Correo NVARCHAR(500),
Direccion NVARCHAR(MAX),
Contrasenna NVARCHAR(MAX) 
);
GO
CREATE TABLE Vendedor(
IdVendedor INT IDENTITY NOT NULL,
CedulaJuridica NVARCHAR(200),
Nombre NVARCHAR(500),
PrimerApellido NVARCHAR(500),
SegundoApellido NVARCHAR(500),
Telefono NVARCHAR(200),
Correo NVARCHAR(500),
Direccion NVARCHAR(MAX),
);
GO
CREATE TABLE Marca(
IdMarca INT IDENTITY NOT NULL,
Descripcion NVARCHAR(500)
);
GO
CREATE TABLE Asegurador(
IdAsegurador INT IDENTITY NOT NULL,
Descripcion NVARCHAR(500)
);
GO
CREATE TABLE CategoriaActivo(
IdCategoriaActivo INT IDENTITY NOT NULL,
Descripcion NVARCHAR(500)
);
GO
CREATE TABLE Activo(
IdActivo INT IDENTITY NOT NULL,
IdUsuario INT NOT NULL,
IdVendedor INT NOT NULL,
IdCategoriaActivo INT NOT NULL,
IdAsegurador INT NOT NULL,
IdMarca INT NOT NULL,
NumeroSerie NVARCHAR(200),
Modelo NVARCHAR(500),
Estado NVARCHAR(500) NOT NULL,
Descripcion NVARCHAR(500),
ValorActual MONEY NOT NULL,
CostoColones MONEY NOT NULL,
CostoDolares MONEY NOT NULL,
FechaCompra DATETIME NOT NULL,
VencimientoGarantia DATETIME NOT NULL,
VencimientoSeguro DATETIME NOT NULL,
ImgActivo VARBINARY(MAX) NOT NULL,
ImgFactura VARBINARY(MAX) NOT NULL,
);
GO
CREATE TABLE HistoricoDepreciacion(
IdHistoricoDepreciacion INT IDENTITY NOT NULL,
IdActivo INT NOT NULL,
ValorDepreciacion MONEY NOT NULL,
RegistroDepreciacion DATETIME 
);
GO
----------------------------------------------------------------------------------------------------------------------
--PK
ALTER TABLE CategoriaUsuario ADD CONSTRAINT PK_CategoriaUsuario PRIMARY KEY (IdCategoriaUsuario);
ALTER TABLE Usuario ADD CONSTRAINT PK_Usuario PRIMARY KEY (IdUsuario);
ALTER TABLE Vendedor ADD CONSTRAINT PK_Vendedor PRIMARY KEY (IdVendedor);
ALTER TABLE Marca ADD CONSTRAINT PK_Marca PRIMARY KEY (IdMarca);
ALTER TABLE Asegurador ADD CONSTRAINT PK_Asegurador PRIMARY KEY (IdAsegurador);
ALTER TABLE CategoriaActivo ADD CONSTRAINT PK_CategoriaActivo PRIMARY KEY (IdCategoriaActivo);
ALTER TABLE Activo ADD CONSTRAINT PK_Activo PRIMARY KEY (IdActivo);
ALTER TABLE HistoricoDepreciacion ADD CONSTRAINT PK_HistoricoDepreciacion PRIMARY KEY (IdHistoricoDepreciacion);
GO
----------------------------------------------------------------------------------------------------------------------
--FK
ALTER TABLE Usuario ADD CONSTRAINT FK_Usuario_CategoriaUsuario FOREIGN  KEY (IdCategoriaUsuario) REFERENCES CategoriaUsuario(IdCategoriaUsuario); 
ALTER TABLE Activo ADD CONSTRAINT FK_Activo_Usuario FOREIGN  KEY (IdUsuario) REFERENCES Usuario(IdUsuario); 
ALTER TABLE Activo ADD CONSTRAINT FK_Activo_Vendedor FOREIGN  KEY (IdVendedor) REFERENCES Vendedor(IdVendedor); 
ALTER TABLE Activo ADD CONSTRAINT FK_Activo_Marca FOREIGN  KEY (IdMarca) REFERENCES Marca(IdMarca); 
ALTER TABLE Activo ADD CONSTRAINT FK_Activo_Asegurador FOREIGN  KEY (IdAsegurador) REFERENCES Asegurador(IdAsegurador);
ALTER TABLE Activo ADD CONSTRAINT FK_Activo_CategoriaActivo FOREIGN  KEY (IdCategoriaActivo) REFERENCES CategoriaActivo(IdCategoriaActivo);
ALTER TABLE HistoricoDepreciacion ADD CONSTRAINT FK_HistoricoDepreciacion_Activo FOREIGN  KEY (IdActivo) REFERENCES Activo(IdActivo);
GO
----------------------------------------------------------------------------------------------------------------------
--Stored Procedures

--CategoriaUsuario

--Insertar CategoriaUsuario
CREATE PROCEDURE spInsertCategoriaUsuario
(@Descripcion NVARCHAR(500))
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					INSERT INTO CategoriaUsuario(Descripcion)
					VALUES (@Descripcion);
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO

--Actualizar CategoriaUsuario
CREATE PROCEDURE spUpdateCategoriaUsuario
(@IdCategoriaUsuario INT , @Descripcion NVARCHAR(500))
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					UPDATE CategoriaUsuario
					SET Descripcion = @Descripcion
					WHERE (IdCategoriaUsuario = @IdCategoriaUsuario) 	
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO

--Eliminar CategoriaUsuario
CREATE PROCEDURE spDeleteCategoriaUsuario
(@IdCategoriaUsuario INT)
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					DELETE  FROM CategoriaUsuario
					WHERE (IdCategoriaUsuario = @IdCategoriaUsuario) 	
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
--Obtener Todos CategoriaUsuario
CREATE PROCEDURE spGetAllCategoriaUsuario
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					SELECT IdCategoriaUsuario, Descripcion 
					FROM CategoriaUsuario
					ORDER BY IdCategoriaUsuario
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
--Obtener CategoriaUsuario Por ID
CREATE PROCEDURE spGetCategoriaUsuarioById
(@IdCategoriaUsuario INT)
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					SELECT IdCategoriaUsuario, Descripcion 
					FROM CategoriaUsuario
					WHERE (IdCategoriaUsuario = @IdCategoriaUsuario) 
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
----------------------------------------------------------------------------------------------------------------------
--Usuario

--Insertar Usuario
ALTER PROCEDURE spInsertUsuario
(@IdCategoriaUsuario INT,@Cedula NVARCHAR(200),@Nombre NVARCHAR(500),@PrimerApellido NVARCHAR(500),@SegundoApellido NVARCHAR(500),@Telefono NVARCHAR(200),@Correo NVARCHAR(500),@Direccion NVARCHAR(MAX),@Contrasenna NVARCHAR(MAX) )
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					INSERT INTO Usuario(IdCategoriaUsuario, Cedula, Nombre, PrimerApellido, SegundoApellido, Telefono, Correo, Direccion, Contrasenna)
					VALUES (@IdCategoriaUsuario, @Cedula, @Nombre,@PrimerApellido,@SegundoApellido, @Telefono,@Correo,@Direccion,@Contrasenna);
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
--Actualizar Usuario
CREATE PROCEDURE spUpdateUsuario
(@IdUsuario INT,@IdCategoriaUsuario INT,@Cedula NVARCHAR(200),@Nombre NVARCHAR(500),@PrimerApellido NVARCHAR(500),@SegundoApellido NVARCHAR(500),@Telefono NVARCHAR(200),@Correo NVARCHAR(500),@Direccion NVARCHAR(MAX))
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					UPDATE Usuario
					SET IdCategoriaUsuario = @IdCategoriaUsuario,
					Cedula = @Cedula,
					Nombre = @Nombre,
					PrimerApellido = @PrimerApellido,
					SegundoApellido = @SegundoApellido,
					Telefono = @Telefono,
					Correo = @Correo,
					Direccion = @Direccion
					WHERE (IdUsuario = @IdUsuario) 	
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
--Actualizar Contrasenna Usuario
CREATE PROCEDURE spUpdatePasswordUsuario
(@IdUsuario INT,@Cedula NVARCHAR(200),@Contrasenna NVARCHAR(MAX))
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					UPDATE Usuario
					SET Contrasenna = @Contrasenna
					WHERE (IdUsuario = @IdUsuario AND Cedula = @Cedula) 	
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
--Eliminar Usuario
CREATE PROCEDURE spDeleteUsuario
(@IdUsuario INT)
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					DELETE  FROM Usuario
					WHERE (IdUsuario = @IdUsuario) 	
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
--Obtener Todos Usuario
CREATE PROCEDURE spGetAllUsuario
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					SELECT IdUsuario, IdCategoriaUsuario, Cedula, Nombre, PrimerApellido, SegundoApellido,Telefono, Correo, Direccion 
					FROM Usuario
					ORDER BY Cedula
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO

--Obtener Usuario Por ID
CREATE PROCEDURE spGetUsuarioById
(@IdUsuario INT)
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					SELECT IdUsuario, IdCategoriaUsuario, Cedula, Nombre, PrimerApellido, SegundoApellido,Telefono, Correo, Direccion 
					FROM Usuario
					WHERE (IdUsuario = @IdUsuario) 
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
--Obtener Usuario Por Cedula
CREATE PROCEDURE spGetUsuarioByCedula
(@Cedula NVARCHAR(200))
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					SELECT IdUsuario, IdCategoriaUsuario, Cedula, Nombre, PrimerApellido, SegundoApellido,Telefono, Correo, Direccion 
					FROM Usuario
					WHERE (Cedula = @Cedula) 
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
----------------------------------------------------------------------------------------------------------------------
--Vendedor
--Insertar Vendedor
CREATE PROCEDURE spInsertVendedor
(@CedulaJuridica NVARCHAR(200),@Nombre NVARCHAR(500),@PrimerApellido NVARCHAR(500),@SegundoApellido NVARCHAR(500),@Telefono NVARCHAR(200),@Correo NVARCHAR(500),@Direccion NVARCHAR(MAX))
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					INSERT INTO Vendedor(IdVendedor,CedulaJuridica, Nombre, PrimerApellido, SegundoApellido, Telefono, Correo, Direccion)
					VALUES (@CedulaJuridica, @Nombre,@PrimerApellido,@SegundoApellido, @Telefono,@Correo,@Direccion,@Direccion);
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
--Actualizar Vendedor
CREATE PROCEDURE spUpdateVendedor
(@IdVendedor INT, @CedulaJuridica NVARCHAR(200),@Nombre NVARCHAR(500),@PrimerApellido NVARCHAR(500),@SegundoApellido NVARCHAR(500),@Telefono NVARCHAR(200),@Correo NVARCHAR(500),@Direccion NVARCHAR(MAX))
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					UPDATE Vendedor
					SET CedulaJuridica = @CedulaJuridica,
					Nombre = @Nombre,
					PrimerApellido = @PrimerApellido,
					SegundoApellido = @SegundoApellido,
					Telefono = @Telefono,
					Correo = @Correo,
					Direccion = @Direccion
					WHERE (IdVendedor = @IdVendedor) 	
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
--Eliminar Vendedor
CREATE PROCEDURE spDeleteVendedor
(@IdVendedor INT)
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					DELETE  FROM Vendedor
					WHERE (IdVendedor = @IdVendedor) 	
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
--Obtener Todos Vendedor
CREATE PROCEDURE spGetAllVendedor
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					SELECT IdVendedor, CedulaJuridica, Nombre, PrimerApellido, SegundoApellido,Telefono, Correo, Direccion 
					FROM Vendedor
					ORDER BY CedulaJuridica
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
--Obtener Vendedor Por ID
CREATE PROCEDURE spGetVendedorById
(@IdVendedor INT)
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					SELECT IdVendedor, CedulaJuridica, Nombre, PrimerApellido, SegundoApellido,Telefono, Correo, Direccion 
					FROM Vendedor
					WHERE (IdVendedor = @IdVendedor) 
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
--Obtener Vendedor Por CedulaJuridica
CREATE PROCEDURE spGetUsuarioByCedulaJuridica
(@CedulaJuridica NVARCHAR(200))
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					SELECT IdVendedor, CedulaJuridica, Nombre, PrimerApellido, SegundoApellido,Telefono, Correo, Direccion 
					FROM Vendedor
					WHERE (CedulaJuridica = @CedulaJuridica) 
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
----------------------------------------------------------------------------------------------------------------------
--Marca
--Insertar Marca
CREATE PROCEDURE spInsertMarca
(@Descripcion NVARCHAR(500))
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					INSERT INTO Marca(Descripcion)
					VALUES (@Descripcion);
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
--Actualizar Marca
CREATE PROCEDURE spUpdateMarca
(@IdMarca INT , @Descripcion NVARCHAR(500))
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					UPDATE Marca
					SET Descripcion = @Descripcion
					WHERE (IdMarca = @IdMarca) 	
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
--Eliminar Marca
CREATE PROCEDURE spDeleteMarca
(@IdMarca INT)
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					DELETE  FROM Marca
					WHERE (IdMarca = @IdMarca) 	
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
--Obtener Todos Marca
CREATE PROCEDURE spGetAllMarca
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					SELECT IdMarca, Descripcion 
					FROM Marca
					ORDER BY IdMarca
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
--Obtener Marca Por ID
CREATE PROCEDURE spGetMarcaById
(@IdMarca INT)
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					SELECT IdMarca, Descripcion 
					FROM Marca
					WHERE (IdMarca = @IdMarca) 
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
----------------------------------------------------------------------------------------------------------------------
--Asegurador
--Insertar Asegurador
CREATE PROCEDURE spInsertAsegurador
(@Descripcion NVARCHAR(500))
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					INSERT INTO Asegurador(Descripcion)
					VALUES (@Descripcion);
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
--Actualizar Asegurador
CREATE PROCEDURE spUpdateAsegurador
(@IdAsegurador INT , @Descripcion NVARCHAR(500))
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					UPDATE Asegurador
					SET Descripcion = @Descripcion
					WHERE (IdAsegurador = @IdAsegurador) 	
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
--Eliminar Marca
CREATE PROCEDURE spDeleteAsegurador
(@IdAsegurador INT)
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					DELETE  FROM Asegurador
					WHERE (IdAsegurador = @IdAsegurador) 	
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
--Obtener Todos Marca
CREATE PROCEDURE spGetAllAsegurador
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					SELECT IdAsegurador, Descripcion 
					FROM Asegurador
					ORDER BY IdAsegurador
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
--Obtener Asegurador Por ID
CREATE PROCEDURE spGetAseguradorById
(@IdAsegurador INT)
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					SELECT IdAsegurador, Descripcion 
					FROM Asegurador
					WHERE (IdAsegurador = @IdAsegurador) 
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
----------------------------------------------------------------------------------------------------------------------
--CategoriaActivo

--Insertar CategoriaActivo
CREATE PROCEDURE spInsertCategoriaActivo
(@Descripcion NVARCHAR(500))
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					INSERT INTO CategoriaActivo(Descripcion)
					VALUES (@Descripcion);
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO

--Actualizar CategoriaActivo
CREATE PROCEDURE spUpdateCategoriaActivo
(@IdCategoriaActivo INT , @Descripcion NVARCHAR(500))
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					UPDATE CategoriaActivo
					SET Descripcion = @Descripcion
					WHERE (IdCategoriaActivo = @IdCategoriaActivo) 	
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO

--Eliminar CategoriaActivo
CREATE PROCEDURE spDeleteCategoriaActivo
(@IdCategoriaActivo INT)
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					DELETE  FROM CategoriaActivo
					WHERE (IdCategoriaActivo = @IdCategoriaActivo) 	
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
--Obtener Todos CategoriaActivo
CREATE PROCEDURE spGetAllCategoriaActivo
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					SELECT IdCategoriaActivo, Descripcion 
					FROM CategoriaActivo
					ORDER BY IdCategoriaActivo
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
--Obtener CategoriaActivo Por ID
CREATE PROCEDURE spGetCategoriaActivoById
(@IdCategoriaActivo INT)
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					SELECT IdCategoriaActivo, Descripcion 
					FROM CategoriaActivo
					WHERE (IdCategoriaActivo = @IdCategoriaActivo) 
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
----------------------------------------------------------------------------------------------------------------------
--Activo
--Insertar Activo
CREATE PROCEDURE spInsertActivo
(@IdUsuario INT,@IdVendedor INT,@IdCategoriaActivo INT,@IdAsegurador INT,@IdMarca INT,@NumeroSerie NVARCHAR(200),@Modelo NVARCHAR(500),@Estado NVARCHAR(500),@Descripcion NVARCHAR(500),@ValorActual MONEY,@CostoColones MONEY,@CostoDolares MONEY,@FechaCompra DATETIME,@VencimientoGarantia DATETIME,@VencimientoSeguro DATETIME,@ImgActivo VARBINARY(MAX),@ImgFactura VARBINARY(MAX))
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					INSERT INTO Activo(IdUsuario,IdVendedor,IdCategoriaActivo,IdAsegurador,IdMarca,NumeroSerie,Modelo,Estado,Descripcion,ValorActual,CostoColones,CostoDolares,FechaCompra,VencimientoGarantia,VencimientoSeguro,ImgActivo,ImgFactura)
					VALUES (@IdUsuario,@IdVendedor,@IdCategoriaActivo,@IdAsegurador,@IdMarca,@NumeroSerie,@Modelo,@Estado,@Descripcion,@ValorActual,@CostoColones,@CostoDolares,@FechaCompra,@VencimientoGarantia,@VencimientoSeguro,@ImgActivo,@ImgFactura);
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
--Actualizar Activo
CREATE PROCEDURE spUpdateActivo
(@IdActivo INT ,@IdUsuario INT,@IdVendedor INT,@IdCategoriaActivo INT,@IdAsegurador INT,@IdMarca INT,@NumeroSerie NVARCHAR(200),@Modelo NVARCHAR(500),@Estado NVARCHAR(500),@Descripcion NVARCHAR(500),@ValorActual MONEY,@CostoColones MONEY,@CostoDolares MONEY,@FechaCompra DATETIME,@VencimientoGarantia DATETIME,@VencimientoSeguro DATETIME,@ImgActivo VARBINARY(MAX),@ImgFactura VARBINARY(MAX))
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					UPDATE Activo
					SET IdUsuario = @IdUsuario,
					IdVendedor = @IdVendedor,
					IdCategoriaActivo = @IdCategoriaActivo,
					IdAsegurador = @IdAsegurador,
					IdMarca = @IdMarca,
					NumeroSerie = @NumeroSerie,
					Modelo = @Modelo,
					Estado = @Estado,
					Descripcion = @Descripcion,
					ValorActual = @ValorActual,
					CostoColones = @CostoColones,
					CostoDolares = @CostoDolares,
					FechaCompra = @FechaCompra,
					VencimientoGarantia = @VencimientoGarantia,
					VencimientoSeguro = @VencimientoSeguro,
					ImgActivo = @ImgActivo,
					ImgFactura = @ImgFactura
					WHERE (IdActivo = @IdActivo) 	
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
--Eliminar Activo
CREATE PROCEDURE spDeleteActivo
(@IdActivo INT)
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					DELETE  FROM Activo
					WHERE (IdActivo = @IdActivo) 	
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
--Obtener Todos Activo
CREATE PROCEDURE spGetAllActivo
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					SELECT IdActivo,IdUsuario,IdVendedor,IdCategoriaActivo,IdAsegurador,IdMarca,NumeroSerie,Modelo,Estado,Descripcion,ValorActual,CostoColones,CostoDolares,FechaCompra,VencimientoGarantia,VencimientoSeguro,ImgActivo,ImgFactura
					FROM Activo
					ORDER BY FechaCompra DESC
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
--Obtener Activo Por ID
CREATE PROCEDURE spGetActivoById
(@IdActivo INT)
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					SELECT IdActivo,IdUsuario,IdVendedor,IdCategoriaActivo,IdAsegurador,IdMarca,NumeroSerie,Modelo,Estado,Descripcion,ValorActual,CostoColones,CostoDolares,FechaCompra,VencimientoGarantia,VencimientoSeguro,ImgActivo,ImgFactura 
					FROM Activo
					WHERE (IdActivo = @IdActivo) 
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
--Obtener Activo Por IdCategoriaActivo
CREATE PROCEDURE spGetActivoByIdCategoriaActivo
(@IdCategoriaActivo INT)
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					SELECT IdActivo,IdUsuario,IdVendedor,IdCategoriaActivo,IdAsegurador,IdMarca,NumeroSerie,Modelo,Estado,Descripcion,ValorActual,CostoColones,CostoDolares,FechaCompra,VencimientoGarantia,VencimientoSeguro,ImgActivo,ImgFactura 
					FROM Activo
					WHERE (IdCategoriaActivo = @IdCategoriaActivo)
					ORDER BY FechaCompra DESC 
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
--Obtener Activo Por IdMarca
CREATE PROCEDURE spGetActivoByIdMarca
(@IdMarca INT)
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					SELECT IdActivo,IdUsuario,IdVendedor,IdCategoriaActivo,IdAsegurador,IdMarca,NumeroSerie,Modelo,Estado,Descripcion,ValorActual,CostoColones,CostoDolares,FechaCompra,VencimientoGarantia,VencimientoSeguro,ImgActivo,ImgFactura 
					FROM Activo
					WHERE (IdMarca = @IdMarca)
					ORDER BY FechaCompra DESC 
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
----------------------------------------------------------------------------------------------------------------------
--HistoricoDeprecacion
--Insertar Activo
CREATE PROCEDURE spInsertHistoricoDeprecacion
(@IdActivo INT,@ValorDepreciacion MONEY,@RegistroDepreciacion DATETIME) 
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					INSERT INTO HistoricoDepreciacion(IdActivo,ValorDepreciacion,RegistroDepreciacion)
					VALUES (@IdActivo,@ValorDepreciacion,@RegistroDepreciacion);
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
--Obtener Todos HistoricoDeprecacion
CREATE PROCEDURE spGetAllHistoricoDeprecacion
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					SELECT IdHistoricoDepreciacion,IdActivo,ValorDepreciacion,RegistroDepreciacion
					FROM HistoricoDepreciacion
					ORDER BY RegistroDepreciacion DESC
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
--Obtener HistoricoDeprecacion Por ID
CREATE PROCEDURE spGetHistoricoDeprecacionById
(@IdHistoricoDeprecacion INT)
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					SELECT IdHistoricoDepreciacion,IdActivo,ValorDepreciacion,RegistroDepreciacion 
					FROM HistoricoDepreciacion
					WHERE (IdHistoricoDepreciacion = @IdHistoricoDeprecacion) 
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
--Obtener HistoricoDeprecacion Por IdActivo
CREATE PROCEDURE spGetHistoricoDeprecacionByIdActivo
(@IdActivo INT)
AS
BEGIN
	SET NOCOUNT ON;
		BEGIN TRAN
			BEGIN TRY 
					SELECT IdHistoricoDepreciacion,IdActivo,ValorDepreciacion,RegistroDepreciacion 
					FROM HistoricoDepreciacion
					WHERE (IdActivo = @IdActivo) 
				COMMIT TRANSACTION
			END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO




