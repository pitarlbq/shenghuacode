var tt_CanLoad = false;
$(function () {
    loadTT();
});
function loadTT() {
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
        columns: [[
            { title: '工作时间周一到周五（9:00-18.00）', width: 100, colspan: 3 },
            { title: '非工作时间（含节假日）', width: 100, colspan: 4 },
            { title: '全部时间', width: 100, colspan: 2 },
        ], [
            { field: 'WorkCallTotalCount', title: '来电总数', width: 100 },
            { field: 'WorkCallNotOnCount', title: '未接来电总数', width: 100 },
            { field: 'WorkCallOnPercent', title: '接通率(%)', width: 100 },
            { field: 'NotWorkCallTotalCount', title: '来电总数', width: 100 },
            { field: 'NotWorkCallNotOnCount', title: '未接来电总数', width: 100 },
            { field: 'NotWorkCallNotPickUpBackCount', title: '未接来电回复数', width: 100 },
            { field: 'NotWorkCallNotPickUpBackPercent', title: '未接来电回复率(%)', width: 100 },
            { field: 'ALLWorkCallOnPercent', title: '接通率(%)', width: 100 },
            { field: 'ALLWorkCallNotPickUpBackPercent', title: '未接来电回复率(%)', width: 100 }
        ]],
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
    var options = {
        "visit": "loadcalltotalanalysis",
        "RoomIDs": JSON.stringify(roomids),
        "ProjectIDs": JSON.stringify(projectids),
        "ALLProjectIDs": JSON.stringify(allprojectids),
        "CompanyIDs": JSON.stringify(companyids),
        "StartTime": StartTime,
        "EndTime": EndTime
    };
    return options;
}