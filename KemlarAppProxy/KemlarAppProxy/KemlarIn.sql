CREATE TABLE [dbo].[KemlarIn]
(
	[TriggerId] INT NOT NULL PRIMARY KEY, 
    [Plate] NCHAR(10) NOT NULL, 
    [KemlarCode] NCHAR(10) NOT NULL, 
    [InTime] DATETIME NOT NULL, 
    [Lane] NCHAR(10) NOT NULL
)
