var tt_CanLoad = false, finalcolumns = [];
$(function () {
    getColumns();
    loadTT();
});
function getColumns() {
    var columns = [
        { field: 'ck', checkbox: true },
        { field: 'CallTime', formatter: formatDateTime, title: '拨打时间', width: 150 },
        { field: 'PickUpTime', formatter: formatDateTime, title: '接听时间', width: 150 },
        { field: 'HangUpTime', formatter: formatDateTime, title: '挂断时间', width: 150 },
        { field: 'PhoneTypeDesc', title: '来电方式', width: 100 },
        { field: 'PhoneNumber', title: '电话号码', width: 100 },
        { field: 'CallbackCount', title: '回拨次数', width: 100 },
        { field: 'Operation', formatter: formatOperation, title: '操作', width: 300 },
    ];
    if (ServiceID == 0) {
        columns = [
       { field: 'ck', checkbox: true },
       { field: 'IsPickUpDesc', title: '是否接听', width: 120 },
       { field: 'CallTime', formatter: formatDateTime, title: '拨打时间', width: 150 },
       { field: 'FinalPickUpTime', formatter: formatDateTime, title: '接听时间', width: 150 },
       { field: 'HangUpTime', formatter: formatDateTime, title: '挂断时间', width: 150 },
       { field: 'PhoneTypeDesc', title: '来电方式', width: 100 },
       { field: 'PhoneNumber', title: '电话号码', width: 100 },
        { field: 'CallbackCount', title: '回拨次数', width: 100 },
       { field: 'Operation', formatter: formatOperation, title: '操作', width: 300 },
        ];
    }
    finalcolumns.push(columns)
}
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
        columns: finalcolumns,
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
        "visit": "loadservicerecordgrid",
        "StartTime": $("#tdStartTime").datetimebox("getValue"),
        "EndTime": $("#tdEndTime").datetimebox("getValue"),
        "ServiceID": ServiceID,
        "PhoneType": $("#tdPhoneType").combobox("getValue"),
    };
    return options;
}
function formatOperation(value, row) {
    if (value == '') {
        return '';
    }
    var html = '<a href="javascript:do_listen(\'' + row.ID + '\')">试听</a>';
    html += '<a style="margin-left:10px;" href="javascript:do_callback(\'' + row.PhoneNumber + '\',' + row.ServiceID + ',' + row.ID + ')">回拨并创建工单</a>';
    return html;
}
function do_listen(ID) {
    var width = 500;
    var height = 300;
    var frame = '<iframe id="recordFrame" name="recordFrame" scrolling="auto" frameborder="0"  src="../CustomerService/ServicePhoneListen.aspx?ID=' + ID + '" style="width:100%;height:99%;min-height:' + (height - 40) + 'px;border:0;"></iframe>'
    $("<div id='winListen'></div>").appendTo("body").window({
        title: '录音试听',
        width: width,
        height: height,
        modal: true,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        content: frame,
        onClose: function () {
            $('#winListen').remove();
        }
    });
}
function do_callback(phoneNumber, serviceID, phoneRecordID) {
    top.dialPhone(phoneNumber, serviceID, phoneRecordID)
    top.getDataByPhoneNumber(phoneNumber);
}
