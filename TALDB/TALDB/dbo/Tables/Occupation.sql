CREATE TABLE [dbo].[Occupation] (
    [OccupationID]       INT           IDENTITY (1, 1) NOT NULL,
    [Name]               VARCHAR (100) NULL,
    [OccupationFactorID] INT           NULL,
    PRIMARY KEY CLUSTERED ([OccupationID] ASC),
    FOREIGN KEY ([OccupationFactorID]) REFERENCES [dbo].[OccupationFactor] ([OccupationFactorID])
);
