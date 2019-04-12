<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="OrderNumberMgr.aspx.cs" Inherits="Web.SysSeting.OrderNumberMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var AddMan = "<%=Web.WebUtil.GetUser(this.Context).RealName%>";
    </script>
    <script src="../js/Page/SysSetting/OrderNumberMgr.js?t=<%=base.getToken() %>"></script>
    <style>
        table.info td {
            padding: 5px;
            text-align: left;
        }

            table.info td.left {
                width: 10%;
                text-align: right;
            }

            table.info td.right {
                width: 20%;
                text-align: left;
            }

        input[type='text'] {
            width: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff">
        <div class="easyui-panel" style="width: 100%; height: 50%; padding: 10px; background: #fafafa; margin: 10px 0;">
            <div class="tableContent">
                <div class="tableItem">
                    <label class="title">单据名称</label>
                    <input type="hidden" id="tdID" />
                    <select class="easyui-combobox" id="tdOrderTypeName" data-options="required:true,editable:false">
                        <option value="customerservice">客服工单</option>
                    </select>
                </div>
                <div class="tableItem">
                    <label class="title">单号位数</label>
                    <input type="text" id="tdOrderNumberCount" class="easyui-numberbox" data-options="required:true" />
                </div>
                <div class="tableItem">
                    <label class="title">单号前缀</label>
                    <input type="text" id="tdPrefix" class="easyui-textbox" />
                </div>
                <div class="tableItem">
                    <label class="title">引用年</label>
                    <select class="easyui-combobox" id="tdUseYear" data-options="required:true,editable:false">
                        <option value="1">是</option>
                        <option value="0">否</option>
                    </select>
                </div>
                <div class="tableItem">
                    <label class="title">引用月</label>
                    <select class="easyui-combobox" id="tdUseMonth" data-options="required:true,editable:false">
                        <option value="1">是</option>
                        <option value="0">否</option>
                    </select>
                </div>
                <div class="tableItem">
                    <label class="title">引用日</label>
                    <select class="easyui-combobox" id="tdUseDay" data-options="required:true,editable:false">
                        <option value="1">是</option>
                        <option value="0">否</option>
                    </select>
                </div>
                <div class="tableItem">
                    <label class="title">按年重置</label>
                    <select class="easyui-combobox" id="tdIsYearReset" data-options="required:true,editable:false">
                        <option value="0">否</option>
                        <option value="1">是</option>
                    </select>
                </div>
                <div class="tableItem">
                    <label class="title">按月重置</label>
                    <select class="easyui-combobox" id="tdIsMonthReset" data-options="required:true,editable:false">
                        <option value="0">否</option>
                        <option value="1">是</option>
                    </select>
                </div>
                <div class="tableItem">
                    <label class="title">按日重置</label>
                    <select class="easyui-combobox" id="tdIsDayReset" data-options="required:true,editable:false">
                        <option value="0">否</option>
                        <option value="1">是</option>
                    </select>
                </div>
                <div class="tableItem">
                    <label class="title">单号预览</label>
                    <input type="text" id="tdOrderPreview" class="easyui-textbox" data-options="readonly:true" />
                </div>
                <div class="tableItem" style="width: 100%;">
                    <label class="title">备注</label>
                    <input type="text" id="tdRemark" class="easyui-textbox" data-options="multiline:true" style="width: 70%; height: 45px;" />
                </div>
            </div>
            <div style="text-align: center;">
                <a href="javascript:void(0)" onclick="savetype()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                <a href="javascript:void(0)" onclick="canceltype()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">撤销</a>
            </div>
        </div>
        <table id="tt_table">
            <thead>
                <tr>
                    <th data-options="field:'ck',checkbox:true"></th>
                    <th data-options="field:'OrderTypeNameDesc'" width="260">单号名称</th>
                    <th data-options="field:'ChargeTypeDesc'" width="260">单据模板</th>
                    <th data-options="field:'OrderPreview'" width="260">单号预览</th>
                    <th data-options="field:'Operation',formatter: formatOper" width="260">分配项目</th>
                </tr>
            </thead>
        </table>
        <div id="tb">
            <a href="javascript:void(0)" onclick="edittype()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
            <a href="javascript:void(0)" onclick="deletetype()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
        </div>
    </form>
</asp:Content>
