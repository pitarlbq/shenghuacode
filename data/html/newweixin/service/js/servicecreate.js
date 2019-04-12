var app;
$(function() {
    var ns = window.Foresight.Util;
    var dialog = new auiDialog();
    var toast = new auiToast();
    app = new Vue({
        el: '#app',
        data: {
            form: {
                ProjectName: '',
                TypeName: '',
                AddCustomerName: '',
                FullName: '',
                PhoneNo: '',
                AppointTime: '',
                Content: '',
                FilePathList: [],
                CotentHolder: '请填写报事报修内容',
                uploadfiles: [],
                callNumber: '4001560006'
            },
            projectForm: {
                showProject: false,
                CompanyName: '',
                ProjectName: '',
                CompanyID: 0,
                ProjectID: 0,
                list: []
            },
            typeForm: {
                showType: false,
                TypeName1: '',
                TypeName2: '',
                TypeName3: '',
                TypeID1: 0,
                TypeID2: 0,
                TypeID3: 0,
                list: [],
                currentlevel: 1
            },
            imglist: [],
            mediaIds: [],
            showCamera: true,
            bannersrc: '../image/banner_3.jpg',
        },
        methods: {
            get_project_data: function() {
                var that = this;
                var options = {};
                options.action = 'getprojecttreedata';
                options.CompanyID = that.projectForm.CompanyID;
                toast.loading({
                    title: "加载中",
                    duration: 2000
                }, function(ret) {});
                ns.post(options, function(succeed, data, err) {
                    toast.hide();
                    if (succeed) {
                        that.projectForm.list = data.list;
                    } else if (err) {
                        ns.toast(err);
                    }
                });
            },
            get_type_data: function(parentid) {
                var that = this;
                var options = {};
                options.action = 'gettypetreedata';
                options.ParentID = parentid;
                toast.loading({
                    title: "加载中",
                    duration: 2000
                }, function(ret) {});
                ns.post(options, function(succeed, data, err) {
                    toast.hide();
                    if (succeed) {
                        that.typeForm.list = data.list;
                    } else if (err) {
                        ns.toast(err);
                    }
                });
            },
            do_format_time: function() {
                var that = this;
                that.form.AppointTime = that.form.AppointTime.replace('T', ' ');
            },
            delete_img: function(mediaid) {
                var that = this;
                $.each(that.imglist, function(index, item) {
                    if (item.media_id == mediaid) {
                        that.imglist.splice(index, 1);
                    }
                });
            },
            do_save: function() {
                var that = this;
                if (that.projectForm.ProjectID <= 0) {
                    ns.toast('请选择项目');
                    return;
                }
                // if (that.typeForm.TypeID1 <= 0) {
                //     ns.toast('请选择类型');
                //     return;
                // }
                // if (that.form.FullName == '') {
                //     ns.toast('请填写详细地址');
                //     return;
                // }
                if (that.form.AddCustomerName == '') {
                    ns.toast('请输入您的姓名');
                    return;
                }
                if (that.form.PhoneNo == '') {
                    ns.toast('请输入您的电话');
                    return;
                }
                // if (that.form.AppointTime == '') {
                //     ns.toast('请选择预约时间');
                //     return;
                // }
                if (that.form.Content == '') {
                    ns.toast('请描述一下你的问题');
                    return;
                }
                if (!toast.IsToasting) {
                    toast.loading({
                        title: "提交中",
                        duration: 2000
                    }, function(ret) {});
                }
                toast.IsToasting = true;
                if (that.imglist.length) {
                    doUpload();
                    return;
                }
                var options = {};
                options.action = 'savewxservice';
                options.AddCustomerName = that.form.AddCustomerName;
                options.Content = that.form.Content;
                options.AppointTime = that.form.AppointTime;
                options.PhoneNo = that.form.PhoneNo;
                options.FullName = that.form.FullName;
                options.IsSuggestion = IsSuggestion;
                options.ProjectID = that.projectForm.ProjectID;
                options.TypeID1 = that.typeForm.TypeID1;
                options.TypeID2 = that.typeForm.TypeID2;
                options.TypeID3 = that.typeForm.TypeID3;
                options.ProjectName = that.form.ProjectName
                options.FilePaths = JSON.stringify(that.form.FilePathList);
                ns.post(options, function(succeed, data, err) {
                    toast.hide();
                    toast.IsToasting = false;
                    if (succeed) {
                        var msg = '提交成功,我们会尽快处理您的请求';
                        if (IsSuggestion) {
                            msg = '提交成功';
                        }
                        ns.alert({
                            title: "提示",
                            msg: msg,
                            buttons: ['确定']
                        }, function() {
                            that.reset_form();
                        });
                    } else if (err) {
                        ns.toast(err);
                    }
                });
            },
            reset_form: function() {
                var that = this;
                that.form = {
                    ProjectName: '',
                    TypeName: '',
                    AddCustomerName: '',
                    FullName: '',
                    PhoneNo: '',
                    AppointTime: '',
                    Content: '',
                    FilePathList: [],
                    CotentHolder: '请填写报事报修内容',
                    uploadfiles: []
                };
            },
            do_call: function() {
                var that = this;
                ns.openWin('tel:' + that.form.callNumber);
            },
            init_min_time: function() {
                (function($) {
                    $.init();
                    var btns = $('.time_btn');
                    btns.each(function(i, btn) {
                        btn.addEventListener('tap', function() {
                            var _self = this;
                            if (_self.picker) {
                                _self.picker.show(function(rs) {
                                    app.form.AppointTime = rs.text;
                                    _self.picker.dispose();
                                    _self.picker = null;
                                });
                            } else {
                                var optionsJson = this.getAttribute('data-options') || '{}';
                                var options = JSON.parse(optionsJson);
                                _self.picker = new $.DtPicker(options);
                                _self.picker.show(function(rs) {
                                    app.form.AppointTime = rs.text;
                                    _self.picker.dispose();
                                    _self.picker = null;
                                });
                            }

                        }, false);
                    });
                })(mui);

            },
            hideProject: function() {
                var that = this;
                that.projectForm.showProject = false;
                setTimeout(function() {
                    that.init_min_time();
                    imageUploadInit();
                }, 500);
            },
            hideType: function() {
                var that = this;
                that.typeForm.showType = false;
                setTimeout(function() {
                    that.init_min_time();
                    imageUploadInit();
                }, 500);
            },
            do_select_project: function() {
                var that = this;
                that.projectForm.showProject = true;
                that.projectForm.ProjectID = 0;
                that.projectForm.ProjectName = '';
                that.projectForm.CompanyID = '';
                that.projectForm.CompanyName = '';
                that.get_project_data();
            },
            go_next_project: function(item) {
                var that = this;
                if (item.type == 'company') {
                    that.projectForm.CompanyID = item.id;
                    that.projectForm.CompanyName = item.name;
                    that.form.ProjectName = that.projectForm.CompanyName;
                    that.get_project_data();
                } else {
                    that.projectForm.ProjectID = item.id;
                    that.projectForm.ProjectName = item.name;
                    that.form.ProjectName += '-' + that.projectForm.ProjectName;
                    that.hideProject();
                }
            },
            go_back_project: function() {
                var that = this;
                that.projectForm.ProjectID = 0;
                that.projectForm.ProjectName = '';
                that.projectForm.CompanyID = 0;
                that.projectForm.CompanyName = '';
                that.form.ProjectName = '';
                that.hideProject();
            },
            do_select_type: function() {
                var that = this;
                that.typeForm.showType = true;
                that.typeForm.TypeID1 = 0;
                that.typeForm.TypeID2 = 0;
                that.typeForm.TypeID3 = 0;
                that.typeForm.TypeName1 = '';
                that.typeForm.TypeName2 = '';
                that.typeForm.TypeName3 = '';
                that.get_type_data(1);
                that.currentlevel = 1;
            },
            go_next_type: function(item, level) {
                var that = this;
                if (that.currentlevel == 1) {
                    that.typeForm.TypeID1 = item.id;
                    that.typeForm.TypeName1 = item.name;
                    that.form.TypeName = that.typeForm.TypeName1;
                    if (!item.hasparent) {
                        that.hideType();
                        return;
                    }
                    that.get_type_data(item.id);
                    that.currentlevel++;
                } else if (that.currentlevel == 2) {
                    that.typeForm.TypeID2 = item.id;
                    that.typeForm.TypeName2 = item.name;
                    that.form.TypeName += '-' + that.typeForm.TypeName2;
                    if (!item.hasparent) {
                        that.hideType();
                        return;
                    }
                    that.get_type_data(item.id);
                    that.currentlevel++;
                } else {
                    that.typeForm.TypeID3 = item.id;
                    that.typeForm.TypeName3 = item.name;
                    that.form.TypeName += '-' + that.typeForm.TypeName3;
                    that.hideType();
                    that.currentlevel = 1;
                }
            },
            go_back_type: function() {
                var that = this;
                that.typeForm.TypeID3 = 0;
                that.typeForm.TypeName3 = '';
                if (that.currentlevel == 3) {
                    that.currentlevel--;
                    that.typeForm.TypeID2 = 0;
                    that.typeForm.TypeName2 = '';
                    that.form.TypeName = that.typeForm.TypeName1;
                    that.get_type_data(1);
                }
                if (that.currentlevel == 2) {
                    that.currentlevel--;
                    that.typeForm.TypeID1 = 0;
                    that.typeForm.TypeName1 = '';
                    that.form.TypeName = '';
                    that.get_type_data(1);
                } else {
                    that.currentlevel = 1;
                    that.hideType();
                }
            },
            delete_img: function(itemindex) {
                var that = this;
                $.each(that.imglist, function(index, item) {
                    if (item.index == itemindex) {
                        that.imglist.splice(index, 1);
                        that.form.uploadfiles.splice(index, 1);
                    }
                });
            },
        }
    });
    if (IsSuggestion) {
        app.form.CotentHolder = '请填写投诉建议内容'
    }
    app.init_min_time();
    imageUploadInit();
});

