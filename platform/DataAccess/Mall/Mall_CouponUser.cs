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
    /// This object represents the properties and methods of a Mall_CouponUser.
    /// </summary>
    public partial class Mall_CouponUser : EntityBase
    {
        public string IsUsedDesc
        {
            get
            {
                return this.IsUsed ? "已使用" : "未使用";
            }
        }
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
        
    }
}
