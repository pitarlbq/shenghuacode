var tt_CanLoad = false;
$(function () {
    loadTT();
    $('.labelyear label').bind('click', function () {
        $('.labelyear label').removeClass('active');
        $(this).addClass('active');
        var dataValue = $(this).attr('data-value');
        getDateValue(dataValue);
    })
    getDateValue(1);
});
function getDateValue(dataValue) {
    var startDate = '', endDate = '';
    if (dataValue == 1) {
        var currentDate = dateRangeUtil.getCurrentDate();
        startDate = dateRangeUtil.getDateString(currentDate);
        endDate = startDate;
    }
    if (dataValue == 2) {
        var currentMonth = dateRangeUtil.getCurrentMonth();
        startDate = dateRangeUtil.getDateString(currentMonth[0]);
        endDate = dateRangeUtil.getDateString(currentMonth[1]);
    }
    if (dataValue == 3) {
        var currentYear = dateRangeUtil.getCurrentYear();
        startDate = dateRangeUtil.getDateString(currentYear[0]);
        endDate = dateRangeUtil.getDateString(currentYear[1]);
    }
    $('#tdStartTime').datebox('setValue', startDate);
    $('#tdEndTime').datebox('setValue', endDate);
    SearchTT();
}
function loadTT() {
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
        columns: [[
            { field: 'ck', checkbox: true },
            { field: 'DayTitle', formatter: formatDayTitle, title: '统计时间', width: 100 },
            { field: 'BillNumber', title: '短信计费条数', width: 100 },
            { field: 'RequestNumber', title: '短信提交量', width: 100 },
            { field: 'SuccessNumber', title: '短信提交成功量', width: 100 },
        ]],
        onLoadSuccess: function (data) {
            if (data.countitem) {
                $('#tdTotalSmsCount').text(data.countitem.TotalSmsCount + '条')
                $('#tdBillNumber').text(data.countitem.BillNumber + '条')
                $('#tdRestNumber').text(data.countitem.RestNumber + '条')
            }
        },
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
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
    var options = {
        "visit": "getsmssendstatusanalysis",
        "StartTime": $('#tdStartTime').datebox('getValue'),
        "EndTime": $('#tdEndTime').datebox('getValue'),
    };
    return options;
}
function formatDayTitle(value, row) {
    if (value) {
        value = value + '';
        return value.substr(0, 4) + '-' + value.substr(4, 2) + '-' + value.substr(6, 2);
    }
    return '';
}
function do_export() {
    var options = get_options();
    if (options == null) {
        return;
    }
    options.canexport = true;
    options.page = 1;
    options.rows = 10;
    MaskUtil.mask('body', '导出中');
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/AnalysisHandler.ashx',
        data: options,
        success: function (data) {
            MaskUtil.unmask();
            if (data.downloadurl) {
                window.location.href = data.downloadurl;
                return;
            }
            if (data.error) {
                show_message(data.error, 'warning');
                return;
            }
            show_message('系统异常', 'error');
        }
    });
}
function setCountValue() {

}
