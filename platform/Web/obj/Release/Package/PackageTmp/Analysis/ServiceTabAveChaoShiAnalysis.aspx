<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="ServiceTabAveChaoShiAnalysis.aspx.cs" Inherits="Web.CustomerService.ServiceTabAveChaoShiAnalysis" %>

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
        <div title="营销投诉工单时效" style="padding: 10px">
            <input type="hidden" value="ServiceYingXiaoTouSuTimeOutAnalysis.aspx" />
            <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
        </div>
        <div title="物业投诉工单时效" style="padding: 10px">
            <input type="hidden" value="ServiceWuYeTouSuTimeOutAnalysis.aspx" />
            <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
        </div>
        <div title="报事报修工单时效" style="padding: 10px">
            <input type="hidden" value="ServiceRepairTimeOutAnalysis.aspx" />
            <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
        </div>
    </div>
</asp:Content>
