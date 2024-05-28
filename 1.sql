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

CREATE TABLE [Brands] (
    [BrandID] int NOT NULL IDENTITY,
    [BrandName] varchar(40) NULL,
    CONSTRAINT [PK__Brands__DAD4F3BE335898EA] PRIMARY KEY ([BrandID])
);
GO

CREATE TABLE [Categories] (
    [CategoryID] int NOT NULL IDENTITY,
    [CategoryName] varchar(40) NULL,
    CONSTRAINT [PK__Categori__19093A2BDEC79F42] PRIMARY KEY ([CategoryID])
);
GO

CREATE TABLE [Products] (
    [ProductID] bigint NOT NULL IDENTITY,
    [ProductName] varchar(50) NULL,
    [Price] decimal(15,2) NULL,
    [DateOfPurchase] datetime NULL,
    [AvailabilityStatus] varchar(50) NULL,
    [CategoryID] int NULL,
    [BrandID] int NULL,
    [Active] bit NULL DEFAULT CAST(1 AS bit),
    [Quantity] int NULL,
    CONSTRAINT [PK__Products__B40CC6ED56AE21D6] PRIMARY KEY ([ProductID]),
    CONSTRAINT [FK__Products__BrandI__52593CB8] FOREIGN KEY ([BrandID]) REFERENCES [Brands] ([BrandID]) ON DELETE SET NULL,
    CONSTRAINT [FK__Products__Catego__5165187F] FOREIGN KEY ([CategoryID]) REFERENCES [Categories] ([CategoryID]) ON DELETE SET NULL
);
GO

CREATE INDEX [IX_Products_BrandID] ON [Products] ([BrandID]);
GO

CREATE INDEX [IX_Products_CategoryID] ON [Products] ([CategoryID]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240523143435_V0', N'8.0.4');
GO

COMMIT;
GO

