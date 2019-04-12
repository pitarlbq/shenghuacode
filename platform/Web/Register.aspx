<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Web.Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="renderer" content="webkit" />
    <title>
        <%= ConfigurationManager.AppSettings["CompanyName"] %></title>
    <link href="styles/basic.css" rel="stylesheet" type="text/css" />
    <link href="styles/page/login.css?10" rel="stylesheet" />
    <script src="js/jquery-1.8.3.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(function () {
            var page_width = $(window).width();
            if (page_width > 1500) {
                $('.mainimg').css('background-size', '60% auto');
            }
            else {
                $('.mainimg').css('background-size', 'auto auto');
            }
        })
        function check() {
            var companayname = $('#<%= this.tdCompanyName.ClientID%>').val();
            var username = $('#<%= this.tbLoginName.ClientID%>').val();
            var password = $('#<%= this.tbPassword.ClientID%>').val();
            var repassword = $('#<%= this.tdRePassword.ClientID%>').val();
            var phonenumber = $('#<%= this.tdPhoneNumber.ClientID%>').val();
            if (!companayname) {
                alert("请输入公司名称");
                $('#<%= this.tdCompanyName.ClientID%>').focus();
                return false;
            }
            if (!phonenumber) {
                alert("请输入联系方式");
                $('#<%= this.tdPhoneNumber.ClientID%>').focus();
                return false;
            }
            if (!username) {
                alert("请输入用户名");
                $('#<%= this.tbLoginName.ClientID%>').focus();
                return false;
            }
            if (!password) {
                alert("请输入密码");
                $('#<%= this.tbPassword.ClientID%>').focus();
                return false;
            }
            if (!repassword) {
                alert("请确认密码");
                $('#<%= this.tdRePassword.ClientID%>').focus();
                return false;
            }
            if (password != repassword) {
                alert("两次输入的密码不一致");
                $('#<%= this.tbPassword.ClientID%>').focus();
                return false;
            }
            return true;
        }

    </script>
    <style type="text/css">
        .top {
            width: 100%;
            height: 75px;
            background-color: #fff;
            margin: 0 auto;
            border-bottom: solid 1px #ccc;
            position: relative;
        }

        .logo {
            background-image: url("styles/images/logo.png?v1");
            background-repeat: no-repeat;
            background-position-x: left;
            background-position-y: center;
            background-size: auto 55px;
            width: 40%;
            margin-left: 10%;
            display: block;
            height: 75px;
            margin-left: 5%;
        }

        .center {
            position: absolute;
            top: 75px;
            left: 0;
            right: 0;
            bottom: 40px;
        }

        .mainimg {
            position: absolute;
            width: 50%;
            background-image: url("styles/images/login_1.png?v1");
            background-repeat: no-repeat;
            background-position: right center;
            top: 0;
            bottom: 0;
            left: 0;
        }

        .loginbox {
            position: absolute;
            width: 40%;
            left: 60%;
            right: 0;
            top: 50%;
            bottom: 0;
            height: 400px;
            margin-top: -200px;
        }

        .footer {
            position: fixed;
            bottom: 0;
            line-height: 40px;
            text-align: center;
            color: #fff;
            clear: both;
            width: 100%;
            background-color: #2E7ECE;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
            <div class="top">
                <div class="logo"></div>
                <div class="links">
                    <label>第一次使用平台?</label>
                    <a href="Register.aspx">注册新账号</a> <span>|</span>
                    <a target="_blank" href="http://admin.saasyy.com/manual/viewsysmanual.aspx">使用帮助</a> <span>|</span>
                    <a target="_blank" href="http://saasyy.com/">官方网站</a>
                </div>
            </div>
            <div class="mainimg"></div>
            <div class="loginbox">
                <div class="title">公司注册</div>
                <div class="inputbox" style="margin-top: 30px;">
                    <asp:TextBox ID="tdCompanyName" placeholder="请输入公司名称" runat="server" Style="border: none;"></asp:TextBox>
                </div>
                <div class="inputbox" style="margin-top: 10px;">
                    <asp:TextBox ID="tdPhoneNumber" placeholder="请输入联系方式" runat="server" Style="border: none;"></asp:TextBox>
                </div>
                <div class="inputbox" style="margin-top: 10px;">
                    <asp:TextBox ID="tbLoginName" placeholder="请输入用户名" runat="server" Style="border: none;"></asp:TextBox>
                </div>
                <div class="inputbox" style="margin-top: 10px;">
                    <asp:TextBox ID="tbPassword" placeholder="请输入密码" TextMode="Password" runat="server" Style="border: none;"></asp:TextBox>
                </div>
                <div class="inputbox" style="margin-top: 10px;">
                    <asp:TextBox ID="tdRePassword" placeholder="请确认密码" TextMode="Password" runat="server" Style="border: none;"></asp:TextBox>
                </div>
                <div style="clear: both;"></div>
                <div class="login_btn">
                    <asp:Button CssClass="btnlogin" Text="注册" ID="btnLogin" runat="server" OnClientClick="return check();"
                        OnClick="btnRegister_Click" />
                </div>
                <div style="text-align: center;">
                    <div style="width: 220px; text-align: right; margin: 0 auto; padding-top: 10px;">
                        <a href="login.aspx">返回登陆
                        </a>
                    </div>
                </div>
                <div style="margin: 0 auto; text-align: center; padding: 0">
                    <asp:Label ID="lbMsg" runat="server" CssClass="err"></asp:Label>
                </div>
            </div>
            <div class="footer">
                Copyright&copy;<%= ConfigurationManager.AppSettings["CopyRight"]%>
            </div>
        </div>
    </form>

    <script type="text/javascript">
        document.getElementById('<%= this.tbLoginName.ClientID%>').focus();
    </script>

</body>
</html>
