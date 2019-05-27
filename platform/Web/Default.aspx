<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.Default" Async="true" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title><%= new Utility.SiteConfig().CompanyName %></title>
    <link href="styles/buttons.css" rel="stylesheet" />
    <link href="js/easyui/gray/easyui.css" type="text/css" rel="stylesheet" />
    <link href="js/easyui/icon.css" type="text/css" rel="stylesheet" />
    <script src="js/jquery-1.8.3.min.js"></script>
    <script>
        var loginname, guid, DefaultURL, TopTitle, isAddService = false, isComingServiceSave = true;
        $(function () {
            DefaultURL = "<%=this.DefaultURL %>";
            TopTitle = '';
        })
    </script>
    <script src="js/socket/loginclient.js?t=<%=base.getToken() %>"></script>
    <script src="js/easyui/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="js/easyui/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <script src="http://<%=this.SocketURL %>/socket.io/socket.io.js"></script>
    <script src="js/Page/Comm/MaskUtil.js?t=<%=getToken() %>"></script>
    <script src="js/Page/Main/Comm.js?t=<%=base.getToken() %>"></script>
    <script src="js/Page/Main/Main.js?t=2_<%=base.getToken() %>"></script>
    <link href="../js/ztree/zTreeStyle/zTreeStyle.css?v1" rel="stylesheet" />
    <script src="../js/ztree/jquery.ztree.core.js"></script>
    <script src="../js/ztree/jquery.ztree.excheck.js"></script>
    <script src="../js/ztree/jquery.ztree.exedit.js"></script>
    <script src="js/Page/Main/zTreeLoad.js?t=<%=base.getToken() %>"></script>
    <link href="styles/treecss.css?v=1.0" rel="stylesheet" />

    <script type="text/javascript" src="js/call/qnviccub.js?t=<%=base.getToken() %>"></script>
    <script type="text/javascript" src="js/call/qnvfunc.js?t=<%=base.getToken() %>"></script>
    <script type="text/javascript" src="js/call/json2.js?t=<%=base.getToken() %>"></script>
    <script type="text/javascript" src="js/call/deviceapi.js?t=<%=base.getToken() %>"></script>
    <script>
        var LogoPath, RecordLocation, hdRecordLocation, UserID, AddUserName, contextPath, isDriverOn = 0, is400User, isPhoneDeviceWork = 0;
        $(function () {
            hdRecordLocation = $("#<%=this.hdRecordLocation.ClientID%>");
            LogoPath = "<%=this.LogoPath%>";
            RecordLocation = hdRecordLocation.val();
            UserID = "<%=this.UserID%>";
            AddUserName = "<%=this.AddUserName%>";
            contextPath = "<%=Web.WebUtil.GetContextPath()%>";
            checkDriverStatus();
            is400User = "<%=this.is400User?1:0%>";
            //var phone = 18108173680;
            //for (var i = 1; i < 5; i++) {
            //    setTimeout(function () {
            //        phone++;
            //        top.getDataByPhoneNumber(phone);
            //    }, 2000 * i);
            //}
        })
        function checkDriverStatus() {
            var iVer = 1;//第一个版本
            top.check_ver(iVer, function (nRet) {
                switch (nRet) {
                    case top.W_OK://检查成功
                        isDriverOn = 1;
                        break;
                    default:
                        isDriverOn = 2;
                        break;
                }
                if (isDriverOn == 2) {
                    driverAlert();
                }
            });
        }
    </script>
    <script src="js/Page/Main/callBoxinit.js?t=<%=base.getToken() %>"></script>
    <style>
        .pageheader {
            width: 100px;
            margin: 0;
            position: fixed;
            left: 0px;
            top: 0;
            z-index: 999;
            height: 40px;
        }

            .pageheader a {
                line-height: 40px;
                font-size: 25px;
                color: #fff;
                margin: 0;
                display: inline-block;
            }

            .pageheader .headertitle .logo {
                background-size: auto 40px;
                background-repeat: no-repeat;
                background-position: left center;
                height: 40px;
                width: 100px;
            }

        .timerBox {
            float: right;
            height: 40px;
            overflow: visible;
            position: relative;
            margin-right: 10px;
        }

        .time {
            background-position: 0 10px;
            background-repeat: no-repeat;
            background-size: 25px 25px;
            float: left;
            height: 100%;
            overflow: visible;
            width: 25px;
            cursor: pointer;
        }

        .knocking {
            background-image: url("styles/images/buttons/head-time.png");
            background-size: 20px 20px;
        }

        a.customer_service {
            background-position: 0 10px;
            background-repeat: no-repeat;
            background-size: 18px 18px;
            float: left;
            height: 40px;
            overflow: visible;
            cursor: pointer;
            line-height: 40px;
            color: #fff;
        }

            a.customer_service:hover {
                color: #fff;
            }

        .notifymsg {
            background-image: url("styles/images/buttons/sysnotify_new.png");
        }

        .viewmanual {
            background-image: url("styles/images/buttons/manual_new.png");
            background-size: 20px 20px;
            width: 20px;
        }

        .warningbar {
            background-image: url("styles/images/buttons/warning_icon_2.png");
            background-size: 20px 20px;
        }

        .wechatservicecss {
            background-image: url("styles/images/buttons/wechat_service_new.png");
        }

        .floatBox {
            background-color: #fff;
            border-radius: 8px;
            box-shadow: 3px 3px 18px #666;
            display: none;
            left: -92px;
            padding: 10px 0px;
            position: absolute;
            top: 45px;
            width: 205px;
            z-index: 1009;
        }

        div.arrows {
            border-bottom: 12px solid #fff;
            border-left: 6px solid transparent;
            border-right: 6px solid transparent;
            height: 0;
            left: 50%;
            margin-left: -6px;
            position: absolute;
            top: -12px;
            width: 0;
            z-index: 999;
        }

        .userCenter {
            float: right;
            height: 30px;
            overflow: visible;
            position: relative;
            padding: 10px 10px 0px 0px;
            cursor: pointer;
        }

            .userCenter span {
                font-size: 13px;
                color: #fff;
            }

        .fatable {
            font-size: 15px;
        }

        .dropdown-menu {
            border: solid 1px #ddd;
            border-radius: 5px !important;
            min-width: 100px;
            padding: 5px;
            top: 40px;
            display: none;
            position: absolute;
            background-color: #fff;
        }

            .dropdown-menu ul {
                list-style: outside none none;
                margin: 0px;
                padding: 0px;
            }

                .dropdown-menu ul li a:hover {
                    background-color: #f0f0f0;
                }

                .dropdown-menu ul li a {
                    text-decoration: none;
                    color: #000;
                    line-height: 25px;
                    height: 25px;
                    display: block;
                    padding: 0 5px;
                    font-size: 14px;
                }

        .tabs-scroller-left {
            background: url(styles/images/buttons/leftarrow.png) no-repeat center center;
            background-size: 18px 18px;
            border: 0;
        }

        .tabs-scroller-right {
            background: url(styles/images/buttons/rightarrow.png) no-repeat center center;
            background-size: 18px 18px;
            border: 0;
        }

        .notify_point {
            min-width: 20px;
            position: absolute;
            top: 0px;
            right: 0px;
            background-color: #ff6a00;
            color: #fff;
            border-radius: 5px;
            font-family: 'Microsoft YaHei';
            padding-left: 0;
            display: none;
            text-align: center;
            font-size: 10px;
        }

            .notify_point.warning_point {
                right: 0px;
                top: 0px;
            }

            .notify_point.expiring_point {
                font-size: 10px;
                right: 0px;
                top: 0px;
                display: block;
            }

        .pop_count {
            color: #ff0000;
            margin: 0 5px;
            font-size: 14px;
        }

        .view_more {
            color: #2f80d1;
        }

        .topHeader {
            position: absolute;
            top: 0;
            right: 0;
            left: 0;
            height: 41px;
            background: #233d64;
        }

        .menubox {
            border: solid 1px #ccc;
            background-color: #808080;
            padding: 5px 10px;
            border-radius: 5px;
            margin-right: 10px;
            margin-top: 20px;
            color: #fff;
            cursor: pointer;
        }

            .menubox.active {
                background-color: #fff;
                color: #000;
            }

        .open {
            position: relative;
        }

        .userCenter.open .dropdown-menu {
            width: 100px;
            display: block;
            left: -10px;
        }

        .timerBox.open .dropdown-menu {
            width: 260px;
            display: block;
            left: -124px;
        }

        .menuLeft, .treeLeft {
            position: absolute;
            top: 82px;
            left: 0;
            bottom: 0;
            width: 200px;
        }

        .treeLeft {
            background: #fff;
        }

        .menuItemBox {
            padding: 10px 0 10px 10px;
            cursor: pointer;
        }

            .menuItemBox.active {
                background-color: #37537c;
            }

            .menuItemBox:hover {
                background-color: #37537c;
            }

        .menuItem {
            height: 30px;
            padding-left: 30px;
            background-position: center left;
            background-repeat: no-repeat;
            background-size: 20px 20px;
        }

            .menuItem label {
                color: #fff;
                display: inline-block;
                width: 150px;
                text-align: left;
                line-height: 30px;
                font-size: 13px;
                cursor: pointer;
            }



        .home_css {
            background-image: url('./styles/icons/客服中心.png');
        }

        .project_css {
            background-image: url('./styles/icons/客户信息.png');
        }

        .customer_css {
            background-image: url('./styles/icons/工单信息.png');
        }

        .feedback_css {
            background-image: url('./styles/icons/回访管理.png');
        }

        .analysis_css {
            background-image: url('./styles/icons/数据统计.png');
        }

        .setting_css {
            background-image: url('./styles/icons/系统设置.png');
        }

        .menuTitle {
            position: absolute;
            top: 40px;
            left: 0;
            width: 200px;
            height: 40px;
        }

            .menuTitle label {
                display: inline-block;
                line-height: 40px;
                width: 45%;
                color: #fff;
                text-align: center;
                font-size: 14px;
                cursor: pointer;
            }

                .menuTitle label.active {
                    background-color: #37537c;
                }
    </style>
    <script>
        $(function () {
            var self;
            $('.menuItemBox').bind('click', function () {
                var elems = $('.menuItemBox');
                $.each(elems, function (index, self) {
                    $(self).removeClass('active');
                })
                var url = $(this).attr('data-url');
                var title = $(this).attr('data-title');
                var id = $(this).attr('data-id');
                $(this).addClass('active');
                if (id) {
                    var contextPath = "<%=base.GetContextPath() %>";
                    addTab(title, contextPath + '/main/subpage.aspx?ID=' + id, '');
                } else if (url) {
                    addTab(title, url, '');
                }
            })
            $('.menuTitle label').bind('click', function () {
                var elems = $('.menuTitle label');
                $.each(elems, function (index, self) {
                    $(self).removeClass('active');
                })
                $(this).addClass('active');
                var id = $(this).attr('data-id');
                if (id == 0) {
                    $('.menuLeft').show();
                    $('.treeLeft').hide();
                } else {
                    $('.menuLeft').hide();
                    $('.treeLeft').show();
                    loadTree();
                }
            })
        })
        function openTreeContent(cancelExChange) {
            if (!cancelExChange) {
                var elems = $('.menuTitle label');
                $.each(elems, function (index, self) {
                    $(self).removeClass('active');
                })
                $('label#treeLabel').addClass('active');
                $('.menuLeft').hide();
                $('.treeLeft').show();
            }
            loadTree();
        }
    </script>
    <style>
        .ztree li {
            padding: 5px 0 0 0;
            /*background:url("../js/ztree/zTreeStyle/img/line_conn.gif") repeat-y scroll 0 0*/
        }

            .ztree li > input {
                margin: 0;
            }

        .ztree input[type=radio] {
            width: 15px;
            height: 15px;
        }
    </style>
