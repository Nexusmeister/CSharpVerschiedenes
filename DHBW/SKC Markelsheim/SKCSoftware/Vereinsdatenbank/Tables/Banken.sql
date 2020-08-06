CREATE TABLE [dbo].[Banken]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [BIC] VARCHAR(50) NULL, 
    [BLZ] INT NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'BIC der Bank',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Banken',
    @level2type = N'COLUMN',
    @level2name = N'BIC'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Bankleitzahl',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Banken',
    @level2type = N'COLUMN',
    @level2name = N'BLZ'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Banken ID',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Banken',
    @level2type = N'COLUMN',
    @level2name = N'Id'