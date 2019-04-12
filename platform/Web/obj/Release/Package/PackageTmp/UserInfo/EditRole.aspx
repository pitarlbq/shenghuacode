<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditRole.aspx.cs" Inherits="Web.UserInfo.EditRole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var RoleID = "<%=Request.QueryString["RoleID"]%>";
            var RoleName = $("#<%=this.tdRoleName.ClientID%>").textbox("getValue");
            var RoleDesc = $("#<%=this.tdRoleDesc.ClientID%>").textbox("getValue");
            var options = { visit: 'saveroleinfo', RoleID: RoleID, RoleName: RoleName, RoleDes: RoleDesc };
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
                            do_close;
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
                    <td>角色名称
                    </td>
                    <td colspan="3">
                        <input class="easyui-textbox" id="tdRoleName" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>描述
                    </td>
                    <td colspan="3">
                        <input class="easyui-textbox" id="tdRoleDesc" data-options="multiline:true" runat="server" style="height: 60px;" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
