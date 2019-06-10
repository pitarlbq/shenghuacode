<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent.Master" AutoEventWireup="true" CodeBehind="Setup.aspx.cs" Inherits="Web.InitialSetup.Setup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function addproject() {
            var projectid = top.GetSelectProjectID();
            if (projectid == null || projectid == "") {
                projectid = 1;
            }
            var can_add = "<%=this.can_add?1:0%>";
            if (projectid == 1 && can_add == 0) {
                show_message("授权项目数已达上限", "warning");
                return;
            }
            do_open_dialog('新增业态', '../InitialSetup/AddSubProject.aspx?ProjectID=' + projectid);
            return;
        }
        function deleteproject() {
            var projectids = [];
            var RoomIDs = [];
            var rows = $("#tt_table").datagrid("getSelections");
            if (rows.length > 0) {
                $.each(rows, function (index, row) {
                    RoomIDs.push(row.RoomID);
                })
            }
            else {
                RoomIDs = top.GetSelectedRooms();
                projectids = [];
                var projectid = top.GetSelectProjectID();
                if (RoomIDs.length == 0 && (projectid == null || projectid == "")) {
                    show_message("请选择一个项目", "warning");
                    return;
                }
                if (projectid != null && projectid != "") {
                    projectids.push(projectid);
                    if ($.inArray(1, projectids) > -1) {
                        show_message("禁止删除选中资源", "warning");
                        return;
                    }
                }
            }
            if (projectids.length == 0 && RoomIDs.length == 0) {
                show_message("请选择一个项目", "warning");
                return;
            }
            var options = { visit: "checkdeleteproject", ProjectIds: JSON.stringify(projectids), RoomIDs: JSON.stringify(RoomIDs) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/CheckStatusHandler.ashx',
                data: options,
                success: function (data) {
                    if (data.status) {
                        top.$.messager.confirm("提示", "确认删除选中的资源档案?", function (r) {
                            if (r) {
                                deleteprojectprocess(projectids, RoomIDs);
                            }
                        });
                        return;
                    }
                    if (data.error) {
                        show_message(data.error, "warning");
                        return;
                    }
                    show_message("系统异常", "error");
                }
            });
        }
        function deleteprojectprocess(projectids, RoomIDs) {
            MaskUtil.mask('body', '提交中');
            var options = { visit: 'deletesubproject', RoomIDs: JSON.stringify(RoomIDs), ProjectIDs: JSON.stringify(projectids) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ProjectHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status) {
                        show_message("删除成功", "success", function () {
                            doSearch();
                            $('#tt_table').datagrid('reaload');
                        });
                        return;
                    }
                    if (message.error) {
                        show_message(message.error, 'warning');
                        return;
                    }
                    show_message("删除失败", "error");
                }
            });
        }
        var CompanyID, hdProjectID, hdRoomIDs, hdSearchAreas, tdKeyword;
        $(function () {
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            hdProjectID = $("#<%=this.hdProjectID.ClientID%>");
            hdRoomIDs = $("#<%=this.hdRoomIDs.ClientID%>");
            hdSearchAreas = $("#<%=this.hdSearchAreas.ClientID%>");
            tdKeyword = $("#<%=this.tdKeyword.ClientID%>");
            SetSearchAreaInfo();
        });
        function openSearchbox() {
            $('#searcharea').show();
            $('#win_Search').window('open');
        }
        function closeSearchwin() {
            $('#searcharea').hide();
            $('#win_Search').window('close');
            SetSearchAreaInfo();
        };
        function SetSearchAreaInfo() {
            var searcharray = [];
            var elems = document.getElementsByName("searchcheck");
            $.each(elems, function () {
                if (this.checked) {
                    var elem = $(this);
                    searcharray.push(elem.val());
                }
            });
            hdSearchAreas.val(JSON.stringify(searcharray));
        }
        function addorgnization() {
            var projectid = top.GetSelectProjectID();
            if (projectid == null || projectid == "") {
                show_message("请选择一个项目", "warning");
                return;
            }
            var can_add = "<%=this.can_add?1:0%>";
            if (projectid == 1 && can_add == 0) {
                show_message("授权项目数已达上限", "warning");
                return;
            }
            var id = Number(projectid);
            var treeObj = $.fn.zTree.getZTreeObj("tt");
            var node = treeObj.getNodeByParam("id", id, null);
            if (node.TypeDesc == "" || node.TypeDesc == null) {
                node.TypeDesc = "小区";
            }
            do_open_dialog('新增公司', '../InitialSetup/AddSubProject.aspx?ProjectID=' + id);
            return;
        }
    </script>

    <script src="../js/Page/InitialSetup/InitialSetup.js?token=<%=base.getToken() %>"></script>
    <style type="text/css">
        .radioBtn {
            height: 16px;
            vertical-align: middle;
        }

        .checkboxBtn {
            vertical-align: middle;
            margin-right: 2px;
        }

        .btntoolbar.l-btn {
            padding: 0px;
        }

            .btntoolbar.l-btn:hover {
                padding: 0px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server" id="form1">
        <div class="easyui-layout" fit="true">
            <div class="op" data-options="region:'north'" style="height: 60px; padding: 10px;">
                <div style="display: inline-table; width: 33%;">
                    <%if (base.CheckAuthByModuleCode("1191083"))
                      { %>
                    <div style="width: 100%;">
                        <div id="win_Search" class="easyui-window" data-options="title:'选择筛选条件',closed:true" style="width: 350px; height: 300px; padding: 10px">
                            <table style="width: 100%;">
                                <tr>
                                    <td>资源位置</td>
                                    <td>
                                        <input type="checkbox" checked="checked" value="FullName" name="searchcheck" /></td>
                                    <td>房间编号</td>
                                    <td>
                                        <input type="checkbox" checked="checked" value="Name" name="searchcheck" /></td>
                                </tr>
                                <tr>
                                    <td>房间类型</td>
                                    <td>
                                        <input type="checkbox" value="RoomType" name="searchcheck" /></td>
                                    <td>户型</td>
                                    <td>
                                        <input type="checkbox" value="RoomLayout" name="searchcheck" /></td>
                                </tr>
                                <tr>
                                    <td>业主姓名</td>
                                    <td>
                                        <input type="checkbox" value="RelationName" name="searchcheck" /></td>
                                    <td>业主身份证</td>
                                    <td>
                                        <input type="checkbox" value="OwnerIDCard" name="searchcheck" /></td>
                                </tr>
                                <tr>
                                    <td>业主手机号码</td>
                                    <td>
                                        <input type="checkbox" value="OwnerPhone" name="searchcheck" /></td>
                                    <td>租户姓名</td>
                                    <td>
                                        <input type="checkbox" value="RentName" name="searchcheck" /></td>
                                </tr>
                                <tr>
                                    <td>租户手机号</td>
                                    <td>
                                        <input type="checkbox" value="RentPhoneNumber" name="searchcheck" /></td>
                                    <td>租户身份证号</td>
                                    <td>
                                        <input type="checkbox" value="RentIDCard" name="searchcheck" /></td>
                                </tr>
                                <tr>
                                    <td>房源属性</td>
                                    <td>
                                        <input type="checkbox" value="RoomProperty" name="searchcheck" /></td>
                                    <td>房间状态</td>
                                    <td>
                                        <input type="checkbox" value="RoomState" name="searchcheck" /></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <input type="button" value="保存" onclick="closeSearchwin()" /></td>
                                </tr>
                            </table>
                        </div>
                        <label>
                            关键字:                
                        <input class="easyui-searchbox" id="tdKeyword" runat="server" type="text" data-options="prompt:'关键字搜索',searcher:SearchTT" style="width: 150px" />
                        </label>
                        <label>
                            <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">查询</a>
                        </label>
                    </div>
                    <%} %>
                </div>
                <div style="display: inline-table; width: 65%;">
                    <div style="width: 100%;">
                        <%if (base.CheckAuthByModuleCode("1191077"))
                          { %>
                        <a href="javascript:void(0)" onclick="addproject()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-add'">新增业态</a>
                        <%} %>
                        <%if (base.CheckAuthByModuleCode("1191078"))
                          { %>
                        <a href="javascript:void(0)" onclick="editProject()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                        <%} %>
                        <%if (base.CheckAuthByModuleCode("1191079"))
                          { %>
                        <a href="javascript:void(0)" onclick="deleteproject()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                        <%} %>
                        <%--<a href="javascript:void(0)" onclick="do_connection()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-guanlian'">关联</a>--%>
                        <%if (base.CheckAuthByModuleCode("1191080"))
                          { %>
                        <a href="javascript:void(0)" onclick="do_export()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                        <%} %>
                        <%if (base.CheckAuthByModuleCode("1191081"))
                          { %>
                        <a href="javascript:void(0)" onclick="openImport()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-import'">导入</a>
                        <%} %>
                        <%if (base.CheckAuthByModuleCode("1191082"))
                          { %>
                        <a href="javascript:void(0)" onclick="openTableSetUp()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-setting'">配置</a>
                        <%} %>
                        <%--<a href="javascript:void(0)" onclick="openFieldSetUp()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-setting'">参数</a>--%>
                        <asp:HiddenField ID="hdProjectID" runat="server" />
                        <asp:HiddenField ID="hdRoomIDs" runat="server" />
                        <asp:HiddenField ID="hdSearchAreas" runat="server" />
                    </div>
                </div>
            </div>
            <div data-options="region:'center'" title="">
                <table id="tt_table">
                </table>
                <div id="tb">
                </div>
            </div>
        </div>
    </form>
</asp:Content>
