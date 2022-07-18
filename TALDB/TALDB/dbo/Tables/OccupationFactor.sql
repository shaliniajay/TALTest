CREATE TABLE [dbo].[OccupationFactor] (
    [OccupationFactorID] INT           IDENTITY (1, 1) NOT NULL,
    [Name]               VARCHAR (100) NULL,
    [Factor]             FLOAT (53)    NULL,
    PRIMARY KEY CLUSTERED ([OccupationFactorID] ASC)
);

