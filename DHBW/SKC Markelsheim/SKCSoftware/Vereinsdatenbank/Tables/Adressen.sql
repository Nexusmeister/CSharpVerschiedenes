CREATE TABLE [dbo].[Adressen] (
    [Id]               INT          IDENTITY (1, 1) NOT NULL,
    [Strasse]          VARCHAR (80) NOT NULL,
    [HausNr]           INT          NOT NULL,
    [OrteId] INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Adressen_Id]
    ON [dbo].[Adressen]([Id] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'AdressenID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Adressen', @level2type = N'COLUMN', @level2name = N'Id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Straßenname', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Adressen', @level2type = N'COLUMN', @level2name = N'Strasse';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Hausnummer', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Adressen', @level2type = N'COLUMN', @level2name = N'HausNr';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Fremdschlüssel auf Orte.ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Adressen', @level2type = N'COLUMN', @level2name = 'OrteId';
