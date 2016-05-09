

/****** Object:  Table [dbo].[HiringType]    Script Date: 05/09/2016 10:43:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[HiringType](
	[TravelName] [nvarchar](50) NULL,
	[TravelType] [nvarchar](50) NULL,
	[Time] [datetime] NULL,
	[Duration] [datetime] NULL,
	[Seats] [nvarchar](50) NULL,
	[Rating] [nvarchar](50) NULL,
	[Cost] [numeric](18, 0) NULL
) ON [PRIMARY]

GO


