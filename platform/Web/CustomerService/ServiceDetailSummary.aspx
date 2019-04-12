<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceDetailSummary.aspx.cs" Inherits="Web.CustomerService.ServiceDetailSummary" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <style>
        body {
            font-family: 'Microsoft YaHei';
        }

        .company {
            font-size: 20px;
            text-align: center;
            margin: 20px 0 0 0;
        }

        .subtitle {
            font-size: 13px;
            text-align: center;
            margin-bottom: 10px;
            font-weight: bold;
            font-size: 15px;
        }

        table.title {
            width: 100%;
            border-spacing: 0;
            border-collapse: collapse;
        }

            table.title td {
                text-align: left;
                padding: 0px 0px 0px 5px;
                font-weight: bold;
                font-size: 15px;
            }

                table.title td span, table.info td span {
                    font-weight: normal;
                }

        table.info {
            width: 100%;
            border-spacing: 0;
            border-collapse: collapse;
            padding: 2px 0;
            border: solid 1px #000;
        }

            table.info td {
                border: solid 1px #000;
                padding: 8px 0 8px 8px;
                font-weight: bold;
                font-size: 14px;
            }

                table.info td:nth-child(2n-1) {
                    font-size: 13px;
                }

        table.info_2 {
            border-top: 0px;
        }

            table.info_2 td {
                border-top: 0px;
            }
    </style>
    <div style="width: 100%; margin: 0 auto;">
        <div class="company"><span id="CompanyName" runat="server"></span></div>
        <div class="subtitle">派工单</div>
        <table class="info">
            <tr>
                <td style="width: 13%;">服务类别</td>
                <td style="width: 20%;"><span id="tdServiceType" runat="server"></span></td>
                <td style="width: 13%;">项目</td>
                <td style="width: 20%;"><span id="tdTaskType" runat="server"></span></td>
                <td style="width: 14%;">客服单号</td>
                <td style="width: 20%;"><span id="tdServiceNumber" runat="server"></span></td>
            </tr>
            <tr>
                <td style="width: 13%;">派工人</td>
                <td style="width: 20%;"><span id="tdAddUserName" runat="server"></span></td>
                <td style="width: 13%;">派工时间</td>
                <td style="width: 20%;"><span id="tdAPPSendTime" runat="server"></span></td>
                <td style="width: 14%;">联系电话</td>
                <td style="width: 20%;"><span id="tdServiceAccpetManPhone" runat="server"></span></td>
            </tr>
            <tr>
                <td style="width: 13%;">报事人</td>
                <td style="width: 20%;"><span id="tdAddCustomerName" runat="server"></span></td>
                <td style="width: 13%;">预约时间</td>
                <td style="width: 20%;"><span id="tdAppointTime" runat="server"></span></td>
                <td style="width: 14%;">联系电话</td>
                <td style="width: 20%;"><span id="tdAddCallPhone" runat="server"></span></td>
            </tr>
            <tr>
                <td style="width: 13%;">反应位置</td>
                <td colspan="5"><span id="tdFullName" runat="server"></span></td>
            </tr>
            <tr>
                <td style="width: 13%;">内容描述</td>
                <td colspan="5"><span id="tdServiceContent" runat="server"></span></td>
            </tr>
            <tr>
                <td style="width: 13%;">接单时间</td>
                <td style="width: 20%;"><span id="tdAcceptTime" runat="server"></span></td>
                <td style="width: 13%;">完成时间</td>
                <td style="width: 20%;"><span id="tdBanJieTime" runat="server"></span></td>
                <td style="width: 14%;">接单人</td>
                <td style="width: 20%;"><span id="tdAcceptMan" runat="server"></span></td>
            </tr>
            <tr>
                <td style="width: 13%;">完成描述</td>
                <td colspan="5"><span id="tdBanJieNote" runat="server"></span></td>
            </tr>
            <tr>
                <td style="width: 13%;">收费情况</td>
                <td style="width: 20%;"><span id="tdChargeStatus" runat="server"></span></td>
                <td style="width: 13%;">收费金额</td>
                <td style="width: 20%;"><span id="tdTotalFee" runat="server"></span></td>
                <td style="width: 14%;">收费人</td>
                <td style="width: 20%;"><span id="tdChargeMan" runat="server"></span></td>
            </tr>
        </table>
        <table class="info info_2">
            <tr>
                <td rowspan="3" style="width: 13%;">客户反馈</td>
                <td style="width: 35%;">是否按时完成</td>
                <td style="width: 15%"></td>
                <td rowspan="3" style="width: 18%; vertical-align:top;">客户签字：</td>
                <td rowspan="3" style="width: 19%;vertical-align:top;">项目签字：</td>
            </tr>
            <tr>
                <td style="width: 35%;">是否满足使用</td>
                <td style="width: 15%"></td>
            </tr>
            <tr>
                <td style="width: 35%;">是否影响观感</td>
                <td style="width: 15%"></td>
            </tr>
        </table>
    </div>
</body>
</html>
