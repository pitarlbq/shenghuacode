<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ServiceStatic.aspx.cs" Inherits="Web.CustomerService.ServiceStatic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>任务统计</title>
    <script>
        var hdServiceType;
        $(function () {
            hdServiceType = $('#<%=this.hdServiceType.ClientID%>');
        })
    </script>
    <script src="../js/Page/CustomerService/ServiceStatic.js?v=<%=base.getToken() %>" type="text/javascript"></script>
    <style>
        .tdsearch label {
            margin-right: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div class="easyui-layout" fit="true">
            <div data-options="region:'north'" style="height: 50px; padding: 5px 10px;">
                <div class="tdsearch">
                    <label>
                        任务时间：
               <input class="easyui-datebox" id="tdStartTime" style="width: 100px; height: 25px;" />
                        -
                    <input class="easyui-datebox" id="tdEndTime" style="width: 100px; height: 25px;" />
                    </label>
                    <label>
                        <a href="javascript:void(0)" onclick="loadTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                    </label>
                    <asp:HiddenField runat="server" ID="hdServiceType" />
                    <label style="margin-right: 10px; line-height: 25px;">
                        <input type="radio" name="tabletype" value="servicecategory"  checked="checked"/>服务类别
                    </label>
                    <label style="margin-right: 10px;">
                        <input type="radio" name="tabletype" value="tasktype" />服务标签
                    </label>
                    <label>
                        <input type="radio" name="tabletype" value="accpetman" />接单人
                    </label>
                </div>
            </div>
            <div data-options="region:'center'" title="">
                <table id="tt_table">
                </table>
            </div>
        </div>
    </form>
</asp:Content>
