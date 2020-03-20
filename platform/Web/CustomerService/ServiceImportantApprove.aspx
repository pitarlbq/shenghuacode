<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ServiceImportantApprove.aspx.cs" Inherits="Web.CustomerService.ServiceImportantApprove" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function do_save(status) {
            var ID = "<%=this.ServiceID%>";
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
                if (IDList.indexOf(ID) > -1) {
                    return true;
                }
                IDList.push(row.ID);
            })
            var approveMsg = '确认执行重大报修投诉审核？';
            if (IDList.length > 1) {
                approveMsg = '您正在同时审核多个工单，继续操作请点击确认';
            }
            $.messager.confirm('提示', approveMsg, function (r) {
                if (r) {
                    MaskUtil.mask('body', '提交中');
                    $('#ff').form('submit', {
                        url: '../Handler/ServiceHandler.ashx',
                        onSubmit: function (param) {
                            param.visit = 'serviceimportapprove';
                            param.IDList = JSON.stringify(IDList);
                            param.status = status;
                            param.Remark = $('#<%=this.tdResponseRemark.ClientID%>').textbox('getValue');
                        },
                        success: function (data) {
                            MaskUtil.unmask();
                            var dataObj = eval("(" + data + ")");
                            if (dataObj.status) {
                                window.update = true;
                                show_message('审核成功', 'success', function () {
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
            <%if (this.ApproveStatus == 0)
                { %>
            <a href="javascript:void(0)" onclick="do_save(1)" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">审核通过</a>
            <a href="javascript:void(0)" onclick="do_save(2)" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">审核不通过</a>
            <%} %>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <div class="tableItem" style="width: 100%;">
                <label class="title">申请时间</label>
                <label id="tdApplicationTime" runat="server"></label>
            </div>
            <div class="tableItem" style="width: 100%;">
                <label class="title">申请人</label>
                <label id="tdApplicationUsreName" runat="server"></label>
            </div>
            <%if (this.IsSuggestion == 0)
                { %>
            <div class="tableItem" style="width: 100%;">
                <label class="title">申请类型</label>
                <label id="tdApplicationType" runat="server"></label>
            </div>
            <%if (this.ApplicationType == 4)
                { %>
            <div class="tableItem type4" style="width: 100%;">
                <label class="title">业主在家时间</label>
                <label id="tdReturnHomeDate" runat="server"></label>
            </div>
            <%} %>
            <%} %>
            <div class="tableItem" style="width: 100%;">
                <label class="title">附件</label>
                <a href="<%=this.FilePath %>" target="_blank">下载</a>
            </div>
            <div class="tableItem" style="width: 100%;">
                <label class="title">申请说明</label>
                <label id="tdRemark" runat="server"></label>
            </div>
            <%if (this.ApproveStatus != 0)
                { %>
            <div class="tableItem" style="width: 100%;">
                <label class="title">审核时间</label>
                <label id="tdApproveTime" runat="server"></label>
            </div>
            <div class="tableItem" style="width: 100%;">
                <label class="title">审核人</label>
                <label id="tdApproveUserName" runat="server"></label>
            </div>
            <div class="tableItem" style="width: 100%;">
                <label class="title">审核状态</label>
                <label id="tdApproveStatus" runat="server"></label>
            </div>
            <%} %>
            <div class="tableItem" style="width: 100%;">
                <label class="title">审核说明</label>
                <input class="easyui-textbox" id="tdResponseRemark" runat="server" data-options="multiline:true" style="width: 60%; height: 50px;" />
            </div>
        </div>
    </form>
</asp:Content>
