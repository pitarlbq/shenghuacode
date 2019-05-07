<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ServiceClose.aspx.cs" Inherits="Web.CustomerService.ServiceClose" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID, tdHuiFangTime, CanManualyAddPhoneState = 0;
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var rows = parent.$("#tt_table").datagrid("getSelections");
            if (rows.length == 0) {
                show_message("请先选择一个任务", "info");
                return;
            }
            var IDList = [];
            $.each(rows, function (index, row) {
                IDList.push(row.ID);
            })
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/ServiceHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'closecustomerservice';
                    param.IDList = JSON.stringify(IDList);
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
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
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

        .callCss {
            border: solid 1px #ddd;
            border-radius: 5px;
            padding: 2px 10px;
            display: inline-block;
            cursor: pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <a id="btnSave" href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <div class="tableItem">
                <label class="title">附件上传</label>
                <input class="easyui-filebox" name="attachfile" data-options="prompt:'请选择文件',buttonText: '选择文件',required:true" style="width: 60%; height: 28px;" />
            </div>
        </div>
    </form>
</asp:Content>
