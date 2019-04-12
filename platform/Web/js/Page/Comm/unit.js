
var global_variable = {
    pageSize: 500,
    pageList: [500, 2000]
};
$(function () {
    //var elems = $('input.easyui-textbox');
    //$.each(elems, function () {
    //    var newValue = $(this).textbox('getValue');
    //    set_textbox_icon(newValue, this);
    //})
    //$('input.easyui-textbox').textbox({
    //    onChange: function (newValue, oldValue) {
    //        set_textbox_icon(newValue, this);
    //    }
    //})
    setTimeout(function () {
        resize_easyui_box();
    }, 300);
    Date.prototype.Format = function (fmt) {
        var o = {
            "M+": this.getMonth() + 1, //月份 
            "d+": this.getDate(), //日 
            "h+": this.getHours(), //小时 
            "m+": this.getMinutes(), //分 
            "s+": this.getSeconds(), //秒 
            "q+": Math.floor((this.getMonth() + 3) / 3), //季度 
            "S": this.getMilliseconds() //毫秒 
        };
        if (/(y+)/.test(fmt))
            fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
        for (var k in o) {
            if (new RegExp("(" + k + ")").test(fmt)) {
                fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
            }
        }
        return fmt;
    }
})
function set_textbox_icon(newValue, target) {
    var icon_disabled = true;
    if (newValue != '') {
        $(target).textbox({
            icons: [{
                iconCls: 'icon-guanbi_2',
                handler: function (e) {
                    $(e.data.target).textbox('clear')
                    $(e.data.target).textbox().next('span').find('input').focus();
                }
            }]
        })
    } else {
        $(target).textbox({
            icons: []
        })
    }
    setTimeout(function () {
        resize_easyui_box();
    }, 100);
}
function resize_easyui_box() {
    $('input.easyui-textbox').css('height', '25px');
    $('input.easyui-combobox').css('height', '25px');
    $('input.textbox-text').css('height', '25px').css('padding-top', '0px').css('padding-bottom', '1px');
    $('span.textbox').css('height', '28px');
    $('.textbox-icon').css('height', '25px');
    $('.textbox-button').css('height', '25px');
    $('.textbox-icon.combo-arrow').css('height', '25px');
    $('textarea.textbox-text').parent().css('height', '60px');
    $('textarea.textbox-text').css('height', '58px');
    $('.textbox-button .l-btn-text').css('line-height', '28px');
}
function formatTime(value, row) {
    if (value == undefined || value == null || value == '' || value == '0001-01-01T00:00:00.0000000' || value == '0001-01-01T00:00:00' || value == '1900-01-01T00:00:00.0000000' || value == '1900-01-01T00:00:00') {
        return "--";
    }
    return value.substring(0, 16).split("T")[0];
}
function formatPrice(value, row) {
    if (Number(value) < 0) {
        return 0.00;
    }
    return value;
}
function formatIntCount(value, row) {
    if (Number(value) < 0) {
        return 0;
    }
    return value;
}
function formatDateTime(value, row) {
    if (value == undefined || value == null || value == '0001-01-01T00:00:00.0000000' || value == '0001-01-01T00:00:00' || value == '1900-01-01T00:00:00.0000000' || value == '1900-01-01T00:00:00') {
        return "--";
    }
    return value.substring(0, 19).replace("T", " ");
}
function timeToStamp(stringTime) {
    stringTime = stringTime.replace(/-/g, "/").replace("T", " ");
    var date = new Date(stringTime);
    var timestamp = Date.parse(date) / 1000;
    return timestamp;
}
function stampToTime(timestamp) {
    var newDate = new Date();
    newDate.setTime(Number(timestamp) * 1000);
    var yyyy = newDate.getFullYear().toString();
    var MM = (Number(newDate.getMonth() + 1) < 10 ? "0" + (newDate.getMonth() + 1).toString() : (newDate.getMonth() + 1).toString());
    var dd = (Number(newDate.getDate()) < 10 ? "0" + newDate.getDate().toString() : newDate.getDate().toString());
    var HH = (Number(newDate.getHours()) < 10 ? "0" + newDate.getHours().toString() : newDate.getHours().toString());
    var mm = (Number(newDate.getMinutes()) < 10 ? "0" + newDate.getMinutes().toString() : newDate.getMinutes().toString());
    var ss = (Number(newDate.getSeconds()) < 10 ? "0" + newDate.getSeconds().toString() : newDate.getSeconds().toString());
    return yyyy + "-" + MM + "-" + dd + " " + HH + ":" + mm + ":" + ss;
}
function stampToDate(timestamp) {
    var newDate = new Date();
    newDate.setTime(Number(timestamp) * 1000);
    var yyyy = newDate.getFullYear().toString();
    var MM = (Number(newDate.getMonth() + 1) < 10 ? "0" + (newDate.getMonth() + 1).toString() : (newDate.getMonth() + 1).toString());
    var dd = (Number(newDate.getDate()) < 10 ? "0" + newDate.getDate().toString() : newDate.getDate().toString());
    return yyyy + "-" + MM + "-" + dd;
}
function stringToDate(str) {
    return new Date(Date.parse(str.replace(/-/g, "/")));
}
function calculate_month(starttime, endtime) {
    var arry1, arry2, year1, year2, month1, month2, day1, day2, count, newenddate, newday2;
    arry1 = starttime.split("-");
    year1 = parseInt(arry1[0]);
    month1 = parseInt(arry1[1]);
    day1 = parseInt(arry1[2]);
    arry2 = endtime.split("-");
    year2 = parseInt(arry2[0]);
    month2 = parseInt(arry2[1]);
    day2 = parseInt(arry2[2]);
    newenddate = new Date(year2, month2, 0);
    newday2 = newenddate.getDate();
    if (day1 == 1) {
        if (day2 == newday2) {
            count = (year2 - year1) * 12 + (month2 - month1) + 1;
        }
        else {
            count = (year2 - year1) * 12 + (month2 - month1);
        }
    }
    else if (day2 < (day1 - 1)) {
        count = (year2 - year1) * 12 + (month2 - month1) - 1;
    }
    else {
        count = (year2 - year1) * 12 + (month2 - month1);
    }
    return count;
}
function toThousands(num) {
    num = num || 0;
    var numarray = num.toString().split(".");
    if (numarray.length > 1) {
        if (numarray[1].length > 4 || numarray[1].length <= 2)
            num = (parseFloat(num)).toFixed(2);
    }
    numarray = num.toString().split(".");
    var num0 = numarray[0], result = '';
    while (num0.length > 3) {
        result = ',' + num0.slice(-3) + result;
        num0 = num0.slice(0, num0.length - 3);
    }
    if (num0) {
        result = num0 + result;
    }
    if (numarray.length > 1) {
        result = result + "." + numarray[1];
    }
    else {
        result = result + ".00";
    }
    return result;
}
function calculate_day(starttime, endtime) {
    if (starttime == '' || endtime == '') {
        return 0;
    }
    var startdate = stringToDate(starttime);
    var enddate = stringToDate(endtime);
    var days = parseInt(Math.abs(enddate - startdate) / 1000 / 60 / 60 / 24);
    return (days >= 0 ? (days + 1) : 0);
}
function do_close_dialog(fn, showtree) {
    $('#main_layoutframe').hide();
    $('#dialog_form').hide();
    $('#dialog_title2').text('');
    $('#dialog_frame2').attr("src", "");
    $('#dialog_frame2').css('height', '0px');
    $('#dialog_title1').text('');
    $('#dialog_frame1').attr("src", "");
    $('#dialog_frame1').css('height', '0px');
    if (typeof fn == 'function') {
        fn.call(this);
    }
}
function do_open_dialog(title, url, hidetree, hideclose, height) {
    height = height || ($('body').height() - 10);
    if (hidetree) {
        $('#dialog_title2').text(title);
        $('#dialog_frame2').css('height', height + 'px');
        $('#dialog_frame2').css('top', '0px');
        $('#dialog_frame2').css('position', 'relative');
        $('#main_layoutframe').show();
        setTimeout(function () {
            $('#dialog_frame2').attr("src", url);
        }, 100);
    } else {
        $('#dialog_form').show();
        $('#dialog_title1').text(title);
        $('#dialog_frame1').css('height', height + 'px');
        $('#dialog_frame1').css('top', '0px');
        $('#dialog_frame1').css('position', 'relative');
        setTimeout(function () {
            $('#dialog_frame1').attr("src", url);
        }, 100);
    }
    $('.dialogtitle').hide();
    $('a.btn_dialog_close').hide();
}
function open_top_win(title, id, width, height, top, modal, closable, onClose) {
    modal = modal || false;
    closable = closable || false;
    top.$("<div id='" + id + "'></div>").appendTo("body").window({
        title: title,
        width: width,
        height: height,
        top: top,
        modal: modal,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        closable: closable,
        draggable: false,
        resizable: false,
        content: frame,
        onClose: onClose
    })
    top.$('#' + id).window('center');
}
function open_parent_win(title, id, frame, width, height, top, modal, closable, onClose) {
    modal = modal || false;
    closable = closable || false;
    parent.$("<div id='" + id + "'></div>").appendTo("body").window({
        title: title,
        width: width,
        height: height,
        top: top,
        modal: modal,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        closable: closable,
        draggable: false,
        resizable: false,
        content: frame,
        onClose: onClose
    })
    parent.$('#' + id).window('center');
}
function show_message(msg, type, callback, timeout) {
    setTimeout(function () {
        type = type || 'success';
        if (type == 'info') {
            type = 'warning';
        }
        timeout = timeout || 1000;
        top.$.messager.show({
            title: '',
            timeout: timeout,
            width: '100%',
            height: 30,
            msg: msg,
            showType: 'slide',
            style: {
                top: 0,
                textAlign: 'center',
                padding: '0px',
                borderRadius: '0px',
                zIndex: 9999
            }
        });
        setTimeout(function () {
            top.$('.messager-body').css('padding', '5px 0');
            top.$('.messager-body').css('width', 'auto');
            top.$('.messager-body').css('height', 'auto');
            top.$('.messager-body').css('background-color', '#00bcd4');
            top.$('.messager-body').css('color', '#fff');
            top.$('.messager-body').css('font-size', '14px');
            if (type == 'success') {
                top.$('.messager-body').css('background-color', '#03a9f4');
            }
            else if (type == 'warning') {
                top.$('.messager-body').css('background-color', '#ffc107');
            }
            else if (type == 'error') {
                top.$('.messager-body').css('background-color', '#e51c23');
            }
        }, 100);
        if (typeof callback == "function") {
            setTimeout(function () {
                callback();
            }, 200);
        }
    }, 100);
}
