<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditUserPwd.aspx.cs" Inherits="Web.UserInfo.EditUserPwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            $.extend($.fn.validatebox.defaults.rules, {
                equals: {
                    validator: function (value, param) {
                        return value == $(param[0]).val();
                    },
                    message: '两次密码不一致'
                }
            });
        })
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var UserID = "<%=Request.QueryString["UserID"]%>";
            var LoginName = $("#<%=this.tdLoginName.ClientID%>").textbox("getValue");
            var Password = $("#tdPassword").val();
            var options = { visit: 'saveuserpwd', UserID: UserID, LoginName: LoginName, Password: Password };
            MaskUtil.mask('body', '提交中');
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/UserHandler.ashx',
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
                parent.$('#tt_table').datagrid('reload');
            });
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
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>登录名
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdLoginName" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>密码
                    </td>
                    <td colspan="3">
                        <input id="tdPassword" name="pwd" type="password" class="easyui-textbox" data-options="required:true" />
                        <asp:HiddenField ID="hdPwd" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>确认密码
                    </td>
                    <td colspan="3">
                        <input id="tdRePassword" name="rpwd" type="password" class="easyui-textbox"
                            required="required" validtype="equals['#tdPassword']" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
