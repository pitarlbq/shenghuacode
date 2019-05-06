$(document).ready(function () {
    TV_Initialize();
    getEvent(T_GetEvent);
    //set_check_data_url('http://192.168.0.4/k.html');//设置注册码URL函数
    openMic();
});
$(window).unload(function () {
    TV_Disable();
});
//离开页面
$(window).bind('beforeunload', function () {
    TV_Disable();
});

function AppendStatus(szStatus) {
    console.log(szStatus);
}
function AppendStatusEx(uID, szStatus) {
    uID = uID + 1;
    AppendStatus("通道" + uID + ":" + szStatus);
}
function showDlg(flag) {
    var urlStr = prompt("请输入上传的文件的URL，格式如php文件上传", "");
    if (urlStr != null && urlStr != "") {
        if (flag == 0)
            TV_uploadFile(urlStr);
        else
            ali_uploadFile(urlStr);
    }
    else {
        alert('上传url不能为空!');
    }
}
var uID = 0;
function T_GetEvent(uID, uEventType, uHandle, uResult, szdata) {
    //var vValueArray=qnviccub.QNV_Event(0,2,0,"","",1024);
    if (uEventType == -1)
        return;
    uID = uID;
    var vValue = " type=" + uEventType + " Handle=" + uHandle + " Result=" + uResult + " szdata=" + szdata;
    switch (uEventType) {
        case BriEvent_PhoneHook:// 本地电话机摘机事件
            AppendStatusEx(uID, "本地电话机摘机" + vValue);
            pickUpLinePhone();
            break;
        case BriEvent_PhoneDial:// 只有在本地话机摘机，没有调用软摘机时，检测到DTMF拨号
            AppendStatusEx(uID, "本地话机拨号" + vValue);
            break;
        case BriEvent_PhoneHang:// 本地电话机挂机事件
            hangUpPhone();
            AppendStatusEx(uID, "本地电话机挂机" + vValue);
            break;
        case BriEvent_CallIn:// 外线通道来电响铃事件
            isRingOn();
            AppendStatusEx(uID, "外线通道来电响铃事件" + vValue);
            break;
        case BriEvent_GetCallID://得到来电号码
            AppendStatusEx(uID, "得到来电号码" + vValue);
            getPhoneNumber(vValue);
            break;
        case BriEvent_StopCallIn:// 对方停止呼叫(产生一个未接电话)
            AppendStatusEx(uID, "对方停止呼叫(产生一个未接电话)" + vValue);
            hangUpPhone();
            break;
        case BriEvent_DialEnd:// 调用开始拨号后，全部号码拨号结束
            AppendStatusEx(uID, "调用开始拨号后，全部号码拨号结束" + vValue);
            doDialNumberDone();
            break;
        case BriEvent_PlayFileEnd:// 播放文件结束事件
            AppendStatusEx(uID, "播放文件结束事件" + vValue);
            break;
        case BriEvent_PlayMultiFileEnd:// 多文件连播结束事件
            AppendStatusEx(uID, "多文件连播结束事件" + vValue);
            break;
        case BriEvent_PlayStringEnd://播放字符结束
            AppendStatusEx(uID, "播放字符结束" + vValue);
            break
        case BriEvent_RepeatPlayFile:// 播放文件结束准备重复播放
            AppendStatusEx(uID, "播放文件结束准备重复播放" + vValue);
            break;
        case BriEvent_SendCallIDEnd:// 给本地设备发送震铃信号时发送号码结束
            AppendStatusEx(uID, "给本地设备发送震铃信号时发送号码结束" + vValue);
            break;
        case BriEvent_RingTimeOut://给本地设备发送震铃信号时超时
            AppendStatusEx(uID, "给本地设备发送震铃信号时超时" + vValue);
            break;
        case BriEvent_Ringing://正在内线震铃
            AppendStatusEx(uID, "正在内线震铃" + vValue);
            break;
        case BriEvent_Silence:// 通话时检测到一定时间的静音.默认为5秒
            AppendStatusEx(uID, "通话时检测到一定时间的静音" + vValue);
            break;
        case BriEvent_GetDTMFChar:// 线路接通时收到DTMF码事件
            AppendStatusEx(uID, "线路接通时收到DTMF码事件" + vValue);
            break;
        case BriEvent_RemoteHook:// 拨号后,被叫方摘机事件
            AppendStatusEx(uID, "拨号后,被叫方摘机事件" + vValue);
            doCustomerPickUpPhone();
            break;
        case BriEvent_RemoteHang://对方挂机事件
            hangUpPhone();
            AppendStatusEx(uID, "对方挂机事件" + vValue);
            break;
        case BriEvent_Busy:// 检测到忙音事件,表示PSTN线路已经被断开
            AppendStatusEx(uID, "检测到忙音事件,表示PSTN线路已经被断开" + vValue);
            stopRecord();
            TV_HangUpCtrl(uID);
            break;
        case BriEvent_DialTone:// 本地摘机后检测到拨号音
            AppendStatusEx(uID, "本地摘机后检测到拨号音" + vValue);
            doDialNumberDone();
            break;
        case BriEvent_RingBack:// 电话机拨号结束呼出事件。
            AppendStatusEx(uID, "电话机拨号结束呼出事件" + vValue);
            break;
        case BriEvent_MicIn:// MIC插入状态
            AppendStatusEx(uID, "MIC插入状态" + vValue);
            break;
        case BriEvent_MicOut:// MIC拔出状态
            AppendStatusEx(uID, "MIC拔出状态" + vValue);
            break;
        case BriEvent_FlashEnd:// 拍插簧(Flash)完成事件，拍插簧完成后可以检测拨号音后进行二次拨号
            AppendStatusEx(uID, "拍插簧(Flash)完成事件，拍插簧完成后可以检测拨号音后进行二次拨号" + vValue);
            break;
        case BriEvent_RefuseEnd:// 拒接完成
            AppendStatusEx(uID, "拒接完成" + vValue);
            break;
        case BriEvent_SpeechResult:// 语音识别完成
            AppendStatusEx(uID, "语音识别完成" + vValue);
            break;
        case BriEvent_FaxRecvFinished:// 接收传真完成
            AppendStatusEx(uID, "接收传真完成" + vValue);
            break;
        case BriEvent_FaxRecvFailed:// 接收传真失败
            AppendStatusEx(uID, "接收传真失败" + vValue);
            break;
        case BriEvent_FaxSendFinished:// 发送传真完成
            AppendStatusEx(uID, "发送传真完成" + vValue);
            break;
        case BriEvent_FaxSendFailed:// 发送传真失败
            AppendStatusEx(uID, "发送传真失败" + vValue);
            break;
        case BriEvent_OpenSoundFailed:// 启动声卡失败
            AppendStatusEx(uID, "启动声卡失败" + vValue);
            break;
        case BriEvent_UploadSuccess://远程上传成功
            AppendStatusEx(uID, "远程上传成功" + vValue);
            break;
        case BriEvent_UploadFailed://远程上传失败
            AppendStatusEx(uID, "远程上传失败" + vValue);
            break;
        case BriEvent_EnableHook:// 应用层调用软摘机/软挂机成功事件
            AppendStatusEx(uID, "应用层调用软摘机/软挂机成功事件" + vValue);
            break;
        case BriEvent_EnablePlay:// 喇叭被打开或者/关闭
            AppendStatusEx(uID, "喇叭被打开或者/关闭" + vValue);
            break;
        case BriEvent_EnableMic:// MIC被打开或者关闭
            AppendStatusEx(uID, "MIC被打开或者关闭" + vValue);
            break;
        case BriEvent_EnableSpk:// 耳机被打开或者关闭
            AppendStatusEx(uID, "耳机被打开或者关闭" + vValue);
            break;
        case BriEvent_EnableRing:// 电话机跟电话线(PSTN)断开/接通
            AppendStatusEx(uID, "电话机跟电话线(PSTN)断开/接通" + vValue);
            break;
        case BriEvent_DoRecSource:// 修改录音源
            AppendStatusEx(uID, "修改录音源" + vValue);
            break;
        case BriEvent_DoStartDial:// 开始软件拨号
            AppendStatusEx(uID, "开始软件拨号" + vValue);
            break;
        case BriEvent_RecvedFSK:// 接收到FSK信号，包括通话中FSK/来电号码的FSK
            AppendStatusEx(uID, "接收到FSK信号，包括通话中FSK/来电号码的FSK" + vValue);
            break;
        case BriEvent_PlugOut:
            AppendStatusEx(uID, "设备移除");
            break;
        case BriEvent_DevErr://设备错误
            AppendStatusEx(uID, "设备错误" + decodeURIComponent(vValue));
            break;
        default:
            if (uEventType < BriEvent_EndID)
                AppendStatusEx(uID, "忽略其它事件发生:ID=" + uEventType + vValue);
            break;
    }

}

