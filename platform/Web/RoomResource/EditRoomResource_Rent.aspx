<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditRoomResource_Rent.aspx.cs" Inherits="Web.RoomResource.EditRoomResource_Rent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var RoomID;
        $(function () {
            RoomID = "<%=Request.QueryString["RoomID"]%>";
        })
    </script>
    <script src="../js/Page/RoomResource/EditRoomResource_Rent.js?v=<%=base.getToken() %>" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post">
        <div class="easyui-layout" fit="true">
            <table id="home_table">
                <thead>
                    <tr>
                        <th data-options="field:'ck',checkbox:true"></th>
                        <th data-options="field:'RelationTypeDesc'" width="100">客户类别</th>
                        <th data-options="field:'RelationName'" width="100">联系人</th>
                        <th data-options="field:'RelatePhoneNumber'" width="100">联系方式</th>
                        <th data-options="field:'IsDefaultDesc'" width="100">默认联系人</th>
                        <th data-options="field:'IsChargeFeeDesc'" width="100">默认缴费人员</th>
                        <th data-options="field:'IsChargeManDesc'" width="100">是否缴费对象</th>
                    </tr>
                </thead>
            </table>
            <div id="home_tb">
                <a href="javascript:void(0)" onclick="addhome()" class="easyui-linkbutton btnlinbar" data-options="plain:true,iconCls:'icon-add'">增加</a>
                <a href="javascript:void(0)" onclick="edithome()" class="easyui-linkbutton btnlinbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                <a href="javascript:void(0)" onclick="deletehome()" class="easyui-linkbutton btnlinbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                <a href="javascript:void(0)" onclick="editapp()" class="easyui-linkbutton btnlinbar" data-options="plain:true,iconCls:'icon-edit'">App帐号</a>
            </div>
        </div>
    </form>
</asp:Content>
