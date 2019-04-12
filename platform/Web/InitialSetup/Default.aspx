<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.InitialSetup.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/page/initialdefault.css?t=<%=base.getToken() %>" rel="stylesheet" />
    <style>
        .panel-body {
            background: #fff;
        }

        .tabs-header {
            background-color: #2f80d1;
        }

        .tabs li.tabs-selected a.tabs-inner {
            color: #2f80d1;
        }

        .tabs li a.tabs-inner:hover {
            color: #2f80d1;
        }
    </style>
    <script>
        var GetContextPath;
        $(function () {
            GetContextPath = "<%=base.GetContextPath() %>";
            $('body').bind('click', function () {
                parent.hide_popup();
            })
        })
    </script>
    <script src="../js/vue.js"></script>
    <script>
        var content, ID, GroupName;
        $(function () {
            ID = "<%=this.ID%>";
            GroupName = "<%=this.GroupName%>";
            content = new Vue({
                el: '#fieldcontent',
                data: {
                    list: [],
                },
                methods: {
                    getdata: function () {
                        var that = this;
                        var options = { visit: 'getmymenus', ID: ID, GroupName: GroupName };
                        $.ajax({
                            type: 'POST',
                            dataType: 'json',
                            url: '../Handler/SysSettingHandler.ashx',
                            data: options,
                            success: function (data) {
                                if (data.status) {
                                    that.list = data.list;
                                }
                            }
                        });
                    },
                    open_menu: function (item) {
                        var that = this;
                        if (item.ID == 33) {
                            top.window.open(item.Url);
                            return;
                        }
                        parent.addTab(item.Title, GetContextPath + '/main/subpage.aspx?ID=' + item.ID, '');
                    }
                }
            });
            content.getdata();
        })
    </script>
    <style>
        .menu_box {
            width: 100px;
            min-height: 30px;
            float: left;
            margin: 50px 0px 0px 70px;
            text-align: center;
            font-size: 16px;
        }

        .ModuleBox {
            float: none;
            height: 95px;
            width: 100px;
            margin: 0 auto;
            padding: 0px;
        }

        .menu_box label {
            width: 100%;
            margin-top: 10px;
        }
        [v-cloak]{
            display: none
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div id="fieldcontent" v-cloak>
        <div style="padding: 0 30px 0px 10px;">
            <div class="menu_box" style="cursor: pointer;" v-on:click="open_menu(item)" v-for="item in list">
                <div v-if="item.IconPath==''" class="ModuleBox" v-bind:class="item.CssClass">
                </div>
                <div v-if="item.IconPath!=''" class="ModuleBox" style="background-size: 80px 80px; background-repeat: no-repeat; background-position: center center;" v-bind:style="{backgroundImage:'url('+item.IconPath+')'}">
                </div>
                <label>{{item.Title}}</label>
            </div>
            <div style="clear: both;"></div>
        </div>
    </div>
</asp:Content>
