CREATE TABLE [dbo].[Patients]
(
	[PatientID] INT NOT NULL  IDENTITY,
	[NHSNumber] int NOT NULL,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL, 
    [DOB] DATE NOT NULL, 
    [Address] NVARCHAR(50) NOT NULL, 
    [MedicalCondition] NVARCHAR(50) NULL, 
    PRIMARY KEY ([NHSNumber]),
)
