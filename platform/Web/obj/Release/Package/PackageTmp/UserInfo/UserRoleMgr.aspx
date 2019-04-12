<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="UserRoleMgr.aspx.cs" Inherits="Web.UserInfo.UserRoleMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/UserInfo/UserRoleMgr.js?v=<%=base.getToken() %>"></script>
    <style>
        .labelMore {
            position: relative;
            display: inline-block;
            line-height: 30px;
            padding-left: 16px;
        }

            .labelMore input[type=checkbox] {
                position: absolute;
                left: 0;
                top: 50%;
                margin: 0;
                margin-top: -7px;
                width: 15px;
                height: 15px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div id="cc" class="easyui-layout" fit="true">
        <div data-options="region:'center',border:false" style="width: 400px; border: 1px solid #d0d0d0; border-left: none;">
            <div class="easyui-panel" title="" style="width: 100%; padding: 5px 0;" data-options="border:false">
                <label>
                    关键字:
                     <input class="easyui-searchbox" id="tdRoleName" type="text" data-options="prompt:'角色名称搜索',searcher:doSearchRole" />
                </label>
                <label>
                    <a href="javascript:void(0)" onclick="doSearchRole()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">查询</a>
                </label>
            </div>
            <div class="easyui-panel" title="" style="width: 100%; height: 40%;" data-options="border:false">
                <table id="notr" class="easyui-datagrid" data-options="border:false" singleselect="true">
                    <thead>
                        <tr>
                            <th field="RoleID" align="center" hidden="true">编号</th>
                            <th field="RoleName" width="100%" align="center">未有角色</th>
                        </tr>
                    </thead>
                </table>
                <label id="loadNoRoleFailed"></label>
            </div>
            <div class="easyui-panel" title="" style="width: 100%; padding: 5px 0; border: 1px solid #d0d0d0; border-left: none; border-right: none;" data-options="border:false">
                <div style="text-align: center;">
                    <label class="labelMore">
                        <input type="checkbox" id="tdMore" />批处理</label>
                    <a href="javascript:void(0)" onclick="leftRole()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-add'">赋予角色</a>
                    <a href="javascript:void(0)" onclick="rightRole()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-remove'">移除角色</a>
                </div>
            </div>
            <div class="easyui-panel" title="" style="width: 100%; height: 35%; border: none; border-bottom: 1px solid #d0d0d0;" data-options="border:false">
                <table id="inr" class="easyui-datagrid" singleselect="true" data-options="border:false,">
                    <thead>
                        <tr>
                            <th field="RoleID" align="center" hidden="true">编号</th>
                            <th field="RoleName" width="100%" align="center">已有角色</th>
                        </tr>
                    </thead>
                </table>
                <label id="loadInRoleFailed"></label>
            </div>
        </div>
        <div data-options="region:'west',border:false" style="width: 70%; border: 1px solid #d0d0d0;">
            <div class="easyui-panel" title="" style="width: 100%; padding: 5px 0;" data-options="border:false">
                <label>
                    关键字:
                     <input class="easyui-searchbox" id="tbRealName" type="text" data-options="prompt:'用户名搜索',searcher:doSearchUser" />
                </label>
                <label>
                    <a href="javascript:void(0)" onclick="doSearchUser()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">查询</a>
                </label>
            </div>
            <div class="easyui-panel" title="" style="width: 100%; height: 80%;" data-options="border:false">
                <table id="dg" class="easyui-datagrid" singleselect="true" data-options="border:false">
                    <thead>
                        <tr>
                            <th data-options="field:'RealName',width:80,align:'left',sortable: true">用户名
                            </th>
                            <th data-options="field:'LoginName',width:100,align:'left',sortable: true">登录名
                            </th>
                            <th data-options="field:'Gender',width:80,align:'left',sortable: true">性别
                            </th>
                        </tr>
                    </thead>
                </table>
                <label id="loadUserFailed"></label>
            </div>
        </div>
    </div>
</asp:Content>
