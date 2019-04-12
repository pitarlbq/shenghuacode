<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="ServiceTimeOutDetailAnalysis.aspx.cs" Inherits="Web.Analysis.ServiceTimeOutDetailAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>投诉超时效工单清单</title>
    <script>
        var ColumnServiceStatus = 31, ColumnServiceType = 3;
    </script>
    <script src="../js/Page/Analysis/ServiceTimeOutDetailAnalysis.js?v=<%=base.getToken() %>" type="text/javascript"></script>
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
                <input class="easyui-searchbox" id="tdKeywords" style="height: 28px; width: 150px;" data-options="prompt:'请输入关键字',searcher:SearchTT" />
            </div>
            <div class="search_item">
                <select class="easyui-combobox" id="tdTimeOutType" style="height: 28px; width: 120px;" data-options="prompt:'请选择超时类型',editable:false">
                    <option value="">全部</option>
                    <option value="2">超时</option>
                    <option value="3">严重超时</option>
                </select>
            </div>
            <div class="search_item">
                <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">查询</a>
            </div>
        </div>
        <div data-options="region:'center'" title="">
            <table id="tt_table">
            </table>
            <div id="tb">
                <a href="javascript:void(0)" onclick="openTableSetUp()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-setting'">配置</a>
                <a href="javascript:void(0)" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
            </div>
        </div>
    </div>
</asp:Content>
