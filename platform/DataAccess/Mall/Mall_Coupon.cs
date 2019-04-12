using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Foresight.DataAccess.Framework;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a Mall_Coupon.
    /// </summary>
    public partial class Mall_Coupon : EntityBase
    {
        public bool FinalIsActive
        {
            get
            {
                if (!this.IsActive)
                {
                    return false;
                }
                if (this.StartTime > DateTime.Now)
                {
                    return false;
                }
                if (this.EndTime < DateTime.Now && this.EndTime > DateTime.MinValue)
                {
                    return false;
                }
                return true;
            }
        }
        public string IsActiveDesc
        {
            get
            {
                return this.FinalIsActive ? "有效" : "失效";
            }
        }
        public string ActiveTimeRangeDesc
        {
            get
            {
                string desc = "";
                if (this.StartTime > DateTime.MinValue)
                {
                    desc += this.StartTime.ToString("yyyy-MM-dd");
                }
                else
                {
                    desc += "--";
                }
                desc += " 至 ";
                if (this.EndTime > DateTime.MinValue)
                {
                    desc += this.EndTime.ToString("yyyy-MM-dd");
                }
                else
                {
                    desc += "--";
                }
                return desc;
            }
        }
        public string UseForALLDesc
        {
            get
            {
                string desc = string.Empty;
                if (this.IsUseForWY)
                {
                    desc += "物业缴费 ";
                }
                if (this.IsUseForProduct)
                {
                    if (this.IsUseForALLProduct)
                    {
                        desc += "购买所有商品 ";
                    }
                    else
                    {
                        desc += "购买指定商品 ";
                    }
                }
                if (this.IsUseForService)
                {
                    if (this.IsUseForALLService)
                    {
                        desc += "购买所有服务 ";
                    }
                    else
                    {
                        desc += "购买指定服务 ";
                    }
                }
                return desc;
            }
        }
        public string UseTypeDesc
        {
            get
            {
                if (this.UseType == 1)
                {
                    return "满减";
                }
                if (this.UseType == 2)
                {
                    return "折扣";
                }
                return "";
            }
        }
        public string UseTypeMoreDesc
        {
            get
            {
                if (this.ReduceAmount > 0)
                {
                    if (this.UseType == 1 && this.UseNeedAmount > 0)
                    {
                        return "满" + this.UseNeedAmount.ToString("0.00") + "减" + this.ReduceAmount.ToString("0.00");
                    }
                    if (this.UseType == 2)
                    {
                        return "固定折扣" + this.ReduceAmount.ToString("0.00");
                    }
                }
                return "";
            }
        }
        public string CouponTypeDesc
        {
            get
            {
                if (this.CouponType == 1)
                {
                    return "单品券";
                }
                if (this.CouponType == 2)
                {
                    return "店铺券";
                }
                if (this.CouponType == 3)
                {
                    return "全场通用券";
                }
                if (this.CouponType == 4)
                {
                    return "品类优惠券";
                }
                if (this.CouponType == 5)
                {
                    return "物业缴费优惠券";
                }
                if (this.CouponType == 6)
                {
                    return "生日券";
                }
                return "";
            }
        }
        public string UseSubTitle
        {
            get
            {
                if (this.UseType == 1 && this.UseNeedAmount > 0)
                {
                    return "满" + this.UseNeedAmount.ToString("0.00") + "可用";
                }
                if (this.UseType == 2)
                {
                    return "固定折扣";
                }
                return "";
            }
        }
        public string UseTitle
        {
            get
            {
                if (this.ReduceAmount > 0)
                {
                    if (this.AmountType == 1)
                    {
                        return "￥" + this.ReduceAmount.ToString("0.00");
                    }
                    return this.ReduceAmount.ToString("0.00") + "%";
                }
                return "";
            }
        }
        public static Mall_Coupon[] GetMall_CouponListByAmountRuleID(int AmountRuleID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (AmountRuleID == 0)
            {
                return new Mall_Coupon[] { };
            }
            conditions.Add("ID in (select [CouponCodeID] from [Mall_AmountRuleService] where [AmountRuleID]=@AmountRuleID)");
            parameters.Add(new SqlParameter("@AmountRuleID", AmountRuleID));
            string cmdtext = "select * from [Mall_Coupon] where  " + string.Join(" and ", conditions.ToArray());
            return GetList<Mall_Coupon>(cmdtext, parameters).ToArray();
        }
        public static Mall_Coupon[] GetMall_CouponListByIDList(List<int> IDList)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (IDList.Count == 0)
            {
                return new Mall_Coupon[] { };
            }
            conditions.Add("ID in (" + string.Join(",", IDList.ToArray()) + ")");
            string cmdtext = "select * from [Mall_Coupon] where  " + string.Join(" and ", conditions.ToArray());
            return GetList<Mall_Coupon>(cmdtext, parameters).ToArray();
        }
        public static Mall_Coupon[] GetMall_CouponListByCouponType(int CouponType, int ProductID = 0, int BusinessID = 0)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[CouponType]=@CouponType");
            parameters.Add(new SqlParameter("@CouponType", CouponType));
            if (CouponType == 0)
            {
                return new Mall_Coupon[] { };
            }
            if (ProductID > 0)
            {
                conditions.Add("(ID in (select [CouponID] from [Mall_CouponProduct] where [ProductID]=@ProductID) or [IsUseForALLProduct]=1)");
                parameters.Add(new SqlParameter("@ProductID", ProductID));
            }
            if (BusinessID > 0)
            {
                conditions.Add("(ID in (select [CouponID] from [Mall_CouponProduct] where [BusinessID]=@BusinessID) or [IsUseForALLStore]=1)");
                parameters.Add(new SqlParameter("@BusinessID", BusinessID));
            }
            string cmdtext = "select * from [Mall_Coupon] where  " + string.Join(" and ", conditions.ToArray());
            return GetList<Mall_Coupon>(cmdtext, parameters).ToArray();
        }
        public static decimal CalculateCouponPrice(decimal TotalCost, Mall_Coupon coupon)
        {
            if (TotalCost <= 0)
            {
                return 0;
            }
            if (coupon == null)
            {
                return 0;
            }
            if (coupon.ReduceAmount <= 0)
            {
                return 0;
            }
            if (coupon.UseType == 1 && coupon.UseNeedAmount <= TotalCost)
            {
                if (coupon.AmountType == 1)
                {
                    return coupon.ReduceAmount;
                }
                if (coupon.AmountType == 2)
                {
                    return Math.Round((TotalCost * coupon.ReduceAmount) / 100, 2, MidpointRounding.AwayFromZero);
                }
                return 0;
            }
            if (coupon.UseType == 2)
            {
                if (coupon.AmountType == 1)
                {
                    return coupon.ReduceAmount;
                }
                if (coupon.AmountType == 2)
                {
                    return Math.Round((TotalCost * coupon.ReduceAmount) / 100, 2, MidpointRounding.AwayFromZero);
                }
                return 0;
            }
            return 0;
        }
    }
    public partial class Mall_CouponDetail : Mall_Coupon
    {
        [DatabaseColumn("UseCount")]
        public int UseCount { get; set; }
        public static Ui.DataGrid GetMall_CouponDetailGridByKeywords(string keywords, long startRowIndex, int pageSize)
        {
            long totalRows = 0;
            string OrderBy = " order by AddTime desc";
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("1=1");
            if (!string.IsNullOrEmpty(keywords))
            {
                conditions.Add("([CouponName] like @keywords)");
                parameters.Add(new SqlParameter("@keywords", "%" + keywords + "%"));
            }
            string fieldList = "A.*";
            string Statement = " from (select *,(select count(1) from [Mall_Order] where [CouponID]=[Mall_Coupon].ID and [OrderStatus]!=4 and [IsClosed]!=1) as [UseCount] from [Mall_Coupon])A where  " + string.Join(" and ", conditions.ToArray());
            Mall_CouponDetail[] list = GetList<Mall_CouponDetail>(fieldList, Statement, parameters, OrderBy, startRowIndex, pageSize, out totalRows).ToArray();
            DataAccess.Ui.DataGrid dg = new Ui.DataGrid();
            dg.rows = list;
            dg.total = totalRows;
            dg.page = pageSize;
            return dg;
        }

    }
}
