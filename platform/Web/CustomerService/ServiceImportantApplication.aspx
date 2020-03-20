<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ServiceImportantApplication.aspx.cs" Inherits="Web.CustomerService.ServiceImportantApplication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var IsSuggestion = 0;
        $(function () {
            IsSuggestion = "<%=this.IsSuggestion%>";
            if (IsSuggestion == 1) {
                $('.cssimport').hide();
            } else {
                $('.cssimport').show();
            }
            $('#tdApplicationType').combobox({
                onChange: function () {
                    changeStatus();
                }
            })
            changeStatus();
        })
        function changeStatus() {
            var applicationType = $('#tdApplicationType').combobox('getValue');
            if (applicationType == 4) {
                $('.type4').show();
            } else {
                $('.type4').hide();
            }
        }
        function do_save() {
            var ID = "<%=this.ServiceID%>";
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var rows = parent.$("#tt_table").datagrid("getSelections");
            var IDList = [];
            $.each(rows, function (index, row) {
                if (IDList.indexOf(ID) > -1) {
                    return true;
                }
                IDList.push(row.ID);
            })
            var approveMsg = '确认执行重大报修投诉申请？';
            if (IDList.length > 1) {
                approveMsg = '您正在同时申请多个工单，继续操作请点击确认';
            }
            $.messager.confirm('提示', approveMsg, function (r) {
                if (r) {
                    MaskUtil.mask('body', '提交中');
                    $('#ff').form('submit', {
                        url: '../Handler/ServiceHandler.ashx',
                        onSubmit: function (param) {
                            param.visit = 'serviceimportapplication';
                            param.IDList = JSON.stringify(IDList);
                            param.Remark = $('#tdRemark').textbox('getValue');
                            param.ApplicationType = $('#tdApplicationType').combobox('getValue');
                            param.ReturnHomeDate = $('#tdReturnHomeDate').combobox('getValue');
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
            })
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
            <div class="tableItem cssimport" style="width: 100%;">
                <label class="title">申请类型</label>
                <select class="easyui-combobox" id="tdApplicationType" data-options="editable:false" style="width: 60%; height: 28px;">
                    <option value="1">启用第三方</option>
                    <option value="2">第三方二次维修</option>
                    <option value="3">维修转赔偿意见未达成一致</option>
                    <option value="4">业主不在家</option>
                </select>
            </div>
            <div class="tableItem cssimport type4" style="width: 100%;">
                <label class="title">业主在家时间</label>
                <input class="easyui-datebox" id="tdReturnHomeDate" style="height: 28px;" />
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
