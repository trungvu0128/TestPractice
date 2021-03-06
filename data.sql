USE [Practice]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 15/06/2021 6:45:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserFullName] [nvarchar](max) NULL,
	[UserEmail] [nvarchar](max) NULL,
	[UserPhone] [nvarchar](50) NULL,
	[UserBirthday] [date] NULL,
	[UserGender] [bit] NULL,
	[UserPassword] [nvarchar](20) NULL,
	[UserCreateAt] [datetime] NULL,
	[UserId] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
