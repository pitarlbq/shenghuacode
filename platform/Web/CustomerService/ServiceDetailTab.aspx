<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="ServiceDetailTab.aspx.cs" Inherits="Web.CustomerService.ServiceDetailTab" %>

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
        <div title="工单详情" style="padding: 10px">
            <input type="hidden" value="ServiceEdit.aspx?op=view&ID=<%=this.ID%>" />
            <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
        </div>
        <div title="处理详情" style="padding: 10px">
            <input type="hidden" value="ServiceProcessMgr.aspx?op=view&ID=<%=this.ID%>" />
            <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
        </div>
        <div title="回访详情" style="padding: 10px">
            <input type="hidden" value="ServiceCallMgr.aspx?op=view&ID=<%=this.ID%>" />
            <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
        </div>
    </div>
</asp:Content>
