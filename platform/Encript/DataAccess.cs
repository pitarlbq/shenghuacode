using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Encript
{
    public class DataAccess
    {
    }
    public class CompanyModel
    {
        public int ID { get; set; }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public bool IsActive { get; set; }
        public string BaseURL { get; set; }
        public int UserCount { get; set; }
        public DateTime ServerStartTime { get; set; }
        public DateTime ServerEndTime { get; set; }
        public bool IsPay { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsCustomer { get; set; }
        public string Login_LogImg { get; set; }
        public string Login_BodyImg { get; set; }
        public string Home_LogoImg { get; set; }
        public int VersionCode { get; set; }
    }
    public class CompanyModuleModel
    {
        public int ID { get; set; }
        public int CompanyID { get; set; }
        public int ModuleID { get; set; }
    }
}
