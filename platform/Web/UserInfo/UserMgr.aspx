<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="UserMgr.aspx.cs" Inherits="Web.UserInfo.UserMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var hdDepartment;
        $(function () {
            hdDepartment = $('#<%=this.hdDepartment.ClientID%>');
            var departmentList = [];
            if (hdDepartment.val() != '') {
                departmentList = eval('(' + hdDepartment.val() + ')');
            }
            $('#tdDepartment').combobox({
                editable: false,
                data: departmentList,
                valueField: 'ID',
                textField: 'Name'
            })
        })
    </script>
    <script src="../js/Page/UserInfo/UserMgr.js?v=<%=base.getToken()%>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <div class="easyui-layout" data-options="fit:true,border:false" id="page_easyui_layout">
            <div data-options="region:'center',border:false">
                <div class="easyui-layout" data-options="fit:true,border:false">
                    <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 10px;">
                        <label>
                            用户名:                
                        <input class="easyui-searchbox" id="tdKeyword" type="text" data-options="prompt:'关键字搜索',searcher:SearchTT" />
                        </label>
                        <label>
                            用户性质:
                        <select id="tdUserType" style="width: 200px;" class="easyui-combobox" data-options="editable:false">
                            <option value="">全部</option>
                            <option value="SystemUser">系统用户</option>
                            <option value="APPUser">员工APP用户</option>
                        </select>
                        </label>
                        <label>
                            所属部门:
                       <input type="text" class="easyui-combobox" id="tdDepartment" />
                            <asp:HiddenField runat="server" ID="hdDepartment" />
                        </label>
                        <label class="searchlabel">
                            <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">查询</a>
                        </label>
                    </div>
                    <div data-options="region:'center',border:false">
                        <table id="tt_table"></table>
                        <div id="tt_mm">
                            <a href="javascript:void(0)" onclick="addUser()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">增加</a>
                            <a href="javascript:void(0)" onclick="editUser()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                            <a href="javascript:void(0)" onclick="removeUser()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                            <a href="javascript:void(0)" onclick="editUserPwd()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改密码</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
