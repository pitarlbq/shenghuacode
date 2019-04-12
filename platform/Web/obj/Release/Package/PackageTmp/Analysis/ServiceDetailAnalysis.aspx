<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="ServiceDetailAnalysis.aspx.cs" Inherits="Web.Analysis.ServiceDetailAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var ColumnServiceStatus = 30, ColumnServiceType = 3;
        var timeValue = 1, hdServiceTypeName1, typeList = [];
        $(function () {
            hdServiceTypeName1 = $('#<%=this.hdServiceTypeName1.ClientID%>');
            if (hdServiceTypeName1.val() != '') {
                typeList = eval('(' + hdServiceTypeName1.val() + ')');
            }
            $('#tdServiceTypeName1').combobox({
                editable: false,
                data: typeList,
                valueField: 'ID',
                textField: 'Name'
            })
            set_time_value();
            search_bar_click();
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
        function search_bar_click() {
            var elems = $('.search_item label');
            $('.search_item label').bind('click', function () {
                var that = this;
                timeValue = $(that).attr('data-value');
                $.each(elems, function (index, elem) {
                    var my_value = $(elem).attr('data-value');
                    if (my_value == timeValue) {
                        $(elem).addClass('active');
                    }
                    else {
                        $(elem).removeClass('active');
                    }
                })
                set_time_value();
                SearchTT();
            })
        }
        function set_time_value() {
            var start = '';
            var end = '';
            var mydate = new Date();
            //获取今天
            var nowDate = new Date(); //当天日期
            //今天是本周的第几天
            var nowDayOfWeek = nowDate.getDay();
            //当前日
            var nowDay = nowDate.getDate();
            //当前月
            var nowMonth = nowDate.getMonth();
            //当前年
            var nowYear = nowDate.getFullYear();
            if (timeValue == 1) {
                start = end = setdatebox(mydate);
            }
            else if (timeValue == 2) {
                var getWeekStartDate = new Date(nowYear, nowMonth, nowDay - nowDayOfWeek + 1);
                start = setdatebox(getWeekStartDate);
                //获得本周的结束日期
                var getWeekEndDate = new Date(nowYear, nowMonth, nowDay + (7 - nowDayOfWeek));
                end = setdatebox(getWeekEndDate);
            }
            else if (timeValue == 3) {
                //获得本月的开始日期
                var getMonthStartDate = new Date(nowYear, nowMonth, 1);
                start = setdatebox(getMonthStartDate);
                //获得本月的结束日期
                var getMonthEndDate = new Date(nowYear, (nowMonth + 1), 1);
                getMonthEndDate.setTime(getMonthEndDate.getTime() - 24 * 60 * 60 * 1000);
                end = setdatebox(getMonthEndDate);
            }
            $('#tdStartTime').datebox('setValue', start);
            $('#tdEndTime').datebox('setValue', end);
        }
        function setdatebox(mydate) {
            var str = "" + mydate.getFullYear() + "-";
            str += (mydate.getMonth() + 1) + "-";
            str += mydate.getDate();
            return str;
        }

    </script>
    <script src="../js/Page/Analysis/ServiceDetailAnalysis.js?v=<%=base.getToken() %>" type="text/javascript"></script>
    <style>
        .search_item {
            display: inline-table;
            margin-left: 20px;
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

                .search_item label.active {
                    background: #b7b7b7;
                }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div id="main_form_layout" class="easyui-layout" fit="true">
        <div data-options="region:'north',split:false,hideCollapsedContent:false," title="" style="height: 100px; padding: 5px;">
            <form runat="server">
                <div class="search_item">
                    <label class="active" data-value="1" style="margin-left: 0;">当天</label>
                    <label data-value="2">本周</label>
                    <label data-value="3">本月</label>
                </div>
                <div class="search_item" style="margin-right: 10px;">
                    <input class="easyui-datebox" id="tdStartTime" style="height: 28px; width: 120px;" />
                </div>
                <div class="search_item" style="margin-left: 10px;">
                    -
                </div>
                <div class="search_item">
                    <input class="easyui-datebox" id="tdEndTime" style="height: 28px; width: 100px;" />
                </div>
                <div class="search_item">
                    <input class="easyui-combobox" id="tdCompanyID" data-options="prompt:'请选择公司',editable:false" style="height: 28px; width: 120px;" />
                </div>
                <div class="search_item">
                    <input class="easyui-combobox" id="tdProjectID" data-options="prompt:'请选择项目',editable:false,multiple:true" style="height: 28px; width: 100px;" />
                </div>
                <div class="search_item">
                    <input class="easyui-combobox" id="tdServiceTypeName1" style="height: 28px; width: 100px;" data-options="prompt:'请选择类型',editable:false" />
                    <asp:HiddenField runat="server" ID="hdServiceTypeName1" />
                </div>
                <div class="search_item">
                    <select class="easyui-combobox" id="tdCloseType" style="height: 28px; width: 100px;" data-options="prompt:'请选择关单类型',editable:false">
                        <option value="">全部</option>
                        <option value="1">已关单</option>
                        <option value="2">未关单</option>
                    </select>
                </div>
                <div class="search_item">
                    <select class="easyui-combobox" id="tdTimeOutType" style="height: 28px; width: 100px;" data-options="prompt:'请选择超时类型',editable:false">
                        <option value="">全部</option>
                        <option value="2">超时</option>
                        <option value="1">正常</option>
                    </select>
                </div>
                <div class="search_item">
                    <input class="easyui-searchbox" id="tdKeywords" style="height: 28px; width: 150px;" data-options="prompt:'请输入关键字',searcher:SearchTT" />
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
                <a href="javascript:void(0)" onclick="openTableSetUp()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-setting'">配置</a>
                <a href="javascript:void(0)" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
            </div>
        </div>
    </div>
</asp:Content>
