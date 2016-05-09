

/****** Object:  StoredProcedure [dbo].[GetHiringType]    Script Date: 05/09/2016 10:44:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetHiringType] 
	
	
AS
BEGIN
SELECT [TravelName]
      ,[TravelType]
      ,[Time]
      ,[Duration]
      ,[Seats]
      ,[Rating]
      ,[Cost]
  FROM  HiringType


END




GO


