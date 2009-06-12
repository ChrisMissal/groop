USE [CRIneta]
go
/****** Drop User From Database******/
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'CRInetaUser')
    DROP USER [CRInetaUser]
GO
USE [Master]
Go

IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = N'CRInetaUser')
    CREATE LOGIN [CRInetaUser] WITH PASSWORD=N'p@ssw0rd', DEFAULT_DATABASE=[CRIneta], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
USE [CRIneta]
GO
CREATE USER [CRInetaUser] FOR LOGIN [CRInetaUser]
GO
USE [CRIneta]
GO
EXEC sp_addrolemember N'db_owner', N'CRInetaUser'
GO
