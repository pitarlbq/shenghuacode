<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditRoomName.aspx.cs" Inherits="Web.RoomResource.EditRoomName" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ProjectID, tdAddressProvice, tdAddressCity, tdAddressDistrict, show_address;
        $(function () {
            ProjectID = "<%=Request.QueryString["ID"]%>";
        })
        function do_save() {
            var ProjectName = $("#<%=this.tdProjectName.ClientID%>").textbox("getValue");
            if (ProjectName == "") {
                show_message("资源名称不能为空");
                return;
            }
            var OrderBy = $("#<%=this.tdOrderBy.ClientID%>").textbox("getValue");
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/ProjectHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'saveprojectname';
                    param.ProjectID = ProjectID;
                    param.ProjectName = ProjectName;
                    param.OrderBy = OrderBy;
                },
                success: function (message) {
                    MaskUtil.unmask();
                    var data = eval('(' + message + ')');
                    if (data.status) {
                        show_message("保存成功", "success", function () {
                            parent.isUpdate = true;
                            do_close();
                        });
                        return;
                    }
                    if (data.error) {
                        show_message(data.error, 'warning');
                        return;
                    }
                    show_message("保存失败", "error");
                }
            });
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$("#tt_table").datagrid("reload");
                parent.doSearch();
            });
        }
        function doNewSort() {
            var SortOrder = $("#<%=this.tdOrderBy.ClientID%>").textbox("getValue");
            if (SortOrder == "") {
                return;
            }
            MaskUtil.mask('body', '提交中...<br/>时间可能会比较长,请耐心等待');
            $('.datagrid-mask-msg').css('height', '70px');
            $('#ff').form('submit', {
                url: '../Handler/ProjectHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'saveprojectneworder';
                    param.ProjectID = ProjectID;
                    param.SortOrder = SortOrder;
                },
                success: function (message) {
                    MaskUtil.unmask();
                    var data = eval("(" + message + ")");
                    if (data.status) {
                        show_message("保存成功", "success");
                        return;
                    }
                    if (data.error) {
                        show_message(data.error, "warning");
                        return;
                    }
                    show_message("保存失败", "error");
                }
            });
        }
    </script>
    <style>
        .panel-body {
            background: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server" id="ff" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td class="first">资源名称</td>
                    <td class="second">
                        <input id="tdProjectName" runat="server" class="easyui-textbox" type="text" name="ProjectName" />
                    </td>
                    <td class="first">排序序号</td>
                    <td class="second">
                        <input id="tdOrderBy" runat="server" class="easyui-textbox" type="text" name="OrderBy" style="width: 50%;" />
                        <a href="javascript:void(0)" onclick="doNewSort()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-paixu'">重新排序</a>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
