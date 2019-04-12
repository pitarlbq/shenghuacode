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
        fitColumns: true,
        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: true,
        striped: true,
        columns: [[
            { field: 'ck', checkbox: true },
            { field: 'ResponseTime', formatter: formatDateTime, title: '回复时间', width: 150 },
            { field: 'ResponseRemark', title: '回复情况', width: 120 },
            { field: 'CheckTime', formatter: formatDateTime, title: '核查时间', width: 150 },
            { field: 'CheckRemark', title: '核查情况', width: 120 },
            { field: 'ChuliDate', formatter: formatDateTime, title: '处理时间', width: 150 },
            { field: 'ChuliNote', title: '处理情况', width: 200 },
            { field: 'ChuLiHandelFee', formatter: formatPrice, title: '处理费用', width: 100 },
            { field: 'RepartPartName', title: '维修部位', width: 100 },
            { field: 'File', formatter: formatFile, title: '附件', width: 100 },
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
    SearchTT()
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
        "visit": "loadserviceprocesslist",
        "Keywords": $("#tdKeywords").searchbox("getValue"),
        "ServiceID": ServiceID
    };
    return options;
}
function formatFile(value, row) {
    if (row.FileCount <= 0) {
        return '';
    }
    return '<a href="javascript:do_view_file(' + row.ID + ')">查看附件</a>'
}
function do_view_file(ID) {
    var iframe = "../CustomerService/ServiceProcessFileView.aspx?ID=" + ID;
    parent.do_open_dialog('查看附件', iframe);
}
