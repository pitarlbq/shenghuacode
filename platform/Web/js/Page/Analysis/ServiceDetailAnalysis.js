var tt_CanLoad = false;
$(function () {
    loadTT();
});
function loadTT() {
    tt_CanLoad = false;
    var options = { visit: 'loadtablecolumn', pagecode: 'customerservice', ColumnServiceStatus: ColumnServiceStatus, ColumnServiceType: ColumnServiceType };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/RoomResourceHandler.ashx',
        data: options,
        success: function (message) {
            if (message.status) {
                var finalcolumn = [];
                finalcolumn = eval(message.columns);
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
                    columns: finalcolumn,
                    pageSize: global_variable.pageSize,
                    pageList: global_variable.pageList,
                    onDblClickRow: onDblClickRow,
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
                return;
            }
            show_message('系统错误', 'error');
        }
    });
}
function onDblClickRow(index, row) {
    var iframe = "../CustomerService/ServiceDetailTab.aspx?op=view&ID=" + row.ID;
    parent.do_open_dialog('任务详情', iframe);
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
        "CloseType": $('#tdCloseType').combobox('getValue'),
        "Keywords": $("#tdKeywords").searchbox("getValue"),
        "isServiceAnalysis": true,
        "ServiceStatus": -1,
        "ServiceType1ID": $('#tdServiceTypeName1').combobox('getValue'),
        "ServiceType2ID": $('#tdServiceTypeName2').combobox('getValue'),
        "ServiceType3ID": $('#tdServiceTypeName3').combobox('getValue'),
        "TimeOutType": $('#tdTimeOutType').combobox('getValue'),
        "ColumnServiceStatus": ColumnServiceStatus,
        "ColumnServiceType": ColumnServiceType,
        "IsImportantTouSu": $('#tdIsImportantTouSu').combobox('getValue')
    };
    options.url = '../Handler/ServiceHandler.ashx';
    return options;
}
function formatNumber(value, row) {
    return (Number(value) > 0 ? value : "");
}
function formatRepairImg(value, row) {
    return '';
}
function formatTimeout(value, row) {
    if (row.TimeOutStatus == 2) {
        return '<img style="height:20px;" src="../styles/images/buttons/statuschaoshi.png" />';
    }
    return '<img style="height:20px;" src="../styles/images/buttons/statusnormal.png" />';
}
function formatProcess(value, row) {
    if (row.ProcessStatus == 2) {
        return '<img style="height:20px;" src="../styles/images/buttons/statuschuli.png" />';
    }
    if (row.ProcessStatus == 3) {
        return '<img style="height:20px;" src="../styles/images/buttons/statusbanjie.png" />';
    }
    if (row.ProcessStatus == 4) {
        return '<img style="height:20px;" src="../styles/images/buttons/statushuifang.png" />';
    }
    return '<img style="height:20px;" src="../styles/images/buttons/statusjiedan.png" />';
}
function formatClose(value, row) {
    if (row.IsClosed) {
        return '<img style="height:20px;" src="../styles/images/buttons/statussuoding.png" />';
    }
    return '<img style="height:20px;" src="../styles/images/buttons/statuskaisuo.png" />';
}
//列设置
function openTableSetUp() {
    var iframe = "../SysSeting/TableSetUp.aspx?PageCode=customerservice&ColumnServiceStatus=" + ColumnServiceStatus + "&ColumnServiceType=" + ColumnServiceType;
    parent.do_open_dialog('任务列表设置', iframe);
}