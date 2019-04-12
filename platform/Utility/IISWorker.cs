using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;

namespace Utility
{
    public class IISWorker
    {
        private static string HostName = "localhost";
        /// <summary>
        /// 判断程序池是否存在
        /// </summary>
        /// <param name="AppPoolName">程序池名称</param>
        /// <returns>true存在 false不存在</returns>
        private bool IsAppPoolName(string AppPoolName)
        {
            bool result = false;
            DirectoryEntry appPools = new DirectoryEntry("IIS://localhost/W3SVC/AppPools");
            foreach (DirectoryEntry getdir in appPools.Children)
            {
                if (getdir.Name.Equals(AppPoolName))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        /// <summary>
        /// 创建虚拟目录网站
        /// </summary>
        /// <param name="webSiteName">网站名称</param>
        /// <param name="physicalPath">物理路径</param>
        /// <param name="domainPort">站点+端口，如192.168.1.23:90</param>
        /// <param name="isCreateAppPool">是否创建新的应用程序池</param>
        /// <returns></returns>
        public static int CreateWebSite(string webSiteName, string physicalPath, string domainServer,string port, bool isCreateAppPool)
        {

            DirectoryEntry root = new DirectoryEntry("IIS://" + HostName + "/W3SVC");
            // 为新WEB站点查找一个未使用的ID
            int siteID = 1;
            foreach (DirectoryEntry e in root.Children)
            {
                if (e.SchemaClassName == "IIsWebServer")
                {
                    int ID = Convert.ToInt32(e.Name);
                    if (ID >= siteID) { siteID = ID + 1; }
                }
            }
            // 创建WEB站点
            DirectoryEntry site = (DirectoryEntry)root.Invoke("Create", "IIsWebServer", siteID);
            site.Invoke("Put", "ServerComment", webSiteName);
            site.Invoke("Put", "KeyType", "IIsWebServer");
            site.Invoke("Put", "ServerBindings", port + ":");
            site.Invoke("Put", "ServerState", 2);
            site.Invoke("Put", "FrontPageWeb", 1);
            site.Invoke("Put", "DefaultDoc", "default.aspx");
            // site.Invoke("Put", "SecureBindings", ":443:");
            site.Invoke("Put", "ServerAutoStart", 1);
            site.Invoke("Put", "ServerSize", 1);
            site.Invoke("SetInfo");
            // 创建应用程序虚拟目录

            DirectoryEntry siteVDir = site.Children.Add("Root", "IISWebVirtualDir");
            siteVDir.Properties["AppIsolated"][0] = 2;
            siteVDir.Properties["Path"][0] = physicalPath;
            siteVDir.Properties["AccessFlags"][0] = 513;
            siteVDir.Properties["FrontPageWeb"][0] = 1;
            siteVDir.Properties["AppRoot"][0] = "LM/W3SVC/" + siteID + "/Root";
            siteVDir.Properties["AppFriendlyName"][0] = "Root";

            if (isCreateAppPool)
            {
                DirectoryEntry apppools = new DirectoryEntry("IIS://" + HostName + "/W3SVC/AppPools");

                DirectoryEntry newpool = apppools.Children.Add(webSiteName, "IIsApplicationPool");
                newpool.Properties["AppPoolIdentityType"][0] = "4"; //4
                newpool.Properties["ManagedPipelineMode"][0] = "0"; //0:集成模式 1:经典模式
                newpool.Properties["ManagedRuntimeVersion"][0] = "v4.0";
                newpool.CommitChanges();
                siteVDir.Properties["AppPoolId"][0] = webSiteName;
            }

            siteVDir.CommitChanges();
            site.CommitChanges();
            return siteID;
        }

    }
}
