var Util = {};
(function (Util, $) {
    Util.resolveUrl = function (relativePage) {
        if (!relativePage || !relativePage.length) {
            return null;
        }

        if (relativePage[0] == "/") {
            return window.location.origin + relativePage;
        }
        if (relativePage[0] == ".") {
            var path = [];
            path.push(window.location.origin);
            if (window.location.pathname) {
                var arr = window.location.pathname.split('/');
                for (var i = 0; i < arr.length - 1; i++) {
                    if (arr[i]) {
                        path.push(arr[i]);
                    }
                }
            }
            var arr = relativePage.split('/'); // ./../../test.html
            var index = 0;
            for (; index < arr.length; index++) {
                if (arr[index] == "..") {
                    if (path.length > 1) {
                        path.pop();
                    }
                } else if (arr[index] == ".") {
                } else {
                    break;
                }
            }
            if (index < arr.length) {
                path = path.concat(arr.slice(index));
            }
            return path.join('/');
        }
        return relativePage;
    };
    Util.getQueryString = function (key) {
        var vars = [], hash;
        var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
        for (var i = 0; i < hashes.length; i++) {
            hash = hashes[i].split('=');
            vars.push(hash[0]);
            vars[hash[0]] = window.decodeURIComponent(hash[1]);
        }
        return !!key ? vars[key] : vars;
    };
    Util.showLoading = function (options) {
        Util.showLoading._id = Util.showLoading._id || 0;
        Util.showLoading._id++;
        var id = Util.showLoading._id;
        $('<div loading="' + id + '" class="loading" style="background-color:#333;opacity:0.3;position:fixed;z-index:999;width:100%;height:100%;top:0;left:0;text-align:center;"></div>').appendTo("body");
        return id;
    };
    Util.hideLoading = function (id) {
        if (id) {
            $('body>[loading="' + id + '"]').remove();
        } else {
            $('body>[loading]').remove();
        }
    };
    Util.toast = function (msg, showmilliseconds, callback) {
        if (!Util.toast._inited) {
            $('body').bind('touchstart', function () { Util.clearToast(); })
            $('body').bind('mousedown', function () { Util.clearToast(); })
            Util.toast._inited = true;
        }
        if (Util.toast._toast) {
            Util.toast._toast.remove();
            Util.toast._toast = null;
        }
        showmilliseconds = showmilliseconds || 3000;
        if (isNaN(showmilliseconds)) {
            switch (showmilliseconds) {
                case "short":
                    showmilliseconds = 1000;
                    break;
                case "long":
                    showmilliseconds = 5000;
                    break;
                case "normal":
                default:
                    showmilliseconds = 3000;
            }
        }
        Util.toast._toast = $('<div class="toast"><span class="content">' + msg + '<span></div>');
        Util.toast._toast.appendTo("body");
        debugger;
        setTimeout(function () {
            if (Util.toast._toast) {
                Util.toast._toast.animate({ opacity: 0 }, 300, function () {
                    if (Util.toast._toast) {
                        Util.toast._toast.remove();
                    }
                    Util.toast._toast = null;
                });
                if (typeof callback == "function") {
                    callback();
                }
            }
        }, showmilliseconds - 0);
    };
    Util.clearToast = function () {
        if (Util.toast._toast) {
            Util.toast._toast.remove();
            Util.toast._toast = null;
        }
    };
    Util.JsonResponseCode = {
        UNAUTHORIZED: -100,
        SUCCEED: 0
    };
    Util.ajax = function (options) {
        var overlay = null;
        if (options.autoOverlay) {
            var w = window;
            try {
                if (options.overlay) {
                    if ($(options.overlay).length) {
                        w = options.overlay;
                    } else {
                        var arr = options.overlay.split('.');
                        for (var i = 0, item; item = arr[i]; i++) {
                            var tmp = w[item];
                            if (tmp) {
                                w = tmp;
                            } else {
                                break;
                            }
                        }
                    }
                }
            } catch (e) {
            }
            if (w.document) {
                overlay = $('<div class="ui-overlay-loading"></div>').appendTo(w.document.body || "body");
            } else {
                overlay = $('<div class="ui-overlay-loading"></div>').appendTo(w);
            }
        }
        options.url = Util.resolveUrl(options.url || window.location.href.replace(/\?.*$/, ""));
        return jQuery.ajax(jQuery.extend(true, {}, options, {
            dataType: "json",
            success: function (data, textStatus) {
                if (data == undefined || data == null) {
                    try {
                        console.error(options.url);
                    } catch (e) {
                    }
                    throw new Error("Ajax response null.");
                } else if (typeof data.Code == "undefined") {
                    try {
                        console.error(data);
                    } catch (e) {
                    }
                    throw new Error("Incorrect json data.");
                }
                else if (data.Code == Util.JsonResponseCode.UNAUTHORIZED) {/* 需要登录（cookie超时） */
                    Util.toast('身份验证失败，请重新登录');
                } else if (data.Code == Util.JsonResponseCode.SUCCEED) {
                    if (typeof options.success == "function")
                        options.success.call(this, data.Result, textStatus); //调用指定的成功处理函数
                } else if (data.Code < 0) {
                    if (typeof options.error == 'function')
                        options.error.call(this, data.Error, textStatus); //调用指定的错误处理函数
                } else {
                    throw new Error("Unknown json code: " + data.Code + ".");
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                if (typeof options.error == 'function') {
                    options.error.call(this, errorThrown, textStatus);
                }
            }, complete: function (XMLHttpRequest, textStatus) {
                if (overlay) {
                    overlay.remove();
                }
                if (typeof options.complete == 'function') {
                    options.complete.call(this, XMLHttpRequest, textStatus);
                }
            }
        }));
    };
    //callback: funtion(succeed,data,error){};
    Util.post = function (data, callback, options) {
        return Util.ajax($.extend(true, {
            cache: false,
            success: function (result, textStatus) {
                if (typeof callback == "function") callback(true, result, null);
            },
            error: function (err, textStatus) {
                if (typeof callback == "function") callback(false, null, err);
            },
            url: (options && options.url) || '',
            data: data,
            type: 'POST'
        }, options));
    };
    //callback: funtion(succeed,data,error){};
    Util.get = function (data, callback, options) {
        return Util.ajax($.extend(true, {
            cache: false,
            success: function (result, textStatus) {
                if (typeof callback == "function") callback(true, result, null);
            },
            error: function (err, textStatus) {
                if (typeof callback == "function") callback(false, null, err);
            },
            url: (options && options.url) || '',
            data: data,
            type: 'GET'
        }, options));
    };
    Util.showLoading = function (options) {
        Util.showLoading._id = Util.showLoading._id || 0;
        Util.showLoading._id++;
        var id = Util.showLoading._id;
        $('<div loading="' + id + '" class="loading" style="background-color:#333;opacity:0.3;position:fixed;z-index:999;width:100%;height:100%;top:0;left:0;text-align:center;"></div>').appendTo("body");
        return id;
    };
    Util.hideLoading = function (id) {
        if (id) {
            $('body>[loading="' + id + '"]').remove();
        } else {
            $('body>[loading]').remove();
        }
    };
    Util.toast = function (msg, showmilliseconds, callback) {
        if (!Util.toast._inited) {
            $('body').bind('touchstart', function () { Util.clearToast(); })
            $('body').bind('mousedown', function () { Util.clearToast(); })
            Util.toast._inited = true;
        }
        if (Util.toast._toast) {
            Util.toast._toast.remove();
            Util.toast._toast = null;
        }
        showmilliseconds = showmilliseconds || 3000;
        if (isNaN(showmilliseconds)) {
            switch (showmilliseconds) {
                case "short":
                    showmilliseconds = 1000;
                    break;
                case "long":
                    showmilliseconds = 5000000;
                    break;
                case "normal":
                default:
                    showmilliseconds = 3000;
            }
        }
        Util.toast._toast = $('<div class="toast"><span class="content">' + msg + '<span></div>');
        Util.toast._toast.appendTo("body");
        setTimeout(function () {
            if (Util.toast._toast) {
                Util.toast._toast.animate({ opacity: 0 }, 300, function () {
                    if (Util.toast._toast) {
                        Util.toast._toast.remove();
                    }
                    Util.toast._toast = null;
                });
                if (typeof callback == "function") {
                    callback();
                }
            }
        }, showmilliseconds - 0);
    };
    Util.clearToast = function () {
        if (Util.toast._toast) {
            Util.toast._toast.remove();
            Util.toast._toast = null;
        }
    };
    Util.parseDateTime = function (dtString, dateformat) {
        if (!isNaN(dtString)) {
            return new Date(dtString - 0);
        }
        if (!dtString) {
            throw "Invalid dtString for ParseDateTime.";
        }
        //for JavaScriptSerializer.Serialize
        if (/\/Date\((\-?\d+)\)\//.test(dtString)) {
            return new Date(dtString.replace(/\/Date\((\-?\d+)\)\//, "$1") - 0);
        }
        dateformat = dateformat || "yyyy-MM-dd";
        //"2012-10-24 12:11:10.999".match(reg)
        //["2012-10-24 12:11:10.999", "2012", "10", "24", " 12:11:10.999", "12", "11", "10", ".999", "999"]
        var reg = /(\d+)[\/\-](\d+)[\/\-](\d+)( (\d+)\:(\d+)\:(\d+)(\.(\d+))*)*/;
        var m = dtString.match(reg);
        if (m) {
            var dt = null;
            var year, month, date;
            if (/[y]+[\/\-][m]+[\/\-][d]+/i.test(dateformat)) {/* yyyy-MM-dd */
                year = m[1];
                month = m[2];
                date = m[3];
            } else if (/[m]+[\/\-][d]+[\/\-][y]+/i.test(dateformat)) {/* MM/dd/yyyy */
                year = m[3];
                month = m[1];
                date = m[2];
            } else if (/[d]+[\/\-][m]+[\/\-][y]+/i.test(dateformat)) {/* dd/MM/yyyy */
                year = m[3];
                month = m[2];
                date = m[1];
            } else {
                throw "Invalid dateformat for ParseDateTime.";
            }
            if (year && month < 13 && date < 32) {
                dt = new Date(year - 0, month - 1, date - 0);
            } else {
                throw "Invalid dtString for ParseDateTime.";
            }
            if (dt) {
                if (m[4]) {
                    dt.setHours(m[5] - 0);
                    dt.setMinutes(m[6] - 0);
                    dt.setSeconds(m[7] - 0);
                }
                if (m[8]) {
                    dt.setMilliseconds(m[9].replace(/^(\d{1,3})(\d*)/, "$1") - 0);
                }
            }
            return dt;
        }
        throw "Invalid dtString for ParseDateTime.";
    };
    Util.getTimeString = function (dt, ignoreMilliseconds) {
        if (dt.valueOf() <= -62135596800000) {
            return null;
        }
        var y = dt.getFullYear(), M = dt.getMonth() + 1, d = dt.getDate(), h = dt.getHours(), m = dt.getMinutes(), s = dt.getSeconds(), f = dt.getMilliseconds()
        return [y, M < 10 ? "0" + M : M, d < 10 ? "0" + d : d].join("-") + " " + [h < 10 ? "0" + h : h, m < 10 ? "0" + m : m, s < 10 ? "0" + s : s].join(":") + (ignoreMilliseconds ? "" : ("." + f));
    };
    Util.getDateString = function (dt, format) {
        if (dt.valueOf() <= -62135596800000) {
            return null;
        }
        var y = dt.getFullYear(), M = dt.getMonth() + 1, d = dt.getDate();
        return [y, M < 10 ? "0" + M : M, d < 10 ? "0" + d : d].join("-");
    };
    Util.getFormData = function (form) {
        if (form && form.elements) {
            var result = {};
            $.each(form.elements, function (index, elem) {
                if (elem.name) {
                    var skip = false;
                    var v = elem.value;
                    switch (elem.type) {
                        case "checkbox":
                            skip = !elem.checked;
                            break;
                        case "radio":
                            skip = !elem.checked;
                            break;
                        case "button": break;
                        case "file": break;
                        case "hidden": break;
                        case "password": break;
                        case "reset": break;
                        case "select-one": break;
                        case "select-multiple": break;
                        case "submit": break;
                        case "text": break;
                        case "textarea": break;
                    }
                    if (!skip) {
                        if (result[elem.name]) {
                            result[elem.name].push(v);
                        } else {
                            result[elem.name] = [v];
                        }
                    }
                }
            });
            return result;
        }
        return null;
    };
    Util.setFields = function (element, data) {
        data = data || {};
        $(element).find('[field]').each(function (index, elem) {
            elem = $(elem);
            var v = data[elem.attr('field')];
            if (v == null || typeof v == "undefined") {
                v = "";
            }
            if (elem.is("input,select,textarea")) {
                elem.val(v);
            } else if (elem.is("img")) {
                elem.attr('src', v);
            } else {
                elem.html(v);
            }
        });
    },
    Util.getFields = function (element) {
        var obj = {};
        $(element).find('[field]').each(function (index, elem) {
            elem = $(elem);
            obj[elem.attr('field')] = elem.val();
        });
        return obj;
    };
    Util.openWindow = function (url, width, height, features, name) {
        var f = $.extend(true, { width: width, height: height, left: (window.screen.width - width) / 2, top: Math.min(30, (window.screen.height - height) / 2) }, features);
        var arr = [];;
        for (var k in f) {
            arr.push(k + "=" + f[k]);
        }
        window.open(url, name || "popwinow", arr.join(","));
    };
    Util.showImage = function (imgs) {
        if (imgs) {
            var opt = {
                buildHtml: function () {
                    var html = [];
                    html.push('<div class="dialog-mask"><table style="width:100%;height:80%; margin-top:10%;">')
                    html.push('<tr><td></td></tr><tr><td style="overflow:hidden;"><img src="' + imgs + '" style="width:100%;  max-height:400px;" /></td></tr><tr><td></td></tr>')
                    html.push('</table></div>')
                    return html.join('');
                }
            }
            Util.dialog(opt);
        }
    };
    Util.dialog = function (options) {
        options = $.extend(true, {
            title: '',
            content: '',
            buildHtml: function () {
                var _html = '<div class="dialog-mask ' + (options.className || "") + '"><div class="dialog">';
                if (options.title) {
                    _html += '<div class="dialog-title">' + options.title + '</div>';
                }
                if (options.content) {
                    _html += '<div class="dialog-content">' + options.content + '</div>';
                }
                if (options.buttons) {
                    _html += '<div class="dialog-buttons"></div></div></div>';
                }
                return _html;
            }
        }, options);
        var wrapper = $(options.buildHtml());
        var hideDialog = function () {
            if (wrapper) {
                wrapper.remove();
                wrapper = null;
            }
        };
        wrapper.get(0).hideDialog = hideDialog;
        var index = 0;
        for (var k in options.buttons) {
            $('<a class="dialog-button ' + (!index ? "dialog-button-first" : "") + '">' + k + '</a>').appendTo(wrapper.find(".dialog-buttons")).bind('click', (function (callback) {
                return function () {
                    if (callback.call(this, wrapper.get(0), options) !== false) {
                        hideDialog();
                    }
                };
            })(options.buttons[k]));
            index++;
        }

        wrapper.bind('touchstart', function (event) {
            if (event.currentTarget == event.target) {
                event.preventDefault();
                event.stopPropagation();
                hideDialog();

            }
        });
        wrapper.appendTo("body");
        if (typeof (options.onshow) == "function") {
            setTimeout(function () {
                options.onshow.call(this, wrapper.get(0));
            }, 0);
        }
        return wrapper.get(0);
    };
    Util.String = {
        trim: function (oldstr) {
            if (oldstr)
                return oldstr.replace(/(^\s\s*)|(\s*\s)/ig, '');
            return oldstr;
        },
        trimStart: function (oldstr) {
            if (oldstr)
                return oldstr.replace(/(^\s\s*)/ig, '');
            return oldstr;
        },
        trimEnd: function (oldstr) {
            if (oldstr)
                return oldstr.replace(/(\s*\s)/ig, '');
            return oldstr;
        }
    };
    Util.loadObjects = function (elem, key, idarr) {
        var container = {};
        $.each(eval("(" + $(elem)[0].innerHTML + ")"), function () {
            container[this[key]] = this;
            if (idarr) {
                idarr.push(this[key]);
            }
        });
        return container;
    };
})(Util, jQuery);