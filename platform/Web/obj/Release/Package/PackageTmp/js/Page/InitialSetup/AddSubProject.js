var yetaiData = [];
var columnarry = [];
var maxlevel = 0;
var selectytobj = {};
$(function () {
    if (ProjectID != 1) {
        $("#projectname").textbox({ disabled: true });
        $("#divedit").removeClass("hidefield");
        $("#divsave").addClass("hidefield");
    }
    else {
        $("#projectname").textbox({ disabled: false });
        $("#editsavetd").addClass("hidefield");
    }
    yetaiData = [{ "level0": 0, "level1": "0", "level2": 0, "level3": 0, "level4": 0, "level5": 0, "level6": 0, "level7": 0, "level8": 0, "level9": 0, "level10": 0, "level11": 0, "level12": 0, "level13": 0, "level14": 0, "level15": 0, "level16": 0, "level17": 0, "level18": 0, "level19": 0, "level20": 0, "level21": 0, "level22": 0, "level23": 0, "level24": 0, "level25": 0, "level26": 0, "level27": 0, "level28": 0, "level29": 0, "level30": 0, "levelname": "" }];
    loadAccording();
})
function loadAccording() {
    var options = { visit: 'loadyttables', ProjectID: ProjectID, CompanyID: CompanyID };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ProjectPropertyHandler.ashx',
        data: options,
        success: function (data) {
            if (data.status) {
                $('#ytAccording').accordion({
                    animate: true,
                    fit: false,
                    onSelect: function (title, index) {
                        var PropertyID = title.split('_')[0].replace("<span style='display:none;'>", "");
                        var valueojb = getListByTitle(PropertyID, data.values);
                        selectytobj = valueojb;
                        loadGrid(valueojb);
                        loadWinGrid(valueojb);
                    }
                });
                selectytobj = data.values[0];
                loadGrid(data.values[0]);
                loadWinGrid(data.values[0]);
                //$.each(data.values, function (i, item) {
                //    loadGrid(item.title, item.list);
                //});
            }
        }
    });
}
function getListByTitle(PropertyID, totallist) {
    var valueobj = {};
    $.each(totallist, function (index, value) {
        if (PropertyID == value.ID) {
            valueobj = value;
            return false;
        }
    });
    return valueobj;
}
function loadGrid(obj) {
    columnarry = [];
    var columns = [];
    $.each(obj.list, function (index, listvalue) {
        if (index == 0) {
            columns.push({ field: 'level' + index, formatter: function (value, row) { if (value <= 0) { return obj.order } return value; }, title: '排序序号', editor: { type: 'numberbox' }, width: 40 });
        }
        columns.push({ field: 'level' + (index + 1), editor: { type: 'numberbox' }, title: listvalue.Name + '数量', width: 100 });
        if (index == obj.list.length - 1) {
            var formathtml = '<a  href="javascript:viewyt(\'' + obj.title + '\',\'' + obj.ID + '\')" style="margin-right:10px;">预览保存</a>';
            if (canCloseYT.val() == "1") {
                formathtml += '<a  href="javascript:closeyt(\'' + obj.ID + '\')">关闭</a>';
            }
            columns.push({ field: 'operation', formatter: function (value, row) { return formathtml; }, title: '操作', width: 100 });
        }
    });
    columnarry.push(columns);
    $('#' + obj.ID + '_table').datagrid({
        border: true,
        fit: false,
        fitColumns: true,
        data: yetaiData,
        columns: columnarry,
        onLoadSuccess: function (data) {
            editrow(obj.ID + '_table', data);
            $('#' + obj.ID + '_table').datagrid('getEditor', { index: 0, field: 'level0' }).target.textbox("setValue", obj.order);
        }
    });
}
function closeyt(ID) {
    var options = { visit: 'deleteproperty', ProjectID: ProjectID, CompanyID: CompanyID, PropertyID: ID };
    top.$.messager.confirm("提示", "关闭后该业态以后将不会在该项目下显示.确认关闭?", function (r) {
        if (r) {
            $.ajax({
                type: 'POST',
                dataType: 'html',
                url: '../Handler/ProjectPropertyHandler.ashx',
                data: options,
                success: function (data) {
                    if (data == "0") {
                        window.location.reload();
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
        columns.push({ field: 'level' + (index + 1), editor: { type: 'numberbox' }, title: listvalue.Name + '数量', width: 100 });
    });
    columnarry.push(columns);
    $('#' + obj.ID + '_wintable').datagrid({
        border: true,
        fit: true,
        fitColumns: true,
        columns: columnarry,
        onLoadSuccess: function (data) {
            maxlevel = getmaxlevel(obj.list[0].Name, obj.title);
            editrow2(obj.ID + '_wintable', maxlevel, firstvalue);
            //editrow(obj.title + '_wintable', data);
        }
    });
}
function formatYTName(value) {
    return value.replace("楼栋", "栋").replace("楼层", "层").replace("第", "");
}
function formatNumber(value, row) {

}

function editrow(id, data) {
    var obj = $("#" + id);
    $.each(data.rows, function (index, row) {
        obj.datagrid('beginEdit', index);
        obj.datagrid('getEditor', { index: index, field: 'level0' }).target.numberbox("disable", true);
    });
}
function editrow2(id, maxlevel, firstvalue) {
    var obj = $("#" + id);
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
                //row.levelname = "第" + (maxlevel + index + 1) + firstvalue;
                obj.datagrid('getEditor', { index: index, field: 'levelname' }).target.textbox("setValue", formatYTName(levelname));
            }
            obj.datagrid('getEditor', { index: index, field: 'sortorder' }).target.textbox("disable", true);
        }, parseInt(index / 5) * timerange);
    });
}
function getmaxlevel(typedesc, titlevalue) {
    var returnvalue = 0;
    var jsonarry = [];
    var options = { visit: 'getmaxlevel', ID: ProjectID, CompanyID: CompanyID };
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
function viewyt(title, PropertyID) {
    $('#' + PropertyID + '_win').window({
        closed: false,
        onClose: function () {
            if (parent.isUpdate) {
                parent.doSearch();
            }
        }
    });
    $('#' + PropertyID + '_win').window('center');
    var tableobj = $("#" + PropertyID + "_table");
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
    var wintableobj = $("#" + PropertyID + "_wintable");
    wintableobj.datagrid("loadData", winrows);
}
function newsaveyt(title, PropertyID) {
    var wintableobj = $("#" + PropertyID + "_wintable");
    var data = wintableobj.datagrid("getData");
    if (data.rows.length == 0) {
        show_message("第一级数量不能为空", "warning");
        return;
    }
    var ProjectName = $("#projectname").val();
    if (ProjectName == "") {
        show_message("项目名称不能为空", "warning");
        return;
    }
    var strlist = [];
    var alllasterror = true;

    $.each(data.rows, function (index, row) {
        var parentid = 0;
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
            strlist.push({ ID: id, Name: Name, SortOrder: sortorder, Count: count, ParentID: parentid, TypeDesc: TypeDesc, PName: title });
            parentid = id;
        })
    })
    if (alllasterror) {
        show_message("数量不能为空", 'info');
        return;
    }
    var strarry = null;
    var tableobj = $("#" + PropertyID + "_table");
    var ytnumber = tableobj.datagrid('getEditor', { index: 0, field: 'level0' }).target.numberbox("getValue");
    if (strlist.length > 0) {
        strarry = { title: title, order: ytnumber, list: strlist };
    }
    if (strarry == null && ProjectID != 1) {
        show_message("请添加项目业态", "warning");
        return;
    }
    top.$.messager.confirm("提示", "是否提交?", function (r) {
        if (r) {
            MaskUtil.mask("#" + PropertyID + "_win", '提交中');
            var options = { visit: 'savesubproject', strjson: JSON.stringify(strarry), ProjectID: ProjectID, AddMan: AddMan, ProjectName: ProjectName, CompanyID: CompanyID, PropertyID: PropertyID };
            $.ajax({
                type: 'POST',
                dataType: 'html',
                url: '../Handler/ProjectHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    issaving = false;
                    if (message == "0") {
                        show_message("保存成功", "success", function () {
                            parent.isUpdate = true;
                            closewin(title, PropertyID);
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
function closewin(title, PropertyID) {
    var wintableobj = $("#" + PropertyID + "_win");
    wintableobj.window('close');
}
function editName() {
    $("#projectname").textbox({ disabled: false });
    $("#divedit").addClass("hidefield");
    $("#divsave").removeClass("hidefield");
    var options = { visit: 'getprojectbyid', ID: ProjectID };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ProjectHandler.ashx',
        data: options,
        success: function (message) {
            if (message.status) {
                $("#projectname").textbox('setValue', message.Name);
            }
        }
    });
}
function saveName() {
    $("#projectname").textbox({ disabled: true });
    $("#divedit").removeClass("hidefield");
    $("#divsave").addClass("hidefield");
    var ProjectName = $("#projectname").textbox('getValue');
    if (ProjectName == "") {
        show_message("项目名称不能为空", "warning");
        return;
    }
    var CompanyID = GetSelectCompanyID();
    var options = { visit: 'saveprojectnamebyid', ProjectID: ProjectID, ProjectName: ProjectName ,CompanyID};
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ProjectHandler.ashx',
        data: options,
        success: function (message) {
            if (message.code == "0") {
                show_message("保存成功", "success", function () {
                    $("#projectname").textbox('setValue', message.FullName);
                });
            }
            else if (message.code == "2") {
                show_message("项目名称不能为空", "warning");
                return;
            }
            else {
                show_message("保存失败", "error");
            }
        }
    });
}
function openytwin() {
    var iframeurl = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../InitialSetup/AddProperty.aspx?ProjectID=" + ProjectID + "' style='width:100%;height:" + ($(parent.window).height() - 40) + "px'></iframe>";
    //if (ProjectID == 1 || ParentID == 1) {
    //    iframeurl = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../InitialSetup/AddTopProperty.aspx?ProjectID=" + ProjectID + "' style='width:100%;height:99%'></iframe>";
    //}
    open_parent_win('新增业态信息', 'win_pro', iframeurl, ($(parent.window).width() - 300), $(parent.window).height(), 0, true, true, function () {
        parent.$("#win_pro").remove();
        window.location.reload();
    })
}
function showytwin() {
    var iframeurl = "";
    if (ProjectID != 1 && ParentID != 1) {
        return;
    }
    var iframeurl = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../InitialSetup/PropertySetup.aspx?ProjectID=" + ProjectID + "' style='width:100%;height:99%'></iframe>";
    open_parent_win('业态设置', 'win_set', iframeurl, ($(parent.window).width() - 300), $(parent.window).height(), 0, true, true, function () {
        parent.$("#win_set").remove();
        window.location.reload();
    })
}