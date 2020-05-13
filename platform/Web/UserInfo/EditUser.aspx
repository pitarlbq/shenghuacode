<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="Web.UserInfo.EditUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var op, hdOpenID, UserID, tdOpenID, hdCustomerName, type, tdUserType, tdIsAllowSysLogin, hdIsAllowSysLogin, tdDepartment, hdDepartment;
        $(function () {
            hdOpenID = $('#<%=this.hdOpenID.ClientID%>');
            tdOpenID = $('#<%=this.tdOpenID.ClientID%>');
            hdCustomerName = $('#<%=this.hdCustomerName.ClientID%>');
            tdUserType = $('#<%=this.tdUserType.ClientID%>');
            tdIsAllowSysLogin = $('#<%=this.tdIsAllowSysLogin.ClientID%>');
            tdIsAllowAPPUserLogin = $('#<%=this.tdIsAllowAPPUserLogin.ClientID%>');
            hdIsAllowSysLogin = $('#<%=this.hdIsAllowSysLogin.ClientID%>');
            hdIsAllowAPPUserLogin = $('#<%=this.hdIsAllowAPPUserLogin.ClientID%>');
            tdDepartment = $('#<%=this.tdDepartment.ClientID%>');
            hdDepartment = $('#<%=this.hdDepartment.ClientID%>');
            UserID = "<%=this.UserID%>";
            loadCompany();
            tdOpenID.textbox({
                buttonText: '绑定',
                iconCls: 'icon-man',
                iconAlign: 'left',
                onClickButton: function () {
                    doChooseWechatUser();
                }
            })
            setTimeout(function () {
                $("#<%=this.tdCustomerName.ClientID%>").textbox("setText", hdCustomerName.val());
                $("#<%=this.tdCustomerName.ClientID%>").textbox("setValue", hdCustomerName.val());
                $("#tdPassword").textbox("setText", '');
                $("#tdPassword").textbox("setValue", '');
            }, 100);
            setTimeout(function () {
                $("#<%=this.tdCustomerName.ClientID%>").textbox('textbox').focus();
            }, 3000);
            tdUserType.combobox({
                onSelect: function () {
                    change_status();
                }
            })
            change_status();
            var departmentList = [];
            if (hdDepartment.val() != '') {
                departmentList = eval('(' + hdDepartment.val() + ')');
            }
            tdDepartment.combobox({
                editable: false,
                data: departmentList,
                valueField: 'ID',
                textField: 'Name',
                multiple: true,
            })
        });
        function change_status() {
            var user_type = tdUserType.combobox('getValue');
            if (user_type == 'SystemUser') {
                tdIsAllowSysLogin.prop('checked', true).prop('disabled', true);
                tdIsAllowAPPUserLogin.prop('disabled', false).prop('checked', hdIsAllowAPPUserLogin.val() == '1');
                $('.sysuser_box').show();
                $('.appuser_box').hide();
            } else {
                tdIsAllowSysLogin.prop('disabled', false).prop('checked', hdIsAllowSysLogin.val() == '1');
                tdIsAllowAPPUserLogin.prop('checked', true).prop('disabled', true);
                $('.sysuser_box').hide();
                $('.appuser_box').show();
            }
        }
        function doChooseWechatUser() {
            var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../UserInfo/ChooseWehcatUser.aspx?UserID=" + UserID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
            $("<div id='winchoose'></div>").appendTo("body").window({
                title: '选择微信粉丝',
                width: ($(window).width() - 200),
                height: $(window).height(),
                top: 0,
                left: 100,
                modal: true,
                minimizable: false,
                maximizable: false,
                collapsible: false,
                content: iframe,
                onClose: function () {
                    $("#winchoose").remove();
                }
            });
        }
        function loadCompany() {
            var companyData = $("#<%=hdCompanys.ClientID%>").val();
            var companylist;
            if (companyData != "") {
                companylist = eval("(" + companyData + ")");
            }
            var CompanyObj = $("#<%=this.tdCompanyID.ClientID%>");
            CompanyObj.combobox({
                editable: false,
                data: companylist,
                valueField: 'CompanyID',
                textField: 'CompanyName',
            });
        }
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var LoginName = $("#<%=this.tdLoginName.ClientID%>").textbox("getValue");
            var Password = $("#tdPassword").textbox("getValue");
            var RePwd = $("#tdRePassword").textbox("getValue");
            if (Password != RePwd && Password != '') {
                show_message("两次密码不一致", "info");
                return;
            }
            var RealName = $("#<%=this.tdCustomerName.ClientID%>").textbox("getValue");
            var PhoneNumber = $("#<%=this.tdPhoneNumber.ClientID%>").textbox("getValue");
            var Gender = $("#<%=this.tdGender.ClientID%>").combobox("getValue");
            var IsLocked = $("#<%=this.tdIsLocked.ClientID%>").combobox("getValue");
            var CompanyID = $("#<%=this.tdCompanyID.ClientID%>").combobox("getValue");
            var HotPhoneLine = $("#<%=this.tdHotPhoneLine.ClientID%>").textbox("getValue");
            var BelongServiceName = $("#<%=this.tdBelongServiceName.ClientID%>").textbox("getValue");
            var QQNumber = $("#<%=this.tdQQNumber.ClientID%>").textbox("getValue");
            var UserType = tdUserType.combobox("getValue");
            var IsAllowAPPUserLogin = (tdIsAllowAPPUserLogin.prop('checked') ? '1' : '0');
            var IsAllowSysLogin = (tdIsAllowSysLogin.prop('checked') ? '1' : '0');
            var Education = $("#<%=this.tdEducation.ClientID%>").combobox("getValue");
            var PositionName = $("#<%=this.tdPositionName.ClientID%>").textbox("getValue");
            var DepartmentIDList = tdDepartment.combobox("getValues");
            var options = { visit: 'saveuserinfo', UserID: UserID, RealName: RealName, NickName: RealName, PhoneNumber: PhoneNumber, Gender: Gender, IsLocked: IsLocked, CompanyID: CompanyID, LoginName: LoginName, Password: Password, HotPhoneLine: HotPhoneLine, BelongServiceName: BelongServiceName, QQNumber: QQNumber, UserType: UserType, OpenID: hdOpenID.val(), IsAllowAPPUserLogin: IsAllowAPPUserLogin, IsAllowSysLogin: IsAllowSysLogin, PositionName: PositionName, DepartmentIDList: JSON.stringify(DepartmentIDList), Education: Education };
            MaskUtil.mask('body', '提交中');
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/UserHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status) {
                        if (message.addfailed) {
                            show_message("添加失败,用户数已达上限", "info", function () {
                                do_close();
                            });
                            return;
                        }
                        show_message('保存成功', 'success', function () {
                            do_close();
                        });
                        return;
                    }
                    if (message.error) {
                        show_message(message.error, 'warning');
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$('#tt_table').datagrid('reload');
            });
        }
    </script>
    <style type="text/css">
        .panel-body {
            background: #f0f0f0;
        }

        .hidefield {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>登录名
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdLoginName" runat="server" data-options="required:true" />
                    </td>
                    <td>姓名
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdCustomerName" runat="server" name="CustomerName" data-options="required:true" />
                        <asp:HiddenField runat="server" ID="hdCustomerName" />
                    </td>
                </tr>
                <tr>
                    <td>密码
                    </td>
                    <td>
                        <input id="tdPassword" name="pwd" type="password" class="easyui-textbox" />
                        <asp:HiddenField ID="hdPwd" runat="server" />
                    </td>
                    <td>确认密码
                    </td>
                    <td>
                        <input id="tdRePassword" name="rpwd" type="password" class="easyui-textbox" />
                    </td>
                </tr>
                <tr>
                    <td>联系电话
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" style="" id="tdPhoneNumber" runat="server" />
                    </td>
                    <td>性别
                    </td>
                    <td>
                        <select id="tdGender" runat="server" class="easyui-combobox" data-options="editable:false">
                            <option value="男">男</option>
                            <option value="女">女</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>是否有效
                    </td>
                    <td>
                        <select id="tdIsLocked" runat="server" class="easyui-combobox" data-options="editable:false">
                            <option value="0">正常</option>
                            <option value="1">失效</option>
                        </select>
                    </td>
                    <td>所属公司
                    </td>
                    <td>
                        <input type="text" class="easyui-combobox" id="tdCompanyID" runat="server" />
                        <asp:HiddenField runat="server" ID="hdCompanys" />
                    </td>
                </tr>
                <tr>
                    <td>用户性质
                    </td>
                    <td>
                        <select id="tdUserType" runat="server" class="easyui-combobox" data-options="editable:false">
                            <option value="SystemUser">系统用户</option>
                            <option value="APPUser">员工APP用户</option>
                        </select>
                    </td>
                    <td colspan="2" style="text-align: left;">
                        <input style="width: 15px; height: 15px;" type="checkbox" runat="server" id="tdIsAllowSysLogin" />
                        允许登录后台
                        <asp:HiddenField runat="server" ID="hdIsAllowSysLogin" />
                        <asp:HiddenField runat="server" ID="hdIsAllowAPPUserLogin" />
                        <input style="width: 15px; height: 15px;" type="checkbox" runat="server" id="tdIsAllowAPPUserLogin" />
                        允许登录员工APP
                    </td>
                </tr>
                <tr class="sysuser_box">
                    <td>客服热线
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" style="" id="tdHotPhoneLine" runat="server" />
                    </td>
                    <td>专属客服
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" style="" id="tdBelongServiceName" runat="server" />
                    </td>
                </tr>
                <tr class="sysuser_box">
                    <td>客服QQ
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" style="" id="tdQQNumber" runat="server" />
                    </td>
                    <td>微信号
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" style="" id="tdOpenID" runat="server" />
                        <asp:HiddenField runat="server" ID="hdOpenID" />
                    </td>
                </tr>
                <tr class="appuser_box">
                    <td>岗位名称</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdPositionName" />
                    </td>
                    <td>所属部门</td>
                    <td>
                        <input class="easyui-combobox" runat="server" data-options="editable:false" id="tdDepartment" />
                        <asp:HiddenField runat="server" ID="hdDepartment" />
                    </td>
                </tr>
                <tr>
                    <td>学历
                    </td>
                    <td>
                        <select runat="server" data-options="editable:false" id="tdEducation" class="easyui-combobox">
                            <option value="">请选择</option>
                            <option value="本科">本科</option>
                            <option value="硕士">硕士</option>
                            <option value="博士">博士</option>
                            <option value="大专">大专</option>
                            <option value="中专">中专</option>
                            <option value="小学">小学</option>
                            <option value="初中">初中</option>
                            <option value="高中">高中</option>
                            <option value="其他">其他</option>
                        </select>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
