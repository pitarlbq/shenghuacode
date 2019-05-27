$(function () {
    tabCloseEven();
    String.prototype.endWith = function (endStr) {
        var d = this.length - endStr.length;
        return (d >= 0 && this.lastIndexOf(endStr) == d);
    }
});

function addTab(subtitle, url, icon) {
    top.TopTitle = subtitle;
    if (!$('#tabs').tabs('exists', subtitle)) {
        $('#tabs').tabs('add', {
            title: subtitle,
            content: createFrame(url, subtitle),
            closable: true,
            icon: icon
        });
    } else {
        $('#tabs').tabs('select', subtitle);
    }
    tabClose();
}
function addnewTab(subtitle, url, icon) {
    top.TopTitle = subtitle;
    try {
        $('#left_menu').show();
    } catch (e) {
    }
    if (!$('#tabs').tabs('exists', subtitle)) {
        $('#tabs').tabs('add', {
            title: subtitle,
            content: createFrame(url, subtitle),
            closable: false,
            icon: icon
        });
    } else {
        $('#tabs').tabs('select', subtitle);
        var tab = $('#tabs').tabs('getSelected');
        $('#tabs').tabs('update', {
            tab: tab,
            options: {
                title: subtitle,
                content: createFrame(url, subtitle),
            }
        });
    }
    $('#tabs').tabs({
        onSelect: function (title, index) {
            top.TopTitle = title;
            if (title == '客户管理') {
                top.treeType = 1;
            } else if (title == '400客服' || top.isAddService || isNumber(title)) {
                top.treeType = 6;
                top.openTreeContent(true);
                return;
            } else {
                top.treeType = 4;
            }
            top.openTreeContent();
        },
        onBeforeClose: function (title, index) {
        }
    })
    tabClose();
}
function isNumber(val) {
    var regPos = /^\d+(\.\d+)?$/; //非负浮点数
    var regNeg = /^(-(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*)))$/; //负浮点数
    if (regPos.test(val) || regNeg.test(val)) {
        return true;
    } else {
        return false;
    }
}
var realcostamalysisdetails_loaddata, tochargeanalysis_loaddata;
function createFrame(url, title) {
    var $height = document.body.clientHeight;
    //var s = '<iframe name="mainFrame" scrolling="auto" frameborder="0"  src="' + url + '" style="width:100%;height:' + ($height - 45) + 'px;border:0;"></iframe>';
    var id = 'top_main_frame';
    if (title == '工单管理') {
        id = 'topServiceFrame';
    } else if (title == '400客服') {
        id = 'top_phonenumber_frame';
    }
    else if (title == '400客服') {
        id = 'top_phonenumber_frame';
    } else if (isNumber(title)) {
        id = 'top_phonenumber_frame_' + title;
    }
    var s = '<iframe name="mainFrame" id="' + id + '" scrolling="auto" frameborder="0"  src="' + url + '" style="width:100%;height:99%;min-height:' + ($height - 45) + 'px;border:0;"></iframe>';
    return s;
}
function tabClose() {
    $(".tabs-inner").dblclick(function () {
        var subtitle = $(this).children(".tabs-closable").text();
        $('#tabs').tabs('close', subtitle);
    });
    $(".tabs-inner").bind('contextmenu', function (e) {
        $('#mm').menu('show', {
            left: e.pageX,
            top: e.pageY
        });
        var subtitle = $(this).children(".tabs-closable").text();
        $('#tabs').tabs('select', subtitle);
        return false;
    });
}
function tabCloseEven() {
    $("#mm-tabclose").click(function () {
        var title = $("#tabs").tabs("getSelected").panel("options").title;
        if (title == "400客服")
            return;
        $("#tabs").tabs("close", title);
    });
}
function getTimeName() {
    var newDate = new Date();
    var yyyy = newDate.getFullYear().toString();
    var MM = (Number(newDate.getMonth() + 1) < 10 ? "0" + (newDate.getMonth() + 1).toString() : (newDate.getMonth() + 1).toString());
    var dd = (Number(newDate.getDate()) < 10 ? "0" + newDate.getDate().toString() : newDate.getDate().toString());
    var HH = (Number(newDate.getHours()) < 10 ? "0" + newDate.getHours().toString() : newDate.getHours().toString());
    var mm = (Number(newDate.getMinutes()) < 10 ? "0" + newDate.getMinutes().toString() : newDate.getMinutes().toString());
    var ss = (Number(newDate.getSeconds()) < 10 ? "0" + newDate.getSeconds().toString() : newDate.getSeconds().toString());
    var hs = newDate.getMilliseconds();
    return yyyy + MM + dd + HH + mm + ss + hs;
}
function getTimeStr(newDate) {
    //var newDate = new Date();
    var yyyy = newDate.getFullYear().toString();
    var MM = (Number(newDate.getMonth() + 1) < 10 ? "0" + (newDate.getMonth() + 1).toString() : (newDate.getMonth() + 1).toString());
    var dd = (Number(newDate.getDate()) < 10 ? "0" + newDate.getDate().toString() : newDate.getDate().toString());
    var HH = (Number(newDate.getHours()) < 10 ? "0" + newDate.getHours().toString() : newDate.getHours().toString());
    var mm = (Number(newDate.getMinutes()) < 10 ? "0" + newDate.getMinutes().toString() : newDate.getMinutes().toString());
    var ss = (Number(newDate.getSeconds()) < 10 ? "0" + newDate.getSeconds().toString() : newDate.getSeconds().toString());
    return yyyy + "-" + MM + "-" + dd + " " + HH + ":" + mm + ":" + ss;
}
function getNowTimeStr() {
    var newDate = new Date();
    return getTimeStr(newDate);
}