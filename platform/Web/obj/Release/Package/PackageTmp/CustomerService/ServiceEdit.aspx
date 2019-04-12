<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent6.Master" AutoEventWireup="true" CodeBehind="ServiceEdit.aspx.cs" Inherits="Web.CustomerService.ServiceEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>任务登记</title>
    <script>
        var ID, ProjectID, tdFullName, tdProjectName, tdServiceNumber, OrderNumberID, tdTaskType, tdBelongTeamName, tdAcceptManInput, tdServiceArea, tdIsSendAPP, ffObj, guid, op, tdAddCustomerName, tdServiceType1, tdServiceType2, tdServiceType3, tdAddCallPhone, ServiceType;
        $(function () {
            op = "<%=this.op%>";
            ID = "<%=this.ID%>";
            guid = "<%=this.guid%>";
            ServiceType = Number("<%=this.ServiceType%>");
            OrderNumberID = Number("<%=this.OrderNumberID%>");
            ProjectID = Number("<%=this.ProjectID%>");
            tdFullName = $('#<%=this.tdFullName.ClientID%>');
            tdProjectName = $('#<%=this.tdProjectName.ClientID%>');
            tdServiceNumber = $('#<%=this.tdServiceNumber.ClientID%>');
            tdTaskType = $('#<%=this.tdTaskType.ClientID%>');
            tdBelongTeamName = $('#<%=this.tdBelongTeamName.ClientID%>');
            tdAcceptManInput = $('#<%=this.tdAcceptManInput.ClientID%>');
            tdServiceArea = $('#<%=this.tdServiceArea.ClientID%>');
            tdIsSendAPP = $('#<%=this.tdIsSendAPP.ClientID%>');
            tdAddCustomerName = $('#<%=this.tdAddCustomerName.ClientID%>');
            ffObj = $('#<%=this.ff.ClientID%>');
            tdServiceType1 = $('#<%=this.tdServiceType1.ClientID%>');
            tdServiceType2 = $('#<%=this.tdServiceType2.ClientID%>');
            tdServiceType3 = $('#<%=this.tdServiceType3.ClientID%>');
            tdAddCallPhone = $('#<%=this.tdAddCallPhone.ClientID%>');
        });
    </script>
    <script src="../js/Lodop/LodopFuncs.js?t=<%=base.getToken()%>"></script>
    <script src="../js/Page/CustomerService/ServiceEdit.js?t=<%=base.getToken()%>"></script>
    <style>
        .panel-body {
            background: #f0f0f0;
        }

        .existImgBox {
            display: inline-grid;
        }

            .existImgBox a {
                display: inline-flexbox;
                margin: 0 5px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <%if (!op.Equals("view"))
              { %>
            <a href="javascript:void(0)" onclick="savedata()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <%--<a href="javascript:void(0)" onclick="sendjpushapp()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-banjie'">推送至APP</a>--%>
            <a href="javascript:void(0)" onclick="doprint()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-print'">保存并打印</a>
            <%} %>
            <a href="javascript:void(0)" onclick="closeWin()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <div class="tableContent">
                <div class="tableItem">
                    <label class="title">项目名称</label>
                    <label runat="server" id="tdProjectName"></label>
                </div>
                <div class="tableItem">
                    <label class="title">资源位置</label>
                    <input runat="server" type="text" data-options="required:true" class="easyui-textbox" id="tdFullName" style="width: 200px" />
                </div>
                <div class="tableItem">
                    <label class="title">反映人</label>
                    <input runat="server" type="text" class="easyui-textbox" id="tdAddCustomerName" />
                </div>
                <div class="tableItem">
                    <label class="title">联系电话</label>
                    <input runat="server" type="text" class="easyui-textbox" id="tdAddCallPhone" />
                </div>
                <div class="tableItem">
                    <label class="title">高频投诉客户</label>
                    <select runat="server" class="easyui-combobox" id="tdIsHighTouSu" data-options="editable:false">
                        <option value="0">否</option>
                        <option value="1">是</option>
                    </select>
                </div>
                <div class="tableItem">
                    <label class="title">异常电话</label>
                    <select runat="server" class="easyui-combobox" id="tdIsInvalidCall" data-options="editable:false">
                        <option value="0">否</option>
                        <option value="1">是</option>
                    </select>
                </div>
                <div class="tableItem">
                    <label class="title">是否在维保期</label>
                    <select runat="server" class="easyui-combobox" id="tdIsInWeiBao" data-options="editable:false">
                        <option value="1">是</option>
                        <option value="0">否</option>
                    </select>
                </div>
                <div class="tableItem">
                    <label class="title">投诉来源</label>
                    <label runat="server" id="tdServiceFrom"></label>
                    <asp:HiddenField runat="server" id="hdServiceFrom" />
                    <%-- <select runat="server" class="easyui-combobox" id="" data-options="editable:false">
                        <option value="system">物业前台</option>
                        <option value="businessfront">营销前台</option>
                        <option value="four00call">400电话</option>
                        <option value="weixin">微信平台</option>
                        <option value="other">其他</option>
                    </select>--%>
                </div>
                <div class="tableItem">
                    <label class="title">客服单号</label>
                    <input runat="server" type="text" class="easyui-textbox" id="tdServiceNumber" />
                </div>
                <div class="tableItem">
                    <label class="title">预约时间</label>
                    <input runat="server" type="text" class="easyui-datetimebox" id="tdAppointTime" />
                </div>
                <div class="tableItem">
                    <label class="title">分类一</label>
                    <input runat="server" type="text" data-options="required:true,editable:false" class="easyui-combobox" id="tdServiceType1" style="height: 28px;" />
                </div>
                <div class="tableItem">
                    <label class="title">分类二</label>
                    <input runat="server" type="text" data-options="required:false,editable:false" class="easyui-combobox" id="tdServiceType2" style="height: 28px;" />
                </div>
                <div class="tableItem">
                    <label class="title">分类三</label>
                    <input runat="server" type="text" data-options="required:false,editable:false" class="easyui-combobox" id="tdServiceType3" style="height: 28px;" />
                </div>
                <div class="tableItem">
                    <label class="title">任务标签</label>
                    <input runat="server" type="text" data-options="required:false" class="easyui-combobox" id="tdTaskType" style="height: 28px;" />
                    <label><a href="javascript:void(0)" onclick="addTask()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">新增</a></label>
                </div>
                <div class="tableItem">
                    <label class="title">服务区域</label>
                    <select runat="server" data-options="required:true,editable:false" class="easyui-combobox" id="tdServiceArea">
                        <option value="个人区域">个人区域</option>
                        <option value="公共区域">公共区域</option>
                    </select>
                </div>
                <div class="tableItem" style="width: 100%;">
                    <label class="title">内容描述</label>
                    <input runat="server" type="text" name="ServiceContent" class="easyui-textbox" id="tdServiceContent" data-options="multiline:true" style="width: 70%; height: 60px;" />
                </div>
                <div class="tableItem">
                    <label class="title">接单人</label>
                    <input runat="server" type="text" class="easyui-combobox" id="tdAcceptManInput" style="height: 28px;" />
                    <label style="padding: 0; display: none;">
                        <input runat="server" type="checkbox" id="tdIsSendAPP" />发送APP工单
                    </label>
                </div>
                <div class="tableItem">
                    <label class="title">负责部门</label>
                    <input runat="server" type="text" class="easyui-combobox" id="tdBelongTeamName" data-options="editable:false" style="height: 28px;" />
                </div>
                <%--<div class="tableItem">
                    <label class="title">维修工费</label>
                    <input runat="server" type="text" class="easyui-textbox" id="tdHandelFee" />
                </div>
                <div class="tableItem">
                    <label class="title">收费金额</label>
                    <input runat="server" type="text" class="easyui-textbox" id="tdTotalFee" />
                </div>--%>
                <div class="tableItem" id="trExistFiles" style="vertical-align: top; width: 90%;">
                </div>
                <div class="tableItem" style="vertical-align: top; width: 90%;">
                    <label class="title">附件</label>
                    <label style="display: inline-block; width: 70%;" class="content" id="tdFile"></label>
                </div>
                <div class="tableItem">
                    <label class="title">登记信息</label>
                    当前登记人: <span runat="server" id="tdAddUserName"></span>&nbsp;&nbsp;&nbsp;&nbsp;登记时间: <span id="tdAddTime" runat="server"></span>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
