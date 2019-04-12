using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility
{
    public class LLing_CommResponse
    {
        public string statusCode { get; set; }
        public string methodName { get; set; }
    }
    public class LLing_AddDeviceResponse : LLing_CommResponse
    {
        public LLing_AddDeviceModel responseResult { get; set; }
    }
    public class LLing_NoListResponse : LLing_CommResponse
    {
        public string responseResult { get; set; }
    }
    public class LLing_QueryDeviceResponse : LLing_CommResponse
    {
        public List<LLing_QueryDeviceModel> responseResult { get; set; }
    }
    public class LLing_QueryDeviceSDKKeyResponse : LLing_CommResponse
    {
        public Dictionary<int, string> responseResult { get; set; }
    }
    public class LLing_LLingIDResponse : LLing_CommResponse
    {
        public LLing_LLingIDModel responseResult { get; set; }
    }
    public class LLing_VistorQrCodeResponse : LLing_CommResponse
    {
        public LLing_VistorQrCodeModel responseResult { get; set; }
    }
    public class LLing_OpenDoorLogResponse : LLing_CommResponse
    {
        public LLing_OpenDoorLogModel responseResult { get; set; }
    }
    public class LLing_LLingIDModel
    {
        public string lingLingId { get; set; }
    }
    public class LLing_AddDeviceModel
    {

        public int deviceId { get; set; }
    }

    public class LLing_QueryDeviceModel
    {
        public int deviceId { get; set; }
        public string deviceName { get; set; }
        public string deviceCode { get; set; }
        public int isOnline { get; set; }
        public long makeTime { get; set; }
    }
    public class LLing_QueryDeviceSDKKeyModel
    {
        public int deviceId { get; set; }
        public string sdkKey { get; set; }
    }
    public class LLing_VistorQrCodeModel
    {
        public int codeId { get; set; }
        public string qrcodeKey { get; set; }
    }
    public class LLing_OpenDoorLogModel
    {
        public long total { get; set; }
        public List<LLing_OpenDoorLogRowsModel> rows { get; set; }
    }
    public class LLing_OpenDoorLogRowsModel
    {
        public int deviceId { get; set; }
        public long openTime { get; set; }
        public int openType { get; set; }
        public string lingLingId { get; set; }
        public string DeviceName { get; set; }
        public DateTime OpenTime
        {
            get
            {
                return Utility.Tools.GetDateTimeByTimeStamp(this.openTime);
            }
        }
        public string OpenTimeDesc
        {
            get
            {
                string desc = this.OpenTime.ToString("yyyy-MM-dd HH:mm:ss");
                return desc;
            }
        }
        public string OpenTypeDesc
        {
            get
            {
                string desc = "";
                switch (this.openType)
                {
                    case 2:
                        desc = "业主二维码开门";
                        break;
                    case 3:
                        desc = "门禁访客二维码开门";
                        break;
                    case 4:
                        desc = "梯控访客二维码";
                        break;
                    case 5:
                        desc = "远程开门";
                        break;
                    case 6:
                        desc = "NFC开门";
                        break;
                    default:
                        break;
                }
                return desc;
            }
        }
    }
}
