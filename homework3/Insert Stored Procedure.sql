USE [LogoDb]
GO

CREATE PROCEDURE InsertUser @name VARCHAR(50), @surname VARCHAR(50), @email VARCHAR(50), @birthdate DATE
AS
BEGIN
	INSERT INTO Users (name, surname, email, birthdate) VALUES (@name, @surname, @email, @birthdate)
END
GO

CREATE PROCEDURE InsertCompany @name VARCHAR(50)
AS
BEGIN
	INSERT INTO Companies (name) VALUES (@name)
END
GO

EXEC InsertUser @name = 'Yavuz Selim', @surname = 'GÜLER', @email = 'yavuzselimguler28@gmail.com', @birthdate = '1998-10-24'
EXEC InsertUser @name = 'Ahmet', @surname = 'Mehmet', @email = 'qwerty@asd.com', @birthdate = '2000-01-01'


EXEC InsertCompany @name = 'Logo Yazýlým'
EXEC InsertCompany @name = 'Patika'

SELECT * FROM Users
SELECT * FROM Companies