/****** Object:  StoredProcedure [dbo].[SPMostrarListaEmpleados]    Script Date: 2/28/2024 12:54:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SPMostrarListaEmpleados]
AS
BEGIN 
SELECT [id] 'ID'
      ,[Nombre] 'Nombre'
      ,[Salario] 'Salario'
  FROM [dbo].[Empleado]
END;
