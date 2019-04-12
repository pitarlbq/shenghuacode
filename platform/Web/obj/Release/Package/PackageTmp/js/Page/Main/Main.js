var returnvalue = "";
var ytnamevalue = [];
var BeforeBanJieTimeOutHour = 1200;
$(function () {
    if (DefaultURL) {
        addnewTab('400客服', DefaultURL, '');
    }
    $(".tabs-header").css("margin-left", "0px");
    $(".tabs-header").css("max-width", "60%");
    $("#time").hover(function () {
        $("#time .floatBox").show();
    }, function () {
        $("#time .floatBox").hide();
    });
    $("#user_center").click(function (e) {
        var target = $(e.target);
        if (target.closest("#user_center").length == 0) {
            if ($("#user_center").hasClass('open')) {
                $("#user_center").removeClass('open');
            }
        }
        else {
            if ($("#user_center").hasClass('open')) {
                $("#user_center").removeClass('open');
            }
            else {
                $("#user_center").addClass('open');
            }
            $("#btnwarning").removeClass('open');
        }
    });
    $("#btnwarning").click(function (e) {
        var target = $(e.target);
        if (target.closest("#btnwarning").length == 0) {
            if ($("#btnwarning").hasClass('open')) {
                $("#btnwarning").removeClass('open');
            }
        }
        else {
            if ($("#btnwarning").hasClass('open')) {
                $("#btnwarning").removeClass('open');
            }
            else {
                $("#btnwarning").addClass('open');
            }
            $("#user_center").removeClass('open');
        }
    });
    $("#sub_servicetimeout").click(function (e) {
        do_view_chaoshi_list();
    });
    setTimeout(function () {
        $('#tabs .tabs-header').bind('click', function () {
            hide_popup();
        })
    }, 1000);
    setTimeout(function () {
        gettimeoutcount();
    }, 2000);
});
function do_view_chaoshi_list() {
    var pageurl = encodeURIComponent('../CustomerService/ServiceMgr.aspx?status=13&BeforeBanJieTimeOutHour=' + BeforeBanJieTimeOutHour);
    addTab('超时工单', 'Main/subpage.aspx?pageurl=' + pageurl + '&title=超时工单&urlencode=1');
    close_message();
}
function gettimeoutcount() {
    var options = {
        "visit": "getmytimeoutservice",
        "page": 1,
        "rows": 10,
        "getCount": 1,
        "ServiceStatus": 13,
        "BeforeBanJieTimeOutHour": BeforeBanJieTimeOutHour
    };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: 'Handler/ServiceHandler.ashx',
        data: options,
        success: function (data) {
            $('#warning_point').hide();
            $('#warning_point').text('0');
            $('#service_count').text('0');
            if (data.status && data.chaoshicount > 0) {
                $('#warning_point').show();
                $('#warning_point').text(data.chaoshicount);
                $('#service_count').text(data.chaoshicount);
                var messages = '您有' + data.chaoshicount + '个即将超时的工单待处理，<a href="javascript:do_view_chaoshi_list()">点击查看</a>'
                alertNotify(messages, 2);
            }
        }
    });
}
function hide_popup() {
    if ($("#user_center,#btnwarning").hasClass('open')) {
        $("#user_center,#btnwarning").removeClass('open');
    }
}
function viewPersonal() {
    addChildWin('个人中心', 'UserInfo/PersionalInfo.aspx?op=detail', $(window).width() - 400, $(window).height() - 50, 50, 200, 'winadd', function () {
        $("#winadd").remove();
    });
}
function addChildWin(title, url, width, height, top, left, id, OnClose) {
    var frame = '<iframe name="mainFrame" scrolling="auto" frameborder="0"  src="' + url + '" style="width:100%;height:99%;min-height:' + (height - 40) + 'px;border:0;"></iframe>'
    $("<div id='" + id + "'></div>").appendTo("body").window({
        title: title,
        width: width,
        height: height,
        top: top,
        left: left,
        modal: true,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        content: frame,
        onClose: OnClose
    });
}
function alertNotify(messages, ringType) {
    if (!messages) {
        return;
    }
    if (ringType == 1) {
        document.getElementById("message_ring").loop = true;
        $('#message_ring').attr('src', 'callring.mp3');
        $('#message_ring')[0].play();
    } else if (ringType == 2) {
        document.getElementById("message_ring").loop = false;
        $('#message_ring').attr('src', 'newmessage.mp3');
        $('#message_ring')[0].play();
    }
    $.messager.show({
        title: '温馨提示',
        msg: messages,
        showSpeed: 1000,
        timeout: 10000,
        showType: 'slide',
        width: 260,
        height: 160,
        onClose: function () {
            top.close_message();
        }
    });
}
function close_message() {
    top.isPopUp = false;
    $(".messager-body").window('close');
    $('#message_ring').attr('src', '');
    document.getElementById("message_ring").loop = false;
    $('#message_ring')[0].pause();
}
function socket_notify(obj) {
    var options = { visit: "checkismyservice", ID: obj.ID, UserID: UserID }
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: 'Handler/ServiceHandler.ashx',
        data: options,
        success: function (data) {
            if (data.status) {
                if (obj.type == 'notifysuggestion') {
                    var messages = '您有一条新的投诉建议，<a href="javascript:do_view_suggestion(' + obj.ID + ')">点击查看</a>'
                    alertNotify(messages, 2);
                    return;
                }
                if (obj.type == 'notifyservice') {
                    var messages = '您有一条新的报事报修单，<a href="javascript:do_view_baoshi(' + obj.ID + ')">查看详情</a>'
                    alertNotify(messages, 2);
                    return;
                }
            }
        }
    });
}
function do_view_baoshi() {
    addTab('报事报修', 'Main/subpage.aspx?pageurl=../CustomerService/ServiceMgr.aspx?status=100&title=报事报修');
    close_message();
}
function do_view_suggestion() {
    addTab('投诉建议', 'Main/subpage.aspx?pageurl=../CustomerService/ServiceSuggestionMgr.aspx?status=100&title=投诉建议');
    close_message();
}
function driverAlert() {
    if (is400User == 1) {
        var messages = '电话语音驱动未运行，请检查'
        alertNotify(messages, 2);
    }
}
function deviceOnAlert() {
    if (is400User == 1) {
        var messages = '设备未连接电脑，请检查'
        alertNotify(messages, 2);
    }
}