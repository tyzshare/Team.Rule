//普通提示
window._alert = function (message) {
    layer.msg(message);
}
//关闭所有弹窗
window._close = function () {
    layer.closeAll();
}
//成功提示
window._success = function (message) {
    layer.msg(message);
}
//警告提示
window._warning = function (message) {
    layer.msg(message);
}
//数字监听
window._monitorWrite = function (obj, size, msg) {
    if ($(obj) != null) {
        var length = $(obj).val().length;
        if (length < size) {
            $("#" + msg + "").html(length);
        }
        else {
            $("#" + msg + "").html(size);
        }
    }
}