function imageUploadInit() {
    var uploadBtn = document.querySelector('#upload');
    // var previewImgList = document.querySelector('.preview_img_list');
    // var submitBtn = document.querySelector('.submit');
    var imageIndex = 0;
    uploadBtn.addEventListener('change', function() {
        var imgLen = this.files.length;
        var liLen = app.imglist.length;
        var ImgLen = imgLen + liLen;
        if (ImgLen > 9) {
            alert("上传最大数量不能大于9");
            return false;
        }

        for (var i = 0; i < imgLen; i++) {
            imageIndex++;
            var file = this.files[i];
            var imgType = /^image\//;

            if (!imgType.test(file.type)) {
                continue;
            }
            var reader = new FileReader();
            reader.onload = (function() {
                return function(e) {
                    var objectUrl = window.URL.createObjectURL(file);
                    app.imglist.push({ index: imageIndex, src: e.target.result, objectUrl: objectUrl });
                };
            })();
            reader.readAsDataURL(file);
            app.form.uploadfiles.push(file);
        }

    }, false);
}
//XmlHttpRequest对象    
function createXmlHttpRequest() {
    if (window.ActiveXObject) { //如果是IE浏览器    
        return new ActiveXObject("Microsoft.XMLHTTP");
    } else if (window.XMLHttpRequest) { //非IE浏览器    
        return new XMLHttpRequest();
    }
}

function doUpload() {
    var url = CONFIG.apiurl + '?action=uploadimage';
    var form = document.querySelector('form');
    var fd = new FormData(form);
    for (var i = 0; i < app.form.uploadfiles.length; i++) {
        fd.append('file[]', app.form.uploadfiles[i]);
    }
    //1.创建XMLHttpRequest组建    
    xmlHttpRequest = createXmlHttpRequest();

    //2.设置回调函数    
    xmlHttpRequest.onreadystatechange = requestCallBackFun;

    //3.初始化XMLHttpRequest组建    
    xmlHttpRequest.open("POST", url, true);
    //4.发送请求    
    xmlHttpRequest.send(fd);
}


//回调函数    
function requestCallBackFun() {
    if (xmlHttpRequest.readyState == 4 && xmlHttpRequest.status == 200) {
        var b = xmlHttpRequest.responseText;
        var data = eval('(' + b + ')');
        if (data.status) {
            app.imglist = [];
            app.form.FilePathList = data.list;
            app.do_save();
            return;
        }
        toast.hide();
        toast.IsToasting = false;
    }
}