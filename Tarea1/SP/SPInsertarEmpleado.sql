/****** Object:  StoredProcedure [dbo].[SPInsertEmpleado]    Script Date: 2/28/2024 12:34:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SPInsertEmpleado]
	@Nombre VARCHAR(64),
	@Salario MONEY

AS
BEGIN

INSERT INTO Empleado (Nombre,Salario) 
VALUES(@Nombre,@Salario);

END;

