using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using Foresight.DataAccess.Framework;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a ServiceType_ImportantService.
    /// </summary>
    public partial class ServiceType_ImportantService : EntityBase
    {
        public static ServiceType_ImportantService[] GetServiceType_ImportantServiceListByMinMaxServiceID(int MinServiceID, int MaxServiceID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (MaxServiceID <= 0)
            {
                return new ServiceType_ImportantService[] { };
            }
            conditions.Add("[ServiceID] between " + MinServiceID + " and " + MaxServiceID);
            string sqlText = "select * from [ServiceType_ImportantService] where " + string.Join(" or ", conditions.ToArray());
            return GetList<ServiceType_ImportantService>(sqlText, parameters).ToArray();
        }
        public static ServiceType_ImportantService GetServiceType_ImportantServiceByServiceID(int ServiceID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            if (ServiceID <= 0)
            {
                return null;
            }
            conditions.Add("[ServiceID]=@ServiceID");
            parameters.Add(new SqlParameter("@ServiceID", ServiceID));
            string sqlText = "select * from [ServiceType_ImportantService] where " + string.Join(" or ", conditions.ToArray());
            return GetOne<ServiceType_ImportantService>(sqlText, parameters);
        }
        public static void ApproveImportantService(ServiceType_ImportantService data)
        {
            var service = CustomerService.GetCustomerService(data.ServiceID);
            if (service == null)
            {
                return;
            }
            if (data.ApproveStatus == 1)
            {
                service.IsImportantTouSu = true;
            }
            else
            {
                service.IsImportantTouSu = false;
            }
            service.Save();
            var serviceTypeList = ServiceType.GetServiceTypes().ToArray();
            var myServiceType = serviceTypeList.FirstOrDefault(p => p.ID == service.ServiceType1ID);
            if (myServiceType == null || data.ApplicationType == 4)
            {
                data.Save();
                return;
            }
            var myServiceType2List = serviceTypeList.Where(p => service.ServiceType2IDList.Contains(p.ID)).ToArray();
            var myServiceType3List = serviceTypeList.Where(p => service.ServiceType3IDList.Contains(p.ID)).ToArray();
            #region 派单时效
            var myPaiDanServiceTypeItem = ServiceType.GetAvailableServiceType(myServiceType2List, myServiceType3List, myServiceType, typeid: 1);
            data.PaiDanTime = myPaiDanServiceTypeItem.PaiDanTime;
            #endregion
            #region 回复时效
            var myResponseServiceTypeItem = ServiceType.GetAvailableServiceType(myServiceType2List, myServiceType3List, myServiceType, typeid: 2);
            data.ResponseTime = myResponseServiceTypeItem.ResponseTime;
            #endregion
            #region 核查时效
            var myCheckServiceTypeItem = ServiceType.GetAvailableServiceType(myServiceType2List, myServiceType3List, myServiceType, typeid: 3);
            data.CheckTime = myCheckServiceTypeItem.CheckTime;
            #endregion
            #region 处理时效
            var myProcessServiceTypeItem = ServiceType.GetAvailableServiceType(myServiceType2List, myServiceType3List, myServiceType, typeid: 4);
            data.ChuliTime = myCheckServiceTypeItem.ChuliTime;
            #endregion
            #region 办结时效
            var myBanJieServiceTypeItem = ServiceType.GetAvailableServiceType(myServiceType2List, myServiceType3List, myServiceType, typeid: 5);
            data.BanJieTime = myBanJieServiceTypeItem.BanJieTime;
            #endregion
            #region 关单时效
            var myGuanDanServiceTypeItem = ServiceType.GetAvailableServiceType(myServiceType2List, myServiceType3List, myServiceType, typeid: 7);
            data.GuanDanTime = myGuanDanServiceTypeItem.GuanDanTime;
            #endregion
            #region 回访时效
            var myHuiFangServiceTypeItem = ServiceType.GetAvailableServiceType(myServiceType2List, myServiceType3List, myServiceType, typeid: 7);
            data.HuiFangTime = myHuiFangServiceTypeItem.HuiFangTime;
            #endregion
            if (data.ApplicationType == 2)//启用第三方(一倍时间)
            {
                data.PaiDanTime = data.PaiDanTime > 0 ? data.PaiDanTime * 2 : 0;
                data.ResponseTime = data.ResponseTime > 0 ? data.ResponseTime * 2 : 0;
                data.CheckTime = data.CheckTime > 0 ? data.CheckTime * 2 : 0;
                data.ChuliTime = data.ChuliTime > 0 ? data.ChuliTime * 2 : 0;
                data.BanJieTime = data.BanJieTime > 0 ? data.BanJieTime * 2 : 0;
                data.GuanDanTime = data.GuanDanTime > 0 ? data.GuanDanTime * 2 : 0;
                data.HuiFangTime = data.HuiFangTime > 0 ? data.HuiFangTime * 2 : 0;
            }
            else
            {
                int addHour = 0;
                if (data.ApplicationType == 1)//启用第三方(三天)
                {
                    addHour = 24 * 3;
                }
                else if (data.ApplicationType == 3)//修转赔偿意见未达成一致(十五天)
                {
                    addHour = 24 * 15;
                }
                data.PaiDanTime = data.PaiDanTime > 0 ? data.PaiDanTime + addHour : 0;
                data.ResponseTime = data.ResponseTime > 0 ? data.ResponseTime + addHour : 0;
                data.CheckTime = data.CheckTime > 0 ? data.CheckTime + addHour : 0;
                data.ChuliTime = data.ChuliTime > 0 ? data.ChuliTime + addHour : 0;
                data.BanJieTime = data.BanJieTime > 0 ? data.BanJieTime + addHour : 0;
                data.GuanDanTime = data.GuanDanTime > 0 ? data.GuanDanTime + addHour : 0;
                data.HuiFangTime = data.HuiFangTime > 0 ? data.HuiFangTime + addHour : 0;
            }
            data.Save();
        }
        public string ApproveStatusDesc
        {
            get
            {
                if (this.ApproveStatus == 1)
                {
                    return "审核通过";
                }
                if (this.ApproveStatus == 2)
                {
                    return "审核未通过";
                }
                return "待审核";
            }
        }
    }
}
