USE [Book_Store]
GO
/****** Object:  StoredProcedure [dbo].[sp_userRegister]    Script Date: 29-06-2021 14:16:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_userRegister]

@FirstName varchar(130),
@LastName varchar(130),
@Email varchar(130),
@Password varchar(130)

	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Insert into UserRegisteration (FirstName,LastName,Email,Password)
	values (@FirstName,@LastName,@Email,@Password);
    -- Insert statements for procedure here
	
	select * from userRegisteration;
END
