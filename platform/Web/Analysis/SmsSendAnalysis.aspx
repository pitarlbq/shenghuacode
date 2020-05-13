<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="SmsSendAnalysis.aspx.cs" Inherits="Web.Analysis.SmsSendAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/table-ui.css" rel="stylesheet" />
    <script src="../js/Page/Comm/dateRangeUtil.js?t=<%=base.getToken() %>"></script>
    <script src="../js/Page/Analysis/SmsSendAnalysis.js?t=<%=base.getToken() %>"></script>
    <style>
        .myui-row.myui-row-table {
            width: 100%;
            margin-right: 0px;
            margin-bottom: 20px;
        }

        .myui-row-table [class*=myui-col-] {
            text-align: center;
        }

            .myui-row-table [class*=myui-col-] .count {
                font-size: 16px;
                line-height: 30px;
            }

            .myui-row-table [class*=myui-col-] .title {
                font-size: 13px;
                line-height: 30px;
            }

        .myui-row-search .myui-col-2.labelyear {
            width: 240px;
        }

            .myui-row-search .myui-col-2.labelyear label {
                display: inline-block;
                width: 60px;
                text-align: center;
                border: solid 1px #ddd;
                border-radius: 6px;
                cursor: pointer;
                margin: 0px;
            }

                .myui-row-search .myui-col-2.labelyear label.active {
                    background: #eee;
                }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" fit="true">
        <div data-options="region:'north'" class="hidenorth" style="padding: 0 20px;">
            <div class="myui-row myui-row-table">
                <div class="myui-col-4">
                    <div class="count" id="tdTotalSmsCount">0条</div>
                    <div class="title">累计购买</div>
                </div>
                <div class="myui-col-4">
                    <div class="count" id="tdBillNumber">0条</div>
                    <div class="title">累计发送</div>
                </div>
                <div class="myui-col-4">
                    <div class="count" id="tdRestNumber">0条</div>
                    <div class="title">剩余</div>
                </div>
            </div>
            <div class="myui-row myui-row-search">
                <div class="myui-col-2 labelyear">
                    <label class="active" data-value="1">今日</label>
                    <label data-value="2">本月</label>
                    <label data-value="3">本年</label>
                </div>
                <div class="myui-col-4 col35">
                    <label class="textbox-label">时间</label>
                    <input type="text" class="easyui-datebox" id="tdStartTime" />
                    -
                    <input type="text" class="easyui-datebox" id="tdEndTime" />
                </div>
                <div class="myui-col-1">
                    <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">查询</a>
                </div>
            </div>
        </div>
        <div data-options="region:'center'" class="hidenorth">
            <table id="tt_table">
            </table>
        </div>
    </div>
</asp:Content>
