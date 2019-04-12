alter table UserCompany add RoleID int null
GO
alter table CKDepartment add CompanyID int null
GO
alter table CustomerServiceChuli add ResponseRemark ntext null
GO
alter table CustomerServiceChuli add CheckRemark ntext null
GO
alter table ServiceType add GongDanType int null
GO
alter table ServiceType add DisableSend bit null
GO
alter table ServiceType add DisableProcee bit null
GO
alter table ServiceType add DisableCompelte bit null
GO
alter table ServiceType add DisableCallback bit null
GO
alter table ServiceType add DisableShenJi bit null
GO
alter table ServiceType add CloseServiceType int
GO
alter table CustomerService alter column ServiceType2ID nvarchar(200)
GO
alter table CustomerService alter column ServiceType3ID nvarchar(200)
GO
update SysMenu set Name='任务工单',Title='任务工单' where ID=53
GO
update SysMenu set Name='工单类别',Title='工单类别' where ID=55
GO
alter table CustomerService_Accpet add AccpetTime datetime
GO
/****** Object:  Table [dbo].[CustomerService_Return]    Script Date: 2019/3/4 14:37:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerService_Return](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ServiceID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[AddTime] [datetime] NOT NULL,
	[ReturnRemark] [ntext] NULL,
 CONSTRAINT [PK_CustomerService_Return] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO