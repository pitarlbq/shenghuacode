using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Utility
{
    public class Tools
    {
        /// <summary>
        /// 转换人民币大小金额
        /// </summary>
        /// <param name="num">金额</param>
        /// <returns>返回大写形式</returns>
        public static string Md5Hash(string input)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
        public static string GetRandomString(int CodeCount)
        {
            string allChar = "1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,i,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            string[] allCharArray = allChar.Split(',');
            string RandomCode = "";
            int temp = -1;
            Random rand = new Random();
            for (int i = 0; i < CodeCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(temp * i * ((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(allCharArray.Length - 1);
                while (temp == t)
                {
                    t = rand.Next(allCharArray.Length - 1);
                }
                temp = t;
                RandomCode += allCharArray[t];
            }

            return RandomCode;
        }
        public static long GetTimeStamp(int Days = 0)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            TimeSpan ts = DateTime.Now.AddDays(Days) - startTime;
            return Convert.ToInt64(ts.TotalSeconds) * 1000;
        }
        #region 加密、解密

        // Encrypt the string.
        public static string Encrypt_Old(string PlainText)
        {
            SymmetricAlgorithm key = new DESCryptoServiceProvider()
            {
                Key = Encoding.UTF8.GetBytes("vU$5)=By"),
                IV = Encoding.UTF8.GetBytes("20180123")
            };
            // Create a memory stream.
            MemoryStream ms = new MemoryStream();

            // Create a CryptoStream using the memory stream and the 
            // CSP DES key.  
            CryptoStream encStream = new CryptoStream(ms, key.CreateEncryptor(), CryptoStreamMode.Write);

            // Create a StreamWriter to write a string
            // to the stream.
            StreamWriter sw = new StreamWriter(encStream);

            // Write the plaintext to the stream.
            sw.WriteLine(PlainText);

            // Close the StreamWriter and CryptoStream.
            sw.Close();
            encStream.Close();

            // Get an array of bytes that represents
            // the memory stream.
            byte[] buffer = ms.ToArray();

            // Close the memory stream.
            ms.Close();

            // Return the encrypted byte array.
            return Convert.ToBase64String(buffer);
        }

        // Decrypt the byte array.
        public static string Decrypt_Old(string base64Str)
        {
            byte[] CypherText = Convert.FromBase64String(base64Str);
            SymmetricAlgorithm key = new DESCryptoServiceProvider()
            {
                Key = Encoding.UTF8.GetBytes("vU$5)=By"),
                IV = Encoding.UTF8.GetBytes("20180123")
            };
            // Create a memory stream to the passed buffer.
            MemoryStream ms = new MemoryStream(CypherText);

            // Create a CryptoStream using the memory stream and the 
            // CSP DES key. 
            CryptoStream encStream = new CryptoStream(ms, key.CreateDecryptor(), CryptoStreamMode.Read);

            // Create a StreamReader for reading the stream.
            StreamReader sr = new StreamReader(encStream);

            // Read the stream as a string.
            string val = sr.ReadLine();

            // Close the streams.
            sr.Close();
            encStream.Close();
            ms.Close();

            return val;
        }
        /// <summary>  
        /// DES加密算法  
        /// sKey为8位或16位  
        /// </summary>  
        /// <param name="pToEncrypt">需要加密的字符串</param>  
        /// <param name="sKey">密钥</param>  
        /// <returns></returns>  
        public static string sKey = "saasyy06";
        public static string Encrypt(string pToEncrypt)
        {
            StringBuilder ret = new StringBuilder();

            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                foreach (byte b in ms.ToArray())
                {
                    ret.AppendFormat("{0:X2}", b);
                }
                ret.ToString();
            }
            catch
            {
            }
            return ret.ToString();
        }
        /// <summary>  
        /// DES解密算法  
        /// sKey为8位或16位  
        /// </summary>  
        /// <param name="pToDecrypt">需要解密的字符串</param>  
        /// <param name="sKey">密钥</param>  
        /// <returns></returns>  
        public static string Decrypt(string pToDecrypt)
        {
            MemoryStream ms = new MemoryStream();
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
                for (int x = 0; x < pToDecrypt.Length / 2; x++)
                {
                    int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                    inputByteArray[x] = (byte)i;
                }
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);

                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                StringBuilder ret = new StringBuilder();
            }
            catch
            {

            }
            return System.Text.Encoding.Default.GetString(ms.ToArray());
        }
        #endregion
        public static string GetByteString(int length = 4)
        {
            string s = GetRandomString(4, useLow: true, useUpp: true);
            Encoding encode = Encoding.UTF8;
            byte[] b = encode.GetBytes(s);//按照指定编码将string编程字节数组
            string result = string.Empty;
            for (int i = 0; i < b.Length; i++)//逐字节变为16进制字符
            {
                result += Convert.ToString(b[i], 16);
            }
            return result;
        }
        public static string GetRandomString(int length, bool useNum = false, bool useLow = false, bool useUpp = true)
        {
            string str = string.Empty;
            byte[] b = new byte[4];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
            Random r = new Random(BitConverter.ToInt32(b, 0));
            string s = null;
            if (useNum == true) { str += "0123456789"; }
            if (useLow == true) { str += "abcdefghijklmnopqrstuvwxyz"; }
            if (useUpp == true) { str += "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; }
            for (int i = 0; i < length; i++)
            {
                s += str.Substring(r.Next(0, str.Length - 1), 1);
            }
            return s;
        }
        public static T GetValueFromDic<T>(Dictionary<string, object> dic, string key)
        {
            if (dic.ContainsKey(key))
            {
                var value = dic[key];
                return (T)value;
            }
            return default(T);
        }
        public static string GetContextPath()
        {
            string domain_path = "http://" + HttpContext.Current.Request.ServerVariables["HTTP_HOST"].ToString();
            if (domain_path.EndsWith("/"))
            {
                domain_path = domain_path.Substring(0, domain_path.Length - 1);
            }
            return domain_path + getApplicationPath();
        }
        public static string getApplicationPath()
        {
            string _ApplicationPath = HttpContext.Current.Request.ApplicationPath;
            if (_ApplicationPath.Length == 1)
            {
                _ApplicationPath = "";
            }
            else if (!_ApplicationPath.StartsWith("/"))
            {
                _ApplicationPath = "/" + _ApplicationPath;
            }
            return _ApplicationPath;
        }
        public static int GetAppVersionCode(string version)
        {
            try
            {
                if (string.IsNullOrEmpty(version))
                {
                    return 0;
                }
                string[] version_array = version.Split('.');
                string versioncode = string.Empty;
                for (int i = 0; i < version_array.Length; i++)
                {
                    var item = version_array[i];
                    if (i > 0)
                    {
                        versioncode += Convert.ToInt32(item).ToString("D2");
                        continue;
                    }
                    versioncode += item;
                }
                LogHelper.WriteInfo("version." + version, Convert.ToInt32(versioncode).ToString());
                return Convert.ToInt32(versioncode);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static bool CheckVersionCode(string newversion, string oldversion)
        {
            return GetAppVersionCode(newversion) < GetAppVersionCode(oldversion);
        }
        public static string GetJosnValue(string jsonStr, string key, bool IncludeDoubleMarks = true)
        {
            string result = string.Empty;
            if (!IsNullOrWhiteSpace(jsonStr))
            {
                if (IncludeDoubleMarks)
                {
                    key = "\"" + key.Trim('"') + "\"";
                }
                else
                {
                    key = key.Trim('"');
                }
                int index = jsonStr.IndexOf(key) + key.Length + 1;
                if (index > key.Length + 1)
                {
                    //先截逗号，若是最后一个，截“｝”号，取最小值

                    int end = jsonStr.IndexOf(',', index);
                    if (end == -1)
                    {
                        end = jsonStr.IndexOf('}', index);
                    }
                    //index = json.IndexOf('"', index + key.Length + 1) + 1;
                    result = jsonStr.Substring(index, end - index);
                    //过滤引号或空格
                    result = result.Trim(new char[] { '"', ' ', '\'' });
                }
            }
            return result;
        }
        public static bool IsNullOrWhiteSpace(string value)
        {
            if (value != null)
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (!char.IsWhiteSpace(value[i]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static DateTime GetDateTimeByTimeStamp(long timeSpan)
        {
            DateTime start = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            TimeSpan ts = new TimeSpan(timeSpan * 10000);
            return start.Add(ts);
        }
        public static bool IsNumeric(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$");
        }
        public static string GetVerifyCode()
        {
            Random rnd = new Random();
            string VerifyCode = rnd.Next(1000, 9999).ToString();
            return VerifyCode;
        }
    }
}
