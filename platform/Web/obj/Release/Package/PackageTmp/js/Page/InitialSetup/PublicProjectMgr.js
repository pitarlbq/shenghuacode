
var tt_CanLoad = false;
$(function () {
    setTimeout(function () {
        loadtt();
    }, 500);
});
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/ProjectHandler.ashx',
        loadMsg: '正在加载',
        border: true,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: true,
        fitColumns: true,
        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: true,
        onDblClickRow: onDblClickRowTT,
        striped: true,
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        columns: [[
            { field: 'ck', checkbox: true },
            { field: 'FinalFullName', title: '资源位置', width: 100 },
            { field: 'Name', title: '资源名称', width: 100 },
            { field: 'Operation', formatter: formatOperation, title: '操作', width: 100 }
        ]],
        onLoadError: function (data) {
            //alert("有错");
            $('#tt_table').datagrid("loadData", {
                total: 0,
                rows: []
            });
        },
        onLoadSuccess: function (node, data) {
            init();
        },
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
    var ProjectIDs = [];
    var PublicProjectIDs = [];
    try {
        ProjectIDs = GetSelectedProjects();
        PublicProjectIDs = GetSelectedPublicProjects();
    } catch (e) {
    }
    var keywords = $("#tdKeyword").searchbox("getValue");
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        visit: 'loadpublicprojectgrid',
        keywords: keywords,
        ProjectIDs: JSON.stringify(ProjectIDs),
        PublicProjectIDs: JSON.stringify(PublicProjectIDs)
    });
}
function formatOperation(index, row) {
    return '<a href="#" onclick="editRow(' + row.ID + ')" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:\'icon-edit\'">编辑</a>';
}
function onDblClickRowTT(index, row) {
    editRow(row.ID)
}
function addRow() {
    var ProjectIDs = [];
    var PublicProjectIDs = [];
    try {
        ProjectIDs = GetSelectedProjects();
        PublicProjectIDs = GetSelectedPublicProjects();
    } catch (e) {
    }
    var ParentProjectID = 0;
    var ParentID = 0;
    if (ProjectIDs.length > 0) {
        ParentProjectID = ProjectIDs[0];
    }
    if (PublicProjectIDs.length > 0) {
        ParentID = PublicProjectIDs[0];
    }
    if (ParentProjectID == 0 && ParentID == 0) {
        show_message('请先选择左侧一条资源树', 'info');
        return;
    }
    var iframe = "../InitialSetup/PublicProjectEdit.aspx?ParentID=" + ParentID + "&ParentProjectID=" + ParentProjectID;
    do_open_dialog('新增公共资源', iframe);
}
function editRow(ID) {
    var iframe = "../InitialSetup/PublicProjectEdit.aspx?ID=" + ID;
    do_open_dialog('修改公共资源', iframe);
}
function removeRows() {
    var rows = $("#tt_table").treegrid("getSelections");
    if (rows.length == 0) {
        show_message('请至少选择一个公共资源进行此操作', 'warning');
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    if (IDList.length == 0) {
        show_message('请选择公共资源', 'warning');
        return;
    }
    top.$.messager.confirm("提示", "是否删除选中的公共资源", function (r) {
        if (r) {
            var options = { visit: 'removepublicprojects', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ProjectHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        if (message.haschild) {
                            show_message("请先删除子级树", "info");
                            return;
                        }
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