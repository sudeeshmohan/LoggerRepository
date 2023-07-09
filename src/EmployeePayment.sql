
CREATE TABLE [dbo].[EmployeePayment](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PaymentDate] [datetime] NULL,
	[AmountPayed] [real] NULL,
	[EmployeeDetailId] [bigint] NULL,
 CONSTRAINT [PK_EmployeePayment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[EmployeePayment]  WITH CHECK ADD  CONSTRAINT [FK_EmployeePayment_EmployeeDetail] FOREIGN KEY([EmployeeDetailId])
REFERENCES [dbo].[Employee] ([Id])
GO

ALTER TABLE [dbo].[EmployeePayment] CHECK CONSTRAINT [FK_EmployeePayment_EmployeeDetail]
GO