//编码问题
var base64EncodeChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
var base64DecodeChars = new Array(

    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,

    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,

    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 62, -1, -1, -1, 63,

    52, 53, 54, 55, 56, 57, 58, 59, 60, 61, -1, -1, -1, -1, -1, -1,

    -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,

    15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, -1, -1, -1, -1, -1,

    -1, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40,

    41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, -1, -1, -1, -1, -1);
//检查驱动 1-安装成功 5-没有安装本地驱动 2,3,4-其他
function checkActiveX() {
    I_CheckActiveX();
}

function base64encode(str) {

    var out, i, len;

    var c1, c2, c3;

    len = str.length;

    i = 0;

    out = "";

    while (i < len) {

        c1 = str.charCodeAt(i++) & 0xff;

        if (i == len) {

            out += base64EncodeChars.charAt(c1 >> 2);

            out += base64EncodeChars.charAt((c1 & 0x3) << 4);

            out += "==";

            break;

        }

        c2 = str.charCodeAt(i++);

        if (i == len) {

            out += base64EncodeChars.charAt(c1 >> 2);

            out += base64EncodeChars.charAt(((c1 & 0x3) << 4) | ((c2 & 0xF0) >> 4));

            out += base64EncodeChars.charAt((c2 & 0xF) << 2);

            out += "=";

            break;

        }

        c3 = str.charCodeAt(i++);

        out += base64EncodeChars.charAt(c1 >> 2);

        out += base64EncodeChars.charAt(((c1 & 0x3) << 4) | ((c2 & 0xF0) >> 4));

        out += base64EncodeChars.charAt(((c2 & 0xF) << 2) | ((c3 & 0xC0) >> 6));

        out += base64EncodeChars.charAt(c3 & 0x3F);

    }

    return out;

}

