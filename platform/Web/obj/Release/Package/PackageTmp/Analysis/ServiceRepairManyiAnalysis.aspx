<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ServiceRepairManyiAnalysis.aspx.cs" Inherits="Web.Analysis.ServiceRepairManyiAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>物业投诉、维修处理满意度统计表</title>
    <script>
        $(function () {
            getProjectParams();
            $('.easyui-combobox').combobox('clear');
        })
        var projectList = [];
        function getProjectParams() {
            var options = { visit: "getprojectparams" }
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ProjectHandler.ashx',
                data: options,
                success: function (data) {
                    if (data.status) {
                        projectList = data.projectList;
                        $('#tdCompanyID').combobox({
                            data: data.companyList,
                            editable: false,
                            valueField: 'ID',
                            textField: 'Name',
                            onSelect: function (ret) {
                                setProjectCombobox(ret.ID);
                            }
                        })
                    }
                    $('.easyui-combobox').combobox('clear');
                    loadTT();
                }
            });
        }
        function setProjectCombobox(companyID) {
            var multiple = false;
            var list = [];
            if (companyID <= 0) {
                list.push({ ID: -1, Name: "不限" });
                if (companyID == 0) {
                    list.push({ ID: 0, Name: "全部" });
                    $('#tdProjectID').combobox('setValue', 0);
                }
            }
            else {
                multiple = true;
                $.each(projectList, function (index, item) {
                    if (item.CompanyID == companyID) {
                        list.push(item);
                    }
                })
            }
            $('#tdProjectID').combobox({
                data: list,
                multiple: multiple,
                editable: false,
                valueField: 'ID',
                textField: 'Name'
            })
            if (companyID == 0) {
                $('#tdProjectID').combobox('setValue', -1);
            }
        }
    </script>
    <script src="../js/Page/Analysis/ServiceRepairManyiAnalysis.js?v=<%=base.getToken() %>" type="text/javascript"></script>
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
                <input class="easyui-combobox" id="tdCompanyID" data-options="prompt:'请选择公司',editable:false" style="height: 28px; width: 120px;" />
            </div>
            <div class="search_item">
                <input class="easyui-combobox" id="tdProjectID" data-options="prompt:'请选择项目',editable:false,multiple:true" style="height: 28px; width: 120px;" />
            </div>
            <div class="search_item">
                <select class="easyui-combobox" id="tdServiceType1" style="height: 28px; width: 120px;" data-options="prompt:'请选择类型',editable:false">
                    <option value="2">全部</option>
                    <option value="3">投诉</option>
                    <option value="4">维修</option>
                </select>
            </div>
            <div class="search_item">
                <a href="javascript:void(0)" onclick="loadTT()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-search'">查询</a>
            </div>
        </div>
        <div data-options="region:'center'" title="">
            <table id="tt_table">
            </table>
            <div id="tb">
                <a href="javascript:void(0)" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
            </div>
        </div>
    </div>
</asp:Content>
