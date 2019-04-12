window.Foresight = window.Foresight || {};
(function(ns) {
    ns.Util = {};
    ns.Util.JsonResponseCode = {
        UNAUTHORIZED: -100,
        SUCCEED: 0
    };
    ns.Util.getCookie = function(name) {
        var strcookie = document.cookie; //获取cookie字符串
        var arrcookie = strcookie.split("; "); //分割
        //遍历匹配
        for (var i = 0; i < arrcookie.length; i++) {
            var arr = arrcookie[i].split("=");
            if (arr[0] == name) {
                return arr[1];
            }
        }
        return "";
    }
    ns.Util.getOpenID = function() {
        // return ns.Util.getCookie('wxopenid');
        return 'oGLPs50_MxKwyXL9ZX097Ghg5LIc';
    }
    ns.Util.checkWechatBrowser = function() {
        var ua = navigator.userAgent.toLowerCase();
        if (ua.indexOf('micromessenger') != -1) {
            return true;
        } else {
            return false;
        }
    }
    ns.Util.ajax = function(options) {
        options.url = CONFIG.apiurl;
        var post_form = options.data;
        post_form.wxopenid = ns.Util.getOpenID();
        var opt = null;
        if (/post/ig.test(options.type)) {
            opt = {
                url: options.url,
                method: options.type,
                cache: false,
                dataType: 'json',
                data: post_form
            };
        } else {
            var arr = [];
            for (var key in post_form) {
                arr.push(key + '=' + encodeURIComponent(post_form[key]));
            }
            if (arr.length) {
                if (!/\?/.test(options.url)) {
                    options.url = options.url + '?' + arr.join('&');
                } else {
                    if (/[\?\&]$/.test(url)) {
                        options.url = options.url + arr.join('&');
                    } else {
                        options.url = options.url + '&' + arr.join('&');
                    }
                }
            }
            opt = {
                url: options.url,
                method: options.type || 'get',
                cache: false,
                dataType: 'json'
            };
        }
        var toast;
        if (options.toast) {
            toast = new auiToast();
            options.toastmsg = options.toastmsg || '加载中';
            toast.loading({
                title: options.toastmsg,
                duration: 2000
            }, function(ret) {});
        }
        jQuery.ajax(jQuery.extend(true, {}, opt, {
            success: function(data, textStatus) {
                // if (options.toast) {
                //     toast.hide();
                // }
                if (data == undefined || data == null) {
                    try {
                        console.error(options.url);
                    } catch (e) {}
                    throw new Error("Ajax response null.");
                } else if (typeof data.Code == "undefined") {
                    try {
                        console.error(data);
                    } catch (e) {}
                    throw new Error("Incorrect json data.");
                } else if (data.Code == ns.Util.JsonResponseCode.SUCCEED) {
                    if (typeof options.success == "function")
                        try {
                            options.success.call(this, data.Result, textStatus); //调用指定的成功处理函数
                        } catch (e) {}
                } else if (data.Code == ns.Util.JsonResponseCode.UNAUTHORIZED) {
                    if (typeof options.success == "function")
                        try {} catch (e) {}
                } else if (data.Code < 0) {
                    if (typeof options.error == 'function')
                        try {
                            options.error.call(this, data.Error, textStatus); //调用指定的错误处理函数
                        } catch (e) {}
                } else {
                    throw new Error("Unknown json code: " + data.Code + ".");
                }
            },
            error: function(XMLHttpRequest, textStatus, errorThrown) {
                if (options.toast) {
                    toast.hide();
                }
                if (typeof options.error == 'function') {
                    options.error.call(this, errorThrown, textStatus);
                }
            },
            complete: function(XMLHttpRequest, textStatus) {
                if (options.toast) {
                    toast.hide();
                }
                if (typeof options.complete == 'function') {
                    options.complete.call(this, XMLHttpRequest, textStatus);
                }
            }
        }));
    };
    ns.Util.extend = function(o, n) {
        for (var p in n) {
            if (n.hasOwnProperty(p) && (!o.hasOwnProperty(p)))
                o[p] = n[p];
        }
        return o;
    };
    ns.Util.post = function(data, callback, options) {
        if (!options) {
            options = {};
        }
        return ns.Util.ajax(ns.Util.extend(options, {
            cache: false,
            success: function(result, textStatus) {
                if (typeof callback == "function") callback(true, result, null);
            },
            error: function(err, textStatus) {
                if (typeof callback == "function") callback(false, null, err);
            },
            url: (options && options.url) || '',
            data: data,
            type: 'POST'
        }));
    };
    //callback: funtion(succeed,data,error){};
    ns.Util.get = function(data, callback, options) {
        if (!options) {
            options = {};
        }
        return ns.Util.ajax(ns.Util.extend(options, {
            cache: false,
            success: function(result, textStatus) {
                if (typeof callback == "function") callback(true, result, null);
            },
            error: function(err, textStatus) {
                if (typeof callback == "function") callback(false, null, err);
            },
            url: (options && options.url) || '',
            data: data,
            type: 'GET'
        }));
    };
    ns.Util.wxJsConfig = function() {
        var that = this;
        ns.Util.post({ action: 'getjsconfig', url: ns.Util.getCurrentUrl() }, function(succeed, data, err) {
            if (succeed) {
                data.debug = false;
                data.jsApiList = [
                    'updateAppMessageShareData',
                    'updateTimelineShareData',
                    'onMenuShareTimeline', //分享到朋友圈
                    'onMenuShareAppMessage', //分享给朋友
                    'onMenuShareQQ', //分享到QQ
                    'onMenuShareWeibo', //腾讯微博
                    'onMenuShareQZone' //QQ空间
                ];
                wx.config(data);
                setTimeout(function() {
                    ns.Util.doShareReady();
                }, 1000);
            } else if (err) {
                ns.Util.toast(err);
            }
        }, { toast: false })
    };
    ns.Util.doShareReady = function() {
        return;
        var title = '';
        var desc = '';
        var link = '';
        var imgUrl = '';
        wx.ready(function() {
            wx.onMenuShareTimeline({
                title: title, // 分享标题
                link: link, // 分享链接，该链接域名或路径必须与当前页面对应的公众号JS安全域名一致
                imgUrl: imgUrl, // 分享图标
                success: function() {
                    // 用户点击了分享后执行的回调函数
                },
            });
            wx.onMenuShareAppMessage({
                title: title, // 分享标题
                desc: desc, // 分享描述
                link: link, // 分享链接，该链接域名或路径必须与当前页面对应的公众号JS安全域名一致
                imgUrl: imgUrl, // 分享图标
                type: 'link', // 分享类型,music、video或link，不填默认为link
                dataUrl: '', // 如果type是music或video，则要提供数据链接，默认为空
                success: function() {
                    // 用户点击了分享后执行的回调函数
                }
            });
            wx.updateAppMessageShareData({
                title: title,
                desc: desc,
                link: link,
                imgUrl: imgUrl,
                success: function() {

                }
            });
            wx.updateTimelineShareData({
                title: title,
                link: link,
                imgUrl: imgUrl,
                success: function() {}
            });
        });
    };
    ns.Util.getQueryString = function(key) {
        var vars = [],
            hash;
        var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
        for (var i = 0; i < hashes.length; i++) {
            hash = hashes[i].split('=');
            vars.push(hash[0]);
            vars[hash[0]] = window.decodeURIComponent(hash[1]);
        }
        return !!key ? vars[key] : vars;
    };
    ns.Util.getCurrentUrl = function() {
        var hashes = window.location.href.split('#');
        return hashes[0];
    };
    ns.Util.alert = function(options, callback) {
        var title = options.title || '提示';
        var msg = options.msg || '提示';
        var buttons = options.buttons || ['确定'];
        var dialog = new auiDialog();
        dialog.alert({
            title: title,
            msg: msg,
            buttons: buttons
        }, function(ret) {
            if (callback) {
                if (typeof callback == "function") {
                    callback();
                }
            }
        });
    }
    ns.Util.toast = function(msg) {
        setTimeout(function() {
            var toast = new auiToast();
            msg = msg || '提交成功';
            toast.toast({
                title: msg,
                html: '',
                duration: 1000
            });
        }, 500);
    }
    ns.Util.confirm = function(options, callback) {
        var title = options.title || '提示';
        var msg = options.msg || '提示';
        var buttons = options.buttons || ['关闭', '确定'];
        var dialog = new auiDialog();
        dialog.alert({
            title: title,
            msg: msg,
            buttons: buttons
        }, function(ret) {
            if (ret.buttonIndex == 2) {
                if (callback) {
                    if (typeof callback == "function") {
                        callback();
                    }
                }
            }
        })
    }
    ns.Util.openWin = function(url, need_domain) {
        if (url.indexOf('tel:') > -1) {
            top.window.location.href = url;
            return;
        }
        if (need_domain) {
            top.window.location.href = CONFIG.domainurl + url;
            return;
        }
        var t = (new Date()).valueOf();
        if (url.indexOf('?') > -1) {
            url += '&t=' + t;
        } else {
            url += '?t=' + t;
        }
        top.window.location.href = url;
    }
    ns.Util.openCurrentWin = function(url, need_domain) {
        if (url.indexOf('tel:') > -1) {
            window.location.href = url;
            return;
        }
        if (need_domain) {
            window.location.href = CONFIG.domainurl + url;
            return;
        }
        var t = (new Date()).valueOf();
        if (url.indexOf('?') > -1) {
            url += '&t=' + t;
        } else {
            url += '?t=' + t;
        }
        window.location.href = url;
    }
    ns.Util.check_mobile = function(phonenumber) {
        var that = this;
        if (!(/^1[3|4|5|7|8|9][0-9]\d{4,8}$/.test(phonenumber))) {
            return false;
        }
        return true;
    }
    ns.Util.StringToDate = function(dateString) {
        try {
            if (dateString) {
                var date = new Date(dateString.replace(/-/, "/").replace('T', ' '));
                return date;
            }
        } catch (e) {

        }
        return ''
    };
    ns.Util.getDateString = function(dt) {
        if (dt.valueOf() <= -62135596800000) {
            return null;
        }
        var y = dt.getFullYear(),
            M = dt.getMonth() + 1,
            d = dt.getDate();
        return [y, M < 10 ? "0" + M : M, d < 10 ? "0" + d : d].join("-");
    };
    ns.Util.getTimeString = function(dt) {
        if (dt.valueOf() <= -62135596800000) {
            return null;
        }
        var H = dt.getHours();
        var m = dt.getMinutes();
        return (H < 10 ? '0' + H : H) + ':' + (m < 10 ? '0' + m : m);
    };
})(window.Foresight);
$(function() {
    var ns = window.Foresight.Util;
    if (!ns.checkWechatBrowser()) {
        // top.window.location.href = '../weixin_alert.html';
        return;
    }
})