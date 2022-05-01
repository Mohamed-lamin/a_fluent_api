IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [UserGroup] (
    [Id] int NOT NULL IDENTITY,
    [Name] int NOT NULL,
    CONSTRAINT [PK_UserGroup] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [ContactEmailAddress] nvarchar(max) NOT NULL,
    [UserGroupId] int NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Users_UserGroup_UserGroupId] FOREIGN KEY ([UserGroupId]) REFERENCES [UserGroup] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_Users_UserGroupId] ON [Users] ([UserGroupId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220430185128_init', N'6.0.4');
GO

COMMIT;
GO

