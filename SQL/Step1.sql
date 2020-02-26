USE [TestABC]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'NHS')
BEGIN
EXEC('CREATE SCHEMA NHS')
END

GO

CREATE TABLE [NHS].[tblPatient](
	[PatientId] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[Gender] [int] NOT NULL,
	[DOB] [date] NOT NULL,
	[Address] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_tblPatient] PRIMARY KEY CLUSTERED 
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [NHS].[tblPatient] ADD  CONSTRAINT [DF_tblPatient_PatientId]  DEFAULT (newid()) FOR [PatientId]
GO



CREATE TABLE [NHS].[tblServices](
	[ServiceId] [uniqueidentifier] NOT NULL,
	[PatientId] [uniqueidentifier] NOT NULL,
	[ServiceTime] [datetime] NOT NULL,
	[Symtoms] [nvarchar](1000) NOT NULL,
	[Advice] [nvarchar](1000) NOT NULL,
	[Medication] [nvarchar](500) NOT NULL,
	[Comments] [nvarchar](1000) NOT NULL,
	[ServiceCharge] [decimal](18, 3) NOT NULL,
 CONSTRAINT [PK_tblServices] PRIMARY KEY CLUSTERED 
(
	[ServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [NHS].[tblServices] ADD  CONSTRAINT [DF_tblServices_ServiceId]  DEFAULT (newid()) FOR [ServiceId]
GO

ALTER TABLE [NHS].[tblServices]  WITH CHECK ADD  CONSTRAINT [FK_tblServices_tblPatient] FOREIGN KEY([PatientId])
REFERENCES [NHS].[tblPatient] ([PatientId])
GO

ALTER TABLE [NHS].[tblServices] CHECK CONSTRAINT [FK_tblServices_tblPatient]
GO

 
  create or alter procedure NHS.sp_Summary_Report
  @reportType int=1,
  @reportDate date=null
  as
  begin
   SET NOCOUNT ON
   declare @sql nvarchar(max)
   declare @where nvarchar(max)
  

  set @sql= ' select count(serviceid) as[TotalConsultation], count(year(pt.DOB)) as[AgeGroup],
  Isnull(sum(servicecharge),0.00) as[TotalFees]  from [NHS].[tblServices] svc

  join [NHS].[tblPatient] as pt
  on svc.PatientId=pt.PatientId where'
  if @reportType =1  
  set @where =' convert(date,svc.ServiceTime)= @reportDate'
  
  else if @reportType =2
  set @where =' datepart(week,svc.ServiceTime)= datepart(week, @reportDate)'
  
  else if @reportType =3
  set @where =' datepart(month,svc.ServiceTime)= datepart(month, @reportDate)'
  
  else if @reportType =4
  set @where =' datepart(QUARTER,svc.ServiceTime)= datepart(QUARTER, @reportDate)'
  else
  set @where =' datepart(year,svc.ServiceTime)= datepart(year, @reportDate)'

  set @sql= @sql + @where  
  
  execute sp_executeSql @sql, N'@reportDate date', @reportDate=@reportDate

  end

