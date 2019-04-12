var userId = 0;
var result = null;
var loginName = null;
var password = null;
var realName = null;
var gender = null;
var dgCanLoad = false;
var isDoMore = false;
$(document).ready(function () {
    loadUsers();
    loadnoRoles(0);
    $('#tdMore').bind('click', function () {
        isDoMore = false;
        $("#dg").datagrid("options").singleSelect = true;
        $("#notr").datagrid("options").singleSelect = true;
        if ($('#tdMore').prop('checked')) {
            $("#dg").datagrid("options").singleSelect = false;
            $("#notr").datagrid("options").singleSelect = false;
            loadnoRoles(0);
            isDoMore = true;
        }
    })
});
function loadnoRoles(userId) {
    if (isDoMore) {
        return;
    }
    getNoRoleByUserID(userId);
    $('#notr').datagrid({
        url: '../Handler/UserRoleHandler.ashx?visit=loadnoroles&UserID=' + userId,
        onLoadError: function () {
            $("#loadNoRoleFailed").html("<span> 重新加载 </span><a href='javascript:loadnoRoles('" + userId + "')'>点击</a>");
        },
        onLoadSuccess: function (data) {
            $("#loadNoRoleFailed").html("");
        }
    });
}
function loadinRoles(userId) {
    if (isDoMore) {
        return;
    }
    $('#inr').datagrid({
        url: '../Handler/UserRoleHandler.ashx?visit=loadinroles&UserID=' + userId,
        onLoadError: function () {
            $("#loadInRoleFailed").html("<span> 重新加载 </span><a href='javascript:loadinRoles('" + userId + "')'>点击</a>");
        },
        onLoadSuccess: function (data) {
            $("#loadInRoleFailed").html("");
        }
    });
}
function loadUsers() {
    $('#dg').datagrid({
        url: '../Handler/UserRoleHandler.ashx',
        onClickRow: UserOnClickRow,
        loadMsg: '正在加载',
        border: false,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: true,
        fitColumns: true,
        singleSelect: true,
        striped: true,
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        onBeforeLoad: function (data) {
            if (!dgCanLoad) {
                $('#dg').datagrid("loadData", {
                    total: 0,
                    rows: []
                });
            }
            return dgCanLoad;
        },
        onLoadError: function () {
            $("#loadUserFailed").html("<span> 重新加载 </span><a href='javascript:loadUsers()'>点击</a>");
        },
        onLoadSuccess: function (data) {
            $("#loadUserFailed").html("");
        }
    });
    doSearchUser();
}
function doSearchUser() {
    dgCanLoad = true;
    $("#dg").datagrid("load", {
        "visit": "loadusers",
        "Keywords": $('#tbRealName').searchbox('getValue')
    });
}
function UserOnClickRow() {
    var userId = 0;
    var row = $("#dg").datagrid('getSelected');
    if (row) {
        userId = row.UserID;
    }
    loadnoRoles(userId);
    loadinRoles(userId);
}
//赋予角色
function leftRole() {
    var rows = $("#dg").datagrid('getSelections');
    var row1s = $("#notr").datagrid('getSelections');
    if (rows.length == 0) {
        show_message('请选择用户', 'warning');
        return;
    }
    if (row1s.length == 0) {
        show_message('请选择部门', 'warning');
        return;
    }
    var UserIDList = [];
    $.each(rows, function (index, row) {
        UserIDList.push(row.UserID);
    })
    var RoleIDList = [];
    $.each(row1s, function (index, row1) {
        RoleIDList.push(row1.RoleID);
    })
    $.post('../Handler/UserRoleHandler.ashx?visit=addroles', { UserIDList: JSON.stringify(UserIDList), RoleIDList: JSON.stringify(RoleIDList) }, function (result) {
        if (isDoMore) {
            show_message('操作成功', 'success');
            return;
        }
        $('#inr').datagrid('reload');
        $('#notr').datagrid('reload');
    }, 'json');
}
//移除角色
function rightRole() {
    var rows = $("#dg").datagrid('getSelections');
    var row1s = $("#inr").datagrid('getSelections');
    if (isDoMore) {
        row1s = $("#notr").datagrid('getSelections');
    }
    if (rows.length == 0) {
        show_message('请选择用户', 'warning');
        return;
    }
    if (row1s.length == 0) {
        show_message('请选择部门', 'warning');
        return;
    }
    var UserIDList = [];
    $.each(rows, function (index, row) {
        UserIDList.push(row.UserID);
    })
    var RoleIDList = [];
    $.each(row1s, function (index, row1) {
        RoleIDList.push(row1.RoleID);
    })
    $.post('../Handler/UserRoleHandler.ashx?visit=removeroles', { UserIDList: JSON.stringify(UserIDList), RoleIDList: JSON.stringify(RoleIDList) }, function (result) {
        if (isDoMore) {
            show_message('操作成功', 'success');
            return;
        }
        $('#inr').datagrid('reload');
        $('#notr').datagrid('reload');
    }, 'json');
}
function getNoRoleByUserID(userId) {
    var keywords = $('#tdRoleName').searchbox('getValue');
    $('#notr').datagrid({
        url: '../Handler/UserRoleHandler.ashx?visit=loadinroles&UserID=' + userId + '&keywords=' + keywords,
        onLoadError: function () {
            $("#loadNoRoleFailed").html("<span> 重新加载 </span><a href='javascript:getNoRoleByUserID('" + userId + "')'>点击</a>");
        },
        onLoadSuccess: function (data) {
            $("#loadInRoleFailed").html("");
        }
    });
}
function doSearchRole() {
    getNoRoleByUserID(0);
}

