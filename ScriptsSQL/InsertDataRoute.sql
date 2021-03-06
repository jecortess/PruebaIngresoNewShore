USE [Prueba_NewShore]
GO
/****** Object:  Table [dbo].[Route]    Script Date: 27/09/2020 9:44:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Route]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Route](
	[IATACode] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Route] PRIMARY KEY CLUSTERED 
(
	[IATACode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
INSERT [dbo].[Route] ([IATACode], [Description]) VALUES (N'BOG', N'Bogotá')
INSERT [dbo].[Route] ([IATACode], [Description]) VALUES (N'CTG', N'Cartagena')
INSERT [dbo].[Route] ([IATACode], [Description]) VALUES (N'MDE', N'Medellín')
INSERT [dbo].[Route] ([IATACode], [Description]) VALUES (N'PEI', N'Pereira')
