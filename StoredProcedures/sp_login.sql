USE [Book_Store]
GO
/****** Object:  StoredProcedure [dbo].[sp_login]    Script Date: 02-07-2021 09:12:03 ******/
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
	begin try
	if exists(select * from UserRegisteration where @Email=@Email and @Password=@Password)
	return 1
	else
	return 0
	end try
    -- Insert statements for procedure here
	begin catch
print('error')
end catch
	begin
select * from UserRegisteration where @Email = @Email;
END

select * from UserRegisteration;
END
