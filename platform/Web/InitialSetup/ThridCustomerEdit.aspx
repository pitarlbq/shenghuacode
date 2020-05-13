<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ThridCustomerEdit.aspx.cs" Inherits="Web.InitialSetup.ThridCustomerEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID, op;
        $(function () {
            ID = "<%=this.ID%>";
            op = "<%=Request.QueryString["op"]%>";
            if (op != 'edit') {
                $('#<%=this.tdProjectName.ClientID%>').textbox({
                    readonly: true
                })
                $('#<%=this.tdRoomName.ClientID%>').textbox({
                    readonly: true
                })
                $('#<%=this.tdCustomerName.ClientID%>').textbox({
                    readonly: true
                })
                $('#<%=this.tdPhoneNumber.ClientID%>').textbox({
                    readonly: true
                })
                $('#<%=this.tdSignDate.ClientID%>').datebox({
                    readonly: true
                })
            }
        })
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var ProjectName = $('#<%=this.tdProjectName.ClientID%>').textbox('getValue')
            var RoomName = $('#<%=this.tdRoomName.ClientID%>').textbox('getValue')
            var CustomerName = $('#<%=this.tdCustomerName.ClientID%>').textbox('getValue')
            var PhoneNumber = $('#<%=this.tdPhoneNumber.ClientID%>').textbox('getValue')
            var SignDate = $('#<%=this.tdSignDate.ClientID%>').datebox('getValue')
            var options = { visit: 'savethirdcustomer', ID: ID, ProjectName: ProjectName, RoomName: RoomName, CustomerName: CustomerName, PhoneNumber: PhoneNumber, SignDate: SignDate };
            MaskUtil.mask('body', '提交中');
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/RoomResourceHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status) {
                        show_message('保存成功', 'success', function () {
                            do_close();
                        });
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$("#tt_table").datagrid("reload");
            }, true);
        }
    </script>
    <style type="text/css">
        .panel-body {
            background: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <div class="operation_box">
            <%if (Request.QueryString["op"] == "edit")
                { %>
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <%} %>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container" style="padding-top: 50px;">
            <table class="info">
                <tr>
                    <td>项目名称
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdProjectName" runat="server" />
                    </td>
                    <td>资源编号
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdRoomName" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>姓名
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdCustomerName" runat="server" />
                    </td>
                    <td>手机号码
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdPhoneNumber" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>签约日期</td>
                    <td colspan="3">
                        <input class="easyui-datebox" id="tdSignDate" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
