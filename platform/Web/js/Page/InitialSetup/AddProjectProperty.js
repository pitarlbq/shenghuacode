var yetaiData = [];
var columnarry = [];
var maxlevel = 0;
var selectytobj = {};
var totalcolumn = 100;
var YyTitle = '';
$(function () {
    var yetai_item = {};
    yetaiData = [];
    for (var i = 0; i < totalcolumn; i++) {
        yetai_item['level' + i] = 0;
    }
    yetai_item['levelname'] = '';
    yetaiData.push(yetai_item);
    load_property_grid();
})
function load_property_grid() {
    var options = { visit: 'loadyttables', ProjectID: ProjectID, PropertyID: PropertyID };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ProjectPropertyHandler.ashx',
        data: options,
        success: function (data) {
            if (data.status && data.values.length > 0) {
                selectytobj = data.values[0];
                load_tt(data.values[0]);
                loadWinGrid(data.values[0]);
                YyTitle = selectytobj.title;
            }
        }
    });
}
function load_tt(obj) {
    columnarry = [];
    var columns = [];
    $.each(obj.list, function (index, listvalue) {
        if (index == 0) {
            columns.push({ field: 'level' + index, formatter: function (value, row) { if (value <= 0) { return obj.order } return value; }, title: '排序序号', editor: { type: 'numberbox' }, width: 40 });
        }
        var column_name = listvalue.Name + '数量';
        if (index > 0) {
            column_name = listvalue.Name + '数量（' + formatYTTitleName("每一" + obj.list[index - 1].Name) + '）';
        }
        columns.push({ field: 'level' + (index + 1), editor: { type: 'numberbox' }, title: column_name, width: 100 });
    });
    columnarry.push(columns);
    $('#tt_table').datagrid({
        border: false,
        fit: true,
        fitColumns: true,
        data: yetaiData,
        columns: columnarry,
        onLoadSuccess: function (data) {
            editrow(data);
            $('#tt_table').datagrid('getEditor', { index: 0, field: 'level0' }).target.textbox("setValue", obj.order);
        }
    });
}
function editrow(data) {
    $.each(data.rows, function (index, row) {
        $('#tt_table').datagrid('beginEdit', index);
        $('#tt_table').datagrid('getEditor', { index: index, field: 'level0' }).target.numberbox("disable", true);
    });
}
function closeyt() {
    var options = { visit: 'deleteproperty', ProjectID: ProjectID, PropertyID: PropertyID };
    top.$.messager.confirm("提示", "关闭后该业态以后将不会在该项目下显示.确认关闭?", function (r) {
        if (r) {
            $.ajax({
                type: 'POST',
                dataType: 'html',
                url: '../Handler/ProjectPropertyHandler.ashx',
                data: options,
                success: function (data) {
                    if (data == "0") {
                        do_close();
                    }
                    else if (data == "2") {
                        show_message("禁止删除", "warning");
                    }
                    else {
                        show_message("系统错误", "error");
                    }
                }
            });
        }
    });
}
function loadWinGrid(obj) {
    var maxlevel = getmaxlevel(obj.list[0].Name, obj.title);
    columnarry = [];
    var columns = [];
    var firstvalue = "";
    $.each(obj.list, function (index, listvalue) {
        if (index == 0) {
            columns.push({
                field: 'sortorder', formatter: function (value, row, rowindex) {
                    return (maxlevel + rowindex + 1)
                }, title: '序号', width: 20, editor: { type: 'numberbox' }
            });
            firstvalue = listvalue.Name;
            columns.push({
                field: 'levelname', formatter: function (value, row, rowindex) {
                    if (value == "") {
                        var ytvalue = '';
                        if (IsParent == "0") {
                            CurrentGrade = (CurrentGrade == "" ? "" : CurrentGrade);
                            var levelgrade = (maxlevel + index + 1);
                            levelgrade = (levelgrade < 10 ? "0" + levelgrade : levelgrade);
                            ytvalue = CurrentGrade + levelgrade;
                        }
                        else {
                            ytvalue = "第" + (maxlevel + rowindex + 1) + firstvalue;
                        }
                        return formatYTName(ytvalue);
                    }
                    return value;
                }, editor: { type: 'textbox' }, title: listvalue.Name + '名称', width: 100
            });
            return true;
        }
        var column_name = listvalue.Name + '数量';
        if (index > 0) {
            column_name = listvalue.Name + '数量（' + formatYTTitleName("每一" + obj.list[index - 1].Name) + '）';
        }
        columns.push({ field: 'level' + (index + 1), editor: { type: 'numberbox' }, title: column_name, width: 100 });
    });
    columnarry.push(columns);
    $('#tt_2_table').datagrid({
        border: true,
        fit: true,
        fitColumns: true,
        columns: columnarry,
        onLoadSuccess: function (data) {
            maxlevel = getmaxlevel(obj.list[0].Name, obj.title);
            editrow2(maxlevel, firstvalue);
            //editrow(obj.title + '_wintable', data);
        }
    });
}
function formatYTName(value) {
    return value.replace("楼栋", "栋").replace("楼层", "层").replace("第", "");
}
function formatYTTitleName(value) {
    return value.replace("一楼栋", "栋").replace("一单元", "单元").replace("一楼层", "层");
}
function editrow2(maxlevel, firstvalue) {
    var obj = $("#tt_2_table");
    var data = obj.datagrid("getData");
    $.each(data.rows, function (index, row) {
        var timerange = 1000;
        var timer = setTimeout(function () {
            obj.datagrid('beginEdit', index);
            if (firstvalue != "" && row.levelname == "") {
                var levelname = '';
                var sortorder = (maxlevel + index + 1);
                if (Number(row.level1) > 0) {
                    if (IsParent == "0") {
                        CurrentGrade = (CurrentGrade == "" ? "" : CurrentGrade);
                        var levelgrade = (sortorder < 10 ? "0" + sortorder : sortorder);
                        levelname = CurrentGrade + levelgrade;
                    }
                    else {
                        levelname = "第" + (maxlevel + index + 1) + firstvalue;
                    }
                }
                obj.datagrid('getEditor', { index: index, field: 'sortorder' }).target.textbox("setValue", sortorder);
                obj.datagrid('getEditor', { index: index, field: 'levelname' }).target.textbox("setValue", formatYTName(levelname));
            }
            obj.datagrid('getEditor', { index: index, field: 'sortorder' }).target.textbox("disable", true);
        }, parseInt(index / 5) * timerange);
    });
}
function getmaxlevel(typedesc, titlevalue) {
    var returnvalue = 0;
    var jsonarry = [];
    var options = { visit: 'getmaxlevel', ID: ProjectID };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        async: false,
        url: '../Handler/ProjectHandler.ashx',
        data: options,
        success: function (message) {
            jsonarry = message;
            $.each(jsonarry, function (n, value) {
                if (value.TypeDesc == typedesc && value.PName == titlevalue) {
                    returnvalue = Number(value.MaxLevel);
                    return false;
                }
            });
        }
    });
    return returnvalue;
}
function viewyt() {
    $('#win_property').window({
        closed: false,
        onClose: function () {
            if (parent.isUpdate) {
                parent.doSearch();
            }
        }
    });
    $('#win_property').window('center');
    var tableobj = $("#tt_table");
    var data = tableobj.datagrid("getData");
    var winrows = [];
    $.each(data.rows, function (index, row) {
        var rowIndex = tableobj.datagrid('getRowIndex', row);
        tableobj.datagrid('endEdit', rowIndex);
        if (Number(row.level1) > 0) {
            for (var i = 0; i < Number(row.level1) ; i++) {
                var newrow = row;
                winrows.push(newrow);
            }
        }
        else {
            winrows.push(row);
        }
        tableobj.datagrid('beginEdit', rowIndex);
    });
    $("#tt_2_table").datagrid("loadData", winrows);
}
function newsaveyt() {
    var wintableobj = $("#tt_2_table");
    var data = wintableobj.datagrid("getData");
    if (data.rows.length == 0) {
        show_message("第一级数量不能为空", "warning");
        return;
    }
    var ProjectName = parent.$("#projectname").val();
    if (ProjectName == "") {
        show_message("项目名称不能为空", "warning");
        return;
    }
    var strlist = [];
    var alllasterror = true;

    var total_rooms = 0;
    $.each(data.rows, function (index, row) {
        var parentid = 0;
        var row_total = 1;
        $.each(selectytobj.list, function (i, ytobj) {
            var count, Name, sortorder;
            if (i == 0) {
                count = 1;
                Name = wintableobj.datagrid('getEditor', { index: index, field: 'levelname' }).target.textbox("getValue");
                sortorder = wintableobj.datagrid('getEditor', { index: index, field: 'sortorder' }).target.numberbox("getValue");
                if (i == selectytobj.list.length - 1) {
                    alllasterror = false;
                }
            }
            else {
                count = wintableobj.datagrid('getEditor', { index: index, field: 'level' + (i + 1) }).target.numberbox("getValue");
                if (count > 0) {
                    alllasterror = false;
                }
                if (count == null || count == "") {
                    count = 0;
                }
                Name = ytobj.Name;
                sortorder = 0;
            }
            var id = index + "_" + i + "_" + Name;
            var TypeDesc = ytobj.Name;
            strlist.push({ ID: id, Name: Name, SortOrder: sortorder, Count: count, ParentID: parentid, TypeDesc: TypeDesc, PName: YyTitle });
            parentid = id;
            row_total = row_total * (count > 0 ? count : 1);
        })
        total_rooms += row_total;
    })
    if (alllasterror) {
        show_message("数量不能为空", 'warning');
        return;
    }
    if (total_rooms > TotalRoomCount) {
        show_message("每次创建的房间总数量不能超过" + TotalRoomCount + '个', 'warning');
        return;
    }
    var strarry = null;
    var tableobj = $("#tt_table");
    var ytnumber = tableobj.datagrid('getEditor', { index: 0, field: 'level0' }).target.numberbox("getValue");
    if (strlist.length > 0) {
        strarry = { title: YyTitle, order: ytnumber, list: strlist };
    }
    if (strarry == null && ProjectID != 1) {
        show_message("请添加项目业态", "warning");
        return;
    }
    top.$.messager.confirm("提示", "是否提交?", function (r) {
        if (r) {
            parent.MaskUtil.mask("body", '提交中');
            var options = { visit: 'savesubproject', strjson: JSON.stringify(strarry), ProjectID: ProjectID, ProjectName: ProjectName, PropertyID: PropertyID, CompanyID: CompanyID };
            $.ajax({
                type: 'POST',
                dataType: 'html',
                url: '../Handler/ProjectHandler.ashx',
                data: options,
                success: function (message) {
                    parent.MaskUtil.unmask();
                    issaving = false;
                    if (message == "0") {
                        show_message('保存成功', 'success', function () {
                            top.isUpdate = true;
                            parent.do_close();
                        });
                    }
                    else if (message == "1") {
                        show_message("请添加项目业态", "warning");
                        return;
                    }
                    else if (message == "2") {
                        show_message("项目名称不能为空", "warning");
                        return;
                    }
                    else {
                        show_message("保存失败", "error");
                    }
                }
            });
        }
    });
}
function closewin() {
    $("#win_property").window('close');
}