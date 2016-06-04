/****** Object:  Table [dbo].[Booking]    Script Date: 05/09/2016 09:57:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Booking](
	[TravelName] [nvarchar](50) NULL,
	[TravelType] [nvarchar](50) NULL,
	[Time] [datetime] NULL,
	[Duration] [datetime] NULL,
	[Seats] [nvarchar](50) NULL,
	[Rating] [nvarchar](50) NULL,
	[Cost] [numeric](18, 0) NULL
) ON [PRIMARY]

GO





/****** Object:  Table [dbo].[PnrDetails]    Script Date: 06/04/2016 17:21:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PnrDetails](
	[Pnr_ID] [int] IDENTITY(1,1) NOT NULL,
	[Pnr_No] [varchar](20) NOT NULL,
	[No_Seats] [int] NOT NULL,
	[cost] [int] NOT NULL,
	[dateandtime] [datetime] NOT NULL,
	[src] [varchar](30) NOT NULL,
	[dest] [varchar](30) NOT NULL,
	[vehicle_No] [varchar](20) NOT NULL,
 CONSTRAINT [PK__Pnr_Deta__0A9420FF19AACF41] PRIMARY KEY CLUSTERED 
(
	[Pnr_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO










/****** Object:  Table [dbo].[PassengerDetails]    Script Date: 06/04/2016 17:37:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PassengerDetails](
	[PassengerId] [int] IDENTITY(1,1) NOT NULL,
	[Fname] [varchar](30) NOT NULL,
	[Lname] [varchar](30) NOT NULL,
	[Age] [int] NOT NULL,
	[Sex] [int] NOT NULL,
	[dateandtime] [datetime] NOT NULL,
	[Pnr_Id] [int] NOT NULL,
	[Pnr_No] [varchar](20) NOT NULL,
	[Identityproof] [varchar](30) NOT NULL,
 CONSTRAINT [PK__Passenge__88915FB01D7B6025] PRIMARY KEY CLUSTERED 
(
	[PassengerId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO










/****** Object:  Table [dbo].[PaymentDetails]    Script Date: 06/04/2016 17:40:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PaymentDetails](
	[TransactionId] [int] IDENTITY(1,1) NOT NULL,
	[Transaction_Number] [varchar](30) NOT NULL,
	[Amount] [bigint] NOT NULL,
	[Paymentmode] [int] NOT NULL,
	[dateandtime] [datetime] NOT NULL,
	[Pnr_Id] [int] NOT NULL,
	[Pnr_No] [varchar](20) NOT NULL,
	[Gateway_transId] [varchar](20) NOT NULL,
 CONSTRAINT [PK__Transact__55433A6B214BF109] PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO








/****** Object:  Table [dbo].[BookedHistory]    Script Date: 06/04/2016 15:33:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[BookedHistory](
	[Bookedhistory_Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Pnr_ID] [int] NOT NULL,
	[Pnr_No] [varchar](20) NOT NULL,
	[Datetime] [datetime] NOT NULL,
 CONSTRAINT [PK_BookedHistory] PRIMARY KEY CLUSTERED 
(
	[Bookedhistory_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO








GO

/****** Object:  Table [dbo].[PnrToSeats]    Script Date: 06/04/2016 15:34:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PnrToSeats](
	[PSID] [int] IDENTITY(1,1) NOT NULL,
	[Pnr_ID] [int] NOT NULL,
	[Pnr_No] [varchar](20) NOT NULL,
	[SeatNo] [varchar](5) NOT NULL,
	[VehicleNo] [varchar](20) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_OnrToSeats] PRIMARY KEY CLUSTERED 
(
	[PSID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO












