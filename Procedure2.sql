ALTER  PROCEDURE validategroup
@group_id NVARCHAR(50),
@exist int out

AS
BEGIN
SET NOCOUNT ON;
	IF EXISTS (SELECT * FROM VEHICLE_MASTER WHERE GROUP_ID = @group_id )
		BEGIN
			SET @exist = 1 ;
			SELECT @exist ;
		END	
	ELSE
		BEGIN
			SET @exist = 0;
			SELECT @exist ;
		END
END