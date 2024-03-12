SET IDENTITY_INSERT [dbo].[Clientes] ON 
GO
INSERT [dbo].[Clientes] ([Id], [Nombre]) VALUES (1, N'TRACASA INSTRUMENTAL')
GO
INSERT [dbo].[Clientes] ([Id], [Nombre]) VALUES (2, N'GOBIERNO DE NAVARRA - DPTO. SISTEMAS')
GO
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[Proyectos] ON 
GO
INSERT [dbo].[Proyectos] ([Id], [ClienteId], [Nombre], [Estado], [Tipo]) VALUES (1, 1, N'Extr@ 2024', N'En curso', N'Proyecto')
GO
INSERT [dbo].[Proyectos] ([Id], [ClienteId], [Nombre], [Estado], [Tipo]) VALUES (2, 1, N'Extr@ 2023', N'Terminado', N'Proyecto')
GO
INSERT [dbo].[Proyectos] ([Id], [ClienteId], [Nombre], [Estado], [Tipo]) VALUES (3, 1, N'Extr@ 2022', N'Terminado', N'Proyecto')
GO
INSERT [dbo].[Proyectos] ([Id], [ClienteId], [Nombre], [Estado], [Tipo]) VALUES (4, 1, N'Justicia 2022', N'En curso', N'Proyecto')
GO
INSERT [dbo].[Proyectos] ([Id], [ClienteId], [Nombre], [Estado], [Tipo]) VALUES (5, 1, N'Hacienda 2022', N'En curso', N'Proyecto')
GO
INSERT [dbo].[Proyectos] ([Id], [ClienteId], [Nombre], [Estado], [Tipo]) VALUES (6, 1, N'Justicia 2020', N'Terminado', N'Proyecto')
GO
SET IDENTITY_INSERT [dbo].[Proyectos] OFF
GO
SET IDENTITY_INSERT [dbo].[Facturaciones] ON 
GO
INSERT [dbo].[Facturaciones] ([Id], [Datos]) VALUES (1, N'Datos de facturación')
GO
SET IDENTITY_INSERT [dbo].[Facturaciones] OFF
GO
SET IDENTITY_INSERT [dbo].[Licitaciones] ON 
GO
INSERT [dbo].[Licitaciones] ([Id], [Nombre], [Tipo]) VALUES (1, N'Renovación 2024 Extr@', N'GANADAS')
GO
INSERT [dbo].[Licitaciones] ([Id], [Nombre], [Tipo]) VALUES (2, N'Renovación 2023 Extr@', N'GANADAS')
GO
INSERT [dbo].[Licitaciones] ([Id], [Nombre], [Tipo]) VALUES (3, N'Carpeta ciudadana 2022', N'PERDIDAS')
GO
INSERT [dbo].[Licitaciones] ([Id], [Nombre], [Tipo]) VALUES (4, N'Renovación licencias 2024', N'EN ESTUDIO')
GO
INSERT [dbo].[Licitaciones] ([Id], [Nombre], [Tipo]) VALUES (5, N'Carpeta ciudadana 2022', N'PERDIDAS')
GO
INSERT [dbo].[Licitaciones] ([Id], [Nombre], [Tipo]) VALUES (6, N'Renovación licencias 2023', N'PERDIDAS')
GO
SET IDENTITY_INSERT [dbo].[Licitaciones] OFF
GO
INSERT [dbo].[LicitacionCliente] ([ClienteId], [LicitacionId]) VALUES (1, 1)
GO
INSERT [dbo].[LicitacionCliente] ([ClienteId], [LicitacionId]) VALUES (1, 2)
GO
INSERT [dbo].[LicitacionCliente] ([ClienteId], [LicitacionId]) VALUES (1, 3)
GO
INSERT [dbo].[LicitacionCliente] ([ClienteId], [LicitacionId]) VALUES (2, 4)
GO
INSERT [dbo].[LicitacionCliente] ([ClienteId], [LicitacionId]) VALUES (2, 5)
GO
INSERT [dbo].[LicitacionCliente] ([ClienteId], [LicitacionId]) VALUES (2, 6)
GO
SET IDENTITY_INSERT [dbo].[Puestos] ON 
GO
INSERT [dbo].[Puestos] ([Id], [Nombre]) VALUES (1, N'Desarrollador Junior BPM')
GO
INSERT [dbo].[Puestos] ([Id], [Nombre]) VALUES (2, N'Desarrollador Senior BPM')
GO
INSERT [dbo].[Puestos] ([Id], [Nombre]) VALUES (3, N'Analista desarrollador BPM')
GO
SET IDENTITY_INSERT [dbo].[Puestos] OFF
GO
SET IDENTITY_INSERT [dbo].[Seguimientos] ON 
GO
INSERT [dbo].[Seguimientos] ([Id], [Nombre], [Fecha], [Tipo]) VALUES (1, N'Reunión enero 2024', CAST(N'2024-01-10T00:00:00.0000000' AS DateTime2), N'Proyecto')
GO
INSERT [dbo].[Seguimientos] ([Id], [Nombre], [Fecha], [Tipo]) VALUES (2, N'Reunión diciembre 2023', CAST(N'2023-12-15T00:00:00.0000000' AS DateTime2), N'Proyecto')
GO
INSERT [dbo].[Seguimientos] ([Id], [Nombre], [Fecha], [Tipo]) VALUES (3, N'Reunión noviembre 2023', CAST(N'2023-11-01T00:00:00.0000000' AS DateTime2), N'Proyecto')
GO
INSERT [dbo].[Seguimientos] ([Id], [Nombre], [Fecha], [Tipo]) VALUES (4, N'Reunión noviembre 2023', CAST(N'2023-11-15T00:00:00.0000000' AS DateTime2), N'Proyecto')
GO
INSERT [dbo].[Seguimientos] ([Id], [Nombre], [Fecha], [Tipo]) VALUES (5, N'Reunión noviembre 2023', CAST(N'2023-11-28T00:00:00.0000000' AS DateTime2), N'Proyecto')
GO
INSERT [dbo].[Seguimientos] ([Id], [Nombre], [Fecha], [Tipo]) VALUES (6, N'Reunión febrero 2023', CAST(N'2023-02-22T00:00:00.0000000' AS DateTime2), N'Proyecto')
GO
INSERT [dbo].[Seguimientos] ([Id], [Nombre], [Fecha], [Tipo]) VALUES (7, N'Reunión marzo 2023', CAST(N'2023-03-21T00:00:00.0000000' AS DateTime2), N'Proyecto')
GO
INSERT [dbo].[Seguimientos] ([Id], [Nombre], [Fecha], [Tipo]) VALUES (8, N'Reunión abril 2023', CAST(N'2023-04-26T00:00:00.0000000' AS DateTime2), N'Proyecto')
GO
INSERT [dbo].[Seguimientos] ([Id], [Nombre], [Fecha], [Tipo]) VALUES (9, N'Reunión enero 2024', CAST(N'2024-01-11T00:00:00.0000000' AS DateTime2), N'Cliente')
GO
INSERT [dbo].[Seguimientos] ([Id], [Nombre], [Fecha], [Tipo]) VALUES (10, N'Reunión diciembre 2023', CAST(N'2023-12-16T00:00:00.0000000' AS DateTime2), N'Cliente')
GO
INSERT [dbo].[Seguimientos] ([Id], [Nombre], [Fecha], [Tipo]) VALUES (11, N'Reunión noviembre 2023', CAST(N'2023-11-02T00:00:00.0000000' AS DateTime2), N'Cliente')
GO
INSERT [dbo].[Seguimientos] ([Id], [Nombre], [Fecha], [Tipo]) VALUES (12, N'Reunión noviembre 2023', CAST(N'2023-11-17T00:00:00.0000000' AS DateTime2), N'Cliente')
GO
INSERT [dbo].[Seguimientos] ([Id], [Nombre], [Fecha], [Tipo]) VALUES (13, N'Reunión noviembre 2023', CAST(N'2023-11-29T00:00:00.0000000' AS DateTime2), N'Cliente')
GO
INSERT [dbo].[Seguimientos] ([Id], [Nombre], [Fecha], [Tipo]) VALUES (14, N'Reunión diciembre 2023', CAST(N'2023-12-06T00:00:00.0000000' AS DateTime2), N'Cliente')
GO
INSERT [dbo].[Seguimientos] ([Id], [Nombre], [Fecha], [Tipo]) VALUES (15, N'Reunión noviembre 2023', CAST(N'2023-11-22T00:00:00.0000000' AS DateTime2), N'Cliente')
GO
INSERT [dbo].[Seguimientos] ([Id], [Nombre], [Fecha], [Tipo]) VALUES (16, N'Reunión octubre 2023', CAST(N'2023-10-21T00:00:00.0000000' AS DateTime2), N'Cliente')
GO
INSERT [dbo].[Seguimientos] ([Id], [Nombre], [Fecha], [Tipo]) VALUES (17, N'Reunión diciembre 2023', CAST(N'2023-12-12T00:00:00.0000000' AS DateTime2), N'Cliente')
GO
SET IDENTITY_INSERT [dbo].[Seguimientos] OFF
GO
INSERT [dbo].[SeguimientoCliente] ([ClienteId], [SeguimientoId]) VALUES (1, 9)
GO
INSERT [dbo].[SeguimientoCliente] ([ClienteId], [SeguimientoId]) VALUES (1, 10)
GO
INSERT [dbo].[SeguimientoCliente] ([ClienteId], [SeguimientoId]) VALUES (1, 11)
GO
INSERT [dbo].[SeguimientoCliente] ([ClienteId], [SeguimientoId]) VALUES (1, 12)
GO
INSERT [dbo].[SeguimientoCliente] ([ClienteId], [SeguimientoId]) VALUES (1, 13)
GO
INSERT [dbo].[SeguimientoCliente] ([ClienteId], [SeguimientoId]) VALUES (1, 14)
GO
INSERT [dbo].[SeguimientoCliente] ([ClienteId], [SeguimientoId]) VALUES (1, 15)
GO
INSERT [dbo].[SeguimientoCliente] ([ClienteId], [SeguimientoId]) VALUES (1, 16)
GO
INSERT [dbo].[FacturacionProyecto] ([ProyectoId], [FacturacionId]) VALUES (1, 1)
GO
INSERT [dbo].[PuestoProyecto] ([ProyectoId], [PuestoId]) VALUES (1, 1)
GO
INSERT [dbo].[PuestoProyecto] ([ProyectoId], [PuestoId]) VALUES (1, 2)
GO
INSERT [dbo].[PuestoProyecto] ([ProyectoId], [PuestoId]) VALUES (1, 3)
GO
INSERT [dbo].[SeguimientoProyecto] ([ProyectoId], [SeguimientoId]) VALUES (1, 1)
GO
INSERT [dbo].[SeguimientoProyecto] ([ProyectoId], [SeguimientoId]) VALUES (1, 2)
GO
INSERT [dbo].[SeguimientoProyecto] ([ProyectoId], [SeguimientoId]) VALUES (1, 3)
GO
INSERT [dbo].[SeguimientoProyecto] ([ProyectoId], [SeguimientoId]) VALUES (1, 4)
GO
INSERT [dbo].[SeguimientoProyecto] ([ProyectoId], [SeguimientoId]) VALUES (1, 5)
GO
INSERT [dbo].[SeguimientoProyecto] ([ProyectoId], [SeguimientoId]) VALUES (1, 6)
GO
INSERT [dbo].[SeguimientoProyecto] ([ProyectoId], [SeguimientoId]) VALUES (1, 7)
GO
INSERT [dbo].[SeguimientoProyecto] ([ProyectoId], [SeguimientoId]) VALUES (1, 8)
GO