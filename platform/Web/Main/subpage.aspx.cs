using Foresight.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Main
{
    public partial class subpage : BasePage
    {
        public string iframeUrl = string.Empty;
        public int iframeType = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string pageurl = string.Empty;
            if (Request.QueryString["pageurl"] != null)
            {
                pageurl = Request.QueryString["pageurl"];
            }
            var module = new Foresight.DataAccess.SysMenu();
            if (!string.IsNullOrEmpty(pageurl))
            {
                string title = "";
                if (Request.QueryString["title"] != null)
                {
                    title = Request.QueryString["title"];
                }
                if (Request.QueryString["expired"] != null)
                {
                    string expired = Request.QueryString["expired"];
                    pageurl = pageurl + "?expired=" + expired;
                }
                module.Title = title;
                string urlencode = "0";
                if (Request.QueryString["urlencode"] != null)
                {
                    urlencode = Request.QueryString["urlencode"];
                }
                if (urlencode.Equals("1"))
                {
                    pageurl = System.Web.HttpUtility.UrlDecode(pageurl);
                }
                module.Url = pageurl;
                this.rptsubpage.DataSource = new SysMenu[] { module };
                this.rptsubpage.DataBind();
                iframeUrl = pageurl;
                return;
            }
            int ID = 0;
            if (string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                return;
            }
            int.TryParse(Request.QueryString["ID"], out ID);
            int RoomID = 0;
            if (!string.IsNullOrEmpty(Request.QueryString["roomid"]))
            {
                int.TryParse(Request.QueryString["roomid"], out RoomID);
            }
            List<SysMenu> data_list = new List<SysMenu>();
            module = SysMenu.GetSysMenu(ID);
            if (module == null)
            {
                return;
            }
            if (module.UsingImgURL)
            {
                module.Url = "../SysSeting/ViewStaticPage.aspx?ID=" + module.ID;
                data_list.Add(module);
                this.rptsubpage.DataSource = data_list;
                this.rptsubpage.DataBind();
                iframeUrl = data_list[0].Url;
                return;
            }
            var modules = SysMenu.GetSysMenuForUser(this.CurrentUser.UserID, ID).ToList();
            if (string.IsNullOrEmpty(module.GroupName) || module.GroupName.Equals(Utility.EnumModel.SysMenuGroupNameDefine.wynk.ToString()))
            {
            }
            string[] modulecodes = WebUtil.GetModuleCodes(this.Context);
            modules = modules.Where(p => modulecodes.Contains(p.ModuleCode)).OrderBy(p => p.SortOrder).ToList();

            var modules_1 = modules.Where(p => !p.IsAuthority).ToList();
            data_list.AddRange(modules_1);
            var modules_2 = modules.Where(p => p.IsAuthority && !string.IsNullOrEmpty(p.Url)).ToList();
            if (modules_2.Count > 0 || data_list.Count == 0)
            {
                if (!string.IsNullOrEmpty(module.Url) && RoomID > 0 && module.ID == 11)
                {
                    module.Url = module.Url + "?RoomID=" + RoomID;
                }
                if (string.IsNullOrEmpty(module.Url))
                {
                    module.Url = "../SysSeting/MainSetup.aspx?ParentID=" + module.ID;
                }
                data_list.Add(module);
            }
            foreach (var item in data_list)
            {
                if (string.IsNullOrEmpty(item.Url))
                {
                    item.Url = "../SysSeting/MainSetup.aspx?ParentID=" + item.ID;
                }
            }
            if (data_list.Count > 0)
            {
                this.rptsubpage.DataSource = data_list;
                this.rptsubpage.DataBind();
                iframeUrl = data_list[0].Url;
            }
        }
    }
}