var MaskUtil = (function () {

    var $mask, $maskMsg;

    var defMsg = '正在加载';

    function init(elem) {
        if (elem) {
            $mask = $("<div class=\"datagrid-mask mymask\" style=''></div>").appendTo(elem);
            $maskMsg = $("<div class=\"datagrid-mask-msg mymask\" style=''>" + defMsg + "</div>")
                .appendTo(elem).css({ 'font-size': '12px' });
            var width = $(elem).outerWidth(true);
            var height = $(document).height();
            $mask.css({ width: width + 'px', height: height + 'px' });
            var msg_width = $('.datagrid-mask-msg').outerWidth(true);
            var maskheight = (height - 100) > 0 ? (height - 100) : height;
            $maskMsg.css({
                left: (width - msg_width) / 2, top: (maskheight) / 2,
            });
        }
        else {
            $mask = $("<div class=\"datagrid-mask mymask\" style=''></div>").appendTo("body");
            $maskMsg = $("<div class=\"datagrid-mask-msg mymask\" style=''>" + defMsg + "</div>")
                .appendTo("body").css({ 'font-size': '12px' });
            $mask.css({ width: "100%", height: $(document).height() });

            $maskMsg.css({
                left: ($(document.body).outerWidth(true) - 190) / 2, top: ($(window).height() - 45) / 2,
            });
        }
    }

    return {
        mask: function (elem, msg) {
            init(elem);
            $mask.show();
            $maskMsg.html(msg || defMsg).show();
        }
        , unmask: function () {
            $mask.remove();
            $maskMsg.remove();
        }
    }

}());
