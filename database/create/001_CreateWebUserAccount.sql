USE [CRineta]
go
/****** Drop User From Database******/
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'CRinetaUser')
    DROP USER [CRinetaUser]
GO
USE [Master]
Go

IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = N'CRinetaUser')
    CREATE LOGIN [CRinetaUser] WITH PASSWORD=N'p@ssw0rd', DEFAULT_DATABASE=[CRineta], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
USE [CRineta]
GO
CREATE USER [CRinetaUser] FOR LOGIN [CRinetaUser]
GO
USE [CRineta]
GO
EXEC sp_addrolemember N'db_owner', N'CRinetaUser'
GO
