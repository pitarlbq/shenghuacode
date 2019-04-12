<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Login" EnableSessionState="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="renderer" content="webkit" />
    <title><%= this.CompanyName %></title>
    <link href="styles/basic.css" rel="stylesheet" type="text/css" />
    <link href="styles/page/login.css?v3" rel="stylesheet" />
    <script src="js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="js/util.js?v6" type="text/javascript"></script>
    <script type="text/javascript">
        var code; //在全局定义验证码 
        $(function () {
        });
    </script>
    <style>
        .logo {
            background-image: url("./styles/images/logo_1.png");
        }

        .login_bg {
            background-image: url("./styles/images/bg_2.png?v3");
        }

        .mainimg {
            background-image: url("./styles/images/bg_1.png?v1");
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
            <div class="top">
                <div class="logo"></div>
                <div class="right_menu">
                    <a href="#" class="aboutus">官方网站</a>
                    <a href="#" class="contactus">联系我们</a>
                </div>
            </div>
            <div class="mainimg"></div>
            <div class="login_bg">
            </div>
            <div class="loginbox">
                <div class="logo_center">
                    <img id="logo_center_img" src="./styles/images/logo_center.png" />
                </div>
                <div class="inputbox" style="margin-top: 10px;">
                    <asp:TextBox ID="tbLoginName" placeholder="支持邮箱手机号登录" runat="server" Style="border: none;"></asp:TextBox>
                </div>
                <div class="inputbox" style="margin-top: 10px;">
                    <asp:TextBox ID="tbPassword" placeholder="密码" TextMode="Password" runat="server" Style="border: none;"></asp:TextBox>
                </div>
                <div style="text-align: left; margin-top: 10px;">
                    <asp:CheckBox runat="server" ID="autoLogin" Text="下次自动登录" Style="font-size: 12px; color: #808080;" />
                </div>
                <div style="text-align: center; margin-top: 10px;">
                    <asp:Button CssClass="btnlogin" Text="登&nbsp;录" ID="btnLogin" runat="server" OnClientClick="return check();"
                        OnClick="btnLogin_Click" />
                </div>
                <div style="margin: 0 auto; text-align: center; padding: 10px 30px 0 30px;">
                    <asp:Label ID="lbMsg" runat="server" CssClass="err"></asp:Label>
                </div>
            </div>
            <div style="clear: both;"></div>
            <div class="bottom">
                <label>Copyright&copy;<%=DateTime.Now.Year %> 重庆永友网络有限公司,Inc.All Rights</label>
            </div>
        </div>
    </form>
    <script type="text/javascript">
        document.getElementById('<%= this.tbLoginName.ClientID%>').focus();
    </script>
</body>
</html>
