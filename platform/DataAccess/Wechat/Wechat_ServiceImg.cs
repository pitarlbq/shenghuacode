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
	/// This object represents the properties and methods of a Wechat_ServiceImg.
	/// </summary>
	public partial class Wechat_ServiceImg : EntityBase
	{
        public static Wechat_ServiceImg[] GetWechat_ServiceImgList(int WechatServiceID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            List<string> conditions = new List<string>();
            conditions.Add("[ServiceID]=@WechatServiceID");
            parameters.Add(new SqlParameter("@WechatServiceID", WechatServiceID));
            return GetList<Wechat_ServiceImg>("select * from [Wechat_ServiceImg] where " + string.Join(" and ", conditions.ToArray()) + " order by AddTime desc", parameters).ToArray();
        }
	}
}
