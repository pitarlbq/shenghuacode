<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="CustomerServiceTypeEdit.aspx.cs" Inherits="Web.CustomerService.CustomerServiceTypeEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID = 0, ParentID = 0, IsDisableTime = 0;
        $(function () {
            ID = "<%=this.ID%>";
            ParentID = "<%=this.ParentID%>";
            IsDisableTime = Number("<%=this.IsDisableTime%>");
            if (ParentID <= 1) {
                $('.topCss').show();
            } else {
                $('.topCss').hide();
            }
            if (IsDisableTime == 1) {
                $('.hidetime').hide();
            } else {
                $('.hidetime').show();
            }
        })
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/ServiceHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'saveservicetype';
                    param.ID = ID;
                    param.ParentID = ParentID;
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
                    <label class="title">分类名称</label>
                    <input type="text" class="easyui-textbox" runat="server" id="tdServiceTypeName" />
                </div>
                <div class="tableItem">
                    <label class="title">所属上级</label>
                    <label runat="server" id="tdParentName"></label>
                </div>
                <div class="tableItem">
                    <label class="title">排序序号</label>
                    <input type="text" class="easyui-textbox" runat="server" id="tdSortOrder" />
                </div>
                <div class="tableItem hidetime">
                    <label class="title">派单时效</label>
                    <input type="text" class="easyui-textbox" runat="server" id="tdPaiDanTime" />（小时）
                </div>
                <div class="tableItem hidetime">
                    <label class="title">回复时效</label>
                    <input type="text" class="easyui-textbox" runat="server" id="tdResponseTime" />（小时）
                </div>
                <div class="tableItem hidetime">
                    <label class="title">核查时效</label>
                    <input type="text" class="easyui-textbox" runat="server" id="tdCheckTime" />（小时）
                </div>
                <div class="tableItem hidetime">
                    <label class="title">处理时效</label>
                    <input type="text" class="easyui-textbox" runat="server" id="tdChuliTime" />（小时）
                </div>
                <div class="tableItem hidetime">
                    <label class="title">办结时效</label>
                    <input type="text" class="easyui-textbox" runat="server" id="tdBanJieTime" />（小时）
                </div>
                <div class="tableItem hidetime">
                    <label class="title">回访时效</label>
                    <input type="text" class="easyui-textbox" runat="server" id="tdHuiFangTime" />（小时）
                </div>
                <div class="tableItem hidetime">
                    <label class="title">关单时效</label>
                    <input type="text" class="easyui-textbox" runat="server" id="tdGuanDanTime" />（小时）
                </div>
                <div class="tableItem hidetime">
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
                <div class="tableItem hidetime">
                    <label class="title">上班时间</label>
                    <input type="text" class="easyui-textbox" runat="server" id="tdStartHour" />（00:00）
                </div>
                <div class="tableItem hidetime">
                    <label class="title">下班时间</label>
                    <input type="text" class="easyui-textbox" runat="server" id="tdEndHour" />（00:00）
                </div>
                <div class="tableItem topCss">
                    <label class="title">支持派单</label>
                    <select class="easyui-combobox" runat="server" id="tdDisableSend">
                        <option value="0">是</option>
                        <option value="1">否</option>
                    </select>
                </div>
                <div class="tableItem topCss">
                    <label class="title">支持处理</label>
                    <select class="easyui-combobox" runat="server" id="tdDisableProcee">
                        <option value="0">是</option>
                        <option value="1">否</option>
                    </select>
                </div>
                <div class="tableItem topCss">
                    <label class="title">支持办结</label>
                    <select class="easyui-combobox" runat="server" id="tdDisableCompelte">
                        <option value="0">是</option>
                        <option value="1">否</option>
                    </select>
                </div>
                <div class="tableItem topCss">
                    <label class="title">支持回访</label>
                    <select class="easyui-combobox" runat="server" id="tdDisableCallback">
                        <option value="0">是</option>
                        <option value="1">否</option>
                    </select>
                </div>
                <div class="tableItem topCss">
                    <label class="title">支持审计</label>
                    <select class="easyui-combobox" runat="server" id="tdDisableShenJi">
                        <option value="0">是</option>
                        <option value="1">否</option>
                    </select>
                </div>
                <div class="tableItem topCss">
                    <label class="title">关单方式</label>
                    <select class="easyui-combobox" runat="server" id="tdCloseServiceType">
                        <option value="1">办结后关单</option>
                        <option value="2">回访后关单</option>
                        <option value="3">审计确认后关单</option>
                        <option value="4">无限制关单</option>
                    </select>
                </div>
                <div class="tableItem topCss">
                    <label class="title">回访方式</label>
                    <select class="easyui-combobox" runat="server" id="tdCallBackServiceType">
                        <option value="1">关单后回访</option>
                        <option value="2">办结后回访</option>
                        <option value="3">无限制回访</option>
                    </select>
                </div>
                <div class="tableItem topCss">
                    <label class="title">办结方式</label>
                    <select class="easyui-combobox" runat="server" id="tdBanJieServiceType">
                        <option value="1">处理后办结</option>
                        <option value="2">无限制办结</option>
                    </select>
                </div>
                <div class="tableItem topCss">
                    <label class="title">工单类型</label>
                    <select class="easyui-combobox" runat="server" id="tdGongDanType">
                        <option value="1">任务工单</option>
                        <option value="2">投诉建议</option>
                    </select>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
