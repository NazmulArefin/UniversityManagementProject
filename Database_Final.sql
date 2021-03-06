USE [master]
GO
/****** Object:  Database [UniversityDB]    Script Date: 24-Nov-16 1:21:18 AM ******/
CREATE DATABASE [UniversityDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UniversityDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\UniversityDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UniversityDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\UniversityDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UniversityDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UniversityDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UniversityDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UniversityDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UniversityDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UniversityDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UniversityDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [UniversityDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UniversityDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [UniversityDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UniversityDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UniversityDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UniversityDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UniversityDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UniversityDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UniversityDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UniversityDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UniversityDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UniversityDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UniversityDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UniversityDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UniversityDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UniversityDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UniversityDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UniversityDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UniversityDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UniversityDB] SET  MULTI_USER 
GO
ALTER DATABASE [UniversityDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UniversityDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UniversityDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UniversityDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [UniversityDB]
GO
/****** Object:  Table [dbo].[ClassRoom]    Script Date: 24-Nov-16 1:21:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClassRoom](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomId] [int] NULL,
	[DayId] [int] NULL,
	[FromTime] [varchar](50) NULL,
	[ToTime] [varchar](50) NULL,
	[CourseId] [int] NULL,
	[DepartmentId] [int] NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK_ClassRoom] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Course]    Script Date: 24-Nov-16 1:21:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Course](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CourseCode] [varchar](50) NULL,
	[CourseName] [varchar](50) NULL,
	[Credit] [decimal](3, 2) NULL,
	[Description] [varchar](50) NULL,
	[DepartmentId] [int] NULL,
	[Semester] [varchar](10) NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CourseAssign]    Script Date: 24-Nov-16 1:21:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CourseAssign](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NULL,
	[TeacherId] [int] NULL,
	[CourseId] [int] NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK_CourseAssign] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Day]    Script Date: 24-Nov-16 1:21:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Day](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DayName] [varchar](50) NULL,
 CONSTRAINT [PK_Day] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Department]    Script Date: 24-Nov-16 1:21:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentCode] [varchar](7) NULL,
	[DepartmentName] [varchar](50) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Room]    Script Date: 24-Nov-16 1:21:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Room](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomNo] [varchar](50) NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Semester]    Script Date: 24-Nov-16 1:21:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Semester](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Semesters] [varchar](50) NULL,
 CONSTRAINT [PK_Semester] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Student]    Script Date: 24-Nov-16 1:21:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentName] [varchar](20) NULL,
	[Email] [varchar](50) NULL,
	[ContactNo] [varchar](50) NULL,
	[Date] [date] NULL,
	[Address] [varchar](50) NULL,
	[DepartmentId] [int] NULL,
	[RegistrationNo] [varchar](50) NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentCourse]    Script Date: 24-Nov-16 1:21:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentCourse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NULL,
	[DepartmentId] [int] NULL,
	[CourseId] [int] NULL,
	[Grade] [varchar](50) NULL,
	[Date] [date] NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK_StudentCourse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 24-Nov-16 1:21:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Teacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeacherName] [varchar](150) NULL,
	[Email] [varchar](50) NULL,
	[ContactNo] [varchar](50) NULL,
	[Address] [varchar](250) NULL,
	[Designation] [varchar](100) NULL,
	[DepartmentId] [int] NULL,
	[CreditToBeTaken] [decimal](5, 3) NULL,
	[RemainCredit] [decimal](5, 3) NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[ClassScheduleAndRoomAllocation]    Script Date: 24-Nov-16 1:21:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ClassScheduleAndRoomAllocation] AS
SELECT cl.Id ClassRoomID,cl.FromTime,cl.ToTime,co.Id CourseId,co.CourseName,co.CourseCode,r.Id RoomId,r.RoomNo,d.Id DayId,d.DayName,de.Id DepartmentId

FROM ClassRoom cl JOIN Course co ON cl.CourseId=co.Id JOIN Room r ON r.Id=cl.RoomId JOIN Day d ON d.Id=cl.DayId JOIN Department de ON de.Id=cl.DepartmentId






GO
SET IDENTITY_INSERT [dbo].[ClassRoom] ON 

INSERT [dbo].[ClassRoom] ([Id], [RoomId], [DayId], [FromTime], [ToTime], [CourseId], [DepartmentId], [Status]) VALUES (1, 1, 1, N'8:00 AM', N'10:00 AM', 1, 1, N'UnAllocate')
INSERT [dbo].[ClassRoom] ([Id], [RoomId], [DayId], [FromTime], [ToTime], [CourseId], [DepartmentId], [Status]) VALUES (3, 2, 1, N'9:00 AM', N'11:00 AM', 2, 1, N'UnAllocate')
INSERT [dbo].[ClassRoom] ([Id], [RoomId], [DayId], [FromTime], [ToTime], [CourseId], [DepartmentId], [Status]) VALUES (4, 1, 1, N'8:00 AM', N'10:00 AM', 3, 3, N'Allocate')
SET IDENTITY_INSERT [dbo].[ClassRoom] OFF
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [Credit], [Description], [DepartmentId], [Semester]) VALUES (1, N'CSE101', N'Computer Fundamental', CAST(2.00 AS Decimal(3, 2)), N'Computer Fundamental', 1, N'1st')
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [Credit], [Description], [DepartmentId], [Semester]) VALUES (2, N'CSE102', N'C Programming ', CAST(3.00 AS Decimal(3, 2)), N'C Programming ', 1, N'2nd')
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [Credit], [Description], [DepartmentId], [Semester]) VALUES (3, N'EEE101', N'Electrical Deivce', CAST(2.00 AS Decimal(3, 2)), N'Electrical Deivce', 3, N'2nd')
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [Credit], [Description], [DepartmentId], [Semester]) VALUES (4, N'CSE103', N'C++', CAST(3.00 AS Decimal(3, 2)), N'OOP', 1, N'3rd')
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [Credit], [Description], [DepartmentId], [Semester]) VALUES (5, N'CSE104', N'Data Structure', CAST(3.00 AS Decimal(3, 2)), N'Data Structure', 1, N'3rd')
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [Credit], [Description], [DepartmentId], [Semester]) VALUES (6, N'CSE106', N'Data mining', CAST(3.00 AS Decimal(3, 2)), N'Data mining', 1, N'8th')
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [Credit], [Description], [DepartmentId], [Semester]) VALUES (7, N'CSE108', N'Data Base', CAST(3.00 AS Decimal(3, 2)), N'Data Base', 1, N'5th')
INSERT [dbo].[Course] ([Id], [CourseCode], [CourseName], [Credit], [Description], [DepartmentId], [Semester]) VALUES (8, N'CSE201', N'Java', CAST(3.50 AS Decimal(3, 2)), N'OOP2', 1, N'4th')
SET IDENTITY_INSERT [dbo].[Course] OFF
SET IDENTITY_INSERT [dbo].[CourseAssign] ON 

INSERT [dbo].[CourseAssign] ([Id], [DepartmentId], [TeacherId], [CourseId], [Status]) VALUES (8, 1, 1, 1, N'Unassign')
INSERT [dbo].[CourseAssign] ([Id], [DepartmentId], [TeacherId], [CourseId], [Status]) VALUES (9, 1, 1, 2, N'Unassign')
INSERT [dbo].[CourseAssign] ([Id], [DepartmentId], [TeacherId], [CourseId], [Status]) VALUES (10, 1, 1, 2, N'Assign')
SET IDENTITY_INSERT [dbo].[CourseAssign] OFF
SET IDENTITY_INSERT [dbo].[Day] ON 

INSERT [dbo].[Day] ([Id], [DayName]) VALUES (1, N'Sat')
INSERT [dbo].[Day] ([Id], [DayName]) VALUES (2, N'Sun')
INSERT [dbo].[Day] ([Id], [DayName]) VALUES (3, N'Mon')
INSERT [dbo].[Day] ([Id], [DayName]) VALUES (4, N'Tue')
INSERT [dbo].[Day] ([Id], [DayName]) VALUES (5, N'Wed')
INSERT [dbo].[Day] ([Id], [DayName]) VALUES (6, N'Thu')
INSERT [dbo].[Day] ([Id], [DayName]) VALUES (7, N'Fri')
SET IDENTITY_INSERT [dbo].[Day] OFF
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([Id], [DepartmentCode], [DepartmentName]) VALUES (2, N'BBA', N'Bachelor of Business Adminstration')
INSERT [dbo].[Department] ([Id], [DepartmentCode], [DepartmentName]) VALUES (1, N'CSE', N'Computer Science and Engineering')
INSERT [dbo].[Department] ([Id], [DepartmentCode], [DepartmentName]) VALUES (3, N'EEE', N'Electrical and Electronics Engineering ')
INSERT [dbo].[Department] ([Id], [DepartmentCode], [DepartmentName]) VALUES (4, N'ETE', N'Electronics and Telecommunication Engineerng')
INSERT [dbo].[Department] ([Id], [DepartmentCode], [DepartmentName]) VALUES (5, N'PHY', N'Physics')
SET IDENTITY_INSERT [dbo].[Department] OFF
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (1, N'101')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (2, N'102')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (3, N'103')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (4, N'201')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (5, N'202')
SET IDENTITY_INSERT [dbo].[Room] OFF
SET IDENTITY_INSERT [dbo].[Semester] ON 

INSERT [dbo].[Semester] ([Id], [Semesters]) VALUES (1, N'1st')
INSERT [dbo].[Semester] ([Id], [Semesters]) VALUES (2, N'2nd')
INSERT [dbo].[Semester] ([Id], [Semesters]) VALUES (3, N'3rd')
INSERT [dbo].[Semester] ([Id], [Semesters]) VALUES (4, N'4th')
INSERT [dbo].[Semester] ([Id], [Semesters]) VALUES (5, N'5th')
INSERT [dbo].[Semester] ([Id], [Semesters]) VALUES (6, N'6th')
INSERT [dbo].[Semester] ([Id], [Semesters]) VALUES (7, N'7th')
INSERT [dbo].[Semester] ([Id], [Semesters]) VALUES (8, N'8th')
INSERT [dbo].[Semester] ([Id], [Semesters]) VALUES (9, N'9th')
SET IDENTITY_INSERT [dbo].[Semester] OFF
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([Id], [StudentName], [Email], [ContactNo], [Date], [Address], [DepartmentId], [RegistrationNo]) VALUES (1, N'Khaled Emon', N'khaled@gmail.com', N'01832220182', CAST(0x153C0B00 AS Date), N'ctg', 1, N'CSE-2016-001')
INSERT [dbo].[Student] ([Id], [StudentName], [Email], [ContactNo], [Date], [Address], [DepartmentId], [RegistrationNo]) VALUES (2, N'Ranvir', N'ranvir@gmail.com', N'018493822225', CAST(0x213C0B00 AS Date), N'ctg', 3, N'EEE-2016-001')
INSERT [dbo].[Student] ([Id], [StudentName], [Email], [ContactNo], [Date], [Address], [DepartmentId], [RegistrationNo]) VALUES (3, N'Kofil', N'kofil@gmail.com', N'018493822224', CAST(0xA03A0B00 AS Date), N'ctg', 1, N'CSE-2015-001')
INSERT [dbo].[Student] ([Id], [StudentName], [Email], [ContactNo], [Date], [Address], [DepartmentId], [RegistrationNo]) VALUES (4, N'Sufi', N'sufi@gmail.com', N'018493822224', CAST(0xA13A0B00 AS Date), N'ctg', 1, N'CSE-2015-002')
INSERT [dbo].[Student] ([Id], [StudentName], [Email], [ContactNo], [Date], [Address], [DepartmentId], [RegistrationNo]) VALUES (6, N'Sufi', N'arefin@gmail.com', N'018493822224', CAST(0x223C0B00 AS Date), N'ctg', 1, N'CSE-2016-002')
INSERT [dbo].[Student] ([Id], [StudentName], [Email], [ContactNo], [Date], [Address], [DepartmentId], [RegistrationNo]) VALUES (7, N'Sufi', N'nazmul.arefin.85@gmail.com', N'018493822224', CAST(0x223C0B00 AS Date), N'ctg', 1, N'CSE-2016-003')
INSERT [dbo].[Student] ([Id], [StudentName], [Email], [ContactNo], [Date], [Address], [DepartmentId], [RegistrationNo]) VALUES (8, N'Kofil', N'sufi.kafilll@gmil.com', N'298428289393', CAST(0x223C0B00 AS Date), N'ctg', 1, N'CSE-2016-004')
SET IDENTITY_INSERT [dbo].[Student] OFF
SET IDENTITY_INSERT [dbo].[StudentCourse] ON 

INSERT [dbo].[StudentCourse] ([Id], [StudentId], [DepartmentId], [CourseId], [Grade], [Date], [Status]) VALUES (19, 1, 1, 1, N'A', CAST(0x0C3C0B00 AS Date), N'assigned')
INSERT [dbo].[StudentCourse] ([Id], [StudentId], [DepartmentId], [CourseId], [Grade], [Date], [Status]) VALUES (20, 1, 1, 2, N'A', CAST(0x0C3C0B00 AS Date), N'assigned')
INSERT [dbo].[StudentCourse] ([Id], [StudentId], [DepartmentId], [CourseId], [Grade], [Date], [Status]) VALUES (21, 1, 1, 4, N'Not Graded Yet', CAST(0x0C3C0B00 AS Date), N'assigned')
INSERT [dbo].[StudentCourse] ([Id], [StudentId], [DepartmentId], [CourseId], [Grade], [Date], [Status]) VALUES (22, 1, 1, 5, N'Not Graded Yet', CAST(0x0C3C0B00 AS Date), N'unassign')
INSERT [dbo].[StudentCourse] ([Id], [StudentId], [DepartmentId], [CourseId], [Grade], [Date], [Status]) VALUES (23, 1, 1, 6, N'Not Graded Yet', CAST(0x0C3C0B00 AS Date), N'unassign')
SET IDENTITY_INSERT [dbo].[StudentCourse] OFF
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([Id], [TeacherName], [Email], [ContactNo], [Address], [Designation], [DepartmentId], [CreditToBeTaken], [RemainCredit]) VALUES (1, N'Muntasir Jamal', N'muntasir@gmail.com', N'01345695212', N'Ctg', N'Professor', 1, CAST(15.000 AS Decimal(5, 3)), CAST(12.000 AS Decimal(5, 3)))
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Email], [ContactNo], [Address], [Designation], [DepartmentId], [CreditToBeTaken], [RemainCredit]) VALUES (2, N'Nazmul Arefin', N'nazmul.arefin@gmail.com', N'01836095554', N'ctg', N'Lecturer', 1, CAST(15.000 AS Decimal(5, 3)), CAST(15.000 AS Decimal(5, 3)))
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Email], [ContactNo], [Address], [Designation], [DepartmentId], [CreditToBeTaken], [RemainCredit]) VALUES (3, N'sufi', N'sufi@gmail.com', N'01849382222', N'ctg', N'Professor', 3, CAST(20.000 AS Decimal(5, 3)), CAST(20.000 AS Decimal(5, 3)))
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Email], [ContactNo], [Address], [Designation], [DepartmentId], [CreditToBeTaken], [RemainCredit]) VALUES (4, N'Kofil', N'kofil@gmail.com', N'82222412154', N'ctg', N'Professor', 3, CAST(20.000 AS Decimal(5, 3)), CAST(20.000 AS Decimal(5, 3)))
SET IDENTITY_INSERT [dbo].[Teacher] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Course]    Script Date: 24-Nov-16 1:21:18 AM ******/
CREATE NONCLUSTERED INDEX [IX_Course] ON [dbo].[Course]
(
	[CourseCode] ASC,
	[CourseName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Department]    Script Date: 24-Nov-16 1:21:18 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Department] ON [dbo].[Department]
(
	[DepartmentCode] ASC,
	[DepartmentName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Student]    Script Date: 24-Nov-16 1:21:18 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Student] ON [dbo].[Student]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Teacher]    Script Date: 24-Nov-16 1:21:18 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Teacher] ON [dbo].[Teacher]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ClassRoom]  WITH CHECK ADD  CONSTRAINT [FK_ClassRoom_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[ClassRoom] CHECK CONSTRAINT [FK_ClassRoom_Course]
GO
ALTER TABLE [dbo].[ClassRoom]  WITH CHECK ADD  CONSTRAINT [FK_ClassRoom_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[ClassRoom] CHECK CONSTRAINT [FK_ClassRoom_Department]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Department]
GO
ALTER TABLE [dbo].[CourseAssign]  WITH CHECK ADD  CONSTRAINT [FK_CourseAssign_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[CourseAssign] CHECK CONSTRAINT [FK_CourseAssign_Course]
GO
ALTER TABLE [dbo].[CourseAssign]  WITH CHECK ADD  CONSTRAINT [FK_CourseAssign_CourseAssign] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[CourseAssign] CHECK CONSTRAINT [FK_CourseAssign_CourseAssign]
GO
ALTER TABLE [dbo].[CourseAssign]  WITH CHECK ADD  CONSTRAINT [FK_CourseAssign_Teacher] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teacher] ([Id])
GO
ALTER TABLE [dbo].[CourseAssign] CHECK CONSTRAINT [FK_CourseAssign_Teacher]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Department]
GO
ALTER TABLE [dbo].[StudentCourse]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourse_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[StudentCourse] CHECK CONSTRAINT [FK_StudentCourse_Course]
GO
ALTER TABLE [dbo].[StudentCourse]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourse_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[StudentCourse] CHECK CONSTRAINT [FK_StudentCourse_Department]
GO
ALTER TABLE [dbo].[StudentCourse]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourse_StudentCourse1] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[StudentCourse] CHECK CONSTRAINT [FK_StudentCourse_StudentCourse1]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Department]
GO
USE [master]
GO
ALTER DATABASE [UniversityDB] SET  READ_WRITE 
GO
