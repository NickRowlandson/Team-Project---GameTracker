CREATE TABLE [dbo].[Games]
(
	[GameID] INT NOT NULL IDENTITY (0, 1) PRIMARY KEY,
	[GameName] [varchar](50),
	[TeamOne] [varchar](50),
	[TeamTwo] [varchar](50),
	[TeamOneScore] [varchar](50),
	[TeamTwoScore] [varchar](50),
	[GameResult] [varchar](50),
	[CalendarWeek] [date] NOT NULL
)

CREATE TABLE [dbo].[AdminUser]
(
	[UserId] INT NOT NULL PRIMARY KEY,
	[Email] [varchar](50),
	[Password] [varchar](50) 
)

INSERT INTO [dbo].[AdminUser] ([UserID], [Email], [Password]) VALUES (01, 'admin@gametrack.com', 'admin')
