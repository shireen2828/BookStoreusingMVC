USE [Book_Store]
GO
/****** Object:  StoredProcedure [dbo].[sp_login]    Script Date: 29-06-2021 23:34:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_login]  @Email varchar(130), @Password varchar(130) 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if exists(select * from UserRegisteration where @Email=@Email and @Password=@Password)
    -- Insert statements for procedure here
	BEGIN
select * from UserRegisteration where @Email = @Email;
END
END
