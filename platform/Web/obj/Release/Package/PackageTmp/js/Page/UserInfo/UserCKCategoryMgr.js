var idList = "", CurrentTab = 1;
$(document).ready(function () {
    get_user_role_tree();
    setTimeout(function () {
        get_user_tree();
    }, 500);
    setTimeout(function () {
        loadoperationTree(0, 0);
    }, 1000);
    $('#CommTab').tabs({
        onSelect: function (title, index) {
            if (title == '用户角色') {
                CurrentTab = 1;
            } else {
                CurrentTab = 0;
            }
        }
    });
});
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
var IDMark_A = "_a";
var setting = {
    view: {
        showIcon: false
    },
    data: {
        simpleData: {
            enable: true
        }
    },
    check: {
        enable: true,
        chkboxType: { "Y": "s", "N": "s" }
    },
    callback: {
        beforeExpand: beforeExpand,
        onAsyncSuccess: onAsyncSuccess,
        onAsyncError: onAsyncError
    }
};
function beforeExpand(treeId, treeNode) {
    if (!treeNode.isAjaxing) {
        treeNode.times = 1;
        ajaxGetNodes(treeNode, "refresh");
        return true;
    } else {
        alert("zTree 正在下载数据中，请稍后展开节点。。。");
        return false;
    }
}
function onAsyncSuccess(event, treeId, treeNode, msg) {
    if (!msg || msg.length == 0) {
        return;
    }
    var zTree = $.fn.zTree.getZTreeObj("tt");
    treeNode.icon = "";
    zTree.updateNode(treeNode);
    zTree.selectNode(treeNode.children[0]);
}
function onAsyncError(event, treeId, treeNode, XMLHttpRequest, textStatus, errorThrown) {
    var zTree = $.fn.zTree.getZTreeObj("tt");
    alert("异步获取数据出现异常。");
    treeNode.icon = "";
}
function ajaxGetNodes(treeNode, reloadType) {
    var zTree = $.fn.zTree.getZTreeObj("tt");
    if (reloadType == "refresh") {
        treeNode.icon = "../js/ztree/zTreeStyle/img/loading.gif";
        zTree.updateNode(treeNode);
    }
    zTree.reAsyncChildNodes(treeNode, reloadType, true);
}
function loadoperationTree(RoleID, UserID) {
    var options = { visit: 'getckcategorytree', RoleID: RoleID, UserID: UserID };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/AuthMgrHandler.ashx',
        data: options,
        success: function (data) {
            $.fn.zTree.init($("#tt"), setting, data);
        }
    });
}
//获取选中的结点
function getSelected() {
    var idarry = [];
    var treeObj = $.fn.zTree.getZTreeObj("tt");
    var nodes = treeObj.getCheckedNodes(true);
    $.each(nodes, function (index, node) {
        idarry.push(node.id);
    });
    return idarry;
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
    do_save_operation(UserID, RoleID);
}
function do_save_operation(UserID, RoleID) {
    var idarry = getSelected();
    MaskUtil.mask('body', '提交中');
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: "../Handler/AuthMgrHandler.ashx",
        data: { visit: 'saveuserckcategory', IdList: JSON.stringify(idarry), RoleId: RoleID, UserID: UserID },
        success: function (data) {
            MaskUtil.unmask();
            if (data.status) {
                show_message("保存成功", 'success');
            } else if (data.error) {
                show_message(data.error, 'info');
            } else {
                show_message("保存失败", 'error');
            }
        }
    });
}
/********单击角色操作***********/
function onClickRole() {
    var nodes = $('#userRoleTree').tree('getSelected');
    var Id = nodes.id;
    loadoperationTree(Id, 0);
}
/********单击用户操作***********/
function onClickUser() {
    var nodes = $('#userTree').tree('getSelected');
    var Id = nodes.id;
    loadoperationTree(0, Id);
}
