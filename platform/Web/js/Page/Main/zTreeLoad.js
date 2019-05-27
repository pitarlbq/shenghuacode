var navtype = 1;
var treeType = 4;
$(function () {
    doSearch();
    if (treeType == 1) {
        $('#labelALL').hide();
    } else {
        $('#labelALL').show();
    }
    $('#btnAll').bind('click', function () {
        var treeObj = $.fn.zTree.getZTreeObj("tt");
        if ($('#btnAll').prop('checked')) {
            treeObj.checkAllNodes(true);
        }
        else {
            treeObj.checkAllNodes(false);
        }
    })
});
function GetALLSelectedProjects() {
    var idarry = [];
    var pidarray = [];
    var treeObj = $.fn.zTree.getZTreeObj("tt");
    var nodes = treeObj.getCheckedNodes(true);
    $.each(nodes, function (index, node) {
        if (node.isParent && node.type == 'project') {
            idarry.push(node.id);
        }
    });
    return idarry;
}
function GetSelectedProjects() {
    var idarry = [];
    var pidarray = [];
    var treeObj = $.fn.zTree.getZTreeObj("tt");
    var nodes = treeObj.getCheckedNodes(true);
    $.each(nodes, function (index, node) {
        if (node.isParent && node.type == 'project') {
            idarry.push(node.id);
            if (node.pId && $.inArray(node.pId, pidarray) == -1) {
                pidarray.push(node.pId);
            }
        }
    });
    var temp = [];
    var temparray = [];
    for (var i = 0; i < pidarray.length; i++) {
        temp[pidarray[i]] = true;
    };
    for (var i = 0; i < idarry.length; i++) {
        if (!temp[idarry[i]]) {
            temparray.push(idarry[i]);
        };
    };
    return temparray;
}
function GetNav7SelectedProjects() {
    var idarry = [];
    var r = document.getElementsByName('checkbox_0');
    for (var i = 0; i < r.length; i++) {
        if (r[i].checked) {
            var Type = $(r[i]).attr("data-type");
            if (Type == 'xiaoqu') {
                var ID = $(r[i]).attr("data-id");
                idarry.push(Number(ID));
            }
        }
    }
    return idarry;
}
function GetNav7SelectedPublicProjects() {
    var idarry = [];
    var r = document.getElementsByName('checkbox_0');
    for (var i = 0; i < r.length; i++) {
        if (r[i].checked) {
            var Type = $(r[i]).attr("data-type");
            if (Type == 'publicproject') {
                var ID = $(r[i]).attr("data-id");
                idarry.push(Number(ID));
            }
        }
    }
    return idarry;
}
function GetSelectedRooms() {
    var idarry = [];
    if (treeType == 1) {
        var r = document.getElementsByName('checkbox_0');
        for (var i = 0; i < r.length; i++) {
            if (r[i].checked) {
                var checkid = $(r[i]).attr("id");
                idarry.push(Number(checkid));
            }
        }
    } else if (treeType == 6) {
        var zTree = $.fn.zTree.getZTreeObj("tt");
        var nodes = treeObj.getCheckedNodes(true);
        $.each(nodes, function (index, node) {
            if (!node.isParent) {
                idlist.push(node.id);
            }
        })
    } else {
        var treeObj = $.fn.zTree.getZTreeObj("tt");
        var nodes = treeObj.getCheckedNodes(true);
        $.each(nodes, function (index, node) {
            if (!node.isParent) {
                idarry.push(node.id);
            }
        })
    }
    return idarry;
}
function GetSelectedCompanyIDs() {
    var idarry = [];
    var treeObj = $.fn.zTree.getZTreeObj("tt");
    var nodes = treeObj.getCheckedNodes(true);
    $.each(nodes, function (index, node) {
        if (node.isParent && node.type == 'company') {
            idarry.push(node.id);
        }
    });
    return idarry;
}
function GetSelectProjectID() {
    var radio = $('#tt input[name="radio_0"]:checked ');
    var radioid = $(radio).attr("id");
    var Type = $(radio).attr("data-type");
    if (radioid != null && radioid != "" && Type == 'project') {
        return Number(radioid);
    }
    return "";
}
function GetSelectCompanyID() {
    var radio = $('#tt input[name="radio_0"]:checked ');
    var radioid = $(radio).attr("id");
    var Type = $(radio).attr("data-type");
    if (radioid != null && radioid != "" && Type == 'company') {
        return Number(radioid);
    }
    return "";
}
function GetSelectedPublicProjects() {
    var idarry = [];
    var pidarray = [];
    var treeObj = $.fn.zTree.getZTreeObj("tt");
    var nodes = treeObj.getCheckedNodes(true);
    $.each(nodes, function (index, node) {
        if (node.isParent && node.type == 'publicproject') {
            idarry.push(node.ID);
            if (node.ParentID && $.inArray(node.ParentID, pidarray) == -1) {
                pidarray.push(node.ParentID);
            }
        }
    });
    var temp = [];
    var temparray = [];
    for (var i = 0; i < pidarray.length; i++) {
        temp[pidarray[i]] = true;
    };
    for (var i = 0; i < idarry.length; i++) {
        if (!temp[idarry[i]]) {
            temparray.push(idarry[i]);
        };
    };
    return temparray;
}
function GetNav8SelectRadio() {
    var radio = $('#tt input[name="radio_0"]:checked ');
    var radioid = $(radio).attr("data-id");
    var type = $(radio).attr("data-type");
    if (radioid != null && radioid != "" && type == 'department') {
        return Number(radioid);
    }
    return "";
}
function GetNav8SelectCompanyID() {
    var radio = $('#tt input[name="radio_0"]:checked ');
    var radioid = $(radio).attr("data-id");
    var type = $(radio).attr("data-type");
    if (radioid != null && radioid != "" && type == 'company') {
        return Number(radioid);
    }
    return "";
}
function GetNav8SelectType() {
    var radio = $('#tt input[name="radio_0"]:checked ');
    var type = $(radio).attr("data-type");
    return type;
}
function GetNav8SelectParentID() {
    var radio = $('#tt input[name="radio_0"]:checked ');
    var radioid = $(radio).attr("p_id");
    if (radioid != null && radioid != "") {
        return Number(radioid);
    }
    return "";
}
function getNav8CheckedRadio(radioName) {
    var r = document.getElementsByName(radioName);
    for (var i = 0; i < r.length; i++) {
        if (r[i].checked) {
            return $(r[i]);
        }
    }
    return null;
}
var IDMark_A = "_a", setting = null;
function loadTree(options) {
    options = options || {};
    setting = {
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
            },
            keep: {
                parent: true
            }
        },
        check: {
            enable: true
        },
        callback: {
            onClick: onClick,
            onCheck: onCheck,
            beforeExpand: beforeExpand,
            beforeCollapse: beforeCollapse,
            onAsyncSuccess: onAsyncSuccess,
            onAsyncError: onAsyncError,
            onCheck: zTreeOnCheck,
        }
    }
    if (treeType == 1) {
        setting.view = {
            addDiyDom: addDiyDom,
            dblClickExpand: false,
            selectedMulti: true,
            showIcon: false
        };
        setting.check = {
            enable: false
        }
    } else if (treeType == 6) {
        setting.view = {
            dblClickExpand: false,
            showIcon: false
        };
        setting.check = {
            enable: true,
            chkStyle: "radio",
            radioType: "all"
        }
    } else if (treeType == 7) {
        setting.view = {
            addDiyDom: addDiyDom,
            dblClickExpand: false,
            selectedMulti: true,
            showIcon: false
        };
        setting.check = {
            enable: false
        }
    } else if (treeType == 8) {
        setting.async.enable = false;
        setting.view = {
            addDiyDom: addDiyDom,
            dblClickExpand: false,
            selectedMulti: true,
            showIcon: false
        };
        setting.check = {
            enable: false
        }
    } else {
        setting.check = {
            enable: true,
            chkboxType: { "Y": "s", "N": "s" }
        }
    }
    doSearch();
}
function getUrl(treeId, treeNode) {
    var param = '';
    if (treeType == 7) {
        var ParentID = 0;
        var ParentProjectID = 0;
        var islastproject = false;
        if (treeNode.Type == 'xiaoqu') {
            ParentID = 0;
            ParentProjectID = treeNode.ID;
            islastproject = treeNode.islastproject;
        }
        if (treeNode.Type == 'publicproject') {
            ParentID = treeNode.ID;
            ParentProjectID = treeNode.ParentProjectID;
        }
        param = "visit=getpublicprojecttree&ParentID=" + ParentID + "&ParentProjectID=" + ParentProjectID + "&islastproject=" + islastproject;
    } else if (treeType == 8) {
        return;
    } else {
        var CompanyID = 0;
        var PublicID = 0;
        var ID = 0;
        var IncludePublic = "false";
        if (treeNode.type == 'company') {
            CompanyID = treeNode.ID;
        }
        else {
            if (navtype == 2) {
                IncludePublic = "true";
                if (treeNode.type == 'publicproject') {
                    PublicID = treeNode.ID;
                }
                else {
                    ID = treeNode.id;
                }
            } else {
                ID = treeNode.id;
            }
        }
        param = "visit=getprojectinfo&ID=" + ID + "&IncludePublic=" + IncludePublic + "&PublicID=" + PublicID + '&CompanyID=' + CompanyID;
    }
    return "../Handler/ProjectHandler.ashx?" + param;
}
function zTreeOnCheck(event, treeId, treeNode) {
    if (!treeNode.isParent) {
        try {
            loadRoomInfo(treeNode.id, treeNode.checked);
        } catch (e) {
        }
    }
};
function beforeCollapse(treeId, treeNode) {
    var treeObj = $.fn.zTree.getZTreeObj("tt");
    if (treeType == 8) {
        return;
    }
    treeObj.removeChildNodes(treeNode);
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
function onClick(event, treeId, treeNode, clickFlag) {
    var zTree = $.fn.zTree.getZTreeObj("tt");
    zTree.expandNode(treeNode, null, false, true, true, true);
    if (treeType == 1) {
        var btn = $("#" + treeNode.id);
        if (btn) {
            btn.click();
        }
    }
    else if (treeType == 6) {
        zTree.checkNode(treeNode, true, false);
        onCheck(event, treeId, treeNode);
    } else if (treeType == 7) {
        zTree.expandNode(treeNode, null, false, true, true, true);
        if (treeNode.hasradio) {
            var btn = $("#" + treeNode.id);
            btn.click();
        }
    } else if (treeType == 8) {
        zTree.expandNode(treeNode, null, false, true, true, true);
        onCheck(event, treeId, treeNode);
        var btn = $("#" + treeNode.id);
        btn.click();
    }
}
function onCheck(event, treeId, treeNode) {
    if (treeType == 6) {
        if (!treeNode.IsLocked) {
            if (top.TopTitle == '400客服') {
                try {
                    //var iframeElems = document.getElementsByName('mainFrame');
                    $("iframe#top_phonenumber_frame")[0].contentWindow.getProjectData('', treeNode.ID, treeNode.isParent);
                } catch (e) {
                    //alert(e)
                }
            } else if (top.isNumber(top.TopTitle)) {
                try {
                    $("iframe#top_phonenumber_frame_" + top.TopTitle)[0].contentWindow.getProjectData('', treeNode.ID, treeNode.isParent);
                } catch (e) {
                    //alert(e)
                }
            }
            else {
                try {
                    var iframeTarget = $('iframe#topServiceFrame').contents().find('iframe#subPageFrame').contents().find("iframe#dialog_frame1");
                    iframeTarget[0].contentWindow.pageLoad(treeNode.ID, treeNode.isParent);
                } catch (e) {
                    //alert(e)
                }
            }
        }
    }
    if (treeType == 8) {
        try {
            var iframeTarget = $('iframe#top_main_frame').contents().find('iframe#subPageFrame').contents().find("iframe#dialog_frame1");
            iframeTarget[0].contentWindow.pageLoad(treeNode.ID);
        } catch (e) {
            //alert(e)
        }
    }
}
function ajaxGetNodes(treeNode, reloadType) {
    var zTree = $.fn.zTree.getZTreeObj("tt");
    if (reloadType == "refresh") {
        treeNode.icon = "../js/ztree/zTreeStyle/img/loading.gif";
        zTree.updateNode(treeNode);
    }
    zTree.reAsyncChildNodes(treeNode, reloadType, true);
}
function doSearch() {
    var keywords = $("#searchbox").searchbox("getValue");
    var visit = 'getprojectinfo';
    var postUrl = '../Handler/ProjectHandler.ashx';
    if (treeType == 7) {
        visit = 'getpublicprojecttree'
    } else if (treeType == 8) {
        visit = 'getdepartmenttree';
        postUrl = '../Handler/SysSettingHandler.ashx';
    }
    MaskUtil.mask('#tt');
    var options = { visit: visit, Keywords: keywords };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: postUrl,
        data: options,
        success: function (data) {
            MaskUtil.unmask();
            $.fn.zTree.init($("#tt"), setting, data);
        }
    });
}
function addDiyDom(treeId, treeNode) {
    var aObj = $("#" + treeNode.tId + IDMark_A);
    if (treeType == 7) {
        if (treeNode.hasradio) {
            var ID = treeNode.ID;
            var Type = treeNode.type;
            var editStr = "<input type='radio' onclick='clickRadioBtn()' name='checkbox_0' class='checkboxBtn' id='" + treeNode.id + "' data-id='" + ID + "' data-type='" + Type + "' onfocus='this.blur();'></input>";
            aObj.before(editStr);
        }
    } else if (treeType == 8) {
        var Type = treeNode.type;
        var id = 0;
        if (treeNode.getParentNode() != null) {
            id = treeNode.getParentNode().id;
        }
        var editStr = "<input type='radio' onclick='clickRadioBtn()' value='0' class='radioBtn' p_id='" + id + "' id='" + treeNode.id + "' name='radio_0' onfocus='this.blur();' data-id='" + treeNode.ID + "' data-type='" + Type + "'></input>";
        aObj.before(editStr);
        var btn = $("#" + treeNode.id);
        if (btn) {
            btn.bind("click", function () {
                var treeObj = $.fn.zTree.getZTreeObj("tt");
                if (btn.val() == 1) {
                    $('#tt input[name="radio_0"]').attr("value", "0");
                    btn.attr("value", "0");
                    btn.prop("checked", false);
                    //btn.removeAttr("checked");
                    //treeObj.cancelSelectedNode(treeNode);
                } else {
                    $('#tt input[name="radio_0"]').attr("value", "0");
                    btn.val("1");
                    btn.prop("checked", true);
                    //treeObj.selectNode(treeNode, false);
                }
            });
        }
    }
    else if (treeType == 1) {
        if (treeNode.isParent) {
            var id = 0;
            if (treeNode.getParentNode() != null) {
                id = treeNode.getParentNode().id;
            }
            var editStr = "<input type='radio' value='0' class='radioBtn' p_id='" + id + "' id='" + treeNode.id + "' name='radio_0' onfocus='this.blur();' data-id='" + treeNode.ID + "' data-type='" + treeNode.type + "'></input>";
            aObj.before(editStr);
            var btn = $("#" + treeNode.id);
            if (btn) {
                btn.bind("click", function () {
                    var treeObj = $.fn.zTree.getZTreeObj("tt");
                    if (btn.val() == 1) {
                        $('#tt input[name="radio_0"]').attr("value", "0");
                        btn.attr("value", "0");
                        btn.prop("checked", false);
                    } else {
                        $('#tt input[name="radio_0"]').attr("value", "0");
                        btn.val("1");
                        btn.prop("checked", true);
                    }
                });
            }
        } else {
            var editStr = "<input type='checkbox' name='checkbox_0' class='checkboxBtn' id='" + treeNode.id + "' onfocus='this.blur();'></input>";
            aObj.before(editStr);
        }
    }
}
function clickRadioBtn() {

}
