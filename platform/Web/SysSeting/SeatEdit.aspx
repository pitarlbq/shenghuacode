<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="SeatEdit.aspx.cs" Inherits="Web.SysSeting.SeatEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var driverStatus = 0;
        $(function () {
            checkDriverStatus();
        })
        function checkDriverStatus() {
            var iVer = 1;//第一个版本
            top.check_ver(iVer, function (nRet) {
                var szHint = "";
                switch (nRet) {
                    case top.W_OK://检查成功
                        szHint = "正常工作";
                        driverStatus = 1;
                        break;
                    case top.W_TRY://试用
                        szHint = "试用版本已安装成功";
                        break;
                    case top.W_NO_FOUND://没有找到校验服务器
                        szHint = "没有找到校验服务器";
                        break;
                    case top.W_EXCEED_NUM:
                        szHint = "校验服务器超过用户数了";
                        break;
                    default:
                        szHint = "没有安装本地驱动，请下载";
                        break;
                }
                $('#tdDriverStatus').html(szHint);
            });
        }
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/SysSettingHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savemyseat';
                    param.driverStatus = driverStatus;
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
        function do_close() {
            try {
                parent.do_close_dialog(function () {
                    parent.$("#tt_table").datagrid("reload");
                }, true);
            } catch (e) {
            }
        }
    </script>
    <style>
        .tableItem {
            width: 100%;
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
                    <label class="title">驱动状态</label>
                    <label id="tdDriverStatus"></label>
                </div>
                <div class="tableItem">
                    <label class="title">驱动下载</label>
                    <a target="_blank" href="../download/driver.zip">点击下载</a>
                </div>
                <div class="tableItem">
                    <label class="title">座席名称</label>
                    <input type="text" class="easyui-textbox" id="tdSeatName" runat="server" data-options="required:true" style="height: 28px;" />
                </div>
                <div class="tableItem">
                    <label class="title">录音存放路径</label>
                    <input id="tdRecordLocation" runat="server" type="text" class="easyui-textbox" style="height: 28px;" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>
