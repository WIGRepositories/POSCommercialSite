USE [INTERBUS]
GO

/****** Object:  StoredProcedure [dbo].[gettable2]    Script Date: 04/25/2016 17:04:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[gettable2]
as
begin
select * from table2
end

GO


