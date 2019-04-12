using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;

namespace Utility
{
    public class ChequeHelper
    {
        const string LogModule = "Utility.ChequeHelper";
        private static string mTOCKET = string.Empty;
        private static object mTOCKETLocker = new object();
        private static DateTime mTOCKETExpiredTime = DateTime.Now;
        /// <summary>
        /// 获取开票结果
        /// </summary>
        /// <param name="XTLSH"></param>
        /// <param name="TOCKET"></param>
        /// <returns></returns>
        public static bool doGetInvoiceResult(string XTLSH, out string msg)
        {
            msg = string.Empty;
            try
            {
                string TOCKET = GetLoginTOCKET();
                string postname = ChequeHttpConfig.HOST_SHKJ_FPKJ_KPJG;
                Dictionary<string, string> formParams = new Dictionary<string, string>();
                formParams["QYSH"] = ChequeHttpConfig.QYSH;
                formParams["XTLSH"] = XTLSH;
                formParams["FPZL"] = "2";
                formParams["TOCKET"] = TOCKET;
                string result = doPostMethod(formParams, postname);
                LogHelper.WriteInfo("ChequeHelper.doGetInvoiceResult", result);
                string ReturnCode = Utility.Tools.GetJosnValue(result, "Result");
                if (!ReturnCode.Equals("1"))
                {
                    msg = Utility.Tools.GetJosnValue(result, "TEXT");
                    return false;
                }
                string PDFContent = Utility.Tools.GetJosnValue(result, "PDF");
                if (string.IsNullOrEmpty(PDFContent))
                {
                    msg = "PDF流内容为空";
                    return false;
                }
                string filepath = "/upload/invoice/" + DateTime.Now.ToString("yyyyMMdd") + "/";
                string rootPath = HttpContext.Current.Server.MapPath("~" + filepath);
                string fileName = Utility.Tools.GetJosnValue(PDFContent, "XTLSH");
                fileName = string.IsNullOrEmpty(fileName) ? DateTime.Now.ToFileTime().ToString() : fileName + ".pdf";
                byte[] PDFChar = Convert.FromBase64String(PDFContent);
                using (var flieStream = new FileStream(Path.Combine(rootPath, fileName), FileMode.Create))
                {
                    flieStream.Write(PDFChar, 0, PDFChar.Length);
                }
                msg = filepath + fileName;
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModule, "doGetInvoiceResult", ex);
                return false;
            }
        }
        /// <summary>
        /// 单独获取PDF信息
        /// </summary>
        /// <param name="FPHM">发票号</param>
        /// <param name="JSHJ">价税合计</param>
        /// <returns></returns>
        public static string doChequeGetReceiptPDF(string FPHM, string JSHJ)
        {
            try
            {
                string postname = ChequeHttpConfig.HOST_SHKJ_DZFP_PDFINFO;
                Dictionary<string, string> formParams = new Dictionary<string, string>();
                formParams["APPID"] = ChequeHttpConfig.APPID;
                formParams["FPHM"] = FPHM;
                formParams["JSHJ"] = JSHJ;
                string result = doPostMethod(formParams, postname);
                LogHelper.WriteInfo("ChequeHelper.doChequeGetReceiptPDF", result);
                return result;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModule, "doChequeGetReceiptPDF", ex);
                return ex.Message;
            }
        }
        /// <summary>
        /// 开票
        /// </summary>
        /// <param name="data"></param>
        /// <param name="TOCKET"></param>
        /// <returns></returns>
        public static bool doChequeWriteReceipt(string data, out string msg)
        {
            msg = string.Empty;
            try
            {
                string TOCKET = GetLoginTOCKET();
                string postname = ChequeHttpConfig.HOST_SHKJ_FPKJ_SCFP;
                Dictionary<string, string> formParams = new Dictionary<string, string>();
                formParams["DATA"] = "[" + data + "]";
                formParams["TOCKET"] = TOCKET;
                string result = doPostMethod(formParams, postname);
                LogHelper.WriteInfo("ChequeHelper.doChequeWriteReceipt", result);
                string ReturnCode = Utility.Tools.GetJosnValue(result, "Result");
                if (!ReturnCode.Equals("1"))
                {
                    msg = Utility.Tools.GetJosnValue(result, "TEXT");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModule, "doChequeWriteReceipt", ex);
                throw ex;
            }
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public static string doChequeLogin()
        {
            string msg = string.Empty;
            try
            {
                string postname = ChequeHttpConfig.HOST_SHKJ_LOGIN_Login;
                Dictionary<string, string> formParams = new Dictionary<string, string>();
                formParams["UserName"] = ChequeHttpConfig.UserName;
                formParams["Password1"] = ChequeHttpConfig.Password;
                string result = doPostMethod(formParams, postname);
                LogHelper.WriteInfo("ChequeHelper.doChequeLogin", result);
                string ReturnCode = Utility.Tools.GetJosnValue(result, "Result");
                if (!ReturnCode.Equals("1"))
                {
                    return string.Empty;
                }
                msg = Utility.Tools.GetJosnValue(result, "ID");
                return msg;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(LogModule, "doChequeLogin", ex);
                throw ex;
            }
        }
        public static string GetLoginTOCKET()
        {
            if (string.IsNullOrEmpty(mTOCKET) || mTOCKETExpiredTime <= DateTime.Now)
            {
                lock (mTOCKETLocker)
                {
                    if (string.IsNullOrEmpty(mTOCKET) || mTOCKETExpiredTime <= DateTime.Now)
                    {
                        mTOCKET = doChequeLogin();
                    }
                }
            }
            return mTOCKET;
        }
        public static string makeMessage(Dictionary<string, string> postJson)
        {
            var stringparams = new List<string>();
            foreach (var item in postJson)
            {
                stringparams.Add(item.Key + "=" + item.Value);
            }
            string result = string.Join("&", stringparams.ToArray());
            return result;
        }
        public static string doPostMethod(Dictionary<string, string> postJson, string postname)
        {
            try
            {
                string postContent = makeMessage(postJson);
                string apiurl = ChequeHttpConfig.HOST_SERVER + postname;
                var request = System.Net.HttpWebRequest.Create(apiurl);
                request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                request.Method = "POST";
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
                    using (StreamReader sr = new StreamReader(myResponse.GetResponseStream()))
                    {
                        result = sr.ReadToEnd();
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static string GetInvoiceContent(Dictionary<string, string> headRequireItem, List<Dictionary<string, string>> itemlist, Dictionary<string, string> headOptionalItem = null)
        {
            string QYSH = ChequeHttpConfig.QYSH;
            string result = string.Empty;
            XmlDocument xml = new XmlDocument();
            //创建一行声明信息，并添加到 xml 文档顶部
            XmlDeclaration decl = xml.CreateXmlDeclaration("1.0", "GB2312", null);
            xml.AppendChild(decl);
            //创建根节点
            XmlElement rootEle = xml.CreateElement("Config");
            xml.AppendChild(rootEle);
            //创建子结点|属性
            XmlElement invoiceListEle = xml.CreateElement("INVOICELIST");
            rootEle.AppendChild(invoiceListEle);

            XmlElement headEle = xml.CreateElement("HEAD");
            invoiceListEle.AppendChild(headEle);
            headRequireItem["QYSH"] = QYSH;
            foreach (var item in headRequireItem)
            {
                XmlAttribute headEleAttribute = xml.CreateAttribute(item.Key);
                headEleAttribute.Value = item.Value;
                headEle.Attributes.Append(headEleAttribute);
            }
            if (headOptionalItem == null)
            {
                headOptionalItem = new Dictionary<string, string>();
            }
            string[] options = new string[] { "KHDZ", "KHSJ", "KHYJ", "BZ", "SKR", "FHR", "CHFPH", "KTDH", "FPBM", "KHKHYHZH" };
            foreach (var item in options)
            {
                if (!headOptionalItem.ContainsKey(item))
                {
                    headOptionalItem[item] = "";
                }
            }
            if (!headOptionalItem.ContainsKey("FPZL"))
            {
                headOptionalItem["FPZL"] = "2";
            }
            if (!headOptionalItem.ContainsKey("FPZT"))
            {
                headOptionalItem["FPZT"] = "2";
            }
            if (!headOptionalItem.ContainsKey("QDBZ"))
            {
                headOptionalItem["QDBZ"] = "2";
            }
            if (!headOptionalItem.ContainsKey("FPBM"))
            {
                headOptionalItem["FPBM"] = ChequeHttpConfig.FPBM;
            }
            foreach (var item in headOptionalItem)
            {
                XmlAttribute headEleAttribute = xml.CreateAttribute(item.Key);
                headEleAttribute.Value = item.Value;
                headEle.Attributes.Append(headEleAttribute);
            }
            XmlElement itemEle = xml.CreateElement("ITEM");
            invoiceListEle.AppendChild(itemEle);
            foreach (var item in itemlist)
            {
                XmlElement itemRowEle = xml.CreateElement("ITEMROW");
                itemEle.AppendChild(itemRowEle);
                foreach (var dic in item)
                {
                    XmlAttribute itemRowEleAttribute = xml.CreateAttribute(dic.Key);
                    itemRowEleAttribute.Value = dic.Value;
                    itemRowEle.Attributes.Append(itemRowEleAttribute);
                }
            }
            byte[] data;
            using (MemoryStream ms = new MemoryStream())
            {
                xml.Save(ms);
                data = ms.ToArray();
            }
            try
            {
                result = Convert.ToBase64String(data);
            }
            catch
            {
            }
            return result;
        }
    }
    public class ChequeHttpConfig
    {
        
        public static string HOST_SERVER = "https://mycst.cn/";
        public static string UserName = new Utility.SiteConfig().Cheque_UserName;//用户名
        public static string Password = new Utility.SiteConfig().Cheque_Password;//密码
        public static string QYSH = new Utility.SiteConfig().Cheque_QYSH;//企业ID
        public static string APPID = new Utility.SiteConfig().Cheque_APPID;//应用ID
        public static string FPBM = new Utility.SiteConfig().Cheque_FLBM;//发票编码
        /// <summary>
        /// 登录
        /// </summary>
        public static string HOST_SHKJ_LOGIN_Login = "SHKJ/LOGIN/Login";
        /// <summary>
        /// 开票
        /// </summary>
        public static string HOST_SHKJ_FPKJ_SCFP = "SHKJ/FPKJ/SCFP";
        /// <summary>
        /// 获取开票结果
        /// </summary>
        public static string HOST_SHKJ_FPKJ_KPJG = "SHKJ/FPKJ/KPJG";
        /// <summary>
        /// 单独获取PDF信息
        /// </summary>
        public static string HOST_SHKJ_DZFP_PDFINFO = "SHKJ/DZFP/PDFINFO";
    }
}
