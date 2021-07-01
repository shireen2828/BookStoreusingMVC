USE [Book_Store]
GO
/****** Object:  StoredProcedure [dbo].[sp_Getcart]    Script Date: 02-07-2021 02:01:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_Getcart] @UserId int
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
BEGIN TRY

      if exists (select UserId from AddToCart where UserId=@UserId)
		begin
		select Books.BookId , Books.BookName ,Books.Author ,Books.Price ,Books.Image ,
		AddToCart.Quantity 
		 from Books inner join  AddToCart on Books.BookId=AddToCart.BookId
		where UserId=@UserId	
		end
END TRY
	
begin catch
			 
   print('error')
	end catch 
END
