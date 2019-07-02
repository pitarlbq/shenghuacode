var tt_CanLoad = false;
$(function () {
    loadTT();
});
function loadTT() {
    tt_CanLoad = false;
    //加载
    $('#tt_table').datagrid({
        url: '../Handler/ServiceHandler.ashx',
        loadMsg: '正在加载',
        border: false,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: true,
        fitColumns: false,
        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: true,
        striped: true,
        columns: [[
            { field: 'CompanyName', title: '公司', width: 100 },
            { field: 'FinalProjectName', title: '项目', width: 100 },
            { field: 'AddCustomerName', title: '姓名', width: 100 },
            { field: 'AddCallPhone', title: '电话', width: 100 },
            { field: 'CategoryPartA', title: '工单类型', width: 100 },
            { field: 'ServiceContent', title: '工单内容', width: 300 },
            { field: 'ServiceStatusDesc', title: '状态', width: 100 },
            { field: 'AddTime', formatter: formatDateTime, title: '登记日期', width: 120 },
            { field: 'BanJieTime', formatter: formatDateTime, title: '办结日期', width: 120 },
            { field: 'ChuliNote', title: '处理结果', width: 100, width: 300 },
            { field: 'HuiFangNote', title: '回访结果', width: 100, width: 300 },
            { field: 'TimeOutDesc', formatter: formatTimeout, title: '是否超时', width: 100 },
            { field: 'FinalBanJieChaoShiTakeHour', title: '办结超时时间', width: 100 },
            { field: 'TotalChaoShiTakeHour', title: '总体超时时间', width: 100 },
            { field: 'ChaoShiStatusNames', title: '超时节点', width: 100 },
            { field: 'ServiceFromDesc', title: '投诉来源', width: 100 },
        ]],
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        showFooter: true,
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
    var CompanyID = $('#tdCompanyID').combobox('getValue');
    if (CompanyID > 0) {
        companyids.push(Number(CompanyID));
    }
    var ProjectIDList = $('#tdProjectID').combobox('getValues');
    $.each(ProjectIDList, function (index, ProjectID) {
        projectids.push(Number(ProjectID));
    })
    var options = {
        "visit": "loadservicelist",
        "RoomIDs": JSON.stringify(roomids),
        "ProjectIDs": JSON.stringify(projectids),
        "ALLProjectIDs": JSON.stringify(allprojectids),
        "CompanyIDs": JSON.stringify(companyids),
        "StartTime": StartTime,
        "EndTime": EndTime,
        "Keywords": $("#tdKeywords").searchbox("getValue"),
        "ServiceType": 0,
        "ColumnServiceStatus": ColumnServiceStatus,
        "ColumnServiceType": ColumnServiceType,
        "ServiceType1ID": $('#tdServiceTypeName1').combobox('getValue'),
        "ServiceType2ID": $('#tdServiceTypeName2').combobox('getValue'),
        "ServiceType3ID": $('#tdServiceTypeName3').combobox('getValue'),
        "ServiceStatus": 250,
        "CompleteStartTime": $("#tdCompleteStartTime").datebox("getValue"),
        "CompleteEndTime": $("#tdCompleteEndTime").datebox("getValue"),
        "ProcessKewords": $("#tdProcessKewords").searchbox("getValue"),
        "CallBackKeywords": $("#tdCallBackKeywords").searchbox("getValue"),
    };
    options.url = '../Handler/ServiceHandler.ashx';
    return options;
}
function formatTimeout(value, row) {
    if (row.BanJieTimeOutStatus == 2) {
        return '<img style="height:20px;" src="../styles/images/buttons/statuschaoshi.png" />';
    }
    return '<img style="height:20px;" src="../styles/images/buttons/statusnormal.png" />';
}
//列设置
function openTableSetUp() {
    var iframe = "../SysSeting/TableSetUp.aspx?PageCode=customerservice&ColumnServiceStatus=" + ColumnServiceStatus + "&ColumnServiceType=" + ColumnServiceType;
    parent.do_open_dialog('任务列表设置', iframe);
}