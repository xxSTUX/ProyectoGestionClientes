--Crear clientes

SET IDENTITY_INSERT [dbo].[Clientes] ON 
GO
DECLARE @Id INT = 1;
DECLARE @Nombre NVARCHAR(100);
DECLARE @Eliminado BIT = 0;
WHILE @Id <= 20
BEGIN
    SET @Nombre = 'cliente' + CAST(@Id AS NVARCHAR(10));

    INSERT INTO [dbo].[Clientes] ([Id], [Nombre], [Eliminado]) 
    VALUES (@Id, @Nombre, @Eliminado);

    SET @Id = @Id + 1;
END;
GO
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO

--crear proyectos

GO
--DBCC CHECKIDENT ('Proyectos', RESEED, 0);
DECLARE @ClienteId INT = 1; -- ID del primer cliente
DECLARE @ProyectoId INT = 1; -- ID del primer proyecto
DECLARE @NumProyectos INT = 5; -- Número de proyectos por cliente

WHILE @ClienteId <= 20 -- Numero clientes
BEGIN
    WHILE @ProyectoId <= @ClienteId * @NumProyectos
    BEGIN
        INSERT INTO [dbo].[Proyectos] ([ClienteId], [Nombre], [Estado], [Tipo], [Eliminado])
        VALUES (@ClienteId, 'Proyecto' + CAST(@ProyectoId AS NVARCHAR(10)), 1, 'Proyecto', 0);
        
        SET @ProyectoId = @ProyectoId + 1;
    END;

    SET @ClienteId = @ClienteId + 1;
END;
GO

GO

--Crear puestos
SET IDENTITY_INSERT [dbo].[Puestos] ON;

DECLARE @Contador INT = 1;

WHILE @Contador <= 10
BEGIN
    INSERT INTO [dbo].[Puestos] ([Id], [Nombre], [Eliminado])
    VALUES (@Contador, CONCAT('Puesto ', @Contador), 0);
    
    SET @Contador = @Contador + 1;
END;

SET IDENTITY_INSERT [dbo].[Puestos] OFF;

GO

--Relacion puestos de proyectos
GO
DECLARE @ProyectoId INT = 1; -- ID del primer proyecto
DECLARE @PuestoId INT = 1; -- ID del primer puesto

WHILE @ProyectoId <= 100 -- Ajusta el límite según el número total de proyectos
BEGIN
    INSERT INTO [dbo].[PuestoProyecto] ([ProyectoId], [PuestoId])
    VALUES (@ProyectoId, @PuestoId);
    
    -- Incrementa el ID del puesto, asegurándose de reiniciarlo cuando supere el número total de puestos
    SET @PuestoId = CASE WHEN @PuestoId < 10 THEN @PuestoId + 1 ELSE 1 END;
    
    SET @ProyectoId = @ProyectoId + 1;
END;

--Relacion puestos a clientes
GO

DECLARE @ClienteId INT = 1; -- ID del primer cliente
DECLARE @NumClientes INT = 20; -- Número total de clientes
DECLARE @PuestoId INT = 1; -- ID del primer puesto

WHILE @ClienteId <= @NumClientes
BEGIN
    INSERT INTO [dbo].[PuestoCliente] ([ClienteId], [PuestoId])
    VALUES (@ClienteId, @PuestoId);
    
    -- Incrementa el ID del puesto, asegurándose de reiniciarlo cuando supere el número total de puestos
    SET @PuestoId = CASE WHEN @PuestoId < 10 THEN @PuestoId + 1 ELSE 1 END;
    
    SET @ClienteId = @ClienteId + 1;
END;


--Crear facturaciones
SET IDENTITY_INSERT [dbo].[Facturaciones] ON 
GO
DECLARE @FacturacionId INT = 1; -- ID de la primera facturación
DECLARE @NumFacturaciones INT = 10; -- Número total de facturaciones

WHILE @FacturacionId <= @NumFacturaciones
BEGIN
    INSERT INTO [dbo].[Facturaciones] ([Id], [Datos], [Eliminado])
    VALUES (@FacturacionId, 'Datos de facturación ' + CAST(@FacturacionId AS NVARCHAR(10)), 0);
    
    SET @FacturacionId = @FacturacionId + 1;
END;
GO
SET IDENTITY_INSERT [dbo].[Facturaciones] OFF
GO

