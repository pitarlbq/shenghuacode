<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="ServiceTabTouSuCountAnalysis.aspx.cs" Inherits="Web.CustomerService.ServiceTabTouSuCountAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>物业投诉数量统计表|投诉来源统计表</title>
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
         <div title="营销类投诉数量统计" style="padding: 10px">
            <input type="hidden" value="ServiceYingXiaoTouSuCountAnalysis.aspx" />
            <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
        </div>
        <div title="物业投诉数量统计" style="padding: 10px">
            <input type="hidden" value="ServiceWuYeTouSuCountAnalysis.aspx" />
            <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
        </div>
        <div title="投诉来源统计" style="padding: 10px">
            <input type="hidden" value="ServiceTouSuFromCountAnalysis.aspx" />
            <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
        </div>
        <div title="维修来源统计" style="padding: 10px">
            <input type="hidden" value="ServiceRepairFromCountAnalysis.aspx" />
            <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
        </div>
    </div>
</asp:Content>
