alter table CustomerService add IsImportantTouSu bit null
GO
/****** Object:  View [dbo].[ViewCustomerService]    Script Date: 2019/3/26 11:21:57 ******/
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
				,CustomerService.RelatedServiceID,CustomerService.CloseTime,Company.CompanyName,
				CustomerService.HuiFangRate,Project.CompanyID,CustomerService.IsImportantTouSu
FROM      dbo.CustomerService LEFT OUTER JOIN
                Project on Project.ID=CustomerService.ProjectID
				left join RoomBasic on ROomBasic.RoomID=CustomerService.ProjectID
				left join [CustomerService_Task] on [CustomerService_Task].ID=CustomerService.TaskType
				left join CKDepartment on CKDepartment.ID=CustomerService.DepartmentID
				left join Company on Company.CompanyID=Project.CompanyID
GO