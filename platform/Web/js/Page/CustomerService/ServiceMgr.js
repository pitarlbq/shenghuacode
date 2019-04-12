var tt_CanLoad = false;
$(function () {
    getComboboxParams();
    loadTT();
});
function getComboboxParams() {
    var options = { visit: 'getservicemgrparams', pagecode: 'customerservice' };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ServiceHandler.ashx',
        data: options,
        success: function (message) {
            if (message.status) {
                $('#tdAccpetMan').combobox({
                    editable: false,
                    data: message.users,
                    valueField: 'UserID',
                    textField: 'RealName'
                })
                $('#tdAccpetMan').combobox('clear');
                return;
            }
            show_message('系统错误', 'error');
        }
    });
}
function loadTT() {
    tt_CanLoad = false;
    var options = { visit: 'loadtablecolumn', pagecode: 'customerservice', ColumnServiceStatus: ColumnServiceStatus, ColumnServiceType: ColumnServiceType };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/RoomResourceHandler.ashx',
        data: options,
        success: function (message) {
            if (message.status) {
                var finalcolumn = [];
                finalcolumn = eval(message.columns);
                //加载
                $('#tt_table').datagrid({
                    url: '../Handler/ServiceHandler.ashx',
                    loadMsg: '正在加载',
                    border: false,
                    remoteSort: false,
                    pagination: true,
                    rownumbers: true,
                    fit: true,
                    fitColumns: false,
                    singleSelect: false,
                    selectOnCheck: true,
                    checkOnSelect: true,
                    striped: true,
                    columns: finalcolumn,
                    pageSize: global_variable.pageSize,
                    pageList: global_variable.pageList,
                    showFooter: true,
                    onDblClickRow: onDblClickRow,
                    onBeforeLoad: function (data) {
                        if (!tt_CanLoad) {
                            $('#tt_table').datagrid("loadData", {
                                total: 0,
                                rows: []
                            });
                        }
                        return tt_CanLoad;
                    },
                    onLoadError: function (data) {
                        //alert("有错");
                        $('#tt_table').datagrid("loadData", {
                            total: 0,
                            rows: []
                        });
                    },
                    rowStyler: function (index, row) {
                        if (row.IsImportantTouSu) {
                            return 'background-color:#FF5151;color:#fff;';
                        }
                    },
                    toolbar: '#tb'
                });
                setTimeout(function () {
                    SearchTT()
                }, 100);
                return;
            }
            show_message('请先配置字段', 'warning');
        }
    });
}
function onDblClickRow(index, row) {
    var iframe = "../CustomerService/ServiceEdit.aspx?op=view&ID=" + row.ID;
    parent.do_open_dialog('任务详情', iframe);
}
function SearchTT() {
    var options = get_options();
    if (options == null) {
        return;
    }
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", options);
}
function get_options() {
    var StartTime = $("#tdStartTime").datebox("getValue");
    var EndTime = $("#tdEndTime").datebox("getValue");
    if (StartTime != '' && EndTime != '') {
        if (stringToDate(StartTime).valueOf() > stringToDate(EndTime).valueOf()) {
            show_message('开始日期不能大于结束日期', 'warning');
            return null;
        }
    }
    var roomids = [];
    var projectids = [];
    var allprojectids = [];
    try {
        roomids = parent.GetSelectedRooms();
        projectids = parent.GetSelectedProjects();
        allprojectids = parent.GetALLSelectedProjects();
    } catch (e) {

    }
    var ServiceAccpetManID = 0;
    try {
        ServiceAccpetManID = $('#tdAccpetMan').combobox('getValue');

    } catch (e) {
    }
    var ServiceRange = $('#tdServiceRange').combobox('getValue');
    var CallBackStatus = $('#tdCallBackStatus').combobox('getValue');
    var CallServiceType = $('#tdCallServiceType').combobox('getValue');
    if (Status != 12) {
        CallBackStatus = 0;
        CallServiceType = 0;
    }
    var options = {
        "visit": "loadservicelist",
        "RoomIDs": JSON.stringify(roomids),
        "ProjectIDs": JSON.stringify(projectids),
        "ALLProjectIDs": JSON.stringify(allprojectids),
        "ServiceStatus": Status,
        "StartTime": StartTime,
        "EndTime": EndTime,
        "Keywords": $("#tdKeywords").searchbox("getValue"),
        "PayStatus": $("#tdPayStatus").combobox("getValue"),
        "OrderBy": $('#tdSortOrder').combobox('getValue'),
        "ServiceAccpetManID": ServiceAccpetManID,
        "ServiceRange": ServiceRange,
        "ServiceType": parent.ServiceType,
        "CallBackStatus": CallBackStatus,
        "CallServiceType": CallServiceType,
        "ColumnServiceStatus": ColumnServiceStatus,
        "ColumnServiceType": ColumnServiceType,
        "BeforeBanJieTimeOutHour": BeforeBanJieTimeOutHour
    };
    if (Status == 101) {
        options.ChooseStatus = $('#tdServiceStatus').combobox('getValue');
    }
    options.url = '../Handler/ServiceHandler.ashx';
    return options;
}
function formatOper(value, row) {
    var $html = '<div>';
    if (row.ServiceStatus == 0) {
        $html += '<a onclick="editData(' + row.ID + ')" style="maring-right:10px;"><span style="color:red;">修改</span></a>';
        $html += ' <a onclick="sendData(' + row.ID + ')" style="maring-right:10px;"><span style="color:red;">处理</span></a>';
        $html += '<a onclick="completeData(' + row.ID + ')" style="maring-right:10px;"><span style="color:red;">办结</span></a>';

    }
    $html += '<a onclick="callData(' + row.ID + ')" style="maring-right:10px;"><span style="color:red;">回访</span></a>';
    $html += '<a onclick="viewData(' + row.ID + ')" style="maring-right:10px;"><span style="color:red;">详情</span></a>';
    $html += '<a onclick="printData(' + row.ID + ')"><span style="color:red;">打印</span></a>';
    $html += '</div>';
    return $html;
}
function formatRepairImg(value, row) {
    return '';
}
function formatNumber(value, row) {
    return (Number(value) > 0 ? value : "");
}
function formatTimeout(value, row) {
    if (row.TimeOutStatus == 2) {
        return '<img style="height:25px;" src="../styles/images/buttons/statuschaoshi.png" />';
    }
    if (row.TimeOutStatus == 3) {
        return '<img style="height:25px;" src="../styles/images/buttons/statusmorechashi.png" />';
    }
    return '<img style="height:25px;" src="../styles/images/buttons/statusnormal.png" />';
}
function formatProcess(value, row) {
    if (row.ProcessStatus == 2) {
        return '<img style="height:25px;" src="../styles/images/buttons/statuschuli.png" />';
    }
    if (row.ProcessStatus == 3) {
        return '<img style="height:25px;" src="../styles/images/buttons/statusbanjie.png" />';
    }
    if (row.ProcessStatus == 4) {
        return '<img style="height:25px;" src="../styles/images/buttons/statushuifang.png" />';
    }
    return '<img style="height:25px;" src="../styles/images/buttons/statusjiedan.png" />';
}
function formatClose(value, row) {
    if (row.IsClosed) {
        return '<img style="height:25px;" src="../styles/images/buttons/statussuoding.png" />';
    }
    return '<img style="height:25px;" src="../styles/images/buttons/statuskaisuo.png" />';
}
function do_print() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个任务", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("只能选择一个任务", "info");
        return;
    }
    var ID = rows[0].ID;
    try {
        var LODOP = getLodop();
        if ((LODOP != null) && (typeof (LODOP.VERSION) != "undefined")) {
            $("#myframe").attr("src", "../CustomerService/ServiceDetailSummary.aspx?ID=" + ID);
            setTimeout(function () {
                LODOP.PRINT_INIT("打印派工单");
                LODOP.SET_PRINT_PAGESIZE(0, 0, 0, "");
                var strHtml = document.getElementsByTagName("iframe")[0].contentWindow.document.documentElement.innerHTML;
                //alert(strHtml);
                LODOP.ADD_PRINT_HTM(0, '5%', "90%", "100%", strHtml);
                LODOP.PREVIEW();
                //LODOP.PRINT();
            }, 1000);
        }
        else {
            alert("Error:该浏览器不支持打印插件!");
        }
    } catch (err) {
        alert("Error:本机未安装或需要升级!");
    }
}
function do_send() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个任务", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("只能选择一个任务", "info");
        return;
    }
    if (rows[0].ServiceStatus == 2) {
        show_message("选中的任务已销单", "info");
        return;
    }
    if (rows[0].ServiceStatus == 1) {
        show_message("选中的任务已办结", "info");
        return;
    }
    if (rows[0].ServiceStatus == 5) {
        show_message("选中的任务已重新开单", "info");
        return;
    }
    if (rows[0].DisableSend) {
        show_message("选中的任务不允许派单", "info");
        return;
    }
    var ID = rows[0].ID;
    var iframe = "../CustomerService/ServiceSend.aspx?ID=" + ID + "&status=" + Status;
    parent.do_open_dialog('任务派单', iframe);
}
function do_process() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个任务", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("只能选择一个任务", "info");
        return;
    }
    if (rows[0].ServiceStatus == 2) {
        show_message("选中的任务已销单", "info");
        return;
    }
    if (rows[0].ServiceStatus == 1) {
        show_message("选中的任务已办结", "info");
        return;
    }
    if (rows[0].ServiceStatus == 5) {
        show_message("选中的任务已重新开单", "info");
        return;
    }
    if (rows[0].DisableProcee) {
        show_message("选中的任务不允许处理", "info");
        return;
    }
    var ID = rows[0].ID;
    var iframe = "../CustomerService/ServiceProcess.aspx?ID=" + ID;
    parent.do_open_dialog('任务处理', iframe);
}
function do_view_process() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个任务", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("只能选择一个任务", "info");
        return;
    }
    ID = rows[0].ID;
    var iframe = "../CustomerService/ServiceProcessMgr.aspx?ID=" + ID + "&op=view";
    parent.do_open_dialog('处理记录', iframe);
}
function do_view_callback() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个任务", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("只能选择一个任务", "info");
        return;
    }
    ID = rows[0].ID;
    var iframe = "../CustomerService/ServiceCallMgr.aspx?ID=" + ID + "&op=view";
    parent.do_open_dialog('回访记录', iframe);
}
//回访
function do_callback() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个任务", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("只能选择一个任务", "info");
        return;
    }
    if (rows[0].ServiceStatus == 2) {
        show_message("选中的任务已销单", "info");
        return;
    }
    if (rows[0].ServiceStatus == 5) {
        show_message("选中的任务已重新开单", "info");
        return;
    }
    if (rows[0].DisableCallback) {
        show_message("选中的任务不允许回访", "info");
        return;
    }
    var ID = rows[0].ID;
    var options = { visit: 'checkservicecallbackstatus', ID: ID };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ServiceHandler.ashx',
        data: options,
        success: function (data) {
            if (data.status) {
                var iframe = "../CustomerService/ServiceCall.aspx?ID=" + ID;
                parent.do_open_dialog('客户回访', iframe);
                return;
            }
            if (data.error) {
                show_message(data.error, "warning");
                return;
            }
            show_message('系统异常', "warning");
        }
    });
}
function do_addrate() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个任务", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("只能选择一个任务", "info");
        return;
    }
    if (rows[0].ServiceStatus == 2) {
        show_message("选中的任务已销单", "info");
        return;
    }
    if (rows[0].ServiceStatus == 5) {
        show_message("选中的任务已重新开单", "info");
        return;
    }
    var ID = rows[0].ID;
    var iframe = "../CustomerService/ServiceCallRateEdit.aspx?ID=" + ID;
    parent.do_open_dialog('处理满意度', iframe);
    return;
}
//办结
function do_complete() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个任务", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("只能选择一个任务", "info");
        return;
    }
    if (rows[0].ServiceStatus == 2) {
        show_message("选中的任务已销单", "info");
        return;
    }
    if (rows[0].ServiceStatus == 5) {
        show_message("选中的任务已重新开单", "info");
        return;
    }
    if (rows[0].ServiceStatus == 1) {
        show_message("选中的任务已办结", "info");
        return;
    }
    if (rows[0].DisableCompelte) {
        show_message("选中的任务不允许办结", "info");
        return;
    }
    var ID = rows[0].ID;
    var options = { visit: 'checkservicecompletestatus', ID: ID };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ServiceHandler.ashx',
        data: options,
        success: function (data) {
            if (data.error) {
                show_message(data.error, "warning");
                return;
            }
            var iframe = '';
            if (data.status && data.callCount > 0) {
                iframe = "../CustomerService/ServiceComplete.aspx?ID=" + ID;
            } else {
                iframe = "../CustomerService/ServiceProcess.aspx?ID=" + ID + '&op=complete';
            }
            parent.do_open_dialog('任务办结', iframe);
        }
    });
}
function do_edit() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个任务", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("只能选择一个任务", "info");
        return;
    }
    if (rows[0].ServiceStatus == 2) {
        show_message("任务已销单，不允许修改", "info");
        return;
    }
    top.isAddService = true;
    var ID = rows[0].ID;
    var iframe = "../CustomerService/ServiceEdit.aspx?ID=" + ID;
    parent.do_open_dialog('任务修改', iframe);
}
function do_complete_remove() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个任务", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "是否删除选中的任务", function (r) {
        if (r) {
            var options = { visit: 'removeservice', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ServiceHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('删除成功', 'success', function () {
                            $("#tt_table").datagrid("reload");
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
function do_cancel() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个任务", "info");
        return;
    }
    var IDList = [];
    var errormsg = '';
    $.each(rows, function (index, row) {
        if (row.ServiceStatus == 2) {
            errormsg = '选中的任务已销单';
            return false;
        }
        IDList.push(row.ID);
    })
    if (errormsg) {
        show_message(errormsg, "info");
        return;
    }
    top.$.messager.confirm("提示", "确认销单?", function (r) {
        if (r) {
            var options = { visit: 'cancelcustomerservice', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ServiceHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message("销单成功", "success", function () {
                            $("#tt_table").datagrid("reload");
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
function do_finish() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个任务", "info");
        return;
    }
    var IDList = [];
    var errormsg = '';
    $.each(rows, function (index, row) {
        if (row.IsClosed) {
            errormsg = '选中的任务已关单';
            return false;
        }
        IDList.push(row.ID);
    })
    if (errormsg) {
        show_message(errormsg, "info");
        return;
    }
    top.$.messager.confirm("提示", "确认关单?", function (r) {
        if (r) {
            var options = { visit: 'closecustomerservice', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ServiceHandler.ashx',
                data: options,
                success: function (data) {
                    if (data.status) {
                        show_message("关单成功", "success", function () {
                            $("#tt_table").datagrid("reload");
                        });
                        return;
                    }
                    if (data.error) {
                        show_message(data.error, "warning");
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
function do_view() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个任务", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("只能选择一个任务", "info");
        return;
    }
    var ID = rows[0].ID;
    var iframe = "../CustomerService/ServiceEdit.aspx?op=view&ID=" + ID;
    parent.do_open_dialog('任务详情', iframe);
}
//列设置
function openTableSetUp() {
    var iframe = "../SysSeting/TableSetUp.aspx?PageCode=customerservice&ColumnServiceStatus=" + ColumnServiceStatus + "&ColumnServiceType=" + ColumnServiceType;
    parent.do_open_dialog('任务列表设置', iframe);
}
function do_add() {
    top.isAddService = true;
    var iframe = "../CustomerService/ServiceEdit.aspx?ServiceType=" + ServiceType;
    parent.do_open_dialog('任务登记', iframe);
}
function do_remove() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个任务", "info");
        return;
    }
    var IDList = [];
    var errormsg = true;
    $.each(rows, function (index, row) {
        if (row.ServiceStatus != 3) {
            errormsg = '只能删除待处理任务';
            return false;
        }
        IDList.push(row.ID);
    })
    if (errormsg) {
        show_message(errormsg, "info");
        return;
    }
    top.$.messager.confirm("提示", "是否删除选中的任务", function (r) {
        if (r) {
            var options = { visit: 'removeservice', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ServiceHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('删除成功', 'success', function () {
                            $("#tt_table").datagrid("reload");
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
function do_view_record() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个任务", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("只能选择一个任务", "info");
        return;
    }
    var ID = rows[0].ID;
    var iframe = "../CustomerService/ServiceRecordMgr.aspx?op=view&ID=" + ID;
    parent.do_open_dialog('拨打记录', iframe);
}
function do_confirm() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个任务", "info");
        return;
    }
    var IDList = [];
    var errormsg = '';
    $.each(rows, function (index, row) {
        if (row.DisableShenJi) {
            errormsg = '选中的任务不允许审计确认';
            return;
        }
        IDList.push(row.ID);
    })
    if (errormsg) {
        show_message(errormsg, "info");
        return;
    }
    top.$.messager.confirm("提示", "确认审计确认", function (r) {
        if (r) {
            var options = { visit: 'doconfirmservice', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ServiceHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('操作成功', 'success', function () {
                            $("#tt_table").datagrid("reload");
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
function do_reopen() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个任务", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("只能选择一个任务", "info");
        return;
    }
    if (rows[0].ServiceStatus == 2) {
        show_message("选中的任务已销单", "info");
        return;
    }
    if (rows[0].ServiceStatus == 5) {
        show_message("选中的任务已重新开单", "info");
        return;
    }
    var ID = rows[0].ID;
    top.$.messager.confirm("提示", "确认重新开单", function (r) {
        if (r) {
            var options = { visit: 'doreopenservice', ID: ID }
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ServiceHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('操作成功', 'success', function () {
                            $("#tt_table").datagrid("reload");
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
function do_mark_important() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个任务", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "确认标注重要投诉？", function (r) {
        if (r) {
            var options = { visit: 'domarkimportant', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ServiceHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('操作成功', 'success', function () {
                            $("#tt_table").datagrid("reload");
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
function do_mark_notcall(status) {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个任务", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    var msg = status == 1 ? '确认暂不回访？' : '确认取消暂不回访？';
    top.$.messager.confirm("提示", msg, function (r) {
        if (r) {
            var options = { visit: 'domarknotcallback', IDList: JSON.stringify(IDList), status: status };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ServiceHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('操作成功', 'success', function () {
                            $("#tt_table").datagrid("reload");
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}