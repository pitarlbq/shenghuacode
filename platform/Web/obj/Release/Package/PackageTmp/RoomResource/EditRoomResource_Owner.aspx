<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditRoomResource_Owner.aspx.cs" Inherits="Web.RoomResource.EditRoomResource_Owner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var RoomID;
        $(function () {
            RoomID = "<%=Request.QueryString["RoomID"]%>";
        })
    </script>
    <script src="../js/Page/RoomResource/EditRoomResource_Owner.js?v=<%=base.getToken() %>" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post">
        <div class="easyui-layout" fit="true">
            <table id="home_table">
                <thead>
                    <tr>
                        <th data-options="field:'ck',checkbox:true"></th>
                        <th data-options="field:'RelationPropertyDesc'" width="100">住户类别</th>
                        <th data-options="field:'RelationTypeDesc'" width="100">住户标签</th>
                        <th data-options="field:'CompanyName'" width="100">公司名称</th>
                        <th data-options="field:'RelationName'" width="100">住户姓名</th>
                        <th data-options="field:'RelatePhoneNumber'" width="100">联系方式</th>
                        <th data-options="field:'IsDefaultDesc'" width="100">默认联系人</th>
                        <th data-options="field:'IDCardTypeDesc'" width="100">证件类别</th>
                        <th data-options="field:'RelationIDCard'" width="150">证件号码</th>
                    </tr>
                </thead>
            </table>
            <div id="home_tb">
                <a href="javascript:void(0)" onclick="addhome()" class="easyui-linkbutton btnlinbar" data-options="plain:true,iconCls:'icon-add'">增加</a>
                <a href="javascript:void(0)" onclick="edithome()" class="easyui-linkbutton btnlinbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                <a href="javascript:void(0)" onclick="deletehome()" class="easyui-linkbutton btnlinbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
            </div>
        </div>
    </form>
</asp:Content>
