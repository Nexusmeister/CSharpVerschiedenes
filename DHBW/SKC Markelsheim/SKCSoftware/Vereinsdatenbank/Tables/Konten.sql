CREATE TABLE [dbo].[Konten]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [IBAN] VARCHAR(100) NOT NULL, 
    [BankenID] INT NULL, 
    [MitgliederID] INT NOT NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Konten ID',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Konten',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'IBAN oder Kontonummer des Mitglieds',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Konten',
    @level2type = N'COLUMN',
    @level2name = N'IBAN'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fremdschlüssel auf Banken.ID',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Konten',
    @level2type = N'COLUMN',
    @level2name = N'BankenID'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fremdschlüssel auf Mitglieder.ID',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Konten',
    @level2type = N'COLUMN',
    @level2name = N'MitgliederID'