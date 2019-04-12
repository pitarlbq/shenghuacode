<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="ServiceMaterialList.aspx.cs" Inherits="Web.CustomerService.ServiceMaterialList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>物料清单</title>
    <script src="../js/Page/CustomerService/ServiceMaterialList.js?v=<%=base.getToken() %>" type="text/javascript"></script>
    <style>
        .tdsearch label {
            margin-right: 10px;
        }

        .btn.btn-link {
            padding: 4px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div class="easyui-layout" fit="true">
            <div data-options="region:'north'" style="height: 50px; padding: 5px 10px;">
                <div class="tdsearch">
                    <label>
                        登记日期：
                        <input class="easyui-datebox" id="tdStartTime" style="width: 100px; height: 25px;" />
                        -
                    <input class="easyui-datebox" id="tdEndTime" style="width: 100px; height: 25px;" />
                    </label>
                    <label>
                        是否有偿：
                <select class="easyui-combobox" id="tdPayStatus" style="width: 100px; height: 25px;">
                    <option value="">全部</option>
                    <option value="1">有偿</option>
                    <option value="0">无偿</option>
                </select>
                    </label>
                    <label>
                        结算状态：
                <select class="easyui-combobox" id="tdBalanceStatus" style="width: 100px; height: 25px;">
                    <option value="">全部</option>
                    <option value="balanceyes">已结算</option>
                    <option value="complete">已销单</option>
                    <option value="balanceno">未结算</option>
                </select>
                    </label>
                    <label>
                        <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                    </label>
                </div>
            </div>
            <div data-options="region:'center'" title="">
                <table id="tt_table">
                </table>
                <div id="tb">
                    <a href="javascript:void(0)" onclick="doPay()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-balance'">结算</a>
                    <a href="javascript:void(0)" onclick="doComplete()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-cancelorder'">销单</a>
                </div>
            </div>
        </div>
    </form>
    <iframe name="myiframe" id="myframe" style="display: none;" src="" width="100%" height="100%"></iframe>
</asp:Content>