function base64decode(str) {

    var c1, c2, c3, c4;

    var i, len, out;

    len = str.length;

    i = 0;

    out = "";

    while (i < len) {

        /* c1 */

        do {

            c1 = base64DecodeChars[str.charCodeAt(i++) & 0xff];

        } while (i < len && c1 == -1);

        if (c1 == -1)

            break;

        /* c2 */

        do {

            c2 = base64DecodeChars[str.charCodeAt(i++) & 0xff];

        } while (i < len && c2 == -1);

        if (c2 == -1)

            break;

        out += String.fromCharCode((c1 << 2) | ((c2 & 0x30) >> 4));

        /* c3 */

        do {

            c3 = str.charCodeAt(i++) & 0xff;

            if (c3 == 61)

                return out;

            c3 = base64DecodeChars[c3];

        } while (i < len && c3 == -1);

        if (c3 == -1)

            break;

        out += String.fromCharCode(((c2 & 0XF) << 4) | ((c3 & 0x3C) >> 2));

        /* c4 */

        do {

            c4 = str.charCodeAt(i++) & 0xff;

            if (c4 == 61)

                return out;

            c4 = base64DecodeChars[c4];

        } while (i < len && c4 == -1);

        if (c4 == -1)

            break;

        out += String.fromCharCode(((c3 & 0x03) << 6) | c4);

    }

    return out;

}

function utf16to8(str) {

    var out, i, len, c;

    out = "";

    len = str.length;

    for (i = 0; i < len; i++) {

        c = str.charCodeAt(i);

        if ((c >= 0x0001) && (c <= 0x007F)) {

            out += str.charAt(i);

        } else if (c > 0x07FF) {

            out += String.fromCharCode(0xE0 | ((c >> 12) & 0x0F));

            out += String.fromCharCode(0x80 | ((c >> 6) & 0x3F));

            out += String.fromCharCode(0x80 | ((c >> 0) & 0x3F));

        } else {

            out += String.fromCharCode(0xC0 | ((c >> 6) & 0x1F));

            out += String.fromCharCode(0x80 | ((c >> 0) & 0x3F));

        }

    }

    return out;

}

