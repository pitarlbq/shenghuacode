$(function() {
    var ns = window.Foresight.Util;
    var app = new Vue({
        el: '#app',
        data: {
            list: [{
                id: 1,
                sex: 1,
                birthday: ''
            }, ],
        },
        methods: {
            get_data: function() {
                var that = this;

            },
            do_add: function() {
                var that = this;
                if (that.list.length == 2) {
                    ns.toast('只能保存两个孩子信息');
                    return;
                }
                that.list.push({ id: 0, sex: 1, birthday: '' });
            },
            do_save: function() {
                var that = this;
                ns.toast('保存成功');
            }
        }
    });
    app.get_data();
})