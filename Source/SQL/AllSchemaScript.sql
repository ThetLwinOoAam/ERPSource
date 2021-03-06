USE [BCErpDb]
GO
/****** Object:  Schema [Administration]    Script Date: 01/25/2020 15:52:49 ******/
CREATE SCHEMA [Administration] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [Purchase]    Script Date: 01/25/2020 15:52:49 ******/
CREATE SCHEMA [Purchase] AUTHORIZATION [dbo]
GO
/****** Object:  Table [Administration].[TblUser]    Script Date: 01/25/2020 15:52:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Administration].[TblUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](200) NULL,
	[RoleId] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_TblUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Purchase].[TblSupplier]    Script Date: 01/25/2020 15:52:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Purchase].[TblSupplier](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Email] [varchar](50) NULL,
	[PhoneNo] [varchar](200) NULL,
	[RegisterDate] [datetime] NULL,
	[Address] [nvarchar](200) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_TblSupplier] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Administration].[TblRole]    Script Date: 01/25/2020 15:52:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Administration].[TblRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_TblRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[SpEditUser]    Script Date: 01/25/2020 15:52:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpEditUser]
	@Id int,@Code varchar(50),@Name nvarchar(50),@Email varchar(50),
    @Password varchar(200),@RoleId int,@ModifiedBy int,@Active bit
AS
BEGIN
	
    UPDATE [Administration].[TblUser]
    SET [Code]=@Code,[Name]=@Name,[Email]=@Email
    ,[Password]=@Password,[RoleId]=@RoleId,[ModifiedOn]=GETDATE()
    ,[ModifiedBy]=@ModifiedBy
    ,[Active]=@Active
    WHERE Id=@Id
           

END
GO
/****** Object:  StoredProcedure [dbo].[SpCreateUser]    Script Date: 01/25/2020 15:52:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpCreateUser]
	@Code varchar(50),@Name nvarchar(50),@Email varchar(50),
    @Password varchar(200),@RoleId int,@CreatedBy int,@Active bit
AS
BEGIN
	
	INSERT INTO [Administration].[TblUser]
           ([Code],[Name],[Email],[Password]
           ,[RoleId],[CreatedOn],[CreatedBy],[Active])
     VALUES
           (@Code,@Name,@Email,@Password
           ,@RoleId,GETDATE(),@CreatedBy,@Active
           )

END
GO
