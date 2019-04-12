<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditColumns.aspx.cs" Inherits="Web.RoomResource.EditColumns" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            loadIframe();
            $('#RoomSourceTab').tabs({
                onSelect: function (title, index) {
                    loadIframe();
                }
            });
        })
        function loadIframe() {
            var curTab = $('#RoomSourceTab').tabs('getSelected');
            if (curTab.find("iframe:first").attr("src") == "") {
                var iframesrc = curTab.find("input[type=hidden]:first").val();
                curTab.find("iframe:first").attr("src", iframesrc);
                var $height = $(window).height();
                curTab.find("iframe:first").css("height", ($height - 65) + "px");
            }
        }
        function do_close() {
            parent.do_close_dialog();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 30px; font-size: 12px;">
            <div class="operation_box">
                <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
            </div>
        </div>
        <div data-options="region:'center',border:false">
            <div class="easyui-tabs" id="RoomSourceTab" style="width: 100%; height: 99%; border: none;" data-options="tabHeight:35">
                <div title="多选参数" style="padding: 0px">
                    <input type="hidden" value="../SysSeting/EditRoomBasicComboboxColumns.aspx" />
                    <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
                </div>
                <div title="面积参数" style="padding: 0px">
                    <input type="hidden" value="../SysSeting/EditRoomBasicAreaColumns.aspx?TableName=RoomBasic" />
                    <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
                </div>
                <div title="自定义参数(资源)" style="padding: 0px">
                    <input type="hidden" value="../SysSeting/DefineFieldSetUp.aspx?TableName=RoomBasic" />
                    <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
                </div>
                <div title="自定义参数(业主/租户)" style="padding: 0px">
                    <input type="hidden" value="../SysSeting/EditRoomBasicAreaColumns.aspx?TableName=RoomPhoneRelation" />
                    <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
