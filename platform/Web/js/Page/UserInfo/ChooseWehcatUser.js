var tt_CanLoad = false, isUpdate = false;
$(function () {
    setTimeout(function () {
        loadtt();
    }, 500);
});
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/WechatHandler.ashx',
        loadMsg: '正在加载',
        border: true,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: true,
        fitColumns: true,
        singleSelect: true,
        selectOnCheck: true,
        checkOnSelect: true,
        striped: true,
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
        columns: [[
        { field: 'ck', checkbox: true },
        { field: 'NickName', title: '昵称', width: 100 },
        { field: 'City', formatter: formatCity, title: '城市', width: 100 },
        { field: 'SexDesc', title: '性别', width: 100 },
        { field: 'SubscribeTime', formatter: formatDateTime, title: '关注时间', width: 150 },
        { field: 'UnSubscribeDesc', title: '关注状态', width: 100 }
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "getwechatuserlist",
        "keywords": keywords,
        "excludeproject": true,
    });
}
function formatFullName(value, row) {
    return row.FullName.replace(/-/g, '') + row.Name;
}
function formatCity(value, row) {
    var result = '';
    if (row.Province != '') {
        result += row.Province + " ";
    }
    if (row.City != '') {
        result += row.City;
    }
    return result;
}
function doChoose() {
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message('请选择一个微信用户', 'info');
        return;
    }
    parent.hdOpenID.val(rows[0].OpenId);
    parent.tdOpenID.textbox('setValue', rows[0].NickName);
    parent.$('#winchoose').window('close');
}
