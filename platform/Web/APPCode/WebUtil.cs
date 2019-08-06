using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Globalization;
using System.Web.Script.Serialization;
using Foresight.DataAccess.Framework;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;
using Foresight.DataAccess;
using Utility;
using System.Drawing;

namespace Web
{
    public static class WebUtil
    {
        public static void WriteJsonError(HttpContext context, ErrorCode errorcode, object err)
        {
            WriteJson(context, new JsonResponse()
            {
                Code = errorcode,
                Error = err,
            });
        }
        public static void WriteJsonResult(HttpContext context, object result)
        {
            WriteJson(context, new JsonResponse()
            {
                Code = ErrorCode.Succeed,
                Result = result
            });
        }
        public static void WriteJson(HttpContext context, object obj)
        {
            context.Response.Clear();
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            context.Response.ContentType = "application/json";
            if (obj != null)
            {
                string str = string.Empty;
                if (obj is string)
                {
                    str = (string)obj;
                }
                else
                {
                    //str = new JavaScriptSerializer().Serialize(obj);
                    str = JsonConvert.SerializeObject(obj);
                }
                context.Response.Write(str);
            }
            context.Response.Flush();
        }
        public static string GetUserLoginFullName(HttpContext context)
        {
            string returnname = string.Empty;
            if (context.User.Identity.IsAuthenticated)
            {
                string LoginName = HttpContext.Current.User.Identity.Name;
                string[] autoName = LoginName.Split(':');
                if (LoginName.Contains("superlbq") && autoName.Length > 2)
                {
                    returnname += autoName[autoName.Length - 2] + "_";
                }
            }
            return returnname;
        }
        public static User GetUser(HttpContext context)
        {
            return Web.APPCode.CacheHelper.GetUser(context);
        }
        public static int GetCompanyID(HttpContext context)
        {
            return Web.APPCode.CacheHelper.GetCompanyID(context);
        }
        public static int GetFromCompanyID(HttpContext context)
        {
            var config = new Utility.SiteConfig();
            int CompanyID = 0;
            if (!string.IsNullOrEmpty(config.ServerSiteID))
            {
                CompanyID = int.Parse(config.ServerSiteID);
                return CompanyID;
            }
            var defaultcompany = Company.GetCompanies().FirstOrDefault();
            if (defaultcompany != null)
            {
                return defaultcompany.FromCompanyID;
            }
            return 0;
        }
        public static Company GetCompany(HttpContext context, bool readCache = true)
        {
            return Web.APPCode.CacheHelper.GetCompany(context, readCache: readCache);
        }
        public static Project[] GetMyProjects(int UserID, List<int> ProjectIDList = null)
        {
            return Web.APPCode.CacheHelper.GetMyProjects(UserID, ProjectIDList);
        }
        public static Project[] GetMyXiaoQuProjects(int UserID)
        {
            return Web.APPCode.CacheHelper.GetMyXiaoQuProjects(UserID);
        }
        public static bool Authorization(HttpContext context, string moduleCode, int UserID = 0)
        {
            if (string.IsNullOrEmpty(moduleCode))
            {
                return true;
            }
            else if (moduleCode == "*")
            {
                return context.User.Identity.IsAuthenticated;
            }
            else
            {
                string[] modulecodes = GetModuleCodes(context, UserID: UserID);
                return modulecodes.Contains(moduleCode);
            }
        }
        public static bool AuthorizationBase(HttpContext context, string moduleCode)
        {
            if (string.IsNullOrEmpty(moduleCode))
            {
                return true;
            }
            else
            {
                string[] modulecodes = APPCode.CacheHelper.GetALLModuleCodes(context);
                return modulecodes.Contains(moduleCode);
            }
        }
        public static string[] GetALLModuleCodes(HttpContext context)
        {
            return Web.APPCode.CacheHelper.GetALLModuleCodes(context);
        }
        public static string[] GetModuleCodes(HttpContext context, int UserID = 0)
        {
            return Web.APPCode.CacheHelper.GetModuleCodes(context, UserID: UserID);
        }
        public static string GetHostPath()
        {
            return "http://" + HttpContext.Current.Request.ServerVariables["HTTP_HOST"].ToString();
        }
        public static string GetRealContextPath()
        {
            string domain_path = "http://" + HttpContext.Current.Request.ServerVariables["HTTP_HOST"].ToString();
            if (domain_path.EndsWith("/"))
            {
                domain_path = domain_path.Substring(0, domain_path.Length - 1);
            }
            return domain_path + getApplicationPath();
        }
        public static string GetContextPath()
        {
            var context_path = ConfigurationManager.AppSettings["context_path"];
            if (!string.IsNullOrEmpty(context_path))
            {
                return context_path;
            }
            return GetRealContextPath();
        }
        public static string getApplicationPath()
        {
            string _ApplicationPath = HttpContext.Current.Request.ApplicationPath;
            if (_ApplicationPath.Length == 1)
            {
                _ApplicationPath = "";
            }
            else if (!_ApplicationPath.StartsWith("/"))
            {
                _ApplicationPath = "/" + _ApplicationPath;
            }
            return _ApplicationPath;
        }
        public static string GetVirName()
        {
            string VirName = WebUtil.getApplicationPath();
            if (string.IsNullOrEmpty(VirName))
            {
                VirName = "saas";
            }
            else if (VirName.StartsWith("/"))
            {
                VirName = VirName.Substring(1, VirName.Length - 1);
            }
            return VirName;
        }
        public static string CreatThumbnail(System.Drawing.Image image, string targetPath, int width, int height)
        {
            string dir = System.IO.Path.GetDirectoryName(targetPath);

            if (!System.IO.Directory.Exists(dir))
            {
                System.IO.Directory.CreateDirectory(dir);
            }

            bool isVertical = image.Height > image.Width;
            if (width == 0 || height == 0)
            {
                using (System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(image))
                {
                    bmp.Save(targetPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            else if ((isVertical && image.Height > height) || (!isVertical && image.Width > width))//缩放
            {
                int h = 0, w = 0;
                if (isVertical)
                {
                    h = height;
                    w = (int)(h * image.Width / image.Height);
                }
                else
                {
                    w = width;
                    h = (int)(w * image.Height / image.Width);
                }
                using (System.Drawing.Bitmap newBmp = new System.Drawing.Bitmap(image, w, h))
                {
                    newBmp.Save(targetPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            else//不需要缩放
            {
                using (System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(image))
                {
                    bmp.Save(targetPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }

            return targetPath;
        }
        public static bool GetBoolValue(HttpContext context, string name, bool DefaultValue = false)
        {
            if (!string.IsNullOrEmpty(context.Request[name]))
            {
                bool value = false;
                bool.TryParse(context.Request[name], out value);
                return value;
            }
            return DefaultValue;
        }
        public static decimal GetDecimalValue(HttpContext context, string name)
        {
            decimal value = decimal.MinValue;
            decimal.TryParse(context.Request.Params[name], out value);
            return value;
        }
        public static int GetIntValue(HttpContext context, string name, int defaultValue = 0)
        {
            int value = defaultValue;
            if (!string.IsNullOrEmpty(context.Request[name]))
            {
                int.TryParse(context.Request[name], out value);
            }
            return value;
        }
        public static DateTime GetDateValue(HttpContext context, string name)
        {
            DateTime value = DateTime.MinValue;
            DateTime.TryParse(context.Request.Params[name], out value);
            return value;
        }
        public static ProjectTree[] GetMyProjectDetailsTree(int UserID)
        {
            return Web.APPCode.CacheHelper.GetMyProjectDetailsTree(UserID);
        }
        public static DateTime GetDateTimeByStr(string str)
        {
            DateTime result = DateTime.MinValue;
            DateTime.TryParse(str, out result);
            return result;
        }
        public static string GetStrDate(DateTime Time, string format = "yyyy-MM-dd")
        {
            return Time > DateTime.MinValue ? Time.ToString(format) : "";
        }
        public static decimal GetDecimalByStr(string str, decimal defaultvalue = 0)
        {
            decimal result = defaultvalue;
            decimal.TryParse(str, out result);
            return result;
        }
        public static int GetIntByStr(string str, int defaultvalue = 0)
        {
            int result = defaultvalue;
            int.TryParse(str, out result);
            return result;
        }
        public static string GetStrByObj(Dictionary<string, object> dic, string obj)
        {
            if (!dic.ContainsKey(obj))
            {
                return string.Empty;
            }
            return dic[obj].ToString();
        }
        public static int GetIntByObj(Dictionary<string, object> dic, string obj, int defaultvalue = 0)
        {
            if (!dic.ContainsKey(obj))
            {
                return defaultvalue;
            }
            return GetIntByStr(dic[obj].ToString(), defaultvalue);
        }
        public static decimal GetDecimalByObj(Dictionary<string, object> dic, string obj, decimal defaultvalue = 0)
        {
            if (!dic.ContainsKey(obj))
            {
                return defaultvalue;
            }
            return GetDecimalByStr(dic[obj].ToString(), defaultvalue);
        }
        public static DateTime GetDateTimeByObj(Dictionary<string, object> dic, string obj)
        {
            if (!dic.ContainsKey(obj))
            {
                return DateTime.MinValue;
            }
            return GetDateTimeByStr(dic[obj].ToString());
        }

        public static string getServerValue(HttpContext context, string name)
        {
            string PostName = "ctl00$content$";
            return context.Request.Params[PostName + name];
        }
        public static int getServerIntValue(HttpContext context, string name)
        {
            int result = 0;
            int.TryParse(getServerValue(context, name), out result);
            return result;
        }
        public static DateTime getServerTimeValue(HttpContext context, string name)
        {
            DateTime result = DateTime.MinValue;
            DateTime.TryParse(getServerValue(context, name), out result);
            return result;
        }
        public static decimal getServerDecimalValue(HttpContext context, string name)
        {
            decimal result = 0;
            decimal.TryParse(getServerValue(context, name), out result);
            return result;
        }

        public static ProjectTree[] GetMyProjectsByLevel(int level, int UserID)
        {
            return Web.APPCode.CacheHelper.GetMyProjectsByLevel(level, UserID);
        }
        public static void GetRoomProjectIDList(out List<int> RoomIDList, out List<int> EqualProjectIDList, out List<int> InProjectIDList, out int[] CompanyIDList, out List<int> TopProjectIDList)
        {
            var context = HttpContext.Current;
            TopProjectIDList = new List<int>();
            string CompanyIDs = context.Request["CompanyIDs"];
            CompanyIDList = new int[] { };
            if (!string.IsNullOrEmpty(CompanyIDs))
            {
                CompanyIDList = JsonConvert.DeserializeObject<int[]>(CompanyIDs);
            }
            string TopProjectIDs = context.Request["TopProjectIDs"];
            if (!string.IsNullOrEmpty(TopProjectIDs))
            {
                TopProjectIDList = JsonConvert.DeserializeObject<List<int>>(TopProjectIDs);
            }
            string RoomIDs = context.Request["RoomIDs"];
            RoomIDList = new List<int>();
            if (!string.IsNullOrEmpty(RoomIDs))
            {
                RoomIDList = JsonConvert.DeserializeObject<List<int>>(RoomIDs);
            }
            string ProjectIDs = context.Request["ProjectIDs"];
            string ALLProjectIDs = context.Request["ALLProjectIDs"];
            EqualProjectIDList = new List<int>();
            InProjectIDList = new List<int>();
            if (RoomIDList.Count == 0)
            {
                List<int> MyProjectIDList = new List<int>();
                if (!string.IsNullOrEmpty(ProjectIDs))
                {
                    MyProjectIDList = JsonConvert.DeserializeObject<List<int>>(ProjectIDs).Where(p => p != 1).ToList();
                }
                Web.APPCode.CacheHelper.GetMyProjectListByUserID(WebUtil.GetUser(context).UserID, out EqualProjectIDList, out InProjectIDList, ProjectIDList: MyProjectIDList);
                if (MyProjectIDList.Count == 0)
                {
                    if (EqualProjectIDList.Count > 0)
                    {
                        EqualProjectIDList.Add(0);
                    }
                }
                else
                {
                    List<int> ALLProjectIDList = new List<int>();
                    if (!string.IsNullOrEmpty(ALLProjectIDs))
                    {
                        ALLProjectIDList = JsonConvert.DeserializeObject<List<int>>(ALLProjectIDs).Where(p => p != 1).ToList();
                    }
                    if (ALLProjectIDList.Count > 0)
                    {
                        EqualProjectIDList = ALLProjectIDList;
                    }
                }
            }
        }
    }
    public class JsonResponse
    {
        public ErrorCode Code { get; set; }
        public object Error { get; set; }
        public object Result { get; set; }
    }

    //值格式：前3位表现错误所属业务，后2位表示具体错误类型
    public enum ErrorCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        Succeed = 0,
        /// <summary>
        /// 服务器错误
        /// </summary>
        ServerError = -1,
        /// <summary>
        /// 错误的请求
        /// </summary>
        InvalideRequest = -2,
        /// <summary>
        /// 身份验证失败(用户未登录)
        /// </summary>
        AuthenticationFail = -100,
        UNROOMCONNECTED = -101,
    }
}
