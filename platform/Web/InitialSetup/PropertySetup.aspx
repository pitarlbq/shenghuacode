<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="PropertySetup.aspx.cs" Inherits="Web.InitialSetup.PropertySetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ProjectID, CompanyID;
        $(function () {
            ProjectID = "<%=Request.QueryString["ProjectID"]%>";
            PropertyID = "<%=Request.QueryString["PropertyID"]%>";
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            getTableFields();
            $('#btnAll').bind('click', function () {
                if ($('#btnAll').prop('checked')) {
                    $('input[name="FieldCheck"]').prop('checked', true);
                }
                else {
                    $('input[name="FieldCheck"]').prop('checked', false);
                }
            })
        })
        function getTableFields() {
            MaskUtil.mask();
            var options = { visit: 'loadtopproperty', ProjectID: ProjectID, PropertyID: PropertyID };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ProjectPropertyHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status) {
                        var html = '';
                        $.each(message.list, function (index, item) {
                            var SortOrder = (Number(item.MainSortOrder) > 0 ? item.MainSortOrder : 0);
                            if (Number(item.SortOrder) > 0) {
                                SortOrder = item.SortOrder;
                            }
                            if (index % 2 == 0) {
                                html += '<tr>';
                                html += '<td>';
                                html += '<input type="text" style="width:80px" id="SortOrder_' + item.ID + '" value="' + SortOrder + '">';
                                html += '</td>';
                                html += '</td>';
                                html += '<td id="YTName_' + item.ID + '">';
                                html += item.Title;
                                html += '</td>';
                                html += '<td>';
                                if (!item.IsHide) {
                                    html += '<input checked="checked" name="FieldCheck" type="checkbox" id="RoomResource_' + item.ID + '" value="' + item.ID + '" />';
                                }
                                else {
                                    html += '<input type="checkbox" name="FieldCheck" id="RoomResource_' + item.ID + '" value="' + item.ID + '" />';
                                }
                            }
                            else if (index % 2 == 1) {
                                html += '<td>';
                                html += '<input type="text" style="width:80px" id="SortOrder_' + item.ID + '" value="' + SortOrder + '">';
                                html += '</td>';
                                html += '</td>';
                                html += '<td id="YTName_' + item.ID + '">';
                                html += item.Title;
                                html += '</td>';
                                html += '<td>';
                                if (!item.IsHide) {
                                    html += '<input checked="checked" name="FieldCheck" type="checkbox" id="RoomResource_' + item.ID + '" value="' + item.ID + '" />';
                                }
                                else {
                                    html += '<input type="checkbox" name="FieldCheck" id="RoomResource_' + item.ID + '" value="' + item.ID + '" />';
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
                        show_message("获取列表失败", "warning");
                    }
                }
            });
        }
        function do_save() {
            var IDList = [];
            var SortOrderList = [];
            var YTNameList = [];
            var CheckList = [];
            $("[name='FieldCheck']").each(function () {
                var ID = $(this).val();
                IDList.push(ID);
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
            MaskUtil.mask('body', '提交中');
            var options = { visit: 'savetopproperty', IDs: JSON.stringify(IDList), ProjectID: ProjectID, SortOrders: JSON.stringify(SortOrderList), CheckLists: JSON.stringify(CheckList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ProjectPropertyHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status) {
                        show_message('保存成功', 'success', function () {
                            do_close();
                        });
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
        function do_remove() {
            var IDList = [];
            $("[name='FieldCheck']").each(function () {
                var ID = $(this).val();
                if (this.checked) {
                    IDList.push(ID);
                }
            });
            if (IDList.length == 0) {
                show_message('请选择业态', 'warning');
            }
            MaskUtil.mask('body', '提交中');
            top.$.messager.confirm('提示', '确认删除选中的业态?', function (r) {
                if (r) {
                    var options = { visit: 'removetopproperty', IDs: JSON.stringify(IDList) };
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        url: '../Handler/ProjectPropertyHandler.ashx',
                        data: options,
                        success: function (message) {
                            MaskUtil.unmask();
                            if (message.status) {
                                show_message('操作成功', 'success', function () {
                                    do_close();
                                });
                            }
                            else {
                                show_message('系统错误', 'error');
                            }
                        }
                    });
                }
            })
        }
        function do_close() {
            parent.$("#win_set").window("close");
        }
    </script>
    <style type="text/css">
        .panel-body {
            background: #f0f0f0;
        }

        table.add {
            width: 96%;
            margin: 0 auto;
            border-collapse: collapse;
            border-spacing: 0px;
            border: solid 1px #ccc;
            background: #fff;
            border-radius: 5px !important;
        }

            table.add td {
                padding: 3px 5px;
                text-align: left;
                border: solid 1px #ccc;
            }

        input[type=text] {
            width: 50px;
            border-radius: 5px !important;
            height: 25px;
            border: solid 1px #ddd;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <div class="operation_box">
            <input type="checkbox" id="btnAll" style="height: 15px; vertical-align: middle; margin: 0;" /><label style="vertical-align: middle; margin: 0;">全选</label>
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_remove()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
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
        </div>
    </form>
</asp:Content>
