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
    /// This object represents the properties and methods of a Wechat_User.
    /// </summary>
    public partial class Wechat_User : EntityBase
    {
        public static Wechat_User GetWechat_UserByUserOpenID(string OpenId)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                return GetWechat_UserByUserOpenid(OpenId, helper);
            }
        }
        public static Wechat_User GetWechat_UserByUserOpenid(string OpenId, SqlHelper helper)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@OpenId", OpenId));
            return GetOne<Wechat_User>("select * from [Wechat_User] where  ltrim(rtrim(OpenId))=ltrim(rtrim(@OpenId))", parameters, helper);
        }
        public string SexDesc
        {
            get
            {
                if (this.Sex < 0)
                {
                    return string.Empty;
                }
                string desc = string.Empty;
                switch (this.Sex)
                {
                    case 2:
                        desc = "女";
                        break;
                    case 1:
                        desc = "男";
                        break;
                    default:
                        break;
                }
                return desc;
            }
        }
        public string UnSubscribeDesc
        {
            get
            {
                if (this.SubScribe < 0)
                {
                    return string.Empty;
                }
                string desc = string.Empty;
                switch (this.SubScribe)
                {
                    case 1:
                        desc = "否";
                        break;
                    case 0:
                        desc = "是";
                        break;
                    default:
                        desc = "是";
                        break;
                }
                return desc;
            }
        }
    }
}
