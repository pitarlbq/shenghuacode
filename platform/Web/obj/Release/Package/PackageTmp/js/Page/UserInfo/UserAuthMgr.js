var idList = "", CurrentTab = 1;//0-用户 1-角色;
$(function () {
    get_user_role_tree();
    setTimeout(function () {
        get_user_tree();
    }, 500);
    $('#CommTab').tabs({
        onSelect: function (title, index) {
            if (title == '用户角色') {
                CurrentTab = 1;
            } else {
                CurrentTab = 0;
            }
        }
    });
})
function get_user_tree() {
    //加载用户列表
    $('#userTree').tree({
        url: "../Handler/AuthMgrHandler.ashx?visit=loadusertree",
        lines: true,
        checkbox: false,
        fit: true,
        fitColumns: false,
        onClick: onClickUser,
        animate: true,
        cascadeCheck: true,
        onLoadSuccess: function (node, data) {
            if (data.status == false) {
                show_message("该用户权限不足", 'info');
            }
            init();
        }
    });
};
function get_user_role_tree() {
    //加载用户角色列表
    $('#userRoleTree').tree({
        url: "../Handler/AuthMgrHandler.ashx?visit=loaduserroletree",
        lines: true,
        checkbox: false,
        fit: true,
        fitColumns: false,
        onClick: onClickRole,
        animate: true,
        cascadeCheck: true,
        onLoadSuccess: function (node, data) {
            if (data.status == false) {
                show_message("该用户权限不足", 'info');
            }
            init();
        }
    });
};
function init() {
    //去掉结点前面的文件及文件夹小图标
    $(".tree-icon,.tree-file").removeClass("tree-icon tree-file");
    $(".tree-icon,.tree-folder").removeClass("tree-icon tree-folder tree-folder-open tree-folder-closed");
}
/*****保存权限*****/
function do_save() {
    var UserID = 0;
    var RoleID = 0;
    if (CurrentTab == 0) {
        var node = $('#userTree').tree('getSelected');
        if (node == null || node == undefined || node == '') {
            show_message("请选择用户", 'info');
            return;
        }
        UserID = node.id;
        if (UserID == 0) {
            show_message("请选择用户", 'info');
            return;
        }
    } else {
        var node = $('#userRoleTree').tree('getSelected');
        if (node == null || node == undefined || node == '') {
            show_message("请选择角色", 'info');
            return;
        }
        RoleID = node.id;
        if (RoleID == 0) {
            show_message("请选择角色", 'info');
            return;
        }
    }
    var curTab = $('#OperationTab').tabs('getSelected');
    curTab.find("iframe")[0].contentWindow.do_save_operation(UserID, RoleID);
}
/********单击用户操作***********/
function onClickRole() {
    var nodes = $('#userRoleTree').tree('getSelected');
    var Id = nodes.id;
    var curTab = $('#OperationTab').tabs('getSelected');
    curTab.find("iframe")[0].contentWindow.loadOperation(Id, 0);
}
function onClickUser() {
    var nodes = $('#userTree').tree('getSelected');
    var Id = nodes.id;
    var curTab = $('#OperationTab').tabs('getSelected');
    curTab.find("iframe")[0].contentWindow.loadOperation(0, Id);
}