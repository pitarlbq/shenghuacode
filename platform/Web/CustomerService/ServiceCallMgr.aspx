<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ServiceCallMgr.aspx.cs" Inherits="Web.CustomerService.ServiceCallMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var ServiceID = 0;
        $(function () {
            ServiceID = "<%=this.ServiceID%>";
        })
        function do_close() {
            try {
                parent.do_close_dialog()
            } catch (e) {

            }
            try {
                parent.parent.do_close_dialog();
            } catch (e) {
            }
        }
    </script>
    <script src="../js/Page/CustomerService/ServiceCallMgr.js?v=<%=base.getToken() %>"></script>
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
        <div data-options="region:'north',border:false" style="height: 80px; font-size: 12px; padding: 5px;">
            <div class="operation_box">
                <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
            </div>
            <label>
                关键字:
                <input class="easyui-searchbox" id="tdKeywords" type="text" data-options="prompt:'关键字搜索',searcher:SearchTT" />
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
