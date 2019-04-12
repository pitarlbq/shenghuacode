using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace Utility
{
    public class LLingHelper
    {
        const string errormsg = "门禁服务器异常";
        /// <summary>
        /// 添加设备
        /// </summary>
        /// <param name="deviceName"></param>
        /// <param name="deviceCode"></param>
        /// <returns></returns>
        public static int doAddDevice(string deviceName, string deviceCode, out string error)
        {
            error = errormsg;
            try
            {
                string postname = LLingHttpConfig.HOST_METHOD_ADD_DEVICE;
                Dictionary<string, object> formParams = new Dictionary<string, object>();
                formParams["deviceName"] = deviceName;
                formParams["deviceCode"] = deviceCode;
                string result = doPostMethod(formParams, postname);
                if (string.IsNullOrEmpty(result))
                {
                    return 0;
                }
                int DeviceID = 0;
                try
                {
                    LLing_AddDeviceResponse response = JsonConvert.DeserializeObject<LLing_AddDeviceResponse>(result);
                    if (response.statusCode.Equals("1"))
                    {
                        DeviceID = response.responseResult.deviceId;
                    }
                }
                catch (Exception)
                {
                    LLing_NoListResponse response = JsonConvert.DeserializeObject<LLing_NoListResponse>(result);
                    error = response.responseResult;
                }
                return DeviceID;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("Utility.LLingHelper.cs", "doAddDevice", ex);
                return 0;
            }
        }
        /// <summary>
        /// 更新设备
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="deviceName"></param>
        /// <param name="deviceCode"></param>
        /// <returns></returns>
        public static bool doEditDevice(int deviceId, string deviceName, string deviceCode, out string error)
        {
            error = errormsg;
            try
            {
                string postname = LLingHttpConfig.HOST_METHOD_UPDATE_DEVICE;
                Dictionary<string, object> formParams = new Dictionary<string, object>();
                formParams["deviceId"] = deviceId;
                formParams["newDeviceName"] = deviceName;
                formParams["newDeviceCode"] = deviceCode;
                string result = doPostMethod(formParams, postname);
                if (string.IsNullOrEmpty(result))
                {
                    return false;
                }
                LLing_NoListResponse response = JsonConvert.DeserializeObject<LLing_NoListResponse>(result);
                if (response.statusCode.Equals("1"))
                {
                    return true;
                }
                error = response.responseResult;
                return false;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("Utility.LLingHelper.cs", "doEditDevice", ex);
                return false;
            }
        }
        /// <summary>
        /// 删除设备
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public static bool doRemoveDevice(int deviceId, out string error)
        {
            error = errormsg;
            try
            {
                string postname = LLingHttpConfig.HOST_METHOD_DEL_DEVICE;
                Dictionary<string, object> formParams = new Dictionary<string, object>();
                formParams["deviceId"] = deviceId;
                string result = doPostMethod(formParams, postname);
                if (string.IsNullOrEmpty(result))
                {
                    return false;
                }
                LLing_NoListResponse response = JsonConvert.DeserializeObject<LLing_NoListResponse>(result);
                if (response.statusCode.Equals("1"))
                {
                    return true;
                }
                error = response.responseResult;
                return false;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("Utility.LLingHelper.cs", "doRemoveDevice", ex);
                return false;
            }
        }
        /// <summary>
        /// 查询设备
        /// </summary>
        /// <returns></returns>
        public static List<LLing_QueryDeviceModel> doQueryDeviceList()
        {
            List<LLing_QueryDeviceModel> list = new List<LLing_QueryDeviceModel>();
            try
            {
                string postname = LLingHttpConfig.HOST_METHOD_GET_DEVICE_LIST;
                string result = doPostMethod(null, postname);
                if (string.IsNullOrEmpty(result))
                {
                    return list;
                }
                LLing_QueryDeviceResponse response = JsonConvert.DeserializeObject<LLing_QueryDeviceResponse>(result);
                if (response.statusCode.Equals("1"))
                {
                    list = response.responseResult;
                }
                return list;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("Utility.LLingHelper.cs", "doQueryDeviceList", ex);
                return list;
            }
        }
        /// <summary>
        /// 添加门禁卡
        /// </summary>
        /// <param name="cardUids"></param>
        /// <param name="deviceIds"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static bool doAddDoorOpenCard(string[] cardUids, int[] deviceIds, int endTime, out string error)
        {
            error = errormsg;
            try
            {
                string postname = LLingHttpConfig.HOST_METHOD_ADD_OPEN_DOOR_CARD;
                Dictionary<string, object> formParams = new Dictionary<string, object>();
                formParams["cardUids"] = cardUids;
                formParams["deviceIds"] = deviceIds;
                formParams["endTime"] = endTime;
                string result = doPostMethod(formParams, postname);
                if (string.IsNullOrEmpty(result))
                {
                    return false;
                }
                LLing_NoListResponse response = JsonConvert.DeserializeObject<LLing_NoListResponse>(result);
                if (response.statusCode.Equals("1"))
                {
                    return true;
                }
                error = response.responseResult;
                return false;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("Utility.LLingHelper.cs", "doAddDoorOpenCard", ex);
                return false;
            }
        }
        /// <summary>
        /// 更新门禁卡
        /// </summary>
        /// <param name="cardUids"></param>
        /// <param name="deviceIds"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static bool doUpdateDoorOpenCard(string[] cardUids, int[] deviceIds, int endTime, out string error)
        {
            error = errormsg;
            try
            {
                string postname = LLingHttpConfig.HOST_METHOD_UPDATE_OPEN_DOOR_CARD;
                Dictionary<string, object> formParams = new Dictionary<string, object>();
                formParams["cardUids"] = cardUids;
                formParams["newDeviceIds"] = deviceIds;
                formParams["newEndTime"] = endTime;
                string result = doPostMethod(formParams, postname);
                if (string.IsNullOrEmpty(result))
                {
                    return false;
                }
                LLing_NoListResponse response = JsonConvert.DeserializeObject<LLing_NoListResponse>(result);
                if (response.statusCode.Equals("1"))
                {
                    return true;
                }
                error = response.responseResult;
                return false;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("Utility.LLingHelper.cs", "doUpdateDoorOpenCard", ex);
                return false;
            }
        }
        /// <summary>
        /// 删除门禁卡
        /// </summary>
        /// <param name="cardUids"></param>
        /// <returns></returns>
        public static bool doRemoveOpenDoorCard(string[] cardUids, out string error)
        {
            error = errormsg;
            try
            {
                string postname = LLingHttpConfig.HOST_METHOD_DEL_OPEN_DOOR_CARD;
                Dictionary<string, object> formParams = new Dictionary<string, object>();
                formParams["cardUids"] = cardUids;
                string result = doPostMethod(formParams, postname);
                if (string.IsNullOrEmpty(result))
                {
                    return false;
                }
                LLing_NoListResponse response = JsonConvert.DeserializeObject<LLing_NoListResponse>(result);
                if (response.statusCode.Equals("1"))
                {
                    return true;
                }
                error = response.responseResult;
                return false;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("Utility.LLingHelper.cs", "doRemoveOpenDoorCard", ex);
                return false;
            }
        }
        public static bool doRemoteOpenDoor(string sdkKey, out string error)
        {
            error = errormsg;
            try
            {
                string postname = LLingHttpConfig.HOST_METHOD_REMOTE_OPEN_DOOR;
                Dictionary<string, object> formParams = new Dictionary<string, object>();
                formParams["sdkKey"] = sdkKey;
                string result = doPostMethod(formParams, postname);
                if (string.IsNullOrEmpty(result))
                {
                    return false;
                }
                LLing_NoListResponse response = JsonConvert.DeserializeObject<LLing_NoListResponse>(result);
                if (response.statusCode.Equals("1"))
                {
                    return true;
                }
                error = response.responseResult;
                return false;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("Utility.LLingHelper.cs", "doRemoteOpenDoor", ex);
                return false;
            }
        }
        /// <summary>
        /// 查询密钥
        /// </summary>
        /// <param name="deviceIds"></param>
        /// <param name="keyEffecDay"></param>
        /// <returns></returns>
        public static Dictionary<int, string> doQueryDeviceSDKKeyList(int[] deviceIds, out string error, int keyEffecDay = 100)
        {
            error = errormsg;
            Dictionary<int, string> list = new Dictionary<int, string>();
            try
            {
                string postname = LLingHttpConfig.HOST_METHOD_MAKE_SDK_KEY;
                Dictionary<string, object> formParams = new Dictionary<string, object>();
                formParams["deviceIds"] = deviceIds;
                formParams["keyEffecDay"] = keyEffecDay;
                string result = doPostMethod(formParams, postname);
                if (string.IsNullOrEmpty(result))
                {
                    return list;
                }
                try
                {
                    LLing_QueryDeviceSDKKeyResponse response = JsonConvert.DeserializeObject<LLing_QueryDeviceSDKKeyResponse>(result);
                    if (response.statusCode.Equals("1"))
                    {
                        list = response.responseResult;
                    }
                }
                catch (Exception)
                {
                    LLing_NoListResponse response = JsonConvert.DeserializeObject<LLing_NoListResponse>(result);
                    error = response.responseResult;
                }
                return list;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("Utility.LLingHelper.cs", "doQueryDeviceSDKKeyList", ex);
                return list;
            }
        }
        /// <summary>
        /// 获取LingLingId
        /// </summary>
        /// <returns></returns>
        public static bool doGetLingLingID(out string LingLingID, out string error)
        {
            error = errormsg;
            LingLingID = string.Empty;
            try
            {
                string postname = LLingHttpConfig.HOST_METHOD_GET_LLID;
                string result = doPostMethod(null, postname);
                if (string.IsNullOrEmpty(result))
                {
                    return false;
                }
                try
                {
                    LLing_LLingIDResponse response = JsonConvert.DeserializeObject<LLing_LLingIDResponse>(result);
                    if (response.statusCode.Equals("1"))
                    {
                        LingLingID = response.responseResult.lingLingId;
                        return true;
                    }
                }
                catch (Exception)
                {
                    LLing_NoListResponse response = JsonConvert.DeserializeObject<LLing_NoListResponse>(result);
                    error = response.responseResult;
                }
                return false;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("Utility.LLingHelper.cs", "doGetLingLingID", ex);
                return false;
            }
        }
        /// <summary>
        /// 添加访客二维码
        /// </summary>
        /// <param name="sdkKey"></param>
        /// <param name="endTime"></param>
        /// <param name="effecNumber"></param>
        /// <returns></returns>
        public static bool doAddVisitorQrCode(string sdkKey, int endTime, int effecNumber, out string lingLingId, out string strKey, out int codeId, out string qrcodeKey)
        {
            lingLingId = string.Empty;
            strKey = string.Empty;
            codeId = 0;
            qrcodeKey = string.Empty;
            try
            {
                string postname = LLingHttpConfig.HOST_METHOD_ADD_VISITOR_QRCODE;
                string error = string.Empty;
                bool ll_result = doGetLingLingID(out lingLingId, out error);
                if (!ll_result)
                {
                    return false;
                }
                long startTime = Utility.Tools.GetTimeStamp();
                //Utility.LogHelper.WriteDebug("doAddVisitorQrCode.starttime", startTime.ToString());
                strKey = Utility.Tools.GetByteString(4);
                qrcodeKey = string.Empty;
                Dictionary<string, object> formParams = new Dictionary<string, object>();
                formParams["lingLingId"] = lingLingId;
                formParams["sdkKeys"] = new string[] { sdkKey };
                formParams["startTime"] = startTime;
                formParams["endTime"] = endTime;
                formParams["effecNumber"] = effecNumber;
                formParams["strKey"] = strKey;
                string result = doPostMethod(formParams, postname);
                if (string.IsNullOrEmpty(result))
                {
                    return false;
                }
                LLing_VistorQrCodeResponse response = JsonConvert.DeserializeObject<LLing_VistorQrCodeResponse>(result);
                if (response.statusCode.Equals("1"))
                {
                    codeId = response.responseResult.codeId;
                    qrcodeKey = response.responseResult.qrcodeKey;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("Utility.LLingHelper.cs", "doAddVisitorQrCode", ex);
                return false;
            }
        }
        public static bool doRemoveVisitorQrCode(int codeId, out string error)
        {
            error = errormsg;
            try
            {
                string postname = LLingHttpConfig.HOST_METHOD_DEL_VISITOR_QRCODE;
                Dictionary<string, object> formParams = new Dictionary<string, object>();
                formParams["codeId"] = codeId;
                string result = doPostMethod(formParams, postname);
                if (string.IsNullOrEmpty(result))
                {
                    return false;
                }
                LLing_NoListResponse response = JsonConvert.DeserializeObject<LLing_NoListResponse>(result);
                if (response.statusCode.Equals("1"))
                {
                    return true;
                }
                error = response.responseResult;
                return false;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("Utility.LLingHelper.cs", "doRemoveVisitorQrCode", ex);
                return false;
            }
        }
        public static LLing_OpenDoorLogModel doQueryOpenDoorLog(int page, long rows,out string error)
        {
            error = errormsg;
            try
            {
                string postname = LLingHttpConfig.HOST_METHOD_GET_OPENDOORLOG;
                Dictionary<string, object> formParams = new Dictionary<string, object>();
                formParams["page"] = page;
                formParams["rows"] = rows;
                string result = doPostMethod(formParams, postname);
                if (string.IsNullOrEmpty(result))
                {
                    return null;
                }
                try
                {
                    LLing_OpenDoorLogResponse response = JsonConvert.DeserializeObject<LLing_OpenDoorLogResponse>(result);
                    if (response.statusCode.Equals("1"))
                    {
                        return response.responseResult;
                    }
                }
                catch (Exception)
                {
                    LLing_NoListResponse response = JsonConvert.DeserializeObject<LLing_NoListResponse>(result);
                    error = response.responseResult;
                }
                return null;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("Utility.LLingHelper.cs", "doQueryOpenDoorLog", ex);
                return null;
            }
        }
        public static string makeMessage(string postJSONStr)
        {
            string result = "MESSAGE={\"requestParam\":" + postJSONStr + ",\"header\":{\"signature\":\"" + LLingHttpConfig.HOST_SIGNATURE + "\",\"token\":\"" + LLingHttpConfig.HOST_TOKEN + "\"}}";
            return result;
        }
        public static string doPostMethod(Dictionary<string, object> postJson, string postname)
        {
            try
            {
                string postJSONStr = "{}";
                if (postJson != null)
                {
                    postJSONStr = JsonConvert.SerializeObject(postJson);
                }
                string apiurl = LLingHttpConfig.HOST_SERVER + postname + "/" + LLingHttpConfig.HOST_OPEN_TOKEN;
                var request = System.Net.HttpWebRequest.Create(apiurl);
                request.ContentType = "application/x-www-form-urlencoded";
                //request.ContentType = "application/json";
                request.Method = "POST";
                //request.Headers["signature"] = LLingHttpConfig.HOST_SIGNATURE;
                //request.Headers["token"] = LLingHttpConfig.HOST_OPEN_TOKEN;
                string postContent = makeMessage(postJSONStr);
                string result = string.Empty;
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] postData = encoding.GetBytes(postContent);

                Stream newStream = request.GetRequestStream();
                // Send the data.
                newStream.Write(postData, 0, postData.Length);
                newStream.Flush();
                newStream.Close();

                HttpWebResponse myResponse = (HttpWebResponse)request.GetResponse();
                if (myResponse.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                    result = reader.ReadToEnd();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    public class LLingHttpConfig
    {
        public static string HOST_SERVER = "http://120.24.172.108:8889/cgi-bin/";
        public static string HOST_ACCOUNT = "chenhui8866";//填写您的Account账户
        public static string HOST_SIGNATURE = "bf36f01d-4487-4d1e-88f6-617518c79816";//填写您的signature
        public static string HOST_TOKEN = "1494981115200";//填写您的token
        public static string HOST_OPEN_TOKEN = "511DFEB1DB3D7F04F4BCB45F137402D5";//填写您的openToken
        /// <summary>
        /// 添加设备
        /// </summary>
        public static string HOST_METHOD_ADD_DEVICE = "device/addDevice";
        /// <summary>
        /// 删除设备
        /// </summary>
        public static string HOST_METHOD_DEL_DEVICE = "device/delDevice";
        /// <summary>
        /// 更新设备
        /// </summary>
        public static string HOST_METHOD_UPDATE_DEVICE = "device/updateDevice";
        /// <summary>
        /// 查询设备列表
        /// </summary>
        public static string HOST_METHOD_GET_DEVICE_LIST = "device/queryDeviceList";
        /// <summary>
        /// 生成开门密钥
        /// </summary>
        public static string HOST_METHOD_MAKE_SDK_KEY = "key/makeSdkKey";
        /// <summary>
        /// 获取令令ID
        /// </summary>
        public static string HOST_METHOD_GET_LLID = "qrcode/getLingLingId";
        /// <summary>
        /// 批量获取令令ID
        /// </summary>
        public static string HOST_METHOD_GET_LLID_LIST = "qrcode/getLingLingIds";
        /// <summary>
        /// 生成业主二维码
        /// </summary>
        public static string HOST_METHOD_ADD_OWNER_QRCODE = "qrcode/addOwnerQrCode";
        /// <summary>
        /// 添加门禁访客二维码
        /// </summary>
        public static string HOST_METHOD_ADD_VISITOR_QRCODE = "qrcode/addVisitorQrCode";
        /// <summary>
        /// 删除访客二维码
        /// </summary>
        public static string HOST_METHOD_DEL_VISITOR_QRCODE = "qrcode/delVisitorQrCode";
        /// <summary>
        /// 开门日志查询
        /// </summary>
        public static string HOST_METHOD_GET_OPENDOORLOG = "openDoorLog/selectOpenDoorLog";
        /// <summary>
        /// 添加门禁卡
        /// </summary>
        public static string HOST_METHOD_ADD_OPEN_DOOR_CARD = "openDoorCard/addOpenDoorCard";
        /// <summary>
        /// 更新门禁卡
        /// </summary>
        public static string HOST_METHOD_UPDATE_OPEN_DOOR_CARD = "openDoorCard/updateOpenDoorCard";
        /// <summary>
        /// 删除门禁卡
        /// </summary>
        public static string HOST_METHOD_DEL_OPEN_DOOR_CARD = "openDoorCard/delOpenDoorCard";
        /// <summary>
        /// 远程开门
        /// </summary>
        public static string HOST_METHOD_REMOTE_OPEN_DOOR = "key/remoteOpenDoor";
    }
}
