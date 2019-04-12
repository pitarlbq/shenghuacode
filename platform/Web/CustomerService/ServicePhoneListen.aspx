<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ServicePhoneListen.aspx.cs" Inherits="Web.CustomerService.ServicePhoneListen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .panel-body {
            background: #f0f0f0;
        }

        .callCss {
            border: solid 1px #ddd;
            border-radius: 5px;
            padding: 2px 10px;
            display: inline-block;
            cursor: pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <div class="table_container">
            <div class="tableContent">
                <div class="tableItem" style="width: 100%;">
                    <audio controls="controls" id="btnRecord">
                        <source src="<%=this.FullFilePath%>" />
                    </audio>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
