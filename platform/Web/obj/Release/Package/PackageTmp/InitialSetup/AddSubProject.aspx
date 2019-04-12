<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="AddSubProject.aspx.cs" Inherits="Web.InitialSetup.AddSubProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ProjectID, FullName, ParentID, TabList = [];
        $(function () {
            ProjectID = "<%=this.ProjectID%>";
            ParentID = "<%=this.ParentID%>";
            FullName = "<%=this.FullName %>";
            $('#projectname').textbox('setValue', FullName);
            get_tab_list();
            top.isUpdate = false;
            if (ProjectID != 1) {
                $("#projectname").textbox({ disabled: true });
                $("#divedit").removeClass("hidefield");
                $("#divsave").addClass("hidefield");
            }
            else {
                $("#projectname").textbox({ disabled: false });
                $("#editsavetd").addClass("hidefield");
            }
        })
        function do_close() {
            parent.do_close_dialog(function () {
                if (top.isUpdate) {
                    parent.doSearch();
                }
            })
        }
        function get_tab_list() {
            for (var i = 0; i < TabList.length; i++) {
                $('#TabAccording').tabs('close', TabList[i].title);
            }
            TabList = [];
            var options = { visit: 'loadyttables', ProjectID: ProjectID };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ProjectPropertyHandler.ashx',
                data: options,
                success: function (data) {
                    if (data.status && data.values.length > 0) {
                        TabList = data.values;
                        $.each(data.values, function (index, item) {
                            add_tab(item.title, 'AddProjectProperty.aspx?t=' + index + '&ProjectID=' + ProjectID + '&PropertyID=' + item.ID, data.values.length);
                        })
                        $('#TabAccording').tabs({
                            onSelect: function (title, index) {
                                loadIframe();
                            }
                        });
                        $('#TabAccording').tabs('select', 0);
                    }
                }
            });
        }
        function loadIframe() {
            var curTab = $('#TabAccording').tabs('getSelected');
            if (curTab.find("iframe:first").attr("src") == "") {
                var iframesrc = curTab.find("input[type=hidden]:first").val();
                curTab.find("iframe:first").attr("src", iframesrc);
            }
        }
        function add_tab(title, url, count) {
            var content = '';
            content += '<input type="hidden" value="' + url + '" />';
            if (count == 1) {
                content += '<iframe name="TabFrame" scrolling="auto" frameborder="0" src="' + url + '" style="width:100%;height:99%;border:0;"></iframe>';
            } else {
                content += '<iframe name="TabFrame" scrolling="auto" frameborder="0" src="" style="width:100%;height:99%;border:0;"></iframe>';
            }
            $('#TabAccording').tabs('add', {
                title: title,
                closable: false,
                content: content
            });
        }
        function openytwin() {
            var iframeurl = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../InitialSetup/AddProperty.aspx?ProjectID=" + ProjectID + "' style='width:100%;height:" + ($(parent.window).height() - 40) + "px'></iframe>";
            open_parent_win('新增业态信息', 'win_pro', iframeurl, ($(parent.window).width() - 300), $(parent.window).height(), 0, true, true, function () {
                parent.$("#win_pro").remove();
            })
        }
        function showytwin() {
            var iframeurl = "";
            if (ProjectID != 1 && ParentID != 1) {
                return;
            }
            var iframeurl = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../InitialSetup/PropertySetup.aspx?ProjectID=" + ProjectID + "' style='width:100%;height:99%'></iframe>";
            open_parent_win('业态设置', 'win_set', iframeurl, ($(parent.window).width() - 300), $(parent.window).height(), 0, true, true, function () {
                parent.$("#win_set").remove();
                get_tab_list();

            })
        }
        function editName() {
            $("#projectname").textbox({ disabled: false });
            $("#divedit").addClass("hidefield");
            $("#divsave").removeClass("hidefield");
            var options = { visit: 'getprojectbyid', ID: ProjectID };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ProjectHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        $("#projectname").textbox('setValue', message.Name);
                    }
                }
            });
        }
        function saveName() {
            $("#projectname").textbox({ disabled: true });
            $("#divedit").removeClass("hidefield");
            $("#divsave").addClass("hidefield");
            var ProjectName = $("#projectname").textbox('getValue');
            if (ProjectName == "") {
                show_message("项目名称不能为空", "warning");
                return;
            }
            var CompanyID = GetSelectCompanyID();
            var options = { visit: 'saveprojectnamebyid', ProjectID: ProjectID, ProjectName: ProjectName, CompanyID: CompanyID };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ProjectHandler.ashx',
                data: options,
                success: function (data) {
                    if (data.status) {
                        show_message("保存成功", "success", function () {
                            $("#projectname").textbox('setValue', message.FullName);
                        });
                    }
                    else if (data.error) {
                        show_message(data.error, "warning");
                        return;
                    }
                    else {
                        show_message("保存失败", "error");
                    }
                }
            });
        }
    </script>
    <link href="../styles/main.css?v=1.1" rel="stylesheet" />
    <style>
        table.info {
            margin: 0;
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server" id="myform">
        <div class="easyui-layout" fit="true">
            <div data-options="region:'north'" class="searcharea" style="height: 100px; padding: 40px 0 0 0;">
                <div class="operation_box">
                    <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
                </div>
                <table class="info">
                    <tr>
                        <td style="width: 15%; padding-left: 20px;">项目名称:</td>
                        <td style="width: 50%;">
                            <input id="projectname" class="easyui-textbox inputbox" type="text" name="name" style="width: 100%; min-width: 200px; height: 28px;" /></td>
                        <td id="editsavetd" style="width: 10%;">
                            <div id="divedit">
                                <a href="javascript:void(0)" onclick="editName()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                            </div>
                            <div id="divsave" class="hidefield">
                                <a href="javascript:void(0)" onclick="saveName()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                            </div>
                        </td>
                        <td style="width: 25%; text-align: right;">
                            <%if (base.CheckAuthByModuleCode("1191132"))
                              { %>
                            <%if (this.ParentID == 1 || this.ProjectID == 1)
                              { %>
                            <a href="javascript:void(0)" onclick="openytwin()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">添加业态</a>
                            <%}
                              } %>
                            <%if (base.CheckAuthByModuleCode("1191133"))
                              { %>
                            <%if (this.ParentID == 1 || this.ProjectID == 1)
                              { %>
                            <a href="javascript:void(0)" onclick="showytwin()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-setting'">业态设置</a>
                            <%}
                              }%>
                        </td>
                    </tr>
                </table>
            </div>
            <div data-options="region:'center'" title="">
                <div id="TabAccording" data-options="fit:true,tabPosition:'left',headerWidth:100,tabHeight:35" class="easyui-tabs" style="width: 100%; height: 100%; margin: 0 auto;">
                </div>
            </div>
        </div>
    </form>
</asp:Content>
