using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using Foresight.DataAccess.Framework;
using Utility;

namespace Foresight.DataAccess
{
    /// <summary>
    /// This object represents the properties and methods of a JPushLog.
    /// </summary>
    public partial class AnalysisAccessModel : EntityBaseReadOnly
    {

        protected override void EnsureParentProperties()
        {
        }
    }
    public partial class CallSummaryAnalysisModel : AnalysisAccessModel
    {
        public int UserID { get; set; }
        public string RealName { get; set; }
        public int TotalCallBackTimeOutCount { get; set; } = 0;
        public int TotalCallBackCount { get; set; } = 0;
        public string TotalCallBackTimeOutPercent
        {
            get
            {
                if (this.TotalCallBackCount <= 0)
                {
                    return "";
                }
                decimal percentValue = Math.Round((decimal)this.TotalCallBackTimeOutCount / this.TotalCallBackCount, 2, MidpointRounding.AwayFromZero);
                return (percentValue * 100).ToString() + "%";
            }
        }
        public int CallBackFromPhoneTotalCount { get; set; } = 0;
        public int CallBackFromPhonePickUpCount { get; set; } = 0;
        public string CallBackIsOnPercentDesc
        {
            get
            {
                if (this.CallBackFromPhoneTotalCount <= 0)
                {
                    return "";
                }
                decimal percentValue = Math.Round((decimal)this.CallBackFromPhonePickUpCount / this.CallBackFromPhoneTotalCount, 2, MidpointRounding.AwayFromZero);
                return (percentValue * 100).ToString() + "%";
            }
        }
        public int BaoXiuTotalCount { get; set; } = 0;
        public int BaoXiuCallBackCount { get; set; } = 0;
        public string BaoXiuCallBackPercentDesc
        {
            get
            {
                if (this.BaoXiuTotalCount <= 0)
                {
                    return "";
                }
                decimal percentValue = Math.Round((decimal)this.BaoXiuCallBackCount / this.BaoXiuTotalCount, 2, MidpointRounding.AwayFromZero);
                return (percentValue * 100).ToString() + "%";
            }
        }
        public int TotalCount { get; set; } = 0;
        public int TotalAddServiceTimeOutCount { get; set; } = 0;
        /// <summary>
        /// 投诉总数
        /// </summary>
        public decimal TouSuTotalCount { get; set; } = 0;
        /// <summary>
        /// 投诉可回访总数
        /// </summary>
        public decimal TouSuTotalCallbackCount { get; set; } = 0;
        /// <summary>
        /// 投诉已回访总数
        /// </summary>
        public int TouSuCallBackCount { get; set; } = 0;
        public string TouSuCallBackPercentDesc
        {
            get
            {
                if (this.TouSuTotalCallbackCount <= 0)
                {
                    return "";
                }
                decimal percentValue = Math.Round((decimal)this.TouSuCallBackCount / this.TouSuTotalCallbackCount, 2, MidpointRounding.AwayFromZero);
                if (percentValue > 1)
                {
                    return "100%";
                }
                return (percentValue * 100).ToString() + "%";
            }
        }
        public int TotalCallBackNotHuiFangCount { get; set; } = 0;
    }
    public partial class CallTotalAnalysisModel : AnalysisAccessModel
    {
        [DatabaseColumn("UserID")]
        public int UserID { get; set; }
        [DatabaseColumn("RealName")]
        public string RealName { get; set; }
        #region 整体时间
        /// <summary>
        /// 整体时间来电总数
        /// </summary>
        public int ALLCallTotalCount { get; set; }
        /// <summary>
        ///整体时间来电接通总数
        /// </summary>
        public int ALLCallIsOnCount { get; set; }
        /// <summary>
        /// 整体时间未接来电总数
        /// </summary>
        public int ALLCallNotOnCount
        {
            get
            {
                if (this.ALLCallTotalCount <= 0)
                {
                    return 0;
                }
                this.ALLCallIsOnCount = this.ALLCallIsOnCount > 0 ? this.ALLCallIsOnCount : 0;
                return this.ALLCallTotalCount - this.ALLCallIsOnCount;
            }
        }
        /// <summary>
        /// 整体时间未接来电回复数
        /// </summary>
        public int ALLCallNotPickUpBackCount { get; set; }
        /// <summary>
        /// 整体时间接通率
        /// </summary>
        public string ALLWorkCallOnPercent
        {
            get
            {
                if (this.ALLCallTotalCount <= 0)
                {
                    return "";
                }
                decimal percentValue = Math.Round((decimal)this.ALLCallIsOnCount / this.ALLCallTotalCount, 2, MidpointRounding.AwayFromZero);
                return (percentValue * 100).ToString() + "%";
            }
        }
        /// <summary>
        /// 整体时间未接来电回复率
        /// </summary>
        public string ALLWorkCallNotPickUpBackPercent
        {
            get
            {
                if (this.ALLCallNotOnCount <= 0)
                {
                    return "";
                }
                decimal percentValue = Math.Round((decimal)this.ALLCallNotPickUpBackCount / this.ALLCallNotOnCount, 2, MidpointRounding.AwayFromZero);
                return (percentValue * 100).ToString() + "%";
            }
        }
        #endregion
        #region 工作时间
        /// <summary>
        /// 工作时间来电总数
        /// </summary>
        public int WorkCallTotalCount { get; set; }
        /// <summary>
        /// 工作时间来电接通总数
        /// </summary>
        public int WorkCallIsOnCount { get; set; }
        /// <summary>
        /// 工作时间未接来电总数
        /// </summary>
        public int WorkCallNotOnCount
        {
            get
            {
                if (this.WorkCallTotalCount <= 0)
                {
                    return 0;
                }
                this.WorkCallIsOnCount = this.WorkCallIsOnCount > 0 ? this.WorkCallIsOnCount : 0;
                return this.WorkCallTotalCount - this.WorkCallIsOnCount;
            }
        }
        /// <summary>
        /// 工作时间接通率(%)
        /// </summary>
        public string WorkCallOnPercent
        {
            get
            {
                if (this.WorkCallTotalCount <= 0)
                {
                    return "";
                }
                decimal percentValue = Math.Round((decimal)this.WorkCallIsOnCount / this.WorkCallTotalCount, 2, MidpointRounding.AwayFromZero);
                return (percentValue * 100).ToString() + "%";
            }
        }
        /// <summary>
        /// 工作时间未接来电回复数
        /// </summary>
        public int WorkCallNotPickUpBackCount { get; set; }
        #endregion
        #region 非工作时间
        /// <summary>
        /// 非工作时间来电总数
        /// </summary>
        public int NotWorkCallTotalCount
        {
            get
            {
                if (this.ALLCallTotalCount <= 0)
                {
                    return 0;
                }
                this.WorkCallTotalCount = this.WorkCallTotalCount > 0 ? this.WorkCallTotalCount : 0;
                return this.ALLCallTotalCount - this.WorkCallTotalCount;
            }
        }
        /// <summary>
        /// 非工作时间来电接通总数
        /// </summary>
        public int NotWorkCallIsOnCount
        {
            get
            {
                if (this.ALLCallIsOnCount <= 0)
                {
                    return 0;
                }
                this.WorkCallIsOnCount = this.WorkCallIsOnCount > 0 ? this.WorkCallIsOnCount : 0;
                return this.ALLCallIsOnCount - this.WorkCallIsOnCount;
            }
        }
        /// <summary>
        /// 非工作时间未接来电总数
        /// </summary>
        public int NotWorkCallNotOnCount
        {
            get
            {
                if (this.NotWorkCallTotalCount <= 0)
                {
                    return 0;
                }
                return this.NotWorkCallTotalCount - this.NotWorkCallIsOnCount;
            }
        }
        /// <summary>
        /// 非工作时间未接来电回复数
        /// </summary>
        public int NotWorkCallNotPickUpBackCount
        {
            get
            {
                if (this.ALLCallNotPickUpBackCount <= 0)
                {
                    return 0;
                }
                return this.ALLCallNotPickUpBackCount - this.WorkCallNotPickUpBackCount;
            }
        }
        /// <summary>
        /// 非工作时间未接来电回复率
        /// </summary>
        public string NotWorkCallNotPickUpBackPercent
        {
            get
            {
                if (this.NotWorkCallNotOnCount <= 0)
                {
                    return "";
                }
                decimal percentValue = Math.Round((decimal)this.NotWorkCallNotPickUpBackCount / this.NotWorkCallNotOnCount, 2, MidpointRounding.AwayFromZero);
                return (percentValue * 100).ToString() + "%";
            }
        }
        #endregion
    }
    public partial class TouSuCountAnalysisModel : AnalysisAccessModel
    {
        [DatabaseColumn("CompanyID")]
        public int CompanyID { get; set; }
        [DatabaseColumn("CompanyName")]
        public string CompanyName { get; set; }
        [DatabaseColumn("ProjectName")]
        public string ProjectName { get; set; }
        [DatabaseColumn("ProjectID")]
        public int ProjectID { get; set; }
        [DatabaseColumn("ServiceTypeID")]
        public int ServiceTypeID { get; set; }
        [DatabaseColumn("TotalCount")]
        public int TotalCount { get; set; }
        [DatabaseColumn("AllParentID")]
        public string AllParentID { get; set; }
        [DatabaseColumn("ServiceType2ID")]
        public int ServiceType2ID { get; set; }
        [DatabaseColumn("ServiceTypeName2")]
        public string ServiceTypeName2 { get; set; }
        [DatabaseColumn("ServiceType3ID")]
        public int ServiceType3ID { get; set; }
        [DatabaseColumn("ServiceTypeName3")]
        public string ServiceTypeName3 { get; set; }
    }
    public partial class TouSuFromAnalysisModel : AnalysisAccessModel
    {
        [DatabaseColumn("ServiceFrom")]
        public string ServiceFrom { get; set; }
        [DatabaseColumn("TotalCount")]
        public int TotalCount { get; set; }
        public string FromNameDesc
        {
            get
            {
                if (string.IsNullOrEmpty(this.ServiceFrom))
                {
                    return string.Empty;
                }
                return Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.WechatServiceFromDefine), this.ServiceFrom);
            }
        }
    }
    public partial class RepairCountAnalysisModel : AnalysisAccessModel
    {
        [DatabaseColumn("CompanyID")]
        public int CompanyID { get; set; }
        [DatabaseColumn("CompanyName")]
        public string CompanyName { get; set; }
        [DatabaseColumn("ProjectID")]
        public int ProjectID { get; set; }
        [DatabaseColumn("ProjectName")]
        public string ProjectName { get; set; }
        [DatabaseColumn("ServiceType2ID")]
        public int ServiceType2ID { get; set; }
        [DatabaseColumn("ServiceTypeName2")]
        public string ServiceTypeName2 { get; set; }
        [DatabaseColumn("ServiceType3ID")]
        public int ServiceType3ID { get; set; }
        [DatabaseColumn("ServiceTypeName3")]
        public string ServiceTypeName3 { get; set; }
        [DatabaseColumn("TotalCount")]
        public int TotalCount { get; set; }
    }
    public partial class YingXiaoManyiAnalysisModel : AnalysisAccessModel
    {
        [DatabaseColumn("AllParentID")]
        public string AllParentID { get; set; }
        [DatabaseColumn("CompanyID")]
        public int CompanyID { get; set; }
        [DatabaseColumn("CompanyName")]
        public string CompanyName { get; set; }
        [DatabaseColumn("ProjectID")]
        public int ProjectID { get; set; }
        [DatabaseColumn("ProjectName")]
        public string ProjectName { get; set; }
        [DatabaseColumn("TotalCount")]
        public decimal TotalCount { get; set; }
        [DatabaseColumn("TotalRate")]
        public decimal TotalRate { get; set; }
        public decimal AverageRate
        {
            get
            {
                if (this.TotalCount <= 0)
                {
                    return 0;
                }
                return Math.Round((decimal)this.TotalRate / this.TotalCount, 2, MidpointRounding.AwayFromZero);
            }
        }
        [DatabaseColumn("ServiceTypeID")]
        public int ServiceTypeID { get; set; }
        public string ServiceTypeName
        {
            get
            {
                if (this.ServiceTypeID == 1)
                {
                    return "营销投诉";
                }
                if (this.ServiceTypeID == 3)
                {
                    return "物业投诉";
                }
                if (this.ServiceTypeID == 4)
                {
                    return "维修";
                }
                return string.Empty;
            }
        }

    }
    public partial class TouSuShiXiaoAnalysisModel : AnalysisAccessModel
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public decimal TotalCount { get; set; }
        public int ChaoShiCount { get; set; }
        public decimal ResponseTimeOutHour { get; set; }
        public decimal AverageResponseTimeOut
        {
            get
            {
                if (this.TotalCount <= 0)
                {
                    return 0;
                }
                return Math.Round((decimal)this.ResponseTimeOutHour / this.TotalCount, 2, MidpointRounding.AwayFromZero);
            }
        }
        public decimal ProcessTimeOut { get; set; }
        public decimal AverageProcessTimeOut
        {
            get
            {
                if (this.TotalCount <= 0)
                {
                    return 0;
                }
                decimal percentValue = Math.Round((decimal)this.ProcessTimeOut / this.TotalCount, 2, MidpointRounding.AwayFromZero);
                return percentValue;
            }
        }
        public decimal CheckTimeOut { get; set; }
        public decimal AverageCheckTimeOut
        {
            get
            {
                if (this.TotalCount <= 0)
                {
                    return 0;
                }
                decimal percentValue = Math.Round((decimal)this.CheckTimeOut / this.TotalCount, 2, MidpointRounding.AwayFromZero);
                return percentValue;
            }
        }
        public string TimeOutPercent
        {
            get
            {
                if (this.TotalCount <= 0)
                {
                    return "";
                }
                decimal percentValue = Math.Round((decimal)this.ChaoShiCount / this.TotalCount, 2, MidpointRounding.AwayFromZero);
                return (100 * percentValue).ToString() + "%";
            }
        }
        public string ServiceTypeName2 { get; set; }
        public string ServiceTypeName3 { get; set; }
        public decimal TotalBanJieTimeOut { get; set; }
        public decimal AverageTotalBanJieTimeOut
        {
            get
            {
                if (this.TotalCount <= 0)
                {
                    return 0;
                }
                decimal percentValue = Math.Round((decimal)this.TotalBanJieTimeOut / this.TotalCount, 2, MidpointRounding.AwayFromZero);
                return percentValue;
            }
        }
    }
    public partial class RepairFeeAnalysisModel : AnalysisAccessModel
    {
        [DatabaseColumn("CompanyID")]
        public int CompanyID { get; set; }
        [DatabaseColumn("CompanyName")]
        public string CompanyName { get; set; }
        [DatabaseColumn("ProjectID")]
        public int ProjectID { get; set; }
        [DatabaseColumn("ProjectName")]
        public string ProjectName { get; set; }
        [DatabaseColumn("ServiceTypeName2")]
        public string ServiceTypeName2 { get; set; }
        public string ServiceTypeName3 { get; set; }
        [DatabaseColumn("HandleFee")]
        public decimal HandleFee { get; set; }
    }
    public partial class ChuLiJieDianAnalysisModel : AnalysisAccessModel
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public int ServiceType2ID { get; set; }
        public int ServiceType3ID { get; set; }
        public string ServiceTypeName2 { get; set; }
        public string ServiceTypeName3 { get; set; }
        public decimal TotalCount { get; set; }
        public decimal ResponseTotalTakeHour { get; set; }
        public decimal PaiDanTotalTakeHour { get; set; }
        public decimal ChuLiTotalTakeHour { get; set; }
        public decimal BanJieTotalTakeHour { get; set; }
        public decimal HuiFangTotalTakeHour { get; set; }
        public decimal AverageResponseTotalTakeHour
        {
            get
            {
                if (this.TotalCount <= 0)
                {
                    return 0;
                }
                return Math.Round((decimal)this.ResponseTotalTakeHour / this.TotalCount, 2, MidpointRounding.AwayFromZero);
            }
        }
        public decimal AveragePaiDanTotalTakeHour
        {
            get
            {
                if (this.TotalCount <= 0)
                {
                    return 0;
                }
                return Math.Round((decimal)this.PaiDanTotalTakeHour / this.TotalCount, 2, MidpointRounding.AwayFromZero);
            }
        }
        public decimal AverageChuLiTotalTakeHour
        {
            get
            {
                if (this.TotalCount <= 0)
                {
                    return 0;
                }
                return Math.Round((decimal)this.ChuLiTotalTakeHour / this.TotalCount, 2, MidpointRounding.AwayFromZero);
            }
        }
        public decimal AverageBanJieTotalTakeHour
        {
            get
            {
                if (this.TotalCount <= 0)
                {
                    return 0;
                }
                return Math.Round((decimal)this.BanJieTotalTakeHour / this.TotalCount, 2, MidpointRounding.AwayFromZero);
            }
        }
        public decimal AverageHuiFangTotalTakeHour
        {
            get
            {
                if (this.TotalCount <= 0)
                {
                    return 0;
                }
                return Math.Round((decimal)this.HuiFangTotalTakeHour / this.TotalCount, 2, MidpointRounding.AwayFromZero);
            }
        }
    }
}
