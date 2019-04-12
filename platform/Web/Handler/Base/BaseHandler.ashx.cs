using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.SessionState;

namespace Web.Handler
{
    /// <summary>
    /// BaseHandler 的摘要说明
    /// </summary>
    public class BaseHandler : IRequiresSessionState
    {
        /// <summary>
        /// 供子类重写的封装逻辑
        /// </summary>
        protected delegate void WrapWhereParamCallbck();
        /// <summary>
        /// 提供参数的集合
        /// </summary>
        protected Dictionary<string, object> AccpetParam = new Dictionary<string, object>();
        /// <summary>
        /// 处理集合
        /// </summary>
        public BaseHandler()
        {
        }
        /// <summary>
        /// 包装请求参数
        /// </summary>
        /// <param name="context">参数</param>
        /// <param name="callback">包装的代理方法</param>
        protected void WrapParams(HttpContext context, WrapWhereParamCallbck callback)
        {
            NameValueCollection param = context.Request.Params;
            IEnumerator paramEnum = param.GetEnumerator();
            while (paramEnum.MoveNext())
            {
                if (paramEnum.Current != null)
                {
                    string key = paramEnum.Current.ToString();
                    if (AccpetParam.ContainsKey(key))
                    {
                        continue;
                    }
                    AccpetParam.Add(key, context.Request[key]);
                }
            }
            if (callback != null)
            {
                callback();
            }
        }
        /// <summary>
        /// 通过键名获取参数集合里面的值
        /// </summary>
        /// <param name="key">参数</param>
        /// <returns>返回处理后的字符</returns>
        protected object GainDataFromAccpetParamByKey(string key)
        {
            if (AccpetParam.ContainsKey(key))
            {
                return AccpetParam[key];
            }
            return null;
        }
    }
}