CREATE TABLE [dbo].[KemlarOut]
(
	[TriggerId] INT NOT NULL PRIMARY KEY, 
    [Plate] NCHAR(10) NOT NULL, 
    [KemlarCode] NCHAR(10) NOT NULL, 
    [InTime] NCHAR(10) NOT NULL, 
    [OutTime] NCHAR(10) NOT NULL, 
    [InLane] NCHAR(10) NOT NULL, 
    [OutLane] NCHAR(10) NOT NULL
)
