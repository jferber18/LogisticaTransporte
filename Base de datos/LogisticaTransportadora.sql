USE [master]
GO
/****** Object:  Database [LogisticaTransportadora]    Script Date: 24/08/2023 15:37:31 ******/
CREATE DATABASE [LogisticaTransportadora]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LogisticaTransportadora', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\LogisticaTransportadora.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LogisticaTransportadora_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\LogisticaTransportadora_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [LogisticaTransportadora] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LogisticaTransportadora].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LogisticaTransportadora] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LogisticaTransportadora] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LogisticaTransportadora] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LogisticaTransportadora] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LogisticaTransportadora] SET ARITHABORT OFF 
GO
ALTER DATABASE [LogisticaTransportadora] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LogisticaTransportadora] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LogisticaTransportadora] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LogisticaTransportadora] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LogisticaTransportadora] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LogisticaTransportadora] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LogisticaTransportadora] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LogisticaTransportadora] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LogisticaTransportadora] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LogisticaTransportadora] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LogisticaTransportadora] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LogisticaTransportadora] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LogisticaTransportadora] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LogisticaTransportadora] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LogisticaTransportadora] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LogisticaTransportadora] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LogisticaTransportadora] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LogisticaTransportadora] SET RECOVERY FULL 
GO
ALTER DATABASE [LogisticaTransportadora] SET  MULTI_USER 
GO
ALTER DATABASE [LogisticaTransportadora] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LogisticaTransportadora] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LogisticaTransportadora] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LogisticaTransportadora] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LogisticaTransportadora] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LogisticaTransportadora] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [LogisticaTransportadora] SET QUERY_STORE = OFF
GO
USE [LogisticaTransportadora]
GO
/****** Object:  Table [dbo].[TblBodegasPuerto]    Script Date: 24/08/2023 15:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblBodegasPuerto](
	[IdBodegaPuerto] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdTipoLogistica] [int] NOT NULL,
	[Nombre] [varchar](400) NOT NULL,
	[Direccion] [varchar](200) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_TblBodegas] PRIMARY KEY CLUSTERED 
(
	[IdBodegaPuerto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblCliente]    Script Date: 24/08/2023 15:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblCliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[NombreCliente] [varchar](500) NOT NULL,
	[IdTipoDoc] [int] NOT NULL,
	[Telefono] [int] NULL,
	[Celular] [int] NOT NULL,
	[Email] [varchar](200) NOT NULL,
	[Direccion] [varchar](200) NOT NULL,
	[FechaCreacion] [date] NOT NULL,
 CONSTRAINT [PK_TblCliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblDescuentos]    Script Date: 24/08/2023 15:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblDescuentos](
	[IdDescuento] [int] IDENTITY(1,1) NOT NULL,
	[IdPrecio] [int] NOT NULL,
	[PorcenDesc] [int] NOT NULL,
	[DesdeUnidades] [int] NOT NULL,
 CONSTRAINT [PK_TblDescuentos] PRIMARY KEY CLUSTERED 
(
	[IdDescuento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblEntrega]    Script Date: 24/08/2023 15:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblEntrega](
	[IdEntrega] [int] IDENTITY(1,1) NOT NULL,
	[IdProducto] [int] NOT NULL,
	[IdTipoLogistica] [int] NOT NULL,
	[CantidadProducto] [int] NOT NULL,
	[FechaRegistro] [date] NOT NULL,
	[FechaEntrega] [date] NULL,
	[IdBodega] [int] NOT NULL,
	[PrecioEnvioFijo] [money] NOT NULL,
	[PorcenDescuento] [int] NOT NULL,
	[PrecioEnvioReal] [money] NOT NULL,
	[NumeroGuia] [varchar](10) NOT NULL,
	[PlacaVehiculo] [varchar](6) NULL,
	[NumeroFlota] [varchar](8) NULL,
 CONSTRAINT [PK_TblEntrega] PRIMARY KEY CLUSTERED 
(
	[IdEntrega] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblPrecios]    Script Date: 24/08/2023 15:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblPrecios](
	[IdPrecio] [int] IDENTITY(1,1) NOT NULL,
	[IdTipoLogistica] [int] NOT NULL,
	[PrecioEnvio] [money] NOT NULL,
 CONSTRAINT [PK_TblPrecios] PRIMARY KEY CLUSTERED 
(
	[IdPrecio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblProductos]    Script Date: 24/08/2023 15:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblProductos](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdTipoLogistica] [int] NOT NULL,
	[NombreProducto] [varchar](400) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_TblProductos] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblTipoDoc]    Script Date: 24/08/2023 15:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblTipoDoc](
	[IdTipoDoc] [int] IDENTITY(1,1) NOT NULL,
	[NomTipoDoc] [varchar](100) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_TblTipoDoc] PRIMARY KEY CLUSTERED 
(
	[IdTipoDoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblTipoLogistica]    Script Date: 24/08/2023 15:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblTipoLogistica](
	[IdTipoLogistica] [int] IDENTITY(1,1) NOT NULL,
	[NombreTipoLogistica] [varchar](200) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_TblTipoLogistica] PRIMARY KEY CLUSTERED 
(
	[IdTipoLogistica] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TblBodegasPuerto] ON 

INSERT [dbo].[TblBodegasPuerto] ([IdBodegaPuerto], [IdCliente], [IdTipoLogistica], [Nombre], [Direccion], [Activo]) VALUES (2, 2, 1, N'Pivijai', N'Carrera 88a #34b-08', 1)
INSERT [dbo].[TblBodegasPuerto] ([IdBodegaPuerto], [IdCliente], [IdTipoLogistica], [Nombre], [Direccion], [Activo]) VALUES (3, 2, 2, N'Puerto valdivia', N'Carrera 88a #34b-08', 1)
SET IDENTITY_INSERT [dbo].[TblBodegasPuerto] OFF
GO
SET IDENTITY_INSERT [dbo].[TblCliente] ON 

INSERT [dbo].[TblCliente] ([IdCliente], [NombreCliente], [IdTipoDoc], [Telefono], [Celular], [Email], [Direccion], [FechaCreacion]) VALUES (2, N'Josue Fernandez Berdugo', 1, 123412, 23134123, N'jferber18@gmail.com', N'Carrera 88a #34b - 08', CAST(N'2023-08-24' AS Date))
INSERT [dbo].[TblCliente] ([IdCliente], [NombreCliente], [IdTipoDoc], [Telefono], [Celular], [Email], [Direccion], [FechaCreacion]) VALUES (3, N'Josue Fernandez Berdugo', 1, 123412, 23134123, N'jferber18@gmail.com', N'Carrera 88a #34b - 08', CAST(N'2023-08-24' AS Date))
INSERT [dbo].[TblCliente] ([IdCliente], [NombreCliente], [IdTipoDoc], [Telefono], [Celular], [Email], [Direccion], [FechaCreacion]) VALUES (4, N'Josue Fernandez Berdugo', 1, 123412, 23134123, N'jferber18@gmail.com', N'Carrera 88a #34b - 08', CAST(N'2023-08-24' AS Date))
INSERT [dbo].[TblCliente] ([IdCliente], [NombreCliente], [IdTipoDoc], [Telefono], [Celular], [Email], [Direccion], [FechaCreacion]) VALUES (5, N'Josue Fernandez Berdugo', 1, 123412, 23134123, N'jferber18@gmail.com', N'Carrera 88a #34b - 08', CAST(N'2023-08-24' AS Date))
SET IDENTITY_INSERT [dbo].[TblCliente] OFF
GO
SET IDENTITY_INSERT [dbo].[TblDescuentos] ON 

INSERT [dbo].[TblDescuentos] ([IdDescuento], [IdPrecio], [PorcenDesc], [DesdeUnidades]) VALUES (1, 1, 5, 10)
INSERT [dbo].[TblDescuentos] ([IdDescuento], [IdPrecio], [PorcenDesc], [DesdeUnidades]) VALUES (2, 2, 3, 10)
SET IDENTITY_INSERT [dbo].[TblDescuentos] OFF
GO
SET IDENTITY_INSERT [dbo].[TblEntrega] ON 

INSERT [dbo].[TblEntrega] ([IdEntrega], [IdProducto], [IdTipoLogistica], [CantidadProducto], [FechaRegistro], [FechaEntrega], [IdBodega], [PrecioEnvioFijo], [PorcenDescuento], [PrecioEnvioReal], [NumeroGuia], [PlacaVehiculo], [NumeroFlota]) VALUES (3, 1, 1, 1, CAST(N'2023-08-24' AS Date), CAST(N'2023-05-29' AS Date), 2, 100000.0000, 0, 100000.0000, N'386n9cgag4', N'ABC455', N'')
INSERT [dbo].[TblEntrega] ([IdEntrega], [IdProducto], [IdTipoLogistica], [CantidadProducto], [FechaRegistro], [FechaEntrega], [IdBodega], [PrecioEnvioFijo], [PorcenDescuento], [PrecioEnvioReal], [NumeroGuia], [PlacaVehiculo], [NumeroFlota]) VALUES (4, 1, 1, 11, CAST(N'2023-08-24' AS Date), CAST(N'2023-05-29' AS Date), 2, 100000.0000, 5, 95000.0000, N'i0u3egufoe', N'ABC455', N'')
SET IDENTITY_INSERT [dbo].[TblEntrega] OFF
GO
SET IDENTITY_INSERT [dbo].[TblPrecios] ON 

INSERT [dbo].[TblPrecios] ([IdPrecio], [IdTipoLogistica], [PrecioEnvio]) VALUES (1, 1, 100000.0000)
INSERT [dbo].[TblPrecios] ([IdPrecio], [IdTipoLogistica], [PrecioEnvio]) VALUES (2, 2, 300000.0000)
SET IDENTITY_INSERT [dbo].[TblPrecios] OFF
GO
SET IDENTITY_INSERT [dbo].[TblProductos] ON 

INSERT [dbo].[TblProductos] ([IdProducto], [IdCliente], [IdTipoLogistica], [NombreProducto], [Activo]) VALUES (1, 5, 1, N'Zapatos de charol', 1)
INSERT [dbo].[TblProductos] ([IdProducto], [IdCliente], [IdTipoLogistica], [NombreProducto], [Activo]) VALUES (2, 5, 1, N'Correas de cuero', 1)
SET IDENTITY_INSERT [dbo].[TblProductos] OFF
GO
SET IDENTITY_INSERT [dbo].[TblTipoDoc] ON 

INSERT [dbo].[TblTipoDoc] ([IdTipoDoc], [NomTipoDoc], [Activo]) VALUES (1, N'Cédula ciudadania', 1)
INSERT [dbo].[TblTipoDoc] ([IdTipoDoc], [NomTipoDoc], [Activo]) VALUES (2, N'Nit', 1)
INSERT [dbo].[TblTipoDoc] ([IdTipoDoc], [NomTipoDoc], [Activo]) VALUES (3, N'Cédula Extranjeria', 1)
INSERT [dbo].[TblTipoDoc] ([IdTipoDoc], [NomTipoDoc], [Activo]) VALUES (4, N'Documento Extranjero', 1)
SET IDENTITY_INSERT [dbo].[TblTipoDoc] OFF
GO
SET IDENTITY_INSERT [dbo].[TblTipoLogistica] ON 

INSERT [dbo].[TblTipoLogistica] ([IdTipoLogistica], [NombreTipoLogistica], [Activo]) VALUES (1, N'Terrestre', 1)
INSERT [dbo].[TblTipoLogistica] ([IdTipoLogistica], [NombreTipoLogistica], [Activo]) VALUES (2, N'Marítimo', 1)
SET IDENTITY_INSERT [dbo].[TblTipoLogistica] OFF
GO
ALTER TABLE [dbo].[TblBodegasPuerto] ADD  CONSTRAINT [DF_TblBodegas_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[TblProductos] ADD  CONSTRAINT [DF_TblProductos_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[TblTipoDoc] ADD  CONSTRAINT [DF_TblTipoDoc_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[TblTipoLogistica] ADD  CONSTRAINT [DF_TblTipoLogistica_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[TblBodegasPuerto]  WITH CHECK ADD  CONSTRAINT [FK_TblBodegasPuerto_TblCliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[TblCliente] ([IdCliente])
GO
ALTER TABLE [dbo].[TblBodegasPuerto] CHECK CONSTRAINT [FK_TblBodegasPuerto_TblCliente]
GO
ALTER TABLE [dbo].[TblBodegasPuerto]  WITH CHECK ADD  CONSTRAINT [FK_TblBodegasPuerto_TblTipoLogistica] FOREIGN KEY([IdTipoLogistica])
REFERENCES [dbo].[TblTipoLogistica] ([IdTipoLogistica])
GO
ALTER TABLE [dbo].[TblBodegasPuerto] CHECK CONSTRAINT [FK_TblBodegasPuerto_TblTipoLogistica]
GO
ALTER TABLE [dbo].[TblCliente]  WITH CHECK ADD  CONSTRAINT [FK_TblCliente_TblTipoDoc] FOREIGN KEY([IdTipoDoc])
REFERENCES [dbo].[TblTipoDoc] ([IdTipoDoc])
GO
ALTER TABLE [dbo].[TblCliente] CHECK CONSTRAINT [FK_TblCliente_TblTipoDoc]
GO
ALTER TABLE [dbo].[TblDescuentos]  WITH CHECK ADD  CONSTRAINT [FK_TblDescuentos_TblPrecios] FOREIGN KEY([IdPrecio])
REFERENCES [dbo].[TblPrecios] ([IdPrecio])
GO
ALTER TABLE [dbo].[TblDescuentos] CHECK CONSTRAINT [FK_TblDescuentos_TblPrecios]
GO
ALTER TABLE [dbo].[TblEntrega]  WITH CHECK ADD  CONSTRAINT [FK_TblEntrega_TblBodegasPuerto] FOREIGN KEY([IdBodega])
REFERENCES [dbo].[TblBodegasPuerto] ([IdBodegaPuerto])
GO
ALTER TABLE [dbo].[TblEntrega] CHECK CONSTRAINT [FK_TblEntrega_TblBodegasPuerto]
GO
ALTER TABLE [dbo].[TblEntrega]  WITH CHECK ADD  CONSTRAINT [FK_TblEntrega_TblProductos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[TblProductos] ([IdProducto])
GO
ALTER TABLE [dbo].[TblEntrega] CHECK CONSTRAINT [FK_TblEntrega_TblProductos]
GO
ALTER TABLE [dbo].[TblEntrega]  WITH CHECK ADD  CONSTRAINT [FK_TblEntrega_TblTipoLogistica] FOREIGN KEY([IdTipoLogistica])
REFERENCES [dbo].[TblTipoLogistica] ([IdTipoLogistica])
GO
ALTER TABLE [dbo].[TblEntrega] CHECK CONSTRAINT [FK_TblEntrega_TblTipoLogistica]
GO
ALTER TABLE [dbo].[TblPrecios]  WITH CHECK ADD  CONSTRAINT [FK_TblPrecios_TblTipoLogistica] FOREIGN KEY([IdTipoLogistica])
REFERENCES [dbo].[TblTipoLogistica] ([IdTipoLogistica])
GO
ALTER TABLE [dbo].[TblPrecios] CHECK CONSTRAINT [FK_TblPrecios_TblTipoLogistica]
GO
ALTER TABLE [dbo].[TblProductos]  WITH CHECK ADD  CONSTRAINT [FK_TblProductos_TblCliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[TblCliente] ([IdCliente])
GO
ALTER TABLE [dbo].[TblProductos] CHECK CONSTRAINT [FK_TblProductos_TblCliente]
GO
ALTER TABLE [dbo].[TblProductos]  WITH CHECK ADD  CONSTRAINT [FK_TblProductos_TblTipoLogistica] FOREIGN KEY([IdTipoLogistica])
REFERENCES [dbo].[TblTipoLogistica] ([IdTipoLogistica])
GO
ALTER TABLE [dbo].[TblProductos] CHECK CONSTRAINT [FK_TblProductos_TblTipoLogistica]
GO
/****** Object:  StoredProcedure [dbo].[CREAR_BodegaPuerto]    Script Date: 24/08/2023 15:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CREAR_BodegaPuerto]
	-- Add the parameters for the stored procedure here
	@IdCliente int,
	@IdTipoLogistica int,
	@Nombre varchar(400),
	@Direccion varchar(200),
	@Activo int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO TblBodegasPuerto(IdCliente,IdTipoLogistica,Nombre,Direccion,Activo)
						  values(@IdCliente,@IdTipoLogistica,@Nombre,@Direccion,@Activo)

	SELECT * FROM TblBodegasPuerto WHERE IdBodegaPuerto = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[CREAR_Cliente]    Script Date: 24/08/2023 15:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CREAR_Cliente]
	-- Add the parameters for the stored procedure here
	@NombreCliente varchar(500),
	@IdTipoDoc int,
	@Telefono int,
	@Celular int,
	@Email varchar(200),
	@Direccion varchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO DBO.TblCliente(NombreCliente,IdTipoDoc,Telefono,Celular,Email,Direccion,FechaCreacion)
						VALUES(@NombreCliente,@IdTipoDoc,@Telefono,@Celular,@Email,@Direccion,GETDATE())
	SELECT @@IDENTITY as IdGenerado
END
GO
/****** Object:  StoredProcedure [dbo].[CREAR_PlanEntrega]    Script Date: 24/08/2023 15:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CREAR_PlanEntrega]
	-- Add the parameters for the stored procedure here
	@IdProducto int,
    @IdTipoLogistica int,
    @CantidadProducto int,
    @FechaRegistro date,
    @FechaEntrega date,
    @IdBodega int,
    @PlacaVehiculo varchar(6),
	@NumeroGuia  varchar(10),
	@NumeroFlota varchar(8)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @PrecioReal money,@DescuentoPorcen int,@PrecioDescontado money

	SELECT top(1) @PrecioReal = PrecioEnvio ,
				@DescuentoPorcen = ISNULL(TblDescuentos.PorcenDesc,0),
				@PrecioDescontado = CASE WHEN TblDescuentos.PorcenDesc IS NULL THEN PrecioEnvio 
										ELSE PrecioEnvio-((PrecioEnvio * TblDescuentos.PorcenDesc)/100)
										END
	FROM TblPrecios 
	LEFT JOIN TblDescuentos ON TblDescuentos.IdPrecio = TblPrecios.IdPrecio and   @CantidadProducto > TblDescuentos.DesdeUnidades
	WHERE IdTipoLogistica = @IdTipoLogistica 
 	

    INSERT INTO TblEntrega(IdProducto,IdTipoLogistica,CantidadProducto,FechaRegistro,FechaEntrega,IdBodega,PrecioEnvioFijo,PorcenDescuento,PrecioEnvioReal,PlacaVehiculo,NumeroGuia,NumeroFlota)
					VALUES(@IdProducto,@IdTipoLogistica,@CantidadProducto,@FechaRegistro,@FechaEntrega,@IdBodega,@PrecioReal,@DescuentoPorcen,@PrecioDescontado,@PlacaVehiculo,@NumeroGuia,@NumeroFlota)

	SELECT * FROM TblEntrega WHERE IdEntrega = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[CREAR_Producto]    Script Date: 24/08/2023 15:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CREAR_Producto] 
	-- Add the parameters for the stored procedure here
	@IdGenerado int,
	@NombreProducto varchar(400),
	@TipoLogistica int,
	@Activo int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO DBO.TblProductos(IdCliente,NombreProducto,IdTipoLogistica,Activo)
						  VALUES(@IdGenerado,@NombreProducto,@TipoLogistica,@Activo)
	SELECT @@IDENTITY AS IdProducto
END
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_BodegasPuertos]    Script Date: 24/08/2023 15:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[LISTAR_BodegasPuertos]
	-- Add the parameters for the stored procedure here
	@IdBodegaPuerto int = 0,
	@IdCliente int = 0,
	@IdTipoLogistica int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT * 
	FROM TblBodegasPuerto
	WHERE TblBodegasPuerto.IdBodegaPuerto = (CASE WHEN @IdBodegaPuerto = 0 THEN IdBodegaPuerto ELSE @IdBodegaPuerto END)
    AND   TblBodegasPuerto.IdCliente = (CASE WHEN @IdCliente = 0 THEN IdCliente ELSE @IdCliente END)
	AND   TblBodegasPuerto.IdTipoLogistica = (CASE WHEN @IdTipoLogistica = 0 THEN IdTipoLogistica ELSE @IdTipoLogistica END)

END
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_Clientes]    Script Date: 24/08/2023 15:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[LISTAR_Clientes]
	-- Add the parameters for the stored procedure here
    @IdCliente int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT DISTINCT TblCliente.IdCliente,NombreCliente,IdTipoDoc,Telefono,Celular,Email,Direccion,FechaCreacion 
	FROM TblCliente
	INNER JOIN TblProductos ON TblProductos.IdCliente = TblCliente.IdCliente
	WHERE TblCliente.IdCliente = CASE WHEN @IdCliente = 0 THEN TblCliente.IdCliente ELSE @IdCliente END

END
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_PlanesEntrega]    Script Date: 24/08/2023 15:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[LISTAR_PlanesEntrega]
	-- Add the parameters for the stored procedure here
	@IdEntrega int = 0,
	@IdProducto int = 0,
	@IdTipoLogistica int = 0,
	@IdBodega int = 0,
	@IdCliente int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT * 
	FROM TblEntrega
	INNER JOIN TblProductos ON TblEntrega.IdProducto = TblProductos.IdProducto
	WHERE TblEntrega.IdEntrega = (CASE WHEN @IdEntrega = 0 THEN TblEntrega.IdEntrega ELSE @IdEntrega END)
	AND   TblEntrega.IdProducto = (CASE WHEN @IdProducto = 0 THEN TblEntrega.IdProducto ELSE @IdProducto END)
	AND   TblEntrega.IdTipoLogistica = (CASE WHEN @IdTipoLogistica = 0 THEN TblEntrega.IdTipoLogistica ELSE @IdTipoLogistica END)
	AND   TblEntrega.IdBodega = (CASE WHEN @IdBodega = 0 THEN TblEntrega.IdBodega ELSE @IdBodega END)
	AND   TblProductos.IdCliente = (CASE WHEN @IdCliente = 0 THEN TblProductos.IdCliente ELSE @IdCliente END)

END
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_Productos]    Script Date: 24/08/2023 15:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[LISTAR_Productos]
	-- Add the parameters for the stored procedure here
	@IdCliente int = 0,
	@IdTipoLogistica int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT * FROM TblProductos
	WHERE IdCliente = CASE WHEN @IdCliente = 0 THEN IdCliente ELSE @IdCliente END
	AND	  IdTipoLogistica = CASE WHEN @IdTipoLogistica = 0 THEN IdTipoLogistica ELSE @IdTipoLogistica END
END
GO
USE [master]
GO
ALTER DATABASE [LogisticaTransportadora] SET  READ_WRITE 
GO
