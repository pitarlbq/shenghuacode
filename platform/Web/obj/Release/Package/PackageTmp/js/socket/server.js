var app = require('express')();
var http = require('http').Server(app);
var io = require('socket.io')(http);

app.get('/', function (req, res) {
    res.send('<h1>Welcome</h1>');
});

//�����û� 
var onlineUsers = {};
//��ǰ�������� 
var onlineCount = 0;

io.on('connection', function (socket) {
    console.log('a user connected');

    //�������û����� 
    socket.on('login', function (obj) {
        //���¼����û���Ψһ��ʶ����socket�����ƣ������˳���ʱ����õ� 
        socket.guid = obj.guid;
        socket.loginname = obj.loginname;

        //��������б������������ͼ��� 
        if (!onlineUsers.hasOwnProperty(obj.guid)) {
            onlineUsers[obj.guid] = obj.loginname;
            //��������+1 
            onlineCount++;
        }
        //�����пͻ��˹㲥�û����� 
        //io.emit('login', { onlineUsers: onlineUsers, onlineCount: onlineCount, user: obj });
        console.log(obj.loginname + ' in');
    });

    //�����û��˳� 
    socket.on('disconnect', function () {
        //���˳����û��������б���ɾ�� 
        if (onlineUsers.hasOwnProperty(socket.guid)) {
            //�˳��û�����Ϣ 
            var obj = { guid: socket.guid, loginname: socket.loginname };

            //ɾ�� 
            delete onlineUsers[socket.guid];
            //��������-1 
            onlineCount--;

            //�����пͻ��˹㲥�û��˳� 
            //io.emit('logout', { onlineUsers: onlineUsers, onlineCount: onlineCount, user: obj });
            console.log(obj.loginname + ' out');
        }
    });

    //�����û������������� 
    socket.on('message', function (obj) {
        //�����пͻ��˹㲥��������Ϣ 
        io.emit('message', obj);
        //console.log(obj.loginname);
    });
});

http.listen(3000, function () {
    console.log('listening on *:3000');
});