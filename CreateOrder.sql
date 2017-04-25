USE [BangDatabase]
GO

/****** Object:  Table [dbo].[Order]    Script Date: 4/24/2017 7:28:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[DuckettsId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL
) ON [PRIMARY]

GO


