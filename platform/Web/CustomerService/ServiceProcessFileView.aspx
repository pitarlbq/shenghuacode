<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ServiceProcessFileView.aspx.cs" Inherits="Web.CustomerService.ServiceProcessFileView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID, hdImgItems;
        $(function () {
            ID = "<%=this.ID%>";
            hdImgItems = $('#<%=this.hdImgItems.ClientID%>');
            if (hdImgItems.val() == '') {
                return;
            }
            var imgList = eval('(' + hdImgItems.val() + ')');
            var html = '';
            $.each(imgList, function (index, item) {
                html += '<a target="_blank" href="' + item + '"><img src="' + item + '"/></a>';
            })
            $('.imgBox').append(html);
        });
        function do_close() {
            parent.do_close_dialog(function () {
            }, true);
        }
    </script>
    <style type="text/css">
        .panel-body {
            background: #f0f0f0;
        }

        .imgBox a {
            display: inline-block;
            width: 200px;
            height: 300px;
            margin: 10px;
        }

            .imgBox a img {
                width: 100%;
                height: 100%;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <asp:HiddenField runat="server" ID="hdImgItems" />
            <div class="imgBox"></div>
        </div>
    </form>
</asp:Content>
