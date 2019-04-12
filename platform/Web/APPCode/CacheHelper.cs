using Foresight.DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.APPCode
{
    public class CacheHelper
    {
        public static readonly string user_key = GetSessionPrefix() + "User";
        static readonly string company_id_key = GetSessionPrefix() + "companyid";
        static readonly string company_key = GetSessionPrefix() + "company";
        static readonly string myprojects_key = GetSessionPrefix() + "projectlist";
        static readonly string myxiaoqu_key = GetSessionPrefix() + "xiaoqulist";
        static readonly string all_modulecodes_key = GetSessionPrefix() + "ALLModuleCodes";
        static readonly string modulecodes_key = GetSessionPrefix() + "ModuleCodes";
        static readonly string projectdetailstree_key = GetSessionPrefix() + "projectdetailstree";
        static readonly string projectlevellist_key = GetSessionPrefix() + "projectlevellist";
        static readonly string EqualProjectIDList_key = GetSessionPrefix() + "EqualProjectIDList";
        static readonly string InProjectIDList_key = GetSessionPrefix() + "InProjectIDList";
        static readonly string wechat_currentproject = GetSessionPrefix() + "wxcurrentproject";
        public static string GetSessionPrefix()
        {
            string application_name = WebUtil.getApplicationPath();
            return string.IsNullOrEmpty(application_name) ? string.Empty : application_name + "_";
        }
        public static User GetUser(HttpContext context)
        {
            User user = null;
            if (context.User.Identity.IsAuthenticated)
            {
                string LoginName = HttpContext.Current.User.Identity.Name;
                string self_user_key = user_key + "_" + LoginName;
                var cache = HttpRuntime.Cache;
                if (cache.Get(self_user_key) != null)
                {
                    user = cache.Get(self_user_key) as User;
                    return user;
                }
                string[] autoName = LoginName.Split(':');
                if (autoName.Length > 1)
                {
                    LoginName = autoName[autoName.Length - 1];
                }
                user = User.GetUserByLoginName(LoginName);
                if (user != null)
                {
                    cache.Insert(self_user_key, user);
                    return user;
                }
            }
            context.Response.Clear();
            context.Response.Write("<Script language=javascript>\n");
            context.Response.Write("top.location.href='" + WebUtil.GetContextPath() + "/login.aspx?op=logout';\n");
            context.Response.Write("</Script>");
            //context.Response.End();
            //context.Response.Redirect("~/login.aspx?");
            return user;
        }
        public static int GetCompanyID(HttpContext context)
        {
            int CompanyID = 0;
            var cache = HttpRuntime.Cache;
            if (cache.Get(company_id_key) != null)
            {
                CompanyID = Convert.ToInt32(cache.Get(company_id_key));
                return CompanyID;
            }
            var defaultcompany = Company.GetCompanyByUserID(GetUser(context).UserID);
            if (defaultcompany != null)
            {
                cache.Insert(company_id_key, defaultcompany.CompanyID);
                return defaultcompany.CompanyID;
            }
            return 0;
        }
        public static Company GetCompany(HttpContext context, bool readCache = true)
        {
            Company company = null;
            var cache = HttpRuntime.Cache;
            if (cache.Get(company_key) != null && readCache)
            {
                company = cache.Get(company_key) as Company;
                return company;
            }
            else
            {
                string BaseURL = WebUtil.GetContextPath();
                string errormsg = string.Empty;
                var my_company = Company.GetCompanies().FirstOrDefault();
                if (company == null)
                {
                    company = my_company;
                }
                if (company != null && string.IsNullOrEmpty(my_company.SystemNo))
                {
                    my_company.SystemNo = company.SystemNo;
                    my_company.Save();
                }
            }
            if (company != null)
            {
                cache.Insert(company_key, company);
            }
            return company;
        }
        public static Project[] GetMyProjects(int UserID, List<int> ProjectIDList = null)
        {
            if (ProjectIDList != null && ProjectIDList.Count > 0)
            {
                return Project.GetProjectListByUserID(UserID, ProjectIDList);
            }
            var cache = HttpRuntime.Cache;
            Project[] projectlist = null;
            string self_myprojects_key = myprojects_key + "_" + UserID;
            if (cache.Get(self_myprojects_key) != null)
            {
                projectlist = cache.Get(self_myprojects_key) as Project[];
                return projectlist;
            }
            projectlist = Project.GetProjectListByUserID(UserID, ProjectIDList);
            if (projectlist != null)
            {
                cache.Insert(self_myprojects_key, projectlist);
            }
            return projectlist;
        }
        public static Project[] GetMyXiaoQuProjects(int UserID)
        {
            var cache = HttpRuntime.Cache;
            Project[] projectlist = null;
            string self_myxiaoqu_key = myxiaoqu_key + "_" + UserID;
            if (cache.Get(self_myxiaoqu_key) != null)
            {
                projectlist = cache.Get(self_myxiaoqu_key) as Project[];
                return projectlist;
            }
            projectlist = Project.GetXiaoQuProjectListBySystemUserID(UserID);
            if (projectlist != null)
            {
                cache.Insert(self_myxiaoqu_key, projectlist);
            }
            return projectlist;
        }
        public static string[] GetALLModuleCodes(HttpContext context)
        {
            return null;
        }
        public static string[] GetModuleCodes(HttpContext context, int UserID = 0)
        {
            UserID = UserID > 0 ? UserID : GetUser(context).UserID;
            var cache = HttpRuntime.Cache;
            string[] modulecodes = null;
            string self_modulecodes_key = modulecodes_key + "_" + UserID;
            if (cache.Get(self_modulecodes_key) != null)
            {
                modulecodes = cache.Get(self_modulecodes_key) as string[];
            }
            else
            {
                modulecodes = Foresight.DataAccess.SysMenu.GetSysModulesForUserByUserId(UserID).Select(p => p.ModuleCode).ToArray();
                string[] allmodulecodes = GetALLModuleCodes(context);
                if (allmodulecodes != null)
                {
                    modulecodes = modulecodes.Intersect(allmodulecodes).ToArray();
                }
            }
            if (modulecodes != null)
            {
                cache.Insert(self_modulecodes_key, modulecodes);
            }
            return modulecodes;
        }
        public static ProjectTree[] GetMyProjectDetailsTree(int UserID)
        {
            var cache = HttpRuntime.Cache;
            ProjectTree[] projectdetailstree = null;
            string self_projectdetailstree_key = projectdetailstree_key + "_" + UserID;
            if (cache.Get(self_projectdetailstree_key) != null)
            {
                projectdetailstree = cache.Get(self_projectdetailstree_key) as ProjectTree[];
                return projectdetailstree;
            }
            projectdetailstree = ProjectTree.GetProjectTreeListByID(0, string.Empty, UserID).ToArray();
            if (projectdetailstree != null)
            {
                cache.Insert(self_projectdetailstree_key, projectdetailstree);
            }
            return projectdetailstree;
        }
        public static ProjectTree[] GetMyProjectsByLevel(int level, int UserID)
        {
            var cache = HttpRuntime.Cache;
            ProjectTree[] projectlist = null;
            string self_projectlevellist_key = projectlevellist_key + "_" + UserID;
            if (cache.Get(self_projectlevellist_key) != null)
            {
                projectlist = cache.Get(self_projectlevellist_key) as ProjectTree[];
                return projectlist;
            }
            projectlist = ProjectTree.GetProjectTreeListByID(0, string.Empty, UserID, IconID: level).ToArray();
            if (projectlist != null)
            {
                cache.Insert(self_projectlevellist_key, projectlist);
            }
            return projectlist;
        }
        public static void GetMyProjectListByUserID(int UserID, out List<int> EqualProjectIDList, out List<int> InProjectIDList, List<int> ProjectIDList = null)
        {
            var cache = HttpRuntime.Cache;
            EqualProjectIDList = new List<int>();
            InProjectIDList = new List<int>();
            string self_EqualProjectIDList_key = EqualProjectIDList_key + "_" + UserID;
            string self_InProjectIDList_key = InProjectIDList_key + "_" + UserID;
            if (cache.Get(self_EqualProjectIDList_key) == null || cache.Get(self_InProjectIDList_key) == null || (ProjectIDList != null && ProjectIDList.Count > 0))
            {
                Project.GetMyProjectListByUserID(UserID, out EqualProjectIDList, out InProjectIDList, ProjectIDList: ProjectIDList);
                if (ProjectIDList == null || ProjectIDList.Count == 0)
                {
                    cache.Insert(self_EqualProjectIDList_key, EqualProjectIDList);
                    cache.Insert(self_InProjectIDList_key, InProjectIDList);
                }
                return;
            }
            EqualProjectIDList = cache.Get(self_EqualProjectIDList_key) as List<int>;
            InProjectIDList = cache.Get(self_InProjectIDList_key) as List<int>;
        }
        public static void ClearCache()
        {
            List<string> cacheKeys = new List<string>();
            var cache = HttpRuntime.Cache;
            IDictionaryEnumerator cacheEnum = cache.GetEnumerator();
            while (cacheEnum.MoveNext())
            {
                cacheKeys.Add(cacheEnum.Key.ToString());
            }
            foreach (string cacheKey in cacheKeys)
            {
                cache.Remove(cacheKey);
            }
        }
        public static void RemoveMyViewProjectTree()
        {
            HttpContext context = HttpContext.Current;
            List<string> cacheKeys = new List<string>();
            var cache = HttpRuntime.Cache;
            IDictionaryEnumerator cacheEnum = cache.GetEnumerator();
            while (cacheEnum.MoveNext())
            {
                string key = cacheEnum.Key.ToString();
                if (key.StartsWith(myprojects_key) || key.StartsWith(myxiaoqu_key) || key.StartsWith(projectdetailstree_key) || key.StartsWith(projectlevellist_key))
                {
                    cacheKeys.Add(key);
                }
            }
            foreach (string cacheKey in cacheKeys)
            {
                if (cache.Get(cacheKey) != null)
                    cache.Remove(cacheKey);
            }
        }
    }
}