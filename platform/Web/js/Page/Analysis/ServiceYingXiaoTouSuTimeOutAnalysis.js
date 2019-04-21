var tt_CanLoad = false, finalColumns = [];
$(function () {
});
function getColumns() {
    finalColumns = [];
    var columns = [];
    var CompanyID = $('#tdCompanyID').combobox('getValue') || -1;
    var ProjectIDList = getTopProjectIDList();
    if (CompanyID < 0 && ProjectIDList.length <= 0) {
        columns.push({ field: 'CompanyName', title: '公司', width: 100 });
        columns.push({ field: 'ProjectName', title: '项目', width: 100 });
    }
    if (CompanyID >= 0) {
        columns.push({ field: 'CompanyName', title: '公司', width: 100 });
    }
    if (ProjectIDList.length > 0) {
        columns.push({ field: 'ProjectName', title: '项目', width: 100 });
    }
    columns.push({ field: 'TotalCount', title: '总工单数', width: 100 });
    columns.push({ field: 'AverageResponseTotalTakeHour', formatter: formatXiaDan, title: '回复平均处理时效', width: 100 });
    columns.push({ field: 'AveragePaiDanTotalTakeHour', formatter: formatPaiDan, title: '派单平均处理时效', width: 100 });
    columns.push({ field: 'AverageChuLiTotalTakeHour', formatter: formatChuLi, title: '处理平均处理时效', width: 100 });
    columns.push({ field: 'AverageBanJieTotalTakeHour', formatter: formatBanJie, title: '办结平均处理时效', width: 100 });
    columns.push({ field: 'AverageHuiFangTotalTakeHour', formatter: formatHuiFang, title: '回访平均处理时效', width: 100 });
    finalColumns.push(columns);
}
function formatXiaDan(value, row) {
    return '<a href="javascript:doViewList(1,' + row.CompanyID + ',' + row.ProjectID + ')">' + value + '</a>';
}
function formatPaiDan(value, row) {
    return '<a href="javascript:doViewList(2,' + row.CompanyID + ',' + row.ProjectID + ')">' + value + '</a>';
}
function formatChuLi(value, row) {
    return '<a href="javascript:doViewList(3,' + row.CompanyID + ',' + row.ProjectID + ')">' + value + '</a>';
}
function formatBanJie(value, row) {
    return '<a href="javascript:doViewList(4,' + row.CompanyID + ',' + row.ProjectID + ')">' + value + '</a>';
}
function formatHuiFang(value, row) {
    return '<a href="javascript:doViewList(5,' + row.CompanyID + ',' + row.ProjectID + ')">' + value + '</a>';
}
function doViewList(typeid, CompanyID, ProjectID) {
    var StartTime = $("#tdStartTime").datebox("getValue");
    var EndTime = $("#tdEndTime").datebox("getValue");
    var iframe = "../Analysis/ServiceChuLiList.aspx?typeid=" + typeid + "&status=1&CompanyID=" + CompanyID + "&ProjectID=" + ProjectID + "&start=" + StartTime + "&end=" + EndTime;
    do_open_dialog('处理时效列表', iframe);
}
function getTopProjectIDList() {
    var CompanyID = $('#tdCompanyID').combobox('getValue') || -1;
    var topProjectID = 0;
    var ProjectIDList = [];
    if (CompanyID == 0) {
        topProjectID = $('#tdProjectID').combobox('getValue') || -1;
        if (topProjectID == 0) {
            ProjectIDList.push(topProjectID);
        }
    } else if (CompanyID > 0) {
        ProjectIDList = $('#tdProjectID').combobox('getValues');
    }
    return ProjectIDList;
}
function loadTT() {
    getColumns();
    tt_CanLoad = false;
    $('#tt_table').datagrid({
        url: '../Handler/AnalysisHandler.ashx',
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
    var roomids = [];
    var projectids = [];
    var allprojectids = [];
    var companyids = [];
    try {
        roomids = GetSelectedRooms();
        projectids = GetSelectedProjects();
        allprojectids = GetALLSelectedProjects();
        companyids = GetSelectedCompanyIDs();
    } catch (e) {
    }
    var CompanyID = $('#tdCompanyID').combobox('getValue') || -1;
    if (CompanyID > 0) {
        companyids.push(Number(CompanyID));
    }
    var ProjectIDList = getTopProjectIDList();
    $.each(ProjectIDList, function (index, ProjectID) {
        if (ProjectID > 0) {
            projectids.push(Number(ProjectID));
        }
    })
    var options = {
        "visit": "loadjiediantimeoutanalysis",
        "RoomIDs": JSON.stringify(roomids),
        "ProjectIDs": JSON.stringify(projectids),
        "ALLProjectIDs": JSON.stringify(allprojectids),
        "CompanyIDs": JSON.stringify(companyids),
        "StartTime": StartTime,
        "EndTime": EndTime,
        "TopProjectIDs": JSON.stringify(ProjectIDList),
        "TopCompanyID": CompanyID,
        "ServiceTypeID": 1
    };
    return options;
}