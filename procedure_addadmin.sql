create procedure addadmin
    @username    NVARCHAR (50)  ,
	@passhash NVARCHAR (MAX)
AS
BEGIN
		IF NOT EXISTS(SELECT USER_ID FROM USER_MASTER WHERE USERNAME=@username )
			BEGIN
			IF NOT EXISTS (SELECT NAME FROM ADMIN_LOGIN WHERE NAME=@username)
				BEGIN
						INSERT INTO ADMIN_LOGIN(name,passhash) VALUES(@username,@passhash);
				END
			END
END