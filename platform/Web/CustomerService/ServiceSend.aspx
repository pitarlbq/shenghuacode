<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent6.Master" AutoEventWireup="true" CodeBehind="ServiceSend.aspx.cs" Inherits="Web.CustomerService.ServiceSend" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>任务登记</title>
    <script src="../js/Page/Comm/PinYin.js?t=<%=base.getToken()%>"></script>
    <script>
        var ID, tdAcceptManInput, ffObj, tdServiceProcessManID, chooseType = 1, ProjectID, Status, tdProjectName, hdProjectName;
        $(function () {
            ID = "<%=this.ID%>";
            tdAcceptManInput = $('#<%=this.tdAcceptManInput.ClientID%>');
            tdServiceProcessManID = $('#<%=this.tdServiceProcessManID.ClientID%>');
            tdProjectName = $('#<%=this.tdProjectName.ClientID%>');
            hdProjectName = $('#<%=this.hdProjectName.ClientID%>');
            ffObj = $('#<%=this.ff.ClientID%>');
            ProjectID = Number('<%=this.ProjectID%>');
            Status = '<%=this.status%>';
            if (ProjectID > 0) {
                getServiceSendParam();
            } else {
                getProjectCombobox();
            }
        });
        function getProjectCombobox() {
            if (ProjectID <= 0 && hdProjectName.val() != '') {
                var list = eval('(' + hdProjectName.val() + ')');
                tdProjectName.combobox({
                    data: list,
                    editable: false,
                    valueField: 'ID',
                    textField: 'Name',
                    onSelect: function (ret) {
                        ProjectID = ret.ID;
                        getServiceSendParam();
                    }
                })
                if (list.length > 0) {
                    ProjectID = list[0].ID;
                    tdProjectName.combobox('setValue', list[0].ID);
                    getServiceSendParam();
                }
            }
        }
        function getServiceSendParam() {
            MaskUtil.mask('body', '加载中');
            var options = { visit: "getuseraccpetparams", ID: ID, ProjectID: ProjectID };
            $.ajax({
                type: 'POST',
                data: options,
                dataType: 'json',
                url: '../Handler/ServiceHandler.ashx',
                success: function (data) {
                    MaskUtil.unmask();
                    var defaultID = 0;
                    if (data.accpetUserStaffList.length > 0) {
                        defaultID = data.accpetUserStaffList[0].ID;
                    }
                    var list = data.accpetUserStaffList;
                    var listItem = { ID: 0, Name: '请选择' };
                    list.splice(0, 0, listItem);
                    tdAcceptManInput.combobox({
                        editable: false,
                        textField: 'Name',
                        valueField: 'ID',
                        data: list
                    })
                    if (defaultID > 0) {
                        tdAcceptManInput.combobox('setValue', defaultID);
                    }
                    var defaultID2 = 0;
                    if (data.processUserStaffList.length > 0) {
                        defaultID2 = data.processUserStaffList[0].ID;
                    }
                    var list2 = data.processUserStaffList;
                    var list2Item = { ID: 0, Name: '请选择' };
                    list2.splice(0, 0, listItem);
                    tdServiceProcessManID.combobox({
                        editable: false,
                        textField: 'Name',
                        valueField: 'ID',
                        data: list2
                    })
                    if (defaultID2 > 0) {
                        tdServiceProcessManID.combobox('setValue', defaultID2);
                    }
                }
            });
        }
        function do_save() {
            var isValid = ffObj.form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            if (ProjectID <= 0) {
                ProjectID = tdProjectName.combobox('getValue');
            }
            if (!ProjectID) {
                show_message('请选择项目', 'warning');
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/ServiceHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'dosendcustomerservice';
                    param.ID = ID;
                    param.ProjectID = ProjectID;
                    param.Status = Status;
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        window.updateWin = true;
                        show_message('保存成功', 'success', function () {
                            closeWin();
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
        function closeWin() {
            parent.do_close_dialog(function () {
                if (window.updateWin) {
                    parent.reloadTT();
                }
            }, true);
        }
    </script>
    <style>
        .panel-body {
            background: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="closeWin()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <div class="tableContent">
                <%if (this.ProjectID <= 0)
                    { %>
                <div class="tableItem" style="width: 100%;">
                    <label class="title">所属项目</label>
                    <input runat="server" type="text" class="easyui-combobox" id="tdProjectName" style="height: 28px;" />
                    <asp:HiddenField runat="server" ID="hdProjectName" />
                </div>
                <%} %>
                <%if (this.status == 10 || this.status == 100)
                    { %>
                <div class="tableItem" style="width: 100%;">
                    <label class="title">接单人</label>
                    <input runat="server" type="text" class="easyui-combobox" id="tdAcceptManInput" style="height: 28px;" />
                    <label style="padding: 0; display: none;">
                        <input runat="server" type="checkbox" id="tdIsSendAPP" />发送APP工单
                    </label>
                </div>
                <%} %>
                <%if (this.status == 3 || this.status == 100)
                    { %>
                <div class="tableItem" style="width: 100%;">
                    <label class="title">处理人</label>
                    <input runat="server" type="text" class="easyui-combobox" id="tdServiceProcessManID" style="height: 28px;" />
                </div>
                <%} %>
            </div>
        </div>
    </form>
</asp:Content>
