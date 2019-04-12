using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility
{
    public class SmsHelper
    {
        public static bool SendSms(string mobile, string content, string verifyCode)
        {
            var config = new Utility.SiteConfig();
            if (config.PaasSmsServerEnable)
            {
                return Utility.PaasSms.Send(mobile, content);
            }
            else if (config.tencentSmsEnable)
            {
                return Utility.TencentSms.Send(mobile, verifyCode);
            }
            return false;
        }
    }
}
