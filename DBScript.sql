
/****** Object:  Database [DAWN-MF]    Script Date: 21-11-2022 7.09.18 PM ******/
CREATE DATABASE [DAWN-MF]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AIA-CRM', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\DAWN-MF.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AIA-CRM_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\DAWN-MF_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DAWN-MF] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DAWN-MF].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DAWN-MF] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DAWN-MF] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DAWN-MF] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DAWN-MF] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DAWN-MF] SET ARITHABORT OFF 
GO
ALTER DATABASE [DAWN-MF] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DAWN-MF] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DAWN-MF] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DAWN-MF] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DAWN-MF] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DAWN-MF] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DAWN-MF] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DAWN-MF] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DAWN-MF] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DAWN-MF] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DAWN-MF] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DAWN-MF] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DAWN-MF] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DAWN-MF] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DAWN-MF] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DAWN-MF] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DAWN-MF] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DAWN-MF] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DAWN-MF] SET  MULTI_USER 
GO
ALTER DATABASE [DAWN-MF] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DAWN-MF] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DAWN-MF] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DAWN-MF] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DAWN-MF] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DAWN-MF] SET QUERY_STORE = OFF
GO
USE [DAWN-MF]
GO
/****** Object:  User [IIS APPPOOL\DefaultAppPool]    Script Date: 21-11-2022 7.09.19 PM ******/
CREATE USER [IIS APPPOOL\DefaultAppPool] FOR LOGIN [IIS APPPOOL\DefaultAppPool] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 21-11-2022 7.09.19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoryMasters]    Script Date: 21-11-2022 7.09.19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryMasters](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.CategoryMasters] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KnowledgeCenters]    Script Date: 21-11-2022 7.09.19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KnowledgeCenters](
	[KnowledgeId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [varchar](50) NULL,
	[SubCategoryId] [varchar](50) NULL,
	[SubSubCategoryId] [varchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[FileURL] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.KnowledgeCenters] PRIMARY KEY CLUSTERED 
(
	[KnowledgeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 21-11-2022 7.09.19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SRManagements]    Script Date: 21-11-2022 7.09.19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SRManagements](
	[SRId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](max) NULL,
	[PhoneNo] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[AgentName] [nvarchar](max) NULL,
	[RequestComplaintDetails] [nvarchar](max) NULL,
	[Category] [nvarchar](max) NULL,
	[SubCategory] [nvarchar](max) NULL,
	[SubSubCategory] [nvarchar](max) NULL,
	[Remark] [nvarchar](max) NULL,
	[TicketOpenDate] [datetime] NULL,
	[TicketCloseDate] [datetime] NULL,
	[TicketOpenAgentName] [nvarchar](max) NULL,
	[TicketCloseAgentName] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NULL,
	[TypeOfCaller] [nvarchar](max) NULL,
	[CustomerSegment] [nvarchar](max) NULL,
	[TypeOfCall] [nvarchar](max) NULL,
	[ResoluctionFeedback] [nvarchar](max) NULL,
	[NatureofComplaints] [nvarchar](500) NULL,
	[Address] [nvarchar](max) NULL,
	[BranchName] [nvarchar](500) NULL,
	[BranchOther] [nvarchar](500) NULL,
	[TypeOfCallerOther] [nvarchar](500) NULL,
	[TypeOfProduct] [nvarchar](500) NULL,
	[TypeOfProductOther] [nvarchar](500) NULL,
	[Region] [nvarchar](500) NULL,
	[Town] [nvarchar](500) NULL,
	[TypeOfBusiness] [nvarchar](1000) NULL,
	[TypeOfBusinessOther] [nvarchar](1000) NULL,
	[Gender] [nvarchar](50) NULL,
	[RequestForResoluction] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.SRManagements] PRIMARY KEY CLUSTERED 
(
	[SRId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubCategoryMasters]    Script Date: 21-11-2022 7.09.19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubCategoryMasters](
	[SubCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[SubCategoryName] [nvarchar](max) NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.SubCategoryMasters] PRIMARY KEY CLUSTERED 
(
	[SubCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubSubCategoryMasters]    Script Date: 21-11-2022 7.09.19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubSubCategoryMasters](
	[SubSubCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[SubSubCategoryName] [nvarchar](max) NULL,
	[SubCategoryId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.SubSubCategoryMasters] PRIMARY KEY CLUSTERED 
(
	[SubSubCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TicketManagements]    Script Date: 21-11-2022 7.09.19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TicketManagements](
	[TicketId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[CallingNumber] [nvarchar](max) NULL,
	[TypeOfCaller] [nvarchar](max) NULL,
	[CustomerSegment] [nvarchar](max) NULL,
	[TypeOfCall] [nvarchar](max) NULL,
	[Category] [nvarchar](max) NULL,
	[SubCategory] [nvarchar](max) NULL,
	[SubSubCategory] [nvarchar](max) NULL,
	[Remark] [nvarchar](max) NULL,
	[TicketOpenDate] [datetime] NULL,
	[TicketCloseDate] [datetime] NULL,
	[TicketOpenAgentName] [nvarchar](max) NULL,
	[TicketCloseAgentName] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NULL,
	[CollectionDate] [datetime] NULL,
	[ClientId] [nvarchar](500) NULL,
	[BranchName] [nvarchar](max) NULL,
	[CollectionPointNumber] [nvarchar](500) NULL,
	[RepaymentAmount] [nvarchar](500) NULL,
	[DepositeSavingAmount] [nvarchar](500) NULL,
	[WithdrawAmount] [nvarchar](500) NULL,
	[RepaymentVoucher] [nvarchar](500) NULL,
	[MessageFromDawn] [nvarchar](max) NULL,
	[CashIs] [nvarchar](50) NULL,
	[AmountCorrect] [nvarchar](500) NULL,
 CONSTRAINT [PK_dbo.TicketManagements] PRIMARY KEY CLUSTERED 
(
	[TicketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 21-11-2022 7.09.19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[ActivationCode] [uniqueidentifier] NOT NULL,
	[RoleId] [int] NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CategoryMasters] ON 
GO
INSERT [dbo].[CategoryMasters] ([CategoryId], [CategoryName]) VALUES (1, N'Agent
')
GO
INSERT [dbo].[CategoryMasters] ([CategoryId], [CategoryName]) VALUES (2, N'Application
')
GO
INSERT [dbo].[CategoryMasters] ([CategoryId], [CategoryName]) VALUES (3, N'Campaign/ Initiative
')
GO
INSERT [dbo].[CategoryMasters] ([CategoryId], [CategoryName]) VALUES (4, N'Claim')
GO
INSERT [dbo].[CategoryMasters] ([CategoryId], [CategoryName]) VALUES (5, N'Complaint
')
GO
INSERT [dbo].[CategoryMasters] ([CategoryId], [CategoryName]) VALUES (6, N'General Enquiry')
GO
INSERT [dbo].[CategoryMasters] ([CategoryId], [CategoryName]) VALUES (7, N'Outbound Call')
GO
INSERT [dbo].[CategoryMasters] ([CategoryId], [CategoryName]) VALUES (8, N'Policy Enquiry')
GO
INSERT [dbo].[CategoryMasters] ([CategoryId], [CategoryName]) VALUES (9, N'Policy Request')
GO
INSERT [dbo].[CategoryMasters] ([CategoryId], [CategoryName]) VALUES (10, N'Premium')
GO
INSERT [dbo].[CategoryMasters] ([CategoryId], [CategoryName]) VALUES (11, N'Product Enquiry')
GO
INSERT [dbo].[CategoryMasters] ([CategoryId], [CategoryName]) VALUES (12, N'Proposition')
GO
INSERT [dbo].[CategoryMasters] ([CategoryId], [CategoryName]) VALUES (13, N'Ruby Member (VIP)')
GO
INSERT [dbo].[CategoryMasters] ([CategoryId], [CategoryName]) VALUES (14, N'SMS/Email')
GO
INSERT [dbo].[CategoryMasters] ([CategoryId], [CategoryName]) VALUES (15, N'Underwriting , New Business')
GO
SET IDENTITY_INSERT [dbo].[CategoryMasters] OFF
GO
SET IDENTITY_INSERT [dbo].[KnowledgeCenters] ON 
GO
INSERT [dbo].[KnowledgeCenters] ([KnowledgeId], [CategoryId], [SubCategoryId], [SubSubCategoryId], [Description], [FileURL]) VALUES (1, N'1', N'1', N'3', N'test knowledge 1', N'D:\DotNetProject\CallCenterSecure\CallCenterSecure\Uploads\Test_PDF_File3.pdf')
GO
INSERT [dbo].[KnowledgeCenters] ([KnowledgeId], [CategoryId], [SubCategoryId], [SubSubCategoryId], [Description], [FileURL]) VALUES (2, N'5', N'53', N'113', N'test pdf', N'D:\DotNetProject\CallCenterSecure\CallCenterSecure\Uploads\Test_PDF_File1.pdf')
GO
SET IDENTITY_INSERT [dbo].[KnowledgeCenters] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (1, N'Admin')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (2, N'Supervisor')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (3, N'Agent')
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[SRManagements] ON 
GO
INSERT [dbo].[SRManagements] ([SRId], [CustomerName], [PhoneNo], [Email], [AgentName], [RequestComplaintDetails], [Category], [SubCategory], [SubSubCategory], [Remark], [TicketOpenDate], [TicketCloseDate], [TicketOpenAgentName], [TicketCloseAgentName], [Status], [TypeOfCaller], [CustomerSegment], [TypeOfCall], [ResoluctionFeedback], [NatureofComplaints], [Address], [BranchName], [BranchOther], [TypeOfCallerOther], [TypeOfProduct], [TypeOfProductOther], [Region], [Town], [TypeOfBusiness], [TypeOfBusinessOther], [Gender], [RequestForResoluction]) VALUES (1, N'Gajanan Shinde', N'9896065527', NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2022-11-18T11:47:39.553' AS DateTime), NULL, N'admin', NULL, N'Open', N'', N'IndividualLendingClient', N'Complaint', NULL, N'ServiceDelay', N'Moshi', N'Branch1', NULL, NULL, N'', NULL, N'', N'', N'', NULL, N'', N'Request for Resolution')
GO
INSERT [dbo].[SRManagements] ([SRId], [CustomerName], [PhoneNo], [Email], [AgentName], [RequestComplaintDetails], [Category], [SubCategory], [SubSubCategory], [Remark], [TicketOpenDate], [TicketCloseDate], [TicketOpenAgentName], [TicketCloseAgentName], [Status], [TypeOfCaller], [CustomerSegment], [TypeOfCall], [ResoluctionFeedback], [NatureofComplaints], [Address], [BranchName], [BranchOther], [TypeOfCallerOther], [TypeOfProduct], [TypeOfProductOther], [Region], [Town], [TypeOfBusiness], [TypeOfBusinessOther], [Gender], [RequestForResoluction]) VALUES (2, N'Test Inbound 1', N'9960500523', NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2022-11-18T11:52:33.853' AS DateTime), NULL, N'admin', NULL, N'Open', N'', N'GroupLendingClient', N'Complaint', NULL, N'NoResponse', N'Baner', N'Other', NULL, NULL, N'', NULL, N'', N'', N'', NULL, N'', N'Request for Resolution')
GO
INSERT [dbo].[SRManagements] ([SRId], [CustomerName], [PhoneNo], [Email], [AgentName], [RequestComplaintDetails], [Category], [SubCategory], [SubSubCategory], [Remark], [TicketOpenDate], [TicketCloseDate], [TicketOpenAgentName], [TicketCloseAgentName], [Status], [TypeOfCaller], [CustomerSegment], [TypeOfCall], [ResoluctionFeedback], [NatureofComplaints], [Address], [BranchName], [BranchOther], [TypeOfCallerOther], [TypeOfProduct], [TypeOfProductOther], [Region], [Town], [TypeOfBusiness], [TypeOfBusinessOther], [Gender], [RequestForResoluction]) VALUES (3, NULL, N'9960500523', N'', N'', NULL, NULL, NULL, NULL, NULL, CAST(N'2022-11-18T12:12:01.240' AS DateTime), NULL, N'admin', NULL, N'Open', N'Products', N'IndividualLendingClient', N'Inquire', NULL, N'ServiceDelay', NULL, N'Branch1', NULL, NULL, N'IndividualLending', NULL, N'Region1', N'Town1', N'Business1', NULL, N'Male', NULL)
GO
INSERT [dbo].[SRManagements] ([SRId], [CustomerName], [PhoneNo], [Email], [AgentName], [RequestComplaintDetails], [Category], [SubCategory], [SubSubCategory], [Remark], [TicketOpenDate], [TicketCloseDate], [TicketOpenAgentName], [TicketCloseAgentName], [Status], [TypeOfCaller], [CustomerSegment], [TypeOfCall], [ResoluctionFeedback], [NatureofComplaints], [Address], [BranchName], [BranchOther], [TypeOfCallerOther], [TypeOfProduct], [TypeOfProductOther], [Region], [Town], [TypeOfBusiness], [TypeOfBusinessOther], [Gender], [RequestForResoluction]) VALUES (4, NULL, N'9953330281', NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2022-11-18T12:14:08.800' AS DateTime), NULL, N'admin', NULL, N'Open', N'BranchPhoneNumber', NULL, N'Inquire', NULL, N'ServiceDelay', NULL, N'Branch1', NULL, N'Other Type Of caller', N'IndividualLending', NULL, N'Region1', N'Town1', N'Business1', NULL, N'Male', NULL)
GO
INSERT [dbo].[SRManagements] ([SRId], [CustomerName], [PhoneNo], [Email], [AgentName], [RequestComplaintDetails], [Category], [SubCategory], [SubSubCategory], [Remark], [TicketOpenDate], [TicketCloseDate], [TicketOpenAgentName], [TicketCloseAgentName], [Status], [TypeOfCaller], [CustomerSegment], [TypeOfCall], [ResoluctionFeedback], [NatureofComplaints], [Address], [BranchName], [BranchOther], [TypeOfCallerOther], [TypeOfProduct], [TypeOfProductOther], [Region], [Town], [TypeOfBusiness], [TypeOfBusinessOther], [Gender], [RequestForResoluction]) VALUES (5, NULL, N'5334534', NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2022-11-18T14:41:58.240' AS DateTime), NULL, N'admin', NULL, N'Open', N'Products', N'IndividualLendingClient', N'Inquire', NULL, N'ServiceDelay', NULL, N'Other', NULL, NULL, N'IndividualLending', NULL, N'Region1', N'Town1', N'Other', N'Business other', N'Male', NULL)
GO
INSERT [dbo].[SRManagements] ([SRId], [CustomerName], [PhoneNo], [Email], [AgentName], [RequestComplaintDetails], [Category], [SubCategory], [SubSubCategory], [Remark], [TicketOpenDate], [TicketCloseDate], [TicketOpenAgentName], [TicketCloseAgentName], [Status], [TypeOfCaller], [CustomerSegment], [TypeOfCall], [ResoluctionFeedback], [NatureofComplaints], [Address], [BranchName], [BranchOther], [TypeOfCallerOther], [TypeOfProduct], [TypeOfProductOther], [Region], [Town], [TypeOfBusiness], [TypeOfBusinessOther], [Gender], [RequestForResoluction]) VALUES (6, N'Test SR SLA', N'9960500523', NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2022-11-21T14:15:40.037' AS DateTime), NULL, N'admin', NULL, N'Open', NULL, N'IndividualLendingClient', N'Complaint', NULL, N'NoResponse', N'asdf', N'Branch1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Request for Resolution')
GO
SET IDENTITY_INSERT [dbo].[SRManagements] OFF
GO
SET IDENTITY_INSERT [dbo].[SubCategoryMasters] ON 
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (1, N'Agent', 1)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (2, N'Campaign/ Initiative', 8)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (3, N'Claim', 9)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (4, N'Complaint', 11)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (5, N'Policy Contract Status Enquriy', 36)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (6, N'iAgent', 3)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (7, N'MyanX app', 3)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (8, N'Auto Debit /Direct Debit', 22)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (9, N'Automatic Premium Loan (APL)', 22)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (10, N'Beneficiary', 22)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (11, N'Billing Frequency', 22)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (12, N'Client Profile Change', 22)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (13, N'Health Renewal', 22)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (14, N'Policy Related', 22)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (15, N'Paid Up', 22)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (16, N'Renewak', 22)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (17, N'Reinstatement', 22)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (18, N'Surrender', 22)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (19, N'Refund', 22)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (20, N'UL Ad Hoc', 22)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (21, N'Policy Holder Change', 22)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (22, N'Payor Change Request', 22)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (23, N'Annual Statement', 22)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (24, N'Policy Surrender', 25)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (25, N'Policy Loan', 25)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (26, N'Policy Paid-up', 25)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (27, N'Premium Refund', 25)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (28, N'Client Profile Change', 25)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (29, N'Billing Change', 25)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (30, N'Auto Debit', 25)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (31, N'Beneficiary Change', 25)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (32, N'Group Life Repalacement', 25)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (33, N'One Health Member Addition/Removal', 25)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (34, N'ACP/APL', 25)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (35, N'Lapse Reinstatement', 25)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (36, N'UL ad hoc Request', 25)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (37, N'Policy Holder Change', 25)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (38, N'Payor Change', 25)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (39, N'Annual Insurance Premium Statement', 25)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (40, N'Health Renewal', 25)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (41, N'2C2P Payment Link Request', 25)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (42, N'Premium Enquiry (After In-Force Policy)', 27)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (43, N'Premium Payment Method', 27)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (44, N'Product Enquiry', 28)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (45, N'Product Enquiry', 29)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (46, N'Product Enquiry', 33)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (47, N'Welcome Call', 17)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (48, N'Call Back', 17)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (49, N'Follow Up Call', 17)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (50, N'Survey Call', 17)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (51, N'Auto Debit /Direct Debit Enquriy', 4)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (52, N'Payment Deduction', 4)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (53, N'APL repayment Enquriy', 5)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (54, N'APL Process Enquriy', 5)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (55, N'APL opt out', 5)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (56, N'Billing Frequency Alternation (Monthly, Quarterly, Semi, Annual)', 7)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (57, N'Client Profile Change Enquiry', 10)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (58, N'Health Renewal Enquiry', 15)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (59, N'Request Forms Enquiry', 12)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (60, N'Policy Certificate Request/Enquiry', 12)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (61, N'Policy Status Check', 26)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (62, N'Policy Loan Enquiry', 24)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (63, N'Paid Up Value Enquiry', 18)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (64, N'Renewal Payment Check (….)', 19)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (65, N'Reinstatement Enquiry (Process , Fee)', 31)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (66, N'Surrender Value Enquiry', 34)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (67, N'Annual Statement Enquiry', 2)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (68, N'Refund Process Enquiry', 30)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (69, N'Member Replacement Request Enquiry', 14)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (70, N'Member Addition/Removal Request Enquiry', 16)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (71, N'UL Ad Hoc Premium Request//Enquiry', 35)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (72, N'Policy Holder Change Request/Enquiry', 23)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (73, N'Payor Change Request/Enquiry', 21)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (74, N'2C2P Payment Link Request/Enquiry', 20)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (75, N'General Enquiry', 13)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (76, N'Enquiry', 32)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (77, N'Ruby Member Propostion', 32)
GO
INSERT [dbo].[SubCategoryMasters] ([SubCategoryId], [SubCategoryName], [CategoryId]) VALUES (78, N'Ruby Member Servicing Request', 32)
GO
SET IDENTITY_INSERT [dbo].[SubCategoryMasters] OFF
GO
SET IDENTITY_INSERT [dbo].[SubSubCategoryMasters] ON 
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (3, N'Agent Commission', 1)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (4, N'New Agent Registration', 1)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (5, N'Agent Campaign/Promotion', 1)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (6, N'Promotion Campaign Enquiry', 2)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (7, N'Promotion Campaign Feedback', 2)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (8, N'Health Care Initative (Medix, Z-Waka)', 2)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (9, N'Claim Benefits', 3)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (10, N'Claim Payment', 3)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (11, N'Claim Procedure/Process (inpatient, outpatient, dead claim etc)', 3)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (12, N'Claim Enquiry', 3)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (13, N'Cashless Claim Enquiry (Ulink)', 3)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (14, N'Agent', 4)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (15, N'AIA Staff', 4)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (16, N'Underwriting Case', 4)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (17, N'Claim Case', 4)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (18, N'Proposition', 4)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (19, N'Payment Check', 5)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (20, N'Policy Status (in-force)', 5)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (21, N'Policy Withdraw', 5)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (22, N'Departmental Information (HR, Marketing, IT etc)', 83)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (23, N'Staff Information', 83)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (24, N'Government Tax (Policy Stamping Fees)', 83)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (25, N'App Function (Login , Form download,2C2P Tracker, Export contract etc)', 7)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (26, N'Portal Function', 7)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (27, N'How to Download', 8)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (28, N'Claim Process/Function', 8)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (29, N'Registration (how to register, registration error)', 8)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (30, N'Log In ( No OTP Code , forget passward)', 8)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (31, N'Proposition Check', 8)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (32, N'Transaction Check (claim payment )', 8)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (33, N'Change Request', 8)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (34, N'Auto Debit /Direct Debit Enquriy', 9)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (35, N'Payment Deduction', 9)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (36, N'APL repayment Enquriy', 10)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (37, N'APL Process Enquriy', 10)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (38, N'APL off out', 10)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (39, N'Beneficiary Alternation (add/remove or edit)', 11)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (40, N'Billing Frequency Alternation (Monthly, Quarterly, Semi, Annual)', 12)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (41, N'Client Profile Change Enquiry', 13)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (42, N'Health Renewal Enquiry', 14)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (43, N'Policy Form Request', 15)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (44, N'Policy Certificate Request', 15)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (45, N'Policy Status Check', 15)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (46, N'Policy Loan Enquiry', 15)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (47, N'Paid Up Value Enquiry', 16)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (48, N'Renewal Payment Check (….)', 17)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (49, N'Reinstatement Enquiry (Process , Fee)', 18)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (50, N'Surrender Value Enquiry', 19)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (51, N'Refund Process Enqiury', 20)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (52, N'UL Ad Hoc Premium Enquiry', 21)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (53, N'Policy Holder Change Enquiry', 22)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (54, N'Payor Changenquiry', 23)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (55, N'Annual Statement Enquiry', 24)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (56, N'Surrender Request', 25)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (57, N'Loan Request', 26)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (58, N'Paid Up Request', 27)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (59, N'Refund Request', 28)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (60, N'Client Profile Change Request (name, email, address, phone, gender, marital status/occupation/DoB)', 29)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (61, N'Billing frequency change request', 30)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (62, N'auto debit Request (registration)', 31)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (63, N'auto debit Request (termination)', 31)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (64, N'beneficiary Change Request (add/remove or Edit)', 32)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (65, N'Member Replacement Request', 33)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (66, N'member addition/removal', 34)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (67, N'ACP Repayment Request', 35)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (68, N'APL Off Out Request', 35)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (69, N'reinstatement Request', 36)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (70, N'ad hoc request', 37)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (71, N'Policy Owner change request', 38)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (72, N'Payor change request', 39)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (73, N'annual statement request', 40)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (74, N'Health Renewal Process request', 41)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (75, N'2C2P Payment Link Request', 42)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (76, N'Payment Receipt', 43)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (77, N'Premium Check', 43)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (78, N'Premium Payment', 43)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (79, N'Transaction Check', 43)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (80, N'2C2P Link Request', 43)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (81, N'Annual Premium Statement', 43)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (82, N'Overdue', 43)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (83, N'2C2P', 44)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (84, N'Auto Debit', 44)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (85, N'Bank Counter', 44)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (86, N'Mobile/Internet Banking', 44)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (87, N'Web/Pay Payment', 44)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (88, N'Group Life', 45)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (89, N'Group Health', 45)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (90, N'Health Insurance', 45)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (91, N'One Health Individual', 45)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (92, N'One Health Group', 45)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (93, N'Personal Accident Insurance', 45)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (94, N'Education', 45)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (95, N'Short Term Endowment Insurance', 45)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (96, N'Universal Life Insurance', 45)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (97, N'AIA Partner', 46)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (98, N'Discount', 46)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (99, N'Premium Discount for AIA and Partners', 46)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (100, N'Promotional Campaign', 46)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (101, N'Ruby Member Info', 84)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (102, N'Ruby Member Benefits', 84)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (103, N'Propostional appointments', 85)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (104, N'Enquiry about SMS', 48)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (105, N'Enquiry about Email', 48)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (106, N'Unable to received SMS', 48)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (107, N'Unable to received Enquriy', 48)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (108, N'Welcome Successful', 49)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (109, N'Welcome Failed', 49)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (110, N'Call Back', 50)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (111, N'Follow Up Call', 51)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (112, N'Survey Call', 52)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (113, N'NA', 53)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (114, N'NA', 58)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (115, N'NA', 59)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (116, N'NA', 60)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (117, N'NA', 61)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (118, N'NA', 62)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (119, N'NA', 63)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (120, N'NA', 64)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (121, N'NA', 65)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (122, N'NA', 66)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (123, N'NA', 67)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (124, N'NA', 68)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (125, N'NA', 69)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (126, N'NA', 70)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (127, N'NA', 71)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (128, N'NA', 72)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (129, N'NA', 73)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (130, N'NA', 74)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (131, N'NA', 75)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (132, N'NA', 76)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (133, N'NA', 77)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (134, N'NA', 78)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (135, N'NA', 79)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (136, N'NA', 80)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (137, N'NA', 81)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (138, N'Push App', 2)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (139, N'Office Hours/working day/Address Enquriy', 83)
GO
INSERT [dbo].[SubSubCategoryMasters] ([SubSubCategoryId], [SubSubCategoryName], [SubCategoryId]) VALUES (140, N'Ruby Member Servicing Request', 86)
GO
SET IDENTITY_INSERT [dbo].[SubSubCategoryMasters] OFF
GO
SET IDENTITY_INSERT [dbo].[TicketManagements] ON 
GO
INSERT [dbo].[TicketManagements] ([TicketId], [Name], [CallingNumber], [TypeOfCaller], [CustomerSegment], [TypeOfCall], [Category], [SubCategory], [SubSubCategory], [Remark], [TicketOpenDate], [TicketCloseDate], [TicketOpenAgentName], [TicketCloseAgentName], [Status], [CollectionDate], [ClientId], [BranchName], [CollectionPointNumber], [RepaymentAmount], [DepositeSavingAmount], [WithdrawAmount], [RepaymentVoucher], [MessageFromDawn], [CashIs], [AmountCorrect]) VALUES (0, N'ABCD', N'324567', NULL, NULL, N'GLClients', NULL, NULL, NULL, N'no comments,,', CAST(N'2022-11-15T16:48:08.833' AS DateTime), NULL, N'admin', NULL, N'Open', CAST(N'2022-03-12T00:00:00.000' AS DateTime), NULL, N'Pune', N'6755434', N'19345', N'34354', N'564', N'N/A', N'N/A', N'overdue', N'N/A')
GO
INSERT [dbo].[TicketManagements] ([TicketId], [Name], [CallingNumber], [TypeOfCaller], [CustomerSegment], [TypeOfCall], [Category], [SubCategory], [SubSubCategory], [Remark], [TicketOpenDate], [TicketCloseDate], [TicketOpenAgentName], [TicketCloseAgentName], [Status], [CollectionDate], [ClientId], [BranchName], [CollectionPointNumber], [RepaymentAmount], [DepositeSavingAmount], [WithdrawAmount], [RepaymentVoucher], [MessageFromDawn], [CashIs], [AmountCorrect]) VALUES (1, N'Ramesh', N'35643', NULL, NULL, N'GLClients', NULL, NULL, NULL, N'comments', CAST(N'2022-11-15T17:53:38.843' AS DateTime), NULL, N'admin', NULL, N'Open', CAST(N'2022-03-03T00:00:00.000' AS DateTime), NULL, N'Aundh', N'7542345', N'4334', N'634', N'32', N'Yes', N'Yes', N'prepaid', N'N/A')
GO
INSERT [dbo].[TicketManagements] ([TicketId], [Name], [CallingNumber], [TypeOfCaller], [CustomerSegment], [TypeOfCall], [Category], [SubCategory], [SubSubCategory], [Remark], [TicketOpenDate], [TicketCloseDate], [TicketOpenAgentName], [TicketCloseAgentName], [Status], [CollectionDate], [ClientId], [BranchName], [CollectionPointNumber], [RepaymentAmount], [DepositeSavingAmount], [WithdrawAmount], [RepaymentVoucher], [MessageFromDawn], [CashIs], [AmountCorrect]) VALUES (2, N'Praful', N'7687', NULL, NULL, N'GLClients', NULL, NULL, NULL, N'asdfasd', CAST(N'2022-11-15T18:09:44.707' AS DateTime), NULL, N'admin', NULL, N'Open', CAST(N'2022-03-12T00:00:00.000' AS DateTime), N'134', N'Moshi', N'6755434', N'19345', N'34354', N'564', N'Yes', N'Yes', N'savings', N'N/A')
GO
INSERT [dbo].[TicketManagements] ([TicketId], [Name], [CallingNumber], [TypeOfCaller], [CustomerSegment], [TypeOfCall], [Category], [SubCategory], [SubSubCategory], [Remark], [TicketOpenDate], [TicketCloseDate], [TicketOpenAgentName], [TicketCloseAgentName], [Status], [CollectionDate], [ClientId], [BranchName], [CollectionPointNumber], [RepaymentAmount], [DepositeSavingAmount], [WithdrawAmount], [RepaymentVoucher], [MessageFromDawn], [CashIs], [AmountCorrect]) VALUES (3, N'Praful', N'7687', NULL, NULL, N'GLClients', NULL, NULL, NULL, N'asdfasd', CAST(N'2022-11-15T18:09:43.107' AS DateTime), NULL, N'admin', NULL, N'Open', CAST(N'2022-03-12T00:00:00.000' AS DateTime), NULL, N'Moshi', N'6755434', N'19345', N'34354', N'564', N'Yes', N'Yes', N'savings', N'N/A')
GO
INSERT [dbo].[TicketManagements] ([TicketId], [Name], [CallingNumber], [TypeOfCaller], [CustomerSegment], [TypeOfCall], [Category], [SubCategory], [SubSubCategory], [Remark], [TicketOpenDate], [TicketCloseDate], [TicketOpenAgentName], [TicketCloseAgentName], [Status], [CollectionDate], [ClientId], [BranchName], [CollectionPointNumber], [RepaymentAmount], [DepositeSavingAmount], [WithdrawAmount], [RepaymentVoucher], [MessageFromDawn], [CashIs], [AmountCorrect]) VALUES (4, N'Rahul', N'9896065527', NULL, NULL, N'GLClients', NULL, NULL, NULL, N'as asx asdf', CAST(N'2022-11-15T18:12:28.567' AS DateTime), NULL, N'admin', NULL, N'Open', CAST(N'2022-03-12T00:00:00.000' AS DateTime), N'1234', N'Pune', N'7542345', N'19345', N'634', N'564', N'No', N'No', N'none', N'N/A')
GO
INSERT [dbo].[TicketManagements] ([TicketId], [Name], [CallingNumber], [TypeOfCaller], [CustomerSegment], [TypeOfCall], [Category], [SubCategory], [SubSubCategory], [Remark], [TicketOpenDate], [TicketCloseDate], [TicketOpenAgentName], [TicketCloseAgentName], [Status], [CollectionDate], [ClientId], [BranchName], [CollectionPointNumber], [RepaymentAmount], [DepositeSavingAmount], [WithdrawAmount], [RepaymentVoucher], [MessageFromDawn], [CashIs], [AmountCorrect]) VALUES (5, NULL, NULL, NULL, NULL, N'AllILClients', NULL, NULL, NULL, NULL, CAST(N'2022-11-16T20:29:14.850' AS DateTime), NULL, N'admin', NULL, N'Open', NULL, N'AIL2233', NULL, NULL, NULL, NULL, NULL, N'N/A', N'N/A', N'overdue', N'N/A')
GO
INSERT [dbo].[TicketManagements] ([TicketId], [Name], [CallingNumber], [TypeOfCaller], [CustomerSegment], [TypeOfCall], [Category], [SubCategory], [SubSubCategory], [Remark], [TicketOpenDate], [TicketCloseDate], [TicketOpenAgentName], [TicketCloseAgentName], [Status], [CollectionDate], [ClientId], [BranchName], [CollectionPointNumber], [RepaymentAmount], [DepositeSavingAmount], [WithdrawAmount], [RepaymentVoucher], [MessageFromDawn], [CashIs], [AmountCorrect]) VALUES (6, NULL, NULL, NULL, NULL, N'ILClients', NULL, NULL, NULL, NULL, CAST(N'2022-11-16T20:31:09.883' AS DateTime), NULL, N'admin', NULL, N'Open', NULL, N'ILC334', NULL, NULL, NULL, NULL, NULL, N'No', N'Yes', N'overdue', N'N/A')
GO
SET IDENTITY_INSERT [dbo].[TicketManagements] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserId], [Username], [FirstName], [LastName], [Email], [Password], [IsActive], [ActivationCode], [RoleId]) VALUES (1, N'admin', N'Gajanan', N'Shinde', N'gajananshinde@gmail.com', N'7OHCXNMAhfBlOgD9v9Ireg==', 1, N'5bbd25ad-137e-411f-9afd-b7c5e288bedb', 1)
GO
INSERT [dbo].[Users] ([UserId], [Username], [FirstName], [LastName], [Email], [Password], [IsActive], [ActivationCode], [RoleId]) VALUES (2, N'MiBSCON4322', N'Zin Zin', N'Phyo', N'Mibscon4322@mibs.com.mm', N'7OHCXNMAhfBlOgD9v9Ireg==', 1, N'c8294f5b-e6be-48b5-8259-80cb15eae789', 2)
GO
INSERT [dbo].[Users] ([UserId], [Username], [FirstName], [LastName], [Email], [Password], [IsActive], [ActivationCode], [RoleId]) VALUES (3, N'MiBSCON4320', N'Swe Lynn', N'Myat', N'Mibscon4320@mibs.com.mm', N'Mz63mNWqrQ6U6rAGO65qAKwBBHEJ/JEMlELnj2v+JZ0=', 1, N'8d7f3e68-ef59-4a01-be11-e72116dead6b', 3)
GO
INSERT [dbo].[Users] ([UserId], [Username], [FirstName], [LastName], [Email], [Password], [IsActive], [ActivationCode], [RoleId]) VALUES (4, N'MiBSCON4321', N'Yu Yu', N'Khin', N'Mibscon4321@mibs.com.mm', N'g8retCYiCIET/l6kC7sK/VwastkdIx5RkfFQ2KAJjBY=', 1, N'0fd3d134-bc1c-49bc-8994-25741a9463b7', 3)
GO
INSERT [dbo].[Users] ([UserId], [Username], [FirstName], [LastName], [Email], [Password], [IsActive], [ActivationCode], [RoleId]) VALUES (5, N'MiBSCON4323', N'Zon Pwint', N'Phyu', N'Mibscon4323@mibs.com.mm', N'g8retCYiCIET/l6kC7sK/VwastkdIx5RkfFQ2KAJjBY=', 1, N'7a97813b-0454-4989-bb46-f5340408150b', 3)
GO
INSERT [dbo].[Users] ([UserId], [Username], [FirstName], [LastName], [Email], [Password], [IsActive], [ActivationCode], [RoleId]) VALUES (6, N'MiBSCON4324', N'Wai Wai', N'Lwin', N'Mibscon4324@mibs.com.mm', N'g8retCYiCIET/l6kC7sK/VwastkdIx5RkfFQ2KAJjBY=', 1, N'6302e97b-f105-425b-896b-881596eae281', 2)
GO
INSERT [dbo].[Users] ([UserId], [Username], [FirstName], [LastName], [Email], [Password], [IsActive], [ActivationCode], [RoleId]) VALUES (7, N'MiBSCON0216', N'May Di', N'Soe', N'Mibscon0216@mibs.com.mm', N'g8retCYiCIET/l6kC7sK/VwastkdIx5RkfFQ2KAJjBY=', 0, N'3192a893-2c6c-49e5-8040-2df5aec094ba', 2)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[TicketManagements] ADD  DEFAULT ('1900-01-01') FOR [TicketOpenDate]
GO
ALTER TABLE [dbo].[TicketManagements] ADD  DEFAULT ('1900-01-01') FOR [TicketCloseDate]
GO
USE [master]
GO
ALTER DATABASE [DAWN-MF] SET  READ_WRITE 
GO
