<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ServiceMgr.aspx.cs" Inherits="Web.CustomerService.ServiceMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>任务看板</title>
    <script>
        var Status = -1, ColumnServiceStatus = -1, ColumnServiceType = 1, ServiceType = 1, BeforeBanJieTimeOutHour = 0;
        $(function () {
            Status = "<%=this.status%>";
            BeforeBanJieTimeOutHour = "<%=this.BeforeBanJieTimeOutHour%>";
            ColumnServiceStatus = Status;
            var op = "<%=this.op%>";
            if (op == 'view') {
                setTimeout(function () {
                    $("#main_form_layout").layout('panel', 'north').panel("options").height = 100;
                    $("#main_form_layout").layout("resize");
                    $('.operation_box').show();
                }, 100);
            }
            if (Status == 12) {
                $('.tdCallBack').show();
            } else {
                $('.tdCallBack').hide();
            }
        })
        function do_close() {
            parent.do_close_dialog()
        }
    </script>
    <script src="../js/Lodop/LodopFuncs.js?t=<%=base.getToken() %>"></script>
    <script src="../js/Page/CustomerService/ServiceMgr.js?v=<%=base.getToken() %>" type="text/javascript"></script>
    <style>
        .tdsearch label {
            margin-right: 5px;
        }

        .operation_box {
            position: relative;
            text-align: right;
        }
    </style>
    <script>
        $(function () {
            $('.easyui-combobox').combobox('clear');
            $('#tdCallBackStatus').combobox('setValue', 2);
            $('#tdCallServiceType').combobox('setValue', 1);
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div id="main_form_layout" class="easyui-layout" fit="true">
            <div data-options="region:'north',split:false,hideCollapsedContent:false," title="" style="height: 70px; padding: 5px;">
                <div class="operation_box" style="display: none;">
                    <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
                </div>
                <div class="tdsearch">
                    <label>
                        <input type="text" class="easyui-searchbox" id="tdKeywords" style="width: 150px; height: 28px;" data-options="prompt:'关键字',searcher:SearchTT" />
                    </label>
                    <label>
                        <select class="easyui-combobox" id="tdPayStatus" style="width: 100px; height: 28px;" data-options="prompt:'是否有偿',editable:false">
                            <option value="0">全部</option>
                            <option value="1">有偿</option>
                            <option value="2">无偿</option>
                        </select>
                    </label>
                    <label>
                        <input type="text" class="easyui-combobox" id="tdAccpetMan" style="width: 100px; height: 28px;" data-options="prompt:'接单人',editable:false" />
                    </label>
                    <label>
                        <input class="easyui-datebox" id="tdStartTime" style="width: 110px; height: 28px;" data-options="prompt:'任务开始时间'" />
                        -                    
                        <input class="easyui-datebox" id="tdEndTime" style="width: 110px; height: 28px;" data-options="prompt:'任务结束时间'" />
                    </label>
                    <%if (this.status == 101)
                        { %>
                    <label>
                        <select class="easyui-combobox" id="tdServiceStatus" style="width: 100px; height: 28px;" data-options="prompt:'任务状态',editable:false">
                            <option value="-1">全部</option>
                            <option value="100">待处理</option>
                            <option value="0">处理中</option>
                            <option value="1">已完成</option>
                            <option value="2">已销单</option>
                        </select>
                    </label>
                    <%} %>
                    <label>
                        <select class="easyui-combobox" id="tdSortOrder" style="width: 120px; height: 28px;" data-options="prompt:'排序方式',editable:false">
                            <option value="1">按登记日期排序</option>
                            <option value="2">按单号排序</option>
                        </select>
                    </label>
                    <label style="display: none;">
                        <select class="easyui-combobox" id="tdServiceRange" style="width: 100px; height: 28px;" data-options="prompt:'报修区域',editable:false">
                            <option value="0">全部区域</option>
                            <option value="1">非公共区域</option>
                            <option value="2">公共区域</option>
                        </select>
                    </label>
                    <label class="tdCallBack">
                        <select class="easyui-combobox" id="tdCallBackStatus" style="width: 100px; height: 25px;" data-options="prompt:'回访状态',editable:false">
                            <option value="2">未回访</option>
                            <option value="1">已回访</option>
                        </select>
                    </label>
                    <label class="tdCallBack">
                        <select class="easyui-combobox" id="tdCallServiceType" style="width: 100px; height: 28px;" data-options="prompt:'回访类别',editable:false">
                            <option value="1">报修</option>
                            <option value="2">投诉</option>
                        </select>
                    </label>
                    <label>
                        <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                    </label>
                </div>
            </div>
            <div data-options="region:'center'" title="">
                <table id="tt_table">
                </table>
                <div id="tb">
                    <%if (base.CheckAuthByModuleCode("1101158") && (status == 100 || status == 101 || status == 10))
                        { %>
                    <a href="javascript:void(0)" onclick="do_add()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101159") && (status == 0 || status == 100 || status == 101 || status == 10 || status == 3))
                        { %>
                    <a href="javascript:void(0)" onclick="do_edit()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101165") && (status == 100 || status == 101 || status == 10))
                        { %>
                    <%--<a href="javascript:void(0)" onclick="do_remove()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>--%>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101172") && (status == 100 || status == 101 || status == 10 || status == 3 || status == 13))
                        { %>
                    <a href="javascript:void(0)" onclick="do_send()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-chuli'">派单</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101160") && (status == 0 || status == 101 || status == 13))
                        { %>
                    <a href="javascript:void(0)" onclick="do_process()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-chuli'">处理</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101161") && (status == 0 || status == 101 || status == 13))
                        { %>
                    <a href="javascript:void(0)" onclick="do_complete()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-banjie'">办结</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101162") && (status == 12 || status == 13))
                        { %>
                    <a href="javascript:void(0)" onclick="do_callback()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-huifang'">回访</a>
                    <a href="javascript:void(0)" onclick="do_mark_notcall(1)" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-save'">暂不回访</a>
                    <a href="javascript:void(0)" onclick="do_mark_notcall(0)" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-save'">取消暂不回访</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1191183") && (status == 12))
                        { %>
                    <%--<a href="javascript:void(0)" onclick="do_addrate()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-huifang'">评分</a>--%>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101163"))
                        { %>
                    <a href="javascript:void(0)" onclick="do_view()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-detail'">详情</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101164"))
                        { %>
                    <a href="javascript:void(0)" onclick="do_print()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-print'">打印</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101166"))
                        { %>
                    <a href="javascript:void(0)" onclick="do_cancel()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-cancelorder'">销单</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101169") && status != 4)
                        { %>
                    <a href="javascript:void(0)" onclick="do_finish()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-banjie'">关单</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101170") && (status == 4 || status == 12 || status == 13))
                        { %>
                    <a href="javascript:void(0)" onclick="do_reopen()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-banjie'">重新开单</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101171") && (status != 4))
                        { %>
                    <a href="javascript:void(0)" onclick="do_confirm()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-banjie'">审计确认</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101167"))
                        { %>
                    <a href="javascript:void(0)" onclick="openTableSetUp()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-setting'">配置</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101168"))
                        { %>
                    <a href="javascript:void(0)" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101173") && status != 10 && status != 3)
                        { %>
                    <a href="javascript:void(0)" onclick="do_view_process()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-chuli'">处理记录</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101174") && status != 10 && status != 3)
                        { %>
                    <a href="javascript:void(0)" onclick="do_view_callback()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-chuli'">回访记录</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101175"))
                        { %>
                    <a href="javascript:void(0)" onclick="do_view_record()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-chuli'">拨打记录</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1191178"))
                        { %>
                    <a href="javascript:void(0)" onclick="do_complete_remove()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">彻底删除</a>
                    <%} %>
                    <asp:HiddenField ID="hdOrderBy" runat="server" />
                    <asp:HiddenField ID="hdIDs" runat="server" />
                </div>
            </div>
        </div>
    </form>
    <iframe name="myiframe" id="myframe" style="display: none;" src="" width="100%" height="100%"></iframe>
</asp:Content>
