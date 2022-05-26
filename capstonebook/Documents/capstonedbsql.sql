CREATE TABLE [dbo].[user]
(
	[number] INT NOT NULL, 
    [id] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [password] NVARCHAR(50) NOT NULL, 
    [name] NVARCHAR(50) NOT NULL, 
    [phonenumber] NVARCHAR(50) NOT NULL, 
    [email] NVARCHAR(50) NOT NULL, 
    [OX] NVARCHAR(50) NULL, 
    [delayday] INT NULL
)
Go

CREATE TABLE [dbo].[book]
(
	[bookname] INT NOT NULL, 
    [symbol] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [writer] NVARCHAR(50) NULL, 
    [price] INT NULL, 
    [publicyear] NVARCHAR(50) NULL, 
    [publisher] NVARCHAR(50) NULL,

)
Go

CREATE TABLE [dbo].[server]
(
	[id] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [password] NVARCHAR(50) NOT NULL
)
Go

Insert [user]
Values 
(
    N'1', N'oking', N'1234', N'최진우', N'010-9135-5717', 'tjsemttjsemt@naver.com', N'O', '1'

)
Go
