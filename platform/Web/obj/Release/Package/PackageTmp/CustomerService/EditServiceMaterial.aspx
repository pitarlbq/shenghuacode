<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditServiceMaterial.aspx.cs" Inherits="Web.CustomerService.EditServiceMaterial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>任务登记</title>
    <script>
        var ID, guid, CustomerServiceID;
        $(function () {
            ID = "<%=this.Request.QueryString["ID"]%>";
            guid = "<%=this.Request.QueryString["guid"]%>";
            CustomerServiceID = "<%=this.Request.QueryString["CustomerServiceID"]%>";
            $("#<%=this.tdUnitPrice.ClientID%>").textbox({
                onChange: function (newValue, oldValue) {
                    calculateTotalCost();
                }
            });
            $("#<%=this.tdTotalCount.ClientID%>").textbox({
                onChange: function (newValue, oldValue) {
                    calculateTotalCost();
                }
            });
        });
        function calculateTotalCost() {
            var TotalCount = $("#<%=this.tdTotalCount.ClientID%>").textbox("getValue");
            var UnitPrice = $("#<%=this.tdUnitPrice.ClientID%>").textbox("getValue");
            TotalCount = (Number(TotalCount) > 0 ? Number(TotalCount) : 0);
            UnitPrice = (Number(UnitPrice) > 0 ? Number(UnitPrice) : 0);
            var TotalCost = Number(TotalCount) * Number(UnitPrice);
            $("#<%=this.tdTotalCost.ClientID%>").textbox('setValue', TotalCost);
            return TotalCost;
        }
        function savedata() {
            var isValid = $('#<%=this.ff.ClientID%>').form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            $('#ff').form('submit', {
                url: '../Handler/ServiceHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'saveservicematerial';
                    param.ID = ID;
                    param.guid = guid;
                    param.CustomerServiceID = CustomerServiceID;
                    param.MateralName = $('#<%=this.tdMateralName.ClientID%>').textbox('getValue');
                    param.TotalCost = $('#<%=this.tdTotalCost.ClientID%>').textbox('getValue');
                    param.TotalCount = $('#<%=this.tdTotalCount.ClientID%>').textbox('getValue');
                    param.UnitPrice = $('#<%=this.tdUnitPrice.ClientID%>').textbox('getValue');
                },
                success: function (data) {
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        if (dataObj.ID > 0) {
                            show_message('保存成功', 'success', function () {
                                closeWin();
                            });
                            return;
                        }
                        show_message("商品不存在", "warning");
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
        function closeWin() {
            parent.$('#winaddproduct').window('close');
        }
    </script>
    <style>
        table.info {
            width: 100%;
            border: solid 1px #ccc;
            border-spacing: 0;
            border-collapse: collapse;
        }

            table.info td {
                border: solid 1px #ccc;
                padding: 10px;
                text-align: left;
                width: 35%;
            }

                table.info td:nth-child(2n-1) {
                    text-align: right;
                    width: 15%;
                }

        input[type=text] {
            width: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <table class="info">
            <tr>
                <td>材料名称</td>
                <td>
                    <input type="text" runat="server" name="MateralName" class="easyui-textbox" id="tdMateralName" /></td>
                <td>数量</td>
                <td>
                    <input type="text" runat="server" name="TotalCount" class="easyui-textbox" id="tdTotalCount" /></td>
            </tr>
            <tr>
                <td>单价</td>
                <td>
                    <input type="text" runat="server" name="UnitPrice" class="easyui-textbox" id="tdUnitPrice" /></td>
                <td>金额</td>
                <td>
                    <input type="text" runat="server" name="TotalCost" class="easyui-textbox" id="tdTotalCost" /></td>
            </tr>
        </table>
        <div style="text-align: center;">
            <a href="javascript:void(0)" onclick="savedata()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
        </div>
    </form>
</asp:Content>
