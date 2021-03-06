USE [master]
GO
/****** Object:  Database [Prueba_NewShore]    Script Date: 27/09/2020 9:41:44 p. m. ******/
CREATE DATABASE [Prueba_NewShore]
GO

USE [Prueba_NewShore]
GO

CREATE TABLE [dbo].[Flight](
	[PK_IdFligth] [int] IDENTITY(1,1) NOT NULL,
	[FK_IdTransport] [int] NOT NULL,
	[DepartureStation] [nvarchar](10) NOT NULL,
	[ArrivalStation] [nvarchar](10) NOT NULL,
	[DepartureDate] [datetime] NOT NULL,
	[Price] [money] NOT NULL,
	[Currency] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Flight] PRIMARY KEY CLUSTERED 
(
	[PK_IdFligth] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Route]    Script Date: 27/09/2020 9:41:45 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Route](
	[IATACode] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Route] PRIMARY KEY CLUSTERED 
(
	[IATACode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transport]    Script Date: 27/09/2020 9:41:45 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transport](
	[PK_IdTransport] [int] IDENTITY(1,1) NOT NULL,
	[FlightNumber] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Transport] PRIMARY KEY CLUSTERED 
(
	[PK_IdTransport] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Flight]  WITH CHECK ADD  CONSTRAINT [FK_Flight_Route] FOREIGN KEY([ArrivalStation])
REFERENCES [dbo].[Route] ([IATACode])
GO
ALTER TABLE [dbo].[Flight] CHECK CONSTRAINT [FK_Flight_Route]
GO
ALTER TABLE [dbo].[Flight]  WITH CHECK ADD  CONSTRAINT [FK_Flight_Route1] FOREIGN KEY([DepartureStation])
REFERENCES [dbo].[Route] ([IATACode])
GO
ALTER TABLE [dbo].[Flight] CHECK CONSTRAINT [FK_Flight_Route1]
GO
ALTER TABLE [dbo].[Flight]  WITH CHECK ADD  CONSTRAINT [FK_Flight_Transport] FOREIGN KEY([FK_IdTransport])
REFERENCES [dbo].[Transport] ([PK_IdTransport])
GO
ALTER TABLE [dbo].[Flight] CHECK CONSTRAINT [FK_Flight_Transport]
GO
USE [master]
GO
ALTER DATABASE [Prueba_NewShore] SET  READ_WRITE 
GO
