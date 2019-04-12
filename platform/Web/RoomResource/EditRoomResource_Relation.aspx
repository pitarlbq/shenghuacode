<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditRoomResource_Relation.aspx.cs" Inherits="Web.RoomResource.EditRoomResource_Relation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var RoomID;
        $(function () {
            RoomID = "<%=Request.QueryString["RoomID"]%>";
        })
    </script>
    <script src="../js/Page/RoomResource/EditRoomResource_Relation.js?v=<%=base.getToken() %>" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post">
        <div class="easyui-layout" fit="true">
            <table id="tt_table">
                <thead>
                    <tr>
                        <th data-options="field:'ck',checkbox:true"></th>
                        <th data-options="field:'FullName'" width="100">资源位置</th>
                        <th data-options="field:'PName'" width="100">资源属性</th>
                        <th data-options="field:'Name'" width="100">资源编号</th>
                        <th data-options="field:'BuildingArea',formatter: formatArea" width="100">计费面积</th>
                        <th data-options="field:'CustomOne'" width="100">自定义一</th>
                        <th data-options="field:'CustomTwo'" width="100">自定义二</th>
                        <th data-options="field:'CustomThree'" width="100">自定义三</th>
                        <th data-options="field:'CustomFour'" width="100">自定义四</th>
                        <th data-options="field:'Remark'" width="100">备注</th>
                    </tr>
                </thead>
            </table>
            <div id="tt_tb">
                <a href="javascript:void(0)" onclick="addresource()" class="easyui-linkbutton btnlinbar" data-options="plain:true,iconCls:'icon-guanlian'">关联</a>
                <a href="javascript:void(0)" onclick="deleteresource()" class="easyui-linkbutton btnlinbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
            </div>
        </div>
    </form>
</asp:Content>
