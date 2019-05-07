<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="ServiceList.aspx.cs" Inherits="Web.CustomerService.ServiceList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>任务看板</title>
    <script type="text/javascript">
        var ServiceType = 1;
        $(function () {
            loadIframe();
            $('#CostTab').tabs({
                onSelect: function (title, index) {
                    loadIframe();
                }
            });
        })
        function loadIframe() {
            var curTab = $('#CostTab').tabs('getSelected');
            if (curTab.find("iframe:first").attr("src") == "") {
                var iframesrc = curTab.find("input[type=hidden]:first").val();
                curTab.find("iframe:first").attr("src", iframesrc);
                var $height = $(window).height();
                //curTab.find("iframe:first").css("height", ($height - 65) + "px");
            }
        }
        function reloadTT() {
            top.treeType = 4;
            top.openTreeContent();
            var curTab = $('#CostTab').tabs('getSelected');
            curTab.find("iframe")[0].contentWindow.loadTT();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-tabs" id="CostTab" style="width: 100%; height: 99%; border: none;" data-options="tabHeight:35">
        <%--<%if (base.CheckAuthByModuleCode("1101206"))
          {%>
        <div title="任务清单" style="padding: 10px">
            <input type="hidden" value="ServiceMgr.aspx?status=101" />
            <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
        </div>
        <%} %>--%>
        <div title="调度台" style="padding: 10px">
            <input type="hidden" value="ServiceMgr.aspx?status=10" />
            <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
        </div>
        <div title="待派单" style="padding: 10px">
            <input type="hidden" value="ServiceMgr.aspx?status=3" />
            <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
        </div>
        <%--<div title="待处理" style="padding: 10px">
            <input type="hidden" value="ServiceMgr.aspx?status=3" />
            <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
        </div>--%>
        <div title="处理中" style="padding: 10px">
            <input type="hidden" value="ServiceMgr.aspx?status=0" />
            <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
        </div>
        <div title="已办结" style="padding: 10px">
            <input type="hidden" value="ServiceMgr.aspx?status=1" />
            <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
        </div>
       <%-- <div title="已销单" style="padding: 10px">
            <input type="hidden" value="ServiceMgr.aspx?status=2" />
            <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
        </div>--%>
        <div title="已关单" style="padding: 10px">
            <input type="hidden" value="ServiceMgr.aspx?status=4" />
            <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
        </div>
    </div>
</asp:Content>
