var tt_CanLoad = false;
$(function () {
    setTimeout(function () {
        loadtt();
    }, 500);
});
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/UserHandler.ashx',
        loadMsg: '正在加载',
        border: true,
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
        columns: [[
        { field: 'OperationTime', formatter: formatDateTime, title: '操作时间', width: 100 },
        { field: 'OperationMan', title: '操作人', width: 100 },
        { field: 'IPAddress', title: '操作人IP', width: 100 },
        { field: 'OperationKeyDesc', title: '操作类型', width: 100 },
        { field: 'OperationContent', title: '操作内容', width: 300 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadoperationloggrid",
        "keywords": keywords,
        "StartTime": $('#tdStartTime').datetimebox('getValue'),
        "EndTime": $('#tdEndTime').datetimebox('getValue'),
        "OperationKey": $('#tdOperationKey').combobox('getValue'),
    });
}