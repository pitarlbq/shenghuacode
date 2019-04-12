var tt_CanLoad = false;
$(function () {
    loadTT();
});
function loadTT() {
    $('#tt_table').datagrid({
        url: '../Handler/UserHandler.ashx',
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
        showFooter: true,
        columns: [[
        { field: 'ck', checkbox: true },
        { field: 'CompanyName', title: '所属公司', width: 100 },
        { field: 'DepartmentName', title: '所属部门', width: 100 },
        { field: 'RealName', title: '人员名称', width: 100 },
        { field: 'PositionName', title: '岗位信息', width: 100 },
        { field: 'PhoneNumber', title: '电话', width: 100 },
        { field: 'LoginName', title: '登录名', width: 60 },
        { field: 'IsLockedDesc', title: '是否有效', width: 100 },
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
        onLoadSuccess: function () {
        },
        toolbar: '#tb'
    });
    SearchTT();
}
function SearchTT() {
    var OrgID = GetSelectRadio();
    var CompanyID = GetSelectCompanyID();
    tt_CanLoad = true;
    var keywords = $('#tdKeywords').searchbox('getValue');
    $("#tt_table").datagrid("load", {
        visit: "loaduserlist",
        keywords: keywords,
        DepartmentID: OrgID,
        DepartmentCompanyID: CompanyID,
        IsAPPUser: true
    });
}
function do_add() {
    var OrgID = GetSelectRadio();
    if (OrgID <= 0) {
        show_message('请选择部门，操作取消', 'warning');
        return;
    }
    var iframe = "../SysSeting/UserStaffEdit.aspx?OrgID=" + OrgID;
    do_open_dialog('新增人员', iframe);
}
function do_edit() {
    var row = $('#tt_table').datagrid('getSelected');
    if (row == null) {
        show_message('请选择一条数据，操作取消', 'warning');
        return;
    }
    var iframe = "../SysSeting/UserStaffEdit.aspx?UserID=" + row.UserID;
    do_open_dialog('修改人员', iframe);
}
function do_remove() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个用户进行此操作", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.UserID);
    })
    top.$.messager.confirm("提示", "是否删除选中的用户", function (r) {
        if (r) {
            var options = { visit: 'removeuser', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/UserHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('删除成功', 'success', function () {
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
function chooseRow() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个员工进行此操作", "warning");
        return;
    }
    if (rows.length > 1) {
        show_message("请选择单行进行此操作", "warning");
        return;
    }
    var UserIDList = [];
    var UserNames = '';
    $.each(rows, function (index, row) {
        UserIDList.push(row.UserID);
        if (index > 0) {
            UserNames += ',';
        }
        UserNames += row.FinalRealName;
    })
    try {
        parent.ChosenStaffUserIDs = JSON.stringify(UserIDList);
        parent.ChosenStaffUserName = UserNames;
    } catch (e) {
    }
    do_close();
}