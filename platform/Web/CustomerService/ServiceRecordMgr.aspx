<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ServiceRecordMgr.aspx.cs" Inherits="Web.CustomerService.ServiceRecordMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var ServiceID = 0;
        $(function () {
            ServiceID = "<%=this.ServiceID%>";
            if (ServiceID > 0) {
                setTimeout(function () {
                    $("#main_form_layout").layout('panel', 'north').panel("options").height = 80;
                    $("#main_form_layout").layout("resize");
                    $('.operation_box').show();
                }, 100);
            }
        })
        function do_close() {
            parent.do_close_dialog(function () {
            })
        }
    </script>
    <script src="../js/Page/CustomerService/ServiceRecordMgr.js?v=<%=base.getToken() %>"></script>
    <style>
        .btn.btn-link {
            padding: 0 !important;
        }

        .operation_box {
            position: relative;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div id="main_form_layout" class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 5px;">
            <div class="operation_box" style="display: none;">
                <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
            </div>
            <label>
                <select class="easyui-combobox" id="tdPhoneType" data-options="prompt:'拨打状态',editable:false" style="width: 100px;">
                    <option value="0">全部</option>
                    <option value="1">来电</option>
                    <option value="2">去电</option>
                </select>
            </label>
            <label>
                <input class="easyui-datetimebox" id="tdStartTime" type="text" data-options="prompt:'开始时间'" />
                -
                <input class="easyui-datetimebox" id="tdEndTime" type="text" data-options="prompt:'结束时间'" />
            </label>
            <label class="searchlabel">
                <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
            </label>
        </div>
        <div data-options="region:'center',border:false">
            <table id="tt_table">
            </table>
        </div>
    </div>
</asp:Content>
