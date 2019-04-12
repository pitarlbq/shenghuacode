<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditRelateFamily.aspx.cs" Inherits="Web.RoomResource.EditRelateFamily" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var ID = 0, RoomID = 0;
        $(function () {
            ID = "<%=this.ID%>";
            RoomID = "<%=this.RoomID%>";
        })
        function do_save() {
            var isValid = $("#ff").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/RoomResourceHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'saveroomphonefamily';
                    param.ID = ID;
                    param.RoomID = RoomID;
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        show_message('保存成功', 'success', function () {
                            do_close();
                        });
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
            parent.do_close_dialog(function () {
                parent.$("#home_table").datagrid("reload");
            });
        }
    </script>
    <style type="text/css">
        .panel-body {
            background: #f0f0f0;
        }

        table.add {
            width: 100%;
            margin: 0 auto;
            margin-top: 10px;
            border-collapse: collapse;
            border-spacing: 0px;
        }

            table.add td {
                padding: 10px;
                width: 35%;
            }

                table.add td:nth-child(2n-1) {
                    width: 15%;
                }

        .fileInputContainer {
            height: 60px;
            background: url("../styles/images/addimage.jpg") no-repeat;
            width: 60px;
            position: relative;
            margin-left: 130px;
            margin-top: 20px;
            background-size: cover;
        }

        .fileInput {
            height: 60px;
            width: 60px;
            position: absolute;
            right: 0;
            top: 0;
            opacity: 0;
            filter: alpha(opacity=0);
            cursor: pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <div class="tableContent">
                <div class="tableItem">
                    <label class="title">住户类别</label>
                    <select type="text" class="easyui-combobox" runat="server" id="tdRelationProperty" data-options="editable:false">
                        <option value="geren">个人</option>
                        <option value="gongsi">公司</option>
                    </select>
                </div>
                <div class="tableItem">
                    <label class="title">住户标签</label>
                    <select type="text" class="easyui-combobox" runat="server" id="tdRelationType" data-options="editable:false">
                        <option value="homefamily">业主</option>
                        <option value="rentfamily">租户</option>
                    </select>
                </div>
                <div class="tableItem">
                    <label class="title">公司名称</label>
                    <input type="text" class="easyui-textbox" runat="server" id="tdCompanyName" />
                </div>
                <div class="tableItem">
                    <label class="title">住户姓名</label>
                    <input type="text" class="easyui-textbox" runat="server" id="tdRelateName" />
                </div>
                <div class="tableItem">
                    <label class="title">联系方式</label>
                    <input type="text" class="easyui-textbox" runat="server" id="tdRelatePhone" data-options="require:true" />
                </div>
                <div class="tableItem">
                    <label class="title">默认联系人</label>
                    <select type="text" class="easyui-combobox" runat="server" id="tdIsDefault" data-options="editable:false">
                        <option value="1">是</option>
                        <option value="0">否</option>
                    </select>
                </div>
                <div class="tableItem">
                    <label class="title">证件类别</label>
                    <select class="easyui-combobox" id="tdIDCardType" runat="server" data-options="editable:false">
                        <option value="1">身份证</option>
                        <option value="2">护照</option>
                        <option value="3">军人证</option>
                        <option value="4">驾驶证</option>
                        <option value="5">其他</option>
                    </select>
                </div>
                <div class="tableItem">
                    <label class="title">证件号码</label>
                    <input type="text" class="easyui-textbox" runat="server" id="tdRelateIDCard" />
                </div>
                <div class="tableItem" style="width: 100%;">
                    <label class="title">备注</label>
                    <input type="text" class="easyui-textbox" runat="server" id="tdRemark" data-options="multiline:true" style="height: 60px; width: 80%;" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>
