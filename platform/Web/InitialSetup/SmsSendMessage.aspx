<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="SmsSendMessage.aspx.cs" Inherits="Web.InitialSetup.SmsSendMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            var options = { visit: 'getsmssendmsgparam' };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/SysSettingHandler.ashx',
                data: options,
                success: function (data) {
                    if (data.list) {
                        $('#tdTemplateID').combobox({
                            valueField: 'ID',
                            textField: 'Name',
                            data: data.list,
                            editable: false,
                            onSelect: function (ret) {
                                $('#tdTemplateContent').html(ret.content);
                            }
                        })
                    }
                }
            });
        })
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            top.$.messager.confirm('提示', '确认发送短信?', function (r) {
                if (r) {
                    MaskUtil.mask('body', '提交中');
                    var Keyword = parent.$('#tdKeyword').searchbox("getValue");
                    var SendStatus = parent.$('#tdSendStatus').combobox("getValue");
                    var ProjectName = parent.$('#tdProjectName').combobox("getValue");
                    var StartTime = parent.$('#tdStartTime').datebox("getValue");
                    var EndTime = parent.$('#tdEndTime').datebox("getValue");
                    var TemplateID = $('#tdTemplateID').combobox('getValue');
                    var rows = parent.$('#tt_table').datagrid('getSelections');
                    var allrows = parent.$('#tt_table').datagrid('getRows');
                    var isSelectAll = rows.length == allrows.length;
                    var IDList = [];
                    if (!isSelectAll) {
                        $.each(rows, function () {
                            IDList.push(this.ID);
                        })
                    }
                    var options = { visit: 'sendsmsbytemplate', IDList: JSON.stringify(IDList), StartTime: StartTime, EndTime: EndTime, TemplateID: TemplateID, Keyword: Keyword, SendStatus: SendStatus, ProjectName: ProjectName, IsSelectAll: isSelectAll };
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        url: '../Handler/SysSettingHandler.ashx',
                        data: options,
                        success: function (message) {
                            MaskUtil.unmask();
                            if (message.status) {
                                top.winUpdate = true;
                                show_message('发送成功', 'success', function () {
                                    do_close();
                                });
                            }
                            else if (message.error) {
                                show_message(message.error, 'warning');
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
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">发送</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container" style="padding-top: 50px;">
            <table class="info">
                <tr>
                    <td>ID</td>
                    <td>
                        <input type="text" class="easyui-combobox" id="tdTemplateID" data-options="required:true,label:''" style="width: 200px" />
                    </td>
                </tr>
                <tr>
                    <td>模板内容</td>
                    <td>
                        <label id="tdTemplateContent"></label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