function utf8to16(str) {

    var out, i, len, c;

    var char2, char3;

    out = "";

    len = str.length;

    i = 0;

    while (i < len) {

        c = str.charCodeAt(i++);

        switch (c >> 4) {

            case 0: case 1: case 2: case 3: case 4: case 5: case 6: case 7:

                // 0xxxxxxx

                out += str.charAt(i - 1);

                break;

            case 12: case 13:

                // 110x xxxx　 10xx xxxx

                char2 = str.charCodeAt(i++);

                out += String.fromCharCode(((c & 0x1F) << 6) | (char2 & 0x3F));

                break;

            case 14:

                // 1110 xxxx　10xx xxxx　10xx xxxx

                char2 = str.charCodeAt(i++);

                char3 = str.charCodeAt(i++);

                out += String.fromCharCode(((c & 0x0F) << 12) |

                    ((char2 & 0x3F) << 6) |

                    ((char3 & 0x3F) << 0));

                break;

        }

    }

    return out;

}
var callList = [];
var CallTime = '', PickUpTime = '', HangUpTime = '', ComingPhoneNumber = '', RelatedPhoneRecordID = 0, RecordPath, ServiceID = 0, RecordName = '', isPopUp = false, isStartRecording = false, RingOnCount = 0;
var PhoneType = 0;//1-来电 2-去电
function reSetData() {
    CallTime = '';
    PickUpTime = '';
    HangUpTime = '';
    ComingPhoneNumber = '';
    RelatedPhoneRecordID = 0;
    RecordPath = '';
    ServiceID = 0;
    RecordName = '';
    isPopUp = false;
    isStartRecording = false;
    PhoneType = 0;
    RingOnCount = 0;
}
function callListPush() {
    var canPush = true;
    if (RecordName == '') {
        canPush = false;
    }
    $.each(callList, function (index, item) {
        if (item.RecordName == RecordName) {
            canPush = false;
            return false;
        }
    })
    if (canPush) {
        callList.push({
            CallTime: CallTime,
            PickUpTime: PickUpTime,
            HangUpTime: HangUpTime,
            ComingPhoneNumber: ComingPhoneNumber,
            RelatedPhoneRecordID: RelatedPhoneRecordID,
            ServiceID: ServiceID,
            RecordName: RecordName,
            PhoneType: PhoneType,
            RecordPath: RecordPath
        })
    }
    reSetData();
}
//检测到拨号动作
function doDialNumberDone() {
    startRecord();
    PhoneType = 2;
}
//拨打电话
function dialPhone(phoneNumber, serviceID, relatedPhoneRecordID) {
    reSetData();
    if (top.isDriverOn == 2) {
        var messages = '电话语音驱动未运行，请检查'
        alertNotify(messages, 2);
        return;
    }
    if (top.isPhoneDeviceWork == 2) {
        var messages = '设备未连接电脑，请检查'
        alertNotify(messages, 2);
        return;
    }
    var messages = '您正在拨打电话:' + phoneNumber + '。电话正在接通中...';
    alertNotify(messages, 0);
    ComingPhoneNumber = phoneNumber;
    ServiceID = serviceID || 0;
    RelatedPhoneRecordID = relatedPhoneRecordID || 0;
    try {
        openMic();
        TV_HangUpCtrl(uID);
        TV_StartDial(uID, phoneNumber);
        startRecord();
    } catch (e) {
        alert(e);
    }
    PhoneType = 2;
}
//软接听电话
function pickUpPhone() {
    RingOnCount = 0;
    TV_OffHookCtrl(uID);
    startRecord();
    PhoneType = 1;
    PickUpTime = getNowTimeStr();
    top.close_message();
}
//响铃事件
function isRingOn() {
    if (RingOnCount == 0) {
        //reSetData();
    }
    RingOnCount++;
    startRecord();
    PhoneType = 1;
}
//本机电话接听
function pickUpLinePhone() {
    RingOnCount = 0;
    startRecord();
    if (PhoneType == 1) {
        PickUpTime = getNowTimeStr();
    } else {
        PhoneType = 2;
    }
    top.close_message();
}
//客户接听电话
function doCustomerPickUpPhone() {
    RingOnCount = 0;
    startRecord();
    PhoneType = 2;
    PickUpTime = getNowTimeStr();
    top.close_message();
}
//挂机
function hangUpPhone() {
    RingOnCount = 0;
    uID = 0;
    try {
        stopRecord();
        closeMic();
        TV_HangUpCtrl(uID);
        top.close_message();
    } catch (e) {
    }
    if (callList.length == 0) {
        var messages = '电话录音上传失败，请检查本地电话录音文件是否存在'
        top.alertNotify(messages, 0);
        return;
    }
}
//拒接来电
function rejectPickUpPhone() {
    RingOnCount = 0;
    TV_RefuseCallIn(uID);
    uID = 0;
    top.close_message();
}
//来电弹屏
function openDialCallPickUpBox() {
    if (isPopUp) {
        return;
    }
    isPopUp = true;
    var messages = '电话来了，<a href="javascript:top.pickUpPhone()">点击接听</a>'
    top.alertNotify(messages, 1);
}
//开始录音
function startRecord() {
    if (isStartRecording) {
        return;
    }
    isStartRecording = true;
    CallTime = getNowTimeStr();
    if (RecordLocation) {
        if (!RecordLocation.endWith('\\')) {
            RecordLocation += '\\';
        }
        RecordName = getTimeName() + '.wav';
        RecordPath = RecordLocation + RecordName;
        TV_StartRecordFile(uID, RecordPath);
    }
}
//结束录音
function stopRecord() {
    callListPush();
    if (isStartRecording) {
        HangUpTime = getNowTimeStr();
        try {
            TV_StopRecordFile(uID);
        } catch (e) {
        }
        setTimeout(function () {
            uploadFileRecord();
        }, 500);
    }
}
var tryCount = 0;
function uploadFileRecord() {
    if (callList.length == 0) {
        return;
    }
    var callItem = callList[callList.length - 1];
    var params = '?visit=uploadvoicerecord&CallTime=' + callItem.CallTime + '&PickUpTime=' + callItem.PickUpTime + '&HangUpTime=' + callItem.HangUpTime + '&ComingPhone=' + callItem.ComingPhoneNumber + '&ServiceID=' + callItem.ServiceID + '&PhoneType=' + callItem.PhoneType + '&UserID=' + UserID + '&AddUserName=' + AddUserName + '&RelatedPhoneRecordID=' + callItem.RelatedPhoneRecordID + "&RecordName=" + callItem.RecordName;
    TV_uploadFile(contextPath + '/Handler/ServiceHandler.ashx' + params, callItem.RecordPath);
    setTimeout(function () {
        var messages = '电话录音上传成功'
        top.alertNotify(messages, 3);
        callList.splice(callList.length - 1, 1);
        uploadFileRecord();
    }, 2000);
}
//得到来电号码
function getPhoneNumber(data) {
    startRecord();
    PhoneType = 1;
    var dataArray = data.split(' ');
    var dataItem = null;
    if (dataArray.length > 0) {
        dataItem = dataArray[dataArray.length - 1];
    }
    if (dataItem) {
        var dataItemArray = dataItem.split('=');
        if (dataItemArray.length > 0) {
            var phoneNumber = dataItemArray[dataItemArray.length - 1];
            getDataByPhoneNumber(phoneNumber);
            setTimeout(function () {
                openDialCallPickUpBox();
            }, 50);
        }
    }
}
function getDataByPhoneNumber(phoneNumber) {
    if (!top.ComingPhoneNumber) {
        top.ComingPhoneNumber = phoneNumber;
        try {
            $("#top_main_frame")[0].contentWindow.getCustomerData(phoneNumber);
        } catch (e) {
        }
        top.addTab('400客服', '../Main/Default.aspx', '');
        top.openTreeContent();
    }
    else {
        top.addTab(phoneNumber, '../Main/Default.aspx?phoneNumber=' + phoneNumber, '');
        top.openTreeContent();
    }
}
//打开耳机麦克风
function openMic() {
    //TV_EnableMic(0, TRUE);
    TV_EnableLine2Spk(0, TRUE);
}
//关闭耳机麦克风
function closeMic() {
    //TV_EnableMic(0, FALSE);
    TV_EnableLine2Spk(0, FALSE);
}