CREATE TABLE [dbo].[IncidentReports]
(
	[IncidentID] INT NOT NULL PRIMARY KEY IDENTITY , 
    [PatientNHSNumber] INT NOT NULL, 
    [IncidentDetails] NVARCHAR(50) NULL, 
    [IncidentDate] DATE NULL, 
    [Location] NVARCHAR(50) NULL, 
    [ActionTaken] NVARCHAR(50) NULL, 
    [WaitingTime] FLOAT NULL, 
    [AssignedHospitalID] NVARCHAR(50) NOT NULL, 
    [AssignedAmbulanceID] NVARCHAR(50) NULL, 
    [CaseClosed] BIT NOT NULL, 
    CONSTRAINT [FK_IncidentReports_Patients] FOREIGN KEY ([PatientNHSNumber]) REFERENCES [dbo].[Patients]([NHSNumber]) 
)
