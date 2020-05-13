using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility
{
    public class SystemMsgModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string ContentSummary { get; set; }
        public int SortOrder { get; set; }
        public bool IsTopShow { get; set; }
        public DateTime AddTime { get; set; }
    }
    public class MobileWechatModel
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class MobileWechatModelResponse
    {
        public bool status { get; set; }
        public MobileWechatModel[] list { get; set; }
    }
    public class ServerCompanyModel
    {
        public int CompanyID { get; set; }
        public string ApiURL { get; set; }
        public string VirName { get; set; }
        public string DBName { get; set; }
        public string DBLogName { get; set; }
    }
    public class DiscountProductModel
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public decimal SalePrice { get; set; }
        public int SaleQuantity { get; set; }
        public decimal FinalPrice { get; set; }
        public int FinalInventory { get; set; }
    }
    public class ChargeFeePriceRangeModel
    {
        public int RoomFeeID { get; set; }
        public int SummaryID { get; set; }
        public decimal MinValue { get; set; }
        public decimal MaxValue { get; set; }
        public decimal BasePrice { get; set; }
        public string BaseType { get; set; }
        public bool IsActive { get; set; }
    }
    public class ContractTempPrice
    {
        public int ID { get; set; }
        public decimal CalculatePrice { get; set; }
        public DateTime CalculateStartTime { get; set; }
        public DateTime CalculateEndTime { get; set; }
        public DateTime ReadyChargeTime { get; set; }
        public decimal CalculateCost { get; set; }
    }
    public class ContractCalculateTypeModel
    {
        public int ID { get; set; }
        public string CalculateType { get; set; }
        public int CalcualtePriceMonth { get; set; }
        public DateTime FirstReadyChargePriceTime { get; set; }
        public DateTime LastReadyChargePriceTime { get; set; }
        public decimal CalculateValue { get; set; }
        public int count { get; set; }
        public string valueunit { get; set; }
    }
    public class ContractTempPriceModel
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime ReadyChargeTime { get; set; }
        public decimal CalculatePercent { get; set; }
        public decimal CalculateAmount { get; set; }
        public decimal CalculateValue { get; set; }
        public string CalculateType { get; set; }
    }
    public class ContractFreeTimeModel
    {
        public int ID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int FreeType { get; set; }
        public string FreeChargeNames { get; set; }
        public string FreeChargeIDs { get; set; }
        public int count { get; set; }
    }
    public class GuaranteeFeeModule
    {
        public DateTime ChargeTime { get; set; }
        public string ChargeName { get; set; }
        public decimal RealCost { get; set; }
        public string BackGuaranteeRemark { get; set; }
        public string Remark { get; set; }
        public int HistoryID { get; set; }
    }
    public class RoomFeeModule
    {
        public string ChargeFeeSummaryName { get; set; }
        public decimal ChargeFeeCurrentBalance { get; set; }
        public decimal RealCost { get; set; }
        public decimal TotalRestBalance { get; set; }
        public string Remark { get; set; }
    }
    public class ProductRow
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string ModelNumber { get; set; }
        public string Unit { get; set; }
        public decimal UnitPrice { get; set; }
        public int InTotalCount { get; set; }
        public decimal InTotalPrice { get; set; }
        public string Remark { get; set; }
    }
    public class ProductOutRow
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string ModelNumber { get; set; }
        public string Unit { get; set; }
        public decimal UnitPrice { get; set; }
        public int OutTotalCount { get; set; }
        public decimal OutTotalPrice { get; set; }
        public decimal TotalInventory { get; set; }
        public string ProductName { get; set; }
        public decimal InBasicUnitPrice { get; set; }
        public string Remark { get; set; }
    }
    public class WeiXinPayModel
    {
        public int ID { get; set; }
        public DateTime? EndTime { get; set; }
    }
    public class APPPayModel
    {
        public int ID { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal TotalCost { get; set; }
    }
    public class CancelSubscribeModel
    {
        public int RoomID { get; set; }
        public string OpenID { get; set; }
    }
    public class TaiZhangModel
    {
        public int ID { get; set; }
        public string FinalBiaoName { get; set; }
        public decimal Rate { get; set; }
        public DateTime WriteDate { get; set; }
        public decimal FinalStartPoint { get; set; }
        public decimal FinalEndPoint { get; set; }
        public decimal FinalReducePoint { get; set; }
        public decimal FinalUnitPrice { get; set; }
        public string BiaoGuiGe { get; set; }
        public decimal FinalCoefficient { get; set; }
    }
    public class BasicModel
    {
        public int id { get; set; }
        public string value { get; set; }
    }
    public class RoomStateModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string BackColor { get; set; }
    }
    public class JpushContent
    {
        public JpushContent(int Code, string Msg = "", string Type = "customerservice")
        {
            this.code = Code;
            this.type = Type;
            switch (this.type)
            {
                case "customerservice":
                    if (!string.IsNullOrEmpty(Msg))
                    {
                        this.msg = Msg;
                    }
                    else if (code == 10)
                    {
                        this.msg = string.IsNullOrEmpty(Msg) ? "有新工单来了，请尽快派单" : Msg;
                    }
                    else if (code == 0)
                    {
                        this.msg = string.IsNullOrEmpty(Msg) ? "有新工单来了，请尽快处理" : Msg;
                    }
                    break;
                case "devicetask":
                    if (code == 1)
                    {
                        this.msg = string.IsNullOrEmpty(Msg) ? "你有新的设备巡检任务待处理" : Msg;
                    }
                    break;
                case "wechatmsg_gonggao":
                    if (code == 101)
                    {
                        this.msg = string.IsNullOrEmpty(Msg) ? "你有新的物业公告通知" : Msg;
                    }
                    break;
                case "wechatmsg_news":
                    if (code == 201)
                    {
                        this.msg = string.IsNullOrEmpty(Msg) ? "你有新的小区新闻通知" : Msg;
                    }
                    break;
                case "mallproduct_tuan":
                    if (code == 301)
                    {
                        this.msg = string.IsNullOrEmpty(Msg) ? "团购商品即将开始" : Msg;
                    }
                    break;
                case "mallproduct_xianshi":
                    if (code == 401)
                    {
                        this.msg = string.IsNullOrEmpty(Msg) ? "限时购商品即将开始" : Msg;
                    }
                    break;
                case "mallbirthday_coupon":
                    if (code == 501)
                    {
                        this.msg = string.IsNullOrEmpty(Msg) ? "生日祝福，领取优惠券" : Msg;
                    }
                    break;
                case "mallorder_refund":
                    if (code == 601)
                    {
                        this.msg = string.IsNullOrEmpty(Msg) ? "订单退款成功" : Msg;
                    }
                    break;
                case "mallorder_shipped":
                    if (code == 701)
                    {
                        this.msg = string.IsNullOrEmpty(Msg) ? "订单已发货" : Msg;
                    }
                    break;
                case "mallcheck_approved":
                    if (code == 801)
                    {
                        this.msg = string.IsNullOrEmpty(Msg) ? "您有新待确认的绩效考核单" : Msg;
                    }
                    break;
                case "mallorder_sendapp":
                    if (code == 901)
                    {
                        this.msg = string.IsNullOrEmpty(Msg) ? "你有新的订单待处理" : Msg;
                    }
                    if (code == 902)
                    {
                        this.msg = string.IsNullOrEmpty(Msg) ? "有新订单来了，开始抢单" : Msg;
                    }
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        public string msg { get; set; }
        public string type { get; set; }
    }
    public class WechatNotifyModel
    {
        public int ID { get; set; }
        public string Value { get; set; }
        public int count { get; set; }
    }
    public class SurveyOption
    {
        public int ID { get; set; }
        public string OptionContent { get; set; }
        public int SortOrder { get; set; }
    }
    public class RentHomeTypeOption
    {
        public int ID { get; set; }
        public string TypeName { get; set; }
        public decimal UnitPrice { get; set; }
        public string Unit { get; set; }
        public decimal TypeArea { get; set; }
        public string TypeTags { get; set; }
        public int RentStatus { get; set; }
        public int count { get; set; }
    }
    public class WechatSurveyQuestionResponse
    {
        public int QuestionID { get; set; }
        public string Title { get; set; }
        public int type { get; set; }
        public List<WechatSurveyOptionResponse> options { get; set; }
    }
    public class WechatSurveyOptionResponse
    {
        public int OptionID { get; set; }
        public bool Selected { get; set; }
        public string Content { get; set; }
    }
    public class SiteVersionModel
    {
        public int VersionCode { get; set; }
        public string FilePath { get; set; }
        public string SqlPath { get; set; }
    }
    public class HouseServiceOption
    {
        public int ID { get; set; }
        public string TypeName { get; set; }
        public decimal BasicPrice { get; set; }
        public decimal UnitPrice { get; set; }
        public string Unit { get; set; }
        public string Remark { get; set; }
        public int count { get; set; }
    }
    public class ContractDivideTypeModel
    {
        public int ID { get; set; }
        public decimal DivideStartCost { get; set; }
        public decimal DivideEndCost { get; set; }
        public decimal Divide_Percent { get; set; }
        public int count { get; set; }
    }
    public class Mall_ProductPriceChangeModel
    {
        public int ProductID { get; set; }
        public int VariantID { get; set; }
        public decimal SalePrice { get; set; }
        public decimal NewSalePrice { get; set; }
    }
    public class RoomFeeModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal TotalCost { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int PrintID { get; set; }
        public string StartEndPoint { get; set; }
        public object[] historylist { get; set; }
        public bool Selected { get; set; }
        public bool ShowMore { get; set; }
    }
    public class MallProductVariantModel
    {
        public int ID { get; set; }
        public string VariantName { get; set; }
        public decimal VariantBasicPrice { get; set; }
        public decimal VariantPrice { get; set; }
        public string VariantTitle { get; set; }
        public int VariantPoint { get; set; }
        public int Inventory { get; set; }
        public int count { get; set; }
        public decimal VariantPointPrice { get; set; }
        public decimal VariantVIPPrice { get; set; }
        public int VariantVIPPoint { get; set; }
        public decimal VariantStaffPrice { get; set; }
        public int VariantStaffPoint { get; set; }
    }
    public class MallProductVariantPriceModel
    {
        public int ProductID { get; set; }
        public int VariantID { get; set; }
        public string VariantName { get; set; }
        public decimal VariantPrice { get; set; }
    }
    public class OrderSummary
    {
        public decimal totalprice { get; set; }
        public bool ispoint { get; set; }
        public decimal totalpoint { get; set; }
        public int totalsalepoint { get; set; }
        public string totalpricedesc { get; set; }
        public int stafftotalpoint { get; set; }
    }
    public class ContractCustomerModel
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public int CustomerType { get; set; }
        public string Address { get; set; }
        public string OfficerName { get; set; }
        public string ContactName { get; set; }
        public string PhoneNumber { get; set; }
        public string ChargeIDs { get; set; }
        public decimal ChargePercent { get; set; }
        public int[] ChargeIDList
        {
            get
            {
                if (!string.IsNullOrEmpty(this.ChargeIDs))
                {
                    return JsonConvert.DeserializeObject<int[]>(this.ChargeIDs);
                }
                return new int[] { };
            }
        }
        public int FinalCustomerType
        {
            get
            {
                if (this.CustomerType > 0)
                {
                    return this.CustomerType;
                }
                return 0;
            }
        }
    }
    public class ResponseDataGrid
    {
        /// <summary>
        /// 数据
        /// </summary>
        public List<Dictionary<string, object>> rows { get; set; } = new List<Dictionary<string, object>>();

        /// <summary>
        /// 总数据量
        /// </summary>
        public long total { get; set; }

        /// <summary>
        /// 当前页数
        /// </summary>
        public int page { get; set; }
    }
}
