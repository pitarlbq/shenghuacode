<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="UserAuthMgr.aspx.cs" Inherits="Web.UserInfo.UserAuthMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            loadIframe();
            $('#OperationTab').tabs({
                onSelect: function (title, index) {
                    loadIframe();
                }
            });
        })
        function loadIframe() {
            var curTab = $('#OperationTab').tabs('getSelected');
            if (curTab.find("iframe:first").attr("src") == "") {
                var iframesrc = curTab.find("input[type=hidden]:first").val();
                curTab.find("iframe:first").attr("src", iframesrc);
            }
        }
    </script>
    <script src="../js/Page/UserInfo/UserAuthMgr.js?t=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'west',border:false" style="width: 200px;">
            <div class="easyui-panel searchlabel" style="max-height: 10%;">
                <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            </div>
            <div class="easyui-panel" style="max-height: 90%;" data-options="fit:true">
                <div class="easyui-tabs" id="CommTab" style="width: 100%; height: 99%; border: none;" data-options="tabHeight:35">
                    <div title="用户角色" style="padding: 0px">
                        <ul class="easyui-tree" id="userRoleTree" style="height: 100%;">
                        </ul>
                    </div>
                    <div title="用户列表" style="padding: 0px">
                        <ul class="easyui-tree" id="userTree" style="height: 100%;">
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <div data-options="region:'center',border:false">
            <div class="easyui-tabs" id="OperationTab" style="width: 100%; height: 99%; border: none;" data-options="tabHeight:35">
                <div title="操作权限" style="padding: 10px">
                    <input type="hidden" value="UserModuleMgr.aspx" />
                    <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
                </div>
                <div title="资源权限" style="padding: 10px">
                    <input type="hidden" value="UserProjectMgr.aspx" />
                    <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
                </div>
                <div title="工单流转权责" style="padding: 10px">
                    <input type="hidden" value="UserServiceTypeMgr.aspx" />
                    <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