--Relacion facturaciones a clientes
DECLARE @ClienteId INT = 1; -- ID del primer cliente
DECLARE @NumClientes INT = 20; -- Número total de clientes
DECLARE @FacturacionId INT = 1; -- ID de la primera facturación
DECLARE @NumFacturacionesPorCliente INT = 3; -- Número de facturaciones por cliente

WHILE @ClienteId <= @NumClientes
BEGIN
    DECLARE @Contador INT = 0;
    
    WHILE @Contador < @NumFacturacionesPorCliente
    BEGIN
        INSERT INTO [dbo].[FacturacionCliente] ([ClienteId], [FacturacionId])
        VALUES (@ClienteId, @FacturacionId);
        
        SET @Contador = @Contador + 1;
        -- Reiniciar el contador de FacturacionId a 1 si llega a 10 num max de faturaciones en BBDD
        IF @FacturacionId = 10
        BEGIN
            SET @FacturacionId = 1;
        END
        ELSE
        BEGIN
            SET @FacturacionId = @FacturacionId + 1;
        END
    END;
    
    SET @ClienteId = @ClienteId + 1;
END;
GO

--Relacion facturacions a proyectos
DECLARE @ProyectoId INT = 1; -- ID del primer proyecto
DECLARE @NumProyectos INT = 100; -- Número total de proyectos
DECLARE @FacturacionId INT = 1; -- ID de la primera facturación
DECLARE @NumFacturacionesPorProyecto INT = 3; -- Número de facturaciones por proyecto

WHILE @ProyectoId <= @NumProyectos
BEGIN
    DECLARE @Contador INT = 0;
    
    WHILE @Contador < @NumFacturacionesPorProyecto
    BEGIN
        INSERT INTO [dbo].[FacturacionProyecto] ([ProyectoId], [FacturacionId])
        VALUES (@ProyectoId, @FacturacionId);
        
        SET @Contador = @Contador + 1;
        
        -- Reiniciar el contador de FacturacionId a 1 si llega a 10 num max de faturaciones en BBDD
        IF @FacturacionId = 10
        BEGIN
            SET @FacturacionId = 1;
        END
        ELSE
        BEGIN
            SET @FacturacionId = @FacturacionId + 1;
        END
    END;
    
    SET @ProyectoId = @ProyectoId + 1;
END;


--Crear licitaciones
SET IDENTITY_INSERT [dbo].[Licitaciones] ON 
GO
DECLARE @LicitacionId INT = 1; -- ID de la primera licitación
DECLARE @NumLicitaciones INT = 10; -- Número total de licitaciones

WHILE @LicitacionId <= @NumLicitaciones
BEGIN
    INSERT INTO [dbo].[Licitaciones] ([Id], [Nombre], [Tipo], [Estado], [Eliminado])
    VALUES (@LicitacionId, 'Licitación ' + CAST(@LicitacionId AS NVARCHAR(10)), 'Tipo ' + CAST(@LicitacionId AS NVARCHAR(10)), @LicitacionId % 3 + 1, 0);
    
    SET @LicitacionId = @LicitacionId + 1;
END;
GO
SET IDENTITY_INSERT [dbo].[Licitaciones] OFF

--Relacion licitaciones a cliente


GO
DECLARE @ClienteId INT = 1; -- ID del primer cliente
DECLARE @NumClientes INT = 20; -- Número total de clientes
DECLARE @LicitacionId INT = 1; -- ID de la primera licitación
DECLARE @NumLicitacionesPorCliente INT = 3; -- Número de licitaciones por cliente

WHILE @ClienteId <= @NumClientes
BEGIN
    DECLARE @Contador INT = 0;
    
    WHILE @Contador < @NumLicitacionesPorCliente
    BEGIN
        INSERT INTO [dbo].[LicitacionCliente] ([ClienteId], [LicitacionId])
        VALUES (@ClienteId, @LicitacionId);
        
        SET @Contador = @Contador + 1;
        -- Reiniciar el contador de licitacionID a 1 si llega a 10 num max de licitaciones
        IF @LicitacionId = 10
        BEGIN
            SET @LicitacionId = 1;
        END
        ELSE
        BEGIN
            SET @LicitacionId = @LicitacionId + 1;
        END
    END;
    SET @ClienteId = @ClienteId + 1;
