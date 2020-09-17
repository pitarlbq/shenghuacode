
var tt_CanLoad = false;
$(function () {
    setTimeout(function () {
        loadtt();
    }, 500);
});
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/ServiceHandler.ashx',
        loadMsg: '正在加载',
        rownumbers: true,
        fit: true,
        fitColumns: true,
        onDblClickRow: onDblClickRowTT,
        columns: [[
            { field: 'ProjectName', title: '项目名称', width: 100 },
            { field: 'DelayHour', title: '延期时间(小时)', width: 100 },
            { field: 'Operation', formatter: formatOperation, title: '操作', width: 100 },
        ]],
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
        }
    });
    SearchTT();
}
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadprojectservicetypegrid",
        "Keywords": $('#tdKeyword').searchbox('getValue')
    });
}
function formatOperation(index, row) {
    return '<a href="#" onclick="editRow(' + row.ProjectID + ')" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:\'icon-edit\'">编辑</a>';
}
function onDblClickRowTT(index, row) {
    editRow(row.ProjectID)
}
function editRow(ID) {
    var iframe = "../CustomerService/ProjectServiceTypeEdit.aspx?ID=" + ID;
    do_open_dialog('修改项目超时延期', iframe);
}