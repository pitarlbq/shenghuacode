<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditDepartment.aspx.cs" Inherits="Web.CangKu.EditDepartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID = 0, ParentID = 0, CompanyID = 0;
        $(function () {
            ID = "<%=this.ID%>";
            ParentID = "<%=this.ParentID%>";
            CompanyID = "<%=this.CompanyID%>";
        })
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/CKHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'saveckdepartment';
                    param.ID = ID;
                    param.ParentID = ParentID;
                    param.CompanyID = CompanyID;
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        show_message('保存成功', 'success', function () {
                            do_close();
                        });
                        return;
                    }
                    if (dataObj.error) {
                        show_message(dataObj.error, 'warning');
                        return;
                    }
                    show_message("内部异常", "error");
                }
            });
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$("#tt_table").treegrid("reload");
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
            <div class="tableContent">
                <div class="tableItem">
                    <label class="title">部门名称</label>
                    <input type="text" class="easyui-textbox" id="tdDepartmentName" runat="server" data-options="required:true" />
                </div>
                <div class="tableItem">
                    <label class="title">描述</label>
                    <input class="easyui-textbox" id="tdDescription" name="Description" data-options="multiline:true" runat="server" style="height: 60px;" />
                </div>
                <div class="tableItem">
                    <label class="title">排序序号</label>
                    <input type="text" class="easyui-textbox" id="tdSortOrder" runat="server" data-options="required:true" />
                </div>
                <div class="tableItem">
                    <label class="title">所属上级</label>
                    <label runat="server" id="tdParentName"></label>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
