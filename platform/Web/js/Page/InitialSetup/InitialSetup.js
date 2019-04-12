var tt_CanLoad = false;
$(function () {
    loadTT();
});
function loadTT() {
    var options = { visit: 'loadtablecolumn', pagecode: 'roomsource', TableName: 'RoomBasic' };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/RoomResourceHandler.ashx',
        data: options,
        success: function (message) {
            if (message.status) {
                var finalcolumn = [];
                finalcolumn = eval(message.columns);
                $('#tt_table').datagrid({
                    url: '../Handler/RoomResourceHandler.ashx',
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
                    //onClickCell: onClickCell,
                    onDblClickRow: onDblClickRow,
                    columns: finalcolumn,
                    pageSize: global_variable.pageSize,
                    pageList: global_variable.pageList,
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
                    toolbar: '#tb'
                });
                SearchTT();
                return;
            }
            show_message('系统错误', 'error');
        }
    });
}
function SearchTT() {
    var options = get_options();
    if (options == null) {
        return;
    }
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", options);
}
function doSearch() {
    top.treeType = 1;
    top.openTreeContent();
}
function get_options() {
    var roomids = top.GetSelectedRooms();
    var projectid = top.GetSelectProjectID();
    var CompanyID = top.GetSelectCompanyID();
    if (roomids.length == 0 && (projectid == null || projectid == "") && CompanyID == '') {
        return null;
    }
    var projectids = [];
    if (projectid != null && projectid != "") {
        projectids.push(projectid);
    }
    hdRoomIDs.val(JSON.stringify(roomids));
    hdProjectID.val(JSON.stringify(projectids));
    var options = {
        "visit": "loadroomresourcelist",
        "RoomID": hdRoomIDs.val(),
        "ProjectID": hdProjectID.val(),
        "SearchAreas": hdSearchAreas.val(),
        "OwnerName": null,
        "OwnerPhoneNumber": null,
        "Keywords": tdKeyword.searchbox("getValue"),
        "CompanyID": CompanyID
    };
    return options;
}
function do_export() {
    var options = get_options();
    if (options == null) {
        return;
    }
    options.canexport = true;
    options.page = 1;
    options.rows = 10;
    MaskUtil.mask('body', '导出中');
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/RoomResourceHandler.ashx',
        data: options,
        success: function (data) {
            MaskUtil.unmask();
            if (data.downloadurl) {
                window.location.href = data.downloadurl;
                return;
            }
            if (data.error) {
                show_message(data.error, 'warning');
                return;
            }
            show_message('系统异常', 'error');
        }
    });
}
function onDblClickRow(index, row) {
    editRoomSource(row.RoomID, row.Name)
}
function do_dialog_comm_close(loadtree) {
    do_close_dialog();
    $("#tt_table").datagrid("reload");
    if (loadtree) {
        doSearch();
    }
}
function editRoomSource(RoomID, Name) {
    var iframe;
    do_open_dialog('修改' + Name + '信息', '../RoomResource/EditRoomResource.aspx?RoomID=' + RoomID);
}
function formatNumber(value, row) {
    if (value < 0) {
        return 0;
    }
    return value;
}
function formatMonth(value, row) {
    if (value == undefined || value == null || value == '0001-01-01T00:00:00.0000000' || value == '0001-01-01T00:00:00' || value == '1900-01-01T00:00:00.0000000' || value == '1900-01-01T00:00:00') {
        return "--";
    }
    return value.substring(0, 7);
}
function openImport() {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../RoomResource/ImportSource.aspx' style='width:100%;height:" + ($(window).height() - 190) + "px;'></iframe>";
    do_open_dialog('导入房间信息', '../RoomResource/ImportSource.aspx');
}
function editProject() {
    var iframe, Name;
    var width = $(window).width() - 400;
    var height = $(window).height();
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length > 0) {
        Name = rows[0].Name;
        iframe = '../RoomResource/EditRoomResource.aspx?RoomID=' + rows[0].RoomID;
    }
    else {
        var roomids = top.GetSelectedRooms();
        Name = '';
        if (roomids.length == 0) {
            var projectid = top.GetSelectProjectID();
            if (projectid == null || projectid == "") {
                show_message("请选择一个资源", "warning");
                return;
            }
            if (projectid == 1) {
                show_message("请选择一个资源", "warning");
                return;
            }
            Name = '资源';
            iframe = "../RoomResource/EditRoomName.aspx?ID=" + projectid;
        }
        else {
            var treeObj = $.fn.zTree.getZTreeObj("tt");
            var node = treeObj.getNodeByParam("id", roomids[0], null);
            Name = '房间';
            iframe = "../RoomResource/EditRoomResource.aspx?RoomID=" + node.id;
        }
    }
    do_open_dialog('修改' + Name + '信息', iframe);
}
function saveFee() {
    var ImportFeeList = [];
    var rows = $('#tt_table').datagrid("getSelections");
    $.each(rows, function (index, row) {
        if (row.ChargeStatus == 1) {
            return true;
        }
        var rowIndex = $('#tt_table').datagrid('getRowIndex', row);
        $('#tt_table').datagrid('endEdit', rowIndex);
        ImportFeeList.push(row);
    });
    var options = { visit: 'saveimportfee', FeeType: 2, ImportFeeList: JSON.stringify(ImportFeeList) };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ImportFeeHandler.ashx',
        data: options,
        success: function (message) {
            if (message.status) {
                show_message("修改成功", "success");
                $('#tt_table').datagrid("reload");
            }
            else {
                show_message('系统错误', 'error');
            }
        }
    });
}
function setupFee() {
    var iframe = "../Charge/SetupFee_ChaoBiao.aspx";
    do_open_dialog('代收费用设置', iframe);
}
function openTableSetUp() {
    var iframe = "../SysSeting/TableSetUp.aspx?PageCode=roomsource&&TableName=RoomBasic";
    do_open_dialog('资源档案列表设置', iframe);
}
function openFieldSetUp() {
    var iframe = "../InitialSetup/EditColumns.aspx";
    do_open_dialog('参数设置', iframe);
}
function do_connection() {
    var RoomIDs = [];
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length > 0) {
        $.each(rows, function (index, row) {
            RoomIDs.push(row.RoomID);
        })
    }
    if (RoomIDs.length <= 1) {
        show_message('请至少选择两个房间资源', 'info');
        return;
    }
    top.$.messager.confirm("提示", "确认关联选中的房源", function (r) {
        if (r) {
            var options = { visit: 'connectproject', RoomIDs: JSON.stringify(RoomIDs) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ProjectHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status == 1) {
                        show_message('添加成功', 'success');
                        $("#tt_table").datagrid("reload");
                    }
                    else if (message.status == 2) {
                        show_message("选中房源已关联", "info");
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
    })
}

