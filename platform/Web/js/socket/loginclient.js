(function () {
    var d = document,
    w = window;
    w.LoginConnect = {
        loginname: null,
        url: null,
        guid: null,
        socket: null,
        socketserver: null,
        systemtype: 'platform',
        action: '',
        submit: function () {
            var obj = {
                loginname: this.loginname,
                guid: this.guid,
                url: this.url,
                systemtype: this.systemtype,
                action: this.action
            };
            this.socket.emit('message', obj);
            return false;
        },
        logout: function () {
            this.socket.disconnect();
        },
        init: function (data) {
            this.loginname = data.loginname;
            this.url = data.url;
            this.guid = data.guid;
            this.socketserver = data.socketserver;
            this.action = data.action;
            //连接websocket后端服务器 
            this.socket = io.connect(this.socketserver);

            //告诉服务器端有用户登录 
            this.socket.emit('login', { loginname: this.loginname, url: this.url, guid: this.guid });

            ////监听消息发送 
            this.socket.on('message', function (obj) {
                if (obj.action == 'notifyalert') {
                    var canpop = false;
                    if (obj.systemtype == LoginConnect.systemtype && obj.url == LoginConnect.url) {
                        canpop = true;
                    }
                    if (canpop) {
                        socket_notify(obj);
                    }
                    return;
                }
            });
        }
    };
})();