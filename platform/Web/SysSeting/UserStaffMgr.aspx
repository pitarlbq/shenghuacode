<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent8.Master" AutoEventWireup="true" CodeBehind="UserStaffMgr.aspx.cs" Inherits="Web.SysSeting.UserStaffMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var op = '';
        $(function () {
            op = "<%=this.op%>";
            if (op == 'choose') {
                setTimeout(function () {
                    $("#main_form_layout").layout('panel', 'north').panel("options").height = 80;
                    $("#main_form_layout").layout("resize");
                    $('.operation_box').show();
                }, 100);
            }
        })
        function do_close() {
            parent.do_close_dialog(function () {
                parent.do_choose_staffuser_done();
            })
        }
    </script>
    <style>
        .btn.btn-link {
            padding: 0 !important;
        }

        .operation_box {
            position: relative;
            text-align: right;
        }
    </style>
    <script src="../js/Page/SysSetting/UserStaffMgr.js?v=<%=base.getToken() %>" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div id="main_form_layout" class="easyui-layout" data-options="fit:true,border:false">
            <div data-options="region:'north',border:false" style="height: 40px; font-size: 12px; padding: 5px;">
                <div class="operation_box" style="display: none;">
                    <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
                </div>
                <label class="search_item">
                    <label class="search_title">
                        关键字           
                    </label>
                    <input class="easyui-searchbox" id="tdKeywords" style="width: 200px; height: 28px;" type="text" data-options="prompt:'姓名，电话，用户名',searcher:SearchTT" />
                </label>
                <label>
                    <a href="#" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">查询</a>
                </label>
            </div>
            <div data-options="region:'center'" title="" style="border: none;">
                <table id="tt_table">
                </table>
                <div id="tb">
                    <a href="#" onclick="do_add()" class="easyui-linkbutton btnlinkbar icon_add" data-options="plain:true,iconCls:'icon-add'">新增</a>
                    <a href="#" onclick="do_edit()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">编辑</a>
                    <a href="#" onclick="do_remove()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                    <%if (!string.IsNullOrEmpty(this.op) && this.op.Equals("choose"))
                      { %>
                    <a href="javascript:void(0)" onclick="chooseRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-choose'">选择</a>
                    <%} %>
                </div>
            </div>
        </div>
    </form>
</asp:Content>

