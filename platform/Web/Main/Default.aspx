<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent6.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.Main.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var ID, ProjectID, tdFullName, tdProjectName, tdServiceNumber, OrderNumberID, tdTaskType, tdBelongTeamName, tdAcceptManInput, tdServiceArea, tdIsSendAPP, ffObj, tdServiceType1, tdServiceType2, tdServiceType3, guid, op, tdAddCustomerName, tdAddCallPhone, tdServiceFrom, comingPhoneNumber, ServiceType = 0;
        $(function () {
            op = 'phonecall';
            comingPhoneNumber = '<%=this.phoneNumber%>';
            ID = 0;
            OrderNumberID = 0;
            ProjectID = 0;
            tdFullName = $('#<%=this.tdFullName.ClientID%>');
            tdProjectName = $('#<%=this.tdProjectName.ClientID%>');
            tdServiceNumber = $('#<%=this.tdServiceNumber.ClientID%>');
            tdTaskType = $('#<%=this.tdTaskType.ClientID%>');
            tdBelongTeamName = $('#<%=this.tdBelongTeamName.ClientID%>');
            tdAcceptManInput = $('#<%=this.tdAcceptManInput.ClientID%>');
            tdServiceArea = $('#<%=this.tdServiceArea.ClientID%>');
            tdIsSendAPP = $('#<%=this.tdIsSendAPP.ClientID%>');
            ffObj = $('#<%=this.ff.ClientID%>');
            tdServiceType1 = $('#<%=this.tdServiceType1.ClientID%>');
            tdServiceType2 = $('#<%=this.tdServiceType2.ClientID%>');
            tdServiceType3 = $('#<%=this.tdServiceType3.ClientID%>');
            tdAddCustomerName = $('#<%=this.tdAddCustomerName.ClientID%>');
            tdAddCallPhone = $('#<%=this.tdAddCallPhone.ClientID%>');
            tdServiceFrom = $('#<%=this.tdServiceFrom.ClientID%>');
            $('.historyTab label').bind('click', function () {
                var that = this;
                var elems = $('.historyTab label');
                $.each(elems, function (index, item) {
                    $(item).removeClass('active');
                })
                var dataID = $(that).attr('data-id');
                $(that).addClass('active');
                if (dataID == 1) {
                    $('#tableGongDanDetail').show();
                    $('#tdHistoryData').hide();
                }
                if (dataID == 2) {
                    $('#tableGongDanDetail').hide();
                    $('#tdHistoryData').show();
                }
            })
            if (comingPhoneNumber) {
                getProjectData(comingPhoneNumber);
            }
            getHomeData();
        });
        function getCustomerData(phoneNumber) {
            comingPhoneNumber = phoneNumber;
            tdAddCallPhone.textbox('setValue', phoneNumber);
            $('#tdComingPhone').html(phoneNumber);
            getProjectData(phoneNumber, 0, false);
            $('#trHangUp').show();
        }
        function getProjectData(phoneNumber, RoomID, isNotRoom) {
            $('#tdComingName').html('');
            $('#tdComingRoomName').html('');
            $('#tdComingProjectName').html('');
            $('#tdGongDanType').html('');
            $('#tdGongDanAddTime').html('');
            $('#tdGongDanStatusDesc').html('');
            $('#tdGongDanRemark').html('');
            $('#tdGongDanContent').html('');
            $('#tdHisotryGongDanCount').html('');
            $('#tdHisotryTouSuCount').html('');
            if (comingPhoneNumber) {
                tdAddCallPhone.textbox('setValue', comingPhoneNumber);
                $('#tdComingPhone').html(comingPhoneNumber);
            }
            var ServiceTypeID = tdServiceType1.combobox('getValue');
            var options = { visit: "getroominfo", phoneNumber: phoneNumber, includeHistory: true, ProjectID: RoomID, IsNotRoom: isNotRoom, ServiceTypeID: ServiceTypeID };
            $.ajax({
                type: 'POST',
                data: options,
                dataType: 'json',
                url: '../Handler/ServiceHandler.ashx',
                success: function (data) {
                    if (!data.status) {
                        return;
                    }
                    ProjectID = data.ProjectID;
                    tdProjectName.html(data.ProjectName);
                    tdServiceNumber.textbox("setValue", data.CustomerNumber);
                    OrderNumberID = data.OrderNumberID;
                    tdAddCustomerName.textbox('setValue', data.RelationName);
                    tdFullName.textbox("setValue", data.FullName);
                    if (!isNotRoom) {
                        tdServiceArea.combobox("setValue", "个人区域");
                    }
                    else {
                        tdServiceArea.combobox("setValue", "公共区域");
                    }
                    tdBelongTeamName.combobox({
                        editable: false,
                        textField: 'Name',
                        valueField: 'ID',
                        data: data.departmentList
                    })
                    tdAcceptManInput.combobox({
                        editable: false,
                        textField: 'Name',
                        valueField: 'ID',
                        data: data.userStaffList,
                        onSelect: function (ret) {
                            tdBelongTeamName.combobox('setValue', ret.DepartmentID);
                        }
                    })
                    if (data.userStaffList.length > 0) {
                        tdAcceptManInput.combobox('setValue', data.userStaffList[0].ID);
                        tdBelongTeamName.combobox('setValue', data.userStaffList[0].DepartmentID);
                    }
                    if (!comingPhoneNumber) {
                        tdAddCallPhone.textbox('setValue', data.RelationPhoneNumber);
                        $('#tdComingPhone').html(data.RelationPhoneNumber);
                    }
                    $('#tdComingName').html(data.RelationName);
                    $('#tdComingRoomName').html(data.RoomName);
                    $('#tdComingProjectName').html(data.ProjectName);
                    if (data.history) {
                        $('#tdGongDanType').html(data.history.GongDanType);
                        $('#tdGongDanAddTime').html(data.history.GongDanAddTime);
                        $('#tdGongDanStatusDesc').html(data.history.GongDanStatusDesc);
                        $('#tdGongDanRemark').html(data.history.GongDanRemark);
                        $('#tdGongDanContent').html(data.history.GongDanContent);
                        $('#tdHisotryGongDanCount').html(data.history.HisotryGongDanCount);
                        $('#tdHisotryTouSuCount').html(data.history.HisotryTouSuCount);
                    }
                }
            });
        }
        function hangUpPhone() {
            top.hangUpPhone();
            $('#trHangUp').hide();
        }
        function do_cancel() {
            $('.tableItem .easyui-textbox').textbox('setValue', '');
            $('.tableItem .easyui-combobox').textbox('setValue', '');
            $('.tableItem .easyui-datetimebox').textbox('setValue', '');
            top.ComingPhoneNumber = '';
        }
        function getHomeData() {
            var options = { visit: "gethomecountdata" };
            $.ajax({
                type: 'POST',
                data: options,
                dataType: 'json',
                url: '../Handler/ServiceHandler.ashx',
                success: function (data) {
                    if (!data.status) {
                        return;
                    }
                    $('#tdNormalSeatCount').html(data.NormalSeatCount);
                    $('#tdInvalidSeatCount').html(data.InvalidSeatCount);
                    $('#tdServiceCount').html(data.ServiceCount);
                    $('#tdSuggestionCount').html(data.SuggestionCount);
                    $('#tdTotalInCallCount').html(data.TotalInCallCount);
                    $('#tdTotalOutCallCount').html(data.TotalOutCallCount);
                    $('#tdTotalInCallMin').html(data.TotalInCallMin);
                    $('#tdTotalOutCallMin').html(data.TotalOutCallMin);
                }
            });
        }
    </script>
    <script src="../js/Page/CustomerService/ServiceEdit.js?t=<%=base.getToken()%>"></script>
    <link href="../styles/page/default.css?v2" rel="stylesheet" />
    <style>
        .historyItem label {
            display: inline-block;
            line-height: 30px;
            width: 80px;
        }

        .historyItem span {
            display: inline-block;
            line-height: 30px;
        }

        table.info tr td {
            padding: 6px 0;
        }

        table.info label.title {
            width: 60px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="firstBox">
        <div class="itemBox first">
            <div class="itemTitle">座席状态</div>
            <div class="itemContent">
                <div class="content_item">
                    <label id="tdNormalSeatCount" class="count green">0</label>
                    <label class="title">正常座席</label>
                </div>
                <div class="content_item">
                    <label id="tdInvalidSeatCount" class="count red">0</label>
                    <label class="title">异常座席</label>
                </div>
            </div>
        </div>
        <div class="itemBox">
            <div class="itemTitle">工单任务</div>
            <div class="itemContent">
                <div class="content_item">
                    <label id="tdServiceCount" class="count green">0</label>
                    <label class="title">客服工单</label>
                </div>
                <div class="content_item">
                    <label id="tdSuggestionCount" class="count red">0</label>
                    <label class="title">投诉工单</label>
                </div>
            </div>
        </div>
        <div class="itemBox">
            <div class="itemTitle">通话时长</div>
            <div class="itemContent">
                <div class="content_item">
                    <label class="content_line1">呼入数量：<span id="tdTotalInCallCount"></span></label>
                    <label class="content_line1">呼出数量：<span id="tdTotalOutCallCount"></span></label>
                </div>
                <div class="content_item">
                    <label class="content_line2">累计时长：<span id="tdTotalInCallMin"></span></label>
                    <label class="content_line2">累计时长：<span id="tdTotalOutCallMin"></span></label>
                </div>
            </div>
        </div>
    </div>
    <div class="serviceBox">
        <div class="serviceTitle">新增工单</div>
        <div class="operationBox">
            <a href="javascript:void(0)" onclick="savedata(0)" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-banjie'">创建工单</a>
            <a href="javascript:void(0)" onclick="do_cancel()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-save'">弃单</a>
        </div>
        <form id="ff" runat="server" method="post" enctype="multipart/form-data">
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
                    <input runat="server" type="text" class="easyui-textbox" id="tdAddCallPhone" data-options="required:true" />
                </div>
                <div class="tableItem">
                    <label class="title">投诉来源</label>
                    <label runat="server" id="tdServiceFrom"></label>
                    <asp:HiddenField runat="server" ID="hdServiceFrom" />
                    <%--<input type="text" class="easyui-combobox" runat="server" id="tdServiceFrom" />--%>
                    <%--<select runat="server" class="easyui-combobox" id="tdServiceFrom" data-options="editable:false,required:true">
                        <option value="four00call">400电话</option>
                        <option value="system">物业前台</option>
                        <option value="businessfront">营销前台</option>
                        <option value="weixin">微信平台</option>
                        <option value="other">其他</option>
                    </select>--%>
                </div>
                <div class="tableItem">
                    <label class="title">客服单号</label>
                    <input runat="server" type="text" class="easyui-textbox" id="tdServiceNumber" data-options="required:true" />
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
                <div class="tableItem" style="width: 80%;">
                    <label class="title">内容描述</label>
                    <input runat="server" type="text" name="ServiceContent" class="easyui-textbox" id="tdServiceContent" data-options="multiline:true" style="width: 70%; height: 60px;" />
                </div>
                <div class="tableItem">
                    <label class="title">接单人</label>
                    <input runat="server" type="text" class="easyui-combobox" id="tdAcceptManInput" style="height: 28px;" data-options="editable:false" />
                    <label style="padding: 0; display: none;">
                        <input runat="server" type="checkbox" id="tdIsSendAPP" />发送APP工单
                    </label>
                </div>
                <div class="tableItem">
                    <label class="title">负责部门</label>
                    <input runat="server" type="text" class="easyui-combobox" id="tdBelongTeamName" data-options="editable:false" style="height: 28px;" />
                </div>
                <div class="tableItem">
                    <label class="title">登记信息</label>
                    当前登记人: <span runat="server" id="tdAddUserName"></span>&nbsp;&nbsp;&nbsp;&nbsp;登记时间: <span id="tdAddTime" runat="server"></span>
                </div>
            </div>
        </form>
    </div>
    <div class="callBox">
        <div class="serviceTitle">来电信息</div>
        <div style="border-bottom: solid 1px #ddd; margin: 0 5px;">
            <table class="info basicinfo">
                <tr>
                    <td>
                        <label class="title" style="width: 30px;">姓名</label>
                        <label id="tdComingName"></label>
                    </td>
                    <td>
                        <label class="title">房号</label>
                        <label id="tdComingRoomName"></label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label class="title" style="width: 30px;">电话</label>
                        <label id="tdComingPhone"></label>
                    </td>
                    <td>
                        <label class="title">项目名称</label>
                        <label id="tdComingProjectName"></label>
                    </td>
                </tr>
                <tr id="trHangUp" style="display: none;">
                    <td><a href="javascript:void(0)" onclick="hangUpPhone()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-save'">电话挂断</a></td>
                </tr>
            </table>
        </div>
        <div class="serviceTitle">客户记录</div>
        <div class="historyTab">
            <label class="active" data-id="1">工单待办</label>
            <label data-id="2">历史记录</label>
        </div>
        <div style="margin: 0 5px;">
            <table class="info" id="tableGongDanDetail">
                <tr>
                    <td colspan="2">
                        <label class="title">工单类型：</label>
                        <label id="tdGongDanType"></label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <label class="title">提交时间：</label>
                        <label id="tdGongDanAddTime"></label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <label class="title">处理进度：</label>
                        <label id="tdGongDanStatusDesc"></label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <label class="title">办理反馈：</label>
                        <label id="tdGongDanRemark"></label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <label class="title">备注：</label>
                        <label id="tdGongDanContent"></label>
                    </td>
                </tr>
            </table>
            <table class="info" id="tdHistoryData" style="display: none;">
                <tr>
                    <td>
                        <label class="title">工单数量：</label>
                        <label id="tdHisotryGongDanCount"></label>
                    </td>
                    <td>
                        <label class="title">投诉数量：</label>
                        <label id="tdHisotryTouSuCount"></label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
