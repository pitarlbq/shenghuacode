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
            { field: 'RealName', title: '客服姓名', width: 100, rowspan: 2 },
            { title: '投诉回访信息', width: 100, colspan: 5 },
            { title: '投诉信息', width: 100, colspan: 3 },
            { title: '报事信息', width: 100, colspan: 3 },
            { title: '400工单数', width: 100, colspan: 2 },
        ], [
            //{ field: 'TotalSuggestionCount', title: '投诉工单数量', width: 100 },
            { field: 'TotalCallBackNotHuiFangCount', title: '待回访条数', width: 100 },
            { field: 'TotalCallBackTimeOutCount', title: '回访超时条数', width: 100 },
            { field: 'TotalCallBackTimeOutPercent', title: '回访超时率', width: 100 },
            { field: 'CallBackFromPhonePickUpCount', title: '回访接通数', width: 100 },
            { field: 'CallBackIsOnPercentDesc', title: '回访接通率(%)', width: 100 },
            { field: 'TouSuTotalCount', title: '投诉工单数量', width: 100 },
            { field: 'TouSuCallBackCount', title: '投诉回访数', width: 100 },
            { field: 'TouSuCallBackPercentDesc', title: '投诉回访率', width: 100 },
            { field: 'BaoXiuTotalCount', title: '维修工单数量', width: 100 },
            { field: 'BaoXiuCallBackCount', title: '维修回访数', width: 100 },
            { field: 'BaoXiuCallBackPercentDesc', title: '维修回访率', width: 100 },
            { field: 'TotalCount', title: '工单总数', width: 100 },
            { field: 'TotalAddServiceTimeOutCount', title: '下单超时条数', width: 100 },
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
        //SearchTT()
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
        "visit": "loadcallsummaryanalysis",
        "RoomIDs": JSON.stringify(roomids),
        "ProjectIDs": JSON.stringify(projectids),
        "ALLProjectIDs": JSON.stringify(allprojectids),
        "CompanyIDs": JSON.stringify(companyids),
        "StartTime": StartTime,
        "EndTime": EndTime,
        "AddUserID": $("#tdAddUserName").combobox("getValue"),
    };
    return options;
}