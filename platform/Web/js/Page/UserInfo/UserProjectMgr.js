var idList = "", CurrentTab = 1;//0-用户 1-角色;
$(function () {
    loadOperation(0, 0);
})
function init() {
    //去掉结点前面的文件及文件夹小图标
    $(".tree-icon,.tree-file").removeClass("tree-icon tree-file");
    $(".tree-icon,.tree-folder").removeClass("tree-icon tree-folder tree-folder-open tree-folder-closed");
}
var IDMark_A = "_a";
var setting = {
    async: {
        enable: true,
        url: getUrl
    },
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
function getUrl(treeId, treeNode) {
    var nodes = $('#userTree').tree('getSelected');
    var RoleId = 0;
    if (nodes != null) {
        RoleId = nodes.id;
    }
    var CompanyID = 0;
    var ID = 0;
    if (treeNode.type == 'company') {
        CompanyID = treeNode.ID;
    } else if (treeNode.type == 'project') {
        ID = treeNode.ID;
    }
    var param = "visit=getprojecttree&ID=" + ID + "&CompanyID=" + CompanyID + "&RoleID=" + RoleId;
    return "../Handler/AuthMgrHandler.ashx?" + param;
}
function beforeExpand(treeId, treeNode) {
    if (!treeNode.isAjaxing) {
        treeNode.times = 1;
        ajaxGetNodes(treeNode, "refresh");
        return true;
    } else {
        show_message("zTree 正在下载数据中，请稍后展开节点", 'info');
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
    show_message("异步获取数据出现异常", 'info');
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
function loadOperation(RoleID, UserID) {
    var options = { visit: 'getprojecttree', CompanyID: 0, RoleID: RoleID, UserID: UserID };
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
        if (node.type == 'project') {
            idarry.push(node.ID);
        }
    });
    return idarry;
}
function getSelectedCompany() {
    var idarry = [];
    var treeObj = $.fn.zTree.getZTreeObj("tt");
    var nodes = treeObj.getCheckedNodes(true);
    $.each(nodes, function (index, node) {
        if (node.type == 'company') {
            idarry.push(node.ID);
        }
    });
    return idarry;
}
function do_save_operation(UserID, RoleID) {
    var idarry = getSelected();
    var CompanyIDList = getSelectedCompany();
    MaskUtil.mask('body', '提交中');
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: "../Handler/AuthMgrHandler.ashx",
        data: { visit: 'saveuserprojecttree', IdList: JSON.stringify(idarry), RoleId: RoleID, UserID: UserID, CompanyIDList: JSON.stringify(CompanyIDList) },
        success: function (data) {
            MaskUtil.unmask();
            if (data.status) {
                show_message("保存成功", 'success');
            } else if (data.error == 0) {
                show_message(data.error, 'info');
            } else {
                show_message("保存失败", 'error');
            }
        }
    });
}
