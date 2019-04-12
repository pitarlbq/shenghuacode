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
    /// This object represents the properties and methods of a Wechat_Service.
    /// </summary>
    public partial class Wechat_Service : EntityBase
    {

        public string ServiceTypeDesc
        {
            get
            {
                if (string.IsNullOrEmpty(this.ServiceType))
                {
                    return string.Empty;
                }
                return Utility.EnumHelper.GetDescription(typeof(Utility.EnumModel.WechatServiceType), this.ServiceType);
            }
        }
        public string ServiceFromDesc
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
}
