var idList = "";
$(document).ready(function () {
    loadoperationTree(OrderNumberID);
});
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
    var param = "visit=getprojectordernumbertree&ID=" + treeNode.id + "&CompanyID=" + CompanyID + "&OrderNumberID=" + OrderNumberID + "&Level=2&UserID=" + UserID;
    return "../Handler/AuthMgrHandler.ashx?" + param;
}
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
function loadoperationTree(RoleID) {
    var options = { visit: 'getprojectordernumbertree', CompanyID: CompanyID, OrderNumberID: OrderNumberID, Level: 2, UserID: UserID };
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
    var idarry = getSelected();
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: "../Handler/AuthMgrHandler.ashx?visit=saveProjectOrderNumber&IdList=" + JSON.stringify(idarry) + "&OrderNumberID=" + OrderNumberID,
        success: function (data) {
            if (data.status) {
                show_message("保存成功", "success", function () {
                    do_close();
                });
            } else {
                show_message("保存失败", "error");
            }
        }
    });
}
function do_close() {
    parent.do_close_dialog();
}
