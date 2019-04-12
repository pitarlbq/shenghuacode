<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="OperationMgr.aspx.cs" Inherits="Web.SysSeting.OperationMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/SysSetting/OperationMgr.js?v=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 10px 0 0 5px;">
            <label>
                操作人:
                  <input class="easyui-searchbox" id="tdKeyword" type="text" data-options="prompt:'操作人搜索',searcher:SearchTT" />
            </label>
            <label>
                操作时间
                <input class="easyui-datetimebox" id="tdStartTime" style="width: 180px;" />
                -
                <input class="easyui-datetimebox" id="tdEndTime" style="width: 180px;" />
            </label>
            <label>
                <select class="easyui-combobox" id="tdOperationKey" style="width: 180px;" data-options="editable:false">
                    <option value="">全部</option>
                    <option value="UserLogin">用户登录</option>
                    <option value="ServiceAdd">工单新增</option>
                    <option value="ServiceEdit">工单修改</option>
                    <option value="ServiceDel">工单删除</option>
                    <option value="ServicePaiDan">工单派单</option>
                    <option value="ServiceProcess">工单处理</option>
                    <option value="ServiceBanJie">工单办结</option>
                    <option value="ServiceCallBack">工单回访</option>
                    <option value="ServiceClose">工单关单</option>
                    <option value="ServiceXiaoDan">工单销单</option>
                    <option value="ServiceShenJi">工单审计</option>
                    <option value="ServiceReOpen">工单重新开单</option>
                    <option value="ServiceMoreImportant">工单重大投诉</option>
                </select>
            </label>
            <label class="searchlabel">
                <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">查询</a>
            </label>
        </div>
        <div data-options="region:'center',border:false">
            <table id="tt_table"></table>
            <div id="tt_mm">
            </div>
        </div>
    </div>
</asp:Content>
