var tt_CanLoad = false;
$(function () {
    setTimeout(function () {
        loadtt();
    }, 500);
});
function loadtt() {
    $('#tt_table').treegrid({
        url: '../Handler/CKHandler.ashx',
        loadMsg: '正在加载',
        rownumbers: true,
        animate: true,
        collapsible: true,
        fit: true,
        fitColumns: true,
        singleSelect: false,
        idField: 'id',
        treeField: 'name',
        onDblClickRow: onDblClickRowTT,
        onBeforeLoad: function (data) {
            if (!tt_CanLoad) {
                $('#tt_table').treegrid("loadData", {
                    total: 0,
                    rows: []
                });
            }
            return tt_CanLoad;
        },
        onLoadError: function (data) {
            //alert("有错");
            $('#tt_table').treegrid("loadData", {
                total: 0,
                rows: []
            });
        },
        onLoadSuccess: function (data) {
            init();
        },
        columns: [[
        { field: 'name', title: '部门名称', width: 100 },
        { field: 'Operation', formatter: formatOperation, title: '操作', width: 150, align: 'center' }
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function init() {
    //去掉结点前面的文件及文件夹小图标
    $(".tree-icon,.tree-file").removeClass("tree-icon tree-file");
    $(".tree-icon,.tree-folder").removeClass("tree-icon tree-folder tree-folder-open tree-folder-closed");
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    tt_CanLoad = true;
    $("#tt_table").treegrid("load", {
        "visit": "loadckdepartmentgrid",
        "keywords": keywords
    });
}
function formatNumber(value, row) {
    return (value < 0 ? 0 : value);
}
function onDblClickRowTT(index, row) {
    editByRow(row.id)
}
function formatOperation(value, row) {
    if (row.type == 'company') {
        return '';
    }
    var $html = '';
    $html += '<a href="javascript:editByRow(' + row.ID + ')">修改</a>';
    return $html;
}
function addRow() {
    var ParentID = 1;
    var CompanyID = 0;
    var row = $("#tt_table").treegrid("getSelected");
    if (row == null) {
        show_message("请至少选择一个部门或公司进行此操作", "warning");
        return;
    }
    if (row.type == 'company') {
        CompanyID = row.ID;
    } else {
        ParentID = row.ID;
        CompanyID = row.CompanyID;
    }
    var iframe = "../CangKu/EditDepartment.aspx?ParentID=" + ParentID + "&CompanyID=" + CompanyID;
    do_open_dialog('新增部门', iframe);
}
function editRow() {
    var row = $("#tt_table").treegrid("getSelected");
    if (row == null) {
        show_message("请选择一个部门进行此操作", "warning");
        return;
    }
    if (row.type == 'company') {
        show_message("请选择一个部门进行此操作", "warning");
        return;
    }
    editByRow(rows.ID);
}
function editByRow(ID) {
    var iframe = "../CangKu/EditDepartment.aspx?ID=" + ID;
    do_open_dialog('修改部门', iframe);
}
function removeRow() {
    var rows = $("#tt_table").treegrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个部门进行此操作", "warning");
        return;
    }
    var IDList = [];
    var errormsg = '';
    $.each(rows, function (index, row) {
        if (row.type == 'company') {
            errormsg = "请选择一个部门进行此操作";
            return false;
        }
        IDList.push(row.ID);
    })
    if (errormsg) {
        show_message("请至少选择一个部门进行此操作", "warning");
        return;
    }
    top.$.messager.confirm("提示", "是否删除选中的部门", function (r) {
        if (r) {
            var options = { visit: 'removeckdepartment', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/CKHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        if (message.haschild) {
                            show_message("请先删除子级树", "warning");
                            return;
                        }
                        show_message('删除成功', 'success', function () {
                            $.each(IDList, function (index, ID) {
                                $("#tt_table").treegrid("remove", ID);
                            })
                            $("#tt_table").treegrid("reload");
                        });
                        return;
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
function chooseRow() {
    var rows = $("#tt_table").treegrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个部门进行此操作", "warning");
        return;
    }
    if (rows.length > 1) {
        show_message("请选择单行进行此操作", "warning");
        return;
    }
    try {
        parent.ChosenDepartmentID = rows[0].id;
        parent.ChosenDepartmentName = rows[0].name;
    } catch (e) {
    }
    do_close();
}
