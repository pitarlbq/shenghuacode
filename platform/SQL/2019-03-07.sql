alter table ServiceType add CallBackServiceType int null
GO
alter table ServiceType add BanJieServiceType int null
GO
alter table TableColumnsUser add ServiceStatus int null
GO
alter table TableColumnsUser add ServiceType int null
GO
alter table ServiceType add DisableHolidayTime bit null
GO
alter table ServiceType add StartHour nvarchar(20) null
GO
alter table ServiceType add EndHour nvarchar(20) null
GO
alter table CustomerService add CloseTime datetime null
GO
/****** Object:  View [dbo].[ViewCustomerService]    Script Date: 2019/3/8 16:34:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER VIEW [dbo].[ViewCustomerService]
AS
SELECT   dbo.CustomerService.ID, dbo.CustomerService.ProjectID, dbo.CustomerService.ServiceFullName, 
                 dbo.CustomerService.ProjectName, dbo.CustomerService.AddUserName, dbo.CustomerService.StartTime, 
                dbo.CustomerService.ServiceArea, dbo.CustomerService.ServiceNumber, dbo.CustomerService.AddCustomerName, 
                dbo.CustomerService.AddCallPhone, dbo.CustomerService.ServiceContent, dbo.CustomerService.AddTime, 
                dbo.CustomerService.ServiceStatus, dbo.CustomerService.BanJieTime, dbo.CustomerService.BanJieNote, 
                dbo.CustomerService.ServiceAppointTime, dbo.CustomerService.AddMan, 
                dbo.CustomerService.OrderNumberID,
                    dbo.CustomerService.HandelFee, dbo.CustomerService.TotalFee, 
                dbo.CustomerService.BalanceStatus, dbo.CustomerService.CKProductOutSumaryID, 
                dbo.CustomerService.IsRequireCost, dbo.CustomerService.IsRequireProduct, dbo.CustomerService.IsAPPShow, 
                dbo.CustomerService.IsAPPSend, dbo.CustomerService.APPSendTime, dbo.CustomerService.APPSendResult, 
                dbo.CustomerService.WechatServiceID, dbo.CustomerService.AcceptTime, dbo.CustomerService.TaskType, 
                dbo.CustomerService.ServiceFrom,
                    dbo.CustomerService.DepartmentID, 
                dbo.CustomerService.IsSuggestion, dbo.CustomerService.PublicProjectID, dbo.CustomerService.AddUserID, 
                dbo.CustomerService.SendUserID, dbo.CustomerService.SendUserName, dbo.CustomerService.BanJieManUserID, 
                dbo.CustomerService.BanJieManName, dbo.CustomerService.IsUnRead, dbo.CustomerService.IsInvalidCall, 
                dbo.CustomerService.IsInWeiBao, 
                dbo.CustomerService.IsHighTouSu,Project.Name as Project_Name,Project.FullName,
				RoomBasic.BuildingNumber,RoomBasic.RoomType,RoomBasic.IsJingZhuangXiu,[CustomerService_Task].TaskName,
				CKDepartment.DepartmentName,CustomerService.IsClosed,
				CustomerService.ServiceType1ID,CustomerService.ServiceType2ID,CustomerService.ServiceType3ID,
				CustomerService.ConfirmStatus
				,CustomerService.RelatedServiceID,CustomerService.CloseTime,Company.CompanyName
FROM      dbo.CustomerService LEFT OUTER JOIN
                Project on Project.ID=CustomerService.ProjectID
				left join RoomBasic on ROomBasic.RoomID=CustomerService.ProjectID
				left join [CustomerService_Task] on [CustomerService_Task].ID=CustomerService.TaskType
				left join CKDepartment on CKDepartment.ID=CustomerService.DepartmentID
				left join Company on Company.CompanyID=Project.CompanyID
GO
alter table TableColumns add IsAnalysis bit null
GO
update TableColumns set ColumnField='field: ''ChuLiHandelFee'', formatter: formatPrice, title: ''处理费用'', width: 100'
where ID=59
GO
update SysMenu set [Disabled]=1 where ID in (7,8,10,13,14)
GO
update SysMenu set [Url]='../Analysis/ServiceTimeOutDetailAnalysis.aspx' where ID=9
GO
update SysMenu set [Url]='../Analysis/ServiceFeeDetailAnalysis.aspx' where ID=11
GO
/****** Object:  Table [dbo].[HolidayLog]    Script Date: 2019/3/8 20:57:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[HolidayLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Day] [nvarchar](200) NOT NULL,
	[Value] [int] NOT NULL,
	[AddTime] [datetime] NOT NULL,
 CONSTRAINT [PK_HolidayLog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0-工作日 1-休息日 2-节假日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HolidayLog', @level2type=N'COLUMN',@level2name=N'Value'
GO