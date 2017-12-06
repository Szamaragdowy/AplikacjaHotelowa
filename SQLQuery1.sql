USE [AplikacjaHotelowa]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[InsertAdres]
		@Miasto = NULL,
		@Ulica = NULL,
		@NumerBudynku = NULL,
		@Wojewodztwo = NULL,
		@Kraj = NULL

SELECT	@return_value as 'Return Value'

GO
