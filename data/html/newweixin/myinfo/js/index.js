$(function() {
    var ns = window.Foresight.Util;
    var app = new Vue({
        el: '#app',
        data: {
            userinfo: { headimg: '', headname: '' },
        },
        methods: {
            get_data: function() {
                var that = this;
                ns.post({ action: 'getmyinfo' }, function(succeed, data, err) {
                    if (succeed) {
                        that.userinfo = data.userinfo;
                    } else if (err) {
                        ns.toast(err);
                    }
                }, { toast: true })
            },
            do_view_challenge: function() {
                var that = this;
                ns.openWin('../myinfo/mychallenge.html');
            },
            do_view_baby: function() {
                var that = this;
                ns.openWin('../myinfo/babyinfo.html');
            }
        }
    });
    app.get_data();
})