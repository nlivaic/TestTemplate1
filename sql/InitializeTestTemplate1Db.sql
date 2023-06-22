USE master
GO

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'TestTemplate1Db')
BEGIN
  CREATE DATABASE TestTemplate1Db;
END;
GO

USE TestTemplate1Db;
GO

IF NOT EXISTS (SELECT 1
                 FROM sys.server_principals
                WHERE [name] = N'TestTemplate1Db_Login' 
                  AND [type] IN ('C','E', 'G', 'K', 'S', 'U'))
BEGIN
    CREATE LOGIN TestTemplate1Db_Login
        WITH PASSWORD = '<DB_PASSWORD>';
END;
GO  

IF NOT EXISTS (select * from sys.database_principals where name = 'TestTemplate1Db_User')
BEGIN
    CREATE USER TestTemplate1Db_User FOR LOGIN TestTemplate1Db_Login;
END;
GO  


EXEC sp_addrolemember N'db_datareader', N'TestTemplate1Db_User';
GO

EXEC sp_addrolemember N'db_datawriter', N'TestTemplate1Db_User';
GO

EXEC sp_addrolemember N'db_ddladmin', N'TestTemplate1Db_User';
GO
