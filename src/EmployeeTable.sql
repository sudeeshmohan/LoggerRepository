
CREATE TABLE [dbo].[Employee](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[EmailAddress] [varchar](50) NULL,
	[AddressLine] [varchar](max) NULL,
	[Country] [varchar](max) NULL,
	[State] [varchar](50) NULL,
	[ZipCode] [varchar](50) NULL,
 CONSTRAINT [PK_EmployeeDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


