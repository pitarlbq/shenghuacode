<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="AddProjectProperty.aspx.cs" Inherits="Web.InitialSetup.AddProjectProperty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var firsttitle, ProjectID, CompanyID, AddMan, IsParent, CurrentGrade, ParentID, PropertyID, canCloseYT, FullName, PropertyID, canCloseYT, TotalRoomCount;
        $(function () {
            firsttitle = "住宅";
            ProjectID = "<%=this.ProjectID%>";
            PropertyID = "<%=this.PropertyID%>";
            AddMan = "<%=this.AddMan%>";
            IsParent = "<%=this.IsParent%>";
            CurrentGrade = "<%=this.CurrentGrade%>";
            ParentID = "<%=this.ParentID%>";
            canCloseYT = $("#<%=this.hdCloseYT.ClientID%>");
            TotalRoomCount = Number("<%=this.TotalRoomCount%>");
            CompanyID = Number("<%=this.CompanyID%>");
            if (CompanyID <= 0) {
                CompanyID = top.GetSelectCompanyID();
            }
        })
    </script>
    <script src="../js/Page/InitialSetup/AddProjectProperty.js?token=<%=base.getToken() %>"></script>
    <link href="../styles/main.css?v=1.1" rel="stylesheet" />
    <style>
        a.opt_a {
            text-decoration: none;
            margin: 5px;
        }

        .datagrid {
            border-left: 0px;
            border-bottom: 0px;
        }

        .window {
            border-radius: 0;
            border: 0px;
            padding: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server" id="myform">
        <asp:HiddenField runat="server" ID="hdCloseYT" />
        <div class="easyui-panel" style="width: 100%; height: 80%; border: 0;">
            <table id="tt_table">
            </table>
        </div>
        <div class="easyui-panel" style="width: 100%; height: 20%; border: 0; text-align: center;">
            <a href="javascript:void(0)" onclick="viewyt()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-save'">预览保存</a>
            <%if (this.hdCloseYT.Value.Equals("0"))
              {%>
            <a href="javascript:void(0)" onclick="closeyt()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-tingyong'">停用</a>
            <%} %>
        </div>
        <div id="win_property" class="easyui-window" title="" data-options="closed:true,modal:false,closable:true,maximizable: false,minimizable:false,collapsible:false" style="width: 100%; height: 100%; padding: 0px;">
            <div class="easyui-panel" style="width: 100%; height: 80%; border: 0;">
                <table id="tt_2_table">
                </table>
            </div>
            <div class="easyui-panel" style="width: 100%; height: 20%; border: 0; text-align: center;">
                <a href="javascript:void(0)" onclick="newsaveyt()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                <a href="javascript:void(0)" onclick="closewin()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
            </div>
        </div>
    </form>
</asp:Content>