END;

GO

--Relacion licitaciones a proyectos
DECLARE @ProyectoId INT = 1; -- ID del primer proyecto
DECLARE @NumProyectos INT = 100; -- Número total de proyectos
DECLARE @LicitacionId INT = 1; -- ID de la primera licitación
DECLARE @NumLicitacionesPorProyecto INT = 3; -- Número de licitaciones por proyecto

WHILE @ProyectoId <= @NumProyectos
BEGIN
    DECLARE @Contador INT = 0;
    
    WHILE @Contador < @NumLicitacionesPorProyecto
    BEGIN
        INSERT INTO [dbo].[LicitacionProyecto] ([ProyectoId], [LicitacionId])
        VALUES (@ProyectoId, @LicitacionId);
        
        SET @Contador = @Contador + 1;
        -- Reiniciar el contador de licitacionID a 1 si llega a 10 num max de licitaciones
        IF @LicitacionId = 10
        BEGIN
            SET @LicitacionId = 1;
        END
        ELSE
        BEGIN
            SET @LicitacionId = @LicitacionId + 1;
        END
    END;
    
    SET @ProyectoId = @ProyectoId + 1;
END;



--Crear seguimientos
GO

GO
DECLARE @NumSeguimientos INT = 20; -- Número total de seguimientos a crear
DECLARE @Contador INT = 1;


DECLARE @TiposSeguimiento TABLE (Id INT, Nombre NVARCHAR(100));
INSERT INTO @TiposSeguimiento (Id, Nombre) VALUES (1, N'Proyecto'), (2, N'Cliente');

WHILE @Contador <= @NumSeguimientos
BEGIN
    --   tipo de seguimiento aleatorio
    DECLARE @TipoSeguimientoId INT = (SELECT Id FROM @TiposSeguimiento ORDER BY NEWID() OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY);
    
    --   nombre de seguimiento único
    DECLARE @NombreSeguimiento NVARCHAR(100) = CONCAT('Seguimiento ', @Contador);
    
    --   fecha aleatoria en los últimos 365 días
    DECLARE @FechaSeguimiento DATETIME = DATEADD(DAY, -CONVERT(INT, RAND() * 365), GETDATE());
    
    -- Insertamos el seguimiento
    INSERT INTO [dbo].[Seguimientos] ([Nombre], [Fecha], [Observaciones], [Tipo], [Eliminado])
    VALUES (@NombreSeguimiento, @FechaSeguimiento, 'Observaciones', (SELECT Nombre FROM @TiposSeguimiento WHERE Id = @TipoSeguimientoId), 0);
    
    SET @Contador = @Contador + 1;
END;
GO

GO



--Relacion seguimientos de clientes

DECLARE @ClienteId INT = 1; -- ID del primer cliente
DECLARE @SeguimientoId INT = 1; -- ID del primer seguimiento

WHILE @ClienteId <= 20 -- Ajusta el límite según el número total de clientes
BEGIN
    INSERT INTO [dbo].[SeguimientoCliente] ([ClienteId], [SeguimientoId])
    SELECT @ClienteId, Id
    FROM [dbo].[Seguimientos]
    WHERE [Tipo] = 'Cliente' AND [Eliminado] = 0 -- Filtrar solo seguimientos tipo "Cliente" no eliminados
    ORDER BY NEWID() -- Ordenar de forma aleatoria para asignar seguimientos aleatoriamente a los clientes
    
    SET @ClienteId = @ClienteId + 1;
END;



--Relación seguimientos de proyectos

GO
DECLARE @ProyectoId INT = 1; -- ID del primer proyecto
DECLARE @SeguimientoId INT = 1; -- ID del primer seguimiento

WHILE @ProyectoId <= 100 -- Ajusta el límite según el número total de proyectos
BEGIN
    INSERT INTO [dbo].[SeguimientoProyecto] ([ProyectoId], [SeguimientoId])
    SELECT @ProyectoId, Id
    FROM [dbo].[Seguimientos]
    WHERE [Tipo] = 'Proyecto'  -- Filtrar solo seguimientos tipo "Proyecto" 
    ORDER BY NEWID() -- Ordenar de forma aleatoria para asignar seguimientos aleatoriamente a los proyectos
    SET @ProyectoId = @ProyectoId + 1;
END;

GO