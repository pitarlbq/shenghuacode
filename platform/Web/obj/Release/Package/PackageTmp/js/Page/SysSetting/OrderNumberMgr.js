var tt_CanLoad = false;
$(function () {
    loadTT()
})
function loadTT() {
    //加载
    $('#tt_table').datagrid({
        url: '../Handler/SysSettingHandler.ashx',
        loadMsg: '正在加载',
        border: false,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: false,
        fitColumns: true,
        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: true,
        striped: true,
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
    $('#tdOrderTypeName').combobox({
        onSelect: function (ret) {
            checkChargeType();
        }
    })
}
function checkChargeType() {
    if ($('#tdOrderTypeName').combobox('getValue') == 'chargefee') {
        $('.tr_chargetype').show();
    }
    else {
        $('.tr_chargetype').hide();
    }
}
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadordernumberlist"
    });
}
function formatSortOrder(value, row) {
    if (Number(value) < 0) {
        return 0;
    }
    return value;
}
function formatOper(value, row) {
    if (row.OrderTypeName == 'productinnumber' || row.OrderTypeName == 'productoutnumber') {
        return '';
    }
    var str = '<a href="javascript:AssignProject(' + row.ID + ')">分配</a>';
    return str;
}
function AssignProject(ID) {
    var iframe = "../SysSeting/AssignProjectNumber.aspx?OrderNumberID=" + ID;
    do_open_dialog('分配项目', iframe);
}
function savetype() {
    var isValid = $("#ff").form('enableValidation').form('validate');
    if (!isValid) {
        return;
    }
    var id = $("#tdID").val();
    var OrderTypeName = $("#tdOrderTypeName").combobox("getValue");
    var OrderNumberCount = $("#tdOrderNumberCount").numberbox("getValue");
    var UseYear = $("#tdUseYear").combobox("getValue");
    var UseMonth = $("#tdUseMonth").combobox("getValue");
    var UseDay = $("#tdUseDay").combobox("getValue");
    var Prefix = $("#tdPrefix").textbox("getValue");
    var OrderPreview = $("#tdOrderPreview").textbox("getValue");
    var Remark = $("#tdRemark").textbox("getValue");
    var ChargeType = 0;
    var IsYearReset = $("#tdIsYearReset").combobox("getValue");
    var IsMonthReset = $("#tdIsMonthReset").combobox("getValue");
    var IsDayReset = $("#tdIsDayReset").combobox("getValue");
    var options = { visit: 'saveordernumber', id: id, OrderTypeName: OrderTypeName, OrderNumberCount: OrderNumberCount, UseYear: UseYear, UseMonth: UseMonth, UseDay: UseDay, Prefix: Prefix, OrderPreview: OrderPreview, Remark: Remark, AddMan: AddMan, ChargeType: ChargeType, IsYearReset: IsYearReset, IsMonthReset: IsMonthReset, IsDayReset: IsDayReset };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/SysSettingHandler.ashx',
        data: options,
        success: function (message) {
            if (message.status) {
                show_message('保存成功', 'success', function () {
                    $("#tt_table").datagrid("reload");
                });
                return;
            }
            show_message('系统错误', 'error');
        }
    });
}
function canceltype() {
    $("#tdID").val("");
    $("#tdOrderTypeName").combobox("setValue", "");
    $("#tdOrderNumberCount").numberbox("setValue", "");
    $("#tdUseYear").combobox("setValue", 1);
    $("#tdUseMonth").combobox("setValue", 1);
    $("#tdUseDay").combobox("setValue", 1);
    $("#tdPrefix").textbox("setValue", "");
    $("#tdOrderPreview").textbox("setValue", "");
    $("#tdRemark").textbox("setValue", "");
    $("#tdChargeType").combobox("setValue", 1);
    $("#tdIsYearReset").combobox("setValue", 0);
    $("#tdIsMonthReset").combobox("setValue", 0);
    $("#tdIsDayReset").combobox("setValue", 0);
    checkChargeType();
}
function edittype() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length != 1) {
        show_message("请选择一行进行此操作", "info");
        return;
    }
    $("#tdID").val(rows[0].ID);
    $("#tdOrderTypeName").combobox("setValue", rows[0].OrderTypeName);
    $("#tdOrderNumberCount").numberbox("setValue", rows[0].OrderNumberCount);
    $("#tdUseYear").combobox("setValue", rows[0].UseYear ? 1 : 0);
    $("#tdUseMonth").combobox("setValue", rows[0].UseMonth ? 1 : 0);
    $("#tdUseDay").combobox("setValue", rows[0].UseDay ? 1 : 0);
    $("#tdPrefix").textbox("setValue", rows[0].OrderPrefix);
    $("#tdOrderPreview").textbox("setValue", rows[0].OrderPreview);
    $("#tdRemark").textbox("setValue", rows[0].Remark);
    $("#tdIsYearReset").combobox("setValue", rows[0].IsYearReset ? 1 : 0);
    $("#tdIsMonthReset").combobox("setValue", rows[0].IsMonthReset ? 1 : 0);
    $("#tdIsDayReset").combobox("setValue", rows[0].IsDayReset ? 1 : 0);
    var ChargeType = rows[0].ChargeType < 0 ? 1 : rows[0].ChargeType;
    $("#tdChargeType").combobox("setValue", ChargeType);
    checkChargeType();
}
function deletetype() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一行进行此操作", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "确认删除?", function (r) {
        if (r) {
            var options = { visit: 'deleteordernumber', ids: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/SysSettingHandler.ashx',
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
