<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent.Master" AutoEventWireup="true" CodeBehind="Setup.aspx.cs" Inherits="Web.RoomResource.Setup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var CompanyID
        $(function () {
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
        })
    </script>
    <script src="../js/Page/RoomResource/RoomResourceSetup.js?token=<%=base.getToken() %>"></script>
    <style type="text/css">
        .radioBtn {
            height: 16px;
            vertical-align: middle;
        }

        .checkboxBtn {
            vertical-align: middle;
            margin-right: 2px;
        }

        .op a {
            margin: 0 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server" id="form1">
        <div class="easyui-layout" fit="true">
            <div data-options="region:'center'" title="">
                <table id="tt_table">
                </table>
            </div>
            <div id="tb">
                <a href="#" class="viewbutton buttonmin" onclick="viewRoom()" data-options="iconCls:'icon-search',plain:true"></a>
                <a href="#" class="importbutton buttonmin" onclick="openImport()" data-options="iconCls:'icon-excel',plain:true"></a>
            </div>
        </div>
    </form>
</asp:Content>
