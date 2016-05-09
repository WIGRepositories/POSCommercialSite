USE [POSDashboard]
GO

/****** Object:  StoredProcedure [dbo].[GetBooking]    Script Date: 05/09/2016 09:58:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[GetBooking] 
	
	
AS
BEGIN
SELECT [TravelName]
      ,[TravelType]
      ,[Time]
      ,[Duration]
      ,[Seats]
      ,[Rating]
      ,[Cost]
  FROM  Booking


END



GO


