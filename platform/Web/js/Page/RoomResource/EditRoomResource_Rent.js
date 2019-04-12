var home_CanLoad = false;
$(function () {
    loadHome();
});
function loadHome() {
    $('#home_table').datagrid({
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
        onDblClickRow: onDblClickHomeRow,
        striped: true,
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        onBeforeLoad: function (data) {
            if (!home_CanLoad) {
                $('#home_table').datagrid("loadData", {
                    total: 0,
                    rows: []
                });
            }
            return home_CanLoad;
        },
        onLoadError: function (data) {
            //alert("有错");
            $('#home_table').datagrid("loadData", {
                total: 0,
                rows: []
            });
        },
        toolbar: '#home_tb'
    });
    SearchHome()
}
function onDblClickHomeRow(index, row) {
    edithomebyid(row.ID);
}
function SearchHome() {
    home_CanLoad = true;
    $("#home_table").datagrid("load", {
        "visit": "loadlrelatefamily",
        "RoomID": RoomID,
        "RelationType": "rentfamily"
    });
}
function edithomebyid(id) {
    var width = $(window).width();
    var height = $(window).height();
    var iframe = "../RoomResource/EditRelateFamily.aspx?ID=" + id + "&RelationType=rentfamily";
    do_open_dialog('修改相关成员', iframe);
}
function edithome() {
    var rows = $('#home_table').datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请选择一个成员", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("最多只能选择一个成员进行编辑", "info");
        return;
    }
    edithomebyid(rows[0].ID);
}
function addhome() {
    var width = $(window).width();
    var height = $(window).height();
    var iframe = "../RoomResource/EditRelateFamily.aspx?RoomID=" + RoomID + "&RelationType=rentfamily";
    do_open_dialog('新增相关成员', iframe);
}
function deletehome(type) {
    var rows = $('#home_table').datagrid("getSelections");
    var IDList = [];
    if (rows.length == 0) {
        show_message("请选择一个资源", "info");
        return;
    }
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    var options = { visit: 'checkrelation_contractstatus', IDList: JSON.stringify(IDList) };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/RoomResourceHandler.ashx',
        data: options,
        success: function (data) {
            if (data.status) {
                if (data.hascontract) {
                    show_message("禁止删除合同关联联系人", "info");
                    return;
                }
                top.$.messager.confirm("提示", "是否删除选中的联系人?", function (r) {
                    if (r) {
                        options = { visit: 'deletefamily', IDList: JSON.stringify(IDList) };
                        $.ajax({
                            type: 'POST',
                            dataType: 'json',
                            url: '../Handler/RoomResourceHandler.ashx',
                            data: options,
                            success: function (message) {
                                if (message.status) {
                                    show_message('删除成功', 'success');
                                    $('#home_table').datagrid("reload");
                                }
                                else {
                                    show_message('系统错误', 'error');
                                }
                            }
                        });
                    }
                })
            }
            else {
                show_message('系统错误', 'error');
            }
        }
    });

}
function editapp() {
    var rows = $("#home_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个用户进行此操作", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("请选择单行进行此操作", "info");
        return;
    }
    var iframe = "../RoomResource/EditAPPAccount.aspx?RelationID=" + rows[0].ID;
    do_open_dialog('修改APP帐号', iframe);
}
