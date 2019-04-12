var tt_CanLoad = false;
$(function () {
    loadTT();
});
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
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        //onClickCell: onClickCell,
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
        toolbar: '#tt_tb'
    });
    SearchTT();
}
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadlrelateroomresource",
        "RoomID": RoomID,
        "loadIn": true
    });
}

function addresource() {
    var IDList = top.GetSelectedRooms();
    if (IDList.length == 0) {
        show_message("请选择一个资源", "info");
        return;
    }
    IDList.push(RoomID);
    top.$.messager.confirm("提示", "确认关联选中的房源", function (r) {
        if (r) {
            var options = { visit: 'connectproject', RoomIDs: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ProjectHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status == 1) {
                        show_message('添加成功', 'success');
                        $("#tt_table").datagrid("reload");
                    }
                    else if (message.status == 2) {
                        show_message("选中房源已关联", "info");
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
    })
}
function deleteresource() {
    var rows = $('#tt_table').datagrid("getSelections");
    var IDList = [];
    if (rows.length == 0) {
        show_message("请选择一个资源", "info");
        return;
    }
    $.each(rows, function (index, row) {
        IDList.push(row.RoomID);
    })
    top.$.messager.confirm("提示", "确认删除选中的关联房源", function (r) {
        if (r) {
            var options = { visit: 'disconnectproject', RoomID: RoomID, IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ProjectHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status == 1) {
                        show_message('删除成功', 'success');
                        $('#tt_table').datagrid("reload");
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
    });
}
function formatArea(value, row) {
    if (Number(value) <= 0) {
        return 0;
    }
    return value;
}
