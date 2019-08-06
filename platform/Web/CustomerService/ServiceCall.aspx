﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ServiceCall.aspx.cs" Inherits="Web.CustomerService.ServiceCall" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID, tdHuiFangTime, CanManualyAddPhoneState = 0;
        $(function () {
            $('#btnSave').hide();
            ID = "<%=this.ID%>";
            tdHuiFangTime = $('#<%=this.tdHuiFangTime.ClientID%>');
            tdHuiFangNote = $('#<%=this.tdHuiFangNote.ClientID%>');
            CanManualyAddPhoneState = <%=this.CanManualyAddPhoneState?1:0%>;
            var phoneNumber = '<%=this.PhoneNumber%>';
            if (phoneNumber == '') {
                $('#btnCall').hide();
            }
            $('#btnCall').bind('click', function () {
                top.dialPhone(phoneNumber, ID);
                tdHuiFangTime.datetimebox({
                    readonly: false
                })
                tdHuiFangNote.textbox({
                    readonly: false
                })
                $('#btnSave').show();
            })
        });
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/ServiceHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'saveservicehuifang';
                    param.ID = ID;
                    param.CanManualyAddPhoneState = CanManualyAddPhoneState;
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        window.updateWin = true;
                        show_message('保存成功', 'success', function () {
                            do_close();
                        });
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
        function do_close() {
            parent.do_close_dialog(function () {
                if (window.updateWin) {
                    parent.reloadTT();
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
            <div class="tableContent">
                <div class="tableItem">
                    <label class="title">致电客户</label>
                    <label id="btnCall" class="callCss">拨打</label>
                </div>
                <div class="tableItem">
                    <label class="title">回访时间</label>
                    <input type="text" runat="server" data-options="required:true,readonly:true" class="easyui-datetimebox" id="tdHuiFangTime" style="height: 28px;" />
                </div>
                <div class="tableItem" style="width: 100%;">
                    <label class="title">回访情况</label>
                    <input type="text" runat="server" class="easyui-textbox" id="tdHuiFangNote" data-options="multiline:true,readonly:true" style="width: 70%; height: 60px;" />
                </div>
                <div class="tableItem" style="width: 100%;">
                    <label class="title">处理满意度</label>
                    <select class="easyui-combobox" id="tdchulirate" runat="server" data-options="editable:false">
                        <option value="">请选择</option>
                        <option value="1">1分</option>
                        <option value="2">2分</option>
                        <option value="3">3分</option>
                        <option value="4">4分</option>
                        <option value="5">5分</option>
                    </select>
                </div>
                <%if (this.CanManualyAddPhoneState)
                    { %>
                <div class="tableItem">
                    <label class="title">电话回访状态</label>
                    <select class="easyui-combobox" id="tdPhoneCallBackType" runat="server" data-options="editable:false">
                        <option value="">请选择</option>
                        <option value="1">正常接通</option>
                        <option value="2">未接通</option>
                        <option value="3">未拨打</option>
                    </select>
                </div>
                <div class="tableItem">
                    <label class="title">电话录音上传</label>
                    <input class="easyui-filebox" name="attachfile" data-options="prompt:'请选择文件',buttonText: '选择文件'" style="width: 60%; height: 28px;" />
                </div>
                <%}
                    else
                    { %>
                <div class="tableItem">
                    <label class="title">电话回访状态</label>
                    <label runat="server" id="labelPhoneStatusDesc"></label>
                </div>
                <%} %>
            </div>
        </div>
    </form>
</asp:Content>
