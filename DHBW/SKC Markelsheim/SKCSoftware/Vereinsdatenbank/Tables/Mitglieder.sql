CREATE TABLE [dbo].[Mitglieder]
(
	[Id] INT NOT NULL IDENTITY (1,1) PRIMARY KEY, 
    [Vorname] VARCHAR(70) NOT NULL, 
    [Nachname] VARCHAR(100) NOT NULL, 
    [Geschlecht] CHAR(10) NULL, 
    [Geburtstag] DATE NOT NULL, 
    [AdresseID] INT NOT NULL, 
    [BankID] INT NOT NULL, 
    [IBAN] VARCHAR(200) NOT NULL, 
    [EintrittSKC] DATE NOT NULL, 
    [EintrittWKBV] DATE NOT NULL, 
    [WKBVFrüher] VARCHAR(250) NULL, 
    [HandyNr] BIGINT NULL, 
    [TelefonNr] VARCHAR(100) NULL, 
    [Fax] INT NULL, 
    [PassNr] INT NOT NULL, 
    [EMail] VARCHAR(150) NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Mitglieder ID',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Mitglieder',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Vorname des Mitglieds',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Mitglieder',
    @level2type = N'COLUMN',
    @level2name = N'Vorname'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Nachname des Mitglieds',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Mitglieder',
    @level2type = N'COLUMN',
    @level2name = N'Nachname'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'm,w,d',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Mitglieder',
    @level2type = N'COLUMN',
    @level2name = N'Geschlecht'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Geburtstagsdatum',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Mitglieder',
    @level2type = N'COLUMN',
    @level2name = N'Geburtstag'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fremdschlüssel auf Adressen.ID',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Mitglieder',
    @level2type = N'COLUMN',
    @level2name = N'AdresseID'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fremdschlüssel zu Banken.ID',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Mitglieder',
    @level2type = N'COLUMN',
    @level2name = N'BankID'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Eintritt in den SKC Markelsheim',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Mitglieder',
    @level2type = N'COLUMN',
    @level2name = N'EintrittSKC'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Eintritt in den WKBV',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Mitglieder',
    @level2type = N'COLUMN',
    @level2name = N'EintrittWKBV'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Frühere Mitgliedschaften im WKBV',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Mitglieder',
    @level2type = N'COLUMN',
    @level2name = N'WKBVFrüher'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Handynummer',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Mitglieder',
    @level2type = N'COLUMN',
    @level2name = N'HandyNr'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Festnetznummer',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Mitglieder',
    @level2type = N'COLUMN',
    @level2name = N'TelefonNr'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Faxnummer',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Mitglieder',
    @level2type = N'COLUMN',
    @level2name = N'Fax'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'PassNr im WKBV bzw. DKBC',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Mitglieder',
    @level2type = N'COLUMN',
    @level2name = N'PassNr'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'MailAdresse',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Mitglieder',
    @level2type = N'COLUMN',
    @level2name = N'EMail'
GO

CREATE UNIQUE INDEX [IX_Mitglieder_Id] ON [dbo].[Mitglieder] (Id)
