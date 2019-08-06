<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ServiceSuggestionEdit.aspx.cs" Inherits="Web.CustomerService.ServiceSuggestionEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>任务登记</title>
    <script>
        function do_close() {
            parent.do_close_dialog();
        }
    </script>
    <style>
        .panel-body {
            background: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td colspan="4" style="text-align: center; font-size: 15px; padding: 5px;">投诉建议</td>
                </tr>
                <tr>
                    <td>资源位置</td>
                    <td colspan="3">
                        <label runat="server" id="tdServiceFullName"></label>
                    </td>
                </tr>
                <tr>
                    <td>反映人</td>
                    <td>
                        <label runat="server" id="tdAddCustomerName"></label>
                    </td>
                    <td>反应时间</td>
                    <td>
                        <label runat="server" id="tdAddTime"></label>
                    </td>

                </tr>
                <tr>
                    <td>反应内容</td>
                    <td colspan="3">
                        <label runat="server" id="tdServiceContent"></label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
