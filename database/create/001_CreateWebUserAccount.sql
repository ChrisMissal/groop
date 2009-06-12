USE [JPCyclesWeb]
go
/****** Drop User From Database******/
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'jpwebuser')
    DROP USER [jpwebuser]
GO
USE [Master]
Go

IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = N'jpwebuser')
    CREATE LOGIN [jpwebuser] WITH PASSWORD=N'p@ssw0rd', DEFAULT_DATABASE=[JPCyclesWeb], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
USE [JPCyclesWeb]
GO
CREATE USER [jpwebuser] FOR LOGIN [jpwebuser]
GO
USE [JPCyclesWeb]
GO
EXEC sp_addrolemember N'db_owner', N'jpwebuser'
GO
