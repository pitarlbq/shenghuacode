<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ServiceImportantApplication.aspx.cs" Inherits="Web.CustomerService.ServiceImportantApplication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }

            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/ServiceHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'serviceimportapplication';
                    param.ID = "<%=this.ServiceID%>";
                    param.Remark = $('#tdRemark').textbox('getValue');
                    param.ApplicationType = $('#tdApplicationType').combobox('getValue');
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        window.update = true;
                        show_message('申请成功', 'success', function () {
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
                if (window.update) {
                    parent.$("#tt_table").datagrid("reload");
                }
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
            <div class="tableItem" style="width: 100%;">
                <label class="title">申请类型</label>
                <select class="easyui-combobox" id="tdApplicationType" data-options="editable:false" style="width: 60%; height: 28px;">
                    <option value="1">启用第三方</option>
                    <option value="2">第三方二次维修</option>
                    <option value="3">维修转赔偿意见未达成一致</option>
                    <option value="4">业主不在家</option>
                </select>
            </div>
            <div class="tableItem" style="width: 100%;">
                <label class="title">附件上传</label>
                <input class="easyui-filebox" name="attachfile" data-options="prompt:'请选择文件',buttonText: '选择文件',required:true" style="width: 60%; height: 28px;" />
            </div>
            <div class="tableItem" style="width: 100%;">
                <label class="title">申请说明</label>
                <input class="easyui-textbox" id="tdRemark" data-options="multiline:true" style="width: 60%; height: 50px;" />
            </div>
        </div>
    </form>
</asp:Content>
