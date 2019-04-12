<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="AddProject.aspx.cs" Inherits="Web.InitialSetup.AddProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var firsttitle, ProjectID, CompanyID, AddMan, IsParent, CurrentGrade, ParentID, PropertyID, canCloseYT, FullName, TotalRoomCount;
        $(function () {
            firsttitle = "住宅";
            ProjectID = "<%=this.ProjectID%>";
            CompanyID = "<%=this.CompanyID%>";
            AddMan = "<%=this.AddMan%>";
            IsParent = "<%=this.IsParent%>";
            CurrentGrade = "<%=this.CurrentGrade%>";
            ParentID = "<%=this.ParentID%>";
            canCloseYT = $("#<%=this.hdCloseYT.ClientID%>");
            FullName = "<%=this.FullName %>";
            TotalRoomCount = Number("<%=this.TotalRoomCount%>");
            $('#projectname').textbox('setValue', FullName);
        })
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$("#tt_table").datagrid("reload");
            })
        }
    </script>
    <%if (this.can_add)
      { %>
    <script src="../js/Page/InitialSetup/AddProject.js?token=<%=base.getToken()%>"></script>
    <%} %>
    <script>
        $(function () {
            $("#ytAccording").accordion('getSelected').panel('collapse')
        })
    </script>
    <style>
        .panel-body {
            background: #f0f0f0;
        }
    </style>
    <link href="../styles/main.css?v=1.1" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server" id="myform">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <asp:HiddenField runat="server" ID="hdCloseYT" />
            <%if (this.can_add)
              { %>
            <div class="table_title">
                项目初始化
            </div>
            <table class="info">
                <tr>
                    <td style="width: 10%;">项目名称:</td>
                    <td style="width: 60%;">
                        <input id="projectname" class="easyui-textbox inputbox" type="text" name="name" style="width: 100%; min-width: 200px;" /></td>
                    <td id="editsavetd" style="width: 10%;">
                        <div id="divedit">
                            <a href="javascript:void(0)" onclick="editName()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                        </div>
                        <div id="divsave" class="hidefield">
                            <a href="javascript:void(0)" onclick="saveName()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                        </div>
                    </td>
                    <td style="width: 20%; text-align: right;">
                        <%if (base.CheckAuthByModuleCode("1191132"))
                          { %>
                        <%if (this.ParentID == 1 || this.ProjectID == 1)
                          { %>
                        <a href="javascript:void(0)" onclick="openytwin()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">添加业态</a>
                        <%}
                          } %>
                        <%if (base.CheckAuthByModuleCode("1191133"))
                          { %>
                        <%if (this.ParentID == 1)
                          { %>
                        <a href="javascript:void(0)" onclick="showytwin()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-setting'">业态设置</a>
                        <%}
                          }%>
                    </td>
                </tr>
            </table>
            <div id="ytAccording" class="easyui-accordion" style="width: 99%; margin: 0 auto;">
                <asp:Repeater runat="server" ID="rptAccord">
                    <ItemTemplate>
                        <div title="<span style='display:none;'><%#Eval("ID")%>_</span><%#Eval("Title")%>初始化" pid='<%#Eval("ID")%>' style="overflow: auto; padding: 5px 0 30px 0;" data-options="selected:false">
                            <table id="<%#Eval("ID")%>_table">
                            </table>
                            <div id="<%#Eval("ID")%>_win" class="easyui-window" title="<%#Eval("Title")%>" data-options="closed:true,modal:true,closable:true,maximizable: false,minimizable:false,collapsible:false" style="width: 800px; height: 400px; padding: 5px;">
                                <div class="easyui-panel" style="width: 100%; height: 80%; border: 0;">
                                    <table id="<%#Eval("ID")%>_wintable">
                                    </table>
                                </div>
                                <div class="easyui-panel" style="width: 100%; height: 20%; border: 0; text-align: center;">
                                    <a href="javascript:void(0)" onclick="newsaveyt('<%#Eval("Title")%>','<%#Eval("ID")%>')" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                                    <a href="javascript:void(0)" onclick="closewin('<%#Eval("Title")%>','<%#Eval("ID")%>')" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <%} %>
        </div>
    </form>
</asp:Content>
