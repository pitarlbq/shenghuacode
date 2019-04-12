function getChargeTypeList() {
    var ChargeTypeList = [];
    ChargeTypeList.push({ ID: 0, Name: "无" });
    ChargeTypeList.push({ ID: 1, Name: "单价*计费面积(月度)" });
    ChargeTypeList.push({ ID: 7, Name: "单价*计费面积(月度进位)" });
    ChargeTypeList.push({ ID: 5, Name: "单价*计费面积(按天)" });
    ChargeTypeList.push({ ID: 3, Name: "单价*计费面积*公摊系数(月度)" });
    ChargeTypeList.push({ ID: 2, Name: "定额(月度)" });
    ChargeTypeList.push({ ID: 4, Name: "定额(年度)" });
    ChargeTypeList.push({ ID: 6, Name: "单价*计费面积/用量(一次性)" });
    return ChargeTypeList;
}
function getRuleList() {
    var RuleList = [];
    RuleList.push({ ID: 1, Name: "预收" });
    RuleList.push({ ID: 2, Name: "实收" });
    RuleList.push({ ID: 3, Name: "临时收取" });
    return RuleList;
}
function getCategoryList() {
    var CategoryList = [];
    CategoryList.push({ ID: 1, Name: "收入" });
    return CategoryList;
}
function getEndTypeList() {
    var EndTypeList = [];
    //EndTypeList.push({ ID: 1, Name: "月末" });
    //EndTypeList.push({ ID: 2, Name: "季末" });
    //EndTypeList.push({ ID: 3, Name: "年末" });
    EndTypeList.push({ ID: 1, Name: "按当前自然日期" });
    EndTypeList.push({ ID: 2, Name: "按计费开始日期" });
    EndTypeList.push({ ID: 3, Name: "手工指定" });
    return EndTypeList;
}
function getEndNumberList() {
    var EndNumberList = [];
    EndNumberList.push({ ID: 1, Name: "舍弃" });
    EndNumberList.push({ ID: 2, Name: "进位" });
    EndNumberList.push({ ID: 3, Name: "四舍五入" });
    return EndNumberList;
}
function getFeeTypeList() {
    var FeeTypeList = [];
    FeeTypeList.push({ ID: 1, Name: "周期费用" });
    //FeeTypeList.push({ ID: 2, Name: "代收费用" });
    //FeeTypeList.push({ ID: 3, Name: "公摊费用" });
    FeeTypeList.push({ ID: 4, Name: "临时费用" });
    //FeeTypeList.push({ ID: 5, Name: "合同费用" });
    //FeeTypeList.push({ ID: 6, Name: "预收费用" });
    //FeeTypeList.push({ ID: 7, Name: "押金费用" });
    FeeTypeList.push({ ID: 8, Name: "违约金" });
    return FeeTypeList;
}
function getChargeFeeTypeList() {
    var FeeTypeList = [];
    FeeTypeList.push({ ID: 0, Name: "无" });
    FeeTypeList.push({ ID: 1, Name: "物业费" });
    return FeeTypeList;
}