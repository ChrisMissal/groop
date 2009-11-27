USE [Groop]
go
/****** Drop User From Database******/
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'GroopUser')
    DROP USER [GroopUser]
GO
USE [Master]
Go

IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = N'GroopUser')
    CREATE LOGIN [GroopUser] WITH PASSWORD=N'p@ssw0rd', DEFAULT_DATABASE=[Groop], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
USE [Groop]
GO
CREATE USER [GroopUser] FOR LOGIN [GroopUser]
GO
USE [Groop]
GO
EXEC sp_addrolemember N'db_owner', N'GroopUser'
GO
