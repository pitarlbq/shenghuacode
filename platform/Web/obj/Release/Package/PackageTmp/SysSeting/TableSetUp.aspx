<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="TableSetUp.aspx.cs" Inherits="Web.SysSeting.TableSetUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var PageCode, ColumnServiceStatus, ColumnServiceType,TableName;
        $(function () {
            PageCode = "<%=this.PageCode%>";
            TableName = "<%=this.TableName%>";
            ColumnServiceStatus = "<%=this.ColumnServiceStatus%>";
            ColumnServiceType = "<%=this.ColumnServiceType%>";
            getTableFields();
            $('#btnAll').bind('click', function () {
                if ($('#btnAll').prop('checked')) {
                    $('input[name="FieldCheck"]').prop('checked', true);
                }
                else {
                    $('input[name="FieldCheck"]').prop('checked', false);
                }
            })
        });
        function getTableFields() {
            MaskUtil.mask();
            var options = { visit: 'gettablefield', PageCode: PageCode, ColumnServiceStatus: ColumnServiceStatus, ColumnServiceType: ColumnServiceType, TableName: TableName };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/SysSettingHandler.ashx',
                data: options,
                success: function (data) {
                    MaskUtil.unmask();
                    if (data.status) {
                        var html = '';
                        $.each(data.list, function (first_index, first_item) {
                            if (first_item.list.length == 0) {
                                return true;
                            }
                            if (first_item.Title != '') {
                                html += '<div class="header_title">';
                                html += first_item.Title;
                                html += '</div>';
                            }
                            html += '<table class="add" id="tablefiled">';
                            html += '<tr>';
                            html += '<td style="width: 15%">排序';
                            html += ' </td>';
                            html += '<td style="width: 20%">名称';
                            html += '</td>';
                            html += '<td style="width: 15%">是否显示';
                            html += '</td>';
                            html += '<td style="width: 15%">排序';
                            html += '</td>';
                            html += '<td style="width: 20%">名称';
                            html += '</td>';
                            html += '<td style="width: 15%">是否显示';
                            html += '</td>';
                            html += '</tr>';
                            $.each(first_item.list, function (index, item) {
                                if (index % 2 == 0) {
                                    html += '<tr>';
                                    html += '<td>';
                                    html += '<input type="text" style="width:80px" id="SortOrder_' + item.FieldID + '_' + item.ID + '" value="' + item.SortOrder + '">';
                                    html += '</td>';
                                    html += '</td>';
                                    html += '<td>';
                                    html += item.ColumnName;
                                    html += '</td>';
                                    html += '<td>';
                                    if (item.IsShown) {
                                        html += '<input checked="checked" name="FieldCheck" type="checkbox" id="RoomResource_' + item.FieldID + '_' + item.ID + '" value="' + item.ID + '" data-fieldid="' + item.FieldID + '" />';
                                    }
                                    else {
                                        html += '<input type="checkbox" name="FieldCheck" id="RoomResource_' + item.FieldID + '_' + item.ID + '" value="' + item.ID + '" data-fieldid="' + item.FieldID + '" />';
                                    }
                                }
                                else if (index % 2 == 1) {
                                    html += '<td>';
                                    html += '<input type="text" style="width:80px" id="SortOrder_' + item.FieldID + '_' + item.ID + '" value="' + item.SortOrder + '">';
                                    html += '</td>';
                                    html += '</td>';
                                    html += '<td>';
                                    html += item.ColumnName;
                                    html += '</td>';
                                    html += '<td>';
                                    if (item.IsShown) {
                                        html += '<input checked="checked" name="FieldCheck" type="checkbox" id="RoomResource_' + item.FieldID + '_' + item.ID + '" value="' + item.ID + '" data-fieldid="' + item.FieldID + '" />';
                                    }
                                    else {
                                        html += '<input type="checkbox" name="FieldCheck" id="RoomResource_' + item.FieldID + '_' + item.ID + '" value="' + item.ID + '" data-fieldid="' + item.FieldID + '" />';
                                    }
                                    html += '</tr>';
                                }
                                if ((index == first_item.list.length - 1) && first_item.list.length % 2 == 1) {
                                    html += '</tr>';
                                }
                            })
                            html += '</table>';
                        });
                        $("#table_content").append(html);
                    }
                    else {
                        show_message("获取列表失败", "info");
                    }
                }
            });
        }

        function do_save() {
            var IDList = [];
            var SortOrderList = [];
            var FieldIDList = [];
            $("[name='FieldCheck']").each(function () {
                if (this.checked) {
                    var ID = $(this).val();
                    var data_fieldid = $(this).attr('data-fieldid')
                    IDList.push(ID);
                    var sortorder = $("#SortOrder_" + data_fieldid + "_" + ID).val();
                    if (sortorder == "" || sortorder == null) {
                        sortorder = 0;
                    }
                    SortOrderList.push(sortorder);
                    FieldIDList.push(data_fieldid);
                }
            });
            MaskUtil.mask('body', '提交中');
            var options = { visit: 'savetablefield', IDs: JSON.stringify(IDList), PageCode: PageCode, SortOrders: JSON.stringify(SortOrderList), FieldIDs: JSON.stringify(FieldIDList), ColumnServiceStatus: ColumnServiceStatus, ColumnServiceType: ColumnServiceType };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/SysSettingHandler.ashx',
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
        function do_close() {
            try {
                parent.do_close_dialog(function () {
                    parent.reloadTT();
                });
            } catch (e) {
            }
            try {
                parent.do_close_dialog(function () {
                    parent.loadTT();
                });
            } catch (e) {
            }
            try {
                parent.do_close_dialog(function () {
                    parent.loadtt();
                });
            } catch (e) {
            }
            try {
                parent.do_close_dialog(function () {
                    parent.document.getElementById('subPageFrame').contentWindow.loadTT();
                }, true);
            } catch (e) {
            }
        }
    </script>
    <style type="text/css">
        .panel-body {
            background: #f0f0f0;
        }

        table.add {
            width: 90%;
            margin: 0 auto;
            margin-top: 10px;
            border-collapse: collapse;
            border-spacing: 0px;
            border: solid 1px #f0f0f0;
            background: #fff;
        }

            table.add td {
                padding: 3px 5px;
                text-align: left;
                border: solid 1px #f0f0f0;
                border-radius: 5px !important;
            }

        input[type=text] {
            width: 50px;
            height: 28px;
            line-height: 28px;
            border: solid 1px #ddd;
            border-radius: 5px !important;
        }

        .header_title {
            padding: 10px 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <div class="operation_box">
            <input type="checkbox" id="btnAll" style="height: 15px; vertical-align: middle; margin: 0;" /><label style="vertical-align: middle; margin: 0;">全选</label>
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container" id="table_content">
        </div>
    </form>
</asp:Content>
