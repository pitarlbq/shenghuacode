$(function() {

})

function init_js(pagejs) {
    create_script('../script/config.js');
    create_script('../script/common.js');
    if (pagejs) {
        setTimeout(function() {
            create_script(pagejs);
        }, 500)
    }
}
function create_script(jsurl) {
    var t = gettoken();
    var myScript = document.createElement("script");
    myScript.type = "text/javascript";
    myScript.src = jsurl + "?t=" + t;
    document.body.appendChild(myScript);
}

function gettoken() {
    return (new Date()).valueOf();
}