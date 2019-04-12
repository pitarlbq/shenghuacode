<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditCustomerServiceTaskCombobox.aspx.cs" Inherits="Web.SysSeting.EditCustomerServiceTaskCombobox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .add, .exist {
            width: 100%;
            margin: 0 auto;
            margin-top: 10px;
            border-collapse: collapse;
            border-spacing: 0px;
            border: solid 1px #ccc;
        }

        .field {
            padding: 3px 5px;
            text-align: left;
            border: solid 1px #ccc;
            width: 33%;
            display: inline-table;
        }

        .exist_field {
            padding: 3px 5px;
            text-align: left;
            border: solid 1px #ccc;
            width: 50%;
            display: inline-table;
        }

            .exist_field .exist_field_label {
                text-align: right;
                width: 30%;
                display: inline-table;
            }

            .exist_field input {
                text-align: left;
                width: 70%;
                display: inline-table;
                padding-left: 10px;
                border: 0;
                border-left: 1px #ccc solid;
            }

        input[type=text] {
            text-align: left;
            width: 70%;
            display: inline-table;
            padding-left: 10px;
            border: 0;
            border-left: 1px #ccc solid;
            border-radius: 5px !important;
            line-height: 25px;
            height: 25px;
        }

        .add .title, .exist .title {
            text-align: center;
            padding: 5px 0;
            color: #000;
            background-color: #ccc;
        }
    </style>
    <script src="../js/Page/SysSetting/EditCustomerServiceTaskCombobox.js?t=<%=base.getToken() %>"></script>
    <script>
        function do_close() {
            parent.do_close_dialog(function () {
                parent.addtask_done();
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="addservicetask()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
            <a href="javascript:void(0)" onclick="savecolumns('servicetask')" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <div class="table_title">
                任务标签
            </div>
            <div class="add" id="servicetask_field">
            </div>
        </div>
    </form>
</asp:Content>
