var tt_CanLoad = false;
$(function () {
    get_projectlist();
    loadTT();
});
function get_projectlist() {
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/RoomResourceHandler.ashx',
        data: { visit: 'getthirdprojectlist' },
        success: function (data) {
            $('#tdProjectName').combobox({
                valueField: 'ID',
                textField: 'Name',
                data: data.list,
                editable: false
            })
        }
    });
}
function loadTT() {
    $('#tt_table').datagrid({
        url: '../Handler/RoomResourceHandler.ashx',
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
            { field: 'ProjectName', title: '项目名称', width: 100 },
            { field: 'RoomName', title: '资源编号', width: 100 },
            { field: 'CustomerName', title: '姓名', width: 100 },
            { field: 'PhoneNumber', title: '手机号码', width: 100 },
            { field: 'SignDate', formatter: formatDateTime, title: '签约日期', width: 100 },
            { field: 'LastSendTime', formatter: formatDateTime, title: '最近发送时间', width: 100 },
            { field: 'SendStatusDesc', title: '发送状态', width: 100 },
            { field: 'Operation', formatter: formatOperation, title: '操作', width: 100 },
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
        toolbar: '#tb'
    });
    SearchTT();
}
function formatOperation(value, row) {
    var html = '<a style="margin-right: 10px;" href="javascript:do_edit(' + row.ID + ',\'view\',\'查看\')">查看</>';
    html += '<a style="margin-right: 10px;" href="javascript:do_edit(' + row.ID + ',\'edit\',\'修改\')">修改</>';
    html += '<a href="javascript:do_remove(' + row.ID + ')">删除</>';
    return html;
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
        "visit": "getthridcustomergrid",
        "Keywords": $('#tdKeyword').searchbox("getValue"),
        "StartTime": $('#tdStartTime').datebox("getValue"),
        "EndTime": $('#tdEndTime').datebox("getValue"),
        "SendStatus": $('#tdSendStatus').combobox("getValue"),
        "ProjectName": $('#tdProjectName').combobox("getValue"),
    };
    return options;
}
function do_export(istemplate) {
    var options = get_options();
    if (options == null) {
        return;
    }
    options.canexport = true;
    options.page = 1;
    options.rows = 10;
    options.istemplate = istemplate;
    MaskUtil.mask('body', '导出中');
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/RoomResourceHandler.ashx',
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
function onDblClickRow(index, row) {
    do_edit(row.ID, 'view', '查看')
}
function do_add() {
    do_edit(0, 'edit', '新增');
}
function do_edit(ID, op, title) {
    do_open_dialog(title, '../InitialSetup/ThridCustomerEdit.aspx?ID=' + ID + '&op=' + op);
}
function do_import() {
    do_open_dialog('导入', '../InitialSetup/ThirdCustomerImport.aspx');
}
function do_send() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请选择客户', 'warning');
        return;
    }
    do_open_dialog('发送', '../InitialSetup/SmsSendMessage.aspx');
}
function do_remove(ID) {
    top.$.messager.confirm("提示", "确认关联选中的房源", function (r) {
        if (r) {
            var options = { visit: 'doremovethridcustomer', ID: ID };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/RoomResourceHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status == 1) {
                        show_message('操作', 'success');
                        $("#tt_table").datagrid("reload");
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
    })
}

