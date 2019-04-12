using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Foresight.DataAccess.Framework;
using Utility;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a JPushLog.
    /// </summary>
    public partial class JPushLog : EntityBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AndroidUserID"></param>
        /// <param name="IOSUserID"></param>
        /// <param name="PushContent"></param>
        /// <param name="PushResult"></param>
        /// <param name="PushType">1-客户服务 2-物业公告 3-小区新闻 4-系统通知 5-设备维保 6-限时购通知 7-团购通知 8-生日通知 9-退款通知 10 发货通知 11-绩效考核</param>
        /// <param name="RelatedID"></param>
        public static void Insert_JPushLog(string[] AndroidUserID, string[] IOSUserID, Dictionary<string, object> PushContent, string PushResult, int PushType, int RelatedID, bool IsPushed, string Title, int[] UserIDList = null)
        {
            try
            {
                var data = new JPushLog();
                if (AndroidUserID == null)
                {
                    data.AndroidUserID = "ALL";
                }
                else
                {
                    data.AndroidUserID = JsonConvert.SerializeObject(AndroidUserID);
                }
                if (IOSUserID == null)
                {
                    data.IOSUserID = "ALL";
                }
                else
                {
                    data.IOSUserID = JsonConvert.SerializeObject(IOSUserID);
                }
                data.IsPushed = IsPushed;
                if (data.IsPushed)
                {
                    data.PushTime = DateTime.Now;
                }
                data.AddTime = DateTime.Now;
                data.Title = Title;
                data.PushContent = JsonConvert.SerializeObject(PushContent);
                data.PushResult = PushResult;
                data.PushType = PushType;
                data.RelatedID = RelatedID;
                data.Save();
                var coupon = Mall_Coupon.GetMall_Coupon(RelatedID);
                if (coupon == null)
                {
                    return;
                }
                List<Mall_CouponUser> my_coupon_list = new List<Mall_CouponUser>();
                if (data.PushType == 8 && RelatedID > 0 && UserIDList != null)
                {
                    foreach (var UserID in UserIDList)
                    {
                        var my_coupon = new Mall_CouponUser();
                        my_coupon.CouponID = RelatedID;
                        my_coupon.UserID = UserID;
                        my_coupon.AddTime = DateTime.Now;
                        my_coupon.CouponType = 2;
                        my_coupon.UseType = 0;
                        my_coupon.AddUserMan = "System";
                        my_coupon.IsUsed = false;
                        my_coupon.AmountRuleID = 0;
                        my_coupon.IsRead = false;
                        my_coupon.IsSent = true;
                        my_coupon.SentTime = DateTime.Now;
                        my_coupon.IsTaken = false;
                        my_coupon.StartTime = coupon.StartTime;
                        my_coupon.EndTime = coupon.EndTime;
                        my_coupon.IsActive = true;
                        my_coupon_list.Add(my_coupon);
                    }
                }
                foreach (var item in my_coupon_list)
                {
                    item.Save();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
