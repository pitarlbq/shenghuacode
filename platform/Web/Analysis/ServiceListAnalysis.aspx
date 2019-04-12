<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="ServiceListAnalysis.aspx.cs" Inherits="Web.Analysis.ServiceListAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>维修超时效工单清单</title>
    <script>
        var ColumnServiceStatus = 35, ColumnServiceType = 3;
        var hdServiceTypeName1, hdServiceTypeName2, hdServiceTypeName3, typeList1 = [], typeList2 = [], typeList3 = [];
        $(function () {
            hdServiceTypeName1 = $('#<%=this.hdServiceTypeName1.ClientID%>');
            hdServiceTypeName2 = $('#<%=this.hdServiceTypeName2.ClientID%>');
            hdServiceTypeName3 = $('#<%=this.hdServiceTypeName3.ClientID%>');
            if (hdServiceTypeName1.val() != '') {
                typeList1 = eval('(' + hdServiceTypeName1.val() + ')');
            }
            if (hdServiceTypeName2.val() != '') {
                typeList2 = eval('(' + hdServiceTypeName2.val() + ')');
            }
            if (hdServiceTypeName3.val() != '') {
                typeList3 = eval('(' + hdServiceTypeName3.val() + ')');
            }
            $('#tdServiceTypeName1').combobox({
                editable: false,
                data: typeList1,
                valueField: 'ID',
                textField: 'Name',
                onSelect: function (ret) {
                    getTypeList2Combobox(ret.ID)
                }
            })
            getProjectParams();
            $('.easyui-combobox').combobox('clear');
        })
        function getTypeList2Combobox(ParentID) {
            var list = [];
            list.push({ ID: 0, Name: '全部' });
            $.each(typeList2, function (index, item) {
                if (item.ParentID == ParentID) {
                    list.push(item);
                }
            })
            $('#tdServiceTypeName2').combobox({
                editable: false,
                data: list,
                valueField: 'ID',
                textField: 'Name',
                onSelect: function (ret) {
                    getTypeList3Combobox(ret.ID)
                }
            })
            $('#tdServiceTypeName2').combobox('setValue', 0);
        }
        function getTypeList3Combobox(ParentID) {
            var list = [];
            list.push({ ID: 0, Name: '全部' });
            $.each(typeList3, function (index, item) {
                if (item.ParentID == ParentID) {
                    list.push(item);
                }
            })
            $('#tdServiceTypeName3').combobox({
                editable: false,
                data: list,
                valueField: 'ID',
                textField: 'Name'
            })
            $('#tdServiceTypeName3').combobox('setValue', 0);
        }
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
                }
            });
        }
        function setProjectCombobox(companyID) {
            var list = [];
            $.each(projectList, function (index, item) {
                if (item.CompanyID == companyID) {
                    list.push(item);
                }
            })
            $('#tdProjectID').combobox({
                data: list,
                multiple: true,
                editable: false,
                valueField: 'ID',
                textField: 'Name'
            })
        }
    </script>
    <script src="../js/Page/Analysis/ServiceListAnalysis.js?v=<%=base.getToken() %>" type="text/javascript"></script>
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
        <div data-options="region:'north',split:false,hideCollapsedContent:false," title="" style="height: 90px; padding: 5px;">
            <form runat="server">
                <div class="search_item" style="margin-right: 10px;">
                    <input type="text" class="easyui-searchbox" id="tdKeywords" style="width: 150px;" data-options="prompt:'关键字',searcher:SearchTT" />
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
                    <input class="easyui-combobox" id="tdCompanyID" data-options="prompt:'请选择公司',editable:false" style="height: 28px; width: 120px;" />
                </div>
                <div class="search_item">
                    <input class="easyui-combobox" id="tdProjectID" data-options="prompt:'请选择项目',editable:false,multiple:true" style="height: 28px; width: 120px;" />
                </div>
                <div class="search_item">
                    <input class="easyui-combobox" id="tdServiceTypeName1" style="height: 28px; width: 150px;" data-options="prompt:'请选择一级维修类型',editable:false" />
                    <asp:HiddenField runat="server" ID="hdServiceTypeName1" />
                </div>
                <div class="search_item">
                    <input class="easyui-combobox" id="tdServiceTypeName2" style="height: 28px; width: 150px;" data-options="prompt:'请选择二级维修类型',editable:false" />
                    <asp:HiddenField runat="server" ID="hdServiceTypeName2" />
                </div>
                <div class="search_item">
                    <input class="easyui-combobox" id="tdServiceTypeName3" style="height: 28px; width: 150px;" data-options="prompt:'请选择三级维修类型',editable:false" />
                    <asp:HiddenField runat="server" ID="hdServiceTypeName3" />
                </div>
                <div class="search_item">
                    <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-search'">查询</a>
                </div>
            </form>
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
