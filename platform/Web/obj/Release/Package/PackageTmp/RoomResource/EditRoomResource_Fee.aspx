<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditRoomResource_Fee.aspx.cs" Inherits="Web.RoomResource.EditRoomResource_Fee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var RoomID;
        $(function () {
            RoomID = "<%=Request.QueryString["RoomID"]%>";
        })
    </script>
    <script src="../js/Page/RoomResource/EditRoomResource_Fee.js?v=<%=base.getToken() %>" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post">
        <div class="easyui-layout" fit="true">
            <table id="fee_table">
                <thead>
                    <tr>
                        <th data-options="field:'ChargeName'" width="80">收费项目</th>
                        <th data-options="field:'UnitPrice',formatter: formatUnitPrice" width="100">单价</th>
                        <th data-options="field:'StartTime',formatter: formatTime" width="100">开始日期</th>
                        <th data-options="field:'EndTime',formatter: formatTime" width="100">结束日期</th>
                        <th data-options="field:'ChargeTypeDesc'" width="80">计费方式</th>
                        <th data-options="field:'Remark'" width="100">备注</th>
                    </tr>
                </thead>
            </table>
        </div>
    </form>
</asp:Content>
