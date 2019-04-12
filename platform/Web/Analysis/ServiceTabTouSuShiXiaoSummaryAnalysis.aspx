<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="ServiceTabTouSuShiXiaoSummaryAnalysis.aspx.cs" Inherits="Web.CustomerService.ServiceTabTouSuShiXiaoSummaryAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>营销投诉时效统计表|物业投诉时效统计表  </title>
    <script type="text/javascript">
        $(function () {
            loadIframe();
            $('#CommTab').tabs({
                onSelect: function (title, index) {
                    loadIframe();
                }
            });
        })
        function loadIframe() {
            var curTab = $('#CommTab').tabs('getSelected');
            if (curTab.find("iframe:first").attr("src") == "") {
                var iframesrc = curTab.find("input[type=hidden]:first").val();
                curTab.find("iframe:first").attr("src", iframesrc);
                var $height = $(window).height();
                //curTab.find("iframe:first").css("height", ($height - 65) + "px");
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-tabs" id="CommTab" style="width: 100%; height: 99%; border: none;" data-options="tabHeight:35">
        <div title="营销投诉时效统计表" style="padding: 10px">
            <input type="hidden" value="ServiceYingXiaoTouSuShiXiaoAnalysis.aspx" />
            <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
        </div>
        <div title="物业投诉时效统计表" style="padding: 10px">
            <input type="hidden" value="ServiceWuYeTouSuShiXiaoAnalysis.aspx" />
            <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
        </div>
    </div>
</asp:Content>
