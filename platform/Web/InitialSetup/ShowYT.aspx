<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ShowYT.aspx.cs" Inherits="Web.InitialSetup.ShowYT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ProjectID, CompanyID;
        $(function () {
            ProjectID = "<%=Request.QueryString["ProjectID"]%>";
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            getTableFields();
        })
        function getTableFields() {
            var options = { visit: 'loadtopyt', ProjectID: ProjectID, CompanyID: CompanyID };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/SysSettingHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        var html = '';
                        $.each(message.list, function (index, item) {
                            var SortOrder = (Number(item.OrderBy) > 0 ? item.OrderBy : 0);
                            if (Number(item.YTOrderBy) > 0) {
                                SortOrder = item.YTOrderBy;
                            }
                            if (index % 2 == 0) {
                                html += '<tr>';
                                html += '<td>';
                                html += '<input type="text" style="width:80px" id="SortOrder_' + item.ID + '" value="' + SortOrder + '">';
                                html += '</td>';
                                html += '</td>';
                                html += '<td id="YTName_' + item.ID + '">';
                                html += item.Name;
                                html += '</td>';
                                html += '<td>';
                                if (item.IsShow) {
                                    html += '<input checked="checked" name="FieldCheck" type="checkbox" id="RoomResource_' + item.ID + '" value="' + item.ID + '" ytvalue="' + item.YTOrderID + '" />';
                                }
                                else {
                                    html += '<input type="checkbox" name="FieldCheck" id="RoomResource_' + item.ID + '" value="' + item.ID + '" ytvalue="' + item.YTOrderID + '" />';
                                }
                            }
                            else if (index % 2 == 1) {
                                html += '<td>';
                                html += '<input type="text" style="width:80px" id="SortOrder_' + item.ID + '" value="' + SortOrder + '">';
                                html += '</td>';
                                html += '</td>';
                                html += '<td id="YTName_' + item.ID + '">';
                                html += item.Name;
                                html += '</td>';
                                html += '<td>';
                                if (item.IsShow) {
                                    html += '<input checked="checked" name="FieldCheck" type="checkbox" id="RoomResource_' + item.ID + '" value="' + item.ID + '" ytvalue="' + item.YTOrderID + '" />';
                                }
                                else {
                                    html += '<input type="checkbox" name="FieldCheck" id="RoomResource_' + item.ID + '" value="' + item.ID + '" ytvalue="' + item.YTOrderID + '" />';
                                }
                                html += '</tr>';
                            }
                            if ((index == message.list.length - 1) && message.list.length % 2 == 1) {
                                html += '</tr>';
                            }
                        })
                        $("#tablefiled").append(html);
                    }
                    else {
                        show_message("获取列表失败", "error");
                    }
                }
            });
        }
        function saveResource() {
            var IDList = [];
            var SortOrderList = [];
            var YTNameList = [];
            var CheckList = [];
            $("[name='FieldCheck']").each(function () {
                var YTOrderID = $(this).attr("ytvalue");
                IDList.push(YTOrderID);
                var ID = $(this).val();
                var sortorder = $("#SortOrder_" + ID).val();
                if (sortorder == "" || sortorder == null) {
                    sortorder = 0;
                }
                SortOrderList.push(sortorder);
                var ytname = $("#YTName_" + ID).text();
                YTNameList.push(ytname);
                if (this.checked) {
                    CheckList.push(1);
                }
                else {
                    CheckList.push(0);
                }
            });
            var options = { visit: 'savetopyt', IDs: JSON.stringify(IDList), ProjectID: ProjectID, CompanyID: CompanyID, SortOrders: JSON.stringify(SortOrderList), YTNameLists: JSON.stringify(YTNameList), CheckLists: JSON.stringify(CheckList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/SysSettingHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('保存成功', 'success', function () {
                            closeWin();
                        });
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
        function closeWin() {
            parent.$("#win").window("close");
        }
    </script>
    <style type="text/css">
        table.add {
            width: 100%;
            margin: 0 auto;
            margin-top: 10px;
            border-collapse: collapse;
            border-spacing: 0px;
            border: solid 1px #ccc;
        }

            table.add td {
                padding: 3px 5px;
                text-align: left;
                border: solid 1px #ccc;
            }

        input {
            width: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <div style="text-align: center;">
            <a href="javascript:void(0)" onclick="saveResource()" class="easyui-linkbutton bttoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="closeWin()" class="easyui-linkbutton bttoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <table class="add" id="tablefiled">
            <tr>
                <td style="width: 15%">排序
                </td>
                <td style="width: 20%">名称
                </td>
                <td style="width: 15%">是否显示
                </td>
                <td style="width: 15%">排序
                </td>
                <td style="width: 20%">名称
                </td>
                <td style="width: 15%">是否显示
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
