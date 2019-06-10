<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ImportantTouSuRuleEdit.aspx.cs" Inherits="Web.SysSeting.ImportantTouSuRuleEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/SysSettingHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'saveimporttousudata';
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        $.messager.alert("提示", "保存成功", "info", function () {
                        });
                        return;
                    }
                    if (dataObj.error) {
                        show_message(dataObj.error, 'error');
                        return;
                    }
                    show_message('内部异常', 'error');
                }
            });
        }
    </script>
    <style>
        .tableItem {
        }

            .tableItem input[type=text] {
                width: 300px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
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
                <div class="tableItem hidetime">
                    <label class="title">包括下班时间</label>
                    <select class="easyui-combobox" runat="server" id="tdDisableWorkOffTime">
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
