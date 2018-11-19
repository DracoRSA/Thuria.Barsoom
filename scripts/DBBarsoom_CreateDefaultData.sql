USE [Barsoom]
GO

-- Delete Application Data
DELETE FROM [dbo].[BarsoomUser]
GO

-- Delete Lookup data
DELETE FROM [dbo].[UserStatus]
GO

-- Setup Lookup data
INSERT INTO [dbo].[UserStatus]
  ([Id], [Description], [IsActive]) VALUES('3A947C23-3492-4E25-8308-8BAC6A02CA61', 'Active', 1)
INSERT INTO [dbo].[UserStatus]
  ([Id], [Description], [IsActive]) VALUES('1C273EE4-A48C-4364-A859-5FDE8D8F6C92', 'Inactive', 2)
INSERT INTO [dbo].[UserStatus]
  ([Id], [Description], [IsActive]) VALUES('4E96823D-B722-419C-827E-67ADB0EA3E9B', 'Locked', 3)
GO

-- Setup the user details
INSERT INTO [dbo].[BarsoomUser]
  ([Id], [userName], [UserStatusId], [IsActive]) VALUES('2B9290C8-63D0-4138-831A-1902515BD2D8', 'admin', '3A947C23-3492-4E25-8308-8BAC6A02CA61', 1)
GO
