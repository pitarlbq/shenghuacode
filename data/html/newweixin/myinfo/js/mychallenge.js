$(function() {
    var ns = window.Foresight.Util;
    var app = new Vue({
        el: '#app',
        data: {
            form: {
                totalsuccess: 10,
                totalfail: 2,
                totalison: 0
                // totalpoint: 30
            },
            list: []
        },
        methods: {
            get_data: function() {
                var that = this;
                ns.post({ action: 'getmychallengelist' }, function(succeed, data, err) {
                    if (succeed) {
                        that.form = data.form;
                        that.list = data.list;
                        for (var i = 0; i < that.list.length; i++) {
                            that.leftTimer(that.list[i]);
                        }
                    } else if (err) {
                        ns.toast(err);
                    }
                }, { toast: true })
            },
            do_view: function(item) {
                var that = this;
                if (item.status == 2 || item.status == 3) {
                    ns.openWin('../challenge/startchallenge.html?id=' + item.id);
                    return;
                }
                if (item.status == 1) {
                    ns.openWin('../challenge/challengesuccess.html?id=' + item.id);
                    return;
                }
            },
            leftTimer: function(item) {
                var that = this;
                if (!item.countdownenable) {
                    clearInterval(item.countdown_timmer);
                    return;
                }
                var s1 = new Date(item.countdowndate.replace(/-/g, "/"));
                item.leftTime = s1 - new Date(); //计算剩余的毫秒数 
                item.countdown_timmer = setInterval(function() {
                    that.do_leftTimer(item);
                }, 1000);
            },
            do_leftTimer: function(item) {
                var that = this;
                if (!item.countdownenable) {
                    clearInterval(item.countdown_timmer);
                    return;
                }
                item.leftTime = item.leftTime - 1000;
                if (item.leftTime <= 0) {
                    if (item.countdown_timmer != null) {
                        clearInterval(item.countdown_timmer);
                    }
                    return;
                }
                var days = parseInt(item.leftTime / 1000 / 60 / 60 / 24, 10); //计算剩余的天数 
                var hours = days * 24 + parseInt(item.leftTime / 1000 / 60 / 60 % 24, 10); //计算剩余的小时 
                var minutes = parseInt(item.leftTime / 1000 / 60 % 60, 10); //计算剩余的分钟 
                var seconds = parseInt(item.leftTime / 1000 % 60, 10); //计算剩余的秒数 
                days = that.checkTime(days);
                hours = that.checkTime(hours);
                minutes = that.checkTime(minutes);
                seconds = that.checkTime(seconds);
                var result = hours + '小时' + minutes + '分' + seconds + '秒';
                item.countdownday = result;
            },
            checkTime: function(i) { //将0-9的数字前面加上0，例1变为01 
                if (i < 10) {
                    i = "0" + i;
                }
                return i;
            }
        }
    });
    app.get_data();
})