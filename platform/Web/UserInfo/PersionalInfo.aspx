<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="PersionalInfo.aspx.cs" Inherits="Web.UserInfo.PersionalInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var op, hdOpenID, UserID, tdOpenID, hdCustomerName;
        $(function () {
            hdOpenID = $('#<%=this.hdOpenID.ClientID%>');
            tdOpenID = $('#<%=this.tdOpenID.ClientID%>');
            hdCustomerName = $('#<%=this.hdCustomerName.ClientID%>');
            UserID = "<%=this.UserID%>";
            loadCompany();
            setTimeout(function () {
                $("#<%=this.tdCustomerName.ClientID%>").textbox("setValue", hdCustomerName.val());
                $("#tdPassword").textbox("setValue", "");
            }, 1000);
            tdOpenID.textbox({
                readonly: true,
            })
        });
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
        function saveResource() {
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
            var UserType = $("#<%=this.tdUserType.ClientID%>").combobox("getValue");
            var options = { visit: 'saveuserinfo', UserID: UserID, RealName: RealName, PhoneNumber: PhoneNumber, Gender: Gender, IsLocked: IsLocked, CompanyID: CompanyID, LoginName: LoginName, Password: Password, HotPhoneLine: HotPhoneLine, BelongServiceName: BelongServiceName, QQNumber: QQNumber, UserType: UserType, OpenID: hdOpenID.val() };
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
                                parent.$("#winadd").window('close');
                            });
                            return;
                        }
                        show_message('保存成功', 'success', function () {
                            parent.$("#winadd").window('close');
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
        function closeWin() {
            parent.$("#winadd").window("close");
        }
    </script>
    <style type="text/css">
        table.info {
            width: 90%;
            margin: 0 auto;
            border: solid 1px #ccc;
            border-spacing: 0;
            border-collapse: collapse;
        }

            table.info td {
                border: solid 1px #ccc;
                padding: 10px;
                text-align: left;
                width: 35%;
            }

                table.info td:nth-child(2n-1) {
                    text-align: right;
                    width: 15%;
                }

        input {
            width: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <div style="padding: 10px 0;">
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
                        <select id="tdGender" style="width: 200px;" runat="server" class="easyui-combobox">
                            <option value="男">男</option>
                            <option value="女">女</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>是否有效
                    </td>
                    <td>
                        <select id="tdIsLocked" style="width: 200px;" runat="server" class="easyui-combobox">
                            <option value="0">正常</option>
                            <option value="1">失效</option>
                        </select></td>
                    <td>用户性质
                    </td>
                    <td>
                        <select id="tdUserType" style="width: 200px;" runat="server" class="easyui-combobox">
                            <option value="SystemUser">系统用户</option>
                            <option value="APPUser">APP用户</option>
                        </select></td>
                </tr>
                <tr>
                    <td>所属公司
                    </td>
                    <td>
                        <input type="text" class="easyui-combobox" id="tdCompanyID" runat="server" />
                        <asp:HiddenField runat="server" ID="hdCompanys" />
                    </td>
                    <td>客服热线
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" style="" id="tdHotPhoneLine" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>专属客服
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" style="" id="tdBelongServiceName" runat="server" />
                    </td>
                    <td>客服QQ
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" style="" id="tdQQNumber" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>微信号
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" style="" id="tdOpenID" runat="server" />
                        <asp:HiddenField runat="server" ID="hdOpenID" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center;">
                        <a href="javascript:void(0)" onclick="saveResource()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                        <a href="javascript:void(0)" onclick="closeWin()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
