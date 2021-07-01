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
CREATE PROCEDURE [sp_Addtocart] @UserId int, @BookId int, @Quantity int
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
begin try
		insert into [AddToCart] values(@UserId,@BookId,@Quantity)
	end try
	BEGIN CATCH 
	PRINT('error found');
	THROW;
	END CATCH
	
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select * from AddToCart;
END
GO
