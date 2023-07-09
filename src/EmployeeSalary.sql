

CREATE TABLE [dbo].[EmployeeSalary](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PaymentDate] [datetime] NULL,
	[Hours] [real] NULL,
	[SalaryPerHour] [real] NULL,
	[Salary] [real] NULL,
	[EmployeeDetailId] [bigint] NULL,
 CONSTRAINT [PK_EmployeeSalary] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[EmployeeSalary]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeSalary_EmployeeDetail] FOREIGN KEY([EmployeeDetailId])
REFERENCES [dbo].[Employee] ([Id])
GO

ALTER TABLE [dbo].[EmployeeSalary] CHECK CONSTRAINT [FK_EmployeeSalary_EmployeeDetail]
GO


