<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ThirdCustomerMgr.aspx.cs" Inherits="Web.InitialSetup.ThirdCustomerMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/InitialSetup/ThirdCustomerMgr.js?token=<%=base.getToken() %>"></script>
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
    <form runat="server" id="form1">
        <div class="easyui-layout" fit="true">
            <div data-options="region:'north'" style="height: 60px; padding: 10px;">
                <div class="search_item" style="margin-right: 10px;">
                    关键字
                    <input class="easyui-searchbox" id="tdKeyword" type="text" data-options="prompt:'资源编号|业主姓名|手机号码',searcher:SearchTT" style="width: 200px" />
                </div>
                <div class="search_item" style="margin-right: 10px;">
                    签约日期
                     <input class="easyui-datebox" id="tdStartTime" data-options="prompt:'开始日期'" style="height: 28px; width: 120px;" />
                    -
                     <input class="easyui-datebox" id="tdEndTime" data-options="prompt:'结束日期'" style="height: 28px; width: 120px;" />
                </div>
                <div class="search_item">
                    发送状态
                    <select class="easyui-combobox" id="tdSendStatus" style="height: 28px; width: 120px;" data-options="prompt:'请选择',editable:false">
                        <option value="">全部</option>
                        <option value="1">未发送</option>
                        <option value="2">已发送</option>
                    </select>
                </div>
                <div class="search_item">
                    项目名称
                    <input class="easyui-combobox" id="tdProjectName" style="height: 28px; width: 120px;" data-options="prompt:'请选择',editable:false" />
                </div>
                <div class="search_item">
                    <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-search'">查询</a>
                </div>
            </div>
            <div data-options="region:'center'" title="">
                <table id="tt_table">
                </table>
                <div id="tb">
                    <a href="javascript:void(0)" onclick="do_add()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
                    <a href="javascript:void(0)" onclick="do_import()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-import'">导入</a>
                    <a href="javascript:void(0)" onclick="do_export(0)" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                    <a href="javascript:void(0)" onclick="do_send()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-send'">发送短信</a>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
