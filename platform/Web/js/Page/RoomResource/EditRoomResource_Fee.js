var fee_CanLoad = false;
$(function () {
    loadFee();
});
function loadFee() {
    $('#fee_table').datagrid({
        url: '../Handler/FeeCenterHandler.ashx',
        loadMsg: '正在加载',
        border: false,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: true,
        fitColumns: true,
        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: true,
        striped: true,
        //onClickCell: onClickCell,
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        onBeforeLoad: function (data) {
            if (!fee_CanLoad) {
                $('#fee_table').datagrid("loadData", {
                    total: 0,
                    rows: []
                });
            }
            return fee_CanLoad;
        },
        onLoadError: function (data) {
            //alert("有错");
            $('#fee_table').datagrid("loadData", {
                total: 0,
                rows: []
            });
        }
    });
    SearchFee()
}
function SearchFee() {
    fee_CanLoad = true;
    var roomidlist = [];
    roomidlist.push(RoomID);
    $("#fee_table").datagrid("load", {
        "visit": "loadroomresourcefeelist",
        "RoomIDs": JSON.stringify(roomidlist)
    });
}
function formatUnitPrice(value, row) {
    return calculateUnitPrice(value, row.FeeUnitPrice, row.SummaryUnitPrice);
}
function calculateUnitPrice(unitprice, feeunitprice, summaryunitprice) {
    if (unitprice <= 0) {
        if (feeunitprice <= 0) {
            if (summaryunitprice <= 0) {
                return 0;
            }
            return summaryunitprice;
        }
        return feeunitprice;
    }
    return unitprice;
}