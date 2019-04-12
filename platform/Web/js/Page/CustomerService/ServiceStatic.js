var tt_CanLoad = false;
$(function () {
    getRadioValue();
    loadTT();
});
function getRadioValue() {
    var checkValue = "";
    var chkRadio = document.getElementsByName("tabletype");
    $.each(chkRadio, function (index, item) {
        if ($(item).prop('checked')) {
            checkValue = $(item).val();
            return false;
        }
    })
    hdServiceType.val(checkValue);
    return checkValue;
}
function loadTT() {
    tt_CanLoad = false;
    var options = { visit: 'loadstaticcolumn', ServiceType: getRadioValue() };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ServiceHandler.ashx',
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
                    }
                });
                SearchTT();
                return;
            }
            show_message('系统错误', 'error');
        }
    });
}

function SearchTT() {
    var StartTime= $("#tdStartTime").datebox("getValue");
    var EndTime= $("#tdEndTime").datebox("getValue");
    if (StartTime != '' && EndTime != '') {
        if (stringToDate(StartTime).valueOf() > stringToDate(EndTime).valueOf()) {
             show_message('开始日期不能大于结束日期', 'warning');
            return;
        }
    }
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadstaticlist",
        "StartTime": StartTime,
        "EndTime": EndTime,
        "ServiceType": getRadioValue()
    });
}
function formatCount(value, row) {
    if (value == "" || value == null) {
        return 0;
    }
    return value;
}
