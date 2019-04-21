var tt_CanLoad = false, finalColumns = [];
$(function () {
    loadTT();
});
function getColumns() {
    finalColumns = [];
    var columns = [];
    columns.push({ field: 'CompanyName', title: '公司', width: 100 });
    columns.push({ field: 'FinalProjectName', title: '项目', width: 100 });
    columns.push({ field: 'AddCustomerName', title: '姓名', width: 100 });
    columns.push({ field: 'AddCallPhone', title: '电话', width: 100 });
    columns.push({ field: 'CategoryPartA', title: '一级类型', width: 100 });
    if (typeid == 1) {
        columns.push({ field: 'PaiDanDate', formatter: formatDateTime, title: '派单时间', width: 100 });
        columns.push({ field: 'ResponseTime', formatter: formatDateTime, title: '回复时间', width: 100 });
        columns.push({ field: 'ResponseTakeHour', title: '处理时效', width: 100 });
    }
    if (typeid == 2) {
        columns.push({ field: 'AddTime', formatter: formatDateTime, title: '添加时间', width: 100 });
        columns.push({ field: 'PaiDanDate', formatter: formatDateTime, title: '派单时间', width: 100 });
        columns.push({ field: 'PaiDanTakeHour', title: '处理时效', width: 100 });
    }
    if (typeid == 3) {
        columns.push({ field: 'PaiDanDate', formatter: formatDateTime, title: '派单时间', width: 100 });
        columns.push({ field: 'ChuliDate', formatter: formatDateTime, title: '处理时间', width: 100 });
        columns.push({ field: 'ProcessTakeHour', title: '处理时效', width: 100 });
    }
    if (typeid == 4) {
        columns.push({ field: 'ChuliDate', formatter: formatDateTime, title: '处理时间', width: 100 });
        columns.push({ field: 'BanJieTime', formatter: formatDateTime, title: '办结时间', width: 100 });
        columns.push({ field: 'BanJieTakeHour', title: '处理时效', width: 100 });
    }
    if (typeid == 5) {
        columns.push({ field: 'BanJieTime', formatter: formatDateTime, title: '办结时间', width: 100 });
        columns.push({ field: 'HuiFangTime', formatter: formatDateTime, title: '回访时间', width: 100 });
        columns.push({ field: 'CallBackTakeHour', title: '处理时效', width: 100 });
    }
    finalColumns.push(columns);
}
function loadTT() {
    getColumns();
    tt_CanLoad = false;
    $('#tt_table').datagrid({
        url: '../Handler/ServiceHandler.ashx',
        loadMsg: '正在加载',
        border: false,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: true,
        fitColumns: true,
        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: true,
        striped: true,
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        showFooter: true,
        columns: finalColumns,
        onBeforeLoad: function (data) {
            if (!tt_CanLoad) {
                $('#tt_table').datagrid("loadData", {
                    total: 0,
                    rows: []
                });
            }
            return tt_CanLoad;
        },
        onLoadError: function (data) {
            //alert("有错");
            $('#tt_table').datagrid("loadData", {
                total: 0,
                rows: []
            });
        },
        toolbar: '#tb'
    });
    setTimeout(function () {
        SearchTT()
    }, 100);
}
function SearchTT() {
    var options = get_options();
    if (options == null) {
        return;
    }
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", options);
}
function get_options() {
    var StartTime = $("#tdStartTime").datebox("getValue");
    var EndTime = $("#tdEndTime").datebox("getValue");
    if (StartTime != '' && EndTime != '') {
        if (stringToDate(StartTime).valueOf() > stringToDate(EndTime).valueOf()) {
            show_message('开始日期不能大于结束日期', 'warning');
            return null;
        }
    }
    var projectids = [];
    var companyids = [];
    if (ProjectID > 0) {
        projectids.push(ProjectID);
    }
    if (CompanyID > 0) {
        companyids.push(CompanyID);
    }
    var options = {
        "visit": "loadserviceanalysislist",
        "StartTime": StartTime,
        "EndTime": EndTime,
        "ServiceTypeID": status,
        "ProjectIDs": JSON.stringify(projectids),
        "CompanyIDs": JSON.stringify(companyids)
    };
    return options;
}