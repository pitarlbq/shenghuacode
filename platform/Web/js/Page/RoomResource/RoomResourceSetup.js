var tt_CanLoad = false;
$(function () {
    loadTT();
});
function loadTT() {
    var options = { visit: 'loadtablecolumn', pagecode: 'roomsource' };
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
    return;
    var columnarry = [];
    columnarry.push({ field: 'ck', checkbox: true });
    columnarry.push({ field: 'FullName', title: '资源位置', width: 260 });
    columnarry.push({ field: 'Name', title: '资源编号', width: 80 });
    columnarry.push({ field: 'BuildingArea', formatter: formatNumber, title: '计费面积', width: 80 });
    columnarry.push({ field: 'PaymentTime', formatter: formatTime, title: '交房日期', width: 80 });
    columnarry.push({ field: 'RoomStateDesc', title: '房间状态', width: 80 });
    columnarry.push({ field: 'BuildingNumber', title: '期数', width: 80 });
    columnarry.push({ field: 'RoomType', title: '房间类型', width: 80 });
    columnarry.push({ field: 'RoomLayout', title: '户型', width: 80 });
    columnarry.push({ field: 'RoomOwner', title: '业主姓名', width: 80 });
    columnarry.push({ field: 'OwnerIDCard', title: '业主身份证', width: 80 });
    columnarry.push({ field: 'OwnerPhone', title: '业主手机号码', width: 100 });
    //columnarry.push({ field: 'FamilyName1', title: '家人姓名1', width: 100 });
    //columnarry.push({ field: 'FamilyPhone1', title: '家人手机号1', width: 100 });
    //columnarry.push({ field: 'FamilyName2', title: '家人姓名2', width: 100 });
    //columnarry.push({ field: 'FamilyPhone2', title: '家人手机号2', width: 100 });
    columnarry.push({ field: 'RentName', title: '租户姓名', width: 100 });
    columnarry.push({ field: 'RentPhoneNumber', title: '租户手机号', width: 100 });
    columnarry.push({ field: 'RentIDCard', title: '租户身份证号', width: 100 });
    columnarry.push({ field: 'RoomPropertyName', title: '房源属性', width: 100 });
    //columnarry.push({ field: 'RelateSourceFullName1', title: '关联资源1:资源位置', width: 200 });
    //columnarry.push({ field: 'RelateSourceName1', title: '关联资源1:资源编号', width: 100 });
    //columnarry.push({ field: 'RelateSourceBuildingArea1', title: '关联资源1:计费面积', width: 100 });
    //columnarry.push({ field: 'RelateSourceFullName2', title: '关联资源2:资源位置', width: 200 });
    //columnarry.push({ field: 'RelateSourceName2', title: '关联资源2:资源编号', width: 100 });
    //columnarry.push({ field: 'RelateSourceBuildingArea2', title: '关联资源2:计费面积', width: 100 });
    //columnarry.push({ field: 'RelateSourceFullName3', title: '关联资源3:资源位置', width: 200 });
    //columnarry.push({ field: 'RelateSourceName3', title: '关联资源3:资源编号', width: 100 });
    //columnarry.push({ field: 'RelateSourceBuildingArea3', title: '关联资源3:计费面积', width: 100 });

}
function SearchTT() {
    var roomid = [];
    roomids = top.GetSelectedRooms();
    var projectid = 0;
    if (roomids.length == 0) {
        projectid = top.GetSelectProjectID();
    }
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadroomresourcelist",
        "RoomID": JSON.stringify(roomids),
        "ProjectID": projectid,
        "OwnerName": null,
        "OwnerPhoneNumber": null
    });
}
function onDblClickRow(index, row) {
    var iframe;
    iframe = "../RoomResource/EditRoomResource.aspx?RoomID=" + row.RoomID;
    do_open_dialog('修改' + row.Name + '信息', iframe);
}
function edit_roomsource_done() {
    $("#tt_table").datagrid("reload");
    doSearch();
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
    var iframe = "../RoomResource/ImportSource.aspx";
    do_open_dialog('导入房间信息', iframe);
}
function editFee() {
    var iframe, Name;
    var roomids = top.GetSelectedRooms();
    if (roomids.length == 0) {
        var id = top.GetSelectProjectID();
        if (id == null || id == "") {
            show_message("请选择一个资源");
            return;
        }
        var treeObj = $.fn.zTree.getZTreeObj("tt");
        var node = treeObj.getNodeByParam("id", id, null);
        Name = node.name;
        iframe = "../Charge/EditRoomName.aspx?ID=" + node.id;
    }
    else {
        var treeObj = $.fn.zTree.getZTreeObj("tt");
        var node = treeObj.getNodeByParam("id", roomids[0], null);
        Name = node.name;
        if (node.PName == "车位" || node.PName == "车辆" || node.PName == "地下室") {
            iframe = "../Charge/EditRoomName.aspx?ID=" + node.id;
        }
        else {
            iframe = "../RoomResource/EditRoomResource.aspx?RoomID=" + node.id;
        }
    }
    do_open_dialog('修改' + Name + '信息', iframe);
}
function viewRoom() {
    SearchTT();
}

