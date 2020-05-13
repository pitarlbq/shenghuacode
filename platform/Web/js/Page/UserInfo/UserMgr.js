var tt_CanLoad = false, columns = [];
$(function () {
    $('#userTree').tree({
        url: "../Handler/AuthMgrHandler.ashx?visit=companytree",
        lines: true,
        checkbox: false,
        fit: true,
        fitColumns: false,
        onClick: onClick,
        animate: true,
        cascadeCheck: true,
        onLoadSuccess: function (node, data) {
            if (data.status == false) {
                alert("该用户权限不足！");
            }
            init();
        }
    });
    getColumns();
    setTimeout(function () {
        loadtt();
    }, 500);
});
function getColumns() {
    columns = [];
    var columns1 = [];
    columns1.push({ field: 'ck', checkbox: true });
    columns1.push({ field: 'FinalHeadImg', formatter: formatHeadImg, title: '头像', width: 100 });
    columns1.push({ field: 'RealName', title: '用户名', width: 100 });
    columns1.push({ field: 'PhoneNumber', title: '电话', width: 100 });
    columns1.push({ field: 'Gender', title: '性别', width: 100 });
    columns1.push({ field: 'LoginName', title: '登录名', width: 60 });
    columns1.push({ field: 'IsLockedDesc', title: '是否有效', width: 100 });
    //columns1.push({ field: 'ActiveTime', formatter: formatActiveTime, title: '生效日期', width: 150 });
    //columns1.push({ field: 'LockTime', formatter: formatLockTime, title: '失效日期', width: 150 });
    columns1.push({ field: 'UserTypeDesc', title: '用户性质', width: 150 });
    columns1.push({ field: 'PositionName', title: '岗位', width: 100 });
    columns1.push({ field: 'DepartmentName', title: '部门', width: 100 });
    columns1.push({ field: 'Education', title: '学历', width: 100 });
    columns1.push();
    columns.push(columns1);
}
function init() {
    //去掉结点前面的文件及文件夹小图标
    $(".tree-icon,.tree-file").removeClass("tree-icon tree-file");
    $(".tree-icon,.tree-folder").removeClass("tree-icon tree-folder tree-folder-open tree-folder-closed");
}
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/UserHandler.ashx',
        loadMsg: '正在加载',
        border: true,
        remoteSort: false,
        pagination: true,
        rownumbers: false,
        fit: true,
        fitColumns: true,
        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: true,
        onDblClickRow: onDblClickRowTT,
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
        columns: columns,
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function onClick() {
    SearchTT();
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    var Id = 0;
    try {
        var nodes = $('#userTree').tree('getSelected');
        if (nodes != null) {
            Id = nodes.id;
        }
    } catch (e) {

    }
    var UserType = $("#tdUserType").combobox("getValue");
    var DepartmentID = $("#tdDepartment").combobox("getValue");
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loaduserlist",
        "keywords": keywords,
        "CompanyID": Id,
        "UserType": UserType,
        "DepartmentID": DepartmentID,
        "UserType": "SystemUser"
    });
}
function onDblClickRowTT(index, row) {
    EditUserByRow(row)
}
function formatFixedPoint(value, row) {
    if (value <= 0) {
        return 0;
    }
    return value;
}
function formatHeadImg(value, row) {
    if (row.HeadImg == '') {
        return '';
    }
    return '<img src="' + row.HeadImg + '" style="width:50px; height:50px;border-radius: 50%;" />';
}
function formatMyCoupons(value, row) {
    if (row.Type == 'SystemUser') {
        return '';
    }
    return '<a href="javascript:do_view_coupon(' + row.UserID + ')">查看</a>'
}
function do_view_coupon(UserID) {
    var iframe = "../APPSetup/UserCouponMgr.aspx?UserID=" + UserID;
    do_open_dialog('我的福顺券', iframe);
}

function formatActiveTime(value, row) {
    if (row.IsLocked) {
        return "--";
    }
    if (value == undefined || value == null || value == '0001-01-01T00:00:00.0000000' || value == '0001-01-01T00:00:00' || value == '1900-01-01T00:00:00.0000000' || value == '1900-01-01T00:00:00') {
        return "--";
    }
    return value.substring(0, 16).split("T")[0];
}
function formatLockTime(value, row) {
    if (!row.IsLocked) {
        return "--";
    }
    if (value == undefined || value == null || value == '0001-01-01T00:00:00.0000000' || value == '0001-01-01T00:00:00' || value == '1900-01-01T00:00:00.0000000' || value == '1900-01-01T00:00:00') {
        return "--";
    }
    return value.substring(0, 16).split("T")[0];
}
function addUser() {
    var iframe = "../UserInfo/EditUser.aspx";
    do_open_dialog('新增用户', iframe);
}
function editUser() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个用户进行此操作", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("请选择单行进行此操作", "info");
        return;
    }
    EditUserByRow(rows[0]);
}
function EditUserByRow(row) {
    var iframe = "../UserInfo/EditUser.aspx?UserID=" + row.UserID;
    do_open_dialog('修改用户', iframe);
}
function removeUser() {
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
function editUserPwd() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个用户进行此操作", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("请选择单行进行此操作", "info");
        return;
    }
    var iframe = "../UserInfo/EditUserPwd.aspx?UserID=" + rows[0].UserID;
    do_open_dialog('修改用户密码', iframe);
}
