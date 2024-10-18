USE [GraduateTraineeEnrollmentDB]
GO
/****** Object:  StoredProcedure [dbo].[TraineeEnrollmentReport]    Script Date: 4/18/2024 6:51:10 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[TraineeEnrollmentReport]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Streams]') AND type in (N'U'))
ALTER TABLE [dbo].[Streams] DROP CONSTRAINT IF EXISTS [FK__Streams__DegreeI__3D5E1FD2]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GraduateTrainees]') AND type in (N'U'))
ALTER TABLE [dbo].[GraduateTrainees] DROP CONSTRAINT IF EXISTS [FK__GraduateT__Strea__3C69FB99]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GraduateTrainees]') AND type in (N'U'))
ALTER TABLE [dbo].[GraduateTrainees] DROP CONSTRAINT IF EXISTS [FK__GraduateT__Degre__3B75D760]
GO
/****** Object:  Table [dbo].[Streams]    Script Date: 4/18/2024 6:51:10 PM ******/
DROP TABLE IF EXISTS [dbo].[Streams]
GO
/****** Object:  Table [dbo].[GraduateTrainees]    Script Date: 4/18/2024 6:51:10 PM ******/
DROP TABLE IF EXISTS [dbo].[GraduateTrainees]
GO
/****** Object:  Table [dbo].[Degree]    Script Date: 4/18/2024 6:51:10 PM ******/
DROP TABLE IF EXISTS [dbo].[Degree]
GO
/****** Object:  Table [dbo].[Degree]    Script Date: 4/18/2024 6:51:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Degree](
	[DegreeId] [int] IDENTITY(1,1) NOT NULL,
	[DegreeName] [varchar](20) NOT NULL,
	[DegreeDescription] [varchar](100) NULL,
 CONSTRAINT [PK_Degree] PRIMARY KEY CLUSTERED 
(
	[DegreeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GraduateTrainees]    Script Date: 4/18/2024 6:51:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GraduateTrainees](
	[GraduateTraineeId] [int] IDENTITY(1,1) NOT NULL,
	[DegreeId] [int] NULL,
	[StreamId] [int] NULL,
	[TraineeName] [varchar](25) NOT NULL,
	[TraineeEmail] [varchar](25) NOT NULL,
	[UniversityName] [varchar](25) NOT NULL,
	[IsLastSemesterPending] [bit] NOT NULL,
	[Gender] [varchar](1) NOT NULL,
	[DateOfApplication] [date] NOT NULL,
	[Image] [varchar](150) NULL,
	[AI] [decimal](18, 0) NULL,
	[Phyton] [decimal](18, 0) NULL,
	[BusinessAnalysis] [decimal](18, 0) NULL,
	[MachineLearning] [decimal](18, 0) NULL,
	[Practical] [decimal](18, 0) NULL,
	[TotalMarks] [decimal](18, 0) NULL,
	[Percentages] [decimal](18, 0) NULL,
	[IsAdmisisonConfirmed] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[GraduateTraineeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Streams]    Script Date: 4/18/2024 6:51:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Streams](
	[StreamId] [int] IDENTITY(1,1) NOT NULL,
	[StreamName] [varchar](50) NOT NULL,
	[StreamDescription] [varchar](max) NULL,
	[DegreeId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[StreamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Degree] ON 
GO
INSERT [dbo].[Degree] ([DegreeId], [DegreeName], [DegreeDescription]) VALUES (1, N'Bachelor Degree ', N'Any computer programming related bachelor degree')
GO
INSERT [dbo].[Degree] ([DegreeId], [DegreeName], [DegreeDescription]) VALUES (2, N'Master Degree', N'Any computer programming related master degree')
GO
SET IDENTITY_INSERT [dbo].[Degree] OFF
GO
SET IDENTITY_INSERT [dbo].[GraduateTrainees] ON 
GO
INSERT [dbo].[GraduateTrainees] ([GraduateTraineeId], [DegreeId], [StreamId], [TraineeName], [TraineeEmail], [UniversityName], [IsLastSemesterPending], [Gender], [DateOfApplication], [Image], [AI], [Phyton], [BusinessAnalysis], [MachineLearning], [Practical], [TotalMarks], [Percentages], [IsAdmisisonConfirmed]) VALUES (1, 1, 2, N'lav', N'abc@xyz.com', N'gsfc', 1, N'm', CAST(N'2024-04-18' AS Date), N'string', CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), 1)
GO
INSERT [dbo].[GraduateTrainees] ([GraduateTraineeId], [DegreeId], [StreamId], [TraineeName], [TraineeEmail], [UniversityName], [IsLastSemesterPending], [Gender], [DateOfApplication], [Image], [AI], [Phyton], [BusinessAnalysis], [MachineLearning], [Practical], [TotalMarks], [Percentages], [IsAdmisisonConfirmed]) VALUES (2, 1, 1, N'vedant', N'abc@xc.com', N'bvm', 1, N'm', CAST(N'2024-04-18' AS Date), N'string', CAST(50 AS Decimal(18, 0)), CAST(50 AS Decimal(18, 0)), CAST(50 AS Decimal(18, 0)), CAST(50 AS Decimal(18, 0)), CAST(50 AS Decimal(18, 0)), CAST(50 AS Decimal(18, 0)), CAST(50 AS Decimal(18, 0)), 1)
GO
INSERT [dbo].[GraduateTrainees] ([GraduateTraineeId], [DegreeId], [StreamId], [TraineeName], [TraineeEmail], [UniversityName], [IsLastSemesterPending], [Gender], [DateOfApplication], [Image], [AI], [Phyton], [BusinessAnalysis], [MachineLearning], [Practical], [TotalMarks], [Percentages], [IsAdmisisonConfirmed]) VALUES (3, 1, 1, N'smit', N'ab@bj.ckm', N'bvm', 1, N'f', CAST(N'2024-04-18' AS Date), N'string', CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), 1)
GO
INSERT [dbo].[GraduateTrainees] ([GraduateTraineeId], [DegreeId], [StreamId], [TraineeName], [TraineeEmail], [UniversityName], [IsLastSemesterPending], [Gender], [DateOfApplication], [Image], [AI], [Phyton], [BusinessAnalysis], [MachineLearning], [Practical], [TotalMarks], [Percentages], [IsAdmisisonConfirmed]) VALUES (4, 1, 1, N'kashyap', N'abc@sa.com', N'bvm', 1, N'f', CAST(N'2024-04-18' AS Date), N'string', CAST(70 AS Decimal(18, 0)), CAST(70 AS Decimal(18, 0)), CAST(70 AS Decimal(18, 0)), CAST(70 AS Decimal(18, 0)), CAST(70 AS Decimal(18, 0)), CAST(70 AS Decimal(18, 0)), CAST(70 AS Decimal(18, 0)), 1)
GO
INSERT [dbo].[GraduateTrainees] ([GraduateTraineeId], [DegreeId], [StreamId], [TraineeName], [TraineeEmail], [UniversityName], [IsLastSemesterPending], [Gender], [DateOfApplication], [Image], [AI], [Phyton], [BusinessAnalysis], [MachineLearning], [Practical], [TotalMarks], [Percentages], [IsAdmisisonConfirmed]) VALUES (5, 1, 1, N'abhinav', N'abc@b.com', N'gsfc', 1, N'm', CAST(N'2024-04-20' AS Date), N'string', CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), 1)
GO
INSERT [dbo].[GraduateTrainees] ([GraduateTraineeId], [DegreeId], [StreamId], [TraineeName], [TraineeEmail], [UniversityName], [IsLastSemesterPending], [Gender], [DateOfApplication], [Image], [AI], [Phyton], [BusinessAnalysis], [MachineLearning], [Practical], [TotalMarks], [Percentages], [IsAdmisisonConfirmed]) VALUES (6, 1, 1, N'hasrshil', N'abc@b.com', N'gsfc', 1, N'm', CAST(N'2024-04-20' AS Date), N'string', CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), 1)
GO
INSERT [dbo].[GraduateTrainees] ([GraduateTraineeId], [DegreeId], [StreamId], [TraineeName], [TraineeEmail], [UniversityName], [IsLastSemesterPending], [Gender], [DateOfApplication], [Image], [AI], [Phyton], [BusinessAnalysis], [MachineLearning], [Practical], [TotalMarks], [Percentages], [IsAdmisisonConfirmed]) VALUES (7, 1, 1, N'rk', N'abc@b.com', N'gsfc', 1, N'm', CAST(N'2024-04-20' AS Date), N'string', CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), 1)
GO
INSERT [dbo].[GraduateTrainees] ([GraduateTraineeId], [DegreeId], [StreamId], [TraineeName], [TraineeEmail], [UniversityName], [IsLastSemesterPending], [Gender], [DateOfApplication], [Image], [AI], [Phyton], [BusinessAnalysis], [MachineLearning], [Practical], [TotalMarks], [Percentages], [IsAdmisisonConfirmed]) VALUES (9, 2, 2, N'parth', N'pa@dsc.com', N'gsfc', 1, N'f', CAST(N'2024-04-20' AS Date), N'string', CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), 1)
GO
INSERT [dbo].[GraduateTrainees] ([GraduateTraineeId], [DegreeId], [StreamId], [TraineeName], [TraineeEmail], [UniversityName], [IsLastSemesterPending], [Gender], [DateOfApplication], [Image], [AI], [Phyton], [BusinessAnalysis], [MachineLearning], [Practical], [TotalMarks], [Percentages], [IsAdmisisonConfirmed]) VALUES (15, 1, 1, N'tanmay', N'dfg@ghj.com', N'bvm', 1, N'm', CAST(N'2024-04-18' AS Date), N'string', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[GraduateTrainees] ([GraduateTraineeId], [DegreeId], [StreamId], [TraineeName], [TraineeEmail], [UniversityName], [IsLastSemesterPending], [Gender], [DateOfApplication], [Image], [AI], [Phyton], [BusinessAnalysis], [MachineLearning], [Practical], [TotalMarks], [Percentages], [IsAdmisisonConfirmed]) VALUES (16, 1, 1, N'jinal', N'dfg@ghj.com', N'bvm', 0, N'm', CAST(N'2024-04-18' AS Date), N'string', CAST(100 AS Decimal(18, 0)), CAST(100 AS Decimal(18, 0)), CAST(100 AS Decimal(18, 0)), CAST(100 AS Decimal(18, 0)), CAST(100 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(100 AS Decimal(18, 0)), 1)
GO
SET IDENTITY_INSERT [dbo].[GraduateTrainees] OFF
GO
SET IDENTITY_INSERT [dbo].[Streams] ON 
GO
INSERT [dbo].[Streams] ([StreamId], [StreamName], [StreamDescription], [DegreeId]) VALUES (1, N'BCA', N'Bachelor Of Computer Application', 1)
GO
INSERT [dbo].[Streams] ([StreamId], [StreamName], [StreamDescription], [DegreeId]) VALUES (2, N'B-Tech IT', N'Bachelor Of Technology in IT ', 1)
GO
INSERT [dbo].[Streams] ([StreamId], [StreamName], [StreamDescription], [DegreeId]) VALUES (3, N'BE Com Engg', N'Bachelor Of Engineer in Computer ', 1)
GO
INSERT [dbo].[Streams] ([StreamId], [StreamName], [StreamDescription], [DegreeId]) VALUES (4, N'B-Tech CSE', N'Bachelor of Technology in Computer Science and Engineering', 1)
GO
INSERT [dbo].[Streams] ([StreamId], [StreamName], [StreamDescription], [DegreeId]) VALUES (5, N'MCA', N'Master Of Computer Application ', 2)
GO
INSERT [dbo].[Streams] ([StreamId], [StreamName], [StreamDescription], [DegreeId]) VALUES (6, N'M-Tech IT ', N'Master Of Technology in IT', 2)
GO
INSERT [dbo].[Streams] ([StreamId], [StreamName], [StreamDescription], [DegreeId]) VALUES (7, N'ME Com Engg', N'Master Of Engineer in Computer', 2)
GO
INSERT [dbo].[Streams] ([StreamId], [StreamName], [StreamDescription], [DegreeId]) VALUES (8, N'M-Tech CSE', N'Master of Technology in Computer Science and Engineering', 2)
GO
SET IDENTITY_INSERT [dbo].[Streams] OFF
GO
ALTER TABLE [dbo].[GraduateTrainees]  WITH CHECK ADD FOREIGN KEY([DegreeId])
REFERENCES [dbo].[Degree] ([DegreeId])
GO
ALTER TABLE [dbo].[GraduateTrainees]  WITH CHECK ADD FOREIGN KEY([StreamId])
REFERENCES [dbo].[Streams] ([StreamId])
GO
ALTER TABLE [dbo].[Streams]  WITH CHECK ADD FOREIGN KEY([DegreeId])
REFERENCES [dbo].[Degree] ([DegreeId])
GO
/****** Object:  StoredProcedure [dbo].[TraineeEnrollmentReport]    Script Date: 4/18/2024 6:51:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[TraineeEnrollmentReport]
AS
BEGIN
	SELECT d.DegreeName, s.StreamName,COUNT(gt.TraineeName) as TotalTraineeCount  FROM GraduateTrainees gt 
	JOIN Degree d on d.DegreeId = gt.DegreeId
	JOIN Streams s on s.StreamId = gt.StreamId
	GROUP BY d.DegreeName , s.StreamName
END
GO
