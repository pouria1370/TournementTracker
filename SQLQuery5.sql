
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.spTestPerson_GetByFirstName
	@FirstName nvarchar(100)
AS
BEGIN
	
	SET NOCOUNT ON;

   
	SELECT *
	from dbo.TestPerson
	where FirstName= @FirstName
END
GO