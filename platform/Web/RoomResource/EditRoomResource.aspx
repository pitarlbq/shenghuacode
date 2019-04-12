<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditRoomResource.aspx.cs" Inherits="Web.RoomResource.EditRoomResource" %>

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
                curTab.find("iframe:first").css("height", ($height - 80) + "px");
            }
        }
        function do_close() {
            parent.do_close_dialog(function () {
                try {
                    parent.$("#tt_table").datagrid("reload");
                } catch (e) {
                }
                try {
                    parent.content.getdata();
                } catch (e) {
                }
                try {
                    parent.edit_roomsource_done();
                } catch (e) {
                }
                try {
                    parent.EditRoomResource_Done();
                } catch (e) {
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 30px;">
            <div class="operation_box">
                <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
            </div>
        </div>
        <div data-options="region:'center',border:false">
            <div class="easyui-tabs" id="RoomSourceTab" style="width: 100%; height: 99%; border: none;" data-options="tabHeight:35">
                <div title="资源信息" style="padding: 0px">
                    <input type="hidden" value="EditRoomResource_Basic.aspx?RoomID=<%=Request.QueryString["RoomID"] %>" />
                    <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
                </div>
                <div title="住户信息" style="padding: 0px">
                    <input type="hidden" value="EditRoomResource_Owner.aspx?RoomID=<%=Request.QueryString["RoomID"] %>" />
                    <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
