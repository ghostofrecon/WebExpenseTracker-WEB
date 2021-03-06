USE [master]
GO
/****** Object:  Database [WebExpenseTracker]    Script Date: 5/14/2016 5:04:04 PM ******/
CREATE DATABASE [WebExpenseTracker]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WebExpenseTracker', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQL2012\MSSQL\DATA\WebExpenseTracker.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'WebExpenseTracker_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQL2012\MSSQL\DATA\WebExpenseTracker_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [WebExpenseTracker] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WebExpenseTracker].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WebExpenseTracker] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WebExpenseTracker] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WebExpenseTracker] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WebExpenseTracker] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WebExpenseTracker] SET ARITHABORT OFF 
GO
ALTER DATABASE [WebExpenseTracker] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WebExpenseTracker] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [WebExpenseTracker] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WebExpenseTracker] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WebExpenseTracker] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WebExpenseTracker] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WebExpenseTracker] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WebExpenseTracker] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WebExpenseTracker] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WebExpenseTracker] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WebExpenseTracker] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WebExpenseTracker] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WebExpenseTracker] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WebExpenseTracker] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WebExpenseTracker] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WebExpenseTracker] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WebExpenseTracker] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WebExpenseTracker] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WebExpenseTracker] SET RECOVERY FULL 
GO
ALTER DATABASE [WebExpenseTracker] SET  MULTI_USER 
GO
ALTER DATABASE [WebExpenseTracker] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WebExpenseTracker] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WebExpenseTracker] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WebExpenseTracker] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'WebExpenseTracker', N'ON'
GO
USE [WebExpenseTracker]
GO
/****** Object:  User [webtrackerlogin]    Script Date: 5/14/2016 5:04:04 PM ******/
CREATE USER [webtrackerlogin] FOR LOGIN [webtrackerlogin] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [webtrackerlogin]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 5/14/2016 5:04:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[RoleId] [nvarchar](450) NULL,
 CONSTRAINT [PK_IdentityRoleClaim<string>] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 5/14/2016 5:04:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
 CONSTRAINT [PK_IdentityRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 5/14/2016 5:04:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NULL,
 CONSTRAINT [PK_IdentityUserClaim<string>] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 5/14/2016 5:04:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NULL,
 CONSTRAINT [PK_IdentityUserLogin<string>] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 5/14/2016 5:04:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_IdentityUserRole<string>] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 5/14/2016 5:04:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[UserName] [nvarchar](256) NULL,
 CONSTRAINT [PK_ApplicationUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FundSources]    Script Date: 5/14/2016 5:04:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FundSources](
	[FundSourceID] [int] IDENTITY(1,1) NOT NULL,
	[FundSourceUserID] [nvarchar](450) NOT NULL,
	[FundSourceName] [nvarchar](100) NOT NULL,
	[FundSourceDTS] [datetime] NOT NULL,
	[FundSourceDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_FundSources] PRIMARY KEY CLUSTERED 
(
	[FundSourceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tags]    Script Date: 5/14/2016 5:04:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[TagID] [int] IDENTITY(1,1) NOT NULL,
	[TagName] [nvarchar](50) NOT NULL,
	[TagUserID] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[TagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 5/14/2016 5:04:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[TransactionID] [int] IDENTITY(1,1) NOT NULL,
	[TransactionDTS] [datetime] NOT NULL,
	[TransactionUserID] [nvarchar](450) NOT NULL,
	[TransactionIsCredit] [bit] NOT NULL,
	[TransactionAmount] [float] NOT NULL,
	[TransactionFundSourceID] [int] NOT NULL,
	[TransactionDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TransactionTags]    Script Date: 5/14/2016 5:04:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionTags](
	[TransactionTagID] [int] IDENTITY(1,1) NOT NULL,
	[TransactionID] [int] NOT NULL,
	[TagID] [int] NOT NULL,
 CONSTRAINT [PK_TransactionTags] PRIMARY KEY CLUSTERED 
(
	[TransactionTagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 5/14/2016 5:04:04 PM ******/
CREATE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [EmailIndex]    Script Date: 5/14/2016 5:04:04 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 5/14/2016 5:04:04 PM ******/
CREATE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TransactionTags]    Script Date: 5/14/2016 5:04:04 PM ******/
CREATE NONCLUSTERED INDEX [IX_TransactionTags] ON [dbo].[TransactionTags]
(
	[TransactionTagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FundSources] ADD  CONSTRAINT [DF_FundSources_FundSourceDeleted]  DEFAULT ((0)) FOR [FundSourceDeleted]
GO
ALTER TABLE [dbo].[Transactions] ADD  CONSTRAINT [DF_Transaction_TransactionIsCredit]  DEFAULT ((0)) FOR [TransactionIsCredit]
GO
ALTER TABLE [dbo].[Transactions] ADD  CONSTRAINT [DF_Transaction_TransactionDeleted]  DEFAULT ((0)) FOR [TransactionDeleted]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_IdentityRoleClaim<string>_IdentityRole_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_IdentityRoleClaim<string>_IdentityRole_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_IdentityUserClaim<string>_ApplicationUser_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_IdentityUserClaim<string>_ApplicationUser_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_IdentityUserLogin<string>_ApplicationUser_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_IdentityUserLogin<string>_ApplicationUser_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_IdentityUserRole<string>_ApplicationUser_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_IdentityUserRole<string>_ApplicationUser_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_IdentityUserRole<string>_IdentityRole_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_IdentityUserRole<string>_IdentityRole_RoleId]
GO
ALTER TABLE [dbo].[FundSources]  WITH CHECK ADD  CONSTRAINT [FK_FundSources_AspNetUsers] FOREIGN KEY([FundSourceUserID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[FundSources] CHECK CONSTRAINT [FK_FundSources_AspNetUsers]
GO
ALTER TABLE [dbo].[Tags]  WITH CHECK ADD  CONSTRAINT [FK_Tags_AspNetUsers] FOREIGN KEY([TagUserID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Tags] CHECK CONSTRAINT [FK_Tags_AspNetUsers]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_AspNetUsers] FOREIGN KEY([TransactionUserID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_AspNetUsers]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_FundSources] FOREIGN KEY([TransactionFundSourceID])
REFERENCES [dbo].[FundSources] ([FundSourceID])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_FundSources]
GO
ALTER TABLE [dbo].[TransactionTags]  WITH CHECK ADD  CONSTRAINT [FK_TransactionTags_Tags] FOREIGN KEY([TransactionTagID])
REFERENCES [dbo].[Tags] ([TagID])
GO
ALTER TABLE [dbo].[TransactionTags] CHECK CONSTRAINT [FK_TransactionTags_Tags]
GO
ALTER TABLE [dbo].[TransactionTags]  WITH CHECK ADD  CONSTRAINT [FK_TransactionTags_Transactions] FOREIGN KEY([TransactionID])
REFERENCES [dbo].[Transactions] ([TransactionID])
GO
ALTER TABLE [dbo].[TransactionTags] CHECK CONSTRAINT [FK_TransactionTags_Transactions]
GO
USE [master]
GO
ALTER DATABASE [WebExpenseTracker] SET  READ_WRITE 
GO
