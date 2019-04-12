<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="PublicProjectEdit.aspx.cs" Inherits="Web.InitialSetup.PublicProjectEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID, ParentID, ParentProjectID;
        $(function () {
            ID = "<%=this.ID%>";
            ParentID = "<%=this.ParentID%>";
            ParentProjectID = "<%=this.ParentProjectID%>";
        })
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var Name = $("#<%=this.tdName.ClientID%>").textbox("getValue");
            var Description = $("#<%=this.tdDescription.ClientID%>").textbox("getValue");
            var options = { visit: 'saveprojectpublic', ID: ID, ParentID: ParentID, ParentProjectID: ParentProjectID, Name: Name, Description: Description };
            MaskUtil.mask('body', '提交中');
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ProjectHandler.ashx',
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
                top.treeType = 7;
                top.openTreeContent();
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
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>上级资源
                    </td>
                    <td colspan="3">
                        <label runat="server" id="tdParentName"></label>
                    </td>
                </tr>
                <tr>
                    <td>资源名称
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdName" runat="server" data-options="required:true" style="width: 70%;" />
                    </td>
                </tr>
                <tr>
                    <td>描述</td>
                    <td colspan="3">
                        <input class="easyui-textbox" id="tdDescription" name="Remark" data-options="multiline:true" runat="server" style="height: 60px; width: 70%;" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
