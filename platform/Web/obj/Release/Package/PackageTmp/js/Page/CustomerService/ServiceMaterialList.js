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
        onCheck: onCheck,
        onUncheck: onUncheck,
        striped: true,
        columns: [[
        { field: 'ck', checkbox: true },
        { field: 'ServiceNumber', title: '服务单号', width: 100 },
        { field: 'AddTime', formatter: formatTime, title: '登记时间', width: 100 },
        { field: 'PayStatusDesc', title: '是否有偿', width: 100 },
        { field: 'ProductName', title: '物品名称', width: 100 },
        { field: 'ModelNumber', title: '物品规格', width: 100 },
        { field: 'InTotalCount', title: '数量', width: 100 },
        { field: 'UnitPrice', title: '单价', width: 100 },
        { field: 'InTotalPrice', title: '金额', width: 100 },
        { field: 'HandelFee', title: '维修工费', width: 100 },
        { field: 'TotalFee', title: '收费金额', width: 100 },
        { field: 'BalanceStatusDesc', title: '结算状态', width: 100 }
        ]],
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
        toolbar: '#tb',
        onLoadSuccess: onLoadSuccess
    });
    SearchTT()
}
function SearchTT() {
    var StartTime = $("#tdStartTime").datebox("getValue");
    var EndTime = $("#tdEndTime").datebox("getValue");
    if (StartTime != '' && EndTime != '') {
        if (stringToDate(StartTime).valueOf() > stringToDate(EndTime).valueOf()) {
             show_message('开始日期不能大于结束日期', 'warning');
            return;
        }
    }
    var roomids = [];
    var projectids = []
    try {
        roomids = GetSelectedRooms();
        projectids = GetSelectedProjects();
    } catch (e) {

    }
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadservicemateriallist",
        "RoomIDs": JSON.stringify(roomids),
        "ProjectIDs": JSON.stringify(projectids),
        "BalanceStatus": $("#tdBalanceStatus").combobox("getValue"),
        "StartTime": StartTime,
        "EndTime": EndTime,
        "PayStatus": $("#tdPayStatus").combobox("getValue")
    });
}
function onLoadSuccess(data) {
    MergeCells("tt_table", "ck,ServiceNumber,AddTime,PayStatusDesc,HandelFee,TotalFee,BalanceStatusDesc");
}
function MergeCells(tableID, fldList) {
    var Arr = fldList.split(",");
    var dg = $('#' + tableID);
    var fldName;
    var RowCount = dg.datagrid("getRows").length;
    var span;
    var PerValue = "";
    var CurValue = "";
    var length = Arr.length - 1;
    for (i = length; i >= 0; i--) {
        fldName = Arr[i];
        PerValue = "";
        span = 1;
        for (row = 0; row <= RowCount; row++) {
            if (row == RowCount) {
                CurValue = "";
            }
            else {
                CurValue = dg.datagrid("getRows")[row]["ServiceID"];
            }
            if (PerValue == CurValue) {
                span += 1;
            }
            else {
                var index = row - span;
                dg.datagrid('mergeCells', {
                    index: index,
                    field: fldName,
                    rowspan: span,
                    colspan: null
                });
                span = 1;
                PerValue = CurValue;
            }
        }
    }
}
function onCheck(index, data) {
    var rows = $("#tt_table").datagrid("getRows");
    $.each(rows, function (i, row) {
        if (!isChecked(row)) {
            var rowIndex = $('#tt_table').datagrid('getRowIndex', row);
            if (row.ServiceID == data.ServiceID && rowIndex != index) {
                $('#tt_table').datagrid('selectRow', rowIndex);
            }
        }
    })
}
function isChecked(row) {
    var allRows = $("#tt_table").datagrid('getChecked');
    for (var i = 0; i < allRows.length; i++) {
        if (row.ID == allRows[i].ID) {
            return true;
        }
    }
    return false;
}
function onUncheck(index, data) {
    var rows = $("#tt_table").datagrid("getRows");
    $.each(rows, function (i, row) {
        if (isChecked(row)) {
            var rowIndex = $('#tt_table').datagrid('getRowIndex', row);
            if (row.ServiceID == data.ServiceID && rowIndex != index) {
                $('#tt_table').datagrid('unselectRow', rowIndex);
            }
        }
    })
}
function formatNumber(value, row) {
    return (Number(value) > 0 ? value : "");
}
function doPay() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个任务", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ServiceID);
    })
    top.$.messager.confirm("提示", "是否结算选中的任务", function (r) {
        if (r) {
            var options = { visit: 'completeservice', IDList: JSON.stringify(IDList), BalanceStatus: "balanceyes" };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ServiceHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message("结算成功", "info", function () {
                            $("#tt_table").datagrid("reload");
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
function doComplete() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个任务", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ServiceID);
    })
    top.$.messager.confirm("提示", "是否销单", function (r) {
        if (r) {
            var options = { visit: 'completeservice', IDList: JSON.stringify(IDList), BalanceStatus: "complete" };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ServiceHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message("销单成功", "info", function () {
                            $("#tt_table").datagrid("reload");
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
