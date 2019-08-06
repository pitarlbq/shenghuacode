var tt_CanLoad = false, filecount = 0, ProjectID = 0;
var ChosenStaffUserIDs = '', ChosenStaffUserName = '';
var ChosenDepartmentID = 0, ChosenDepartmentName;
var ChosenServiceTypeID = 0, ChosenServiceTypeName;
$(function () {
    if (op != 'view' && op != 'phonecall') {
        addFile();
    }
    loadComboboxParams(true, true);
    if (ID > 0) {
        loadattachs();
    }
    if (ProjectID > 0) {
        var options = { visit: "getroominfo", ProjectID: ProjectID, OnlyUserStaff: true };
        $.ajax({
            type: 'POST',
            data: options,
            dataType: 'json',
            url: '../Handler/ServiceHandler.ashx',
            success: function (data) {
                tdBelongTeamName.combobox({
                    editable: false,
                    textField: 'Name',
                    valueField: 'ID',
                    data: data.departmentList
                })
                tdAcceptManInput.combobox({
                    editable: false,
                    textField: 'Name',
                    valueField: 'ID',
                    data: data.userStaffList,
                    onSelect: function (ret) {
                        tdBelongTeamName.combobox('setValue', ret.DepartmentID);
                    }
                })
            }
        });
    }
})
function loadattachs() {
    var options = { visit: 'loadserviceattachs', ID: ID };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ServiceHandler.ashx',
        data: options,
        success: function (data) {
            var $html = '';
            $("#trExistFiles").html($html);
            if (data.length > 0) {
                $("#trExistFiles").show();
                $html += '<label class="title">已上传附件</label>';
                $.each(data, function (index, item) {
                    $html += '<div class="existImgBox"><a target="_blank" href="' + item.AttachedFilePath + '"><img style="max-width:100px;" src="' + item.AttachedFilePath + '" /></a><div style="text-align:center;"><a href="' + item.AttachedFilePath + '" target="_blank" >下载</a>&nbsp;&nbsp;&nbsp;&nbsp;';
                    $html += '<a href="#" onclick="deleteAttach(' + item.ID + ')">删除</a></div></div>';
                })
            }
            $("#trExistFiles").append($html);
        }
    });
}
function deleteAttach(AttachID) {
    top.$.messager.confirm("提示", "是否删除选已上传的文件?", function (r) {
        if (r) {
            var options = { visit: 'deletefile', ID: AttachID };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ServiceHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('删除成功', 'success', function () {
                            loadattachs();
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
function formatNumber(value, row) {
    return (parseFloat(value) < 0 ? 0 : value);
}
function pageLoad(RoomID, isNotRoom) {
    ProjectID = RoomID;
    tdFullName.textbox("setValue", "");
    tdProjectName.html("");
    tdServiceNumber.textbox("setValue", "");
    OrderNumberID = 0;
    var ServiceTypeID = tdServiceType1.combobox('getValue');
    var options = { visit: "getroominfo", ProjectID: ProjectID, IsNotRoom: isNotRoom, ServiceTypeID: ServiceTypeID };
    $.ajax({
        type: 'POST',
        data: options,
        dataType: 'json',
        url: '../Handler/ServiceHandler.ashx',
        success: function (data) {
            if (!data.status) {
                return;
            }
            ProjectID = data.ProjectID;
            tdProjectName.html(data.ProjectName);
            tdServiceNumber.textbox("setValue", data.CustomerNumber);
            OrderNumberID = data.OrderNumberID;
            tdAddCustomerName.textbox('setValue', data.RelationName);
            tdFullName.textbox("setValue", data.FullName);
            var existPhoneNumber = tdAddCallPhone.textbox('getValue');
            tdAddCallPhone.textbox('setValue', data.RelationPhoneNumber);
            if (!isNotRoom) {
                tdServiceArea.combobox("setValue", "个人区域");
            }
            else {
                tdServiceArea.combobox("setValue", "公共区域");
            }
            tdBelongTeamName.combobox({
                editable: false,
                textField: 'Name',
                valueField: 'ID',
                data: data.departmentList
            })
            tdAcceptManInput.combobox({
                editable: false,
                textField: 'Name',
                valueField: 'ID',
                data: data.userStaffList,
                onSelect: function (ret) {
                    tdBelongTeamName.combobox('setValue', ret.DepartmentID);
                }
            })
            if (data.userStaffList.length > 0) {
                tdAcceptManInput.combobox('setValue', data.userStaffList[0].ID);
                tdBelongTeamName.combobox('setValue', data.userStaffList[0].DepartmentID);
            }
        }
    });
}
function savedata() {
    var isValid = ffObj.form('enableValidation').form('validate');
    if (!isValid) {
        return;
    }
    endEditing();
    IsRequireCost = 0;
    IsSendAPP = 0;
    if (tdIsSendAPP.prop('checked')) {
        IsSendAPP = 1;
    }
    if (!ProjectID) {
        show_message('请选择项目', 'warning');
        return;
    }
    MaskUtil.mask('body', '提交中');
    $('#ff').form('submit', {
        url: '../Handler/ServiceHandler.ashx',
        onSubmit: function (param) {
            param.visit = 'savecustomerservice';
            param.ProjectID = ProjectID;
            param.ID = ID;
            param.IsRequireCost = IsRequireCost;
            param.IsSendAPP = IsSendAPP;
            param.guid = guid;
            param.OrderNumberID = OrderNumberID;
            var ServiceType2IDList = tdServiceType2.combobox('getValues');
            if (ServiceType2IDList.length > 0) {
                param.ServiceType2ID = JSON.stringify(ServiceType2IDList);
            }
            var ServiceType3IDList = tdServiceType3.combobox('getValues');
            if (ServiceType3IDList.length > 0) {
                param.ServiceType3ID = JSON.stringify(ServiceType3IDList);
            }
            if (op == 'phonecall') {
                param.RecordName = top.RecordName;
            }
            param.ServiceType = ServiceType;
            param.UserID = top.UserID
        },
        success: function (data) {
            MaskUtil.unmask();
            var dataObj = eval("(" + data + ")");
            if (dataObj.status) {
                top.recordPath = '';
                if (dataObj.ID > 0) {
                    if (op != 'phonecall') {
                        ID = dataObj.ID;
                        if (status == 100) {
                            printData(dataObj.ID);
                            return;
                        }
                        window.update = true;
                        show_message('保存成功', 'success', function () {
                            closeWin();
                        });
                    } else {
                        top.ComingPhoneNumber = '';
                        show_message('保存成功', 'success');
                    }
                    return;
                }
                show_message("任务记录不存在", "info");
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
function loadComboboxParams(load_TaskType, loadServiceType1) {
    var options = { visit: "getserviceeditparams" };
    $.ajax({
        type: 'POST',
        data: options,
        dataType: 'json',
        url: '../Handler/ServiceHandler.ashx',
        success: function (data) {
            if (load_TaskType) {
                var tasktype = tdTaskType.combobox('getValue');
                tdTaskType.combobox({
                    editable: false,
                    data: data.tasks,
                    valueField: 'ID',
                    textField: 'Name'
                });
                if (tasktype != '') {
                    tdTaskType.combobox('setValue', tasktype);
                }
            }
            if (loadServiceType1) {
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
                if (serviceType1 != '') {
                    tdServiceType1.combobox('setValue', serviceType1);
                    loadServiceTypes(serviceType1, 2, true);
                }
            }
        }
    });
}
function loadServiceTypes(ParentID, level, setDefault) {
    var ParentIDList = [];
    if (level == 2) {
        ParentIDList.push(ParentID);
    } else if (level == 3) {
        ParentIDList = tdServiceType2.combobox('getValues');
    }
    var options = { visit: "getservicetypelist", ParentIDList: JSON.stringify(ParentIDList), level: level, ProjectID: ProjectID };
    $.ajax({
        type: 'POST',
        data: options,
        dataType: 'json',
        url: '../Handler/ServiceHandler.ashx',
        success: function (data) {
            if (level == 2) {
                tdBelongTeamName.combobox({
                    editable: false,
                    textField: 'Name',
                    valueField: 'ID',
                    data: data.departmentList
                })
                tdAcceptManInput.combobox({
                    editable: false,
                    textField: 'Name',
                    valueField: 'ID',
                    data: data.userStaffList,
                    onSelect: function (ret) {
                        tdBelongTeamName.combobox('setValue', ret.DepartmentID);
                    }
                })
                if (data.userStaffList.length > 0) {
                    tdAcceptManInput.combobox('setValue', data.userStaffList[0].ID);
                    tdBelongTeamName.combobox('setValue', data.userStaffList[0].DepartmentID);
                }
            }
            if (level == 2) {
                tdServiceType2.combobox({
                    multiple: true,
                    editable: false,
                    data: data.list,
                    valueField: 'ID',
                    textField: 'Name',
                    onSelect: function (ret) {
                        tdServiceType3.combobox('setValues', []);
                        loadServiceTypes(0, 3);
                    },
                    onUnselect: function () {
                        tdServiceType3.combobox('setValues', []);
                        loadServiceTypes(0, 3);
                    }
                });
                var serviceType2 = tdServiceType2.combobox('getValues');
                if (serviceType2 && setDefault) {
                    tdServiceType2.combobox('setValues', serviceType2);
                    loadServiceTypes(0, 3, setDefault);
                } else {
                    tdServiceType2.combobox('setValues', []);
                    loadServiceTypes(0, 3, setDefault);
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
                if (serviceType3 && setDefault) {
                    tdServiceType3.combobox('setValues', serviceType3);
                } else {
                    tdServiceType3.combobox('setValues', []);
                }
            }
        }
    });
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
function closeWin() {
    top.isAddService = false;
    try {
        parent.do_close_dialog(function () {
            if (window.update) {
                parent.reloadTT();
            }
        }, true);
    } catch (e) {
    }
    try {
        parent.parent.do_close_dialog(function () {
        }, true);
    } catch (e) {
    }
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
function sendjpushapp() {
    var options = { visit: "resendjpush", ID: ID };
    $.ajax({
        type: 'POST',
        data: options,
        dataType: 'html',
        url: '../Handler/ServiceHandler.ashx',
        success: function (data) {
            show_message('推送成功', 'info');
        }
    });
}
function addTask() {
    var iframe = "../SysSeting/EditCustomerServiceTaskCombobox.aspx";
    do_open_dialog('任务标签管理', iframe);
}
function addtask_done() {
    loadComboboxParams(true, false);
}
function doprint() {
    savedata(100)
}
function printData(ID) {
    if (ID == 0) {
        return;
    }
    try {
        var LODOP = getLodop();
        if ((LODOP != null) && (typeof (LODOP.VERSION) != "undefined")) {
            $("#myframe").attr("src", "../CustomerService/ServiceDetailSummary.aspx?ID=" + ID);
            setTimeout(function () {
                LODOP.PRINT_INIT("打印派工单");
                LODOP.SET_PRINT_PAGESIZE(0, 0, 0, "");
                var strHtml = document.getElementsByTagName("iframe")[0].contentWindow.document.documentElement.innerHTML;
                //alert(strHtml);
                LODOP.ADD_PRINT_HTM(0, '5%', "90%", "100%", strHtml);
                LODOP.PREVIEW();
                //LODOP.PRINT();
            }, 1000);
        }
        else {
            alert("Error:该浏览器不支持打印插件!");
        }
    } catch (err) {
        alert("Error:本机未安装或需要升级!");
    }
}
