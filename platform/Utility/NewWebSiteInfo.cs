using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility
{
    public class NewWebSiteInfo
    {
        private string hostIP;   // 主机IP
        private string portNum;   // 网站端口号
        private string descOfWebSite; // 网站表示。一般为网站的网站名。例如"www.dns.com.cn"
        private string commentOfWebSite;// 网站注释。一般也为网站的网站名。
        private string webPath;   // 网站的主目录。例如"e:\ mp"
        public NewWebSiteInfo(string hostIP, string portNum, string descOfWebSite, string commentOfWebSite, string webPath)
        {
            this.hostIP = hostIP;
            this.portNum = portNum;
            this.descOfWebSite = descOfWebSite;
            this.commentOfWebSite = commentOfWebSite;
            this.webPath = webPath;
        }
        public string BindString
        {
            get
            {
                return String.Format("{0}:{1}:{2}", hostIP, portNum, descOfWebSite); //网站标识（IP,端口，主机头值）
            }
        }
        public string PortNum
        {
            get
            {
                return portNum;
            }
        }
        public string CommentOfWebSite
        {
            get
            {
                return commentOfWebSite;
            }
        }
        public string WebPath
        {
            get
            {
                return webPath;
            }
        }
    }
}
