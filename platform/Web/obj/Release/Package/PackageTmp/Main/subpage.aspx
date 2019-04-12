<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="subpage.aspx.cs" Inherits="Web.Main.subpage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .panel-body {
            background: #f0f0f0;
        }

        .subtitle {
            background: #fff none repeat scroll 0 0;
            height: 35px;
            position: relative;
            z-index: 10;
            padding-left: 0px;
            margin-bottom: 10px;
        }

        .titlename {
            float: left;
            height: 35px;
            margin-top: 2px;
        }

            .titlename a {
                background: #fff;
                border-radius: 0px;
                color: #808080;
                text-decoration: none;
                display: inline-block;
                padding: 0 15px;
                line-height: 35px;
                text-decoration: none;
            }

            .titlename.choosetitlename a {
                background: #f0f1f5;
            }

        .subPageFrame {
            border: none;
            margin-left: 10px;
            border-radius: 5px !important;
        }
    </style>
    <script>
        $(function () {
            var url = "<%=this.iframeUrl%>";
            $("#subPageFrame").attr("src", url);
        })
        window.onresize = dynsiteFramesize;
        function dynsiteFramesize() {
            var bodyHeight = document.body.clientHeight;
            var titleHeight = $('.subtitle').height();
            $("#subPageFrame").css("height", (bodyHeight - titleHeight - 15) + "px");
            var bodyWidth = document.body.clientWidth;
            $("#subPageFrame").css("width", (bodyWidth - 20) + "px");
        }
        function showsubpage(url) {
            $("#subPageFrame").attr("src", url);
        }
        $(function () {
            var r = $(".subpagediv");
            if (!$(r[0]).hasClass("choosetitlename")) {
                $(r[0]).addClass("choosetitlename");
            }
            $(".subpagediv").click(function () {
                var $this = $(this);
                var r = $(".subpagediv");
                for (var i = 0; i < r.length; i++) {
                    if ($(r[i]).hasClass("choosetitlename")) {
                        $(r[i]).removeClass("choosetitlename");
                    }
                    if (!$(r[i]).hasClass("titlename")) {
                        $(r[i]).addClass("titlename");
                    }
                }
                $this.addClass("choosetitlename");
            })
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="subtitle">
        <asp:Repeater runat="server" ID="rptsubpage">
            <ItemTemplate>
                <div class="titlename subpagediv"><a href="#" onclick="showsubpage('<%#Eval("Url") %>')"><%#Eval("Title") %></a></div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div style="clear: both;"></div>
    <iframe id="subPageFrame" class="subPageFrame" name="subPageFrame" src="" onload="dynsiteFramesize()"></iframe>
</asp:Content>
