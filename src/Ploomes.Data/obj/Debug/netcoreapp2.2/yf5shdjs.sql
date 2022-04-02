IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Providers] (
    [Id] uniqueidentifier NOT NULL,
    [Name] VARCHAR(200) NOT NULL,
    [Identification] VARCHAR(14) NOT NULL,
    [ProviderType] int NOT NULL,
    [Active] bit NOT NULL,
    CONSTRAINT [PK_Providers] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Address] (
    [Id] uniqueidentifier NOT NULL,
    [ProviderId] uniqueidentifier NOT NULL,
    [Street] VARCHAR(200) NOT NULL,
    [Number] VARCHAR(10) NOT NULL,
    [Additional] VARCHAR(200) NOT NULL,
    [ZipCode] VARCHAR(8) NOT NULL,
    [Neighborhood] VARCHAR(200) NOT NULL,
    [City] VARCHAR(200) NOT NULL,
    [State] VARCHAR(200) NOT NULL,
    CONSTRAINT [PK_Address] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Address_Providers_ProviderId] FOREIGN KEY ([ProviderId]) REFERENCES [Providers] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Products] (
    [Id] uniqueidentifier NOT NULL,
    [ProviderId] uniqueidentifier NOT NULL,
    [Name] VARCHAR(200) NOT NULL,
    [Description] VARCHAR(1000) NOT NULL,
    [Image] VARCHAR(100) NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    [RegistrationDate] datetime2 NOT NULL,
    [Active] bit NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Products_Providers_ProviderId] FOREIGN KEY ([ProviderId]) REFERENCES [Providers] ([Id]) ON DELETE NO ACTION
);

GO

CREATE UNIQUE INDEX [IX_Address_ProviderId] ON [Address] ([ProviderId]);

GO

CREATE INDEX [IX_Products_ProviderId] ON [Products] ([ProviderId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220325201701_Initial', N'2.2.6-servicing-10079');

GO

