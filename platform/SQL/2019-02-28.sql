alter table CustomerService add ServiceType1ID int null
GO
alter table CustomerService add ServiceType2ID int null
GO
alter table CustomerService add ServiceType3ID int null
GO
alter table CustomerService drop column ServiceTypeID
GO
alter table CustomerService drop column ServiceTypeName
GO
alter table [User] add ServiceFrom nvarchar(100) null
GO
alter table CustomerService add ConfirmStatus int null
GO
alter table ServiceType add PaiDanTime decimal(18,2) null
GO
alter table ServiceType add ChuliTime decimal(18,2) null
GO
alter table ServiceType add BanJieTime decimal(18,2) null
GO
alter table ServiceType add HuiFangTime decimal(18,2) null
GO
alter table ServiceType add GuanDanTime decimal(18,2) null
GO
alter table PhoneRecord drop column PhoneRecordID
GO
alter table PhoneRecord add RelatedPhoneRecordID int null
GO
alter table PhoneRecord add PickUpTime datetime null
GO
alter table CustomerService drop column ServiceAccpetManID
GO
alter table CustomerService drop column ServiceAccpetMan
GO
alter table CustomerService drop column ServiceProcessManID
GO
alter table CustomerService add RelatedServiceID int null
GO
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
				,CustomerService.RelatedServiceID
FROM      dbo.CustomerService LEFT OUTER JOIN
                Project on Project.ID=CustomerService.ProjectID
				left join RoomBasic on ROomBasic.RoomID=CustomerService.ProjectID
				left join [CustomerService_Task] on [CustomerService_Task].ID=CustomerService.TaskType
				left join CKDepartment on CKDepartment.ID=CustomerService.DepartmentID
GO
/****** Object:  Table [dbo].[UserServiceType]    Script Date: 2019/3/1 13:47:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserServiceType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NULL,
	[UserID] [int] NULL,
	[ServiceTypeID] [int] NOT NULL,
 CONSTRAINT [PK_UserServiceType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
