var idList = "";
$(document).ready(function () {
    //加载权限列表
    loadoperationTree(0);
    //init();
});
var IDMark_A = "_a";
var setting = {
    check: {
        enable: true,
        chkStyle: "radio",
        radioType: "level"
    },
    view: {
        showIcon: false
    },
    data: {
        simpleData: {
            enable: true
        }
    }
};

function loadoperationTree() {
    var options = { visit: 'getanalysistree', CompanyID: CompanyID };
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
function doSave() {
    var idarry = getSelected();
    var options = { visit: 'saveanalysisuser', IdList: JSON.stringify(idarry) };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        data: options,
        url: "../Handler/AuthMgrHandler.ashx",
        success: function (data) {
            if (data.status) {
                show_message('保存成功', 'success');
                return;
            }
            if (data.error) {
                show_message(data.error, 'warning');
                return;
            }
            show_message('系统错误', 'error');
        }
    });
}
