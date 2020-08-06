CREATE TABLE [dbo].[Orte]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [PLZ] INT NULL, 
    [Ortsname] VARCHAR(150) NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Postleitzahl',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Orte',
    @level2type = N'COLUMN',
    @level2name = N'PLZ'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Ortsname',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Orte',
    @level2type = N'COLUMN',
    @level2name = N'Ortsname'
