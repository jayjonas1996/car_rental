alter PROCEDURE createnewuser
	 @name        VARCHAR (50),
    @address     NVARCHAR (MAX) ,
    @email_id    NVARCHAR (50)  ,
    @username    NVARCHAR (50)  ,
    @city        VARCHAR (50)   ,
    @state       VARCHAR (50)   ,
    @dob         DATE           ,
    @contact_no  NUMERIC (14)   ,
    @pincode     NUMERIC (9)    ,
    @license_no NVARCHAR (50)  ,
	@passhash NVARCHAR (MAX),
	@id int out
AS
BEGIN
SET NOCOUNT ON;
	IF NOT EXISTS(SELECT USER_ID FROM USER_MASTER WHERE USERNAME=@USERNAME OR email_id=@email_id)
		BEGIN
			IF NOT EXISTS (SELECT NAME FROM ADMIN_LOGIN WHERE NAME=@USERNAME)
				BEGIN
					insert into user_master (name,address,email_id,username,city,state,dob,contact_no,pincode,license_no) values (@name,@address,@email_id,@username,@city,@state,@dob,@contact_no,@pincode,@license_no);
					set @id = SCOPE_IDENTITY();
					insert into user_login values(@id,@username,@passhash);
					select @id;
				END
			ELSE
				BEGIN
					set @id =0;
					select @id;
				END
		END
	ELSE
		BEGIN
			set @id =0;
			select @id;
		END
END