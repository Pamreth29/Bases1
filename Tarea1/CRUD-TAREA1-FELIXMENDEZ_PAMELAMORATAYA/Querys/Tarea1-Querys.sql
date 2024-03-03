CREATE DATABASE Tarea1;

Create table EMPLEADO(
	id INT IDENTITY (1, 1) PRIMARY KEY
	, Nombre VARCHAR(128) NOT NULL
	, Salario MONEY NOT NULL 
)
--*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
CREATE PROCEDURE SP_Listar
AS
BEGIN
	SELECT * FROM EMPLEADO
END
--*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
CREATE PROCEDURE SP_Obtener (@id INT)
AS
BEGIN
	SELECT * FROM EMPLEADO WHERE id = @id
END
--*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
CREATE PROCEDURE SP_Guardar(
@Nombre VARCHAR(128),
@Salario MONEY
)
AS
BEGIN
	INSERT INTO EMPLEADO(Nombre, Salario) VALUES (@Nombre, @Salario)
END
--*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
CREATE PROCEDURE SP_Modificar(
@id INT,
@Nombre VARCHAR(128),
@Salario MONEY
)
AS
BEGIN
	UPDATE EMPLEADO SET Nombre = @Nombre, Salario = @Salario WHERE id = @id
END
--*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
CREATE PROCEDURE SP_Eliminar(@id INT)
AS
BEGIN
	DELETE FROM EMPLEADO WHERE id = @id
END

SELECT * FROM EMPLEADO