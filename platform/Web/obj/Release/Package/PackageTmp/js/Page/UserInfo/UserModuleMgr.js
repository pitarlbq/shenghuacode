var idList = "", CurrentTab = 1;//0-用户 1-角色;
$(function () {
    loadoperationTree();
})
function show(checkid) {
    var s = '#check_' + checkid;
    /*选子节点*/
    var nodes = $("#operationTree").treegrid("getChildren", checkid);
    for (i = 0; i < nodes.length; i++) {
        $(('#check_' + nodes[i].id))[0].checked = $(s)[0].checked;

    }
    //选上级节点
    if (!$(s)[0].checked) {
        var parent_node = $("#operationTree").treegrid("getParent", checkid);
        var flag = true;
        var sons = [];
        if (parent_node && parent_node.sondata) {
            sons = parent_node.sondata.split(',');
        }
        for (j = 0; j < sons.length; j++) {
            if (!$(('#check_' + sons[j]))[0].checked) {
                flag = true;
                break;
            }
        }
        if (flag) {
            if (parent_node) {
                $(('#check_' + parent_node.id))[0].checked = true;
            }
        }
        while (flag) {
            if (parent_node) {
                parent_node = $("#operationTree").treegrid("getParent", parent_node.id);
                if (parent_node && parent_node.sondata) {
                    sons = parent_node.sondata.split(',');
                    for (j = 0; j < sons.length; j++) {
                        if (!$(('#check_' + sons[j]))[0].checked) {
                            flag = true;
                            break;
                        }
                    }
                    if (flag) {
                        $(('#check_' + parent_node.id))[0].checked = true;
                    }
                } else {
                    flag = false;
                }
            } else {
                flag = false;
            }
        }
    }
}
//加载权限列表
function loadoperationTree() {
    var url = "../Handler/AuthMgrHandler.ashx?visit=operationTree";
    $('#operationTree').treegrid({
        url: url,
        rownumbers: false,
        idField: 'id',
        treeField: 'name',
        onClickRow: onOperationClick,
        onLoadSuccess: function (node, data) {
            init();
        }
    });
}
function formatcheckbox(val, row) {
    return "<input type='checkbox' name='procheck' onclick=show('" + row.id + "') id='check_" + row.id + "' " + (row.checked ? 'checked' : '') + "/>" + row.name;
}
function init() {
    //去掉结点前面的文件及文件夹小图标
    $(".tree-icon,.tree-file").removeClass("tree-icon tree-file");
    $(".tree-icon,.tree-folder").removeClass("tree-icon tree-folder tree-folder-open tree-folder-closed");
}
//获取选中的结点
function getSelected() {
    idList = "";
    $("input:checked").each(function () {
        var id = $(this).attr("id");

        if (id.indexOf('check_type') == -1 && id.indexOf("check_") > -1)
            idList += id.replace("check_", '') + ',';

    })
}
//设置选中节点
function setSelected(Id) {
    var CheckId = "check_" + Id;
    $("#" + CheckId).prop("checked", 'true');
}
function do_save_operation(UserID, RoleID) {
    getSelected();
    MaskUtil.mask('body', '提交中');
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: "../Handler/AuthMgrHandler.ashx",
        data: { visit: "saveoperation", IdList: idList, UserID: UserID, RoleID: RoleID },
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
//加载权限
function loadOperation(roleId, UserID) {
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: "../Handler/AuthMgrHandler.ashx",
        data: { visit: 'loadoperation', RoleId: roleId, UserID: UserID },
        success: function (data) {
            $("input[name='procheck']").prop("checked", false);
            for (var i = 0; i < data.length; i++) {
                setSelected(data[i].ModuleId);
            }
        }
    });
}
function onOperationClick() {
}