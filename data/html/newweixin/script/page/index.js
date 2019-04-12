var ns = window.Foresight.Util,
    popup;
$(function() {
    var app = new Vue({
        el: '#app',
        data: {
            footer_menus: [{ css: 'icon-jiangli', title: '挑战', url: 'challenge/index.html', ActiveCss: 'aui-active' },
                { css: 'icon-wode1', title: '我的', url: 'myinfo/index.html', ActiveCss: '' }
            ],
            currentindex: 0,
            currenturl: '',
            xiaoquname: '',
            xiaoqulist: [],
            canchat: false,
        },
        methods: {
            set_menu: function() {
                var that = this;
                $.each(that.footer_menus, function(index, menu) {
                    menu.ActiveCss = '';
                    if (index == that.currentindex) {
                        menu.ActiveCss = 'aui-active';
                        var t = (new Date()).valueOf();
                        that.currenturl = menu.url + '?t=' + t;
                        document.title = menu.title;
                    }
                })
                var height = $(window).height();
                var footer_height = $('#footer').height();
                $('#main_frame').css('height', (height - footer_height) + 'px');
            },
            open_footer_item: function(index) {
                var that = this;
                that.currentindex = index;
                ns.openCurrentWin('./index.html?index=' + index);
            }
        }
    });
    app.currentindex = ns.getQueryString('index') || 0;
    app.set_menu();
    app.get_data();
})