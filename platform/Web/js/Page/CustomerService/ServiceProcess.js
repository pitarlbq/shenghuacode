var tt_CanLoad = false;
$(function () {
    loadtt();
    tdHandelFeeObj.textbox({
        onChange: function (newValue, oldValue) {
            calculateTotalFee();
        }
    });
    checkCheckboxStatus();
    tdIsRequireProduct.bind('click', function () {
        checkCheckboxStatus();
    });
})
function checkCheckboxStatus() {
    if (tdIsRequireProduct.prop('checked')) {
        $('#divProductPanel').panel({
            closed: false
        });
    }
    else {
        $('#divProductPanel').panel({
            closed: true
        });
    }
}
function getColumnList() {
    var columnslist;
    columnslist = [[
        { field: 'ck', checkbox: true },
        { field: 'ProductName', title: '物品名称', width: 100, editor: { type: 'textbox', options: { disabled: true } } },
        { field: 'ModelNumber', title: '规格型号', width: 100, editor: { type: 'textbox', options: { disabled: true } } },
        { field: 'Unit', title: '单位', width: 100, editor: { type: 'textbox', options: { disabled: true } } },
        { field: 'UnitPrice', title: '单价', width: 100, editor: { type: 'numberbox', options: { precision: 2 } } },
        { field: 'InTotalCount', title: '数量', width: 100, editor: { type: 'numberbox', options: { precision: 0 } } },
        { field: 'InTotalPrice', title: '金额', width: 100, editor: { type: 'numberbox', options: { disabled: true, precision: 2 } } }
    ]];
    return columnslist;
}
function calculateTotalFee() {
    var HandelFee = tdHandelFeeObj.textbox("getValue");
    if (HandelFee == "") {
        HandelFee = 0;
    }
    var rows = $('#tt_table').datagrid('getRows');
    var MaterialFee = 0;
    $.each(rows, function (index, row) {
        MaterialFee += (parseFloat(row.InTotalPrice) > 0 ? parseFloat(row.InTotalPrice) : 0);
    })
    var TotalCost = parseFloat(HandelFee) + parseFloat(MaterialFee);
    tdTotalFeeObj.textbox('setValue', TotalCost);
    return TotalCost;
}
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/CKHandler.ashx',
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
        striped: true,
        onClickRow: onClickTTRow,
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        columns: getColumnList(),
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
        toolbar: '#tt_mm',
        onLoadSuccess: function (data) {
            calculateTotalFee();
        }
    });
    SearchTT();
}
function formatNumber(value, row) {
    return (parseFloat(value) < 0 ? 0 : value);
}
function SearchTT() {
    tt_CanLoad = true;
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadinproductdetailgrid",
        "ServiceID": ID
    });
}
function addRow() {
    var iframe = "../CangKu/AddInOutProduct.aspx";
    do_open_dialog('选择商品', iframe);
}
function choose_product_done() {
    $.each(SelectedList, function (index, item) {
        $('#tt_table').datagrid('appendRow', item);
    })
}
function removeRow() {
    endEditing();
    var rows = $('#tt_table').datagrid('getSelections');
    var indexlist = [];
    $.each(rows, function (index, row) {
        var rowindex = $('#tt_table').datagrid('getRowIndex', row);
        indexlist.push(rowindex);
    })
    $.each(indexlist, function (index, item) {
        $('#tt_table').datagrid('cancelEdit', item).datagrid('deleteRow', item - index);
    })
}
var editIndex;
var SelectedList = [];
function onClickTTRow(index, row) {
    if (editIndex != index) {
        if (endEditing()) {
            $('#tt_table').datagrid('selectRow', index).datagrid('beginEdit', index);
            setProductCombobox(index);
            editIndex = index;
        } else {
            $('#tt_table').datagrid('selectRow', editIndex);
        }
    }
}
function endEditing() {
    if (editIndex == undefined) {
        return true;
    }
    if ($('#tt_table').datagrid('validateRow', editIndex)) {
        $('#tt_table').datagrid('endEdit', editIndex);
        editIndex = undefined;
        return true;
    } else {
        return false;
    }
}
function setProductCombobox(index) {
    var dgUnitPrice = $('#tt_table').datagrid('getEditor', { index: index, field: 'UnitPrice' }).target;
    var dgInTotalCount = $('#tt_table').datagrid('getEditor', { index: index, field: 'InTotalCount' }).target;
    dgUnitPrice.numberbox({
        onChange: function (value) {
            calculateTotalPrice(index);
        }
    })
    dgInTotalCount.numberbox({
        onChange: function (value) {
            calculateTotalPrice(index);
        }
    })
}
function calculateTotalPrice(index) {
    var dgUnitPrice = $('#tt_table').datagrid('getEditor', { index: index, field: 'UnitPrice' }).target;
    var dgInTotalCount = $('#tt_table').datagrid('getEditor', { index: index, field: 'InTotalCount' }).target;
    var dgInTotalPrice = $('#tt_table').datagrid('getEditor', { index: index, field: 'InTotalPrice' }).target;
    var unitprice = dgUnitPrice.numberbox('getValue');
    var intotalcount = dgInTotalCount.numberbox('getValue');
    var intotalprice = 0;
    if (unitprice != '' && intotalcount != '') {
        intotalprice = unitprice * intotalcount;
    }
    dgInTotalPrice.numberbox('setValue', intotalprice);
    if (intotalprice > 0) {
        endEditing();
        calculateTotalFee();
    }
}
function do_save() {
    var isValid = ffObj.form('enableValidation').form('validate');
    if (!isValid) {
        return;
    }
    endEditing();
    var validRowList = [];
    var rows = $('#tt_table').datagrid('getRows');
    if (rows.length > 0) {
        var invalidRowError = '';
        $.each(rows, function (index, row) {
            if (row.ProductID == '') {
                invalidRowError += (index + 1) + ',';
                return false;
            }
            if (row.UnitPrice == '') {
                row.UnitPrice = 0;
                row.InTotalPrice = 0;
            }
            if (row.InTotalCount == '') {
                row.InTotalCount = 0;
                row.InTotalPrice = 0;
            }
            validRowList.push(row);
        })
        if (invalidRowError != '') {
            var errorlines = "第" + invalidRowError.substring(0, invalidRowError.length - 1) + "行数据不完善";
            show_message(errorlines, 'info');
            return;
        }
        if (validRowList.length == 0) {
            show_message('请先完善物品', 'info');
            return;
        }
    }
    MaskUtil.mask('body', '提交中');
    $('#ff').form('submit', {
        url: '../Handler/ServiceHandler.ashx',
        onSubmit: function (param) {
            param.visit = 'savechuli';
            param.ID = ID;
            param.guid = guid;
            param.ProductRows = JSON.stringify(validRowList);
        },
        success: function (data) {
            MaskUtil.unmask();
            var dataObj = eval("(" + data + ")");
            if (dataObj.status) {
                show_message('保存成功', 'success', function () {
                    do_close();
                });
            }
            else {
                show_message('系统错误', 'error');
            }
        }
    });
}
function do_close() {
    parent.do_close_dialog(function () {
    }, true);
}