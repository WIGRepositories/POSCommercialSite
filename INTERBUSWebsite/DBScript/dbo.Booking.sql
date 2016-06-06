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


/****** Object:  Table [dbo].[UserInfo]    Script Date: 06/06/2016 19:25:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[UserInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NULL,
	[EmailAddress] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[ConfirmPassword] [nvarchar](50) NULL,
	[Gender] [nvarchar](50) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[UserLogin1]    Script Date: 06/06/2016 19:26:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[UserLogin1](
	[LoginInfo] [nvarchar](50) NOT NULL,
	[PassKey] [nvarchar](50) NOT NULL,
	[Id] [int] NOT NULL,
	[UserId] [nchar](10) NOT NULL,
	[salt] [varchar](50) NULL,
	[Active] [int] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


/****** Object:  StoredProcedure [dbo].[GetUserInfo]    Script Date: 06/06/2016 19:26:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserInfo]

AS
BEGIN

SELECT U.[Id]
      ,U.[FirstName]
      ,U.[LastName]      
      
      ,U.[EmailAddress]
     
      ,ul.logininfo as UserName
      ,ul.passkey as [Password]            
      
  FROM [POSDashboard].[dbo].[UserInfo] U
  
 
left OUTER join dbo.userlogin1 ul on ul.userid = U.id    
 
end

GO


/****** Object:  StoredProcedure [dbo].[GetUserLogin1]    Script Date: 06/06/2016 19:27:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[GetUserLogin1]

AS
BEGIN

SELECT U.[Id]
        
      ,U.[Active]
      
      ,u.logininfo as UserName
      ,u.passkey as [Password]            
      
  FROM [POSDashboard].[dbo].[UserLogin1] U
  
  left outer join dbo.userinfo u1 on u.userid = U.id    
  
end


GO


/****** Object:  StoredProcedure [dbo].[InsUpdUserInfo]    Script Date: 06/06/2016 19:27:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[InsUpdUserInfo](
@FirstName varchar(50)
,@LastName varchar(50)

,@UserName varchar(50)  
,@Password varchar(50)  
,@EmailAddress varchar(50)

,@ConfirmPassword varchar(50)
,@Gender varchar(50))

 AS
BEGIN

	
INSERT INTO [POSDashboard].[dbo].[UserInfo]
           ([FirstName]
           ,[LastName]
           ,[UserName]
           ,[EmailAddress]
           ,[Password]
           ,[ConfirmPassword]
           ,[Gender])
     VALUES
           (@FirstName
           ,@LastName
           ,@UserName
           ,@EmailAddress
           ,@Password
           ,@ConfirmPassword
           ,@Gender)
END
GO


/****** Object:  StoredProcedure [dbo].[ValidateCredentials1]    Script Date: 06/06/2016 19:28:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[ValidateCredentials1](@logininfo varchar(50) = null, @passkey varchar(50) = null)
as
begin

select logininfo,FirstName, Lastname,u.Id 
from userlogin1 ul 
inner join userInfo u on 
u.id = ul.UserId

where LoginInfo=@logininfo and [PassKey]=@passkey

end




GO










