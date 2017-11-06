create procedure changepassword
@id int,
@old_hash NVARCHAR(MAX),
@new_hash NVARCHAR(MAX)

AS
BEGIN
		IF EXISTS (SELECT USERNAME FROM user_login WHERE USER_ID=@id AND PASSHASH=@old_hash)
		BEGIN
			UPDATE USER_LOGIN SET passhash = @new_hash WHERE user_id=@id	;
		END
END