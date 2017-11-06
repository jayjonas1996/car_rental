create procedure deleteaccount
@id int,
@hash NVARCHAR(MAX)

AS
BEGIN

	IF EXISTS(SELECT USERNAME FROM USER_LOGIN WHERE USER_ID=@id AND passhash=@hash)
	BEGIN
		UPDATE user_login SET username='XX',passhash='XX' WHERE user_id = @id;
		UPDATE user_master SET username='XX',email_id='XX' WHERE user_id= @id;
	END

END