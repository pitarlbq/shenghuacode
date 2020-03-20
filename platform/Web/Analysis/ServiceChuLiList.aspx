<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="ServiceChuLiList.aspx.cs" Inherits="Web.Analysis.ServiceChuLiList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>处理时效列表</title>
    <script>
        var typeid = 0;
        var status = 0;
        var ProjectID = 0;
        var CompanyID = 0;
        var StartTime = '';
        var EndTime = '';
        var ServiceType2ID = 0;
        var ServiceType3ID = 0;
        $(function () {
            typeid = "<%=this.typeid%>";
            status = "<%=this.status%>";
            StartTime = "<%=this.StartTime%>";
            EndTime = "<%=this.EndTime%>";
            ProjectID = Number("<%=this.ProjectID%>");
            CompanyID = Number("<%=this.CompanyID%>");
            ServiceType2ID = Number("<%=this.ServiceType2ID%>");
            ServiceType3ID = Number("<%=this.ServiceType3ID%>");
            if (StartTime != '') {
                $('#tdStartTime').datebox('setValue', StartTime);
            }
            if (EndTime != '') {
                $('#tdEndTime').datebox('setValue', EndTime);
            }
        })
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$("#tt_table").treegrid("reload");
            }, true);
        }
    </script>
    <script src="../js/Page/Analysis/ServiceChuLiList.js?v=<%=base.getToken() %>" type="text/javascript"></script>
    <style>
        .search_item {
            display: inline-table;
            margin-right: 20px;
            line-height: 40px;
        }

            .search_item label {
                border: solid 1px #ddd;
                background: #fff;
                padding: 0 20px;
                border-radius: 10px;
                margin-left: 10px;
                cursor: pointer;
                font-size: 12px;
                line-height: 30px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div id="main_form_layout" class="easyui-layout" fit="true">
        <div data-options="region:'north',split:false,hideCollapsedContent:false," title="" style="height: 60px; padding: 5px;">
            <form runat="server">
                <div class="operation_box" style="width: 100px; right: 0; left: auto; background-color: transparent;">
                    <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
                </div>
                <div class="search_item" style="margin-right: 10px;">
                    <input class="easyui-datebox" id="tdStartTime" data-options="prompt:'开始日期'" style="height: 28px; width: 120px;" />
                </div>
                <div class="search_item" style="margin-right: 10px;">
                    -
                </div>
                <div class="search_item">
                    <input class="easyui-datebox" id="tdEndTime" data-options="prompt:'结束日期'" style="height: 28px; width: 120px;" />
                </div>
                <div class="search_item">
                    <a href="javascript:void(0)" onclick="loadTT()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-search'">查询</a>
                </div>
            </form>
        </div>
        <div data-options="region:'center'" title="">
            <table id="tt_table">
            </table>
        </div>
    </div>
</asp:Content>
