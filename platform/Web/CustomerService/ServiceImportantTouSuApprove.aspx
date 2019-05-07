<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ServiceImportantTouSuApprove.aspx.cs" Inherits="Web.CustomerService.ServiceImportantTouSuApprove" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {

        })
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
                    param.visit = 'domarkimportant';
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
                    <label class="title">派单时效</label>
                    <input type="text" class="easyui-textbox" runat="server" id="tdPaiDanTime" />（小时）
                </div>
                <div class="tableItem">
                    <label class="title">回复时效</label>
                    <input type="text" class="easyui-textbox" runat="server" id="tdResponseTime" />（小时）
                </div>
                <div class="tableItem">
                    <label class="title">核查时效</label>
                    <input type="text" class="easyui-textbox" runat="server" id="tdCheckTime" />（小时）
                </div>
                <div class="tableItem">
                    <label class="title">处理时效</label>
                    <input type="text" class="easyui-textbox" runat="server" id="tdChuliTime" />（小时）
                </div>
                <div class="tableItem">
                    <label class="title">办结时效</label>
                    <input type="text" class="easyui-textbox" runat="server" id="tdBanJieTime" />（小时）
                </div>
                <div class="tableItem">
                    <label class="title">回访时效</label>
                    <input type="text" class="easyui-textbox" runat="server" id="tdHuiFangTime" />（小时）
                </div>
                <div class="tableItem">
                    <label class="title">关单时效</label>
                    <input type="text" class="easyui-textbox" runat="server" id="tdGuanDanTime" />（小时）
                </div>
                <div class="tableItem">
                    <label class="title">包括节假日</label>
                    <select class="easyui-combobox" runat="server" id="tdDisableHolidayTime">
                        <option value="0">是</option>
                        <option value="1">否</option>
                    </select>
                </div>
                <div class="tableItem">
                    <label class="title">上班时间</label>
                    <input type="text" class="easyui-textbox" runat="server" id="tdStartHour" />（00:00）
                </div>
                <div class="tableItem">
                    <label class="title">下班时间</label>
                    <input type="text" class="easyui-textbox" runat="server" id="tdEndHour" />（00:00）
                </div>
            </div>
        </div>
    </form>
</asp:Content>
