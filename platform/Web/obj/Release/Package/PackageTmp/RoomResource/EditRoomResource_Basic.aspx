<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditRoomResource_Basic.aspx.cs" Inherits="Web.RoomResource.EditRoomResource_Basic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Comm/GetTypeList.js?v=<%=base.getToken() %>"></script>
    <script type="text/javascript">
        var RoomTypeList = [];
        var RoomLayoutList = [];
        var RoomPropertyList = [];
        var RoomID;
        $(function () {
            RoomID = "<%=this.RoomID%>";
            //getFieldContent();
        })
        function do_save() {
            var isValid = $("#ff").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var FieldList = [];
            //自定义属性
            $('.define').each(function () {
                var FieldID = $(this).attr('data-id');
                var data_value = $(this).textbox('getValue');
                FieldList.push({ id: FieldID, value: data_value });
            })
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/RoomResourceHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'saveroomresource';
                    param.RoomID = RoomID;
                    param.FieldList = JSON.stringify(FieldList)
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        show_message('保存成功', 'success');
                        return;
                    }
                    if (dataObj.error) {
                        show_message(dataObj.error, 'warning');
                        return;
                    }
                    show_message("内部异常", "error");
                }
            });
        }
        function do_close() {
            parent.parent.do_close_dialog(function () {
                parent.parent.$("#tt_table").datagrid("reload");
            });
        }
        function getFieldContent() {
            MaskUtil.mask('body', '加载中');
            var options = { visit: 'getdefinecontent', TableName: "RoomBasic", RoomID: RoomID };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/SysSettingHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status) {
                        var html = '';
                        var count = 0;
                        var html = '';
                        $.each(message.list, function (index, item) {
                            if (index % 2 == 0) {
                                html += '<tr>';
                                html += '<td>';
                                html += item.FieldName;
                                html += '</td>';
                                html += '<td>';
                                html += '<input data-id="' + item.ID + '" class="easyui-textbox define" type="text" data-value="' + item.FieldContent + '" />';
                                html += '</td>';
                                count = 2;
                            }
                            else if (index % 2 == 1) {
                                html += '<td>';
                                html += item.FieldName;
                                html += '</td>';
                                html += '<td>';
                                html += '<input data-id="' + item.ID + '" class="easyui-textbox define" type="text" data-value="' + item.FieldContent + '" />';
                                html += '</td>';
                                html += '</tr>';
                                count = 4;
                            }
                            if ((index == message.list.length - 1) && count == 2) {
                                html += '<td>';
                                html += '</td>';
                                html += '<td>';
                                html += '</td>';
                                html += '</tr>';
                                count = 0;
                            }
                        })
                        $(html).appendTo("#definefield");
                        $.parser.parse('#definefield');
                        $('.define').each(function () {
                            var data_value = $(this).attr('data-value');
                            $(this).textbox('setValue', data_value);
                        })
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
    </script>
    <style>
        .panel-body {
            background: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
        </div>
        <div class="table_container">
            <div class="tableContent">
                <div class="tableItem">
                    <label class="title">分公司</label>
                    <label id="tdCompanyName"></label>
                </div>
                <div class="tableItem">
                    <label class="title">资源位置</label>
                    <label id="tdFullName" runat="server"></label>
                </div>
                <div class="tableItem">
                    <label class="title">房产类型</label>
                    <label id="tdRoomProperty" runat="server"></label>
                </div>
                <div class="tableItem">
                    <label class="title">房号</label>
                    <input id="tbRoomName" class="easyui-textbox" runat="server" type="text" data-options="required:true" />
                </div>
                <div class="tableItem">
                    <label class="title">期数</label>
                    <input id="tbBuildingNumber" class="easyui-textbox" runat="server" type="text" />
                </div>
                <div class="tableItem">
                    <label class="title">签约时间</label>
                    <input id="tdSignDate" class="easyui-datebox" runat="server" type="text" />
                </div>
                <div class="tableItem">
                    <label class="title">交付时间</label>
                    <input id="tbPaymentTime" class="easyui-datebox" runat="server" type="text" />
                </div>
                <div class="tableItem">
                    <label class="title">产权办理时间</label>
                    <input class="easyui-datebox" id="tdCertificateTime" runat="server" />
                </div>
                <div class="tableItem">
                    <label class="title">房产类别</label>
                    <select class="easyui-combobox" data-options="editable:false" id="tbRoomType" runat="server">
                        <option value="请选择"></option>
                        <option value="洋房">洋房</option>
                        <option value="高层">高层</option>
                        <option value="别墅">别墅</option>
                    </select>
                </div>
                <div class="tableItem">
                    <label class="title">精装修情况</label>
                    <select class="easyui-combobox" data-options="editable:false" id="tdIsJingZhuangXiu" runat="server">
                        <option value="请选择"></option>
                        <option value="1">是</option>
                        <option value="2">否</option>
                    </select>
                </div>
                <div class="tableItem">
                    <label class="title">建筑面积</label>
                    <input class="easyui-textbox" id="tdBuildingOutArea" runat="server" />
                </div>
                <div class="tableItem">
                    <label class="title">排序序号</label>
                    <input class="easyui-textbox" id="tdSortOrder" runat="server" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>
