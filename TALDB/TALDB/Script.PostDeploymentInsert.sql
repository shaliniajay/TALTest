/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


INSERT INTO [dbo].[Occupation] (OccupationID, Name, OccupationFactorID)
VALUES
    (1,'Cleaner',3),
    (2,'Doctor',1 ),
    (3,'Author',2),
     (4,'Farmer',4),
      (5,'Mechanic',4),
       (6,'Florist',3)

INSERT INTO [dbo].[Occupation] (OccupationFactorID, Name, Factor)
VALUES
    (1,'Professional',1),
    (2,'White Collar',1.25 ),
    (3,'Light Manual',1.5),
     (4,'Heavy Manual',1.75)
