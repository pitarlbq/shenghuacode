using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocketIOClient;
using Quobject.SocketIoClientDotNet.Client;
using Newtonsoft.Json.Linq;
using Utility;

namespace SocketIOClient
{
    public class SocketClient
    {
        public static Socket socket = null;
        public static void Init()
        {
            try
            {
                if (socket != null)
                {
                    return;
                }
                socket = IO.Socket("http://" + new SiteConfig().SocketURL, new IO.Options()
                {
                    Reconnection = true,
                    Timeout = 60000,
                    ReconnectionDelay = 1000,
                    AutoConnect = false,
                    ReconnectionAttempts = 3
                });
                socket.On(Socket.EVENT_CONNECT, () =>       //监听链接            
                {
                    LogHelper.WriteInfo("SocketClient.EVENT_CONNECT", "连接成功: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                });
                socket.On(Socket.EVENT_DISCONNECT, () =>
                {
                    LogHelper.WriteInfo("SocketClient.EVENT_DISCONNECT", "断开连接: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                });
                socket.On(Socket.EVENT_CONNECT_ERROR, () =>
                {
                    LogHelper.WriteInfo("SocketClient.EVENT_DISCONNECT", "连接出错: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                });
                socket.On(Socket.EVENT_CONNECT_TIMEOUT, () =>
                {
                    LogHelper.WriteInfo("SocketClient.EVENT_DISCONNECT", "连接超时: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                });
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("SocketClient", "Init()", ex);
            }
        }
        public static void EmitMsg(JObject obj)
        {
            Init();
            socket.Connect();
            socket.Emit("message", obj);
        }
    }
}
