<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ServiceProcess.aspx.cs" Inherits="Web.CustomerService.ServiceProcess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID, tdHandelType, ffObj, filecount = 0, tdServiceType1, tdServiceType2, tdServiceType3, isComplete = 0, tdResponseRemark, tdChuLiNote;
        $(function () {
            ID = "<%=this.ID%>";
            isComplete = Number("<%=this.isComplete%>");
            ffObj = $("#<%=this.ff.ClientID%>");
            tdServiceType1 = $("#<%=this.tdServiceType1.ClientID%>");
            tdServiceType2 = $("#<%=this.tdServiceType2.ClientID%>");
            tdServiceType3 = $("#<%=this.tdServiceType3.ClientID%>");
            tdHandelType = $("#<%=this.tdHandelType.ClientID%>");
            tdResponseRemark = $("#<%=this.tdResponseRemark.ClientID%>");
            tdChuLiNote = $("#<%=this.tdChuLiNote.ClientID%>");
            addFile();
            loadComboboxParams();
            doChangeType();
            tdHandelType.combobox({
                onSelect: function () {
                    doChangeType();
                }
            })
        });
        function loadComboboxParams() {
            var options = { visit: "getserviceeditparams" };
            $.ajax({
                type: 'POST',
                data: options,
                dataType: 'json',
                url: '../Handler/ServiceHandler.ashx',
                success: function (data) {
                    var serviceType1 = tdServiceType1.combobox('getValue');
                    tdServiceType1.combobox({
                        editable: false,
                        data: data.types,
                        valueField: 'ID',
                        textField: 'Name',
                        onSelect: function (ret) {
                            loadServiceTypes(ret.ID, 2);
                        }
                    });
                    var serviceType1 = tdServiceType1.combobox('getValue');
                    if (serviceType1 != '') {
                        loadServiceTypes(serviceType1, 2);
                    }
                }
            });
        }
        function loadServiceTypes(ParentID, level) {
            var ParentIDList = [];
            if (level == 2) {
                ParentIDList.push(ParentID);
            } else if (level == 3) {
                ParentIDList = tdServiceType2.combobox('getValues');
            }
            var options = { visit: "getservicetypelist", ParentIDList: JSON.stringify(ParentIDList) };
            $.ajax({
                type: 'POST',
                data: options,
                dataType: 'json',
                url: '../Handler/ServiceHandler.ashx',
                success: function (data) {
                    if (level == 2) {
                        tdServiceType2.combobox({
                            multiple: true,
                            editable: false,
                            data: data.list,
                            valueField: 'ID',
                            textField: 'Name',
                            onSelect: function (ret) {
                                loadServiceTypes(ret.ID, 3);
                            },
                            onUnselect: function () {
                                loadServiceTypes(0, 3);
                            }
                        });
                        var serviceType2 = tdServiceType2.combobox('getValues');
                        if (serviceType2 != '') {
                            tdServiceType2.combobox('setValues', serviceType2);
                            loadServiceTypes(serviceType2, 3);
                        }
                    } else if (level == 3) {
                        tdServiceType3.combobox({
                            multiple: true,
                            editable: false,
                            data: data.list,
                            valueField: 'ID',
                            textField: 'Name'
                        });
                        var serviceType3 = tdServiceType3.combobox('getValues');
                        if (serviceType3 != '') {
                            tdServiceType3.combobox('setValues', serviceType3);
                        }
                    }
                }
            });
        }
        function doChangeType() {
            var type = tdHandelType.combobox('getValue');
            if (type == 1) {
                $('.responseCss').show();
                $('.checkCss').hide();
                $('.handelCss').hide();
            } else if (type == 2) {
                $('.responseCss').hide();
                $('.checkCss').show();
                $('.handelCss').hide();
            } if (type == 3) {
                $('.responseCss').hide();
                $('.checkCss').hide();
                $('.handelCss').show();
            }
        }
        function addFile() {
            $("#tdFile").find("a.fileadd").hide();
            $("#tdFile").find("a.fileremove").show();
            filecount++;
            var $html = "<div id=\"tdFile_" + filecount + "\">";
            $html += "<input class=\"easyui-filebox\" name=\"attachfile\" data-options=\"prompt:'请选择文件',buttonText: '选择文件'\" style=\"width: 60%;height:28px;\" />";
            $html += "<a href=\"javascript:void(0)\" onclick=\"addFile()\" class=\"easyui-linkbutton btnlinkbar fileadd\" data-options=\"plain:true,iconCls:'icon-add'\">添加</a>";
            $html += "<a href=\"javascript:void(0)\" onclick=\"deleteFile(" + filecount + ")\" class=\"easyui-linkbutton btnlinkbar fileremove\" style=\"display:none;\" data-options=\"plain:true,iconCls:'icon-remove'\">删除</a>";
            $html += "</div>";
            $("#tdFile").append($html);
            $.parser.parse("#tdFile_" + filecount);
        }
        function deleteFile(id) {
            $("#tdFile_" + id).html("");
        }
        function do_save(type) {
            var isValid = ffObj.form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            if (type == 1) {//办结
                if (tdChuLiNote.textbox('getValue') == '') {
                    show_message("处理情况不能为空", "warning");
                    return;
                }
            }
            var handleType = tdHandelType.combobox('getValue');
            if (handleType == 1 && tdResponseRemark.textbox('getValue') == '') {
                show_message("回复情况不能为空", "warning");
                return;
            }
            if (handleType == 3 && tdChuLiNote.textbox('getValue') == '') {
                show_message("处理情况不能为空", "warning");
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/ServiceHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'saveservicechuli';
                    param.ID = ID;
                    param.isComplete = type == 1;
                    var ServiceType2IDList = tdServiceType2.combobox('getValues');
                    if (ServiceType2IDList.length > 0) {
                        param.ServiceType2ID = JSON.stringify(ServiceType2IDList);
                    }
                    var ServiceType3IDList = tdServiceType3.combobox('getValues');
                    if (ServiceType3IDList.length > 0) {
                        param.ServiceType3ID = JSON.stringify(ServiceType3IDList);
                    }
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        window.updateWin = true;
                        show_message('保存成功', 'success', function () {
                            do_close();
                        });
                        return;
                    }
                    if (dataObj.error) {
                        show_message(dataObj.error, 'warning');
                        return;
                    }
                    show_message("内部异常", "error");
                }
            });
        }
        function do_close() {
            parent.do_close_dialog(function () {
                if (window.updateWin) {
                    parent.reloadTT();
                }
            }, true);
        }
    </script>
    <style type="text/css">
        .panel-body {
            background: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <%if (service.CanDeal)
                { %>
            <a href="javascript:void(0)" onclick="do_save(1)" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">办结并保存</a>
            <%if (this.isComplete == 0)
                { %>
            <a href="javascript:void(0)" onclick="do_save(0)" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">处理并保存</a>
            <%} %>
            <%} %>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <div class="tableContent">
                <div class="tableItem">
                    <label class="title">分类一</label>
                    <input runat="server" type="text" data-options="required:true,editable:false" class="easyui-combobox" id="tdServiceType1" style="height: 28px;" />
                </div>
                <div class="tableItem">
                    <label class="title">分类二</label>
                    <input runat="server" type="text" data-options="required:true,editable:false" class="easyui-combobox" id="tdServiceType2" style="height: 28px;" />
                </div>
                <div class="tableItem">
                    <label class="title">分类三</label>
                    <input runat="server" type="text" data-options="required:true,editable:false" class="easyui-combobox" id="tdServiceType3" style="height: 28px;" />
                </div>
                <div class="tableItem">
                    <label class="title">处理类型</label>
                    <select runat="server" type="text" data-options="required:false,editable:false" class="easyui-combobox" id="tdHandelType" style="height: 28px;">
                        <option value="3">处理</option>
                        <option value="1">回复</option>
                        <option value="2">核查</option>
                    </select>
                </div>
                <div class="tableItem responseCss">
                    <label class="title">回复时间</label>
                    <input runat="server" type="text" class="easyui-datetimebox" id="tdResponseTime" data-options="readonly:true" />
                </div>
                <div class="tableItem responseCss" style="width: 100%;">
                    <label class="title">回复情况</label>
                    <input type="text" runat="server" class="easyui-textbox" id="tdResponseRemark" data-options="multiline:true" style="width: 70%; height: 60px;" />
                </div>
                <div class="tableItem checkCss">
                    <label class="title">核查时间</label>
                    <input type="text" runat="server" class="easyui-datetimebox" id="tdCheckTime" data-options="readonly:true" />
                </div>
                <div class="tableItem checkCss" style="width: 100%;">
                    <label class="title">核查情况</label>
                    <input type="text" runat="server" class="easyui-textbox" id="tdCheckRemark" data-options="multiline:true" style="width: 70%; height: 60px;" />
                </div>
                <div class="tableItem handelCss">
                    <label class="title">处理时间</label>
                    <input type="text" runat="server" class="easyui-datetimebox" id="tdChuLiTime" data-options="readonly:true" />
                </div>
                <div class="tableItem handelCss">
                    <label class="title">维修部位</label>
                    <input type="text" runat="server" class="easyui-textbox" id="tdRepartPartName" />
                </div>
                <div class="tableItem handelCss">
                    <label class="title">处理费用</label>
                    <input type="text" runat="server" class="easyui-textbox" id="tdHandelFee" />
                </div>
                <div class="tableItem handelCss" style="width: 100%;">
                    <label class="title">处理情况</label>
                    <input type="text" runat="server" class="easyui-textbox" id="tdChuLiNote" data-options="multiline:true" style="width: 70%; height: 60px;" />
                </div>
                <div class="tableItem" style="vertical-align: top; width: 100%;">
                    <label class="title">附件</label>
                    <label style="display: inline-block; width: 70%;" class="content" id="tdFile"></label>
                </div>
                <%if (this.isComplete == 1)
                    { %>
                <div class="tableItem">
                    <label class="title">办结时间</label>
                    <input type="text" runat="server" data-options="required:false,readonly:true" class="easyui-datetimebox" id="tdBanJieTime" />
                </div>
                <div class="tableItem" style="width: 100%;">
                    <label class="title">办结情况</label>
                    <input type="text" runat="server" name="td" class="easyui-textbox" id="tdBanJieNote" data-options="multiline:true" style="width: 70%; height: 60px;" />
                </div>
                <%} %>
            </div>
        </div>
    </form>
</asp:Content>
