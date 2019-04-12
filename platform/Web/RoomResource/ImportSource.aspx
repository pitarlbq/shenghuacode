<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ImportSource.aspx.cs" Inherits="Web.RoomResource.ImportSource" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function downloadTempate() {
            window.location.href = "../upload/roomresourcetemplte.xls";
        }
        function do_save() {
            var filebox = $("#attached").filebox("getValue");
            if (filebox == "") {
                $("#<%=this.errMsg.ClientID%>").html("请选择文件");
                return;
            }
            top.$.messager.confirm("提示", "覆盖已有房源信息", function (r) {
                var isconver = 0;
                if (r) {
                    isconver = 1;
                }
                MaskUtil.mask('body', '导入中');
                $('#ff').form('submit', {
                    url: "../Handler/ImportSourceHandler.ashx?visit=importroomsource",
                    onSubmit: function (param) {
                        param.CreatorID = "<%= Web.WebUtil.GetUser(this.Context).UserID %>",
                        param.CompanyID = "<%= Web.WebUtil.GetCompanyID(this.Context) %>",
                        param.isconver = isconver
                    },
                    dataType: "html",
                    success: function (data) {
                        MaskUtil.unmask();
                        data = data.replace(/&lt;/g, "<");
                        data = data.replace(/&gt;/g, ">");
                        $("#<%=this.errMsg.ClientID%>").html(data);
                    }
                });
            })
        }
        function do_export() {
            parent.do_export();
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$("#tt_table").datagrid("reload");
            });
        }
    </script>
    <style type="text/css">
        .panel-body {
            background: #f0f0f0;
        }

        .notifyMsg {
            text-align: center;
            color: #ff0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" method="post" runat="server" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>模板</td>
                    <td>
                        <a href="javascript:void(0)" onclick="do_export()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-export'">下载</a>
                        <asp:HiddenField runat="server" ID="hdRoomID" />
                        <asp:HiddenField runat="server" ID="hdProjectID" />
                    </td>
                </tr>
                <tr>
                    <td>文件</td>
                    <td>
                        <input class="easyui-filebox" name="attachfile" id="attached" data-options="prompt:'请选择文件',buttonText: '选择文件'" style="width: 60%" />
                    </td>
                </tr>
            </table>
            <div class="notifyMsg">
                <label runat="server" id="errMsg"></label>
            </div>
        </div>
    </form>
</asp:Content>
