using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace Utility
{
    public class IISManager
    {
        public IISManager()
        {
        }

        public static string VirDirSchemaName = "IIsWebVirtualDir";
        private string _serverName;

        public string ServerName
        {
            get
            {
                return _serverName;
            }
            set
            {
                _serverName = value;
            }
        }


        /// <summary>      
        /// 创建网站或虚拟目录 
        /// </summary>     
        /// <param name="WebSite">服务器站点名称(localhost)</param>     
        /// <param name="VDirName">虚拟目录名称</param>     
        /// <param name="Path">实际路径</param>      
        /// <param name="RootDir">true=网站;false=虚拟目錄</param>    
        /// <param name="iAuth">设置目录的安全性，0不允许匿名访问，1为允许,2基本身份验证，3允许匿名+基本身份验证，4整合Windows驗證,5允许匿名+整合Windows验证...更多请查阅MSDN</param>       
        /// <param name="webSiteNum">1</param>      
        /// <param name="serverName">一般為localhost</param> 
        /// <returns></returns> 
        public static bool CreateWebSite(string WebSite, string VDirName, string Path, bool RootDir, int iAuth, int webSiteNum, string serverName, string Sub_VDirName = "")
        {
            VDirName = string.IsNullOrEmpty(VDirName) ? "saas" : VDirName;
            System.DirectoryServices.DirectoryEntry IISSchema;
            System.DirectoryServices.DirectoryEntry IISAdmin;
            System.DirectoryServices.DirectoryEntry VDir;
            try
            {
                bool IISUnderNT;
                //    
                // 确定IIS版本 
                //           
                IISSchema = new System.DirectoryServices.DirectoryEntry("IIS://" + serverName + "/Schema/AppIsolated");
                if (IISSchema.Properties["Syntax"].Value.ToString().ToUpper() == "BOOLEAN")
                    IISUnderNT = true;
                else
                    IISUnderNT = false;
                IISSchema.Dispose();

                //         
                // Get the admin object          
                // 获得管理权限        
                //            
                IISAdmin = new System.DirectoryServices.DirectoryEntry("IIS://" + serverName + "/W3SVC/" + webSiteNum + "/Root");

                //           
                // If we're not creating a root directory         
                // 如果我们不能创建一个根目录           
                //               
                if (!RootDir)
                {
                    //               
                    // If the virtual directory already exists then delete it             
                    // 如果虚拟目录已经存在则删除     
                    //

                    foreach (System.DirectoryServices.DirectoryEntry v in IISAdmin.Children)
                    {
                        if (v.Name == VDirName)
                        {
                            if (!string.IsNullOrEmpty(Sub_VDirName))
                            {
                                foreach (System.DirectoryServices.DirectoryEntry sub_v in v.Children)
                                {
                                    if (sub_v.Name == Sub_VDirName)
                                    {
                                        return false;
                                    }
                                }
                                VDir = v.Children.Add(Sub_VDirName, "IIsWebVirtualDir");
                                CreateVDir(VDir, Sub_VDirName, IISUnderNT, Path, iAuth);
                                return true;
                            }
                            return false;
                            // Delete the specified virtual directory if it already exists 
                            //try
                            //{
                            //    IISAdmin.Invoke("Delete", new string[] { v.SchemaClassName, VDirName });
                            //    IISAdmin.CommitChanges();
                            //}
                            //catch (Exception)
                            //{

                            //}
                        }
                    }
                }
                if (!RootDir)
                {
                    VDir = IISAdmin.Children.Add(VDirName, "IIsWebVirtualDir");
                }
                else
                {
                    VDir = IISAdmin;
                }
                CreateVDir(VDir, VDirName, IISUnderNT, Path, iAuth);
                return true;
                //           
                // Create the virtual directory        
                // 创建一个虚拟目录     

                //          

                //          
                // Make it a web application       
                // 创建一个web应用         
                //

                if (IISUnderNT)
                {
                    VDir.Invoke("AppCreate", false);
                }
                else
                {
                    VDir.Invoke("AppCreate", true);
                }

                //           
                // Setup the VDir       
                // 安装虚拟目录       
                //AppFriendlyName,propertyName,, bool chkRead,bool chkWrite, bool chkExecute, bool chkScript,, true, false, false, true 
                VDir.Properties["AppFriendlyName"][0] = VDirName;    //应用程序名称 
                VDir.Properties["AccessRead"][0] = true; //设置读取权限 
                VDir.Properties["AccessExecute"][0] = false;
                VDir.Properties["AccessWrite"][0] = false;
                VDir.Properties["AccessScript"][0] = true; //执行权限[纯脚本] 
                //VDir.Properties["AuthNTLM"][0] = chkAuth; 
                VDir.Properties["EnableDefaultDoc"][0] = true;
                VDir.Properties["EnableDirBrowsing"][0] = false;
                VDir.Properties["DefaultDoc"][0] = "Default.aspx,Index.aspx,Index.asp"; //设置默认文档,多值情况下中间用逗号分割 
                VDir.Properties["Path"][0] = Path;
                VDir.Properties["AuthFlags"][0] = iAuth;

                //        
                // NT doesn't support this property      
                // NT格式不支持这特性       
                //          
                if (!IISUnderNT)
                {
                    VDir.Properties["AspEnableParentPaths"][0] = true;
                }
                VDir.CommitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static void CreateVDir(DirectoryEntry VDir, string VDirName, bool IISUnderNT, string Path, int iAuth)
        {
            //          
            // Make it a web application       
            // 创建一个web应用         
            //
            if (IISUnderNT)
            {
                VDir.Invoke("AppCreate", false);
            }
            else
            {
                VDir.Invoke("AppCreate", true);
            }
            //           
            // Setup the VDir       
            // 安装虚拟目录       
            //AppFriendlyName,propertyName,, bool chkRead,bool chkWrite, bool chkExecute, bool chkScript,, true, false, false, true 
            VDir.Properties["AppFriendlyName"][0] = VDirName;    //应用程序名称 
            VDir.Properties["AccessRead"][0] = true; //设置读取权限 
            VDir.Properties["AccessExecute"][0] = false;
            VDir.Properties["AccessWrite"][0] = false;
            VDir.Properties["AccessScript"][0] = true; //执行权限[纯脚本] 
            //VDir.Properties["AuthNTLM"][0] = chkAuth; 
            VDir.Properties["EnableDefaultDoc"][0] = true;
            VDir.Properties["EnableDirBrowsing"][0] = false;
            VDir.Properties["DefaultDoc"][0] = "Default.aspx,Index.aspx,Index.asp"; //设置默认文档,多值情况下中间用逗号分割 
            VDir.Properties["Path"][0] = Path;
            VDir.Properties["AuthFlags"][0] = iAuth;
            //        
            // NT doesn't support this property      
            // NT格式不支持这特性       
            //          
            if (!IISUnderNT)
            {
                VDir.Properties["AspEnableParentPaths"][0] = true;
            }
            VDir.CommitChanges();
        }

        /// <summary> 
        /// 获取VDir支持的所有屬性 
        /// </summary> 
        /// <returns></returns> 
        public string GetVDirPropertyName()
        {
            //System.DirectoryServices.DirectoryEntry VDir; 
            const String constIISWebSiteRoot = "IIS://localhost/W3SVC/1/ROOT/iKaoo";
            DirectoryEntry root = new DirectoryEntry(constIISWebSiteRoot);

            string sOut = "";
            //下面的方法是得到所有属性名称的方法： 
            foreach (PropertyValueCollection pvc in root.Properties)
            {
                //Console.WriteLine(pvc.PropertyName); 
                sOut += pvc.PropertyName + ":" + pvc.Value.ToString() + "-----------";
            }
            return sOut;
        }

        /// <summary> 
        /// 创建虚拟目录 
        /// </summary> 
        /// <param name="sDirName">虚拟目录程序名称</param> 
        /// <param name="sPath">实际路径</param> 
        /// <param name="sDefaultDoc">默认首页，多个首页用逗号分隔</param> 
        /// <param name="iAuthFlags">设置目录的安全性，0不允许匿名访问，1为允许,2基本身份验证，3允许匿名+基本身份验证，4整合Windows验证,5允许匿名+整合Windows验证...更多请查阅MSDN</param> 
        /// <param name="sWebSiteNumber">Win2K,2K3支持多个网站,本次操作哪個网站,默认网站为1</param> 
        /// <returns></returns> 
        public bool CreateVDir(string sDirName, string sPath, string sDefaultDoc, int iAuthFlags, string sWebSiteNumber)
        {
            try
            {
                String sIISWebSiteRoot = "IIS://localhost/W3SVC/" + sWebSiteNumber + "/ROOT";
                DirectoryEntry root = new DirectoryEntry(sIISWebSiteRoot);

                foreach (System.DirectoryServices.DirectoryEntry v in root.Children)
                {
                    if (v.Name == sDirName)
                    {
                        // Delete the specified virtual directory if it already exists   
                        root.Invoke("Delete", new string[] { v.SchemaClassName, sDirName });
                        root.CommitChanges();
                    }
                }

                DirectoryEntry tbEntry = root.Children.Add(sDirName, root.SchemaClassName);


                tbEntry.Properties["Path"][0] = sPath;
                tbEntry.Invoke("AppCreate", true);

                //tbEntry.Properties["AccessRead"][0] = true; 
                //tbEntry.Properties["ContentIndexed"][0] = true; 
                tbEntry.Properties["DefaultDoc"][0] = sDefaultDoc;
                tbEntry.Properties["AppFriendlyName"][0] = sDirName;
                //tbEntry.Properties["AccessScript"][0] = true; 
                //tbEntry.Properties["DontLog"][0] = true; 
                //tbEntry.Properties["AuthFlags"][0] = 0; 
                tbEntry.Properties["AuthFlags"][0] = iAuthFlags;
                tbEntry.CommitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool UpdateConfigValue(string strFileName, Dictionary<string, object> dic)
        {
            bool isSucceed = false;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(strFileName);
                foreach (string key in dic.Keys)
                {
                    XmlNode node = null;
                    XmlElement ele = null;
                    if (key.Equals("ConnString"))
                    {
                        node = xmlDoc.SelectSingleNode(@"//add[@name='" + key + "']");
                        ele = (XmlElement)node;
                        ele.SetAttribute("connectionString", dic[key].ToString());
                    }
                    else if (key.Equals("ErrorMode"))
                    {
                        node = xmlDoc.SelectSingleNode(@"//customErrors");
                        ele = (XmlElement)node;
                        ele.SetAttribute("mode", dic[key].ToString());
                        ele.SetAttribute("defaultRedirect", "ErrorPage.html");
                    }
                    else
                    {
                        XmlNode xNode = xmlDoc.SelectSingleNode("//appSettings");
                        node = xNode.SelectSingleNode(@"//add[@key='" + key + "']");
                        if (node == null)
                        {
                            xmlDoc.CreateElement("add");
                            ele = xmlDoc.CreateElement("add");
                            ele.SetAttribute("key", key);
                            ele.SetAttribute("value", dic[key].ToString());
                            xNode.AppendChild(ele);
                        }
                        else
                        {
                            ele = (XmlElement)node;
                            ele.SetAttribute("value", dic[key].ToString());
                        }
                    }
                }
                xmlDoc.Save(strFileName);
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return isSucceed;
        }
    }

}
