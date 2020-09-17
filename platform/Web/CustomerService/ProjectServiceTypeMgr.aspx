<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ProjectServiceTypeMgr.aspx.cs" Inherits="Web.CustomerService.ProjectServiceTypeMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/CustomerService/ProjectServiceTypeMgr.js?t=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div id="main_form_layout" class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 5px;">
            <label>
                关键字
                <input class="easyui-searchbox" id="tdKeyword" type="text" data-options="prompt:'项目名称',searcher:SearchTT" />
            </label>
            <label class="searchlabel">
                <a href="#" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
            </label>
        </div>
        <div data-options="region:'center',border:false">
            <table id="tt_table">
            </table>
        </div>
    </div>
</asp:Content>
