<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="UserServiceTypeMgr.aspx.cs" Inherits="Web.UserInfo.UserServiceTypeMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/UserInfo/UserServiceTypeMgr.js?t=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'center',border:false">
            <div class="easyui-panel" data-options="border:false,fit:true">
                <table id="operationTree" data-options="border:false,fit:true">
                    <thead>
                        <tr>
                            <th data-options="field:'name'" width="30%" formatter="formatcheckbox">模块</th>
                            <th data-options="field:'description'" width="70%" align="left">描述</th>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
