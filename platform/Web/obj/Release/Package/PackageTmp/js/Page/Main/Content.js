var isUpdate = false;
$(function () {
    var $height = $(window).height();
    $("#myFrame").css("height", ($height - 100) + "px");
    $('body').bind('click', function () {
        try {
            top.hide_popup();
        } catch (e) {
        }
    })
})
function addChildWin(title, url, width, height, top, left, id, OnClose, modal) {
    $("<div id='" + id + "'></div>").appendTo("body").window({
        title: title,
        width: width,
        height: height,
        top: top,
        left: left,
        modal: modal,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        content: createFrame(url),
        onClose: OnClose
    });
}
function createFrame(url) {
    var s = '<iframe name="mainFrame" scrolling="auto" frameborder="0"  src="' + url + '" style="width:100%;height:99%;border:0;"></iframe>';
    return s;
}