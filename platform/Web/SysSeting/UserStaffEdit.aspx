<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="UserStaffEdit.aspx.cs" Inherits="Web.SysSeting.UserStaffEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var type, UserID, OrgID, tdPassword, tdRePassword, tdDepartment, hdDepartment;
        $(function () {
            UserID = "<%=this.UserID%>";
            OrgID = "<%=this.OrgID%>";
            tdPassword = $('#<%=this.tdPassword.ClientID%>');
            tdRePassword = $('#<%=this.tdRePassword.ClientID%>');
            tdDepartment = $('#<%=this.tdDepartment.ClientID%>');
            hdDepartment = $('#<%=this.hdDepartment.ClientID%>');
            tdDepartment.combobox({
                editable: false,
                valueField: 'ID',
                textField: 'Name',
                data: eval('(' + hdDepartment.val() + ')')
            })
        })
        function pageLoad(ID) {
            tdDepartment.combobox('setValue', ID);
        }
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var pwd = tdPassword.textbox('getValue');
            var repwd = tdRePassword.textbox('getValue');
            if (pwd != '' && pwd != repwd) {
                show_message('两次输入密码不一致', 'warning');
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/SysSettingHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'saveuserstaffdata';
                    param.UserID = UserID;
                    param.OrgID = OrgID;
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        show_message('保存成功', '保存成功', function () {
                            do_close();
                        });
                        return;
                    }
                    if (dataObj.error) {
                        show_message(dataObj.error, 'error');
                        return;
                    }
                    show_message('内部异常', 'error');
                }
            });
        }
        function do_close() {
            try {
                parent.do_close_dialog(function () {
                    parent.$("#tt_table").datagrid("reload");
                }, true);
            } catch (e) {
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <div class="tableContent">
                <div class="tableItem">
                    <label class="title">登录名</label>
                    <input type="text" class="easyui-textbox" id="tdLoginName" runat="server" data-options="required:true" style="height: 28px;" />
                </div>
                <div class="tableItem">
                    <label class="title">姓名</label>
                    <input type="text" class="easyui-textbox" id="tdRealName" runat="server" data-options="required:true" style="height: 28px;" />
                </div>
                <div class="tableItem">
                    <label class="title">密码</label>
                    <input id="tdPassword" runat="server" type="password" class="easyui-textbox" style="height: 28px;" />
                    <asp:HiddenField ID="hdPwd" runat="server" />
                </div>
                <div class="tableItem">
                    <label class="title">确认密码</label>
                    <input id="tdRePassword" runat="server" type="password" class="easyui-textbox" style="height: 28px;" />
                </div>
                <div class="tableItem">
                    <label class="title">联系电话</label>
                    <input type="text" class="easyui-textbox" id="tdPhoneNumber" runat="server" style="height: 28px;" />
                </div>
                <div class="tableItem">
                    <label class="title">性别</label>
                    <select id="tdGender" data-options="editable:false" style="height: 28px;" runat="server" class="easyui-combobox">
                        <option value="男">男</option>
                        <option value="女">女</option>
                    </select>
                </div>
                <div class="tableItem">
                    <label class="title">是否有效</label>
                    <select id="tdIsLocked" data-options="editable:false" style="height: 28px;" runat="server" class="easyui-combobox">
                        <option value="0">正常</option>
                        <option value="1">失效</option>
                    </select>
                </div>
                <div class="tableItem">
                    <label class="title">工单来源</label>
                    <select runat="server" class="easyui-combobox" id="tdServiceFrom" data-options="editable:false,required:true">
                        <option value="">无</option>
                        <option value="four00call">400电话</option>
                        <option value="system">物业前台</option>
                        <option value="businessfront">营销前台</option>
                        <%--<option value="weixin">微信平台</option>--%>
                        <option value="other">其他</option>
                    </select>
                </div>
                <div class="tableItem">
                    <label class="title">所属部门</label>
                    <input tye="combobox" runat="server" id="tdDepartment" data-options="editable:false" />
                    <asp:HiddenField runat="server" ID="hdDepartment" />
                </div>
                <div class="tableItem">
                    <label class="title">岗位信息</label>
                    <input type="text" class="easyui-textbox" id="tdPositionName" runat="server" style="height: 28px;" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>
