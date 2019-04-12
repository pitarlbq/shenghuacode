<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="AddRelateResource.aspx.cs" Inherits="Web.RoomResource.AddRelateResource" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var RoomID = "<%=Request.QueryString["RoomID"]%>";
    </script>
    <script src="../js/Page/AddRelateResource.js?token=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div id="layout" class="easyui-layout" fit="true">
        <div data-options="region:'north',split:false,hideCollapsedContent:false," title="" style="height: 50px; padding: 10px;">
            <label>
                关键字:
                <input class="easyui-searchbox" data-options="prompt:'资源编号、资源位置',searcher:SearchTT" id="tdKeywords" />
            </label>
            <label class="searchlabel">
                <a href="#" class="searchbutton" onclick="SearchTT()" data-options="iconCls:'icon-search'"></a>
            </label>
        </div>
        <div data-options="region:'center'" title="">
            <table id="tt_table">
            </table>
            <div id="tb">
                <a href="#" class="addbutton buttonmin" onclick="addsource()" data-options="iconCls:'icon-add',plain:true"></a>
            </div>
        </div>
    </div>
</asp:Content>
