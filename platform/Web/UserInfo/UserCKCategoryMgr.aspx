<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="UserCKCategoryMgr.aspx.cs" Inherits="Web.UserInfo.UserCKCategoryMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../js/ztree/zTreeStyle/zTreeStyle.css?v1" rel="stylesheet" />
    <script src="../js/ztree/jquery.ztree.core.js"></script>
    <script src="../js/ztree/jquery.ztree.excheck.js"></script>
    <script src="../js/ztree/jquery.ztree.exedit.js"></script>
    <script>
        var CompanyID;
        $(function () {
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            $('#LeftSide').css('height', ($(window).height()) + "px");
            $('#RightSide').css('height', ($(window).height()) + "px");
        })
    </script>
    <script src="../js/Page/UserInfo/UserCKCategoryMgr.js?t=<%=base.getToken() %>"></script>
    <style>
        .l-btn-plain {
            display: inline;
        }

        .ztree li {
            padding: 5px 0 0 0;
            /*background:url("../js/ztree/zTreeStyle/img/line_conn.gif") repeat-y scroll 0 0*/
        }

            .ztree li > input {
                margin: 0;
            }
    </style>
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
            <div class="easyui-panel" data-options="border:false,fit:true" style="border: solid 1px #ccc;">
                <ul id="tt" class="ztree"></ul>
            </div>
        </div>
    </div>
</asp:Content>