</head>
<body>
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'west'" style="width: 200px; border: 0px; background: #233d64;">
            <form runat="server">
                <asp:HiddenField runat="server" ID="hdRecordLocation" />
            </form>
            <div class="pageheader" style="position: absolute;">
                <a class="headertitle" href="default.aspx?pagetype=<%=this.pagetype %>">
                    <div class="logo"></div>
                </a>
            </div>
            <div class="menuTitle">
                <label class="active" data-id="0">菜单</label>
                <label id="treeLabel" data-id="1">资源</label>
            </div>
            <div class="menuLeft">
                <%if (this.CanViewHomeCall == 1)
                    { %>
                <div class="menuItemBox active" data-url="../Main/Default.aspx" data-title="400客服">
                    <div class="menuItem home_css">
                        <label>400客服</label>
                    </div>
                </div>
                <%} %>
                <%if (this.CanViewProject == 1)
                    { %>
                <div class="menuItemBox" data-title="客户管理" data-id="2">
                    <div class="menuItem project_css">
                        <label>客户管理</label>
                    </div>
                </div>
                <%} %>
                <%if (this.CanViewService == 1)
                    { %>
                <div class="menuItemBox" data-title="工单管理" data-id="3">
                    <div class="menuItem customer_css">
                        <label>工单管理</label>
                    </div>
                </div>
                <%} %>
                <%if (this.CanViewCallBack == 1)
                    { %>
                <div class="menuItemBox" data-title="回访管理" data-id="4">
                    <div class="menuItem feedback_css">
                        <label>回访管理</label>
                    </div>
                </div>
                <%} %>
                <%if (this.CanViewServiceDetail == 1)
                    { %>
                <div class="menuItemBox" data-title="工单查询" data-id="100">
                    <div class="menuItem analysis_css">
                        <label>工单查询</label>
                    </div>
                </div>
                <%} %>
                <%if (this.CanViewAnalysis == 1)
                    { %>
                <div class="menuItemBox" data-title="统计报表" data-id="5">
                    <div class="menuItem analysis_css">
                        <label>统计报表</label>
                    </div>
                </div>
                <%} %>
                <%if (this.CanViewSetting == 1)
                    { %>
                <div class="menuItemBox" data-title="系统设置" data-id="6">
                    <div class="menuItem setting_css">
                        <label>系统设置</label>
                    </div>
                </div>
                <%} %>
            </div>
            <div class="treeLeft" style="display: none;">
                <div class="easyui-panel" style="height: 50px; width: 200px; padding-top: 10px; border: 0px;">
                    <input id="searchbox" class="easyui-searchbox" data-options="prompt:'',searcher:doSearch" style="height: 30px; width: 150px;" />
                    <label id="labelALL" style="vertical-align: middle; margin: 0;">
                        <input type="checkbox" id="btnAll" style="height: 15px; width: 15px; vertical-align: middle; margin: 0;" />全选</label>
                </div>
                <div class="easyui-panel" style="height: 90%; width: 200px; border: 0px;">
                    <ul id="tt" class="ztree"></ul>
                </div>
            </div>
        </div>
        <div data-options="region:'center',border:false" style="border: 0px; background-color: #f0f0f0;">
            <div class="topHeader">
                <div style="position: absolute; right: 20px; top: 0; z-index: 999;">
                    <div class="userCenter" id="user_center">
                        <span id="user_info">欢迎您 , <%=this.RealName %>!</span>
                        <div class="dropdown-menu">
                            <div class="arrows"></div>
                            <ul>
                                <li><a onclick="viewPersonal()" style="text-align: left;">个人中心</a></li>
                                <li><a href="Login.aspx?op=logout" id="ahover" target="_top" style="text-align: left;">退出</a></li>
                            </ul>
                        </div>
                    </div>
                    <div class="timerBox" id="btnwarning">
                        <a hre="#" title="提醒事项" class="time warningbar" style="margin-right: 10px;">
                            <div id="warning_point" class="notify_point warning_point">0</div>
                        </a>
                        <div class="dropdown-menu">
                            <div class="arrows"></div>
                            <ul>
                                <li><a href="#" id="sub_servicetimeout" style="text-align: left;">工单超时提醒<span class="pop_count" id="service_count">0</span>条 <span class="view_more">点击查看详情</span></a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <div id="tabs" class="easyui-tabs" data-options="fit:true,border:false,tabHeight:34" style="width: 100%; height: 100%; padding-top: 4px;">
            </div>
            <audio style="display: none;" id="message_ring" controls="controls" src="newmessage.mp3"></audio>
        </div>
        <!-- 鼠标右键菜单 -->
        <div id="mm" class="easyui-menu" style="width: 150px; display: none; margin-left: 5px;">
            <div id="mm-tabclose">
                关闭
            </div>
        </div>
    </div>
    <style>
        .tabs-header {
            background: #233d64;
            border: 0;
        }

        .tabs li.tabs-selected a.tabs-inner {
            color: #233d64;
        }

        .tabs {
            padding-left: 0px;
        }

            .tabs li {
                margin: 0 4px 0 0;
            }

                .tabs li a.tabs-inner {
                    color: #fff;
                }

                .tabs li.tabs-selected a.tabs-inner {
                    border-bottom: 0;
                }

        ul.tabs {
            border: 0;
        }
    </style>
</body>
</html>

