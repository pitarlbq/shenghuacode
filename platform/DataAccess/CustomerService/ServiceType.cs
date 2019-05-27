using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using Foresight.DataAccess.Framework;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a ServiceType.
    /// </summary>
    public partial class ServiceType : EntityBase
    {
        public string ParentName { get; set; }
        public string FullName { get; set; }
        public static List<Dictionary<string, object>> GetServiceTypeGridByKeywords(string Keywords)
        {
            var list = ServiceType.GetServiceTypes().OrderBy(p => p.SortOrder).ThenBy(p => p.AddTime).ToArray();
            if (list.Length > 0)
            {
                foreach (var item in list)
                {
                    var myParentData = list.FirstOrDefault(p => p.ID == item.ParentID);
                    if (myParentData != null)
                    {
                        item.ParentName = myParentData.ServiceTypeName;
                    }
                }
            }
            #region 关键字查询
            string cmd = string.Empty;
            ServiceType[] dataList = new ServiceType[] { };
            if (!string.IsNullOrEmpty(Keywords))
            {
                dataList = list.Where(p => p.ServiceTypeName.Contains(Keywords)).ToArray();
            }
            #endregion
            dataList = dataList.OrderBy(p => p.SortOrder).ThenBy(p => p.ID).ToArray();
            var items = list.Select(p =>
            {
                var dic = new Dictionary<string, object>();
                dic["id"] = p.ID;
                dic["name"] = p.ServiceTypeName;
                dic["FullName"] = GetFullName(list, p, p.ServiceTypeName);
                dic["_parentId"] = p.ParentID <= 1 ? 0 : p.ParentID;
                dic["PaiDanTime"] = p.PaiDanTime > 0 ? p.PaiDanTime : 0;
                dic["ResponseTime"] = p.ResponseTime > 0 ? p.ResponseTime : 0;
                dic["CheckTime"] = p.CheckTime > 0 ? p.CheckTime : 0;
                dic["ChuliTime"] = p.ChuliTime > 0 ? p.ChuliTime : 0;
                dic["BanJieTime"] = p.BanJieTime > 0 ? p.BanJieTime : 0;
                dic["HuiFangTime"] = p.HuiFangTime > 0 ? p.HuiFangTime : 0;
                dic["GuanDanTime"] = p.GuanDanTime > 0 ? p.GuanDanTime : 0;
                if (list.Any(o => o.ParentID == p.ID))
                {
                    dic["state"] = "closed";
                }
                return dic;
            }).ToList();
            //var dic2 = new Dictionary<string, object>();
            //dic2["id"] = 1;
            //dic2["name"] = new Utility.SiteConfig().CompanyName;
            //dic2["_parentId"] = 0;
            //items.Add(dic2);
            return items;
        }
        public static string GetFullName(ServiceType[] list, ServiceType data, string FullName)
        {
            if (data.ParentID <= 1)
            {
                return FullName;
            }
            foreach (var item in list)
            {
                if (item.ID == data.ParentID)
                {
                    FullName = item.ServiceTypeName + "-" + FullName;
                    return GetFullName(list, item, FullName);
                }
            }
            return FullName;
        }
        public static int GetServiceTypeLevel(ServiceType[] list, ServiceType data, int level = 1)
        {
            if (data.ParentID <= 1)
            {
                return level;
            }
            foreach (var item in list)
            {
                if (item.ID == data.ParentID)
                {
                    level++;
                    return GetServiceTypeLevel(list, item, level);
                }
            }
            return level;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="myServiceType2List"></param>
        /// <param name="myServiceType3List"></param>
        /// <param name="myServiceType"></param>
        /// <param name="type">1-派单 2-回复 3-核查 4-处理 5-办结 6-回访 7-关单 8-下单</param>
        /// <returns></returns>
        public static ServiceType GetAvailableServiceType(ServiceType[] myServiceType2List, ServiceType[] myServiceType3List, ServiceType myServiceType, int typeid = 1, bool IsPinZhiShengJi = false)
        {
            if (IsPinZhiShengJi)
            {
                return myServiceType;
            }
            ServiceType myServiceTypeItem = null;
            ServiceType[] myServiceTypeList = new ServiceType[] { };
            if (myServiceTypeItem == null && myServiceType3List.Length > 0)
            {
                myServiceTypeList = myServiceType3List.Where(p => p.PaiDanTime > 0 || p.ResponseTime > 0 || p.CheckTime > 0 || p.ChuliTime > 0 || p.BanJieTime > 0 || p.HuiFangTime > 0 || p.GuanDanTime > 0).ToArray();
            }
            if (myServiceTypeList.Length == 0 && myServiceType2List.Length > 0)
            {
                myServiceTypeList = myServiceType2List.Where(p => p.PaiDanTime > 0 || p.ResponseTime > 0 || p.CheckTime > 0 || p.ChuliTime > 0 || p.BanJieTime > 0 || p.HuiFangTime > 0 || p.GuanDanTime > 0).ToArray();
            }
            if (myServiceTypeList.Length == 0)
            {
                return myServiceType;
            }
            if (typeid == 1)
            {
                myServiceTypeItem = myServiceTypeList.OrderByDescending(p => p.PaiDanTime).FirstOrDefault();
            }
            else if (typeid == 2)
            {
                myServiceTypeItem = myServiceTypeList.OrderByDescending(p => p.ResponseTime).FirstOrDefault();
            }
            else if (typeid == 3)
            {
                myServiceTypeItem = myServiceTypeList.OrderByDescending(p => p.CheckTime).FirstOrDefault();
            }
            else if (typeid == 4)
            {
                myServiceTypeItem = myServiceTypeList.OrderByDescending(p => p.ChuliTime).FirstOrDefault();
            }
            else if (typeid == 5)
            {
                myServiceTypeItem = myServiceTypeList.OrderByDescending(p => p.BanJieTime).FirstOrDefault();
            }
            else if (typeid == 6)
            {
                myServiceTypeItem = myServiceTypeList.OrderByDescending(p => p.HuiFangTime).FirstOrDefault();
            }
            else if (typeid == 7)
            {
                myServiceTypeItem = myServiceTypeList.OrderByDescending(p => p.GuanDanTime).FirstOrDefault();
            }
            //if (myServiceTypeItem == null && myServiceType2List.Length > 0)
            //{
            //    if (typeid == 1)
            //    {
            //        myServiceTypeItem = myServiceType2List.Where(p => p.PaiDanTime > 0).OrderByDescending(p => p.PaiDanTime).FirstOrDefault();
            //    }
            //    else if (typeid == 2)
            //    {
            //        myServiceTypeItem = myServiceType2List.Where(p => p.ResponseTime > 0).OrderByDescending(p => p.ResponseTime).FirstOrDefault();
            //    }
            //    else if (typeid == 3)
            //    {
            //        myServiceTypeItem = myServiceType2List.Where(p => p.CheckTime > 0).OrderByDescending(p => p.CheckTime).FirstOrDefault();
            //    }
            //    else if (typeid == 4)
            //    {
            //        myServiceTypeItem = myServiceType2List.Where(p => p.ChuliTime > 0).OrderByDescending(p => p.ChuliTime).FirstOrDefault();
            //    }
            //    else if (typeid == 5)
            //    {
            //        myServiceTypeItem = myServiceType2List.Where(p => p.BanJieTime > 0).OrderByDescending(p => p.BanJieTime).FirstOrDefault();
            //    }
            //    else if (typeid == 6)
            //    {
            //        myServiceTypeItem = myServiceType2List.Where(p => p.HuiFangTime > 0).OrderByDescending(p => p.HuiFangTime).FirstOrDefault();
            //    }
            //    else if (typeid == 7)
            //    {
            //        myServiceTypeItem = myServiceType2List.Where(p => p.GuanDanTime > 0).OrderByDescending(p => p.GuanDanTime).FirstOrDefault();
            //    }
            //}
            if (myServiceTypeItem == null)
            {
                myServiceTypeItem = myServiceType;
            }
            return myServiceTypeItem;
        }
        public static ServiceType GetImportServiceType()
        {
            var list = SysConfig.GetSysConfigListByType("ServiceType");
            if (list.Length == 0)
            {
                return null;
            }
            var data = new ServiceType();
            decimal decimalValue = 0;
            var name = Foresight.DataAccess.SysConfigNameDefine.ServiceTypePaiDanTime;
            var value = SysConfig.GetSysConfigValueByName(list, name);
            if (!string.IsNullOrEmpty(value))
            {
                decimal.TryParse(value, out decimalValue);
                data.PaiDanTime = decimalValue;
            }

            name = Foresight.DataAccess.SysConfigNameDefine.ServiceTypeCheckTime;
            value = Foresight.DataAccess.SysConfig.GetSysConfigValueByName(list, name);
            if (!string.IsNullOrEmpty(value))
            {
                decimal.TryParse(value, out decimalValue);
                data.CheckTime = decimalValue;
            }

            name = Foresight.DataAccess.SysConfigNameDefine.ServiceTypeBanJieTime;
            value = Foresight.DataAccess.SysConfig.GetSysConfigValueByName(list, name);
            if (!string.IsNullOrEmpty(value))
            {
                decimal.TryParse(value, out decimalValue);
                data.BanJieTime = decimalValue;
            }

            name = Foresight.DataAccess.SysConfigNameDefine.ServiceTypeResponseTime;
            value = Foresight.DataAccess.SysConfig.GetSysConfigValueByName(list, name);
            if (!string.IsNullOrEmpty(value))
            {
                decimal.TryParse(value, out decimalValue);
                data.ResponseTime = decimalValue;
            }

            name = Foresight.DataAccess.SysConfigNameDefine.ServiceTypeChuliTime;
            value = Foresight.DataAccess.SysConfig.GetSysConfigValueByName(list, name);
            if (!string.IsNullOrEmpty(value))
            {
                decimal.TryParse(value, out decimalValue);
                data.ChuliTime = decimalValue;
            }

            name = Foresight.DataAccess.SysConfigNameDefine.ServiceTypeGuanDanTime;
            value = Foresight.DataAccess.SysConfig.GetSysConfigValueByName(list, name);
            if (!string.IsNullOrEmpty(value))
            {
                decimal.TryParse(value, out decimalValue);
                data.GuanDanTime = decimalValue;
            }

            name = Foresight.DataAccess.SysConfigNameDefine.ServiceTypeHuiFangTime;
            value = Foresight.DataAccess.SysConfig.GetSysConfigValueByName(list, name);
            if (!string.IsNullOrEmpty(value))
            {
                decimal.TryParse(value, out decimalValue);
                data.HuiFangTime = decimalValue;
            }

            name = Foresight.DataAccess.SysConfigNameDefine.ServiceTypeDisableHolidayTime;
            value = Foresight.DataAccess.SysConfig.GetSysConfigValueByName(list, name);
            if (!string.IsNullOrEmpty(value))
            {
                int intValue = 0;
                int.TryParse(value, out intValue);
                data.DisableHolidayTime = intValue == 1;
            }

            name = Foresight.DataAccess.SysConfigNameDefine.ServiceTypeStartHour;
            value = Foresight.DataAccess.SysConfig.GetSysConfigValueByName(list, name);
            data.StartHour = value;

            name = Foresight.DataAccess.SysConfigNameDefine.ServiceTypeEndHour;
            value = Foresight.DataAccess.SysConfig.GetSysConfigValueByName(list, name);
            data.EndHour = value;

            return data;
        }
        public static void SetServiceTypeData(ServiceType data, ServiceType oldData = null, ServiceType_ImportantService importantData = null)
        {
            if (oldData == null && importantData == null)
            {
                return;
            }
            if (data == null)
            {
                data = new ServiceType();
            }
            if (importantData != null)
            {
                data.DealTime = importantData.DealTime;
                data.PaiDanTime = importantData.PaiDanTime;
                data.CheckTime = importantData.CheckTime;
                data.ResponseTime = importantData.ResponseTime;
                data.ChuliTime = importantData.ChuliTime;
                data.BanJieTime = importantData.BanJieTime;
                data.HuiFangTime = importantData.HuiFangTime;
                data.GuanDanTime = importantData.GuanDanTime;
                data.DisableHolidayTime = importantData.DisableHolidayTime;
                data.StartHour = importantData.StartHour;
                data.EndHour = importantData.EndHour;
            }
            else if (oldData != null)
            {
                data.PaiDanTime = oldData.PaiDanTime;
                data.CheckTime = oldData.CheckTime;
                data.ResponseTime = oldData.ResponseTime;
                data.ChuliTime = oldData.ChuliTime;
                data.BanJieTime = oldData.BanJieTime;
                data.HuiFangTime = oldData.HuiFangTime;
                data.GuanDanTime = oldData.GuanDanTime;
                data.DisableHolidayTime = oldData.DisableHolidayTime;
                data.StartHour = oldData.StartHour;
                data.EndHour = oldData.EndHour;
            }
        }
        public static ServiceType[] GetServiceTypeListByParentIDList(int[] ParentIDList)
        {
            if (ParentIDList.Length == 0)
            {
                return new ServiceType[] { };
            }
            return GetList<ServiceType>("select * from [ServiceType] where ParentID in (" + string.Join(",", ParentIDList) + ")", new List<SqlParameter>()).ToArray();
        }
    }
}
