BEGIN TRANSACTION;
GO

ALTER TABLE [Foos] ADD [SomeNumber] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230628125950_Migration_2', N'6.0.8');
GO

COMMIT;
GO

