-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [sp_Wishlist] @UserId int
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
begin try
		if exists (select UserId from AddToWishlist where UserId = @UserId)
	begin
		select Books.BookId, BookName, Author,Details, Price, Image, AddToWishlist.Quantity
		from Books inner join AddToWishlist on Books.BookId = AddToWishlist.BookId 
		where UserId = @UserId
	end
	end try
	begin catch
	print('error')
	end catch

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
END
GO
